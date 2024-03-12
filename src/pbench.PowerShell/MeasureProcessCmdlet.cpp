using namespace System;
using namespace System::Management::Automation;

[Cmdlet("Measure", "Process")]
[Alias("pbench")]
public ref class MeasureProcessCmdlet : PSCmdlet
{
public:
    [Parameter(Position = 0, Mandatory = true)]
    property System::String^ FilePath
    {
        System::String^ get() { return filePath; }
        void set(String^ value) { filePath = value; }
    }

    [Parameter(ValueFromRemainingArguments = true)]
    property array<String^>^ ArgumentList
    {
        array<String^>^ get() { return argumentList; }
        void set(array<String^>^ value) { argumentList = value; }
    }

protected:
    virtual void ProcessRecord() override;

private:
    String^ filePath;
    array<String^>^ argumentList;
};

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
