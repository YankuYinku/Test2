variable "environment" {
  type = string
}

variable "location" {
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

variable "appInsightsRessourceName" {
  description = "Name of the app insights ressource to use"
  type        = string
}

variable "functionAppName" {
  description = "name of the function app"
  type        = string
}

variable "imageName" {
  description = "name of the image to deploy"
  type        = string
}

variable "servicePrincipalClientId_SecretName" {
  description = "The name of the keyvault secret holding the client id of the service principal used to access azure ressources from the function app"
  type        = string
}

variable "servicePrincipalClientSecret_SecretName" {
  description = "The name of the keyvault secret holding the client id of the service principal used to access azure ressources from the function app"
  type        = string
}

variable "servicePrincipalTennantId_SecretName" {
  description = "The name of the keyvault secret holding the client id of the service principal used to access azure ressources from the function app"
  type        = string
}

variable "oldInfrastructureResourceGroupName" {
  type = string
}

variable "oldKeyVaultName" {
  type = string
}

variable "app_service_plan_name" {
  type = string
}