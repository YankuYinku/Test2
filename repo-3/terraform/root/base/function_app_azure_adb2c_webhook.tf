module "azureADB2CWebhookFunctionApp" {
  depends_on = [
    module.meinapetito_functions_appserviceplan
  ]

  source                                  = "../../modules/functionApp"
  environment                             = var.environment
  location                                = var.location
  functionAppName                         = "${var.environment}-meinapetito-webhook-adb2c"
  imageName                               = "meinapetito-webhooks-azureadb2c-api"
  appInsightsRessourceName                = "meinapetito.core.${var.environment}"
  servicePrincipalClientId_SecretName     = "apetito-meinapetito-serviceprincipal-clientid"
  servicePrincipalClientSecret_SecretName = "apetito-meinapetito-serviceprincipal-clientsecret"
  servicePrincipalTennantId_SecretName    = "apetito-Azure-TenantId"
  oldInfrastructureResourceGroupName      = var.oldInfrastructureResourceGroupName
  oldKeyVaultName                         = var.oldKeyVaultName
  app_service_plan_name                   = format("%s_%s_functions", var.environment, var.application_name)
}
