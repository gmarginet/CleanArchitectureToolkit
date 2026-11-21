<#
Refreshes the saved OpenAPI document of the payment provider and generates the client again.

The payment provider is an outside system, so Orders keeps its own copy of the OpenAPI document and generates its own client.
Start the AppHost first. The stand-in of the provider only publishes its OpenAPI document in Development, which is what the
AppHost runs. Commit the changed document and the changed client together.

Usage: .\Refresh-PaymentProviderClient.ps1 [-ServiceUrl <address of the document>]
#>
param(
    [string]$ServiceUrl = 'http://localhost:5103/openapi/v1.json'
)

$ErrorActionPreference = 'Stop'
Set-Location $PSScriptRoot

Write-Host "Downloading $ServiceUrl"
Invoke-WebRequest -Uri $ServiceUrl -OutFile 'payment-provider.openapi.json' -UseBasicParsing

# NSwag is a local tool of the repository, see dotnet-tools.json in the root.
dotnet tool restore
if ($LASTEXITCODE -ne 0) { throw 'dotnet tool restore failed' }

dotnet nswag run nswag.json
if ($LASTEXITCODE -ne 0) { throw 'NSwag failed' }

Write-Host 'The document and the generated client are up to date.'
