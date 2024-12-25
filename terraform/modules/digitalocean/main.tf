resource "digitalocean_droplet" "web" {
  image  = "docker-20-04" # Or a specific snapshot with your app pre-installed
  name   = "blazor-app"
  region = var.region
  size   = var.droplet_size
  ssh_keys = [
    data.digitalocean_ssh_key.terraform.id
  ]
}

# Optional: Use cloud-init to run scripts on first boot
resource "digitalocean_droplet" "web_cloud_init" {
  image  = "docker-20-04"
  name   = "blazor-app-cloud-init"
  region = var.region
  size   = var.droplet_size
  user_data = file("./cloud-init.yaml") # Define initial setup script
  ssh_keys = [
    data.digitalocean_ssh_key.terraform.id
  ]
}

# Fetch an existing SSH Key
data "digitalocean_ssh_key" "terraform" {
  name = "Terraform Key"
}

# Optional: Create a new SSH key
resource "digitalocean_ssh_key" "generated_key" {
  name       = "Generated Key"
  public_key = file("~/.ssh/id_rsa.pub") # Path to your public key
}
