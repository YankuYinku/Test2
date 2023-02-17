locals {
  frontend_port_name             = "${data.azurerm_virtual_network.meinapetito_vnet.name}-feport"
  frontend_port_name_https       = "${data.azurerm_virtual_network.meinapetito_vnet.name}-feport-https"
  frontend_ip_configuration_name = "${data.azurerm_virtual_network.meinapetito_vnet.name}-feip"

  applications = [
    for index, application in var.applications : {

      http_listener_name_http                = format("%s-%s-httplstn-http", data.azurerm_virtual_network.meinapetito_vnet.name, application["name"])
      http_listener_name_https               = format("%s-%s-httplstn-https", data.azurerm_virtual_network.meinapetito_vnet.name, application["name"])
      redirect_configuration_name            = format("%s-%s-rdrcfg", data.azurerm_virtual_network.meinapetito_vnet.name, application["name"])
      redirect_configuration_app_to_app_name = format("%s-%s-rdrcfg-https", data.azurerm_virtual_network.meinapetito_vnet.name, application["name"])
      backend_address_pool_name              = format("%s-%s-beap", data.azurerm_virtual_network.meinapetito_vnet.name, application["name"])
      backend_http_settings_name             = format("%s-%s-be-htst", data.azurerm_virtual_network.meinapetito_vnet.name, application["name"])
      probe_name                             = format("%s-%s-probe", data.azurerm_virtual_network.meinapetito_vnet.name, application["name"])
      redirect_request_routing_rule_name     = format("%s-%s-rqrt", data.azurerm_virtual_network.meinapetito_vnet.name, application["name"])
      request_routing_rule_name              = format("%s-%s-rqrt-https", data.azurerm_virtual_network.meinapetito_vnet.name, application["name"])
      request_timeout                        = application["request_timeout"]
      health_probe_path                      = application["health_probe_path"]
      ssl_certificate_name                   = application["ssl_certificate_name"]

      host_names                 = application["host_names"]
      backend_target_type        = application["backend_target_type"]
      backend_target             = application["backend_target"]
      backend_target_listener    = application["backend_target_type"] == "redirect" ? format("%s-%s-httplstn-https", data.azurerm_virtual_network.meinapetito_vnet.name, application["backend_target"]) : null
      backend_port               = application["ssl_termination"] ? 80 : 443
      backend_protocol           = application["ssl_termination"] ? "Http" : "Https"
      backend_override_host_name = application["backend_target_type"] == "fqdn" ? true : false

      priority = 1000 + (index * 100)
    }
  ]
}


