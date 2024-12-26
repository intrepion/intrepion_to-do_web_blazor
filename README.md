<!-- /README.md -->
# intrepion_to-do_web_blazor
intrepion To Do web app written using .NET Blazor framework

# Blazor Project with Docker

This project is a Blazor application set up for local development using Docker Compose and for deployment to various cloud providers (DigitalOcean, AWS, Azure, and GCP) using Terraform.

## Prerequisites

Before you begin, make sure you have the following installed:

*   **Docker:** [https://docs.docker.com/get-docker/](https://docs.docker.com/get-docker/)
*   **Docker Compose:** [https://docs.docker.com/compose/install/](https://docs.docker.com/compose/install/)
*   **Git:** [https://git-scm.com/book/en/v2/Getting-Started-Installing-Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

## Project Structure

```
blazor-project/
├── docker/                     # Dockerfiles
│   ├── Dockerfile             # Development Dockerfile
│   ├── Dockerfile.init        # Initialization Dockerfile
│   └── Dockerfile.publish     # Production Dockerfile
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

### 3. Running Tests

You can run tests in several ways using Docker:

#### Run All Tests
To run all tests in the solution:

```bash
docker compose run --rm blazor-dev dotnet test
```

#### Run Tests with Watch Mode
To run tests in watch mode, which will automatically re-run tests when files change:

```bash
docker compose run --rm blazor-dev dotnet watch test
```

#### Run Tests for a Specific Project
To run tests for a specific project:

```bash
docker compose run --rm blazor-dev dotnet test path/to/test/project
```

#### Run Tests with Filter
To run specific tests using a filter:

```bash
docker compose run --rm blazor-dev dotnet test --filter "FullyQualifiedName~NamespaceToTest"
```

The test results will be displayed in the console, showing which tests passed or failed along with any error messages or stack traces for failed tests.

### 4. Local Production Build

This simulates a production build locally.

```bash
docker compose up blazor-prod
```

*   The application will be accessible at `http://localhost:5151`.

### 5. Stopping the Development Environment

To stop the Docker containers, press `Ctrl + C` in the terminal where `docker compose up` is running. You can also use:

```bash
docker compose down
```
