variable "cloud_provider" {
  description = "The cloud provider to use (digitalocean, aws, azure, or gcp)"
  type        = string
  default     = "digitalocean" # Set your preferred default
}

# DigitalOcean Variables
variable "do_token" {
  description = "DigitalOcean API token"
  type        = string
  sensitive   = true # Mark as sensitive for security
  default     = ""
}

variable "droplet_size" {
  description = "DigitalOcean droplet size"
  type        = string
  default     = "s-1vcpu-1gb"
}

variable "region" {
  description = "Region to deploy to"
  type        = string
  default     = "nyc3"
}

# AWS Variables
variable "aws_access_key" {
  description = "AWS Access Key ID"
  type        = string
  sensitive   = true
  default     = ""
}

variable "aws_secret_key" {
  description = "AWS Secret Access Key"
  type        = string
  sensitive   = true
  default     = ""
}

variable "aws_region" {
  description = "AWS Region"
  type        = string
  default     = "us-east-1"
}

variable "aws_instance_type" {
  description = "AWS EC2 instance type"
  type        = string
  default     = "t2.micro"
}

# Azure Variables
variable "azure_subscription_id" {
  description = "Azure Subscription ID"
  type        = string
  sensitive   = true
  default     = ""
}

variable "azure_client_id" {
  description = "Azure Client ID"
  type        = string
  sensitive   = true
  default     = ""
}

variable "azure_client_secret" {
  description = "Azure Client Secret"
  type        = string
  sensitive   = true
  default     = ""
}

variable "azure_tenant_id" {
  description = "Azure Tenant ID"
  type        = string
  sensitive   = true
  default     = ""
}

variable "azure_location" {
  description = "Azure Location"
  type        = string
  default     = "East US"
}

variable "azure_vm_size" {
  description = "Azure VM size"
  type        = string
  default     = "Standard_B1s"
}

# GCP Variables
variable "gcp_project_id" {
  description = "GCP Project ID"
  type        = string
  #  sensitive   = true # Project ID might not be sensitive, but mark it if needed
  default     = ""
}

variable "gcp_credentials_file" {
  description = "Path to GCP credentials JSON file"
  type        = string
  sensitive   = true
  default     = ""
}

variable "gcp_region" {
  description = "GCP region"
  type        = string
  default     = "us-central1"
}

variable "gcp_zone" {
  description = "GCP zone"
  type        = string
  default     = "us-central1-a"
}

variable "gcp_machine_type" {
  description = "GCP machine type"
  type        = string
  default     = "e2-medium"
}
