# Runs a Cake target, writes the full output to a log file and prints only what matters:
# the build errors, the number of warnings, the test totals and the failing tests.
# Exit code: the exit code of Cake.
param(
    [Parameter(Mandatory = $true)][string]$Target,
    [string]$Configuration,
    [Parameter(Mandatory = $true)][string]$LogDir
)

$name = if ($Configuration) { "cake-$Target-$Configuration.log" } else { "cake-$Target.log" }
$log = Join-Path $LogDir $name
$cakeArgs = @('cake', "--target=$Target")
if ($Configuration) { $cakeArgs += "--configuration=$Configuration" }

$ErrorActionPreference = 'Continue'
& dotnet @cakeArgs 2>&1 | ForEach-Object { "$_" } | Out-File -FilePath $log -Encoding utf8
$exitCode = $LASTEXITCODE
$lines = Get-Content $log

$errors = @($lines | Where-Object { $_ -match ': error [A-Z]*\d+' } | ForEach-Object { $_.Trim() } | Sort-Object -Unique)
$warnings = @($lines | Where-Object { $_ -match ': warning [A-Z]*\d+' } | ForEach-Object { $_.Trim() } | Sort-Object -Unique)
$cakeErrors = @($lines | Where-Object { $_ -match '^(Error|An error occurred)' })
$totals = @($lines | Where-Object { $_ -match '^\s*(Passed|Failed|Skipped)!\s+-' } | ForEach-Object { $_.Trim() })

Write-Output "Target $Target, exit code $exitCode. Full log: $log"
Write-Output "Build errors: $($errors.Count). Build warnings: $($warnings.Count)."
$errors | Select-Object -First 30 | ForEach-Object { Write-Output "  $_" }
if ($errors.Count -gt 30) { Write-Output "  ($($errors.Count - 30) more errors in the log)" }
$cakeErrors | ForEach-Object { Write-Output "Cake: $_" }

if ($totals.Count -gt 0) {
    $failed = 0; $passed = 0; $skipped = 0
    foreach ($t in $totals) {
        if ($t -match 'Failed:\s*(\d+)') { $failed += [int]$Matches[1] }
        if ($t -match 'Passed:\s*(\d+)') { $passed += [int]$Matches[1] }
        if ($t -match 'Skipped:\s*(\d+)') { $skipped += [int]$Matches[1] }
    }
    Write-Output "Tests: $passed passed, $failed failed, $skipped skipped, in $($totals.Count) test projects."
    if ($failed -gt 0) {
        Select-String -Path $log -Pattern '^\s+Failed \S' -Context 0, 4 | Select-Object -First 20 | ForEach-Object {
            Write-Output "  $($_.Line.Trim())"
            $_.Context.PostContext | ForEach-Object { Write-Output "    $($_.Trim())" }
        }
    }
}

exit $exitCode
