<#
Unlists old versions of the packages of one nuget.org owner. It has two ways.

Cleanup, with -Tag:
- The rule: a pre-release version goes when a tag has a higher stage and a higher version. The stages go alpha, rc, stable.
  - An alpha tag unlists nothing.
  - An rc tag unlists the alphas that are lower than the tag.
  - A stable tag unlists the alphas and the rcs that are lower than the tag.
- The rule runs for every tag that you pass. A run that stopped at the quota, or a later tag of a lower stage, then never leaves old work behind.
- Stable versions are never unlisted by a cleanup, and neither is a version of a newer line than the tag.
- Versions with another label than alpha or rc stay listed.

Single, with -Version:
- Unlists exactly that version in every package that has it. It can be an alpha, an rc or a stable version.
- When no package lists the version, nothing is unlisted. The script prints the listed versions and fails.

The build workflow runs a cleanup with every v tag after a tag. A manual run of the workflow offers both ways.
Run the script yourself with -DryRun to see what it would unlist. A dry run also prints every listed version once, with the number of packages that have it.

Parameters:
- Owner: the nuget.org user that owns the packages.
- Tag: the tag versions for a cleanup, without the v, such as 1.1.0 or 1.1.1-rc.1.
- Version: the one version for a single unlist.
- IdPattern: only package ids that match are touched. The default covers the modules and the template pack, which all start with gmarginet.Cat.
- TimeLimit: stops unlisting after this time, 50 minutes by default, because the temporary key of the workflow lasts one hour.
- DelayMilliseconds: the pause after every unlist call, one second by default. When nuget.org answers with a quota error, the script stops without a failure.
- DryRun: lists the versions and unlists nothing.

The API key comes from the environment variable NUGET_API_KEY. It needs the unlist scope.
Unlisting is safe to repeat. A run only looks at versions that are still listed, so an interrupted run continues at the next call.
#>
param(
    [Parameter(Mandatory)][string]$Owner,
    [string[]]$Tag = @(),
    [string]$Version = '',
    [string]$IdPattern = '^gmarginet\.Cat\.',
    [TimeSpan]$TimeLimit = [TimeSpan]::FromMinutes(50),
    [int]$DelayMilliseconds = 1000,
    [switch]$DryRun
)

$ErrorActionPreference = 'Stop'

$Tag = @($Tag | Where-Object { $_ -and $_.Trim() })
$Version = $Version.Trim().TrimStart('v')

if ($Tag.Count -eq 0 -and -not $Version) { throw 'Pass -Tag for a cleanup or -Version for a single unlist.' }
if ($Tag.Count -gt 0 -and $Version) { throw 'Pass -Tag or -Version, not both.' }

$apiKey = $env:NUGET_API_KEY
if (-not $DryRun -and [string]::IsNullOrWhiteSpace($apiKey)) { throw 'NUGET_API_KEY is not set.' }

# Splits a version into its numbers and its pre-release labels. The stage is 1 for an alpha, 2 for an rc, 3 for a stable version and 0 for any other label.
function ConvertTo-SemVer([string]$Text) {
    $m = [regex]::Match($Text, '^(\d+)\.(\d+)\.(\d+)(?:\.\d+)?(?:-([0-9A-Za-z.-]+))?(?:\+.*)?$')
    if (-not $m.Success) { return $null }
    $pre = if ($m.Groups[4].Success) { [string[]]$m.Groups[4].Value.Split('.') } else { [string[]]@() }
    $stage = 0
    if ($pre.Count -eq 0) { $stage = 3 }
    elseif ($pre[0] -ieq 'alpha') { $stage = 1 }
    elseif ($pre[0] -ieq 'rc') { $stage = 2 }
    return [pscustomobject]@{
        Major = [long]$m.Groups[1].Value
        Minor = [long]$m.Groups[2].Value
        Patch = [long]$m.Groups[3].Value
        Pre   = $pre
        Stage = $stage
    }
}

