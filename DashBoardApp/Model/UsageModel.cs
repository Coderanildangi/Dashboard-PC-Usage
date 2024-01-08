using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardApp.Model
{
    internal class UsageModel
    {
        public string MachineName { get; set; }
        public string OS { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string GPU { get; set; }
        public string Disk { get; set; }
        public double CPUUsage { get; set; }
        public double RAMUsage { get; set; }
        public double DiskUsage { get; set; }
        public double FanSpeed { get; set; }
        public bool IsConnected { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
