variable "environment" {
  type = string
}

variable "application_name" {
  type = string
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

variable "oldInfrastructureResourceGroupName" {
  type = string
}

variable "oldKeyVaultName" {
  type = string
}

variable "adminAdGroup" {
  type = string
}

variable "portal_db_sku" {
  type = string
}

variable "database_subnet_address_prefix" {
  type = string
}
