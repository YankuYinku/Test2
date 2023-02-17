variable "environment" {
  type = string
}

variable "application_name" {
  type    = string
  default = "meinapetito"
}

variable "company_name" {
  type    = string
  default = "apetito AG"
}

variable "department_name" {
  type    = string
  default = "eBusiness Solutions"
}

variable "location" {
  type    = string
  default = "West Europe"
}

variable "meinapetitoVnetAddressSpace" {
  type = string
}

variable "oldInfrastructureResourceGroupName" {
  type = string
}

variable "oldKeyVaultName" {
  type = string
}

variable "portal_db_sku" {
  type = string
}

variable "database_subnet_address_prefix" {
  type = string
}

variable "app_services_inbound_subnet" {
  type = string
}

variable "recipie_change_webhook_function_app_outbound_subnet_prefix" {
  type = string
}

variable "meinapetito_orders_function_app_outbound_subnet_prefix" {
  type = string
}

variable "app_service_plan_sku" {
  type = string
}