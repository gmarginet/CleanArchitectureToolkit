<#
Helps with splitting work into commits. It changes nothing.

Status:  commit-info.ps1 -Mode Status
  Lists every changed or new file, grouped by area. Use it to plan the commits.

Staged:  commit-info.ps1 -Mode Staged
  Looks at what is staged right now. It lists the areas, and warns about files that must not be committed
  and about a commit that mixes areas.
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
    if ($p -match '^templates/') { return 'templates' }
    if ($p -match '^\.claude/skills/([^/]+)/') { return ".claude/skills/$($Matches[1])" }
    if ($p -match '^\.claude/') { return '.claude' }
    if ($p -match '^\.github/') { return '.github' }
    return 'root'
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
            Write-Output "== $($group.Name) ($($group.Count))"
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
    Write-Output "Staged files: $($paths.Count)"
    Write-Output "Areas: $($areas -join ', ')"
    if ($areas.Count -gt 3) { Write-Output 'WARNING this commit touches many areas. Check that it is one logical block.' }
} finally {
    Pop-Location
}
