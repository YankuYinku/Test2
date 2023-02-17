resource "azurerm_firewall_application_rule_collection" "meinapetito_applicationrules" {
  name                = "${var.environment}-${var.application_name}"
  azure_firewall_name = data.azurerm_firewall.infrastructurefirewall.name
  resource_group_name = data.azurerm_resource_group.infrastructureresourcegroup.name
  priority            = 100
  action              = "Allow"

  rule {
    name = "aks"

    source_addresses = [
      var.meinapetitoVnetAddressSpace
    ]

    fqdn_tags = [
      "AzureKubernetesService"
    ]
  }
}

resource "azurerm_firewall_network_rule_collection" "meinapetito_networkrules" {
  name                = "${var.environment}-${var.application_name}"
  azure_firewall_name = data.azurerm_firewall.infrastructurefirewall.name
  resource_group_name = data.azurerm_resource_group.infrastructureresourcegroup.name
  priority            = 400
  action              = "Allow"

  rule {
    name = "MSSQL"

    protocols = [
      "TCP"
    ]

    source_addresses = [
      var.meinapetitoVnetAddressSpace,
    ]

    destination_addresses = [
      "Sql"
    ]

    destination_ports = [
      "*",
    ]
  }

  lifecycle {
    ignore_changes = [rule["AMQP"]]
  }
}
