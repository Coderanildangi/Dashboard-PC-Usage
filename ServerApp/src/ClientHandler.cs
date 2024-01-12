using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// This class handles requests from clients PCs connected in LAN.
/// 

namespace ServerApp.src
{
    internal class ClientHandler
    {
        // Method to handle incoming client data.
        public static void handleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // Splitting data at comma (,).
                string[] dataParts = data.Split(',');
                if (dataParts.Length == 12)
                {
                    string ipAddress = ((System.Net.IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                    string machineName = dataParts[0];
                    string os = dataParts[1];
                    string cpu = dataParts[2];
                    string ram = dataParts[3];
                    string gpu = dataParts[4];
                    string disk = dataParts[5];
                    float cpuUsage = float.Parse(dataParts[6]);
                    float ramUsage = float.Parse(dataParts[7]);
                    float diskUsage = float.Parse(dataParts[8]);
                    float fanSpeed = float.Parse(dataParts[9]);
                    float gpuUsage = float.Parse(dataParts[10]);
                    float gpuTemp = float.Parse(dataParts[11]);

                    // Method to Save data to the database and mark client as connected.
                    DataBaseHandler.saveOrUpdateData(ipAddress, machineName, os, cpu, ram, gpu, disk, cpuUsage, ramUsage, diskUsage, fanSpeed, gpuUsage, gpuTemp, true);

                    // Method to check if Client is alive or to keep client connected.
                    //checkClientConnection(ipAddress, machineName, stream);
                    checkConnectionWithClient(ipAddress, client);
                }

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Client Connection Error: {ex.Message}"); 

                // If error occurs then mark client as disconnected
                if(!client.Connected)
                {
                    string ipAddress = ((System.Net.IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                    DataBaseHandler.updateConnectionStatus(ipAddress, false);
                }
            }
        }

        private static void checkConnectionWithClient(string ipAddress, TcpClient client)
        {
            // If return true update the valu of IsConnected accordingly.
            while(true)
            {
                
                if (!client.Connected)
                {
                    // Update.
                    DataBaseHandler.updateConnectionStatus(ipAddress, false);
                    Thread.Sleep(60000);
                }

                else
                    return;
            }
            
        }

    }
}
