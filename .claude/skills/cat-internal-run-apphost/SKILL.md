---
name: cat-internal-run-apphost
description: Start, check and stop the Aspire AppHost of the demo with the Aspire CLI, without breaking Docker Desktop. Use when a task needs the demo running, such as a live test, the emulator tests or a look in the dashboard.
argument-hint: "[start|status|stop]"
---

# Run the AppHost

These steps are for Claude only. A developer starts the AppHost with `dotnet run`, as the demo readme says. Do not put these commands in the demo readme.

Claude needs the Aspire CLI for this: `dotnet tool install --global Aspire.Cli`. A PowerShell session that was open before the install needs its PATH refreshed.

## Start
1. Run `docker info` once. The laptop of the owner does not always have Docker Desktop running. When it fails, ask the owner to start Docker Desktop and wait for the answer. Never poll.
2. Check that no instance runs yet with `aspire ps`.
3. Start it from the root of the repository, because the path is relative:
   ```
   aspire start --apphost demo/Cat.Demo.AppHost/Cat.Demo.AppHost/Cat.Demo.AppHost.csproj --launch-profile http
   ```
4. The services take a while to become healthy. Look with `aspire describe` and read the logs with `aspire logs`. Do not loop on it.

## Rules
- Never use `--isolated`. It randomizes the ports and the user secrets, and the demo needs its fixed ports (Catalog 5101, Inventory 5103, Payment 5105, Orders 5106, the emulator on 5300).
- Never run the AppHost in the foreground (`aspire run`, `dotnet run --project ...AppHost`). It blocks the shell.
- After a change in the AppHost code, run the start command again. It replaces the previous instance.
- The detached AppHost does not watch the source files. After a change in a service, start again.

## Stop
- Stop it with `aspire stop`, and do it when the task is done.
- Never kill dotnet, dcp or container processes, never `docker rm -f`, and never chain `docker ps` onto a stop command. Force-killing hung Docker Desktop twice, and only a graceful stop left no containers behind.
- Never build `Debug` while it runs. Aspire starts the services with `dotnet run --no-build --configuration Debug`, and the locked files give about 200 errors (MSB3021, MSB3027). The Debug output also loses `runtimeconfig.json`. The `Test` target builds Release and still works.

## Emulator tests
`tests/Cat.Messaging.Tests/EmulatorTests.cs` needs the AppHost running. Start it, run `dotnet test tests/Cat.Messaging.Tests --filter "TestCategory=Emulator"`, and stop it before a Debug build.

## Telemetry
The CLI sends usage data to Microsoft. The owner opted out with the user environment variable `ASPIRE_CLI_TELEMETRY_OPTOUT=1`.
