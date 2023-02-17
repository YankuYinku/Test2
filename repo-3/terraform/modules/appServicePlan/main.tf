resource "azurerm_service_plan" "app_service_plan" {
  name                = var.name
  resource_group_name = data.azurerm_resource_group.meinapetito_resourcegroup.name
  location            = data.azurerm_resource_group.meinapetito_resourcegroup.location
  os_type             = "Linux"
  sku_name            = var.app_service_plan_sku

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}