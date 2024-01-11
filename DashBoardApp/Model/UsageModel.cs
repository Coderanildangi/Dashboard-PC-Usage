using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoardApp.Model
{
    internal class UsageModel
    {
        public string mMachineName { get; set; }
        public string mOS { get; set; }
        public string mCPU { get; set; }
        public string mRAM { get; set; }
        public string mGPU { get; set; }
        public string mDisk { get; set; }
        public double mCPUUsage { get; set; }
        public double mRAMUsage { get; set; }
        public double mDiskUsage { get; set; }
        public double mFanSpeed { get; set; }
        public double mGPULoad {  get; set; }
        public double mGPUTemp {  get; set; }
        public bool mIsConnected { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
