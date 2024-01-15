# Dashboard PC Usage App

This application is designed to monitor and display real-time PC usage data collected from multiple computers within a network.

## Components

### Client App
- **Description**: Collects system data (CPU, RAM, disk usage, etc.) from individual PCs.
- **Technologies**: C#, WPF, Performance Counters.
- **Usage**: Run the client app on PCs within the network to collect system data.

### Server App
- **Description**: Central server handling incoming data from multiple clients and storing it in a database.
- **Technologies**: C#, .NET Framework, TCP/IP Sockets, SQL Server.
- **Usage**: Run the server app to receive data from client apps and store it in the database.

### Dashboard Monitor App
- **Description**: Real-time visualization of aggregated PC usage data received from the server app.
- **Technologies**: C#, WPF, Data Binding.
- **Usage**: Run the dashboard app to visualize and monitor PC usage across the network.

## Installation and Setup

1. **Client App Setup**:
   - Clone or download the client app source code.
   - Configure the server IP and port in the client code.
   - Run the client app on target PCs within the network.

2. **Server App Setup**:
   - Clone or download the server app source code.
   - Set up a SQL Server database and execute the provided SQL script to create the required tables.
   - Update the database connection string in the server code with your SQL Server details.
   - Run the server app to start listening for client connections.

3. **Dashboard Monitor App Setup**:
   - Clone or download the dashboard monitor app source code.
   - Modify the connection details to establish a connection with the server app.
   - Run the dashboard monitor app to visualize real-time PC usage data.

## Usage

1. Start the server app to listen for incoming client connections.
2. Run the client app on target PCs to start collecting system data.
3. Launch the dashboard monitor app to visualize and monitor aggregated PC usage data.

## Contributing

Contributions are welcome! Fork the repository, make your changes, and submit a pull request.

## License

This project is licensed under CCtech.

## Class Architecture Diagram

![ArchitectureClass](https://github.com/Coderanildangi/Dashboard-PC-Usage/assets/149321466/4cb473bb-af22-458b-bf4c-5986ac13d37b)

## Video Output

[video.webm](https://github.com/Coderanildangi/Dashboard-PC-Usage/assets/149321466/2f670c0d-3f1a-4d91-ad7e-d626980adcda)
