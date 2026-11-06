<#
Generates the entities and the DbContext of the inventory database again.

The database is the source of truth, so nobody edits the generated files. Custom behavior goes in partial classes.
Create the inventory database first and run the scripts of the Database project on it, in order.

Usage: .\Scaffold-InventoryModel.ps1 -ConnectionString "Server=localhost,1433;Database=inventory;User Id=sa;Password=<password>;TrustServerCertificate=True"
#>
param(
    [Parameter(Mandatory)][string]$ConnectionString
)

$ErrorActionPreference = 'Stop'
Set-Location $PSScriptRoot

dotnet ef dbcontext scaffold $ConnectionString Microsoft.EntityFrameworkCore.SqlServer `
    --context InventoryDbContext --context-dir DataAccess --output-dir Entities `
    --namespace Cat.Demo.InventoryService.Infrastructure.Entities `
    --context-namespace Cat.Demo.InventoryService.Infrastructure.DataAccess `
    --no-onconfiguring --force
if ($LASTEXITCODE -ne 0) { throw 'The scaffold failed' }

Write-Host 'The model is up to date.'
