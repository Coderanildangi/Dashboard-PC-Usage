using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientApp.src;


namespace ClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating object of Computer Performance class.
            ComputerPerformance computerPerformance = new ComputerPerformance();

            // Creating object of connector class.
            Connector connector = new Connector();

            // Starting thread for sending data at recurring intervals.
            Thread sendDataThread = new Thread(() =>
            {
                while (true)
                {
                    float cpuUsage = computerPerformance.getCPUUsage();
                    float ramUsage = computerPerformance.getRAMUsage();
                    float diskUsage = computerPerformance.getDiskUsage();
                    float fanSpeed = computerPerformance.getFanSpeed();
                    float gpuUsage = computerPerformance.getGPULoad();
                    float gpuTemp = computerPerformance.getGPUTemp();
                    string machine = ComputerHardware.getMachineName();
                    string os = ComputerHardware.getOSInformation();
                    string cpu = ComputerHardware.getCPUInformation();
                    string ram = ComputerHardware.getInstalledRAM();
                    string gpu = ComputerHardware.getGPUInformation();
                    string disk = ComputerHardware.getDiskInformation();

                    // Sending data to the Server.
                    connector.sendDataToServer(machine, os, cpu, ram, gpu, disk,
                        cpuUsage, ramUsage, diskUsage, fanSpeed, gpuUsage, gpuTemp);

                    // Sending data after gap of 1000 milliseconds == 1 second.
                    Thread.Sleep(500);
                }
            });

            // Starting the thread.
            sendDataThread.Start();

            Console.ReadKey();
        }
    }
}
