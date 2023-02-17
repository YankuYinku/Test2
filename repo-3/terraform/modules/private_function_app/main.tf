module "app_service_plan" {
  source               = "../appServicePlan"
  environment          = var.environment
  name                 = var.functionAppName
  app_service_plan_sku = var.app_service_plan_sku
}

module "function_app" {
  depends_on = [module.app_service_plan]

  source = "../functionApp"

  appInsightsRessourceName                = var.appInsightsRessourceName
  environment                             = var.environment
  functionAppName                         = var.functionAppName
  imageName                               = var.imageName
  location                                = var.location
  oldInfrastructureResourceGroupName      = var.oldInfrastructureResourceGroupName
  oldKeyVaultName                         = var.oldKeyVaultName
  servicePrincipalClientId_SecretName     = var.servicePrincipalClientId_SecretName
  servicePrincipalClientSecret_SecretName = var.servicePrincipalClientSecret_SecretName
  servicePrincipalTennantId_SecretName    = var.servicePrincipalTennantId_SecretName
  app_service_plan_name                   = var.functionAppName
}