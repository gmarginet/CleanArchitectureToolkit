---
name: cat-add-telemetry
description: Add an own source, meter or exporter to the telemetry of a service with Cat.Telemetry. Use when the developer wants a custom trace, a metric, an exporter, or says "add telemetry" or "add a meter".
---

# Add telemetry

`Cat.Telemetry` sets up the traces, metrics and logs of a service. This skill adds to what is there.

## Before you start
1. Find the service. It is the folder with the `*.CoreService` project. When the solution holds more than one service, ask which one.
2. Read the chapters "Set up the telemetry of a service", "Names of the sources, the meters and the tags", "Add your own source, meter or exporter", "Personal data" and "Tests" in the readme of `Cat.Telemetry`. The readme is `modules/Cat.Telemetry/README.md` when the solution references the module as a project. Otherwise it is `README.md` in `~/.nuget/packages/gmarginet.cat.telemetry/<version>/`, with the version from `CatVersion` in `Directory.Packages.Cat.props`. The readme is the truth. Follow it when it and this skill disagree.

## Steps
1. Ask what to measure or trace, and where it goes. A service made with `cat-service` calls `Cat.Telemetry` in `Program.cs`. A service with Aspire may set it up in its `ServiceDefaults`. Find which one before you add anything.
2. Name the source or meter by the convention of "Names of the sources, the meters and the tags". Follow the names that the module uses.
3. Add the source, the meter or the exporter with the call that "Add your own source, meter or exporter" shows. Add it where the service sets up the telemetry, not in a handler.
4. Use the source or the meter where the work happens. Keep the core service clean: hold the `ActivitySource` or `Meter` in a small class that the handler gets through its constructor.
5. Add a test as "Tests" shows.
6. Run `dotnet build` and `dotnet test`. Fix what fails.

## Rules
- Never put personal data in a tag or a trace. Read "Personal data" first.
- Keep the tags few and with a small set of values, because each new value costs storage in the backend.
