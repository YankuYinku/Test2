resource "azurerm_subnet" "outbound_subnet" {
  name                 = "${var.functionAppName}_outbound"
  address_prefixes     = [var.function_outbound_subnet_address_prefix]
  resource_group_name  = data.azurerm_resource_group.resource_group.name
  virtual_network_name = data.azurerm_virtual_network.virtual_network.name

  delegation {
    name = "delegation"
    service_delegation {
      actions = ["Microsoft.Network/virtualNetworks/subnets/action"]
      name    = "Microsoft.Web/serverFarms"
    }
  }
}

resource "azurerm_app_service_virtual_network_swift_connection" "swift_connection" {
  subnet_id      = azurerm_subnet.outbound_subnet.id
  app_service_id = module.function_app.function_app_id
}

resource "azurerm_private_endpoint" "private_app_service_endpoint" {
  location            = data.azurerm_resource_group.resource_group.location
  resource_group_name = data.azurerm_resource_group.resource_group.name
  name                = "${var.environment}_${var.application_name}_${var.functionAppName}"
  subnet_id           = data.azurerm_subnet.inbound_subnet.id

  private_dns_zone_group {
    name                 = "private_dns_link_app_service"
    private_dns_zone_ids = [data.azurerm_private_dns_zone.privatelink_app_service.id]
  }

  private_service_connection {
    is_manual_connection           = false
    name                           = "private_endpoint_connection"
    private_connection_resource_id = module.function_app.function_app_id
    subresource_names              = ["sites"]
  }
}
