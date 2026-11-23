<#
Unlists every listed alpha version of the packages of one nuget.org owner. Rc and stable versions stay listed.

The build workflow runs it after a tag. Run it yourself with -DryRun to see what it would unlist.

Parameters:
- Owner: the nuget.org user that owns the packages.
- IdPattern: only package ids that match are touched. The default covers the modules and the template pack, which all start with gmarginet.Cat.
- TimeLimit: stops unlisting after this time, 50 minutes by default, because the temporary key of the workflow lasts one hour.
- DryRun: lists the versions and unlists nothing.

The API key comes from the environment variable NUGET_API_KEY. It needs the unlist scope.
Unlisting is safe to repeat. A run only looks at versions that are still listed, so an interrupted run continues at the next call.
#>
param(
    [Parameter(Mandatory)][string]$Owner,
    [string]$IdPattern = '^gmarginet\.Cat\.',
    [TimeSpan]$TimeLimit = [TimeSpan]::FromMinutes(50),
    [switch]$DryRun
)

$ErrorActionPreference = 'Stop'

$apiKey = $env:NUGET_API_KEY
if (-not $DryRun -and [string]::IsNullOrWhiteSpace($apiKey)) { throw 'NUGET_API_KEY is not set.' }

# Versions such as 0.0.0-alpha.0.516 are SemVer 2. The search hides them without semVerLevel.
$search = Invoke-RestMethod "https://azuresearch-usnc.nuget.org/query?q=owner:$Owner&prerelease=true&semVerLevel=2.0.0&take=1000"
$ids = @($search.data | ForEach-Object { $_.id } | Where-Object { $_ -match $IdPattern } | Sort-Object)
Write-Host "Found $($ids.Count) packages of $Owner that match $IdPattern."

$unlisted = 0
$failed = 0
$stopped = $false
$clock = [System.Diagnostics.Stopwatch]::StartNew()
foreach ($id in $ids) {
    $index = Invoke-RestMethod "https://api.nuget.org/v3/registration5-gz-semver2/$($id.ToLowerInvariant())/index.json"

    # Small registrations hold the items in the index. Larger ones hold pages that we have to fetch.
    $items = foreach ($page in $index.items) {
        if ($page.items) { $page.items } else { (Invoke-RestMethod $page.'@id').items }
    }

    $versions = @($items |
        ForEach-Object { $_.catalogEntry } |
        Where-Object { $_.listed -and $_.version -match '-alpha' } |
        ForEach-Object { $_.version })

    foreach ($version in $versions) {
        if ($DryRun) {
            Write-Host "Would unlist $id $version"
            continue
        }

        if ($clock.Elapsed -gt $TimeLimit) {
            Write-Warning "The time limit of $($TimeLimit.TotalMinutes) minutes is reached. The next run continues with the versions that are still listed."
            $stopped = $true
            break
        }

        # This is the call that dotnet nuget delete makes. nuget.org unlists the version, it does not delete it.
        # It is faster than starting dotnet for every version, which matters because the key lasts one hour.
        try {
            Invoke-RestMethod -Method Delete -Uri "https://www.nuget.org/api/v2/package/$id/$version" -Headers @{ 'X-NuGet-ApiKey' = $apiKey } | Out-Null
            $unlisted++
            Write-Host "Unlisted $id $version"
        }
        catch {
            $failed++
            Write-Warning "Could not unlist $id $version. $($_.Exception.Message)"
        }
    }
    if ($stopped) { break }
}

Write-Host "Done. Unlisted $unlisted versions, $failed failed."
if ($failed -gt 0) { exit 1 }
