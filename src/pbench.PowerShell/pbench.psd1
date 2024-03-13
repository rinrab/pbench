@{
    # TODO: fill Author, CompanyName, Copyright, and Description, and other fields.
    # Author                 = ""
    # CompanyName            = ""
    # Copyright              = "(c) . All rights reserved."
    ModuleVersion          = "0.8.0"
    PowerShellVersion      = "3.0"
    CLRVersion             = "4.0"
    Description            = ""
    RootModule             = "pbench.PowerShell.dll"
    DotNetFrameworkVersion = "4.7.2"
    CmdletsToExport        = @(
        "Measure-Process"
    )
    AliasesToExport        = @(
        "pbench"
    )
    FunctionsToExport      = @()
    FormatsToProcess       = @()
    FileList               = @()
    PrivateData            = @{
        PSData = @{
            Tags                     = @()
            ReleaseNotes             = ""
            # LicenseUri = ""
            # ProjectUri = ""
            # IconUri = ""
            RequireLicenseAcceptance = $false
            # ExternalModuleDependencies = @()
        }
    }
}
