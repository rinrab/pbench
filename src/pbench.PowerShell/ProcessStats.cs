using System;

namespace pbench.PowerShell
{
    public class ProcessStats
    {
        public TimeSpan RealTime { get; set; }
        public TimeSpan CpuTime { get; set; }
        public TimeSpan UserTime { get; set; }
        public TimeSpan KernelTime { get; set; }
        public TimeSpan TotalTime { get; set; }
        public long ReadCount { get; set; }
        public long ReadBytes { get; set; }
        public long WriteCount { get; set; }
        public long WriteBytes { get; set; }
    }
}
