<#
Reads or writes the Excalidraw scene that is embedded in a *.excalidraw.svg file.

Decode: excalidraw-payload.ps1 -Mode Decode -SvgPath <svg> -JsonPath <out.json>
Encode: excalidraw-payload.ps1 -Mode Encode -SvgPath <svg> -JsonPath <scene.json>

Decode writes the scene JSON to JsonPath.
Encode replaces the payload between <!-- payload-start --> and <!-- payload-end --> with the scene in JsonPath.
The visible picture in the SVG is not touched. Generate that part separately.
#>
param(
    [Parameter(Mandatory)][ValidateSet('Decode', 'Encode')][string]$Mode,
    [Parameter(Mandatory)][string]$SvgPath,
    [Parameter(Mandatory)][string]$JsonPath
)

$ErrorActionPreference = 'Stop'
[System.Threading.Thread]::CurrentThread.CurrentCulture = [System.Globalization.CultureInfo]::InvariantCulture
$latin1 = [System.Text.Encoding]::GetEncoding(28591)
$utf8 = New-Object System.Text.UTF8Encoding($false)
$pattern = '(?s)(<!-- payload-start -->)(.*?)(<!-- payload-end -->)'

function Get-Adler32([byte[]]$bytes) {
    [uint32]$a = 1
    [uint32]$b = 0
    foreach ($byte in $bytes) {
        $a = ($a + $byte) % 65521
        $b = ($b + $a) % 65521
    }
    return ([uint32]($b * 65536) + $a)
}

if ($Mode -eq 'Decode') {
    $svg = [System.IO.File]::ReadAllText($SvgPath, $utf8)
    $match = [regex]::Match($svg, $pattern)
    if (-not $match.Success) { throw "No payload found in $SvgPath" }

    $outerJson = $latin1.GetString([Convert]::FromBase64String($match.Groups[2].Value.Trim()))
    $outer = $outerJson | ConvertFrom-Json
    $zlibBytes = $latin1.GetBytes($outer.encoded)

    # Skip the 2 byte zlib header, the rest is a raw deflate stream.
    $zin = New-Object System.IO.MemoryStream($zlibBytes, 2, ($zlibBytes.Length - 2))
    $deflate = New-Object System.IO.Compression.DeflateStream($zin, [System.IO.Compression.CompressionMode]::Decompress)
    $output = New-Object System.IO.MemoryStream
    $deflate.CopyTo($output)
    [System.IO.File]::WriteAllText($JsonPath, $utf8.GetString($output.ToArray()), $utf8)
    Write-Output "Decoded the scene to $JsonPath"
}
else {
    $sceneBytes = $utf8.GetBytes([System.IO.File]::ReadAllText($JsonPath, $utf8))

    $compressed = New-Object System.IO.MemoryStream
    $deflate = New-Object System.IO.Compression.DeflateStream($compressed, [System.IO.Compression.CompressionMode]::Compress, $true)
    $deflate.Write($sceneBytes, 0, $sceneBytes.Length)
    $deflate.Close()

    # zlib stream = header 78 9C + raw deflate + big endian Adler-32.
    $adler = Get-Adler32 $sceneBytes
    $zlib = New-Object System.Collections.Generic.List[byte]
    $zlib.Add(0x78)
    $zlib.Add(0x9C)
    $zlib.AddRange($compressed.ToArray())
    $zlib.Add([byte](($adler -shr 24) -band 255))
    $zlib.Add([byte](($adler -shr 16) -band 255))
    $zlib.Add([byte](($adler -shr 8) -band 255))
    $zlib.Add([byte]($adler -band 255))

    # Write every byte as a JSON safe Latin-1 character.
    $encoded = New-Object System.Text.StringBuilder
    foreach ($byte in $zlib) {
        if ($byte -eq 34) { [void]$encoded.Append('\"') }
        elseif ($byte -eq 92) { [void]$encoded.Append('\\') }
        elseif ($byte -lt 32 -or $byte -gt 126) { [void]$encoded.Append(('\u{0:x4}' -f $byte)) }
        else { [void]$encoded.Append([char]$byte) }
    }
    $outerJson = '{"version":"1","encoding":"bstring","compressed":true,"encoded":"' + $encoded.ToString() + '"}'
    $payload = [Convert]::ToBase64String($latin1.GetBytes($outerJson))

    $svg = [System.IO.File]::ReadAllText($SvgPath, $utf8)
    if (-not [regex]::IsMatch($svg, $pattern)) { throw "No payload markers found in $SvgPath" }
    $svg = [regex]::Replace($svg, $pattern, { param($m) $m.Groups[1].Value + $payload + $m.Groups[3].Value })
    [System.IO.File]::WriteAllText($SvgPath, $svg, $utf8)
    Write-Output "Wrote the scene from $JsonPath into $SvgPath"
}
