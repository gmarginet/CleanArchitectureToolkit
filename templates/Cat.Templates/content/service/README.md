# ServiceName

A service made with the `cat-service` template of the Clean Architecture Toolkit.

## Projects
- `ServiceName.Api`: the host. It wires the modules, maps the endpoints and the health checks.
- `ServiceName.CoreService`: the service request handlers, the queries, the commands and the validators. It only references abstractions of the CAT modules.
- `ServiceName.Infrastructure`: the database context and the handlers that use it.
- `ServiceName.Contracts`: the service requests and the models that callers use. It targets `netstandard2.0`.
- `ServiceName.DataModels`: the entities.
<!--#if (Tests)-->
- `ServiceName.CoreService.Tests`: the unit tests of the core service.
<!--#endif-->
<!--#if (ApiClient)-->
- `ServiceName.Api.Client`: the generated client that other services use to call this service. It targets `netstandard2.0`.
<!--#endif-->

## Run it
1. Fill in the connection string `servicelower` in `ServiceName.Api/appsettings.json`, or set `ConnectionStrings__servicelower` as an environment variable.
2. Run `dotnet run --project ServiceName.Api`.
3. In development the service creates its tables from the model when it has no migrations yet. Add the first migration with `dotnet ef migrations add Initial --project ServiceName.Infrastructure --startup-project ServiceName.Api`, and the service applies migrations from then on.
<!--#if (ExampleRequest)-->
4. Try the example request in `ServiceName.Api/ServiceName.http`. It reads one row of the table `ExampleItem`. Replace the example with the requests of your service.
<!--#endif-->

## Versions
`Directory.Packages.props` holds the version of the CAT packages in the property `CatVersion`, and the versions of the packages that follow .NET for `TARGET_FRAMEWORK`. Change the versions in that one file.

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
