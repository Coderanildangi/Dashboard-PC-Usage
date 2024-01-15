# Client App README

## Overview

Welcome to the client app for our innovative product! This README provides in-depth information to help you get started with the C# console application built with socket programming. Whether you're a developer, tester, or user, this guide will walk you through the app's functionality, installation, and key features.

## Table of Contents

1. [Introduction](#introduction)
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

## Introduction

Our client app, developed in C# and utilizing socket programming, is a console application designed to facilitate data sending securely to server. It enables users to send data to server app automatically. This app is particularly useful for System Admins, Managers and Supervisors.

## Getting Started

### Prerequisites

Before you begin, make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) for C# development

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

#### Connecting to the Server

To connect to the server, run the application and follow these steps:

1. Launch the console application.
2. It automatically connects to remote server.
3. It also sends data regarding system such as hardware information, performance parameters to server.

#### Sending Data

Once connected, you can send Data to the server. Follow these steps:

1. It automatically sends data to sever for recurring intervals of 1000 milliseconds.

### Developer Guide

#### Project Structure

The project follows a standard C# console application structure. Key components include:

- `Program.cs`: Main entry point of the application.
- `Connector.cs`: Implementation of the socket client.
- `ComputerPerformance.cs`: It collects information such as CPU Usage, RAM and DISK Usages.
- `ComputerHardware.cs`: It collects System hardware information.

#### Socket Programming

The application uses socket programming for communication. The `SocketClient` class handles the client-side socket interactions. Developers interested in extending functionality should focus on this class.

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

![Client](https://github.com/Coderanildangi/Dashboard-PC-Usage/assets/149321466/2d5c8a28-6df1-4033-a819-40a858a42101)
