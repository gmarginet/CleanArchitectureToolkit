<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: ../.. -->
<link href="../../resources/styles/style.css" rel="stylesheet" />
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-module-readme skill to update this readme.-->
<!-- region end: TemplateSkill-->

# Cat.Scheduling <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Scheduling runs recurring jobs inside your API. A job has a name and a cron expression. Every run becomes one service request that your core handles, so the worker holds no business logic.

Work that starts because time passed, such as a nightly cleanup or a periodic import, fits here. A one-off moment, such as "cancel after 24 hours", does not. Use a scheduled message of the bus for that.

A service can run several instances. Before a run, an instance claims the due time, and only the instance that wins runs the job.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Switch the scheduler on](#switch-the-scheduler-on)
  - [Declare a job](#declare-a-job)
  - [Change a job in the configuration](#change-a-job-in-the-configuration)
  - [The system user](#the-system-user)
  - [Run on more than one instance](#run-on-more-than-one-instance)
  - [Retry a failed run](#retry-a-failed-run)
  - [Overlap](#overlap)
  - [Missed runs](#missed-runs)
  - [Time zones](#time-zones)
  - [Trigger a job by hand](#trigger-a-job-by-hand)
  - [Tracing and metrics](#tracing-and-metrics)
  - [Test your jobs](#test-your-jobs)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Scheduling)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Scheduling.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Scheduling.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.Scheduling.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Scheduling.Abstractions)](#nuget-packages) |
| [Cat.Scheduling](https://www.nuget.org/packages/gmarginet.Cat.Scheduling/) | Implementation | `dotnet add package gmarginet.Cat.Scheduling` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Scheduling)](#nuget-packages) |
| [Cat.Scheduling.EFCore](https://www.nuget.org/packages/gmarginet.Cat.Scheduling.EFCore/) | Claim store and run history in the database | `dotnet add package gmarginet.Cat.Scheduling.EFCore` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Scheduling.EFCore)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Scheduling.Abstractions](namespaces/Cat.Scheduling.Abstractions/index.md) | The job settings, the job runner and the claim store contracts. |
| [Cat.Scheduling](namespaces/Cat.Scheduling/index.md) | The scheduler loop, the cron parsing, the in-memory claim store and the telemetry. |
| [Cat.Scheduling.EFCore](namespaces/Cat.Scheduling.EFCore/index.md) | The claim store and the run history in a database, with Entity Framework Core. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.Scheduling needs it |
|--------|-----------------------------|
| [Cat.Responses](../Cat.Responses/README.md) | The result of a run is the `ICatResponse` of the service request. |
| [Cat.ServiceRequests](../Cat.ServiceRequests/README.md) | Every run becomes a service request that the processor handles. |
| [Cat.Users](../Cat.Users/README.md) | Every run uses a named system user, so `ICatUser` always has a value. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Switch the scheduler on
Register the scheduler in the API project. Cat.Scheduling.EFCore is optional. Without it, the claims live in memory, which is right for a service with one instance.

```csharp
services.AddCatScheduling(configuration, scheduler => scheduler
    .RunAs("orders")
    .Job<CleanUpOrderCountersRequest>("clean-up-order-counters", "5 0 * * *"));
```

The scheduler is a hosted service. It needs `ICatServiceRequestProcessor`, so register the service requests module as well. A cron expression with 5 fields runs at the minute. One with 6 fields starts with the seconds. A wrong expression or time zone throws at registration, with the name of the job in the message.

### Declare a job
There are two ways.

```csharp
// The request has a parameterless constructor.
scheduler.Job<CleanUpOrderCountersRequest>("clean-up-order-counters", "5 0 * * *");

// The request needs data. The factory runs on every run.
scheduler.Job("low-stock-report", "0 6 * * 1-5", () => new LowStockReportRequest(threshold: 5));
```

Both take an optional action to set the options of the job.

```csharp
scheduler.Job<ImportPricesRequest>("import-prices", "*/15 * * * *", options =>
{
    options.MaxRetries = 3;
    options.AllowOverlap = false;
});
```

A job name is unique. A duplicate or an empty name throws.

| Option | Default | Meaning |
|--------|---------|---------|
| `Cron` | the expression of the job | The schedule. |
| `TimeZoneId` | `UTC` | Any time zone id of `TimeZoneInfo`. |
| `Enabled` | `true` | `false` switches the job off. |
| `MissedRuns` | `RunOnce` | What to do at startup with a due time that passed. `RunOnce` or `Skip`. |
| `AllowOverlap` | `false` | Allows a new run while the last one is still busy. |
| `DeadAfter` | 1 hour | After this time, a busy claim counts as dead and another run may take over. |
| `MaxRetries` | 0 | How many times a failed run is tried again. |
| `RetryDelay` | 30 seconds | The wait between two tries. |
| `GrowingRetryDelay` | `false` | Doubles the delay after every try. |

### Change a job in the configuration
The section `CatScheduling:Jobs:<job name>` overrides the options of the code. It wins over the code. Use it to change the time per environment, or to switch a job off.

```json
{
  "CatScheduling": {
    "Jobs": {
      "clean-up-order-counters": {
        "Cron": "30 1 * * *",
        "Enabled": true
      }
    }
  }
}
```

### The system user
A run has no person behind it. The scheduler runs every service request as a named system user, so `ICatUser` always has a value. `RunAs("orders")` sets the name. Without it the name is `scheduler`. The user is authenticated, has the role `system`, and its `UserId` is the name.

The user also reaches the handler, because `CatUserAccessor` of Cat.Users flows the user along the async call chain. A token for calls to other services is not part of this module.

### Run on more than one instance
Add `Cat.Scheduling.EFCore` and tell the scheduler to use your `DbContext`.

```csharp
services.AddCatSchedulingEFCore<OrderDbContext>();
services.AddCatScheduling(configuration, scheduler => ...);
```

Add the model to your `DbContext`, then create a migration.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.AddCatScheduling();
}
```

Before a run, an instance inserts a row `CatJobRun` with the job name and the due time. The two form the key. The instance whose insert succeeds runs the job. The others skip that due time. The row also keeps the status, the start and end time and the error code, so it is the run history. The module has no screen for it.

A service with one instance needs none of this. The in-memory store is the default. To use another store, such as a blob lease, implement `ICatJobClaimStore` of the abstractions project and register it before `AddCatScheduling`.

### Retry a failed run
A failed `ICatResponse` is logged with its error codes and counted in a metric. By default the job waits for the next due time. Set `MaxRetries` to try again.

A retry is a new try of the same due time and uses the same claim, so two instances never retry the same job together. A run stays failed after the last try, until the next due time.

### Overlap
When a run is still busy at the next due time, the new run is skipped and a warning is logged. Set `AllowOverlap` to let them run together. A busy claim older than `DeadAfter` counts as dead, so a crashed instance does not block the job forever.

### Missed runs
When an instance starts and a due time passed, the job runs once, not once for every missed time. Set `MissedRuns` to `Skip` to wait for the next due time instead. Write service requests that are safe to run more than once.

### Time zones
Set `TimeZoneId` per job. The cron library Cronos handles daylight saving time. Read its documentation for what a job does when a local time happens twice or not at all.

### Trigger a job by hand
`ICatJobRunner.RunAsync(jobName)` runs a job at once, with its retry setting and the system user. It does not claim a due time. Use it in a development endpoint to try a job without waiting for the schedule.

```csharp
app.MapPost("/development/jobs/{name}", async (string name, ICatJobRunner runner, CancellationToken token) =>
    (await runner.RunAsync(name, token)).Status.ToString());
```

If the service request already has its own endpoint, as in the demo, that is enough. The result holds the `Status`, the `ErrorCode` and the number of `Attempts`.

### Tracing and metrics
- Every run starts an activity `Cat.Scheduling.Run <job name>` under the source `Cat.Scheduling`.
- The meter `Cat.Scheduling` has the counter `cat.scheduling.runs`, with the tags `job` and `status`, and the gauge `cat.scheduling.last_run`, the time of the last finished run per job in seconds since 1970.
- Alert on a failed count that grows, or on a last run that is too old.

### Test your jobs
The module reads time from `TimeProvider`. Register a `FakeTimeProvider` of `Microsoft.Extensions.TimeProvider.Testing` before `AddCatScheduling` and move the clock. Test the request handler itself like any other handler.
<!-- region end: Usage-->
