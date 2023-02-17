resource "azurerm_mssql_server" "meinapetitosqlserver" {
  name                          = format("%s-%s", var.environment, var.application_name)
  resource_group_name           = data.azurerm_resource_group.resourcegroup.name
  location                      = data.azurerm_resource_group.resourcegroup.location
  administrator_login           = data.azurerm_key_vault_secret.sqlAdminUserName.value
  administrator_login_password  = data.azurerm_key_vault_secret.sqlAdminPassword.value
  version                       = "12.0"
  public_network_access_enabled = false

  azuread_administrator {
    login_username = "sqladmin"
    tenant_id      = data.azurerm_client_config.current.tenant_id
    object_id      = data.azuread_group.adg.object_id
  }

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}


resource "azurerm_storage_container" "meinapetitosqlserver" {
  name                  = format("%s%s%s", var.environment, var.application_name, "sqlserver")
  storage_account_name  = data.azurerm_storage_account.meinapetito_storage_account.name
  container_access_type = "private"
}

resource "azurerm_mssql_server_security_alert_policy" "meinapetitosqlserver" {
  resource_group_name = data.azurerm_resource_group.resourcegroup.name
  server_name         = azurerm_mssql_server.meinapetitosqlserver.name
  state               = "Enabled"
}

resource "azurerm_mssql_server_vulnerability_assessment" "meinapetitosqlserver" {
  server_security_alert_policy_id = azurerm_mssql_server_security_alert_policy.meinapetitosqlserver.id
  storage_container_path          = "${data.azurerm_storage_account.meinapetito_storage_account.primary_blob_endpoint}${azurerm_storage_container.meinapetitosqlserver.name}/"
  storage_account_access_key      = data.azurerm_storage_account.meinapetito_storage_account.primary_access_key

  recurring_scans {
    enabled                   = true
    email_subscription_admins = true
    emails                    = [
      "robin.bitterlich@apetito.de",
      "marius.tebbe@apetito.de",
      "tobias.richling@apetito.de"
    ]
  }
}

resource "azurerm_mssql_database" "meinapetito_portaldb" {
  name         = "PortalDb"
  server_id    = azurerm_mssql_server.meinapetitosqlserver.id
  collation    = "SQL_Latin1_General_CP1_CI_AS"
  license_type = "LicenseIncluded"
  max_size_gb  = 2
  sku_name     = var.portal_db_sku

  lifecycle {
    ignore_changes = [
      license_type
    ]
  }

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}

resource "azurerm_mssql_database_extended_auditing_policy" "meinapetitosqlserver" {
  database_id                             = azurerm_mssql_database.meinapetito_portaldb.id
  storage_endpoint                        = data.azurerm_storage_account.meinapetito_storage_account.primary_blob_endpoint
  storage_account_access_key              = data.azurerm_storage_account.meinapetito_storage_account.primary_access_key
  storage_account_access_key_is_secondary = false
  retention_in_days                       = 6
}


resource "azurerm_mssql_database" "meinapetito_authorizationdb" {
  name         = "AuthorizationDb"
  server_id    = azurerm_mssql_server.meinapetitosqlserver.id
  collation    = "SQL_Latin1_General_CP1_CI_AS"
  license_type = "LicenseIncluded"
  max_size_gb  = 2
  sku_name     = "Basic"

  lifecycle {
    ignore_changes = [
      license_type
    ]
  }

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}

resource "azurerm_mssql_database" "meinapetito_notification" {
  name         = "NotificationDb"
  server_id    = azurerm_mssql_server.meinapetitosqlserver.id
  collation    = "SQL_Latin1_General_CP1_CI_AS"
  license_type = "LicenseIncluded"
  max_size_gb  = 2
  sku_name     = "Basic"

  lifecycle {
    ignore_changes = [
      license_type
    ]
  }

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}

resource "azurerm_mssql_database" "meinapetito_distributedcache" {
  name         = "DistributedCache"
  server_id    = azurerm_mssql_server.meinapetitosqlserver.id
  collation    = "SQL_Latin1_General_CP1_CI_AS"
  license_type = "LicenseIncluded"
  max_size_gb  = 2
  sku_name     = "Basic"

  lifecycle {
    ignore_changes = [
      license_type
    ]
  }

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}

resource "azurerm_mssql_database" "meinapetito_nservicebus" {
  name         = "NServiceBus"
  server_id    = azurerm_mssql_server.meinapetitosqlserver.id
  collation    = "SQL_Latin1_General_CP1_CI_AS"
  license_type = "LicenseIncluded"
  max_size_gb  = 2
  sku_name     = "Basic"

  lifecycle {
    ignore_changes = [
      license_type
    ]
  }

  tags = {
    environment = var.environment
    application = var.application_name
    company     = var.company_name
    department  = var.department_name
  }
}