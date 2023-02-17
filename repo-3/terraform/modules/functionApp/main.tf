resource "random_string" "contentshare_random_suffix" {
  length  = 4
  special = false
  upper   = false
}

locals {
  aspnetcore_environment = var.environment == "dev" ? "Development" : var.environment == "stage" ? "Staging" : "Production"
}

resource "azurerm_linux_function_app" "function_app" {
  lifecycle {
    ignore_changes = [
      app_settings,
      site_config,
      tags
    ]
  }

  name                       = var.functionAppName
  resource_group_name        = data.azurerm_resource_group.meinapetito_resourcegroup.name
  location                   = var.location
  storage_account_name       = data.azurerm_storage_account.meinapetito_storage_account.name
  storage_account_access_key = data.azurerm_storage_account.meinapetito_storage_account.primary_access_key

  service_plan_id = data.azurerm_service_plan.app_service_plan.id

  identity {
    type = "SystemAssigned"
  }

  site_config {
    container_registry_use_managed_identity = true

    application_stack {
      docker {
        registry_url = "apetitoebusinesssolutions.azurecr.io"
        image_name   = var.imageName
        image_tag    = "latest"
      }
    }

    app_service_logs {
      disk_quota_mb         = 35
      retention_period_days = 0
    }
  }


  app_settings = {
    ASPNETCORE_ENVIRONMENT                   = local.aspnetcore_environment
    WEBSITE_ENABLE_SYNC_UPDATE_SITE          = true
    WEBSITES_ENABLE_APP_SERVICE_STORAGE      = false
    APPINSIGHTS_INSTRUMENTATIONKEY           = data.azurerm_application_insights.application_insights.instrumentation_key,
    AZURE_TENANT_ID                          = data.azurerm_key_vault_secret.service_principal_tennant_ids.value,
    AZURE_CLIENT_ID                          = data.azurerm_key_vault_secret.service_principal_client_ids.value,
    AZURE_CLIENT_SECRET                      = data.azurerm_key_vault_secret.service_principal_client_secrets.value,
    WEBSITE_CONTENTAZUREFILECONNECTIONSTRING = data.azurerm_storage_account.meinapetito_storage_account.primary_connection_string
    WEBSITE_CONTENTSHARE                     = "${var.functionAppName}-${random_string.contentshare_random_suffix.result}"
  }

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}

resource "azurerm_role_assignment" "acrpull_role" {
  scope                            = data.azurerm_container_registry.apetitoebusinesssolutions.id
  role_definition_name             = "AcrPull"
  principal_id                     = azurerm_linux_function_app.function_app.identity.0.principal_id
  skip_service_principal_aad_check = true
}

output "function_app_id" {
  value = azurerm_linux_function_app.function_app.id
}