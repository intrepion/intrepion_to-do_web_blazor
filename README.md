# intrepion_to-do_web_blazor
intrepion To Do web app written using .NET Blazor framework

# Blazor Project with Docker and Terraform

This project is a Blazor application set up for local development using Docker Compose and for deployment to various cloud providers (DigitalOcean, AWS, Azure, and GCP) using Terraform.

## Prerequisites

Before you begin, make sure you have the following installed:

*   **Docker:** [https://docs.docker.com/get-docker/](https://docs.docker.com/get-docker/)
*   **Docker Compose:** [https://docs.docker.com/compose/install/](https://docs.docker.com/compose/install/)
*   **Terraform:** [https://www.terraform.io/downloads.html](https://www.terraform.io/downloads.html)
*   **Git:** [https://git-scm.com/book/en/v2/Getting-Started-Installing-Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)
*   **Cloud Provider CLI (Optional but recommended):**
    *   **DigitalOcean:** `doctl` ([https://docs.digitalocean.com/reference/doctl/how-to/install/](https://docs.digitalocean.com/reference/doctl/how-to/install/))
    *   **AWS:** `aws` ([https://docs.aws.amazon.com/cli/latest/userguide/install-cliv2.html](https://docs.aws.amazon.com/cli/latest/userguide/install-cliv2.html))
    *   **Azure:** `az` ([https://docs.microsoft.com/en-us/cli/azure/install-azure-cli](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli))
    *   **GCP:** `gcloud` ([https://cloud.google.com/sdk/docs/install](https://cloud.google.com/sdk/docs/install))

## Project Structure

```
blazor-project/
├── docker/                     # Dockerfiles
│   ├── Dockerfile             # Development Dockerfile
│   ├── Dockerfile.init        # Initialization Dockerfile
│   └── Dockerfile.publish     # Production Dockerfile
├── terraform/                  # Terraform code
│   ├── modules/                # Cloud-specific modules
│   │   ├── digitalocean/
│   │   ├── aws/
│   │   ├── azure/
│   │   └── gcp/
│   ├── main.tf                 # Main Terraform entry point
│   ├── outputs.tf              # Deployment outputs
│   └── variables.tf            # Terraform variables
├── .gitignore
├── docker-compose.yml           # Docker Compose configurations
├── init.sh                    # Project initialization script
├── Intrepion.ToDo.sln        # .NET solution file (generated)
└── Intrepion.ToDo/           # Blazor project files (generated)
    └── ...
```

## Local Development with Docker Compose

### 1. Initialize the Project

This step creates the Blazor project structure and necessary files using the .NET SDK.

```bash
docker compose run --rm blazor-init
```

### 2. Development Environment

This starts the development environment with hot reloading.

```bash
docker compose up blazor-dev
```

*   The application will be accessible at `http://localhost:5151`.
*   Changes to your Blazor project files will automatically trigger a rebuild and refresh in the browser.

### 3. Local Production Build

This simulates a production build locally.

```bash
docker compose up blazor-prod
```

*   The application will be accessible at `http://localhost:5151`.

### 4. Stopping the Development Environment

To stop the Docker containers, press `Ctrl + C` in the terminal where `docker compose up` is running. You can also use:

```bash
docker compose down
```

## Cloud Deployment with Terraform

Terraform is used to provision infrastructure and deploy the application to different cloud providers.

### General Terraform Workflow

1.  **Initialize Terraform:**

    ```bash
    terraform init
    ```

2.  **Create a Terraform variables file:**

    *   Create a `.tfvars` file (e.g., `digitalocean.tfvars`, `aws.tfvars`, `azure.tfvars`, `gcp.tfvars`) in the `terraform` directory.
    *   Populate this file with the necessary variables for your chosen cloud provider. See the "Cloud Provider Configuration" section below for examples.

3.  **Plan the Deployment:**

    ```bash
    terraform plan -var="cloud_provider=<provider>" -var-file="<provider>.tfvars"
    ```

    *   Replace `<provider>` with your chosen provider (digitalocean, aws, azure, or gcp).
    *   Replace `<provider>.tfvars` with the name of your variables file.

4.  **Apply the Deployment:**

    ```bash
    terraform apply -var="cloud_provider=<provider>" -var-file="<provider>.tfvars"
    ```

5.  **Destroy the Infrastructure (when finished):**

    ```bash
    terraform destroy -var="cloud_provider=<provider>" -var-file="<provider>.tfvars"
    ```

### Cloud Provider Configuration

Here are example `.tfvars` file configurations for each cloud provider:

#### DigitalOcean (`digitalocean.tfvars`)

```
cloud_provider = "digitalocean"
do_token       = "YOUR_DIGITALOCEAN_API_TOKEN"  # Keep this sensitive!
droplet_size   = "s-1vcpu-1gb"
region         = "nyc3"
```

*   **Authenticate with DigitalOcean:**
    *   Generate a personal access token in the DigitalOcean control panel.
    *   You can either put the token in the `digitalocean.tfvars` file (less secure) or set it as the environment variable `TF_VAR_do_token` (more secure).
    *   You can also authenticate `doctl` using `doctl auth init`.

#### AWS (`aws.tfvars`)

```
cloud_provider = "aws"
aws_access_key = "YOUR_AWS_ACCESS_KEY_ID"  # Keep this sensitive!
aws_secret_key = "YOUR_AWS_SECRET_ACCESS_KEY"  # Keep this sensitive!
aws_region     = "us-east-1"
aws_instance_type = "t2.micro"
```

*   **Authenticate with AWS:**
    *   You can set your credentials in the `aws.tfvars` file (less secure) or use environment variables (more secure): `TF_VAR_aws_access_key` and `TF_VAR_aws_secret_key`.
    *   Alternatively, configure the AWS CLI with an IAM user that has appropriate permissions: `aws configure`.

#### Azure (`azure.tfvars`)

```
cloud_provider      = "azure"
azure_subscription_id = "YOUR_AZURE_SUBSCRIPTION_ID"  # Keep this sensitive!
azure_client_id       = "YOUR_AZURE_CLIENT_ID"  # Keep this sensitive!
azure_client_secret   = "YOUR_AZURE_CLIENT_SECRET"  # Keep this sensitive!
azure_tenant_id       = "YOUR_AZURE_TENANT_ID"  # Keep this sensitive!
azure_location        = "East US"
azure_vm_size         = "Standard_B1s"
```

*   **Authenticate with Azure:**
    *   You can set your credentials in the `azure.tfvars` file (less secure) or use environment variables (more secure).
    *   Alternatively, use the Azure CLI to log in: `az login`. This will use your logged-in identity for authentication.

#### GCP (`gcp.tfvars`)

```
cloud_provider      = "gcp"
gcp_project_id      = "YOUR_GCP_PROJECT_ID"
gcp_credentials_file = "PATH_TO_YOUR_GCP_CREDENTIALS_FILE.json"  # Keep this sensitive!
gcp_region          = "us-central1"
gcp_zone            = "us-central1-a"
gcp_machine_type    = "e2-medium"
```

*   **Authenticate with GCP:**
    *   **Service Account (Recommended):**
        1.  Create a service account in the GCP console with appropriate permissions (e.g., Compute Admin).
        2.  Download the JSON key file for the service account.
        3.  Set the `gcp_credentials_file` variable to the path of the key file, or set the environment variable `GOOGLE_APPLICATION_CREDENTIALS` to the path of the key file.
    *   **Application Default Credentials (ADC):**
        1.  Run `gcloud auth application-default login`. This will use your logged-in user credentials.

### Deployment Steps (Example with GCP)

1.  **Build the Production Docker Image:**

    ```bash
    docker compose build blazor-prod
    ```

2.  **Push the Image to a Container Registry (Optional but Recommended):**
    *   Tag the image:

        ```bash
        docker tag blazor-prod:latest YOUR_REGISTRY/YOUR_IMAGE_NAME:latest
        ```

        *   Replace `YOUR_REGISTRY` with your registry (e.g., `gcr.io/your-project-id`, `docker.io/your-username`).
        *   Replace `YOUR_IMAGE_NAME` with your desired image name.
    *   Push the image:

        ```bash
        docker push YOUR_REGISTRY/YOUR_IMAGE_NAME:latest
        ```

3.  **Configure Terraform (gcp.tfvars):**
    ```
    cloud_provider      = "gcp"
    gcp_project_id      = "your-gcp-project"
    gcp_credentials_file = "/path/to/your/credentials.json"
    gcp_region          = "us-central1"
    gcp_zone            = "us-central1-a"
    gcp_machine_type    = "e2-medium"
    ```
    
4.  **Update the `terraform/modules/gcp/main.tf` file to either pull the image from your container registry or build it from the Dockerfile.**

    *   **Option 1: Pulling from a Container Registry**
        *   Replace the `metadata_startup_script` inside the `google_compute_instance` resource in `terraform/modules/gcp/main.tf` with the following:

        ```terraform
            metadata_startup_script = <<-EOF
                #!/bin/bash
                sudo apt-get update
                sudo apt-get install -y apt-transport-https ca-certificates curl software-properties-common
                curl -fsSL [https://download.docker.com/linux/ubuntu/gpg](https://download.docker.com/linux/ubuntu/gpg) | sudo apt-key add -
                sudo add-apt-repository "deb [arch=amd64] [https://download.docker.com/linux/ubuntu](https://download.docker.com/linux/ubuntu) focal stable"
                sudo apt-get update
                sudo apt-get install -y docker-ce
                sudo docker pull YOUR_REGISTRY/YOUR_IMAGE_NAME:latest
                sudo docker run -d -p 80:80 YOUR_REGISTRY/YOUR_IMAGE_NAME:latest
            EOF
        ```
     *   **Option 2: Building from Dockerfile**
         *   Copy your application's Dockerfile to the `terraform/modules/gcp` folder.
         *   Modify the `metadata_startup_script` to build and run the Docker image from the Dockerfile. You will need to copy the Dockerfile and any necessary application code to the VM using startup scripts or other methods.

5.  **Initialize, plan and apply Terraform configuration:**
    ```bash
    terraform init
    terraform plan -var="cloud_provider=gcp" -var-file="gcp.tfvars"
    terraform apply -var="cloud_provider=gcp" -var-file="gcp.tfvars"
    ```

## Important Security Notes

*   **Never commit sensitive information (API keys, credentials, etc.) directly to your Git repository.** Use environment variables or a dedicated secrets management tool.
*   **Restrict access to your cloud resources.** Use the principle of least privilege when creating IAM users or service accounts.
*   **Regularly update your dependencies and patch your systems.**
*   **Consider using a firewall to restrict inbound traffic to your instances.** (The provided Terraform configurations already include basic firewall rules).
