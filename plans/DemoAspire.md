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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Aspire plan

This plan covers the first Aspire AppHost of the demo.  
It is part of [Demo.md](Demo.md). The demo plan says what Aspire hosts. This plan says how we build it, in which order.

## Contents

- [The goal](#the-goal)
- [Decisions](#decisions)
- [Starting point](#starting-point)
- [Projects](#projects)
- [How the AppHost works](#how-the-apphost-works)
- [Swapping the price provider](#swapping-the-price-provider)
- [Phases](#phases)
- [Later](#later)
- [Open questions](#open-questions)

## The goal

One command starts the whole demo, and the Aspire dashboard shows it.

- Catalog and Orders run as projects.
- They get their connection strings and service URLs from the AppHost.
- Logs, traces, metrics and health checks are in the dashboard.
- Orders asks Catalog for the current price of every book, instead of using the fake.

React, the gateway, Keycloak, the Service Bus and Inventory are not part of this build. See [Later](#later).

## Decisions

| Topic | Decision |
|---|---|
| Names | `Cat.Demo.AppHost` and `Cat.Demo.ServiceDefaults`, each in its own folder in `demo/`. |
| SQL Server | Two modes, switched by one AppHost setting: `Container` and `Existing`. See [How the AppHost works](#how-the-apphost-works). |
| First mode to build | `Existing`, because Docker and WSL are not installed on the owner's machine. `Container` follows in its own phase. |
| Standalone start | Every service still starts with `dotnet run` and its own `appsettings`. The AppHost is a convenience, not a requirement. |
| Price provider | The first version is a plain `HttpClient` implementation in `Orders.Infrastructure`. `Cat.Api.Client` replaces it in the future. See [Swapping the price provider](#swapping-the-price-provider). |
| Service to service calls | Orders calls Catalog directly for now, because the gateway does not exist yet. |
| Contracts | Orders keeps its own small model of the price response and does not reference `Catalog.Contracts`. This is a choice, not a rule: Orders needs only the price, so it stays independent of the rest of the Catalog contract. A later service to service call shares contracts, so the demo shows both. See [Sharing contracts](Demo.md#sharing-contracts). |
| Aspire version | The latest stable Aspire that supports .NET 10. Pin it in `Directory.Packages.props` when the projects are created. |

## Starting point

- Catalog and Orders are code first and apply their EF Core migrations at startup in `Development`.
- Both read their database from the connection strings `catalog` and `orders`. These are the names the AppHost will use as well, so the services do not change for it.
- Both have an `IsDevelopment` seeder and fixed launch profile ports: Catalog 5101, Orders 5102.
- The `.http` files use those ports.
- Orders registers `FakePriceProvider` in `Orders.Infrastructure`.
- This machine has no Docker and no WSL. `Container` mode cannot run here until the owner installs them.

## Projects

Follow the `demo-structure` skill. It also keeps `CleanArchitectureToolkit.slnx` in sync.

```
demo/
  Cat.Demo.AppHost/
    Cat.Demo.AppHost/
  Cat.Demo.ServiceDefaults/
    Cat.Demo.ServiceDefaults/
```

- **ServiceDefaults.** The standard Aspire project: telemetry, health checks, service discovery and the resilience handler for `HttpClient`.
- **AppHost.** Describes the system. It references the Api project of each service.
- **Service changes.** Each Api project references ServiceDefaults and calls `AddServiceDefaults()` and `MapDefaultEndpoints()`. Nothing else in the services changes.
- **Modules.** No module may reference Aspire or ServiceDefaults. Only the demo does.

## How the AppHost works

### SQL Server modes

A setting in the AppHost configuration, `Sql:Mode`, picks one of two modes.

| Mode | What happens | Needs |
|---|---|---|
| `Existing` | The AppHost passes the connection strings `catalog` and `orders` from its own configuration to the services. | A SQL Server the services can reach, such as the local instance they use today. |
| `Container` | The AppHost starts a SQL Server container with a data volume, creates the databases `catalog` and `orders` and passes their connection strings. | Docker. |

- In `Existing` mode the AppHost reads `ConnectionStrings:catalog` and `ConnectionStrings:orders`. The defaults are the strings that sit in the `appsettings.Development.json` of the services.
- The default mode is `Container`, because a clone should need one command. The owner sets `Existing` in the user secrets of the AppHost until Docker is installed.
- The services see no difference. They always read `GetConnectionString("catalog")` and `GetConnectionString("orders")`.
- In `Container` mode the AppHost limits the memory of SQL Server with `MSSQL_MEMORY_LIMIT_MB`, as described in the demo plan.

### Start order

- In `Container` mode the services wait for their database. The AppHost makes that explicit.
- Each service applies its migrations and seeds in `Development`, as it does today. The databases exist by then.
- Orders waits for Catalog, because it asks Catalog for prices.

### Ports

Decided: the AppHost keeps the fixed ports 5101 and 5102, with `WithHttpEndpoint(port: ...)` and no Aspire proxy. The `.http` files, the Orders to Catalog address and standalone runs all use the same ports. The dashboard runs on 15101 (OTLP on 19101 and the resource service on 20101), set in the launch profile of the AppHost.

## Swapping the price provider

`IPriceProvider` stays as it is. Only the class behind it changes.

**Phase 1: plain HttpClient.** This is the version we build now.

- A new class `CatalogPriceProvider` in `Orders.Infrastructure`, using a typed `HttpClient`.
- The base address comes from Aspire service discovery. The AppHost gives Orders a reference to Catalog.
- It calls `GET /catalog/books/prices?bookIds=<id>` with one `bookIds` value per book.
- It reads the response into a small model that belongs to Orders. Orders does not reference `Catalog.Contracts`. That is a choice for this call, see [Sharing contracts](Demo.md#sharing-contracts).
- Responses map as follows:

| Catalog answers | `IPriceProvider` returns |
|---|---|
| 200 | An Ok response with the price of each book. |
| 404 | A failed response. The step already turns that into `PriceUnavailable`. |
| 400 or any other status | An error response. Orders never trusts a half answer. |
| Network error or timeout | An error response. |

- The resilience handler from ServiceDefaults adds retries and a circuit breaker to the call.
- Catalog reads are public, so no token is sent. Once Keycloak arrives, the call forwards the token.
- Registration picks the real provider only when the AppHost gives Orders a Catalog address. Without it, `dotnet run` keeps working with `FakePriceProvider`.
- A unit test per row of the table above, with a fake `HttpMessageHandler`. These tests need no database and no running service.
- The `IPriceProvider` summary and the demo plan still say that `Api.Client` implements it. Adjust both while building.

**In the future: `Cat.Api.Client`.**

- When the `Cat.Api.Client` module exists, `CatalogPriceProvider` is replaced by a typed client from the module, and the call goes through the gateway.
- Build the module from this working code, not up front. Then the design follows what we learned: how a client is declared, how the token is forwarded, how error responses map to `ICatResponse` and how it works with `Cat.Resilience`.
- Only the registration in `Orders.Infrastructure` changes. `IPriceProvider`, the workflow step and the tests stay.

## Phases

1. **ServiceDefaults.** Create the project. Both Api projects call it. Build and run both services standalone to check that nothing broke.
2. **AppHost, `Existing` mode.** (Built. The `.http` requests pass and the traces show in the dashboard.) Create the AppHost with Catalog and Orders. Both show up in the dashboard with logs, traces and health. Run every request of both `.http` files against the AppHost.
3. **Price provider.** Add `CatalogPriceProvider` and its tests. Place an order through the AppHost and check in the dashboard that the Catalog call is part of the trace.
4. **AppHost, `Container` mode.** Needs Docker on the machine. Add the SQL Server container, the data volume and the databases. Check a fresh start from an empty volume and a restart that keeps the data.
5. **Documents.** Update `demo/README.md` with the run steps for both modes and the Docker memory notes. Update [Demo.md](Demo.md).

Phase 4 can wait. Phases 1 to 3 do not need Docker.

## Later

These come after the first AppHost build, in the order of the demo plan.

- The `Cat.Api.Client` module, replacing `CatalogPriceProvider`.
- The API gateway, Keycloak, JWT validation in the services and the real `ICurrentUser`.
- The React client, started by the AppHost.
- The Service Bus emulator, with `Cat.Messaging`.
- Inventory, database first.

## Open questions

- **Tracing sources.** Settled in phase 1. ServiceDefaults adds the wildcard source `Cat.*`, which covers `Cat.ServiceRequests` and `Cat.FluentWorkFlows`. Check in phase 2 that the activities show up in the dashboard.
- **Phase 2 check.** Done for the requests: every request of both `.http` files gives the expected status under the AppHost, and both health checks answer. Seen in the dashboard: traces with the `Cat.ServiceRequests` and `Cat.FluentWorkFlows` sources.
- **ASPIRE010 warning.** The AppHost build warns that `AspireUseCliBundle` is false. Decide whether to set it to true or suppress the warning.
- **Development certificate.** The dashboard shows "No trusted development certificate was found" when the machine has not run `dotnet dev-certs https --trust`. It is harmless now, because the AppHost, the dashboard and the services all run on HTTP. It matters once HTTPS is used, for example with the gateway or Keycloak. Decide whether the run steps in `demo/README.md` (phase 5) tell a developer to trust the certificate, and whether the AppHost keeps `ASPIRE_ALLOW_UNSECURED_TRANSPORT`.
- **Existing mode and Trusted_Connection.** The default strings use Windows authentication. That works for a local process but not for a container. Fine for `Existing` mode, since nothing runs in a container there.
