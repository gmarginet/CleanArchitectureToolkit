<#
Switches the boxes of the demo architecture drawing between hatched and solid, based on what exists in demo/.

Run:   sync-demo-architecture.ps1 [-WorkDir <scratchpad>]
Check: sync-demo-architecture.ps1 -Check   (changes nothing, exit code 1 when the drawing is out of date)

demo-blocks.json lists the blocks, the id of their rectangle in the scene and the rule that says the block is built.
A block that is built gets a solid fill. A block that is not built gets a cross-hatch fill.
The background color of a box never changes.

The script changes the fill style in the embedded scene and redraws the fill of the changed boxes in the visible picture.
Everything else in the SVG stays as it is. Boxes that do not change keep their hand-drawn look.
#>
param(
    [switch]$Check,
    [string]$WorkDir = $env:TEMP
)

$ErrorActionPreference = 'Stop'
[System.Threading.Thread]::CurrentThread.CurrentCulture = [System.Globalization.CultureInfo]::InvariantCulture
$utf8 = New-Object System.Text.UTF8Encoding($false)

$root = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..')).Path
$config = Get-Content (Join-Path $PSScriptRoot 'demo-blocks.json') -Raw | ConvertFrom-Json
$svgPath = Join-Path $root $config.drawing
$payloadScript = Join-Path $root '.claude\skills\excalidraw-svg\excalidraw-payload.ps1'
$jsonPath = Join-Path $WorkDir 'demo-architecture-scene.json'

function Format-Number([double]$n) { return $n.ToString('0.##', [System.Globalization.CultureInfo]::InvariantCulture) }

function Test-Built($detect) {
    $target = Join-Path $root $detect.path
    if (-not (Test-Path -Path $target)) { return $false }
    if (-not $detect.pattern) { return $true }
    $hit = Get-ChildItem -Path $target -Recurse -File -Include *.cs, *.csproj, *.json, *.ts, *.tsx -ErrorAction SilentlyContinue |
        Where-Object { $_.FullName -notmatch '\\(bin|obj|node_modules)\\' } |
        Select-String -Pattern $detect.pattern -SimpleMatch -Quiet
    return [bool]$hit
}

function Get-CornerRadius([double]$w, [double]$h) {
    $m = [Math]::Min($w, $h)
    if ($m -le 128) { return $m * 0.25 }
    return 32
}

function Test-Inside([double]$px, [double]$py, [double]$w, [double]$h, [double]$r, [double]$inset) {
    if ($px -lt $inset -or $px -gt ($w - $inset) -or $py -lt $inset -or $py -gt ($h - $inset)) { return $false }
    $cx = $null; $cy = $null
    if ($px -lt $r) { $cx = $r } elseif ($px -gt ($w - $r)) { $cx = $w - $r }
    if ($py -lt $r) { $cy = $r } elseif ($py -gt ($h - $r)) { $cy = $h - $r }
    if ($null -eq $cx -or $null -eq $cy) { return $true }
    $dx = $px - $cx; $dy = $py - $cy
    return (($dx * $dx + $dy * $dy) -le (($r - $inset) * ($r - $inset)))
}

function New-SolidFill([double]$w, [double]$h, [string]$color) {
    $r = Get-CornerRadius $w $h
    $a = Format-Number $r; $b = Format-Number ($w - $r); $c = Format-Number $w
    $d = Format-Number ($h - $r); $e = Format-Number $h
    $path = "M$a 0 L$b 0 Q$c 0 $c $a L$c $d Q$c $e $b $e L$a $e Q0 $e 0 $d L0 $a Q0 0 $a 0 Z"
    return "<path d=`"$path`" stroke=`"none`" stroke-width=`"0`" fill=`"$color`"></path>"
}

function New-HatchFill([double]$w, [double]$h, [string]$color) {
    $r = Get-CornerRadius $w $h
    $gap = 8.0
    $reach = [Math]::Sqrt($w * $w + $h * $h) / 2 + 4
    $segments = New-Object System.Collections.Generic.List[string]
    foreach ($angle in 49, -49) {
        $rad = $angle * [Math]::PI / 180
        $dirX = [Math]::Cos($rad); $dirY = -[Math]::Sin($rad)
        $nX = -$dirY; $nY = $dirX
        for ($offset = -$reach; $offset -le $reach; $offset += $gap) {
            $startX = $w / 2 + $nX * $offset
            $startY = $h / 2 + $nY * $offset
            $first = $null; $last = $null
            for ($t = -$reach; $t -le $reach; $t += 1) {
                $px = $startX + $dirX * $t; $py = $startY + $dirY * $t
                if (Test-Inside $px $py $w $h $r 3) {
                    if ($null -eq $first) { $first = @($px, $py) }
                    $last = @($px, $py)
                } elseif ($null -ne $first) {
                    break
                }
            }
            if ($null -ne $first -and $null -ne $last) {
                $segments.Add("M$(Format-Number $first[0]) $(Format-Number $first[1]) L$(Format-Number $last[0]) $(Format-Number $last[1])")
            }
        }
    }
    return "<path d=`"$($segments -join ' ')`" stroke=`"$color`" stroke-width=`"1`" fill=`"none`"></path>"
}

