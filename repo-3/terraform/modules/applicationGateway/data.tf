data "azurerm_resource_group" "meinapetito_resourcegroup" {
  name = format("%s_%s", var.environment, var.application_name)
}

data "azurerm_resource_group" "oldinfrastructureresourcegroup" {
  name = var.oldInfrastructureResourceGroupName
}

data "azurerm_virtual_network" "meinapetito_vnet" {
  name                = format("%s_%s", var.environment, var.application_name)
  resource_group_name = data.azurerm_resource_group.meinapetito_resourcegroup.name
}

data "azurerm_user_assigned_identity" "application_gateway_key_vault_reader" {
  name                = format("%s_%s_%s", var.environment, var.application_name, "application_gateway")
  resource_group_name = data.azurerm_resource_group.meinapetito_resourcegroup.name
}

data "azurerm_key_vault" "oldkeyvault" {
  name                = var.oldKeyVaultName
  resource_group_name = data.azurerm_resource_group.oldinfrastructureresourcegroup.name
}

data "azurerm_key_vault_certificate" "certificates" {
  for_each     = toset(distinct(var.certificates))
  name         = each.value
  key_vault_id = data.azurerm_key_vault.oldkeyvault.id
}

data "azurerm_resource_group" "infrastructure" {
  name                = "${var.environment}_infrastructure"
}

data "azurerm_firewall" "infrastructure-firewallip" {
  name                = "${var.environment}_infrastructure_firewall"
  resource_group_name = data.azurerm_resource_group.infrastructure.name
  
}

data "azurerm_private_dns_zone" "apebs_dns_zone" {
  name                = format("%s.apebs.de", var.environment)
  resource_group_name = data.azurerm_resource_group.infrastructure.name
}

data "azurerm_private_dns_zone" "privatelink_dns_zone" {
  name                = "privatelink.azurewebsites.net"
  resource_group_name = data.azurerm_resource_group.infrastructure.name
}

data "azurerm_private_dns_zone" "privatelink_database_dns_zone" {
  name                = "privatelink.database.windows.net"
  resource_group_name = data.azurerm_resource_group.infrastructure.name
}