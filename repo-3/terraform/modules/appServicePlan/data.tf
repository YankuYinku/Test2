data "azurerm_resource_group" "meinapetito_resourcegroup"{
  name = format("%s_%s", var.environment, var.application_name)
}