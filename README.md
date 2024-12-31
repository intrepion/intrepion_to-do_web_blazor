<!-- /README.md -->

# intrepion_to-do_web_blazor

A comprehensive To Do application built with .NET Blazor and .NET MAUI. This project demonstrates how to create a modern, cross-platform application that works seamlessly across web browsers, desktop environments (Windows, macOS, Linux), and mobile platforms (iOS, Android).

## Prerequisites

### Core Requirements
- **Docker**: [Installation Guide](https://docs.docker.com/get-docker/)
- **Docker Compose**: [Installation Guide](https://docs.docker.com/compose/install/)
- **Git**: [Installation Guide](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)
- **.NET SDK 8.0**: [Installation Guide](https://dotnet.microsoft.com/download/dotnet/8.0)

### Platform-Specific Requirements

#### For Web Development
- Any modern web browser
- Visual Studio Code (recommended) or your preferred IDE

#### For Windows Desktop Development
- Windows 10/11
- Visual Studio 2022 with the following workloads:
  - .NET Desktop Development
  - .NET MAUI Development

#### For macOS Desktop Development
- macOS 13.0 (Ventura) or later
- Visual Studio for Mac or JetBrains Rider
- Xcode 15.0 or later

#### For Linux Desktop Development
- Ubuntu 20.04 or later (or equivalent)
- GTK development libraries
- Visual Studio Code with C# extension

#### For iOS Development
- macOS 13.0 (Ventura) or later
- Xcode 15.0 or later
- Visual Studio for Mac or JetBrains Rider
- Apple Developer account (for device deployment)

#### For Android Development
- Android Studio
- Android SDK Platform 33
- Android Build Tools 33.0.0
- Android NDK 25.1.8937393
- Java Development Kit (JDK) 17

## Project Structure

```
blazor-project/
├── docker/                     # Docker configuration files
│   ├── Dockerfile             # Web development environment
│   ├── Dockerfile.init        # Project initialization
│   ├── Dockerfile.publish     # Web production build
│   └── Dockerfile.maui-android # Android development environment
├── Intrepion.ToDo/            # Main Blazor web project
├── Intrepion.ToDo.MauiClient/ # MAUI client application
├── Intrepion.ToDo.Shared/     # Shared code library
└── [Other project folders]     # Additional solution projects
```

## Development Environments

### Web Application Development

1. Initialize the project:
```bash
docker compose run --rm blazor-init
```

2. Start the development server:
```bash
docker compose up blazor-dev
```

The web application will be available at `http://localhost:5151` with hot reload enabled.

### Android Development

#### Using Docker

1. Start the Android development environment:
```bash
docker compose up maui-android-dev
```

2. Build the Android application:
```bash
docker compose run --rm maui-android-build
```

3. Run Android-specific tests:
```bash
docker compose run --rm maui-android-test
```

#### Using Local Development Environment

1. Install prerequisites:
```bash
dotnet workload install maui-android
```

2. Open in Visual Studio 2022:
   - Set Intrepion.ToDo.MauiClient as startup project
   - Select Android Emulator as target
   - Press F5 to run

3. Command line development:
```bash
cd Intrepion.ToDo.MauiClient
dotnet build -f net8.0-android
dotnet run -f net8.0-android
```

### iOS Development

iOS development must be performed on macOS due to Apple's development requirements.

1. Initial Setup:
```bash
# Install Xcode command line tools
xcode-select --install

# Accept Xcode license
sudo xcodebuild -license accept

# Install MAUI workload
dotnet workload install maui

# Install iOS development certificate
dotnet workload install ios
```

2. Development Options:

Using Visual Studio for Mac:
- Open solution
- Set Intrepion.ToDo.MauiClient as startup
- Select iOS Simulator target
- Press Play to run

Using Command Line:
```bash
# Build for iOS Simulator
dotnet build -f net8.0-ios /p:Platform=iPhoneSimulator

# Run in Simulator
dotnet run -f net8.0-ios --project Intrepion.ToDo.MauiClient/Intrepion.ToDo.MauiClient.csproj

# Run tests
dotnet test Intrepion.ToDo.MauiClient.Tests/Intrepion.ToDo.MauiClient.Tests.csproj
```

### Desktop Development

#### Windows
1. Open solution in Visual Studio 2022
2. Set Intrepion.ToDo.MauiClient as startup
3. Select Windows Machine as target
4. Press F5 to run

Command line:
```bash
dotnet build -f net8.0-windows10.0.19041.0
dotnet run -f net8.0-windows10.0.19041.0
```

#### macOS
1. Open solution in Visual Studio for Mac
2. Set Intrepion.ToDo.MauiClient as startup
3. Select Mac Catalyst as target
4. Press Play to run

Command line:
```bash
dotnet build -f net8.0-maccatalyst
dotnet run -f net8.0-maccatalyst
```

#### Linux
Ensure GTK is installed:
```bash
sudo apt-get install gtk+3.0
```

Build and run:
```bash
dotnet build -f net8.0-linux
dotnet run -f net8.0-linux
```

## Publishing

### Web Application

Using Docker:
```bash
docker compose up blazor-prod
```

Manual publishing:
```bash
dotnet publish Intrepion.ToDo/Intrepion.ToDo.csproj -c Release
```

### Desktop Applications

#### Windows
```bash
dotnet publish Intrepion.ToDo.MauiClient/Intrepion.ToDo.MauiClient.csproj \
  -f net8.0-windows10.0.19041.0 \
  -c Release \
  -p:RuntimeIdentifier=win10-x64 \
  --self-contained true
```

#### macOS
```bash
dotnet publish Intrepion.ToDo.MauiClient/Intrepion.ToDo.MauiClient.csproj \
  -f net8.0-maccatalyst \
  -c Release \
  -p:RuntimeIdentifier=maccatalyst-x64 \
  --self-contained true
```

#### Linux
```bash
dotnet publish Intrepion.ToDo.MauiClient/Intrepion.ToDo.MauiClient.csproj \
  -f net8.0-linux \
  -c Release \
  -p:RuntimeIdentifier=linux-x64 \
  --self-contained true
```

### Mobile Applications

#### Android
Using Docker:
```bash
docker compose run --rm maui-android-build
```

Manual publishing:
```bash
dotnet publish Intrepion.ToDo.MauiClient/Intrepion.ToDo.MauiClient.csproj \
  -f net8.0-android \
  -c Release \
  --self-contained true
```

#### iOS
1. Configure certificates in Xcode:
   - Open Xcode → Preferences → Accounts
   - Add Apple ID
   - Download manual provisioning profiles

2. Build for App Store:
```bash
dotnet publish -f net8.0-ios -c Release \
  /p:Platform=iPhone \
  /p:PropertyGroup/RuntimeIdentifier=ios-arm64 \
  /p:PropertyGroup/CodesignKey="iPhone Distribution" \
  /p:PropertyGroup/CodesignProvision="Your Provisioning Profile Name"
```

## Testing

### Running All Tests
```bash
docker compose run --rm blazor-test
```

### Platform-Specific Tests

Web tests:
```bash
dotnet test Intrepion.ToDo.Client.ComponentTests
```

Android tests:
```bash
docker compose run --rm maui-android-test
```

iOS tests (macOS only):
```bash
dotnet test Intrepion.ToDo.MauiClient.Tests -f net8.0-ios
```

## Troubleshooting

### Web Development
1. Clear Docker cache:
```bash
docker compose down -v
docker system prune -a
```

2. Verify ports are available:
```bash
lsof -i :5151
```

### Android Development
1. Check Android SDK installation:
```bash
sdkmanager --list
```

2. Verify device connectivity:
```bash
adb devices
```

3. Clear Android build cache:
```bash
dotnet clean -f net8.0-android
```

### iOS Development
1. Reset iOS Simulator:
   - Simulator → Device → Erase All Content and Settings

2. Clear Xcode cache:
```bash
rm -rf ~/Library/Developer/Xcode/DerivedData
```

3. Reinstall MAUI workload:
```bash
dotnet workload repair
```

### Desktop Development
1. Windows: Verify Windows SDK installation
2. macOS: Check Xcode Command Line Tools
3. Linux: Verify GTK installation
4. Clear MAUI cache:
```bash
dotnet clean Intrepion.ToDo.MauiClient
```

## Contributing

1. Fork the repository
2. Create your feature branch: `git checkout -b feature/YourFeature`
3. Commit your changes: `git commit -m 'Add YourFeature'`
4. Push to the branch: `git push origin feature/YourFeature`
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.
