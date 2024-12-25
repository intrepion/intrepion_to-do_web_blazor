# init.sh
#!/bin/bash

# Install bUnit template
# This is required before we can create bUnit test projects
dotnet new install bunit.template::2.0.33-preview

# Create initial files
# The gitignore helps prevent committing unnecessary files
# The globaljson ensures consistent .NET SDK version across development environments
dotnet new gitignore
dotnet new globaljson

# Create main Blazor project
# This creates an Individual authentication enabled Blazor project with Auto interactivity
dotnet new blazor --auth Individual --interactivity Auto --name Intrepion.ToDo --output . --use-local-db

# Create test and supporting projects
# We create various test projects using different testing frameworks
# and library projects to maintain a clean separation of concerns
dotnet new nunit --name Intrepion.ToDo.AcceptanceTests
dotnet new classlib --name Intrepion.ToDo.BusinessLogic
dotnet new nunit --name Intrepion.ToDo.BusinessLogic.UnitTests
dotnet new console --name Intrepion.ToDo.ConsoleProject
dotnet new bunit --framework nunit --name Intrepion.ToDo.Client.ComponentTests
dotnet new bunit --framework nunit --name Intrepion.ToDo.Server.ComponentTests
dotnet new nunit --name Intrepion.ToDo.Server.ControllerTests
dotnet new razorclasslib --name Intrepion.ToDo.Shared
dotnet new bunit --framework nunit --name Intrepion.ToDo.Shared.ComponentTests

# Add projects to solution
# This ensures all projects are part of the main solution file
dotnet sln add Intrepion.ToDo.AcceptanceTests
dotnet sln add Intrepion.ToDo.BusinessLogic
dotnet sln add Intrepion.ToDo.BusinessLogic.UnitTests
dotnet sln add Intrepion.ToDo.Client.ComponentTests
dotnet sln add Intrepion.ToDo.ConsoleProject
dotnet sln add Intrepion.ToDo.Server.ComponentTests
dotnet sln add Intrepion.ToDo.Server.ControllerTests
dotnet sln add Intrepion.ToDo.Shared
dotnet sln add Intrepion.ToDo.Shared.ComponentTests

# Add project references
# These references establish the dependencies between projects
dotnet add Intrepion.ToDo reference Intrepion.ToDo.BusinessLogic
dotnet add Intrepion.ToDo reference Intrepion.ToDo.Shared
dotnet add Intrepion.ToDo.BusinessLogic.UnitTests reference Intrepion.ToDo.BusinessLogic
dotnet add Intrepion.ToDo.Client reference Intrepion.ToDo.BusinessLogic
dotnet add Intrepion.ToDo.Client reference Intrepion.ToDo.Shared
dotnet add Intrepion.ToDo.Client.ComponentTests reference Intrepion.ToDo.Client
dotnet add Intrepion.ToDo.ConsoleProject reference Intrepion.ToDo.BusinessLogic
dotnet add Intrepion.ToDo.Server.ComponentTests reference Intrepion.ToDo
dotnet add Intrepion.ToDo.Server.ControllerTests reference Intrepion.ToDo
dotnet add Intrepion.ToDo.Shared.ComponentTests reference Intrepion.ToDo.Shared
