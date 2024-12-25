output "public_ip" {
  value = {
    digitalocean = var.cloud_provider == "digitalocean" ? (length(module.digitalocean) > 0 ? module.digitalocean[0].droplet_ip : null) : null
    aws         = var.cloud_provider == "aws" ? (length(module.aws) > 0 ? module.aws[0].instance_public_ip : null) : null
    azure       = var.cloud_provider == "azure" ? (length(module.azure) > 0 ? module.azure[0].public_ip_address : null) : null
    gcp         = var.cloud_provider == "gcp" ? (length(module.gcp) > 0 ? module.gcp[0].external_ip : null) : null
  }
}
