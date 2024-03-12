#include "MeasureProcessCmdlet.h"
#include "ProcessStats.h"

void MeasureProcessCmdlet::ProcessRecord()
{
    String^ str = gcnew String(filePath);
    for each (String^ arg in argumentList)
    {
        str += " ";
        str += arg;
    }
    WriteVerbose(str);

    ProcessStats^ obj = gcnew ProcessStats();
    obj->RealTime = gcnew TimeSpan(0, 0, 3);
    obj->CpuTime = gcnew TimeSpan(0, 0, 1);
    obj->ReadCount = 123;
    WriteObject(obj);
}
