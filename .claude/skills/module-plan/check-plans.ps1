<#
Checks the module plans in plans/ against the rules in .claude/skills/module-plan/SKILL.md.

Run: check-plans.ps1
Exit code 1 when there is an error. Warnings do not change the exit code.

Errors
- A future module row in the root README points to a missing plan, or to a plan with another name.
- A module that exists in modules/ is still in the Future modules table.
- A plan of a module that does not exist yet is missing from the Future modules table.
- A plan of an existing module is missing from the Plans column of the module overview, or the Plans cell points to a missing file.
- The title is not "Plans for <ModuleName>".
- A required chapter is missing: The idea, Decisions and open questions (with Decided and Open), Questions before building.
- A table of contents entry points to a heading that does not exist.

Warnings
- A plan mentions a Cat module that is not a module folder, a plan or a known name.
- A plan uses a long dash or an ellipsis outside code.
- A plan has no "What we already know" chapter.
#>
$ErrorActionPreference = 'Stop'
$root = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..')).Path
$errors = New-Object System.Collections.Generic.List[string]
$warnings = New-Object System.Collections.Generic.List[string]

function Get-Slug([string]$heading) {
    $s = $heading.ToLowerInvariant() -replace '[^\p{L}\p{Nd} _-]', ''
    return ($s.Trim() -replace ' ', '-')
}

$readme = [System.IO.File]::ReadAllLines((Join-Path $root 'README.md'))
$moduleFolders = Get-ChildItem (Join-Path $root 'modules') -Directory | ForEach-Object { $_.Name }
$planFiles = Get-ChildItem (Join-Path $root 'plans') -Filter 'Cat.*.md' -File
$planNames = $planFiles | ForEach-Object { $_.BaseName }

# Future modules table
$futureStart = [array]::IndexOf($readme, '## Future modules')
$futureRows = @{}
if ($futureStart -ge 0) {
    for ($i = $futureStart + 1; $i -lt $readme.Count; $i++) {
        if ($readme[$i] -like '## *') { break }
        if ($readme[$i] -match '^\| \[`?(Cat\.[\w.]+)`?\]\(\./plans/([^)]+)\)') {
            $futureRows[$Matches[1]] = $Matches[2]
        } elseif ($readme[$i] -match '^\| `(Cat\.[\w.]+)`') {
            $errors.Add("README Future modules: $($Matches[1]) has no link to a plan.")
        }
    }
}
foreach ($name in $futureRows.Keys) {
    $target = $futureRows[$name]
    if ($target -ne "$name.md") { $errors.Add("README Future modules: $name links to $target. Expected $name.md.") }
    elseif (-not (Test-Path (Join-Path $root "plans\$target"))) { $errors.Add("README Future modules: plans/$target does not exist.") }
    if ($moduleFolders -contains $name) { $errors.Add("README Future modules: $name exists in modules/. Remove it from the Future modules table.") }
}

# Plans column of the module overview
$start = [array]::IndexOf($readme, '<!-- Modules start-->')
$end = [array]::IndexOf($readme, '<!-- Modules end-->')
$planCells = @{}
for ($i = $start + 1; $i -lt $end; $i++) {
    if ($readme[$i] -match '^\| \[(Cat\.[\w.]+)\]\(\./modules/') {
        $name = $Matches[1]
        if ($readme[$i] -match '\[Plans\]\(\./plans/([^)]+)\)') {
            $planCells[$name] = $Matches[1]
        }
    }
}
foreach ($name in $planCells.Keys) {
    if ($planCells[$name] -ne "$name.md") { $errors.Add("README module overview: $name links to $($planCells[$name]). Expected $name.md.") }
    elseif (-not (Test-Path (Join-Path $root "plans\$($planCells[$name])"))) { $errors.Add("README module overview: plans/$($planCells[$name]) does not exist.") }
}

$knownNames = @($moduleFolders) + @($planNames) + @('Cat.Demo', 'Cat.NUnit')

foreach ($file in $planFiles) {
    $name = $file.BaseName
    $lines = [System.IO.File]::ReadAllLines($file.FullName)

    if ($moduleFolders -contains $name) {
        if (-not $planCells.ContainsKey($name)) { $errors.Add("$($file.Name): $name exists, but its row in the module overview has no Plans link.") }
    } elseif (-not $futureRows.ContainsKey($name)) {
        $errors.Add("$($file.Name): $name does not exist yet and is not in the Future modules table of the root README.")
    }

    if ($lines[0] -ne "# Plans for $name") { $errors.Add("$($file.Name): the title must be '# Plans for $name'.") }

    $headings = @($lines | Where-Object { $_ -match '^#{2,4} ' } | ForEach-Object { ($_ -replace '^#+ ', '').Trim() })
    foreach ($required in 'The idea', 'Decisions and open questions', 'Questions before building') {
        if ($headings -notcontains $required) { $errors.Add("$($file.Name): missing chapter '$required'.") }
    }
    foreach ($required in 'Decided', 'Open') {
        if ($headings -notcontains $required) { $errors.Add("$($file.Name): missing '### $required' under Decisions and open questions.") }
    }
    if ($headings -notcontains 'What we already know') { $warnings.Add("$($file.Name): no 'What we already know' chapter.") }

    $slugs = $headings | ForEach-Object { Get-Slug $_ }
    foreach ($line in $lines) {
        if ($line -match '^\s*- \[[^\]]+\]\(#([^)]+)\)\s*$') {
            if ($slugs -notcontains $Matches[1]) { $errors.Add("$($file.Name): table of contents entry #$($Matches[1]) has no heading.") }
        }
    }

    # Text without code, for the style and name checks
    $inFence = $false
    $text = New-Object System.Collections.Generic.List[string]
    foreach ($line in $lines) {
        if ($line.TrimStart().StartsWith('```')) { $inFence = -not $inFence; continue }
        if (-not $inFence) { $text.Add(($line -replace '`[^`]*`', '')) }
    }
    $body = $text -join "`n"
    if ($body -match '—|\.\.\.| -- ') { $warnings.Add("$($file.Name): long dash or ellipsis outside code.") }

    $mentions = [regex]::Matches(($lines -join "`n"), 'Cat\.[A-Za-z][\w.]*') | ForEach-Object { $_.Value.TrimEnd('.') } | Sort-Object -Unique
    foreach ($m in $mentions) {
        $ok = $false
        foreach ($k in $knownNames) { if ($m -eq $k -or $m.StartsWith("$k.")) { $ok = $true; break } }
        if (-not $ok) { $warnings.Add("$($file.Name): mentions $m, which is not a module, a plan or a known name.") }
    }
}

$errors | ForEach-Object { Write-Output "ERROR   $_" }
$warnings | ForEach-Object { Write-Output "WARNING $_" }
Write-Output "$($planFiles.Count) plans checked. $($errors.Count) errors, $($warnings.Count) warnings."
if ($errors.Count -gt 0) { exit 1 }
