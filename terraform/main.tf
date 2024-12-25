terraform {
  required_providers {
    digitalocean = {
      source  = "digitalocean/digitalocean"
      version = "~> 2.0"
    }
    aws = {
      source  = "hashicorp/aws"
      version = "~> 4.0"
    }
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.0"
    }
    google = {
      source  = "hashicorp/google"
      version = "~> 4.0"
    }
  }
}

# Configure Providers (using locals for conditional logic)
locals {
  providers = {
    digitalocean = var.cloud_provider == "digitalocean" ? {
      token = var.do_token
    } : null
    aws = var.cloud_provider == "aws" ? {
      access_key = var.aws_access_key
      secret_key = var.aws_secret_key
      region     = var.aws_region
    } : null
    azurerm = var.cloud_provider == "azure" ? {
      subscription_id = var.azure_subscription_id
      client_id       = var.azure_client_id
      client_secret   = var.azure_client_secret
      tenant_id       = var.azure_tenant_id
    } : null
    google = var.cloud_provider == "gcp" ? {
      credentials = var.gcp_credentials_file
      project     = var.gcp_project_id
      region      = var.gcp_region
      zone        = var.gcp_zone
    } : null
  }
}

# Configure DigitalOcean Provider if selected
provider "digitalocean" {
  token = local.providers.digitalocean.token
}

# Configure AWS Provider if selected
provider "aws" {
  access_key = local.providers.aws.access_key
  secret_key = local.providers.aws.secret_key
  region     = local.providers.aws.region
}

# Configure Azure Provider if selected
provider "azurerm" {
  features {}
  subscription_id = local.providers.azurerm.subscription_id
  client_id       = local.providers.azurerm.client_id
  client_secret   = local.providers.azurerm.client_secret
  tenant_id       = local.providers.azurerm.tenant_id
}

# Configure GCP Provider if selected
provider "google" {
  credentials = local.providers.google.credentials
  project     = local.providers.google.project
  region      = local.providers.google.region
  zone        = local.providers.google.zone
}

# Module Calls (using count for conditional execution)
module "digitalocean" {
  count = var.cloud_provider == "digitalocean" ? 1 : 0
  source = "./modules/digitalocean"

  droplet_size = var.droplet_size
  region       = var.region
}

module "aws" {
  count = var.cloud_provider == "aws" ? 1 : 0
  source = "./modules/aws"

  aws_region = var.aws_region
  aws_instance_type = var.aws_instance_type
}

module "azure" {
  count = var.cloud_provider == "azure" ? 1 : 0
  source = "./modules/azure"

  azure_location = var.azure_location
  azure_vm_size  = var.azure_vm_size
}

module "gcp" {
  count = var.cloud_provider == "gcp" ? 1 : 0
  source = "./modules/gcp"

  gcp_project_id   = var.gcp_project_id     # Pass the project ID to the module
  gcp_region       = var.gcp_region         # Pass the region to the module
  gcp_zone         = var.gcp_zone           # Pass the zone to the module
  gcp_machine_type = var.gcp_machine_type
}