# Orders versions like NuGet does. A version without labels is higher than the same version with labels.
function Compare-SemVer($A, $B) {
    foreach ($part in 'Major', 'Minor', 'Patch') {
        if ($A.$part -ne $B.$part) { return [Math]::Sign($A.$part - $B.$part) }
    }
    $pa = $A.Pre
    $pb = $B.Pre
    if ($pa.Count -eq 0 -and $pb.Count -eq 0) { return 0 }
    if ($pa.Count -eq 0) { return 1 }
    if ($pb.Count -eq 0) { return -1 }
    $shared = [Math]::Min($pa.Count, $pb.Count)
    for ($i = 0; $i -lt $shared; $i++) {
        $x = $pa[$i]
        $y = $pb[$i]
        $xIsNumber = $x -match '^\d+$'
        $yIsNumber = $y -match '^\d+$'
        if ($xIsNumber -and $yIsNumber) {
            $diff = [long]$x - [long]$y
            if ($diff -ne 0) { return [Math]::Sign($diff) }
        }
        elseif ($xIsNumber) { return -1 }
        elseif ($yIsNumber) { return 1 }
        else {
            $c = [string]::CompareOrdinal($x.ToLowerInvariant(), $y.ToLowerInvariant())
            if ($c -ne 0) { return [Math]::Sign($c) }
        }
    }
    return [Math]::Sign($pa.Count - $pb.Count)
}

# The tag versions of a cleanup. A tag that is not a version, or has another label than alpha or rc, can not unlist anything.
$tagVersions = @()
foreach ($text in $Tag) {
    $sem = ConvertTo-SemVer ($text.Trim().TrimStart('v'))
    if ($null -eq $sem) { Write-Warning "Ignored the tag '$text'. It is not a version."; continue }
    if ($sem.Stage -eq 0) { Write-Warning "The tag '$text' has no alpha or rc label and is not stable. It unlists nothing."; continue }
    $tagVersions += $sem
}

# Versions such as 0.0.0-alpha.0.516 are SemVer 2. The search hides them without semVerLevel.
$search = Invoke-RestMethod "https://azuresearch-usnc.nuget.org/query?q=owner:$Owner&prerelease=true&semVerLevel=2.0.0&take=1000"
$ids = @($search.data | ForEach-Object { $_.id } | Where-Object { $_ -match $IdPattern } | Sort-Object)
Write-Host "Found $($ids.Count) packages of $Owner that match $IdPattern."

$clock = [System.Diagnostics.Stopwatch]::StartNew()

# Every listed version of every package.
$listed = New-Object System.Collections.Generic.List[object]
foreach ($id in $ids) {
    $index = Invoke-RestMethod "https://api.nuget.org/v3/registration5-gz-semver2/$($id.ToLowerInvariant())/index.json"

    # Small registrations hold the items in the index. Larger ones hold pages that we have to fetch.
    $items = foreach ($page in $index.items) {
        if ($page.items) { $page.items } else { (Invoke-RestMethod $page.'@id').items }
    }

    foreach ($entry in @($items | ForEach-Object { $_.catalogEntry } | Where-Object { $_.listed })) {
        $listed.Add([pscustomobject]@{ Id = $id; Version = [string]$entry.version; Sem = (ConvertTo-SemVer ([string]$entry.version)) })
    }
}

# What goes.
if ($Version) {
    $targets = @($listed | Where-Object { $_.Version -ieq $Version })
}
else {
    $targets = @($listed | Where-Object {
            $v = $_
            $v.Sem -and $v.Sem.Pre.Count -gt 0 -and $v.Sem.Stage -gt 0 -and
            @($tagVersions | Where-Object { $v.Sem.Stage -lt $_.Stage -and (Compare-SemVer $v.Sem $_) -lt 0 }).Count -gt 0
        })
}

