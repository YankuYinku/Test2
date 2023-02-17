data "azurerm_key_vault" "keyvault" {
  name                = var.oldKeyVaultName
  resource_group_name = var.oldInfrastructureResourceGroupName
}

data "azurerm_key_vault_secret" "service_principal_client_ids" {
  name         = var.servicePrincipalClientId_SecretName
  key_vault_id = data.azurerm_key_vault.keyvault.id
}

data "azurerm_key_vault_secret" "service_principal_client_secrets" {
  name         = var.servicePrincipalClientSecret_SecretName
  key_vault_id = data.azurerm_key_vault.keyvault.id
}

data "azurerm_key_vault_secret" "service_principal_tennant_ids" {
  name         = var.servicePrincipalTennantId_SecretName
  key_vault_id = data.azurerm_key_vault.keyvault.id
}