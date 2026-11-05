# Plans for Cat.Scheduling

Worker support that turns schedules into service requests.  
Status: not started. This plan collects what we know. The open questions need an answer before the build.

## Contents

- [The idea](#the-idea)
- [What we already know](#what-we-already-know)
- [Decisions and open questions](#decisions-and-open-questions)
- [Questions before building](#questions-before-building)

## The idea

Some work starts because time passed, not because someone asked. A nightly cleanup, a periodic import, an order that stays unpaid for 24 hours. The service project structure has a place for it: the optional `ServiceName.Scheduler` project.

`Cat.Scheduling` is the code behind that project. It runs on a schedule. Every run becomes a service request that the core handles. The worker holds no business logic.

## What we already know

From the root readme:

- The scheduler is a worker, not a host. It lives in its own project and runs inside the API.
- It runs work on a schedule, like a nightly cleanup or a periodic import. Every run triggers a service request.
- It is optional.
- In debug mode the API has a development endpoint group with a sub group per worker. The scheduler endpoint simulates a trigger.

From the demo plan:

- Clean up the daily order counters every night, shortly after midnight UTC. The `CleanUpOrderCounters` service request exists already. Until the scheduler exists, a development endpoint triggers it. The request can run any time and more than once.
- Cancel unpaid orders after 24 hours.
- A nightly low stock report.
- The notifications service runs the scheduled jobs. Where it stores its data is decided once this module is designed.
- Work without a user, such as the scheduler, uses a client credentials token.

From the saga plan:

- A saga needs timeouts, such as "cancel after 24 hours without payment". The scheduler looks for instances whose wait is over and resumes them with a timeout result.
- That is a moment stored next to the data, not a fixed recurring job. It is a different kind of schedule from a nightly job.

From the architecture:

- Services run as containers in Azure Container Apps. A service can run several instances, so a job must not run twice at the same time.

## Decisions and open questions

### Decided

| Topic | Decision |
|---|---|
| Hosting | A worker that runs inside the API of the service. |
| Work | One run becomes one service request. |
| Business logic | None in the worker. |
| Time zone | The demo counter cleanup uses UTC. |
| Testing | A development endpoint triggers a run, in debug mode only. |

### Open

- **Two kinds of schedule.** Recurring jobs (cron like) and one-off moments (a timeout 24 hours from now). Do both belong in this module?
- **Definition.** Are schedules written in code, in configuration, or stored in a database?
- **Cron library.** Build on an existing one, or write the small part we need?
- **Several instances.** How do we make sure one instance runs a job? A database lock, a blob lease or a bus message?
- **Missed runs.** If the service was down at midnight, does the job run on startup?
- **Overlap.** What if a run is still busy when the next is due?
- **Failure.** A failed `ICatResponse` means what for the schedule: try again soon, wait for the next run, or alert?
- **Storage.** Does the module keep run history and the next due time? Where?
- **Identity.** Which user does a scheduled request run as? A system user, or a client credentials token?
- **Health and tracing.** Does a run show up in traces, and does a missed run show up in health checks?
- **Time.** Use `TimeProvider`, so tests can move time.

## Questions before building

1. Do we want recurring jobs only in the first version, or also one-off timeouts?
2. Where do schedules live: in code, in `appsettings` or in the database?
3. Which scheduling library, if any, do we build on?
4. How do we stop two instances from running the same job? What do we run in Container Apps?
5. What should happen after a missed run or a failed run?
6. Is run history something the module must store? If yes, where, and how does it connect to the notifications data decision?
7. Which time zones must we support besides UTC?
8. Which user identity does a scheduled service request get?
9. Should jobs be configurable per environment, for example switched off in development?
10. Do we build the timeout part together with `Cat.Sagas`, or first?
