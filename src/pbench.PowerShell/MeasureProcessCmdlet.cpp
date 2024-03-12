using namespace System::Management::Automation;

[Cmdlet("Measure", "Process")]
public ref class MeasureProcessCmdlet : PSCmdlet
{
protected:
    virtual void ProcessRecord() override;
};

void MeasureProcessCmdlet::ProcessRecord()
{
    WriteObject("Hello, World!");
}
