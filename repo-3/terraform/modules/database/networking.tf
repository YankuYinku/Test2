resource "azurerm_subnet" "database_subnet" {
  address_prefixes     = [var.database_subnet_address_prefix]
  name                 = "${var.environment}_${var.application_name}_database"
  resource_group_name  = data.azurerm_resource_group.resourcegroup.name
  virtual_network_name = data.azurerm_virtual_network.vnet.name
}

resource "azurerm_network_security_group" "database" {
  location            = var.location
  name                = "${var.environment}_${var.application_name}_database"
  resource_group_name = data.azurerm_resource_group.resourcegroup.name

  security_rule {
    access                     = "Allow"
    direction                  = "Inbound"
    name                       = "Allow-SQL-Inbound"
    priority                   = 1000
    protocol                   = "Tcp"
    destination_port_range     = "1433"
    destination_address_prefix = "*"
    source_address_prefixes    = data.azurerm_virtual_network.vnet.address_space
    source_port_range          = "*"
  }
}

resource "azurerm_subnet_network_security_group_association" "database" {
  network_security_group_id = azurerm_network_security_group.database.id
  subnet_id                 = azurerm_subnet.database_subnet.id
}

resource "azurerm_private_endpoint" "database_private_endpoint" {
  name                = "${var.environment}_${var.application_name}_database"
  resource_group_name = data.azurerm_resource_group.resourcegroup.name
  location            = data.azurerm_resource_group.resourcegroup.location
  subnet_id           = azurerm_subnet.database_subnet.id

  private_dns_zone_group {
    name                 = "${var.environment}_${var.application_name}_database"
    private_dns_zone_ids = [data.azurerm_private_dns_zone.privatelink_database.id]
  }

  private_service_connection {
    is_manual_connection           = false
    name                           = "${var.environment}_${var.application_name}_database"
    private_connection_resource_id = azurerm_mssql_server.meinapetitosqlserver.id
    subresource_names              = ["sqlServer"]
  }
}