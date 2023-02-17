

resource "azurerm_servicebus_namespace" "meinapetito" {
  name                = format("%s-%s-%s", var.environment, var.application_name, var.version_number) 
  location            = data.azurerm_resource_group.meinapetitoresourcegroup.location
  resource_group_name = data.azurerm_resource_group.meinapetitoresourcegroup.name
  sku                 = "Standard"

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}

resource "azurerm_key_vault_secret" "meinapetito_azureservicebusnamespace_primaryconnectionstring" {
  name         = "apetito-meinapetito-azureservicebusnamespace-primaryconnectionstring-${var.version_number}"
  value        = azurerm_servicebus_namespace.meinapetito.default_primary_connection_string
  key_vault_id = data.azurerm_key_vault.keyvault.id
}