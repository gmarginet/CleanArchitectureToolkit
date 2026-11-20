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
- The repo overview table of the readme does not match the repository. Every module folder and every plan has a row. A row that is not built has the New badge and links to its plan. A built row with a plan has the Building badge, or the Growing badge when the plan says `**First stable version:** reached`. A built row without a plan has the Stable badge. Every plan has that line, and a plan that is not built says `not reached`. The rows are in order: modules, the demo, then tooling, each sorted by name. A Stable row has an empty Phases cell. Every other row has one line `[A (B): C](./plans/File.md#phase-A)` for each phase of its plan, ordered by C. A is the phase number, B is the number of open questions of the phase, and C is its priority, a whole number that is unique in the table.
- A link in the `Needs` chapter of a plan points to another plan without a phase anchor such as `#phase-1`.
- A link points to an anchor that no heading of the target markdown file has.
- A code fence is not closed.
- A Markdown table starts on the line right below a heading or a line of text, with no empty line between them. The published site shows it as plain text.
- A Markdown table touches an HTML comment, on the line right above or right below it. The published site does not render such a table. Template files are skipped, so the row templates in `*.parts.template.md` are fine.
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
    $prevKind = 'other'
    for ($i = 0; $i -lt $lines.Count; $i++) {
        $raw = $lines[$i]
        $n = $i + 1
        $trim = $raw.TrimStart()
        if ($trim.StartsWith('```') -or $trim.StartsWith('~~~')) {
            $inFence = -not $inFence
            if ($inFence) { $fenceStart = $n }
            $prevKind = 'other'
            continue
        }
        if ($inFence) { continue }

        # A Markdown table that touches an HTML comment is not rendered on the published site. Keep an empty line between them.
        # Any line with a comment marker counts: a one-line comment, the start or the end of a multi-line comment,
        # and a comment on the same line as text. The lines inside a multi-line comment are skipped.
        if ($inComment -and $raw -notmatch '-->') {
            $prevKind = 'other'
        } else {
            $kind = if ($raw.Trim().StartsWith('|')) { 'table' } elseif ($raw -match '<!--|-->') { 'comment' } elseif ($raw.Trim() -eq '') { 'blank' } else { 'text' }
            # A table needs an empty line above it. Directly under a heading or a paragraph the published site shows plain text.
            if ($prevKind -eq 'text' -and $kind -eq 'table') { $errors.Add("${file}:$n a table starts right below a line of text. Put an empty line between them.") }
            if ($prevKind -eq 'comment' -and $kind -eq 'table') { $errors.Add("${file}:$($n - 1) an HTML comment is directly above a table. Put an empty line between them.") }
            if ($prevKind -eq 'table' -and $kind -eq 'comment') { $errors.Add("${file}:$n an HTML comment is directly below a table. Put an empty line between them.") }
            $prevKind = $kind
        }

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

# Every plan keeps the no toc line in its Phases region. It stops editor plugins from generating a full table of contents.
if (-not $Path -or $Path -like '*plans*') {
    foreach ($planFile in Get-ChildItem -LiteralPath (Join-Path $root 'plans') -Filter '*.md' -File) {
        if (-not (Select-String -LiteralPath $planFile.FullName -Pattern '^<!-- no toc -->' -Quiet)) {
            $errors.Add("plans\$($planFile.Name): the Phases region has lost the line <!-- no toc -->. Copy it back from plan.template.md.")
        }
        if (Select-String -LiteralPath $planFile.FullName -Pattern '^<!-- region (start|end): StatusBadge-->' -Quiet) {
            $errors.Add("plans\$($planFile.Name): the StatusBadge region is gone from the plan template. Remove the region and the badge.")
        }
        # A need that links to a plan names the phase, such as Cat.Resilience.md#phase-1, also when the plan has one phase.
        $inNeeds = $false
        $needLine = 0
        foreach ($text in [System.IO.File]::ReadAllLines($planFile.FullName)) {
            $needLine++
            if ($text -match '^#### Needs\s*$') { $inNeeds = $true; continue }
            if ($inNeeds -and ($text -match '^#### ' -or $text -match '^<!-- region end: ')) { $inNeeds = $false }
            if (-not $inNeeds) { continue }
            foreach ($m in [regex]::Matches($text, '\]\(((?:Cat\.[\w.]+|Demo|Skills)\.md)(#[^)]*)?\)')) {
                if ($m.Groups[2].Value -notmatch '^#phase-\d+$') {
                    $errors.Add("plans\$($planFile.Name) line ${needLine}: a need links to $($m.Groups[1].Value) without a phase. Link to the phase, such as $($m.Groups[1].Value)#phase-1.")
                }
            }
        }
    }
}

# Returns the phases of a plan with their number of open questions.
# A question or a sub question is open when it has no answer and no sub question below it.
function Get-PlanPhases([string]$file) {
    $questions = @{}
    $answers = @{}
    $order = [System.Collections.Generic.List[string]]::new()
    $current = $null
    foreach ($line in [System.IO.File]::ReadAllLines($file)) {
        if ($line -match '^<!-- region start: Phase (\d+)-->$') {
            $current = $Matches[1]
            $order.Add($current)
            $questions[$current] = [System.Collections.Generic.List[string]]::new()
            $answers[$current] = [System.Collections.Generic.List[string]]::new()
            continue
        }
        if ($line -match '^<!-- region end: Phase (\d+)-->$') { $current = $null; continue }
        if ($null -eq $current) { continue }
        if ($line -match '^#{4,5} Question (\d+(?:\.\d+)*)\s*$') { $questions[$current].Add($Matches[1]) }
        elseif ($line -match '^##### Answer (\d+(?:\.\d+)*)\s*$') { $answers[$current].Add($Matches[1]) }
    }
    $result = [ordered]@{}
    foreach ($phase in $order) {
        $open = 0
        foreach ($question in $questions[$phase]) {
            $hasSub = $false
            foreach ($other in $questions[$phase]) {
                if ($other.StartsWith("$question.")) { $hasSub = $true; break }
            }
            if (-not $hasSub -and -not $answers[$phase].Contains($question)) { $open++ }
        }
        $result[$phase] = $open
    }
    return $result
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
            # A row is: name | type badge, status badge, line break, description | phases
            if ($readme[$i] -match '^\| (Cat\.[\w.]+) \| <a id="([^"]+)"></a>\[!\[(\w+)\]\([^)]*\)\]\(([^)]*)\) (\[!\[[^\]]*\]\([^)]*\)\]\(([^)]*)\))(?: \[!\[Readme\]\([^)]*\)\]\(([^)]*)\))?<br>(.+?)(?: \[Read more\]\(([^)]*)\))? \| (.*) \| (.*) \| (.*) \|$') {
                $row = [pscustomobject]@{ Name = $Matches[1]; Anchor = $Matches[2]; Type = $Matches[3]; TypeLink = $Matches[4]; Badge = $Matches[5]; BadgeLink = $Matches[6]; ReadmeLink = $Matches[7]; MoreLink = $Matches[9]; Phases = '' }
                # The three columns after the description hold the priority, the phase with its link and the open questions. Join them to one line for each phase: [A (B): C](link)
                $priorityCells = @(if ($Matches[10].Trim() -ne '') { $Matches[10].Trim() -split '<br>' })
                $phaseCells = @(if ($Matches[11].Trim() -ne '') { $Matches[11].Trim() -split '<br>' })
                $openCells = @(if ($Matches[12].Trim() -ne '') { $Matches[12].Trim() -split '<br>' })
                if ($priorityCells.Count -ne $phaseCells.Count -or $phaseCells.Count -ne $openCells.Count) {
                    $errors.Add("README.md repo overview line $($i + 1): $($row.Name) has a different number of lines in the priority, phase and open questions columns.")
                } else {
                    $joined = for ($k = 0; $k -lt $phaseCells.Count; $k++) {
                        if ($phaseCells[$k] -match '^\[(\d+)\]\((.+)\)$') { "[$($Matches[1]) ($($openCells[$k])): $($priorityCells[$k])]($($Matches[2]))" } else { "$($phaseCells[$k])" }
                    }
                    $row.Phases = @($joined) -join '<br>'
                }
                $rows.Add($row)
            } elseif ($readme[$i] -match '^\| (<a id=|\[?Cat\.)') {
                $errors.Add("README.md repo overview line $($i + 1): the row does not match name | anchor, type badge, status badge, <br>, description | priority | phase | open questions.")
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
        $built = switch ($row.Type) { 'Module' { $moduleFolders -contains $name } 'Demo' { $true } default { $row.Badge -notlike '*badge/status-New-*' } }
        # The name is plain text with an anchor. The type badge links to that anchor, so a click keeps the reader in place.
        $anchor = $name.ToLower().Replace('.', '-')
        if ($row.Anchor -ne $anchor) { $errors.Add("README.md repo overview: $name has the anchor $($row.Anchor). It must be $anchor.") }
        if ($row.TypeLink -ne "#$anchor") { $errors.Add("README.md repo overview: $name has a type badge that links to $($row.TypeLink). It must link to #$anchor.") }
        # The Readme badge and the Read more link exist only for a built item, and both link to its readme.
        $readmePath = switch ($row.Type) { 'Module' { "./modules/$name/README.md" } 'Demo' { './demo/README.md' } default { $row.ReadmeLink } }
        if ($built) {
            if (-not $readmePath -or $row.ReadmeLink -ne $readmePath) { $errors.Add("README.md repo overview: $name is built. It needs a Readme badge after the status badge that links to its readme, $readmePath.") }
            if (-not $readmePath -or $row.MoreLink -ne $readmePath) { $errors.Add("README.md repo overview: $name is built. Its description must end with a Read more link to its readme, $readmePath.") }
        } else {
            if ($row.ReadmeLink -or $row.MoreLink) { $errors.Add("README.md repo overview: $name is not built. It has no readme, so it gets no Readme badge and no Read more link.") }
        }
        # The plan says whether the first stable version is reached, in the line "**First stable version:** reached" or "not reached".
        $firstStable = $null
        if ($hasPlan) {
            $planText = [System.IO.File]::ReadAllText((Join-Path $plansRoot $plan))
            if ($planText -match '(?m)^\*\*First stable version:\*\* (reached|not reached)\s*$') {
                $firstStable = $Matches[1]
            } else {
                $errors.Add("plans\${plan}: the line '**First stable version:** reached' or '**First stable version:** not reached' is missing. It belongs in the FirstStableVersion region.")
            }
            if ($firstStable -eq 'reached' -and -not $built) { $errors.Add("plans\${plan}: $name is not built, so the first stable version cannot be reached.") }
        }
        if (-not $built) {
            if (-not $hasPlan) { $errors.Add("README.md repo overview: $name is not built and has no plan plans\$plan.") }
            if ($row.Badge -notlike "*badge/status-New-*](#$anchor)*") { $errors.Add("README.md repo overview: $name is not built. Its badge must be New and link to #$anchor.") }
        } elseif ($hasPlan) {
            $word = if ($firstStable -eq 'reached') { 'Growing' } else { 'Building' }
            if ($row.Badge -notlike "*badge/status-$word-*](#$anchor)*") { $errors.Add("README.md repo overview: $name has a plan that says the first stable version is $firstStable. Its badge must be $word and link to #$anchor.") }
        } else {
            if ($row.Badge -notlike "*badge/status-Stable-*](#$anchor)*") { $errors.Add("README.md repo overview: $name has no plan. Its badge must be Stable and link to #$anchor.") }
        }
    }
    # The Phases column: one line for each phase of the plan, ordered by priority
    $priorities = @{}
    foreach ($row in $rows) {
        $name = $row.Name
        $cell = $row.Phases.Trim()
        if ($row.Badge -like '*badge/status-Stable-*') {
            if ($cell -ne '') { $errors.Add("README.md repo overview: $name is Stable. Its Phases cell must be empty.") }
            continue
        }
        $plan = if ($planOf.ContainsKey($name)) { $planOf[$name] } else { "$name.md" }
        $planPath = Join-Path $plansRoot $plan
        if (-not (Test-Path $planPath)) { continue }
        $phases = Get-PlanPhases $planPath
        $lines = if ($cell -eq '') { @() } else { @($cell -split '<br>') }
        $linePhases = @{}
        $last = 0
        foreach ($line in $lines) {
            if ($line -notmatch '^\[(\d+) \((\d+)\): (\d+)\]\(\./plans/([^)#]+)#phase-(\d+)\)$') {
                $errors.Add("README.md repo overview: $name has the Phases line '$line'. A line is [A (B): C](./plans/File.md#phase-A).")
                continue
            }
            $phase = $Matches[1]; $open = [int]$Matches[2]; $priority = [int]$Matches[3]; $file = $Matches[4]; $anchor = $Matches[5]
            if ($file -ne $plan) { $errors.Add("README.md repo overview: $name has a Phases line that links to $file. It must link to $plan.") }
            if ($anchor -ne $phase) { $errors.Add("README.md repo overview: $name has the Phases line for phase $phase that links to #phase-$anchor.") }
            if (-not $phases.Contains($phase)) { $errors.Add("README.md repo overview: $name has a Phases line for phase $phase, and plans\$plan has no such phase."); continue }
            if ($linePhases.ContainsKey($phase)) { $errors.Add("README.md repo overview: $name has more than one Phases line for phase $phase."); continue }
            $linePhases[$phase] = $true
            if ($open -ne $phases[$phase]) { $errors.Add("README.md repo overview: $name phase $phase says $open open questions, and plans\$plan has $($phases[$phase]).") }
            if ($priority -lt 1) { $errors.Add("README.md repo overview: $name phase $phase needs a priority, a whole number from 1.") }
            elseif ($priorities.ContainsKey($priority)) { $errors.Add("README.md repo overview: the priority $priority is used by $($priorities[$priority]) and by $name phase $phase. Priorities are unique.") }
            else { $priorities[$priority] = "$name phase $phase" }
            if ($priority -le $last) { $errors.Add("README.md repo overview: the Phases lines of $name are not ordered by priority. Phase $phase with priority $priority comes after priority $last.") }
            $last = $priority
        }
        foreach ($phase in $phases.Keys) {
            if (-not $linePhases.ContainsKey($phase)) { $errors.Add("README.md repo overview: $name has no Phases line for phase $phase of plans\$plan.") }
        }
    }
    foreach ($name in $moduleFolders) {
        if (-not $seen.ContainsKey($name)) { $errors.Add("README.md repo overview: the module $name has no row.") }
    }
    foreach ($plan in $planFiles) {
        $name = if ($plan -eq 'Demo.md') { 'Cat.Demo' } elseif ($plan -eq 'Skills.md') { 'Cat.Skills' } else { [System.IO.Path]::GetFileNameWithoutExtension($plan) }
        # A plan that says <!-- no overview row--> covers the whole repository and has no row.
        if ([System.IO.File]::ReadAllText((Join-Path $plansRoot $plan)) -match '(?m)^<!-- no overview row-->\s*$') { continue }
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
    }
}

$errors | ForEach-Object { Write-Output "ERROR   $_" }
$warnings | ForEach-Object { Write-Output "WARNING $_" }
Write-Output "$(@($files).Count) markdown files checked. $($errors.Count) errors, $($warnings.Count) warnings."
if ($errors.Count -gt 0) { exit 1 }
