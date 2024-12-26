#!/bin/bash

# /init.sh
# This script initializes the complete project structure

app_name="Intrepion.ToDo"
human_name="Intrepion To Do"
version_bogus="35.6.1"
version_bunit="2.0.33-preview"
version_codegeneration="8.0.7"
version_csvhelper="33.0.1"
version_efcore="8.0.11"
version_intrepion="0.1.0"
version_mailkit="4.9.0"
version_playwright="1.49.0"
version_roslyn="VSCode-CSharp-2.60.26"
version_spectre="0.49.1"

# Install bUnit template
# Required for creating bUnit test projects
dotnet new install bunit.template::${version_bunit}

# Create initial files
dotnet new gitignore
dotnet new globaljson

# Create main Blazor project
dotnet new blazor --auth Individual --interactivity Auto --name ${app_name} --output . --use-local-db

# Create test and supporting projects
dotnet new nunit --name ${app_name}.AcceptanceTests
dotnet new classlib --name ${app_name}.BusinessLogic
dotnet new nunit --name ${app_name}.BusinessLogic.UnitTests
dotnet new console --name ${app_name}.ConsoleProject
dotnet new bunit --framework nunit --name ${app_name}.Client.ComponentTests
dotnet new bunit --framework nunit --name ${app_name}.Server.ComponentTests
dotnet new nunit --name ${app_name}.Server.ControllerTests
dotnet new razorclasslib --name ${app_name}.Shared
dotnet new bunit --framework nunit --name ${app_name}.Shared.ComponentTests

# Add projects to solution
dotnet sln add ${app_name}.AcceptanceTests
dotnet sln add ${app_name}.BusinessLogic
dotnet sln add ${app_name}.BusinessLogic.UnitTests
dotnet sln add ${app_name}.Client.ComponentTests
dotnet sln add ${app_name}.ConsoleProject
dotnet sln add ${app_name}.Server.ComponentTests
dotnet sln add ${app_name}.Server.ControllerTests
dotnet sln add ${app_name}.Shared
dotnet sln add ${app_name}.Shared.ComponentTests

# Add project references
dotnet add ${app_name} reference ${app_name}.BusinessLogic
dotnet add ${app_name} reference ${app_name}.Shared
dotnet add ${app_name}.BusinessLogic.UnitTests reference ${app_name}.BusinessLogic
dotnet add ${app_name}.Client reference ${app_name}.BusinessLogic
dotnet add ${app_name}.Client reference ${app_name}.Shared
dotnet add ${app_name}.Client.ComponentTests reference ${app_name}.Client
dotnet add ${app_name}.ConsoleProject reference ${app_name}.BusinessLogic
dotnet add ${app_name}.Server.ComponentTests reference ${app_name}
dotnet add ${app_name}.Server.ControllerTests reference ${app_name}
dotnet add ${app_name}.Shared.ComponentTests reference ${app_name}.Shared

cd ${app_name} && dotnet add package MailKit --version ${version_mailkit} && cd ..
cd ${app_name} && dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version ${version_efcore} && cd ..
cd ${app_name} && dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version ${version_codegeneration} && cd ..
cd ${app_name}.AcceptanceTests && dotnet add package Bogus --version ${version_bogus} && cd ..
cd ${app_name}.AcceptanceTests && dotnet add package Microsoft.Playwright.NUnit --version ${version_playwright} && cd ..
cd ${app_name}.BusinessLogic && dotnet add package Bogus --version ${version_bogus} && cd ..
cd ${app_name}.BusinessLogic && dotnet add package Microsoft.EntityFrameworkCore.Design --version ${version_efcore} && cd ..
cd ${app_name}.BusinessLogic && dotnet add package CsvHelper --version ${version_csvhelper} && cd ..
cd ${app_name}.BusinessLogic && dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version ${version_efcore} && cd ..
cd ${app_name}.BusinessLogic && dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version ${version_efcore} && cd ..
cd ${app_name}.ConsoleProject && dotnet add package Spectre.Console --version ${version_spectre} && cd ..
cd ${app_name}.ConsoleProject && dotnet add package Spectre.Console.Cli --version ${version_spectre} && cd ..
cd ${app_name}.ConsoleProject && dotnet add package Spectre.Console.Json --version ${version_spectre} && cd ..

curl --output .editorconfig https://raw.githubusercontent.com/dotnet/roslyn/${version_roslyn}/.editorconfig
dotnet format

dotnet build
cd ${app_name}.AcceptanceTests && ./bin/Debug/net8.0/playwright.ps1 install --with-deps && cd ..
