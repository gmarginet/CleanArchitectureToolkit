<#
Helps with splitting work into commits and with the (skip-pub) rule. It changes nothing.

Status:  commit-info.ps1 -Mode Status
  Lists every changed or new file, grouped by area. Use it to plan the commits.

Staged:  commit-info.ps1 -Mode Staged
  Looks at what is staged right now. It says whether the commit changes code in modules/ or a build file,
  and so whether the subject must end with " (skip-pub)". It also warns about files that must not be committed
  and about a commit that mixes areas.

Code in modules/ is every file under modules/ that is not a markdown file: C# files, project files, json and ddlinks.
Build files count as code too, because they can change the packages: Directory.Build.props, Directory.Build.targets,
Directory.Packages.props, build.cake, global.json, dotnet-tools.json, anything in tools/, and the workflows in .github/workflows.
#>
param(
    [Parameter(Mandatory)][ValidateSet('Status', 'Staged')][string]$Mode
)

$ErrorActionPreference = 'Stop'
$root = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..')).Path
Push-Location $root

function Get-Area([string]$p) {
    $p = $p.Replace('\', '/')
    if ($p -match '^modules/([^/]+)/namespaces/') { return "modules/$($Matches[1]) (generated pages)" }
    if ($p -match '^modules/([^/]+)/') {
        if ($p -like '*.md') { return "modules/$($Matches[1]) (docs)" }
        return "modules/$($Matches[1]) (code)"
    }
    if ($p -like 'modules/*') { return 'modules (shared)' }
    if ($p -match '^tests/([^/]+)/') { return "tests/$($Matches[1])" }
    if ($p -match '^demo/([^/]+)/') { return "demo/$($Matches[1])" }
    if ($p -like 'demo/*') { return 'demo (shared)' }
    if ($p -match '^plans/') { return 'plans' }
    if ($p -match '^resources/') { return 'resources' }
    if ($p -match '^tools/') { return 'tools' }
    if ($p -match '^\.claude/skills/([^/]+)/') { return ".claude/skills/$($Matches[1])" }
    if ($p -match '^\.claude/') { return '.claude' }
    if ($p -match '^\.github/') { return '.github' }
    return 'root'
}

function Test-IsCode([string]$p) {
    $p = $p.Replace('\', '/')
    if ($p -like 'modules/*' -and $p -notlike '*.md') { return $true }
    if ($p -like 'tools/*') { return $true }
    if ($p -like '.github/workflows/*') { return $true }
    if ($p -in 'Directory.Build.props', 'Directory.Build.targets', 'Directory.Packages.props', 'build.cake', 'global.json', 'dotnet-tools.json') { return $true }
    return $false
}

function Test-NeverCommit([string]$p) {
    $p = $p.Replace('\', '/')
    return ($p -match '(^|/)(bin|obj|node_modules|artifacts)/' -or $p -match '\.user$' -or $p -match '(^|/)desktop\.ini$' -or $p -match '(^|/)\.vs/')
}

try {
    if ($Mode -eq 'Status') {
        $items = @()
        foreach ($line in (git status --porcelain=v1 --untracked-files=all)) {
            if ($line.Length -lt 4) { continue }
            $code = $line.Substring(0, 2)
            $path = $line.Substring(3)
            if ($path -like '* -> *') { $path = ($path -split ' -> ')[1] }
            $path = $path.Trim('"')
            $items += [pscustomobject]@{ Status = $code; Path = $path; Area = (Get-Area $path) }
        }
        if ($items.Count -eq 0) { Write-Output 'Nothing to commit.'; return }
        foreach ($group in ($items | Group-Object Area | Sort-Object Name)) {
            $flag = if (($group.Group | Where-Object { Test-IsCode $_.Path }).Count -gt 0) { ' [code or build file]' } else { '' }
            Write-Output "== $($group.Name) ($($group.Count))$flag"
            foreach ($i in $group.Group) { Write-Output ("   {0} {1}" -f $i.Status, $i.Path) }
        }
        $bad = $items | Where-Object { Test-NeverCommit $_.Path }
        foreach ($b in $bad) { Write-Output "WARNING do not commit: $($b.Path)" }
        Write-Output "$($items.Count) files in $(@($items | Select-Object -ExpandProperty Area -Unique).Count) areas."
        return
    }

    # Staged
    $paths = @()
    foreach ($line in (git diff --cached --name-status -M)) {
        $parts = $line -split "`t"
        $paths += $parts[1..($parts.Count - 1)]
    }
    $paths = @($paths | Where-Object { $_ } | Select-Object -Unique)
    if ($paths.Count -eq 0) { Write-Output 'Nothing is staged.'; exit 1 }

    foreach ($p in $paths) { if (Test-NeverCommit $p) { Write-Output "WARNING do not commit: $p" } }

    $areas = @($paths | ForEach-Object { Get-Area $_ } | Select-Object -Unique | Sort-Object)
    $codeFiles = @($paths | Where-Object { Test-IsCode $_ })
    Write-Output "Staged files: $($paths.Count)"
    Write-Output "Areas: $($areas -join ', ')"
    if ($areas.Count -gt 3) { Write-Output 'WARNING this commit touches many areas. Check that it is one logical block.' }
    if ($codeFiles.Count -gt 0) {
        Write-Output "Code or build files changed: $($codeFiles.Count). Do NOT add (skip-pub)."
        $codeFiles | Select-Object -First 5 | ForEach-Object { Write-Output "   $_" }
    } else {
        Write-Output 'No code in modules/ and no build file changed. End the subject line with " (skip-pub)".'
    }
} finally {
    Pop-Location
}
