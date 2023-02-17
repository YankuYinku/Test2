data "azurerm_client_config" "current" {}

data "azuread_group" "adg" {
  display_name = var.adminAdGroup
}

data "azurerm_resource_group" "infrastructureresourcegroup" {
  name = var.oldInfrastructureResourceGroupName
}

data "azurerm_resource_group" "resourcegroup" {
  name = format("%s_%s", var.environment, var.application_name)
}

data "azurerm_key_vault" "keyvault" {
  name                = var.oldKeyVaultName
  resource_group_name = data.azurerm_resource_group.infrastructureresourcegroup.name
}

data "azurerm_key_vault_secret" "sqlAdminUserName" {
  name         = "apetito-meinapetito-sqldatabase-sa-user"
  key_vault_id = data.azurerm_key_vault.keyvault.id
}

data "azurerm_key_vault_secret" "sqlAdminPassword" {
  name         = "apetito-meinapetito-sqldatabase-sa-password"
  key_vault_id = data.azurerm_key_vault.keyvault.id
}

data "azurerm_storage_account" "meinapetito_storage_account" {
  name                = format("%s%s%s", "ap", var.environment, var.application_name)
  resource_group_name = data.azurerm_resource_group.resourcegroup.name
}

data "azurerm_public_ip" "firewallpublicip" {
  name                = "${var.environment}_infrastructure_firewall"
  resource_group_name = "${var.environment}_infrastructure"
}

data "azurerm_private_dns_zone" "privatelink_database" {
  name                = "privatelink.database.windows.net"
  resource_group_name = "${var.environment}_infrastructure"
}

data "azurerm_virtual_network" "vnet" {
  name                = "${var.environment}_${var.application_name}"
  resource_group_name = data.azurerm_resource_group.resourcegroup.name
}