# Every listed version once, lowest first, with the number of packages that have it.
function Write-ListedVersions {
    $groups = @($listed | Group-Object { $_.Version.ToLowerInvariant() } | ForEach-Object {
            [pscustomobject]@{ Version = $_.Group[0].Version; Count = $_.Count; Sem = $_.Group[0].Sem }
        })
    $sorted = New-Object System.Collections.Generic.List[object]
    $sorted.AddRange([object[]]$groups)
    $sorted.Sort([Comparison[object]] {
            param($x, $y)
            if ($null -eq $x.Sem -and $null -eq $y.Sem) { return [string]::CompareOrdinal($x.Version, $y.Version) }
            if ($null -eq $x.Sem) { return 1 }
            if ($null -eq $y.Sem) { return -1 }
            return Compare-SemVer $x.Sem $y.Sem
        })
    Write-Host "Listed versions: $($sorted.Count)"
    foreach ($g in $sorted) {
        $word = if ($g.Count -eq 1) { 'package' } else { 'packages' }
        Write-Host "  $($g.Version) ($($g.Count) $word)"
    }
}

if ($Version -and $targets.Count -eq 0) {
    Write-Warning "No package lists the version $Version. Nothing is unlisted."
    Write-ListedVersions
    exit 1
}

# In a workflow a warning becomes a yellow annotation on the run page. On your own machine it is a plain warning.
function Write-StopWarning([string]$Title, [string]$Text) {
    if ($env:GITHUB_ACTIONS -eq 'true') { Write-Host "::warning title=$Title::$Text" }
    else { Write-Warning $Text }
}

# In a workflow the summary shows on the run page.
function Write-RunSummary([string[]]$Lines) {
    if ($env:GITHUB_STEP_SUMMARY) { Add-Content -Path $env:GITHUB_STEP_SUMMARY -Value $Lines -Encoding utf8 }
}

$unlisted = 0
$failed = 0
$stoppedBy = ''
foreach ($target in $targets) {
    if ($DryRun) {
        Write-Host "Would unlist $($target.Id) $($target.Version)"
        continue
    }

    if ($clock.Elapsed -gt $TimeLimit) {
        $stoppedBy = 'the time limit'
        Write-StopWarning 'Time limit reached' "The time limit of $($TimeLimit.TotalMinutes) minutes is reached. Unlisted $unlisted, $($targets.Count - $unlisted) versions are left. Run again to continue with the versions that are still listed."
        break
    }

    # This is the call that dotnet nuget delete makes. nuget.org unlists the version, it does not delete it.
    # It is faster than starting dotnet for every version, which matters because the key lasts one hour.
    try {
        Invoke-RestMethod -Method Delete -Uri "https://www.nuget.org/api/v2/package/$($target.Id)/$($target.Version)" -Headers @{ 'X-NuGet-ApiKey' = $apiKey } | Out-Null
        $unlisted++
        Write-Host "Unlisted $($target.Id) $($target.Version)"
    }
    catch {
        # nuget.org limits the unlist calls. Stop here, the next run continues with what is still listed.
        if ($_.Exception.Message -match 'Quota Exceeded') {
            $stoppedBy = 'the nuget.org quota'
            Write-StopWarning 'nuget.org quota reached' "nuget.org says the quota is exceeded. Unlisted $unlisted, $($targets.Count - $unlisted) versions are left. The quota is about 250 per hour, so wait an hour or more, then run again."
            break
        }
        $failed++
        Write-Warning "Could not unlist $($target.Id) $($target.Version). $($_.Exception.Message)"
    }

    Start-Sleep -Milliseconds $DelayMilliseconds
}

if ($DryRun) {
    Write-ListedVersions
    Write-Host "Dry run. Nothing was unlisted. $($targets.Count) versions would go."
    Write-RunSummary '### Unlist old versions', '', "Dry run. Nothing was unlisted. $($targets.Count) versions would go."
    exit 0
}

Write-Host "Done. Unlisted $unlisted versions, $failed failed."
$summary = @('### Unlist old versions', '', "- Unlisted: $unlisted", "- Failed: $failed", "- Left: $($targets.Count - $unlisted)")
if ($stoppedBy) { $summary += "- Stopped by $stoppedBy. Wait an hour or more, then run again." }
Write-RunSummary $summary
if ($failed -gt 0) { exit 1 }
