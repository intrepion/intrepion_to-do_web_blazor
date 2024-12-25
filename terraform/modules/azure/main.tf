resource "azurerm_resource_group" "web" {
  name     = "blazor-app-rg"
  location = var.azure_location
}

resource "azurerm_public_ip" "web" {
  name                = "blazor-app-public-ip"
  location            = azurerm_resource_group.web.location
  resource_group_name = azurerm_resource_group.web.name
  allocation_method   = "Dynamic"
}

resource "azurerm_network_interface" "web" {
  name                = "blazor-app-nic"
  location            = azurerm_resource_group.web.location
  resource_group_name = azurerm_resource_group.web.name

  ip_configuration {
    name                          = "internal"
    subnet_id                     = azurerm_subnet.web.id
    private_ip_address_allocation = "Dynamic"
    public_ip_address_id          = azurerm_public_ip.web.id
  }
}

resource "azurerm_network_security_group" "web" {
  name                = "blazor-app-nsg"
  location            = azurerm_resource_group.web.location
  resource_group_name = azurerm_resource_group.web.name

  security_rule {
    name                       = "SSH"
    priority                   = 1001
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "22"
    source_address_prefix      = "*" # Consider restricting for security
    destination_address_prefix = "*"
  }

  security_rule {
    name                       = "HTTP"
    priority                   = 1002
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "80"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }

  security_rule {
    name                       = "HTTPS"
    priority                   = 1003
    direction                  = "Inbound"
    access                     = "Allow"
    protocol                   = "Tcp"
    source_port_range          = "*"
    destination_port_range     = "443"
    source_address_prefix      = "*"
    destination_address_prefix = "*"
  }
}

resource "azurerm_virtual_network" "web" {
  name                = "blazor-app-vnet"
  address_space       = ["10.0.0.0/16"]
  location            = azurerm_resource_group.web.location
  resource_group_name = azurerm_resource_group.web.name
}

resource "azurerm_subnet" "web" {
  name                 = "blazor-app-subnet"
  resource_group_name  = azurerm_resource_group.web.name
  virtual_network_name = azurerm_virtual_network.web.name
  address_prefixes     = ["10.0.1.0/24"]
}

resource "azurerm_network_interface_security_group_association" "web" {
  network_interface_id      = azurerm_network_interface.web.id
  network_security_group_id = azurerm_network_security_group.web.id
}

# Availability Set (Optional - for higher availability)
resource "azurerm_availability_set" "web" {
  name                = "blazor-app-avset"
  location            = azurerm_resource_group.web.location
  resource_group_name = azurerm_resource_group.web.name
  platform_fault_domain_count  = 2  # Adjust based on needs
  platform_update_domain_count = 5  # Adjust based on needs
  managed = true # Use managed disks
}

# Virtual Machine
resource "azurerm_linux_virtual_machine" "web" {
  name                  = "blazor-app-vm"
  location              = azurerm_resource_group.web.location
  resource_group_name   = azurerm_resource_group.web.name
  network_interface_ids = [azurerm_network_interface.web.id]
  size                  = var.azure_vm_size
  admin_username        = "azureuser" # Change to your desired username
  availability_set_id   = azurerm_availability_set.web.id # Include for higher availability

  admin_ssh_key {
    username   = "azureuser" # Match with admin_username
    public_key = file("~/.ssh/id_rsa.pub") # Path to your public SSH key
  }

  os_disk {
    caching              = "ReadWrite"
    storage_account_type = "Standard_LRS"
  }

  source_image_reference {
    publisher = "Canonical"
    offer     = "0001-com-ubuntu-server-focal"
    sku       = "20_04-lts-gen2"
    version   = "latest"
  }

  # User Data for Initial Setup (Optional)
  user_data = base64encode(<<-EOF
    #!/bin/bash
    sudo apt-get update
    sudo apt-get install -y docker.io
    # ... other Docker setup commands ...
  EOF
  )
}
