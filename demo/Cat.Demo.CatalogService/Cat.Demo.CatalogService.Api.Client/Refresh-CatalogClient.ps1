<#
Refreshes the saved OpenAPI document of the Catalog service and generates the client again.

Start the AppHost first. The Catalog service only publishes its OpenAPI document in Development, which is what the
AppHost runs. Commit the changed document and the changed client together.

Usage: .\Refresh-CatalogClient.ps1 [-ServiceUrl <address of the document>]
#>
param(
    [string]$ServiceUrl = 'http://localhost:5101/openapi/v1.json'
)

$ErrorActionPreference = 'Stop'
Set-Location $PSScriptRoot

Write-Host "Downloading $ServiceUrl"
Invoke-WebRequest -Uri $ServiceUrl -OutFile 'catalog.openapi.json' -UseBasicParsing

# NSwag is a local tool of the repository, see dotnet-tools.json in the root.
dotnet tool restore
if ($LASTEXITCODE -ne 0) { throw 'dotnet tool restore failed' }

dotnet nswag run nswag.json
if ($LASTEXITCODE -ne 0) { throw 'NSwag failed' }

Write-Host 'The document and the generated client are up to date.'
