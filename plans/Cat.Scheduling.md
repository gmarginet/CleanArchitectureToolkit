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
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catscheduling)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
- [Phase 1](#phase-1)
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
- A saga needs timeouts, such as "cancel after 24 hours without payment". The scheduler looks for instances whose wait is over and resumes them with a timeout result.
- That is a moment stored next to the data, not a fixed recurring job. It is a different kind of schedule from a nightly job.

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
<!-- region end: PhaseDescription-->

### Open Questions
Every question has a recommendation. The recommendations are not decisions. They fit with each other, so the owner can say yes or no to each one.

<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Which kinds of schedule belong in this module? There are recurring jobs (cron like) and one-off moments (a timeout 24 hours from now). Do both belong here, or only recurring jobs in the first version?

Recommendation: only recurring jobs. A one-off moment is better done by the bus. Azure Service Bus can hold a message until a given time, so Orders sends a "payment expired" message when it places an order, and the event processor delivers it as a service request after 24 hours. The bus keeps the timer, it survives a restart, and with several instances only one gets the message. The handler first checks the order, and does nothing when it was paid, which is how it must work anyway, since the handlers are idempotent. This asks `Cat.Messaging` for scheduled messages, see the scheduled delivery question in [Cat.Messaging.md](Cat.Messaging.md). It also changes the assumption in [Cat.Sagas.md](Cat.Sagas.md) that the scheduler looks for instances past their timeout. Cost: a saga timeout depends on the messaging module, and a scheduled message cannot easily be changed once it is sent.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Where do schedules live: in code, in configuration, or stored in a database? Can a job be switched off per environment, for example in development?

Recommendation: in code, with an override in configuration. The `Scheduler` project of the service declares its jobs and a default cron expression, in the style of the endpoints of an API. `appsettings` can change the expression or switch a job off with an enabled flag per environment. In development the development endpoint triggers a run by hand. A database is not needed for the first version. Cost: a change of a schedule in production needs a configuration change, which is fine.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Which scheduling library, if any, do we build on? Do we build on an existing one, or write the small part we need?

Recommendation: use a small parser and write our own loop. `Cronos` parses cron expressions, gives the next time and knows time zones. Check its target framework, its licence and that it is maintained. Do not build on Quartz.NET or Hangfire. They bring their own storage and concepts, which fits badly with a toolbox of small parts.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
How do we make sure only one instance runs a job when a service has several instances? A database lock, a blob lease or a bus message? What do we run in Container Apps?

Recommendation: a claim in the database of the service. Before a run, an instance inserts a row with the job name and the due time, with a unique key on the two. The instance whose insert succeeds runs the job, and the others skip it. This costs one table, and it gives the run history and the missed run check for free, see the next questions. Put it behind a small interface, so a blob lease can follow later. A service without a database, or one that runs one instance, uses an in-memory version. A blob lease needs a storage account and a bus message needs a sender that is itself only once, so both are heavier. Azure Container Apps also has cron jobs as a separate kind of resource. They are not a worker in the API, so they do not fit this module. The worker runs inside the API, as decided, so there is no separate job resource.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
If the service was down at midnight, does the job run on startup? What happens after a missed run?

Recommendation: run it once on startup when the due time passed. Not once for every missed time. Make it a setting per job, `RunOnce` or `Skip`, with `RunOnce` as the default, since service requests of a schedule must be safe to run more than once, as the counter cleanup is. The claim table tells the module what was missed.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
What if a run is still busy when the next is due?

Recommendation: skip the new run and write a warning to the log. Two runs of one job at the same time are rarely what a developer wants. A setting can allow it. The claim row has a status, so the module knows a run is busy. A crashed instance would leave the row busy for ever, so the row needs a time after which it counts as dead.
<!-- region end: Question 6-->

<!-- region start: Question 7-->
#### Question 7
A failed `ICatResponse` means what for the schedule: try again soon, wait for the next run, or alert?

Recommendation: wait for the next run by default. Log the failed response with its error codes and count it in a metric, which is the alert. A setting per job, such as a retry after some minutes, can come later. Immediate retries risk a storm against a broken dependency. The bus is not involved, so the retry rules of the event processor do not apply.
<!-- region end: Question 7-->

<!-- region start: Question 8-->
#### Question 8
Does the module keep run history and the next due time? Where? Is run history something the module must store?

Recommendation: keep the small amount that the claim needs: the job, the due time, the status, the start and end time and the error code. It lives in the service database in an optional project that uses EF Core, like the outbox, and the module works without it in memory. The next due time is computed from the cron expression and is not stored. A rich history screen is not the job of the module. Where the notifications service stores its own data is a separate decision, see the demo plan.
<!-- region end: Question 8-->

<!-- region start: Question 9-->
#### Question 9
Which user does a scheduled service request run as? A system user, or a client credentials token?

Recommendation: both, for different things. Inside the service the request runs as a named system user, such as the service name, so `ICatUser` always has a value, see [Cat.Authorization.md](Cat.Authorization.md). A client credentials token is only for calls to other services, as the demo plan says, and the owner decided that a system that sends messages without a user has its own token, see [Cat.EventProcessor.md](Cat.EventProcessor.md). The Keycloak realm of the demo has no client for that yet. The scheduler module needs to know nothing about the token. The client call that sends it does.
<!-- region end: Question 9-->

<!-- region start: Question 10-->
#### Question 10
Does a run show up in traces, and does a missed run show up in health checks?

Recommendation: every run starts a trace activity with the job name, under the source name `Cat.Scheduling`, so it shows in the dashboard like the other CAT modules. The service request inside it is traced already. A health check is optional: unhealthy when a job has not run for twice its interval. The metric with the time of the last run is cheaper and it is enough at first.
<!-- region end: Question 10-->

<!-- region start: Question 11-->
#### Question 11
Do we use `TimeProvider`, so tests can move time?

Recommendation: yes. It is the standard way. Tests use `FakeTimeProvider` of Microsoft, see [Cat.UnitTesting.md](Cat.UnitTesting.md).
<!-- region end: Question 11-->

<!-- region start: Question 12-->
#### Question 12
Which time zones must we support besides UTC?

Recommendation: any time zone of `TimeZoneInfo`, set per job, with UTC as the default. Daylight saving makes a local time happen twice or not at all, so the docs must say what a job does then. `Cronos` handles it.
<!-- region end: Question 12-->

<!-- region start: Question 13-->
#### Question 13
Do we build the timeout part together with `Cat.Sagas`, or first?

Recommendation: neither. Timeouts wait for scheduled messages in `Cat.Messaging`. This module goes first with recurring jobs, because the demo needs the counter cleanup.
<!-- region end: Question 13-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->