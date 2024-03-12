#include "MeasureProcessCmdlet.h"

void MeasureProcessCmdlet::ProcessRecord()
{
    String^ str = gcnew String(filePath);
    for each (String^ arg in argumentList)
    {
        str += " ";
        str += arg;
    }
    WriteObject(str);
}
