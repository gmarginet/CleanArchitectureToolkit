# SystemName

A system made with the `cat-system` template of the Clean Architecture Toolkit. It holds an Aspire AppHost, `ServiceDefaults`, a YARP gateway and a first service, `SystemName.ServiceShort`, made with `cat-service`.

## Run it
Docker must run. Then start the AppHost:

```
dotnet run --project SystemName.AppHost
```

The AppHost starts:
<!--#if (SqlServer)-->
- a SQL Server container for the database of the service,
<!--#if (DatabaseFirst)-->
- the SQL project `SystemName.ServiceShort.Database`, which creates the tables in that database,
<!--#endif-->
<!--#else-->
- a PostgreSQL container for the database of the service,
<!--#if (DatabaseFirst)-->
- the scripts in `SystemName.ServiceShort.Database/Scripts`, which PostgreSQL runs the first time the container starts,
<!--#endif-->
<!--#endif-->
<!--#if (Messages)-->
- the Azure Service Bus emulator,
<!--#endif-->
- the service, and the gateway in front of it.

The Aspire dashboard shows the ports. The service is `servicelower`, and the gateway is `gateway`.

## The gateway needs an identity provider
`Cat.Api.Gateway` is closed by default. Every call needs a valid token, so the gateway rejects every call until you fill in your provider. Change these two values in `SystemName.Api.Gateway/appsettings.json`:

- `CatGateway:Authentication:Authority`: the address of your identity provider.
- `CatGateway:Authentication:Audience`: the audience of the tokens for the gateway.

The AppHost starts no identity provider. Get a token from yours, and send it as a bearer token to the gateway. Then call the service through the gateway. The gateway keeps the prefix, because the endpoints of the service are in the group `/servicelower`. With the example request, call `GET /servicelower/examples/{exampleId}`.

The health checks `/health` and `/alive` of the gateway need no token.

## What is where

| Project | What it does |
|---------|--------------|
| `SystemName.AppHost` | Starts the system for development. It holds the Aspire code. |
| `SystemName.ServiceDefaults` | Telemetry, health checks, service discovery and resilient HTTP clients. The gateway calls `AddServiceDefaults()`. |
| `SystemName.Api.Gateway` | The front door. It finds the service by name through service discovery. |
| `SystemName.ServiceShort.*` | The first service. Its own readme is `SystemName.ServiceShort.README.md`. |
