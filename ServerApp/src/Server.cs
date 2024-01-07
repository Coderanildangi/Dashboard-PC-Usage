using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                Console.WriteLine("Database Connected...");

                while(true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Thread clientThread = new Thread(() => ClientHandler.handleClient(client));
                    clientThread.Start();
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // ----------------------------------------
        // Private Members
        private const int port = 8080;
    }
}
