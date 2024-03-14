using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace pbench.PowerShell
{
    public static class TimerResolution
    {
        public static IDisposable SetTimerResolution()
        {
            uint currentRes = 0;
            if (NtSetTimerResolution(5000, true, ref currentRes))
            {
                throw new Win32Exception();
            }
            else
            {
                return new TimerResolutionReleaser();
            }
        }

        private class TimerResolutionReleaser : IDisposable
        {
            public void Dispose()
            {
                uint currentRes = 0;
                if (NtSetTimerResolution(5000, true, ref currentRes))
                {
                    throw new Win32Exception();
                }
            }
        }

        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern bool NtSetTimerResolution(uint reqRes, bool acquire, ref uint pNewRes);
    }
}
