variable "environment" {
  description = "tag name for the environment"
  type = string
}

variable "version_number" {
  type = string
  description = "The feature number / build number / version number that is used as an index to distinguish between mutliple clusters in the same environment."
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
  description = "location where the sql server will be hosted"
  type = string
}

variable "oldInfrastructureResourceGroupName" {
  description = "Name of the infrastructure ressource group"
  type = string
}

variable "oldKeyVaultName" {
  description = "name of the keyvault"
  type = string
}






