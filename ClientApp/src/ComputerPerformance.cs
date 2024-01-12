using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;

/// This class collects system performance parameters
/// 

namespace ClientApp.src
{
    internal class ComputerPerformance
    {
        // Default Contsructor.
        public ComputerPerformance() 
        {
            computer.Open();
        }

        // Method to get CPU Usage.
        public float getCPUUsage()
        {
            foreach (var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.CPU)
                {
                    // Update the Hardware for Real time Data.
                    hardware.Update();

                    foreach (var sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("CPU Total"))
                        {
                            mCPUUsage = sensor.Value.GetValueOrDefault();
                        }
                    }
                }
                    
            }

            return mCPUUsage;
        }

        // Method to get RAM Usage.
        public float getRAMUsage()
        {
            foreach(var hardware in computer.Hardware)
            {
                if(hardware.HardwareType == HardwareType.RAM)
                {
                    // Update The Hardware.
                    hardware.Update();

                    foreach(var sensor in hardware.Sensors)
                    {
                        if(sensor.SensorType == SensorType.Load && sensor.Name.Contains("Memory"))
                        {
                            mRAMUsage = sensor.Value.GetValueOrDefault();
                        }
                    }
                }
            }

            return mRAMUsage;
        }

        // Method to get Disk Usage.
        public float getDiskUsage()
        {
            foreach (var hardware in computer.Hardware)
            {
                if(hardware.HardwareType == HardwareType.HDD)
                {
                    // Update the hardware.
                    hardware.Update();

                    foreach( var sensor in hardware.Sensors)
                    {
                        if( sensor.SensorType == SensorType.Load && sensor.Name.Contains("Used Space"))
                        {
                            mDiskUsage = sensor.Value.GetValueOrDefault();
                        }
                    }
                }
            }

            return mDiskUsage;
        }

        // Method to get GPU load.
        public float getGPULoad()
        {
            foreach( var hardware in computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.GpuAti || hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    // Update the Hardware.
                    hardware.Update();

                    foreach ( var sensor in hardware.Sensors)
                    {
                        if(sensor.SensorType == SensorType.Load && sensor.Name.Contains("GPU Core"))
                        {
                            mGpuUsage = sensor.Value.GetValueOrDefault();
                        }
                    }
                }
            }

            return mGpuUsage;
        }

        // Method to get GPU Fan speed.
        public float getFanSpeed()
        {
            foreach(var hardware in computer.Hardware)
            {
                if(hardware.HardwareType == HardwareType.GpuAti || hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    // Update the Harddrive.
                    hardware.Update();

                    foreach (var sensor in hardware.Sensors)
                    {
                        if(sensor.SensorType == SensorType.Fan && sensor.Name.Contains("GPU Fan"))
                        {
                            mGPUFan = sensor.Value.GetValueOrDefault();
                        }
                    }
                }
            }

            return mGPUFan;
        }

        // Method to get GPU Temperature.
        public float getGPUTemp()
        {
            foreach ( var hardware in computer.Hardware)
            {
                if(hardware.HardwareType == HardwareType.GpuAti || hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    // Update the driver.
                    hardware.Update();

                    foreach( var sensor in hardware.Sensors)
                    {
                        if(sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("GPU Core"))
                        {
                            mGPUTemp = sensor.Value.GetValueOrDefault();
                        }
                    }
                }
            }

            return mGPUTemp;
        }

        // ----------------------------------------------------------
        // Private Data members.

        // Creating object of Computer class of Open Hardware Monitor API.
        private static Computer computer = new Computer()
        {
            GPUEnabled = true,
            CPUEnabled = true,
            RAMEnabled = true, 
            MainboardEnabled = true, 
            FanControllerEnabled = true,
            HDDEnabled = true, 
        };

        // CPU Usage.
        private static float mCPUUsage;

        // Main Memory Usage. 
        private static float mRAMUsage;

        // Disk Usage.
        private static float mDiskUsage;

        // GPU Fan Speed in RPM.
        private static float mGPUFan;

        // GPU Temperature in Celsius.
        private static float mGPUTemp;

        // GPU Usage.
        private static float mGpuUsage;
    }
}
