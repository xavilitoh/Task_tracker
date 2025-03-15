## Clone repo 📋

```sh
  git clone https://github.com/xavilitoh/Task_tracker.git
  cd TaskTracker
```

## Prerequisites 📦

To run this project, you need to have the following dependencies installed:

1. **.NET Core SDK 9.0**:
   You can download and install the .NET Core SDK 9.0 from the official [.NET download page](https://dotnet.microsoft.com/download/dotnet/9.0).

## Installing Dependencies 🛠️

### .NET Core SDK 9.0

1. Visit the [.NET download page](https://dotnet.microsoft.com/download/dotnet/9.0).
2. Download the installer for your operating system (Windows, macOS, or Linux).
3. Run the installer and follow the instructions to complete the installation.

## Deployment Steps 🚀

To execute the program you should run the following command:
```bash
  dotnet run help
```

### Install as a global tool 🛠️

1. **Build the package**:
   Use the `dotnet pack` command to generate a `.nupkg` file.

   ```sh
   dotnet pack --configuration Release
   ```

This will generate the package in the `bin/Release` folder.

2. **Install the package**:
   In the terminal, navigate to the folder where the package was generated and proceed to install it with the `dotnet` CLI using the following command:

   ```sh
   dotnet tool install --global --add-source {ruta del paquete} TaskTracker
   ```

   Example:

   ```sh
   dotnet tool install --global --add-source ./TaskTracker/bin/Release/ TaskTracker
   ```

3. **Run the Task tracker CLI**:
   Once installed, you can run the tool using the following command:

   ```sh
   task-cli help
   ```


This project is part of [Road Map Projects](https://roadmap.sh/projects/task-tracker).