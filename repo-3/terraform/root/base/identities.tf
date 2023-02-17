resource "azurerm_user_assigned_identity" "application_gateway_key_vault_reader" {
  resource_group_name = azurerm_resource_group.resource_group.name
  location            = azurerm_resource_group.resource_group.location

  name = format("%s_%s_%s", var.environment, var.application_name, "application_gateway")
}

# This identity needs "Key Vault Secrets User" role on the key vault. 
# Needs admin privileges to create a role assignment. 
resource "azurerm_role_assignment" "application_gateway_key_vault_reader_role_assignment" {
  scope                            = data.azurerm_key_vault.oldkeyvault.id
  role_definition_name             = "Key Vault Secrets User"
  principal_id                     = azurerm_user_assigned_identity.application_gateway_key_vault_reader.principal_id
  skip_service_principal_aad_check = true
}
