<#
.SYNOPSIS
    Checks that no two modules use the same error code prefix.

.DESCRIPTION
    A CAT error code is APPLICATION-AREA-number, like CAT-VAL-1001. Every module defines its codes in one class,
    and that class holds the prefix in a constant whose name ends with ErrorCodePrefix, like
    private const string ValidatorErrorCodePrefix = "CAT-VAL";
    The script finds those constants in modules/, skips bin, obj and the generated namespaces folders, and fails
    when two different modules use the same prefix. It warns about a prefix that is not CAT-XXX.
    Exit code 1 when two modules share a prefix.

.PARAMETER Root
    The root of the repository. The default is three folders above this script.
#>
param(
    [string]$Root = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..')).Path
)

$ErrorActionPreference = 'Stop'

# Get-Item returns the full path, also when the root was given as a short Windows path.
$Root = (Get-Item -LiteralPath $Root).FullName
$modulesPath = (Get-Item -LiteralPath (Join-Path $Root 'modules')).FullName
$files = Get-ChildItem -Path $modulesPath -Recurse -Filter '*.cs' -File |
    Where-Object { $_.FullName -notmatch '[\\/](bin|obj|namespaces)[\\/]' }

$found = @()
foreach ($file in $files) {
    $module = ($file.FullName.Substring($modulesPath.Length + 1) -split '[\\/]')[0]
    $lineNumber = 0
    foreach ($line in Get-Content -LiteralPath $file.FullName) {
        $lineNumber++
        if ($line -match 'const\s+string\s+\w*ErrorCodePrefix\s*=\s*"([^"]*)"') {
            $found += [pscustomobject]@{
                Prefix = $Matches[1].TrimEnd('-')
                Module = $module
                Where  = '{0}:{1}' -f $file.FullName.Substring($Root.Length + 1), $lineNumber
            }
        }
    }
}

$errors = 0
$warnings = 0

foreach ($group in ($found | Group-Object Prefix | Sort-Object Name)) {
    $modules = @($group.Group | Select-Object -ExpandProperty Module -Unique)
    if ($modules.Count -gt 1) {
        $errors++
        Write-Host ("ERROR   The prefix {0} is used by more than one module: {1}" -f $group.Name, ($modules -join ', '))
        foreach ($item in $group.Group) { Write-Host ("        {0}" -f $item.Where) }
    }
}

foreach ($item in ($found | Sort-Object Prefix)) {
    if ($item.Prefix -notmatch '^CAT-[A-Z]{3}$') {
        $warnings++
        Write-Host ("WARNING {0} uses the prefix {1}. CAT modules use CAT-XXX with a 3 letter area." -f $item.Where, $item.Prefix)
    }
}

Write-Host ''
Write-Host 'Prefixes found:'
$found | Sort-Object Prefix | ForEach-Object { Write-Host ('  {0,-10} {1}' -f $_.Prefix, $_.Module) }
Write-Host ''
Write-Host ("{0} prefixes in modules/. {1} errors, {2} warnings." -f $found.Count, $errors, $warnings)

if ($errors -gt 0) { exit 1 }