resource "azurerm_application_gateway" "meinapetito" {
  name                = format("%s_%s", var.environment, var.application_name)
  resource_group_name = data.azurerm_resource_group.meinapetito_resourcegroup.name
  location            = data.azurerm_resource_group.meinapetito_resourcegroup.location

  sku {
    name     = "WAF_v2"
    tier     = "WAF_v2"
    capacity = 2
  }

  identity {
    type = "UserAssigned"
    identity_ids = [
      data.azurerm_user_assigned_identity.application_gateway_key_vault_reader.id
    ]
  }

  waf_configuration {
    enabled                  = true
    file_upload_limit_mb     = 100
    firewall_mode            = "Detection"
    max_request_body_size_kb = 128
    request_body_check       = true
    rule_set_type            = "OWASP"
    rule_set_version         = "3.0"
  }

  gateway_ip_configuration {
    name      = "frontend_ipconfiguration"
    subnet_id = azurerm_subnet.applicationgatewaysubnet.id
  }

  frontend_port {
    name = local.frontend_port_name
    port = 80
  }

  frontend_port {
    name = local.frontend_port_name_https
    port = 443
  }

  frontend_ip_configuration {
    name                 = local.frontend_ip_configuration_name
    public_ip_address_id = azurerm_public_ip.applicationGateway_public_ip.id
  }

  #
  # http_listener
  #

  # http listeners: HTTPS
  dynamic "http_listener" {
    for_each = local.applications
    content {
      name                           = http_listener.value["http_listener_name_https"]
      frontend_ip_configuration_name = local.frontend_ip_configuration_name
      frontend_port_name             = local.frontend_port_name_https
      protocol                       = "Https"
      host_names                     = http_listener.value["host_names"]
      require_sni                    = true
      ssl_certificate_name           = http_listener.value["ssl_certificate_name"]
      ssl_profile_name               = "${var.environment}_${var.application_name}_ssl_profile_strict"
    }
  }

  ## for an application of type redirect, create a redirect configuration for https that redirects to the listener given in the backend_target property
  dynamic "redirect_configuration" {
    for_each = [for n in local.applications : n if n.backend_target_type == "redirect"]
    content {
      name                 = redirect_configuration.value["redirect_configuration_app_to_app_name"]
      redirect_type        = "Permanent"
      target_listener_name = redirect_configuration.value["backend_target_listener"]
      include_path         = true
      include_query_string = true
    }
  }

  # http listeners: HTTP & Redirect config to HTTPS
  dynamic "http_listener" {
    for_each = local.applications
    content {
      name                           = http_listener.value["http_listener_name_http"]
      frontend_ip_configuration_name = local.frontend_ip_configuration_name
      frontend_port_name             = local.frontend_port_name
      protocol                       = "Http"
      host_names                     = http_listener.value["host_names"]
      require_sni                    = false
    }
  }

  dynamic "redirect_configuration" {
    for_each = local.applications
    content {
      name                 = redirect_configuration.value["redirect_configuration_name"]
      redirect_type        = "Permanent"
      target_listener_name = redirect_configuration.value["http_listener_name_https"]
      include_path         = true
      include_query_string = true
    }
  }

  #
  # Backend pools & settings (only created for backend_target_type "ip" of "fqdn" and not for "redirect", because the redirect has a different applicatn as a target)
  #

  dynamic "backend_address_pool" {
    for_each = [
      for ip_app in local.applications : ip_app
      if ip_app.backend_target_type == "ip"
    ]
    content {
      name = backend_address_pool.value["backend_address_pool_name"]
      ip_addresses = [
        backend_address_pool.value["backend_target"]
      ]
    }
  }

  dynamic "backend_address_pool" {
    for_each = [
      for fqdn_app in local.applications : fqdn_app
      if fqdn_app.backend_target_type == "fqdn"
    ]
    content {
      name = backend_address_pool.value["backend_address_pool_name"]
      fqdns = [
        backend_address_pool.value["backend_target"]
      ]
    }
  }

  dynamic "backend_http_settings" {
    for_each = local.applications

    content {
      name                                = backend_http_settings.value["backend_http_settings_name"]
      port                                = backend_http_settings.value["backend_port"]
      protocol                            = backend_http_settings.value["backend_protocol"]
      cookie_based_affinity               = "Disabled"
      request_timeout                     = backend_http_settings.value["request_timeout"]
      probe_name                          = backend_http_settings.value["probe_name"]
      pick_host_name_from_backend_address = backend_http_settings.value["backend_override_host_name"]

      connection_draining {
        drain_timeout_sec = 60
        enabled           = true
      }
    }
  }

  dynamic "probe" {
    for_each = local.applications
    content {
      name                                      = probe.value["probe_name"]
      pick_host_name_from_backend_http_settings = probe.value["backend_override_host_name"]
      host                                      = probe.value["backend_override_host_name"] ? null : element(probe.value["host_names"], 0)
      interval                                  = 30
      minimum_servers                           = 0
      path                                      = probe.value["health_probe_path"]
      port                                      = probe.value["backend_port"]
      protocol                                  = probe.value["backend_protocol"]
      timeout                                   = 30
      unhealthy_threshold                       = 3
    }
  }


  #
  # Routing rules
  #

  # redrict routing rules
  dynamic "request_routing_rule" {
    for_each = local.applications

    content {
      name                        = request_routing_rule.value["redirect_request_routing_rule_name"]
      rule_type                   = "Basic"
      http_listener_name          = request_routing_rule.value["http_listener_name_http"]
      redirect_configuration_name = request_routing_rule.value["redirect_configuration_name"]
      priority                    = request_routing_rule.value["priority"] + 50
    }
  }

  # actual routing rules
  # here we split the applications into ["ip", "fqdn"] and "redirect". The first two get a request routing rule that routes to a backend pool
  # The redirect app gets a request routing rule which is a redirect to the application stated in the backend_target of the redirect app
  dynamic "request_routing_rule" {
    for_each = [
      for app in local.applications : app
      if app.backend_target_type == "ip" || app.backend_target_type == "fqdn"
    ]

    content {
      name                       = request_routing_rule.value["request_routing_rule_name"]
      rule_type                  = "Basic"
      http_listener_name         = request_routing_rule.value["http_listener_name_https"]
      backend_address_pool_name  = request_routing_rule.value["backend_address_pool_name"]
      backend_http_settings_name = request_routing_rule.value["backend_http_settings_name"]
      priority                   = request_routing_rule.value["priority"]
    }
  }

  # for redirect applications the "acutal routing rule" is again a redirect 
  dynamic "request_routing_rule" {
    for_each = [
      for app in local.applications : app
      if app.backend_target_type == "redirect"
    ]

    content {
      name                        = request_routing_rule.value["request_routing_rule_name"]
      rule_type                   = "Basic"
      http_listener_name          = request_routing_rule.value["http_listener_name_https"]
      redirect_configuration_name = request_routing_rule.value["redirect_configuration_app_to_app_name"]
      priority                    = request_routing_rule.value["priority"] + 25
    }
  }
  
  #
  # SSL Configuration
  #

  dynamic "ssl_certificate" {
    for_each = data.azurerm_key_vault_certificate.certificates
    content {
      name                = ssl_certificate.value["name"]
      key_vault_secret_id = ssl_certificate.value["versionless_secret_id"]
    }
  }

  ssl_profile {
    name                         = "${var.environment}_${var.application_name}_ssl_profile"
    verify_client_cert_issuer_dn = false
    ssl_policy {
      policy_name = "AppGwSslPolicy20170401S"
      policy_type = "Predefined"
    }
  }

  ssl_profile {
    name                         = "${var.environment}_${var.application_name}_ssl_profile_strict"
    verify_client_cert_issuer_dn = false
    ssl_policy {
      policy_name          = "SecureSSL"
      policy_type          = "Custom"
      cipher_suites        = ["TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256", "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384", "TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384", "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384"]
      min_protocol_version = "TLSv1_2"
    }
  }

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}
