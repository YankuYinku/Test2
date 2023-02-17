data "azurerm_resource_group" "meinapetitoresourcegroup" {
  name = format("%s_%s", var.environment, var.application_name)
}

data "azurerm_resource_group" "infrastructureresourcegroup"{
  name = var.oldInfrastructureResourceGroupName
}

data "azurerm_key_vault" "keyvault" {
  name                 = var.oldKeyVaultName
  resource_group_name  = data.azurerm_resource_group.infrastructureresourcegroup.name
}