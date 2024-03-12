using System;
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

        protected override void ProcessRecord()
        {
            WriteObject(new ProcessStats
            {
                CpuTime = new TimeSpan(0, 0, 0, 0, 320),
                TotalTime = new TimeSpan(0, 0, 0, 0, 500),
            });
        }
    }
}
