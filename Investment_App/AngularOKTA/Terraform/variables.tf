variable "rgname" {
  default   = "InvestmentApp_ResourceGroup"
}

variable "container_registry_name" {
  default   = "InvestmentAppAzureContainerRegistry"
}

variable "location" {
  default = "eastus"
  description   = "Location of the resource group."
}

locals {
 env_variables = {
   DOCKER_REGISTRY_SERVER_URL            = "investmentappazurecontainerregistry.azurecr.io"
   DOCKER_REGISTRY_SERVER_USERNAME       = "InvestmentAppAzureContainerRegistry"
   DOCKER_REGISTRY_SERVER_PASSWORD       = "4ywhHQoYMQn5vNEj+uqEIijX1fdKvue2"
 }
}
