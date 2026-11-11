<#
Checks the markdown of the repository locally. It sends no web requests.

Run:  check-docs.ps1 [-IncludeGenerated] [-Path <file or folder, relative to the repository root>]
Exit code 1 when there is an error. Warnings do not change the exit code.

Scope
- Every markdown file that git knows, tracked or new, except the generated pages in modules/*/namespaces,
  the Jekyll theme, vendor, artifacts and node_modules. Use -IncludeGenerated to add the generated pages.
- Template files are skipped, because their links are written for the folder where the copy goes. That is every file that ends in `.template.md`.
- CLAUDE.md is skipped for the style warning, because it quotes the forbidden punctuation as examples.

Errors
- A relative link or image points to a file or folder that does not exist, or the case of the path is wrong.
  The published site runs on Linux, where case matters.
- The repo overview table of the readme does not match the repository. Every module folder and every plan has a row. A row that is not built has the New badge and links to its plan. A built row with a plan has the In development badge. A built row without a plan has the Stable badge. The rows are in order: modules, the demo, then tooling, each sorted by name. A Stable row has no priority, and every other row has a unique whole number as priority.
- A link points to an anchor that no heading of the target markdown file has.
- A code fence is not closed.
- A `Header` region that differs from the header template of the `cat-internal-create-header` skill, or has no comment line with its `RootPath`.
- The readme lost its <!-- region start: RepoOverview--> or <!-- region end: RepoOverview--> region marker.
- A skill folder has no SKILL.md, has a name that differs from the folder, or is missing from .claude/skills/README.md.

Warnings
- A long dash, "--" outside code, or an ellipsis in text. CLAUDE.md forbids them.
#>
param(
    [switch]$IncludeGenerated,
    [string]$Path
)

$ErrorActionPreference = 'Stop'
$root = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..')).Path
$errors = New-Object System.Collections.Generic.List[string]
$warnings = New-Object System.Collections.Generic.List[string]

Push-Location $root
try {
    $files = git ls-files --cached --others --exclude-standard -- '*.md' |
        ForEach-Object { $_.Replace('/', '\') } |
        Where-Object { Test-Path (Join-Path $root $_) }
} finally { Pop-Location }

$files = $files | Where-Object {
    $_ -notmatch '^(jekyll-theme|vendor|artifacts)\\' -and $_ -notmatch '(^|\\)node_modules\\' -and $_ -notmatch '\.template\.md$' -and
    ($IncludeGenerated -or $_ -notmatch '^modules\\[^\\]+\\namespaces\\')
}
if ($Path) {
    $prefix = $Path.Replace('/', '\').TrimEnd('\')
    $files = $files | Where-Object { $_ -eq $prefix -or $_.StartsWith("$prefix\") }
}

$dirCache = @{}
function Get-Entries([string]$dir) {
    if (-not $dirCache.ContainsKey($dir)) {
        try { $dirCache[$dir] = @([System.IO.Directory]::GetFileSystemEntries($dir) | ForEach-Object { [System.IO.Path]::GetFileName($_) }) }
        catch { $dirCache[$dir] = @() }
    }
    return $dirCache[$dir]
}

# Returns ok, missing or case. Walks the path from the repository root and compares every part with its exact case.
function Test-ExactPath([string]$full) {
    if (-not $full.StartsWith($root, [System.StringComparison]::OrdinalIgnoreCase)) {
        if (Test-Path -LiteralPath $full) { return 'ok' } else { return 'missing' }
    }
    $relative = $full.Substring($root.Length).Trim('\')
    $current = $root
    if ($relative -eq '') { return 'ok' }
    foreach ($part in $relative.Split('\')) {
        $entries = Get-Entries $current
        if ($entries -ccontains $part) { $current = Join-Path $current $part; continue }
        if ($entries -contains $part) { return 'case' }
        return 'missing'
    }
    return 'ok'
}

function Get-Slug([string]$heading) {
    $h = $heading -replace '<!--.*?-->', ''
    $h = $h -replace '\[([^\]]*)\]\([^)]*\)', '$1'
    $h = $h -replace '`', ''
    $h = $h.Trim() -replace '\s+#+$', ''
    $s = $h.ToLowerInvariant() -replace '[^\p{L}\p{Nd} _-]', ''
    return ($s.Trim() -replace ' ', '-')
}

$anchorCache = @{}
function Get-Anchors([string]$full) {
    $key = $full.ToLowerInvariant()
    if ($anchorCache.ContainsKey($key)) { return $anchorCache[$key] }
    $set = New-Object System.Collections.Generic.HashSet[string]
    $count = @{}
    $inFence = $false
    foreach ($line in [System.IO.File]::ReadAllLines($full)) {
        if ($line.TrimStart().StartsWith('```') -or $line.TrimStart().StartsWith('~~~')) { $inFence = -not $inFence; continue }
        if ($inFence) { continue }
        if ($line -match '^#{1,6}\s+(.+)$') {
            $slug = Get-Slug $Matches[1]
            if ($count.ContainsKey($slug)) { $count[$slug]++; [void]$set.Add("$slug-$($count[$slug])") }
            else { $count[$slug] = 0; [void]$set.Add($slug) }
        }
        foreach ($m in [regex]::Matches($line, '<a\s+(?:name|id)\s*=\s*["'']([^"'']+)["'']')) { [void]$set.Add($m.Groups[1].Value) }
    }
    $anchorCache[$key] = $set
    return $set
}

function Test-Link([string]$file, [int]$lineNumber, [string]$target) {
    $target = $target.Trim().Trim('<', '>')
    if ($target -eq '' -or $target -match '^(https?:|mailto:|tel:|data:|javascript:|//|\{|\$)') { return }
    $anchor = $null
    $hash = $target.IndexOf('#')
    if ($hash -ge 0) { $anchor = $target.Substring($hash + 1); $target = $target.Substring(0, $hash) }
    $query = $target.IndexOf('?')
    if ($query -ge 0) { $target = $target.Substring(0, $query) }

    $fileFull = Join-Path $root $file
    if ($target -eq '') {
        $targetFull = $fileFull
    } else {
        $decoded = [System.Uri]::UnescapeDataString($target).Replace('/', '\')
        $targetFull = [System.IO.Path]::GetFullPath((Join-Path (Split-Path $fileFull -Parent) $decoded)).TrimEnd('\')
        $state = Test-ExactPath $targetFull
        if ($state -eq 'missing') { $errors.Add("${file}:$lineNumber link target not found: $target"); return }
        if ($state -eq 'case') { $errors.Add("${file}:$lineNumber link target has the wrong letter case: $target"); return }
    }
    if ($anchor -and $anchor -ne '' -and $targetFull -like '*.md' -and (Test-Path -LiteralPath $targetFull -PathType Leaf)) {
        $decodedAnchor = [System.Uri]::UnescapeDataString($anchor)
        if (-not (Get-Anchors $targetFull).Contains($decodedAnchor)) {
            $errors.Add("${file}:$lineNumber anchor #$anchor not found in $(Split-Path $targetFull -Leaf)")
        }
    }
}

foreach ($file in $files) {
    $lines = [System.IO.File]::ReadAllLines((Join-Path $root $file))
    $inFence = $false
    $fenceStart = 0
    $inComment = $false
    for ($i = 0; $i -lt $lines.Count; $i++) {
        $raw = $lines[$i]
        $n = $i + 1
        $trim = $raw.TrimStart()
        if ($trim.StartsWith('```') -or $trim.StartsWith('~~~')) {
            $inFence = -not $inFence
            if ($inFence) { $fenceStart = $n }
            continue
        }
        if ($inFence) { continue }

        $line = $raw
        if ($inComment) {
            if ($line -match '-->') { $inComment = $false; $line = $line -replace '^.*?-->', '' } else { continue }
        }
        $line = $line -replace '<!--.*?-->', ''
        if ($line -match '<!--') { $inComment = $true; $line = $line -replace '<!--.*$', '' }

        $text = $line -replace '`[^`]*`', ''

        if ($file -ne '.claude\CLAUDE.md' -and ($text -match '—' -or $text -match '(^|\s)--(\s|$)' -or $text -match '\.\.\.')) {
            $warnings.Add("${file}:$n long dash or ellipsis")
        }

        # The target may hold balanced parentheses, like the method signatures in the generated pages. The title may use " or '.
        foreach ($m in [regex]::Matches($text, '!?\[(?:\\.|[^\]\\])*\]\(((?:[^()\s]|\([^()]*\))+)(?:\s+(?:"[^"]*"|''[^'']*''))?\)')) { Test-Link $file $n $m.Groups[1].Value }
        foreach ($m in [regex]::Matches($text, '(?:src|href)\s*=\s*["'']([^"'']+)["'']')) { Test-Link $file $n $m.Groups[1].Value }
        if ($text -match '^\s{0,3}\[[^\]]+\]:\s*(\S+)') { Test-Link $file $n $Matches[1] }
    }
    if ($inFence) { $errors.Add("${file}:$fenceStart code fence is not closed") }
}

# Header regions copied from the header template
$headerTemplateFile = Join-Path $root '.claude\skills\cat-internal-create-header\header.template.md'
if (Test-Path $headerTemplateFile) {
    $headerTemplate = ([System.IO.File]::ReadAllText($headerTemplateFile) -replace "`r`n", "`n")
    $headerTemplate = [regex]::Match($headerTemplate, '(?s)<!-- region start: Header-->\n.*?<!-- region end: Header-->').Value
    foreach ($file in $files) {
        $content = [System.IO.File]::ReadAllText((Join-Path $root $file)) -replace "`r`n", "`n"
        $region = [regex]::Match($content, '(?s)<!-- region start: Header-->\n.*?<!-- region end: Header-->')
        if (-not $region.Success) { continue }
        $comment = [regex]::Match($region.Value, '<!-- Header template: @\.claude\\skills\\cat-internal-create-header\\header\.template\.md, RootPath: (\S+) -->')
        if (-not $comment.Success) { $errors.Add("${file}: the Header region has no 'Header template' comment line with a RootPath"); continue }
        if ($region.Value -cne $headerTemplate.Replace('[[RootPath]]', $comment.Groups[1].Value)) {
            $errors.Add("${file}: the Header region differs from .claude\skills\cat-internal-create-header\header.template.md")
        }
    }
}

# Region markers of the repo overview in the readme
$readmeFile = Join-Path $root 'README.md'
if (Test-Path $readmeFile) {
    $content = [System.IO.File]::ReadAllText($readmeFile)
    foreach ($marker in '<!-- region start: RepoOverview-->', '<!-- region end: RepoOverview-->') {
        $count = ([regex]::Matches($content, [regex]::Escape($marker))).Count
        if ($count -ne 1) { $errors.Add("README.md: the marker $marker must appear once. Found $count.") }
    }
}

# The repo overview table: one row per module folder and per plan, with the right badge, link and order
$plansRoot = Join-Path $root 'plans'
if ((Test-Path $readmeFile) -and (Test-Path $plansRoot)) {
    $readme = [System.IO.File]::ReadAllLines($readmeFile)
    $moduleFolders = @(Get-ChildItem (Join-Path $root 'modules') -Directory | Where-Object { Test-Path (Join-Path $_.FullName 'README.md') } | ForEach-Object { $_.Name })
    $planFiles = @(Get-ChildItem $plansRoot -Filter '*.md' -File | ForEach-Object { $_.Name })
    $planOf = @{ 'Cat.Demo' = 'Demo.md'; 'Cat.Skills' = 'Skills.md' }
    $start = [array]::IndexOf($readme, '<!-- region start: RepoOverview-->')
    $end = [array]::IndexOf($readme, '<!-- region end: RepoOverview-->')
    $rows = [System.Collections.Generic.List[object]]::new()
    if ($start -ge 0 -and $end -gt $start) {
        for ($i = $start + 1; $i -lt $end; $i++) {
            if ($readme[$i] -match '^\| \[(Cat\.[\w.]+)\]\(([^)]+)\) \| (\w+) \| (.*?) \| (\d*) \| ') {
                $rows.Add([pscustomobject]@{ Name = $Matches[1]; Link = $Matches[2]; Type = $Matches[3]; Badge = $Matches[4]; Priority = $Matches[5] })
            }
        }
    }
    $seen = @{}
    foreach ($row in $rows) {
        $name = $row.Name
        if ($seen.ContainsKey($name)) { $errors.Add("README.md repo overview: $name has more than one row."); continue }
        $seen[$name] = $true
        if ($row.Type -notin 'Module', 'Demo', 'Tooling') { $errors.Add("README.md repo overview: $name has the type $($row.Type). Use Module, Demo or Tooling."); continue }
        $plan = if ($planOf.ContainsKey($name)) { $planOf[$name] } else { "$name.md" }
        $hasPlan = $planFiles -contains $plan
        $built = switch ($row.Type) { 'Module' { $moduleFolders -contains $name } 'Demo' { $true } default { $row.Badge -notlike '*status-new*' } }
        if ($row.Type -eq 'Module' -and -not $built -and $row.Link -like './modules/*') { $errors.Add("README.md repo overview: $name has no folder in modules/.") }
        if (-not $built) {
            if (-not $hasPlan) { $errors.Add("README.md repo overview: $name is not built and has no plan plans\$plan.") }
            if ($row.Badge -notlike "*status-new*](./plans/$plan)*") { $errors.Add("README.md repo overview: $name is not built. Its badge must be New and link to ./plans/$plan.") }
            if ($row.Link -ne "./plans/$plan") { $errors.Add("README.md repo overview: $name is not built. Its name must link to ./plans/$plan.") }
        } elseif ($hasPlan) {
            if ($row.Badge -notlike "*status-in%20development*](./plans/$plan)*") { $errors.Add("README.md repo overview: $name has a plan. Its badge must be In development and link to ./plans/$plan.") }
        } else {
            if ($row.Badge -notlike "*status-stable*]($($row.Link))*") { $errors.Add("README.md repo overview: $name has no plan. Its badge must be Stable and link to $($row.Link).") }
        }
        if ($row.Type -eq 'Module' -and $built -and $row.Link -ne "./modules/$name/README.md") { $errors.Add("README.md repo overview: $name is built. Its name must link to ./modules/$name/README.md.") }
    }
    $priorities = @{}
    foreach ($row in $rows) {
        if ($row.Badge -like '*status-stable*') {
            if ($row.Priority -ne '') { $errors.Add("README.md repo overview: $($row.Name) is Stable. Its priority must be empty.") }
        } elseif ($row.Priority -eq '' -or [int]$row.Priority -lt 1) {
            $errors.Add("README.md repo overview: $($row.Name) is not Stable. It needs a priority, a whole number from 1.")
        } elseif ($priorities.ContainsKey($row.Priority)) {
            $errors.Add("README.md repo overview: the priority $($row.Priority) is used by $($priorities[$row.Priority]) and $($row.Name). Priorities are unique.")
        } else {
            $priorities[$row.Priority] = $row.Name
        }
    }
    foreach ($name in $moduleFolders) {
        if (-not $seen.ContainsKey($name)) { $errors.Add("README.md repo overview: the module $name has no row.") }
    }
    foreach ($plan in $planFiles) {
        $name = if ($plan -eq 'Demo.md') { 'Cat.Demo' } elseif ($plan -eq 'Skills.md') { 'Cat.Skills' } else { [System.IO.Path]::GetFileNameWithoutExtension($plan) }
        if (-not $seen.ContainsKey($name)) { $errors.Add("plans\${plan}: $name has no row in the repo overview of the readme.") }
    }
    $rank = @{ 'Module' = 0; 'Demo' = 1; 'Tooling' = 2 }
    $ordered = @($rows | Where-Object { $rank.ContainsKey($_.Type) } | Sort-Object @{ Expression = { $rank[$_.Type] } }, @{ Expression = { $_.Name } })
    for ($i = 0; $i -lt $ordered.Count; $i++) {
        if ($ordered[$i].Name -ne $rows[$i].Name) { $errors.Add("README.md repo overview: the rows are not in order. Expected modules, then the demo, then tooling, each sorted by name. First difference: $($rows[$i].Name), expected $($ordered[$i].Name)."); break }
    }
}
# Skills and the skills overview
$skillsRoot = Join-Path $root '.claude\skills'
$skillsReadme = Join-Path $skillsRoot 'README.md'
if ((Test-Path $skillsRoot) -and (Test-Path $skillsReadme)) {
    $overview = [System.IO.File]::ReadAllText($skillsReadme)
    foreach ($dir in Get-ChildItem $skillsRoot -Directory) {
        $skillFile = Join-Path $dir.FullName 'SKILL.md'
        if (-not (Test-Path $skillFile)) { $errors.Add(".claude\skills\$($dir.Name): no SKILL.md"); continue }
        $head = [System.IO.File]::ReadAllText($skillFile)
        if ($head -match '(?m)^name:\s*(\S+)\s*$') {
            if ($Matches[1] -ne $dir.Name) { $errors.Add(".claude\skills\$($dir.Name)\SKILL.md: name '$($Matches[1])' differs from the folder name") }
        } else {
            $errors.Add(".claude\skills\$($dir.Name)\SKILL.md: no name in the front matter")
        }
        if ($overview -notmatch [regex]::Escape("]($($dir.Name)/SKILL.md)")) { $errors.Add(".claude\skills\README.md: no table row for $($dir.Name)") }
        if ($overview -notmatch "(?m)^### $([regex]::Escape($dir.Name))\s*$") { $errors.Add(".claude\skills\README.md: no '### $($dir.Name)' entry") }
    }
}

$errors | ForEach-Object { Write-Output "ERROR   $_" }
$warnings | ForEach-Object { Write-Output "WARNING $_" }
Write-Output "$(@($files).Count) markdown files checked. $($errors.Count) errors, $($warnings.Count) warnings."
if ($errors.Count -gt 0) { exit 1 }
