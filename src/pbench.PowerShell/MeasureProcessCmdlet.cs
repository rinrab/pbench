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

            WriteObject(new ProcessStats
            {
                TotalTime = process.ExitTime - process.StartTime,
                CpuTime = process.TotalProcessorTime,
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
