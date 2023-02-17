data "azurerm_resource_group" "resource_group" {
  name = format("%s_%s", var.environment, var.application_name)
}

data "azurerm_resource_group" "infrastructure" {
  name = "${var.environment}_infrastructure"
}

data "azurerm_virtual_network" "virtual_network" {
  name                = format("%s_%s", var.environment, var.application_name)
  resource_group_name = data.azurerm_resource_group.resource_group.name
}

data "azurerm_private_dns_zone" "privatelink_app_service" {
  name                = "privatelink.azurewebsites.net"
  resource_group_name = data.azurerm_resource_group.infrastructure.name
}

data "azurerm_subnet" "inbound_subnet" {
  name                 = "${var.environment}_${var.application_name}_inbound"
  resource_group_name  = data.azurerm_resource_group.resource_group.name
  virtual_network_name = data.azurerm_virtual_network.virtual_network.name
}