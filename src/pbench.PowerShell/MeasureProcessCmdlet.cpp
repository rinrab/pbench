#include "ProcessStats.h"

using namespace System;
using namespace System::Management::Automation;

[Cmdlet("Measure", "Process")]
[Alias("pbench")]
[OutputType(ProcessStats::typeid)]
public ref class MeasureProcessCmdlet : PSCmdlet
{
public:
    [Parameter(Position = 0, Mandatory = true)]
        property System::String^ FilePath
    {
        System::String^ get() { return filePath; }
        void set(String^ value) { filePath = value; }
    }

    [Parameter(ValueFromRemainingArguments = true, Mandatory = false)]
        property array<String^>^ ArgumentList
    {
        array<String^>^ get() { return argumentList; }
        void set(array<String^>^ value) { argumentList = value; }
    }

protected:
    void ProcessRecord() override
    {
        String^ str = gcnew String(filePath);
        for each (String ^ arg in argumentList)
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

private:
    String^ filePath;
    array<String^>^ argumentList;
};
