module "meinapetito_databases" {
  depends_on = [
    azurerm_resource_group.resource_group,
    azurerm_storage_account.meinapetito_storage_account
  ]

  source = "../../modules/database"

  environment                        = var.environment
  oldInfrastructureResourceGroupName = var.oldInfrastructureResourceGroupName
  oldKeyVaultName                    = var.oldKeyVaultName
  adminAdGroup                       = "+Systementwicklung-Web"
  portal_db_sku                      = var.portal_db_sku
  database_subnet_address_prefix     = var.database_subnet_address_prefix
}

