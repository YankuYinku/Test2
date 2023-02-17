resource "azurerm_virtual_network" "meinapetito_vnet" {
  location            = var.location
  name                = format("%s_%s", var.environment, var.application_name)
  resource_group_name = azurerm_resource_group.resource_group.name
  address_space       = [var.meinapetitoVnetAddressSpace]

  tags = local.common_tags
}

resource "azurerm_virtual_network_peering" "peer_meinapetito_to_hub" {
  name                      = "peer_meinapetito_to_hub"
  resource_group_name       = azurerm_resource_group.resource_group.name
  virtual_network_name      = azurerm_virtual_network.meinapetito_vnet.name
  remote_virtual_network_id = data.azurerm_virtual_network.hubvnet.id
}

resource "azurerm_virtual_network_peering" "peer_hub_to_meinapetito" {
  name                      = "peer_hub_to_meinapetito"
  resource_group_name       = data.azurerm_resource_group.infrastructureresourcegroup.name
  virtual_network_name      = data.azurerm_virtual_network.hubvnet.name
  remote_virtual_network_id = azurerm_virtual_network.meinapetito_vnet.id
}

resource "azurerm_subnet" "inbound_subnet" {
  address_prefixes     = [var.app_services_inbound_subnet]
  name                 = "${var.environment}_${var.application_name}_inbound"
  resource_group_name  = azurerm_resource_group.resource_group.name
  virtual_network_name = azurerm_virtual_network.meinapetito_vnet.name
}

resource "azurerm_network_security_group" "inbound_subnet" {
  name                = format("%s_%s_inbound_subnet", var.environment, var.application_name)
  location            = azurerm_resource_group.resource_group.location
  resource_group_name = azurerm_resource_group.resource_group.name

  security_rule {
    name                       = "GatewayManager"
    priority                   = 1001
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "GatewayManager"
    destination_address_prefix = "*"
  }

  security_rule {
    name                       = "InboundVirtualNetwork"
    priority                   = 1002
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefixes    = azurerm_virtual_network.meinapetito_vnet.address_space
    destination_address_prefix = "*"
  }

  security_rule {
    name                       = "OutboundVirtualNetwork"
    priority                   = 1001
    direction                  = "Outbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_ranges    = ["22", "3389"]
    source_address_prefix      = "*"
    destination_address_prefix = "VirtualNetwork"
  }

  security_rule {
    name                       = "OutboundToAzureCloud"
    priority                   = 1002
    direction                  = "Outbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "*"
    destination_address_prefix = "AzureCloud"
  }
}

resource "azurerm_subnet_network_security_group_association" "inbound_subnet" {
  network_security_group_id = azurerm_network_security_group.inbound_subnet.id
  subnet_id                 = azurerm_subnet.inbound_subnet.id
}

resource "azurerm_network_security_group" "meinapetitonetworksubnet_sec_group" {
  name                = format("%s_%s_clusters", var.environment, var.application_name)
  location            = azurerm_resource_group.resource_group.location
  resource_group_name = azurerm_resource_group.resource_group.name

  security_rule {
    name                       = "GatewayManager"
    priority                   = 1001
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "GatewayManager"
    destination_address_prefix = "*"
  }

  security_rule {
    name                       = "Internet-PublicIP"
    priority                   = 1002
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }

  security_rule {
    name                       = "OutboundVirtualNetwork"
    priority                   = 1001
    direction                  = "Outbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_ranges    = ["22", "3389"]
    source_address_prefix      = "*"
    destination_address_prefix = "VirtualNetwork"
  }

  security_rule {
    name                       = "OutboundToAzureCloud"
    priority                   = 1002
    direction                  = "Outbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "*"
    destination_address_prefix = "AzureCloud"
  }
}