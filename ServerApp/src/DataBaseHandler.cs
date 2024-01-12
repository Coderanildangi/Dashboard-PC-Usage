using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Data.SqlClient;


/// This class handles Database Connection and Data transfer with it.
/// 


namespace ServerApp.src
{
    internal class DataBaseHandler
    {
        // Method to Save or Update the database from client data. 
        internal static void saveOrUpdateData(string ipAddress, string machineName, string os, string cpu, string ram, 
            string gpu, string disk, float cpuUsage, float ramUsage, float diskUsage, float fanSpeed, float gpuUsage, float gpuTemp, bool isConnected)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mConnectionString))
                {
                    connection.Open();

                    if(mCount == 0)
                    {
                        Console.WriteLine("Database Connected...");
                        SqlCommand clearAll = new SqlCommand("TRUNCATE TABLE ClientSystemData", connection);
                        clearAll.ExecuteNonQuery();
                        mCount++;
                    }

                    // SQL query to delete table data before adding it

                    // Sql Query to Save or Update Data into Database.
                    string query = "IF EXISTS (SELECT 1 FROM ClientSystemData WHERE IPAddress = @IPAddress) " +
                                   "BEGIN " +
                                   "  UPDATE ClientSystemData " +
                                   "  SET MachineName = @MachineName, OS = @OS, CPU = @CPU, RAM = @RAM, GPU = @GPU, DISK = @DISK, CPUUsage = @CPUUsage, RAMUsage = @RAMUsage, DiskUsage = @DiskUsage, FanSpeed = @FanSpeed, IsConnected = @IsConnected, " +
                                   "  GPULoad = @GPULoad, GPUTemp = @GPUTemp  WHERE IPAddress = @IPAddress " +
                                   "END " +
                                   "ELSE " +
                                   "BEGIN " +
                                   "  INSERT INTO ClientSystemData (IPAddress, MachineName, OS, CPU, RAM, GPU, DISK, CPUUsage, RAMUsage, DiskUsage, FanSpeed, IsConnected, GPULoad, GPUTemp) " +
                                   "  VALUES (@IPAddress, @MachineName, @OS, @CPU, @RAM, @GPU, @DISK, @CPUUsage, @RAMUsage, @DiskUsage, @FanSpeed, @IsConnected, @GPULoad, @GPUTemp) " +
                                   "END ";

                    // Executing SQL Command.
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IPAddress", ipAddress);
                    command.Parameters.AddWithValue("@MachineName", machineName);
                    command.Parameters.AddWithValue("@OS", os);
                    command.Parameters.AddWithValue("@CPU", cpu);
                    command.Parameters.AddWithValue("@RAM", ram);
                    command.Parameters.AddWithValue("@GPU", gpu);
                    command.Parameters.AddWithValue("@DISK", disk);
                    command.Parameters.AddWithValue("@CPUUsage", cpuUsage);
                    command.Parameters.AddWithValue("@RAMUsage", ramUsage);
                    command.Parameters.AddWithValue("@DiskUsage", diskUsage);
                    command.Parameters.AddWithValue("@FanSpeed", fanSpeed);
                    command.Parameters.AddWithValue("@IsConnected", isConnected);
                    command.Parameters.AddWithValue("@GPULoad", gpuUsage);
                    command.Parameters.AddWithValue("@GPUTemp", gpuTemp);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }
        }

        // Method to update IsConnected value if system is disconnected...
        internal static void updateConnectionStatus(string ipAddress, bool isConnected)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(mConnectionString))
                {
                    connection.Open();
                    string query = "UPDATE ClientSystemData SET IsConnected = @IsConnected WHERE IPAddress = @IPAddress";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IsConnected", isConnected);
                    command.Parameters.AddWithValue("@IPAddress", ipAddress);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }

        }

        // ------------------------------------------
        // Private Data Members.

        // Connection string for SQL SERVER Daabase.
        private const string mConnectionString = @"Server=DESKTOP-9UFDCFP;Database=ClientDataDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;Integrated Security=True;";
    
        // Static member.
        private static int mCount = 0;
    }
}
