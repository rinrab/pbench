using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Text;

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
            using (TimerResolution.SetTimerResolution())
            {
                StringBuilder cmd = new StringBuilder();
                if (ArgumentList != null && ArgumentList.Length > 0)
                {
                    foreach (string arg in ArgumentList)
                    {
                        if (ArgumentList.Length > 0)
                        {
                            cmd.Append(" ");
                        }

                        if (arg.IndexOf(' ') != -1 || arg.Length == 0)
                        {
                            cmd.Append('"');
                            cmd.Append(arg);
                            cmd.Append('"');
                        }
                        else
                        {
                            cmd.Append(arg);
                        }
                    }
                }

                using (process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = FilePath,
                        Arguments = cmd.ToString(),
                        CreateNoWindow = false,
                        UseShellExecute = false,
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
                        KernelTime = new TimeSpan(lpKernelTime),
                        ReadCount = io.ReadOperationCount,
                        ReadBytes = io.ReadTransferCount,
                        WriteCount = io.WriteOperationCount,
                        WriteBytes = io.WriteTransferCount,
                    });
                }
            }
        }

        protected override void StopProcessing()
        {
            // TODO: correct killing
            process.Kill();
        }
    }
}
