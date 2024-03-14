using System;
using System.Diagnostics;
using System.Management.Automation;

namespace pbench.PowerShell
{
    [Cmdlet("Measure", "Process")]
    [Alias("pbench")]
    [OutputType(typeof(ProcessStats))]
    public class MeasureProcessCmdlet : PSCmdlet
    {
        [Parameter(Position = 0, Mandatory = true)]
        public string FilePath { get; set; }

        [Parameter(ValueFromRemainingArguments = true)]
        public string[] ArgumentList { get; set; }

        private Process process;

        protected override void ProcessRecord()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = FilePath,
                CreateNoWindow = true,
            };

            process = new Process()
            {
                StartInfo = startInfo,
            };

            process.Start();
            process.WaitForExit();
            process.Refresh();

            var io = PInvoke.GetProcessIoCounters(process.Handle);

            PInvoke.GetProcessTimes(process.Handle, out var lpCreationTime, out var lpExitTime, out var lpKernelTime, out var lpUserTime);

            WriteObject(new ProcessStats
            {
                TotalTime = new TimeSpan(lpExitTime - lpCreationTime),
                CpuTime = new TimeSpan(lpKernelTime + lpUserTime),
                UserTime = new TimeSpan(lpUserTime),
                ReadCount = io.ReadOperationCount,
                ReadBytes = io.ReadTransferCount,
                WriteCount = io.WriteOperationCount,
                WriteBytes = io.WriteTransferCount,
            });
        }

        protected override void StopProcessing()
        {
            // TODO: correct killing
            process.Kill();
        }
    }
}
