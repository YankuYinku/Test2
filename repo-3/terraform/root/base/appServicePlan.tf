module "meinapetito_functions_appserviceplan" {
  depends_on = [
    azurerm_resource_group.resource_group,
    azurerm_storage_account.meinapetito_storage_account
  ]

  source = "../../modules/appServicePlan"

  name                 = format("%s_%s_functions", var.environment, var.application_name)
  environment          = var.environment
  app_service_plan_sku = var.app_service_plan_sku
}
