#  Dashboard Monitor App for Dashboard PC Usage

The Dashboard Monitor App is a component of the Dashboard PC Usage system, providing real-time visualization of PC usage data received from the server app.

## Overview
This app is designed to offer a user-friendly interface to monitor and visualize PC usage across the network. It connects to the central server, fetches real-time data, and presents it in an easy-to-understand dashboard.

## Table of Contents

1. [Features](#introduction)
2. [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
3. [Usage](#usage)
    - [User Guide](#user-guide)
    - [Developer Guide](#developer-guide)
4. [Configuration](#configuration)
5. [Troubleshooting](#troubleshooting)
6. [Contributing](#contributing)
7. [License](#license)
8. [Output]

## Features

- Real-time visualization of PC usage data.
- Connects to the central server to fetch aggregated data.
- Provides an intuitive dashboard for monitoring purposes.

## Getting Started

### Prerequisites

Before you begin, make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) for C# development
-  Visual Studio or any preferred C# IDE.
- C #WPF (https://learn.microsoft.com/en-us/dotnet/desktop/wpf/?view=netframeworkdesktop-4.8).

### Installation

1. **Clone this repository to your local machine:**

    ```bash
    git clone https://github.com/Coderanildangi/Dashboard-PC-Usage.git
    ```

2. **Change into the project directory:**

    ```bash
    cd client-app
    ```

3. **Build the application:**

    ```bash
    dotnet build
    ```

4. **Run the application:**

    ```bash
    dotnet run
    ```

5. [Additional steps, such as configuring server connection parameters if applicable]

## Usage

### User Guide

#### Connecting to the SQL Server

To connect to the server, run the application and follow these steps:

1. Launch the WPF application.
2. It automatically connects to SQL Server.
3. It also collects data from SQL Sever DB. 
4. visualization in charts, gauges and graph..

#### Collecting Data

1. Once connected, collects data from Database.
2. Visualizes it in real time updated data in the form of charts, graphs.

### Developer Guide

#### Project Structure

The project follows a standard C# console application structure. Key components include:

- `App.xaml`: This XAML file defines a WPF application and any application resources.
- `MainWindow`: This XAML file is the main window of your application and displays content created in pages.
- `MainWindow.xaml.cs`: This file is a code-behind file that contains code to handle the events declared in MainWindow.xaml
- `UsageModel.cs`: It collects from client PCs in real time.
- `DataBaseHandler.cs`: It connects server to SQL Server database.

## Configuration

The application requires manual putting of IP address of server.

## Troubleshooting

- Check you internet connection.
- The Client PC must be connected to LAN on which server runs.

## Contributing

We welcome contributions! If you find any issues or have ideas for improvements, please check out our [Contribution Guidelines](CONTRIBUTING.md).

## License

This project is licensed under the [CCtech].

## Output

![Dashboard](https://github.com/Coderanildangi/Dashboard-PC-Usage/assets/149321466/03e5500f-4000-4334-a16c-0213010fc4a2)
