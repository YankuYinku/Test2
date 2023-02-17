module "recipieChangeWebhookFunctionApp" {
  depends_on = [
    azurerm_subnet.inbound_subnet
  ]

  source                                  = "../../modules/private_function_app"
  environment                             = var.environment
  location                                = var.location
  functionAppName                         = "${var.environment}-meinapetito-adapter-recipe-changed"
  imageName                               = "meinapetito-adapters-recipe-changed"
  appInsightsRessourceName                = "meinapetito.core.${var.environment}"
  servicePrincipalClientId_SecretName     = "apetito-meinapetito-serviceprincipal-clientid"
  servicePrincipalClientSecret_SecretName = "apetito-meinapetito-serviceprincipal-clientsecret"
  servicePrincipalTennantId_SecretName    = "apetito-Azure-TenantId"
  oldInfrastructureResourceGroupName      = var.oldInfrastructureResourceGroupName
  oldKeyVaultName                         = var.oldKeyVaultName
  function_outbound_subnet_address_prefix = var.recipie_change_webhook_function_app_outbound_subnet_prefix
  app_service_plan_sku                    = var.app_service_plan_sku
}
