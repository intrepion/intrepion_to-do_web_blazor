<!-- /README.md -->

# intrepion_to-do_web_blazor

A To Do web application written using the .NET Blazor framework. This project provides a complete development environment using Docker Compose and includes configurations for deployment to various cloud providers.

## Prerequisites

Before starting, ensure you have the following tools installed on your system:

- **Docker**: [Installation Guide](https://docs.docker.com/get-docker/)
- **Docker Compose**: [Installation Guide](https://docs.docker.com/compose/install/)
- **Git**: [Installation Guide](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

## Project Structure

The project is organized with the following structure:

```
blazor-project/
├── docker/                     # Docker configuration files
│   ├── Dockerfile             # Development environment
│   ├── Dockerfile.init        # Project initialization
│   └── Dockerfile.publish     # Production build
├── .gitignore
├── docker-compose.yml         # Docker Compose configuration
├── init.sh                    # Initialization script
├── Intrepion.ToDo.sln        # .NET solution file (generated)
└── Intrepion.ToDo/           # Main Blazor project (generated)
    └── ...
```

## Local Development

### 1. Initialize the Project

Start by creating the Blazor project structure:

```bash
docker compose run --rm blazor-init
```

### 2. Development Environment

Launch the development environment with hot reloading:

```bash
docker compose up blazor-dev
```

Your application will be available at `http://localhost:5151`. The development environment includes hot reloading, so any changes you make to your Blazor project files will automatically trigger a rebuild and refresh your browser.

### 3. Running Tests

The project includes several options for running tests using Docker:

#### Run All Tests
Execute all tests in the solution:

```bash
docker compose run --rm blazor-test
```

#### Watch Mode
Run tests continuously, automatically re-running when files change:

```bash
docker compose run --rm blazor-test watch test
```

#### Test Specific Project
Target tests in a particular project:

```bash
docker compose run --rm blazor-test test Intrepion.ToDo.Tests/Intrepion.ToDo.Tests.csproj
```

#### Filtered Tests
Run specific tests using a filter:

```bash
docker compose run --rm blazor-test test --filter "Category=Unit"
```

Test results will display in your terminal, showing passed and failed tests along with any error messages or stack traces for failures.

### 4. Production Build

Test your application in a production-like environment:

```bash
docker compose up blazor-prod
```

The production build will be available at `http://localhost:5151`.

### 5. Stopping the Environment

To stop running containers, use either:

- Press `Ctrl + C` in the terminal where Docker Compose is running
- Or run the following command:

```bash
docker compose down
```

## Development Workflow Tips

1. Start with the initialization step only once, when first setting up the project.
2. Use the development environment (`blazor-dev`) for your daily development work.
3. Run tests frequently to ensure code quality.
4. Test the production build before deploying to ensure everything works as expected.

## Troubleshooting

If you encounter issues:

1. Ensure all prerequisites are properly installed
2. Check that Docker services are running
3. Verify that ports 5151 is not in use by other applications
4. Try removing all containers and volumes with `docker compose down -v` and start fresh

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m 'Add YourFeature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.
