---
name: cat-add-job
description: Add a scheduled job with its configuration and a test using Cat.Scheduling. Use when the developer wants a recurring task, a nightly job, a cron schedule, or says "add a job".
---

# Add a scheduled job

A job sends a service request on a schedule as the system user. Each run claims a row in the database, so two instances never run it twice.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Switch the scheduler on", "Declare a job", "Change a job in the configuration", "The system user", "Run on more than one instance" and "Test your jobs" in the readme of `Cat.Scheduling`. The readme is `modules/Cat.Scheduling/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.scheduling/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.
3. Run `dotnet new list cat-`. When it shows nothing, stop and show `dotnet new install gmarginet.Cat.Templates`. Run it only when the developer says yes. Never write a file that a template writes.

## Steps
1. Ask what the job does and how often. Turn the schedule into a cron expression and say it back in words, with the time zone.
2. A service made with `--Jobs true` has the scheduler already, in `Extensions/SchedulerExtensions.cs`, with one example job. Otherwise switch it on as "Switch the scheduler on" says, and add the table `CatJobRun`. Database first services get it from `dotnet new cat-jobrun-table --Database <SqlServer|PostgreSQL>`, run in the folder of the solution.
3. The work of the job is a service request with a handler. Add it with `cat-add-service-request`, and name it for the work, such as `OrderCleanupJobRequest`.
4. Declare the job as "Declare a job" shows, following the line of the example job. Put the cron expression in `appsettings.json` under `CatScheduling:Jobs`, so it changes without a build.
5. Add a test of the job as "Test your jobs" shows.
6. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- The job runs as the system user. Check that the handler needs no more than that user may do.
- The handler must be safe to run twice, because a retry can run it again.
