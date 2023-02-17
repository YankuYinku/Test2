data "azurerm_resource_group" "meinapetito_resourcegroup" {
  name = format("%s_%s", var.environment, var.application_name)
}

data "azurerm_service_plan" "app_service_plan" {
  name                = var.app_service_plan_name
  resource_group_name = data.azurerm_resource_group.meinapetito_resourcegroup.name
}

data "azurerm_storage_account" "meinapetito_storage_account" {
  name                = format("%s%s%s", "ap", var.environment, var.application_name)
  resource_group_name = data.azurerm_resource_group.meinapetito_resourcegroup.name
}

data "azurerm_application_insights" "application_insights" {
  name                = var.appInsightsRessourceName
  resource_group_name = "RGAppInsights"
}

data "azurerm_container_registry" "apetitoebusinesssolutions" {
  name                = "apetitoebusinesssolutions"
  resource_group_name = "production_infrastructure"
}
