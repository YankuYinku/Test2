resource "azurerm_subnet" "applicationgatewaysubnet" {
  name                 = format("%s_%s_%s", var.environment, var.application_name, "applicationgateway")
  virtual_network_name = data.azurerm_virtual_network.meinapetito_vnet.name
  resource_group_name  = data.azurerm_resource_group.meinapetito_resourcegroup.name
  address_prefixes     = [var.applicationgatewaySubnetAddressSpace]
}

resource "azurerm_network_security_group" "applicationgatewaysubnet_security_group" {
  name                = format("%s_%s_%s", var.environment, var.application_name, "applicationgateway")
  location            = data.azurerm_resource_group.meinapetito_resourcegroup.location
  resource_group_name = data.azurerm_resource_group.meinapetito_resourcegroup.name

  security_rule {
    name                       = "GatewayManager"
    priority                   = 1001
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "GatewayManager"
    destination_address_prefix = "*"
  }

  security_rule {
    name                       = "Internet-PublicIP"
    priority                   = 1002
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }

  security_rule {
      name                       = "HTTP-Inbound-ForRedirects"
      priority                   = 1004
      direction                  = "Inbound"
      access                     = "Allow"
      protocol                   = "Tcp"
      source_address_prefix      = "*"
      source_port_range          = "*"
      destination_port_range     = "80"
      destination_address_prefix = "*"
  }

  security_rule {
    access                     = "Allow"
    direction                  = "Inbound"
    name                       = format("%s_%s_Loadbalancer", var.environment, var.application_name)
    priority                   = 1005
    protocol                   = "*"
    source_address_prefix      = "AzureLoadBalancer"
    source_port_range          = "*"
    destination_address_prefix = "*"
    destination_port_range     = "*"
  }

  security_rule {
    name                       = format("%s_%s_GatewayManager", var.environment, var.application_name)
    priority                   = 1003
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_address_prefix      = "GatewayManager"
    source_port_range          = "*"
    destination_port_range     = "65200-65535"
    destination_address_prefix = "*"
  }

  security_rule {
    name                       = "OutboundToAzureCloud"
    priority                   = 1002
    direction                  = "Outbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "*"
    destination_address_prefix = "AzureCloud"
  }
}

resource "azurerm_subnet_network_security_group_association" "applicationGateway_subnet_security_group_association" {
  network_security_group_id = azurerm_network_security_group.applicationgatewaysubnet_security_group.id
  subnet_id                 = azurerm_subnet.applicationgatewaysubnet.id
}

resource "azurerm_public_ip" "applicationGateway_public_ip" {
  name                = format("%s_%s_%s", var.environment, var.application_name, "applicationgateway")
  resource_group_name = data.azurerm_resource_group.meinapetito_resourcegroup.name
  location            = data.azurerm_resource_group.meinapetito_resourcegroup.location
  allocation_method   = "Static"
  domain_name_label   = format("%s-%s", var.environment, var.application_name)
  sku                 = "Standard"
  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}


resource "azurerm_route_table" "routing_from_applicationGateway" {
  name                = "${var.environment}_${var.application_name}_routing_applicationgateway"
  location            = data.azurerm_resource_group.meinapetito_resourcegroup.location
  resource_group_name = data.azurerm_resource_group.meinapetito_resourcegroup.name

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}

resource "azurerm_subnet_route_table_association" "subnetlink" {
  subnet_id      = azurerm_subnet.applicationgatewaysubnet.id
  route_table_id = azurerm_route_table.routing_from_applicationGateway.id
}

resource "azurerm_route" "ApplicationGateway_To_Infrastructure" {
  name                   = "To_Infrastructure"
  resource_group_name    = data.azurerm_resource_group.meinapetito_resourcegroup.name
  route_table_name       = azurerm_route_table.routing_from_applicationGateway.name
  address_prefix         = var.infrastructureSubnetAddressSpace
  next_hop_type          = "VirtualAppliance"
  next_hop_in_ip_address = data.azurerm_firewall.infrastructure-firewallip.ip_configuration.0.private_ip_address
}

resource "azurerm_route" "ApplicationGateway_To_SharedApplicationGateway" {
  name                   = "To_SharedApplicationGateway"
  resource_group_name    = data.azurerm_resource_group.meinapetito_resourcegroup.name
  route_table_name       = azurerm_route_table.routing_from_applicationGateway.name
  address_prefix         = var.sharedApplicationGatewaysSubnetAddressSpace
  next_hop_type          = "VirtualAppliance"
  next_hop_in_ip_address = data.azurerm_firewall.infrastructure-firewallip.ip_configuration.0.private_ip_address
}


// DNS Zone link

resource "azurerm_private_dns_zone_virtual_network_link" "apebs_dns_zone_virtual_network_link" {
  name                  = format("%s.apebs.de_%s", var.environment, var.application_name)
  resource_group_name   = data.azurerm_private_dns_zone.apebs_dns_zone.resource_group_name
  private_dns_zone_name = data.azurerm_private_dns_zone.apebs_dns_zone.name
  virtual_network_id    = data.azurerm_virtual_network.meinapetito_vnet.id
  registration_enabled  = false

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}

resource "azurerm_private_dns_zone_virtual_network_link" "privatelink_dns_zone_virtual_network_link" {
  name                  = format("%s_%s", var.environment, var.application_name)
  resource_group_name   = data.azurerm_private_dns_zone.privatelink_dns_zone.resource_group_name
  private_dns_zone_name = data.azurerm_private_dns_zone.privatelink_dns_zone.name
  virtual_network_id    = data.azurerm_virtual_network.meinapetito_vnet.id
  registration_enabled  = false

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}

resource "azurerm_private_dns_zone_virtual_network_link" "privatelink_database_dns_zone_virtual_network_link" {
  name                  = format("%s_%s", var.environment, var.application_name)
  resource_group_name   = data.azurerm_private_dns_zone.privatelink_database_dns_zone.resource_group_name
  private_dns_zone_name = data.azurerm_private_dns_zone.privatelink_database_dns_zone.name
  virtual_network_id    = data.azurerm_virtual_network.meinapetito_vnet.id
  registration_enabled  = false

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}