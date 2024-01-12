using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DashBoardApp.Model;

namespace DashBoardApp.DAL
{
    internal class DataBaseHandler
    {
        // Method to get avaiable clients in LAN list.
        public static List<string> GetAvailableClients()
        {
            // Data Structure to store machine names in List.
            List<string> clients = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(mConnectionString))
                {
                    connection.Open();
                    string query = "SELECT DISTINCT machineName FROM ClientSystemData";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string machineName = reader["machineName"].ToString();
                        clients.Add(machineName);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }
            return clients;
        }

        //Method to get machine properties like usage and info like.
        public static UsageModel GetUsageData(string machineName)
        {
            // Creating object of UsagModel to store data from database.
            UsageModel usageData = new UsageModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(mConnectionString))
                {
                    // Connecting to database.
                    connection.Open();
                    
                    string query = "SELECT * FROM ClientSystemData WHERE machineName = @MachineName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MachineName", machineName);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Populating propetries from database.
                        usageData.mMachineName = reader["machineName"].ToString();
                        usageData.mFanSpeed = Math.Round((double)reader["FanSpeed"], 2);
                        usageData.mCPUUsage = Math.Round((double)reader["CPUUsage"], 2);
                        usageData.mRAMUsage = Math.Round((double)reader["RAMUsage"], 2);
                        usageData.mDiskUsage = Math.Round((double)reader["DiskUsage"], 2);
                        
                        usageData.mGPULoad = Math.Round((double)reader["GPULoad"], 2);
                        usageData.mGPUTemp = Math.Round((double)reader["GPUTemp"], 2);
                        usageData.mIsConnected = Convert.ToBoolean(reader["IsConnected"]);
                        usageData.mCPU = reader["CPU"].ToString();
                        usageData.mRAM = reader["RAM"].ToString();
                        usageData.mDisk = reader["DISK"].ToString();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }
            return usageData;
        }

        // Method to get List of CPU, RAM, DISK Usage data from Database.

        //public static 


        // --------------------------------------------------------
        // Private Data members.

        // Connection string for data base connection.
        private const string mConnectionString = @"Server=DESKTOP-9UFDCFP;Database=ClientDataDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;Integrated Security=True;"; 

    }
}
