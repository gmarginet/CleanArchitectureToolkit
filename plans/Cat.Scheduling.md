<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: .. -->
<link href="../resources/styles/style.css" rel="stylesheet" />
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
            <img src='../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-plan skill to update this plan.-->
<!-- region end: TemplateSkill-->

# Plans for `Cat.Scheduling` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![READY TO START BUILDING](https://img.shields.io/badge/Status-READY%20TO%20START%20BUILDING-green)](#plans-for-catscheduling)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
- [Phase 1](#phase-1)
- [Phase 2](#phase-2)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
A new module, `Cat.Scheduling`, with worker support that turns schedules into service requests.

#### The idea
Some work starts because time passed, not because someone asked. A nightly cleanup, a periodic import, an order that stays unpaid for 24 hours. The service project structure has a place for it: the optional `ServiceName.Scheduler` project.

`Cat.Scheduling` is the code behind that project. It runs on a schedule. Every run becomes a service request that the core handles. The worker holds no business logic.

#### Background
From the readme:
- The scheduler is a worker, not a host. It lives in its own project and runs inside the API.
- It runs work on a schedule, like a nightly cleanup or a periodic import. Every run triggers a service request.
- It is optional.
- In debug mode the API has a development endpoint group with a sub group per worker. The scheduler endpoint simulates a trigger.

From the demo plan:
- Clean up the daily order counters every night, shortly after midnight UTC. The `CleanUpOrderCounters` service request exists already. The request can run any time and more than once.
- Cancel unpaid orders after 24 hours.
- A nightly low stock report.
- The notifications service runs the scheduled jobs. Where it stores its data is decided once this module is designed.
- Work without a user, such as the scheduler, uses a client credentials token.

From the saga plan:
- A saga needs timeouts, such as "cancel after 24 hours without payment".
- That is a moment stored next to the data, not a fixed recurring job. It is a different kind of schedule from a nightly job, so it does not belong in this module. See the decision on timeouts below.

From the architecture:
- Services run as containers in Azure Container Apps. A service can run several instances, so a job must not run twice at the same time.

#### What exists today
- The module does not exist yet. It is listed in the repo overview of the readme with the status New.
- The `CleanUpOrderCounters` service request exists in the contracts of Orders, with its handler and tests. The counter cleanup command handler uses `TimeProvider`.
- Until the scheduler exists, the development endpoint `POST /development/scheduler/clean-up-order-counters` triggers the request. It only exists in the Development environment.
- Orders has no `Scheduler` project yet, and the Notifications service does not exist.
- The Keycloak realm of the demo has no client for a client credentials token yet.
- Nothing in the code uses a cron library such as `Cronos`.

#### Decided
- **Hosting.** A worker that runs inside the API of the service.
- **Work.** One run becomes one service request.
- **Business logic.** None in the worker.
- **Time zone.** The demo counter cleanup uses UTC.
- **Testing.** A development endpoint triggers a run, in debug mode only.
- **Kinds of schedule.** Only recurring jobs. A one-off moment, such as a saga timeout or "cancel after 24 hours", is done with a scheduled message of the bus, see [Cat.Messaging.md](../modules/Cat.Messaging/README.md) and [Cat.Sagas.md](Cat.Sagas.md). The handler of such a message first checks the order and does nothing when it was paid.
- **Library.** A small cron parser and our own loop. `Cronos` is the candidate: check its target framework, its licence and that it is maintained. No Quartz.NET and no Hangfire.
- **One instance runs a job.** A claim in the database of the service. Before a run an instance inserts a row with the job name and the due time, with a unique key on the two. The instance whose insert succeeds runs the job. It sits behind a small interface, so a blob lease can follow later. A service without a database, or with one instance, uses an in-memory version. Container Apps cron jobs do not fit, since the worker runs inside the API.
- **Missed runs.** A job runs once on startup when the due time passed, not once for every missed time. A setting per job, `RunOnce` or `Skip`, with `RunOnce` as the default. Service requests of a schedule must be safe to run more than once.
- **Overlap.** When a run is still busy at the next due time, the new run is skipped and a warning is logged. A setting can allow overlap. The claim row has a status, and a time after which a busy row counts as dead.
- **Run history.** The claim row keeps the job, the due time, the status, the start and end time and the error code. It lives in the service database in an optional project that uses EF Core, like the outbox, and the module works without it in memory. The next due time is computed from the cron expression and is not stored. A history screen is not the job of the module.
- **User.** A scheduled service request runs as a named system user, such as the service name, so `ICatUser` always has a value, see [Cat.Users.md](Cat.Users.md). A client credentials token is only for calls to other services. The module knows nothing about the token.
- **Tracing.** Every run starts a trace activity with the job name, under the source name `Cat.Scheduling`. A metric holds the time of the last run. A health check is optional.
- **Time.** The module uses `TimeProvider`, and tests use `FakeTimeProvider` of Microsoft, see [Cat.UnitTesting.md](Cat.UnitTesting.md).
- **Time zones.** Any time zone of `TimeZoneInfo`, set per job, with UTC as the default. The docs say what a job does when daylight saving makes a local time happen twice or not at all. `Cronos` handles it.
- **Where the jobs are declared.** The module holds a set of extension methods that the API project calls to configure the scheduled jobs, the same way as the API gateway and the event processor.
- **Override per environment.** `appsettings` can change the cron expression of a job or switch it off with an enabled flag per environment.
- **Failed runs.** By default a failed `ICatResponse` waits for the next run. The failed response is logged with its error codes and counted in a metric, which is the alert.
- **Retry in this phase.** A small retry setting per job in this module: a number of retries and a delay, with a growing delay as an option. The default is no retry. A failed run stays failed after the last retry until the next due time. A retry is a new run of the same due time and uses the same claim row, so two instances never retry the same job together. Retry through `Cat.Resilience` comes in phase 2.
- **Timeouts.** Not part of this module. They wait for scheduled messages in `Cat.Messaging`. This module goes first with recurring jobs, because the demo needs the counter cleanup.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
Retry of a failed scheduled run through `Cat.Resilience`.

#### Decided
- **Retry.** Retry of a failed run goes through `Cat.Resilience`, see [Cat.Resilience.md](Cat.Resilience.md). Phase 1 has a small retry setting per job in this module.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 14-->
#### Question 14
What happens to the retry setting of phase 1 when the retry goes through `Cat.Resilience`? The options:
- **The setting goes away.** A job gets its retry from the decorator of `Cat.Resilience`. Cost: a breaking change in the settings of the module, which is fine while it is in alpha.
- **The setting stays** as a short way to switch the decorator on for a job. Cost: two ways to do one thing.

Recommendation: the setting goes away. Two retry concepts in one module is what the owner wanted to avoid, and breaking changes are not an issue yet.
<!-- region end: Question 14-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->