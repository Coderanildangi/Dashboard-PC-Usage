using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.src
{
    internal class Connector
    {
        // Default Constructor. 
        public Connector() { }

        // Method to send data to server.
        public void sendDataToServer(string machine, string os, string cpu, string ram, 
            string gpu, string disk, float cpuUsage, float ramUsage, float diskUsage, float fanSpeed)
        {
            try
            {
                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)) 
                {
                    // Parsing IP Address.
                    IPAddress ipAddress = IPAddress.Parse(mServerIP);

                    // Creating IPEndPoint.
                    IPEndPoint serverEndPoint = new IPEndPoint(ipAddress, mServerPort);

                    // Connecting to Server.
                    clientSocket.Connect(serverEndPoint);
                    Console.WriteLine("Client connected to remote Server with ip address : " +mServerIP + ":" + mServerPort);

                    // Storing data into single string stream.
                    string data = $"{machine},{os},{cpu},{ram},{gpu},{disk},{cpuUsage},{ramUsage},{diskUsage},{fanSpeed}";

                    // Storing data into byte stream/Array.
                    byte[] bytes = Encoding.UTF8.GetBytes(data);
                    clientSocket.Send(bytes);
                    clientSocket.Shutdown(SocketShutdown.Both);

                    // Closing Socket.
                    clientSocket.Close();
                }
            }

            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

        }
        // ------------------------------------------------
        // Private Data Members.

        // IP V4 Address of Server.
        private const string mServerIP = "192.168.0.129";

        // Port of Server Running.
        private const int mServerPort = 8080;
    }
}