function Set-SceneFillStyle([string]$text, [string]$id, [string]$style) {
    $m = [regex]::Match($text, '"id":\s*"' + [regex]::Escape($id) + '"')
    if (-not $m.Success) { throw "Element $id not found in the scene" }
    $start = $text.LastIndexOf('{', $m.Index)
    $depth = 0; $end = -1
    for ($i = $start; $i -lt $text.Length; $i++) {
        if ($text[$i] -eq '{') { $depth++ } elseif ($text[$i] -eq '}') { $depth--; if ($depth -eq 0) { $end = $i; break } }
    }
    $object = $text.Substring($start, $end - $start + 1)
    $changed = [regex]::Replace($object, '"fillStyle":\s*"[^"]*"', '"fillStyle": "' + $style + '"')
    return $text.Substring(0, $start) + $changed + $text.Substring($end + 1)
}

& $payloadScript -Mode Decode -SvgPath $svgPath -JsonPath $jsonPath | Out-Null
$sceneText = [System.IO.File]::ReadAllText($jsonPath, $utf8)
$scene = $sceneText | ConvertFrom-Json
$svg = [System.IO.File]::ReadAllText($svgPath, $utf8)

$groupPattern = '<g stroke-linecap="round" transform="translate\(([-\d.]+) ([-\d.]+)\) rotate\(0 ([-\d.]+) ([-\d.]+)\)">(<path[^>]*></path>)(<path[^>]*></path>)</g>'
$groups = [regex]::Matches($svg, $groupPattern)

# The SVG is shifted against the scene. The first element is the frame, and it is the first drawn group.
$frame = $scene.elements[0]
$frameGroup = [regex]::Match($svg, '<g stroke-linecap="round" transform="translate\(([-\d.]+) ([-\d.]+)\)')
$offsetX = [double]$frameGroup.Groups[1].Value - [double]$frame.x
$offsetY = [double]$frameGroup.Groups[2].Value - [double]$frame.y

$rows = @()
$outOfDate = $false
foreach ($block in $config.blocks) {
    $element = $scene.elements | Where-Object { $_.id -eq $block.element }
    if (-not $element) { throw "Block '$($block.name)': element $($block.element) is not in the drawing" }

    $built = Test-Built $block.detect
    $wanted = if ($built) { 'solid' } else { 'cross-hatch' }

    $group = $groups | Where-Object {
        [Math]::Abs([double]$_.Groups[1].Value - ([double]$element.x + $offsetX)) -lt 0.05 -and
        [Math]::Abs([double]$_.Groups[2].Value - ([double]$element.y + $offsetY)) -lt 0.05 -and
        [Math]::Abs([double]$_.Groups[3].Value * 2 - [double]$element.width) -lt 0.1
    } | Select-Object -First 1
    if (-not $group) { throw "Block '$($block.name)': no group in the picture at the place of the element" }

    $drawn = if ($group.Groups[5].Value -match 'fill="none"') { 'cross-hatch' } else { 'solid' }
    $inScene = $element.fillStyle
    $stale = ($drawn -ne $wanted) -or ($inScene -ne $wanted)
    if ($stale) { $outOfDate = $true }

    if ($stale -and -not $Check) {
        $color = $element.backgroundColor
        $fill = if ($built) { New-SolidFill ([double]$element.width) ([double]$element.height) $color } else { New-HatchFill ([double]$element.width) ([double]$element.height) $color }
        $header = $group.Value.Substring(0, $group.Value.IndexOf('>') + 1)
        $newGroup = $header + $fill + $group.Groups[6].Value + '</g>'
        $svg = $svg.Replace($group.Value, $newGroup)
        $sceneText = Set-SceneFillStyle $sceneText $block.element $wanted
    }

    $rows += [pscustomobject]@{ Block = $block.name; Built = $built; Wanted = $wanted; WasDrawn = $drawn; Updated = ($stale -and -not $Check) }
}

if ($outOfDate -and -not $Check) {
    [System.IO.File]::WriteAllText($svgPath, $svg, $utf8)
    [System.IO.File]::WriteAllText($jsonPath, $sceneText, $utf8)
    & $payloadScript -Mode Encode -SvgPath $svgPath -JsonPath $jsonPath | Out-Null
}

$rows | Format-Table -AutoSize | Out-String -Width 200
if ($Check) {
    if ($outOfDate) { Write-Output 'The drawing is out of date.'; exit 1 }
    Write-Output 'The drawing is up to date.'
} elseif ($outOfDate) {
    Write-Output "Updated $svgPath. Render a preview and look at it before you commit."
} else {
    Write-Output 'Nothing to change.'
}
