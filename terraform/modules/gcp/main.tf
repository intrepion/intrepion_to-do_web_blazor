resource "google_compute_network" "vpc_network" {
  project                 = var.gcp_project_id
  name                    = "blazor-app-network"
  auto_create_subnetworks = false # For finer control over subnets
  mtu                     = 1460
}

resource "google_compute_subnetwork" "subnet" {
  project       = var.gcp_project_id
  name          = "blazor-app-subnet"
  ip_cidr_range = "10.0.1.0/24"
  region        = var.gcp_region
  network       = google_compute_network.vpc_network.id
}

resource "google_compute_firewall" "allow_ssh" {
  project     = var.gcp_project_id
  name        = "blazor-app-allow-ssh"
  network     = google_compute_network.vpc_network.id
  description = "Allow SSH traffic to the VM"

  allow {
    protocol = "tcp"
    ports    = ["22"]
  }

  source_ranges = ["0.0.0.0/0"] # Restrict for security
  target_tags   = ["blazor-app"]
}

resource "google_compute_firewall" "allow_http_https" {
  project     = var.gcp_project_id
  name        = "blazor-app-allow-http-https"
  network     = google_compute_network.vpc_network.id
  description = "Allow HTTP and HTTPS traffic to the VM"

  allow {
    protocol = "tcp"
    ports    = ["80", "443"]
  }

  source_ranges = ["0.0.0.0/0"]
  target_tags   = ["blazor-app"]
}

# Optional: Cloud NAT for internet access from the VM
resource "google_compute_router" "router" {
  project = var.gcp_project_id
  name    = "blazor-app-router"
  region  = var.gcp_region
  network = google_compute_network.vpc_network.id
}

resource "google_compute_router_nat" "nat" {
  project = var.gcp_project_id
  name    = "blazor-app-nat"
  router  = google_compute_router.router.name
  region  = var.gcp_region

  source_subnetwork_ip_ranges_to_nat = "ALL_SUBNETWORKS_ALL_IP_RANGES"
  nat_ip_allocate_option             = "AUTO_ONLY"
}

resource "google_compute_address" "static_ip" {
  project = var.gcp_project_id
  name    = "blazor-app-static-ip"
  region  = var.gcp_region
}

resource "google_compute_instance" "default" {
  project      = var.gcp_project_id
  name         = "blazor-app-vm"
  machine_type = var.gcp_machine_type
  zone         = var.gcp_zone

  boot_disk {
    initialize_params {
      image = "projects/ubuntu-os-cloud/global/images/family/ubuntu-2004-lts"
    }
  }

  # Assign static IP (Optional)
  network_interface {
    subnetwork = google_compute_subnetwork.subnet.id
    # Comment out the line below if using Cloud NAT
    # network_ip = google_compute_address.static_ip.address 
    access_config {
        network_tier = "PREMIUM"
    }
  }

  # Add SSH key for access
  metadata = {
    ssh-keys = "ubuntu:${file("~/.ssh/id_rsa.pub")}" # Update username and path
  }

  # Apply firewall rules
  tags = ["blazor-app"]

  # Install Docker using startup script (Optional)
  metadata_startup_script = <<-EOF
    #!/bin/bash
    sudo apt-get update
    sudo apt-get install -y apt-transport-https ca-certificates curl software-properties-common
    curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -
    sudo add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/ubuntu focal stable"
    sudo apt-get update
    sudo apt-get install -y docker-ce
    # ... further Docker setup and deployment commands
  EOF
}
