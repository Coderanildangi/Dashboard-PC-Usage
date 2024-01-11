using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.VisualBasic.Devices;
using System.CodeDom.Compiler;

namespace ClientApp.src
{
    internal class ComputerHardware : Microsoft.VisualBasic.Devices.ServerComputer
    {
        // Default Constructor for Computer class.
        private ComputerHardware() { }


        // Method to get Computer Hardware Information from traversing through Management Searcher Classe. 
        public static string GetComponentInformation(string hardwareName, string info)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hardwareName);

            StringBuilder result = new StringBuilder();

            // Traversing through Management Object Searcher class.
            foreach (ManagementObject obj in searcher.Get())
            {
                result.Append(obj[info]?.ToString()).Append(" ");
            }

            return result.ToString();
        }

        // Method to get Computer System name.
        public static string getMachineName()
        {
            mMachineName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            return mMachineName;
        }

        // Method to get Computer OS Information.
        public static string getOSInformation()
        {
            // Creating an Object of  class ComputerInfo.
            ComputerInfo computerinfo = new ComputerInfo();
            mOSInformation = computerinfo.OSFullName + " Version : " + ComputerHardware.GetComponentInformation("Win32_OperatingSystem ",
                "Version") + " Build : " + ComputerHardware.GetComponentInformation("Win32_OperatingSystem ", "BuildNumber");

            return mOSInformation;
        }

        // Method to get Computer CPU Information.
        public static string getCPUInformation()
        {
            mCPUInformation = GetComponentInformation("Win32_Processor ", "Name");

            return mCPUInformation;
        }

        // Method to get Installed RAM Capacity.
        public static string getInstalledRAM()
        {
            ComputerInfo computerInfo = new ComputerInfo();
            mInstalledRAM = Math.Round((double)computerInfo.TotalPhysicalMemory / (1024 * 1024 * 1024), 2).ToString() + " GB";

            return mInstalledRAM;
        }

        // Method to get Computer GPU Information.
        public static string getGPUInformation()
        {
            mGPUInformation = ComputerHardware.GetComponentInformation("Win32_VideoController ", "Name");

            return mGPUInformation;
        }

        // Method to get Capacity of Computer Hard Drive.
        public static string getDiskInformation()
        {
            mDiskInfromation = ComputerHardware.GetComponentInformation("Win32_DiskDrive ", "Model");

            return mDiskInfromation;
        }

        // -----------------------------------------------------------------------------------
        // Private Data members.

        // System Name.
        private static string mMachineName;

        // OS Version Build.
        private static string mOSInformation;

        // CPU Model and Make.
        private static string mCPUInformation;

        // Main Memory Capacity available to OS.
        private static string mInstalledRAM;

        // GPU Make.
        private static string mGPUInformation;

        // Disk Drive Make and Capacity.
        private static string mDiskInfromation;

    }
}
