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
- A module plan (plans/Cat.*.md) has no place in the root README, or a row links to the wrong plan. A module that exists has a Plans link in the module overview. A module that does not exist yet has a row in the Future modules table, and a module is never in both.
- A link points to an anchor that no heading of the target markdown file has.
- A code fence is not closed.
- A `Header` region that differs from the header template of the `cat-internal-create-header` skill, or has no comment line with its `RootPath`.
- The root README lost its <!-- Modules start--> or <!-- Modules end--> marker.
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

# Markers in the root README
$rootReadme = Join-Path $root 'README.md'
if (Test-Path $rootReadme) {
    $content = [System.IO.File]::ReadAllText($rootReadme)
    foreach ($marker in '<!-- Modules start-->', '<!-- Modules end-->') {
        $count = ([regex]::Matches($content, [regex]::Escape($marker))).Count
        if ($count -ne 1) { $errors.Add("README.md: the marker $marker must appear once. Found $count.") }
    }
}

# Plans and the tables of the root README
$plansRoot = Join-Path $root 'plans'
if ((Test-Path $rootReadme) -and (Test-Path $plansRoot)) {
    $readme = [System.IO.File]::ReadAllLines($rootReadme)
    $moduleFolders = @(Get-ChildItem (Join-Path $root 'modules') -Directory | ForEach-Object { $_.Name })
    $planNames = @(Get-ChildItem $plansRoot -Filter 'Cat.*.md' -File | ForEach-Object { $_.BaseName })

    # Future modules table: [Cat.X](./plans/Cat.X.md), no backticks, and no module folder yet
    $futureRows = @{}
    $futureStart = [array]::IndexOf($readme, '## Future modules')
    if ($futureStart -ge 0) {
        for ($i = $futureStart + 1; $i -lt $readme.Count; $i++) {
            if ($readme[$i] -like '## *') { break }
            if ($readme[$i] -match '^\| \[`?(Cat\.[\w.]+)`?\]\(\./plans/([^)]+)\)') {
                $futureRows[$Matches[1]] = $Matches[2]
            } elseif ($readme[$i] -match '^\| `(Cat\.[\w.]+)`') {
                $errors.Add("README.md Future modules: $($Matches[1]) has no link to a plan.")
            }
        }
    }
    foreach ($name in $futureRows.Keys) {
        if ($futureRows[$name] -ne "$name.md") { $errors.Add("README.md Future modules: $name links to $($futureRows[$name]). Expected $name.md.") }
        if ($moduleFolders -contains $name) { $errors.Add("README.md Future modules: $name exists in modules/. Remove it from the Future modules table.") }
    }

    # Plans column of the module overview: [Plans](./plans/Cat.X.md)
    $planCells = @{}
    $start = [array]::IndexOf($readme, '<!-- Modules start-->')
    $end = [array]::IndexOf($readme, '<!-- Modules end-->')
    if ($start -ge 0 -and $end -gt $start) {
        for ($i = $start + 1; $i -lt $end; $i++) {
            if ($readme[$i] -match '^\| \[(Cat\.[\w.]+)\]\(\./modules/' -and $readme[$i] -match '\[Plans\]\(\./plans/([^)]+)\)') {
                $planCells[[regex]::Match($readme[$i], '^\| \[(Cat\.[\w.]+)\]').Groups[1].Value] = $Matches[1]
            }
        }
    }
    foreach ($name in $planCells.Keys) {
        if ($planCells[$name] -ne "$name.md") { $errors.Add("README.md module overview: $name links to $($planCells[$name]). Expected $name.md.") }
    }

    # Every module plan has exactly one place in the README
    foreach ($name in $planNames) {
        if ($moduleFolders -contains $name) {
            if (-not $planCells.ContainsKey($name)) { $errors.Add("plans\${name}.md: $name exists, but its row in the module overview has no Plans link.") }
        } elseif (-not $futureRows.ContainsKey($name)) {
            $errors.Add("plans\${name}.md: $name does not exist yet and is not in the Future modules table of the root README.md.")
        }
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
