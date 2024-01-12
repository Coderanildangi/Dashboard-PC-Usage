using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// This class establishes server on Given IP address.
/// 


namespace ServerApp.src
{
    internal class Server
    {
        // Default Constructor.
        public Server() { }

        // Method to Start Server.
        public static void startServer()
        {
            try
            {
                // Creating Server at Current Machine IP address.
                TcpListener listener = new TcpListener(IPAddress.Any, port);

                // Staring the Server.
                listener.Start();

                Console.WriteLine("Server Started... \nWaiting for clients Connections...");

                while(true)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

                    // Adding Client IP Address in HashSet.
                    clientIPAddresses.Add(clientIP);

                    // Starting Client Thread.
                    Thread clientThread = new Thread(() => ClientHandler.handleClient(client));
                    clientThread.Start();
                    printIPsOfClientSystems();

                }
                

            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Method to Print IP Addresses of all Connected Clients.
        public static void printIPsOfClientSystems()
        {
            Console.WriteLine("Connected Clients are : ");
            Console.WriteLine("--------------------------------------------------");
            int i = 1;
            foreach (var item in clientIPAddresses)
            {
                Console.WriteLine($"{i}. {item.ToString()}");
                i++;
            }
            Console.WriteLine("--------------------------------------------------");
        }

        // ----------------------------------------
        // Private Members
        private const int port = 8080;

        // Static member.
        private static int count = 0;

        // HashSet of IP address.
        private static HashSet<string> clientIPAddresses = new HashSet<string>();
    }
}
