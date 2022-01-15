terraform{
    required_version = ">=0.12"

    required_providers {
      azurerm = {
          source = "hashicorp/azurerm"
      version = "~>2.0"
      }
    }
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg-name" {
    name = var.rgname
    location = var.location
}

resource "azurerm_container_registry" "azacr" {
    name = var.container_registry_name
    resource_group_name = var.rgname
    location = var.location
    sku = "Standard"
    admin_enabled = true
}