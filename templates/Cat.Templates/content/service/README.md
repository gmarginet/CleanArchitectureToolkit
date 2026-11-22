# ServiceName

A service made with the `cat-service` template of the Clean Architecture Toolkit.

## Projects
- `ServiceName.Api`: the host. It wires the modules, maps the endpoints and the health checks.
- `ServiceName.CoreService`: the service request handlers, the queries, the commands and the validators. It only references abstractions of the CAT modules.
- `ServiceName.Infrastructure`: the database context and the handlers that use it.
- `ServiceName.Contracts`: the service requests and the models that callers use. It targets `netstandard2.0`.
- `ServiceName.DataModels`: the entities.
<!--#if (DatabaseFirst)-->
- `ServiceName.Database`: the schema of the database, see Database first.
<!--#endif-->
<!--#if (Tests)-->
- `ServiceName.CoreService.Tests`: the unit tests of the core service.
<!--#endif-->
<!--#if (ApiClient)-->
- `ServiceName.Api.Client`: the generated client that other services use to call this service. It targets `netstandard2.0`.
<!--#endif-->

## Run it
1. Fill in the connection string `servicelower` in `ServiceName.Api/appsettings.json`, or set `ConnectionStrings__servicelower` as an environment variable.
2. Run `dotnet run --project ServiceName.Api`.
<!--#if (DatabaseFirst)-->
3. Create the tables of `ServiceName.Database` in the database. The service never changes the schema itself.
<!--#else-->
3. In development the service creates its tables from the model when it has no migrations yet. Add the first migration with `dotnet ef migrations add Initial --project ServiceName.Infrastructure --startup-project ServiceName.Api`, and the service applies migrations from then on.
<!--#endif-->
<!--#if (ExampleRequest)-->
4. Try the example request in `ServiceName.Api/ServiceName.http`. It reads one row of the table `ExampleItem`. Replace the example with the requests of your service.
<!--#endif-->

<!--#if (Messages)-->
## Message handlers
`ServiceName.Api/Extensions/MessageHandlerExtensions.cs` wires `Cat.EventProcessor` with Azure Service Bus, the only transport. The service receives `ExampleReceived`, and `ExampleReceivedHandler` in the core service handles it. It does nothing yet, so replace both with your own messages. Every message type has the inbox on, so a message that arrives twice is handled once. The table `CatInbox` is in the database of the service. The inbox row is saved together with the work of the handler, in one `SaveChanges`. The example handler saves nothing, so it leaves no row, and a handler of yours that writes to the database saves through its context.
<!--#if (DatabaseFirst)-->
The table `CatInbox` is one of the files of `ServiceName.Database`.
<!--#endif-->

The service does not start until you fill in the connection string `messaging` in `ServiceName.Api/appsettings.json`. For development, run the Azure Service Bus emulator and use its connection string. In the AppHost, the emulator is one line, and the AppHost then gives the service the connection string `messaging`:

```csharp
var messaging = builder.AddAzureServiceBus("messaging").RunAsEmulator();
// Add .WithReference(messaging) to the line that adds this service.
```

The sender of a message creates its topic. In development the service creates its own subscription on that topic at startup, and it creates the topic of the example message too, because nothing sends that message yet. Remove that line from `InitializeServiceShortMessageHandlersAsync` when a real sender creates the topic. The module readme of `Cat.EventProcessor` has the rest.

<!--#endif-->
<!--#if (Jobs)-->
## Scheduled jobs
`ServiceName.Api/Extensions/SchedulerExtensions.cs` switches `Cat.Scheduling` on. Every night at 02:00 UTC it sends `ExampleJobRequest` as the system user `servicelower`, and `ExampleJobRequestHandler` in the core service handles it. It does nothing yet, so replace it with the work of your job. Each run claims a row in the table `CatJobRun`, so two instances of the service never run a job twice. `CatScheduling:Jobs:example-job:Cron` in `appsettings.json` changes the time. The module readme of `Cat.Scheduling` has the rest.
<!--#if (DatabaseFirst)-->
The table `CatJobRun` is one of the files of `ServiceName.Database`.
<!--#endif-->

<!--#endif-->
<!--#if (DatabaseFirst)-->
## Database first
The schema is SQL, one file per table, and the entities are scaffolded from it. `ServiceName.DataModels` holds the entities and `ServiceName.Infrastructure` holds the context.
<!--#if (SqlServer)-->
The schema is the SDK-style SQL project `ServiceName.Database` with the `Microsoft.Build.Sql` SDK. Build it to check the schema, and publish the `.dacpac` it makes with `sqlpackage` or with `AddSqlProject` in the AppHost.
<!--#else-->
The `Microsoft.Build.Sql` SDK only builds SQL Server schemas, so on PostgreSQL the schema is the plain scripts in `ServiceName.Database/Scripts`. Run them by hand:

```
psql "postgresql://user:password@localhost:5432/servicelower" -f ServiceName.Database/Scripts/ExampleItem.sql
```
<!--#endif-->

Scaffold the entities and the context again after a change of the schema:

```
<!--#if (SqlServer)-->
dotnet ef dbcontext scaffold "<connection string>" Microsoft.EntityFrameworkCore.SqlServer --project ServiceName.Infrastructure --startup-project ServiceName.Api --context ServiceShortDbContext --context-dir DataAccess --output-dir ../ServiceName.DataModels/Entities --namespace ServiceName.DataModels.Entities --context-namespace ServiceName.Infrastructure.DataAccess --force
<!--#else-->
dotnet ef dbcontext scaffold "<connection string>" Npgsql.EntityFrameworkCore.PostgreSQL --project ServiceName.Infrastructure --startup-project ServiceName.Api --context ServiceShortDbContext --context-dir DataAccess --output-dir ../ServiceName.DataModels/Entities --namespace ServiceName.DataModels.Entities --context-namespace ServiceName.Infrastructure.DataAccess --force
<!--#endif-->
```

<!--#endif-->
## Versions
`Directory.Packages.Cat.props` holds the version of the CAT packages in the property `CatVersion`, and the versions of the packages that follow .NET for `TARGET_FRAMEWORK`. Change the versions in that one file. `Directory.Packages.props` imports it. A solution that already has its own `Directory.Packages.props` needs the same import line. A service made with `--NewSolution false` merges its versions into `Directory.Packages.Cat.props` with a script, see the readme of the templates.

## Without Aspire
The template holds no Aspire code. `Program.cs` calls `Cat.Telemetry` and `Cat.Resilience` directly, as their module readmes show for a project without Aspire. Point `OTEL_EXPORTER_OTLP_ENDPOINT` at your collector to send the telemetry.

With Aspire, call `AddServiceDefaults()` of your own `ServiceDefaults` project in `Program.cs` instead of the telemetry, health check and resilience lines. Then add the service to the AppHost:

```csharp
<!--#if (SqlServer)-->
var database = builder.AddSqlServer("sql").AddDatabase("servicelower");
<!--#else-->
var database = builder.AddPostgres("postgres").AddDatabase("servicelower");
<!--#endif-->
// Aspire writes the dots of the project name as underscores in the name of the Projects class.
builder.AddProject<Projects.ServiceName_Api>("servicelower").WithReference(database).WaitFor(database);
```
