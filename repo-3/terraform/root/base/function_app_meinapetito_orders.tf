module "meinapetito_orders_function_app" {
  depends_on = [
    azurerm_subnet.inbound_subnet
  ]

  source                                  = "../../modules/private_function_app"
  environment                             = var.environment
  location                                = var.location
  functionAppName                         = "${var.environment}-meinapetito-orders"
  imageName                               = "meinapetito-orders"
  appInsightsRessourceName                = "meinapetito.core.${var.environment}"
  servicePrincipalClientId_SecretName     = "apetito-meinapetito-serviceprincipal-clientid"
  servicePrincipalClientSecret_SecretName = "apetito-meinapetito-serviceprincipal-clientsecret"
  servicePrincipalTennantId_SecretName    = "apetito-Azure-TenantId"
  oldInfrastructureResourceGroupName      = var.oldInfrastructureResourceGroupName
  oldKeyVaultName                         = var.oldKeyVaultName
  function_outbound_subnet_address_prefix = var.meinapetito_orders_function_app_outbound_subnet_prefix
  app_service_plan_sku                    = var.app_service_plan_sku
}