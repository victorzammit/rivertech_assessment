# Running .NET Tests via CLI

This document provides step-by-step instructions on how to build and run the .NET automated tests for the API Servide & Web SauceDemo using the command line interface (CLI).

## Prerequisites

Before running the tests, ensure you have the following installed on your machine:

- **.NET SDK**: Version 8.0 or later. You can download it from the [.NET Download Page](https://dotnet.microsoft.com/download).
- **Chrome Browser**: Installed on your machine.
- **ChromeDriver**: Ensure that the ChromeDriver version matches your installed Chrome browser version. This is managed by the `Selenium.WebDriver.ChromeDriver` package in the project.

## Steps to Build and Run Tests

Follow these steps to build the project and execute the tests using the CLI:

### 1. Open Command Line Interface

Open your command prompt, PowerShell, or terminal.

### 2. Navigate to Project Directory

Change the directory to where your project clone is located. Replace `path/to/rivertech_assessment` with the actual path to your project.

```bash
cd path/to/rivertech_assessment
```

### 3. Restore .NET for clean environment dependencies

Before building the project, restore and clean any dependencies required by the project using the following command:

```bash
dotnet restore
dotnet clean
```

### 4. Build .NET project

Build the .NET project using the following command:

```bash
dotnet build
```

### 5. Run Tests

Run the built .NET Tests (API Service and Selenium Web Auto Test) using the following command:

```bash
dotnet test
```
