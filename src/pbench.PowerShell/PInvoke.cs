using System;
using System.Runtime.InteropServices;

public class PInvoke
{
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool GetProcessIoCounters(IntPtr hProcess, out IO_COUNTERS lpIoCounters);

    [StructLayout(LayoutKind.Sequential)]
    public struct IO_COUNTERS
    {
        public long ReadOperationCount;
        public long WriteOperationCount;
        public long OtherOperationCount;
        public long ReadTransferCount;
        public long WriteTransferCount;
        public long OtherTransferCount;
    };

    public static IO_COUNTERS GetProcessIoCounters(IntPtr handle)
    {
        bool rv = GetProcessIoCounters(handle, out IO_COUNTERS counters);

        return counters;
    }
}
