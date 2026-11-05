# Demo

A small bookshop that shows how the Clean Architecture Toolkit modules work together.  
The full plan is in [DemoPlan.md](../plans/DemoPlan.md).

## Contents

- [What is here](#what-is-here)
- [Run the Catalog service](#run-the-catalog-service)
- [Try the endpoints](#try-the-endpoints)
- [Run the Order service](#run-the-order-service)
- [Health checks and telemetry](#health-checks-and-telemetry)
- [Run the tests](#run-the-tests)

## What is here

| Folder | What it is |
|---|---|
| `Cat.Demo.CatalogService` | Books, categories and prices. The first service of the plan. |
| `Cat.Demo.OrderService` | Customers place and track orders. The place order process is a workflow. |
| `Cat.Demo.ServiceDefaults` | Shared defaults of the services: telemetry, health checks, service discovery and resilient HTTP clients. Only the demo uses it, never the CAT modules. |

More services, the Aspire AppHost and the React client follow. See the plan.

## Run the Catalog service

For now Catalog needs a SQL Server it can reach. A local instance, LocalDB or a container all work. Temporal tables need SQL Server, so SQLite and PostgreSQL do not.

1. Check the connection string in `Cat.Demo.CatalogService/Cat.Demo.CatalogService.Api/appsettings.Development.json`. The default points to the local default instance:
   ```
   Server=.;Database=catalog;Trusted_Connection=True;TrustServerCertificate=True
   ```
2. Start the service from the root of the repository:
   ```
   dotnet run --project demo/Cat.Demo.CatalogService/Cat.Demo.CatalogService.Api
   ```
3. Open `http://localhost:5101`.

In `Development` the service applies the EF Core migrations at startup. It then adds 4 categories and 7 books when the tables are empty.

The OpenAPI document is at `http://localhost:5101/openapi/v1.json`.

## Try the endpoints

Open `Cat.Demo.CatalogService/Cat.Demo.CatalogService.Api/CatalogRequests.http` in Visual Studio or Rider. Run the requests from top to bottom. Later requests use ids from earlier responses.

## Run the Order service

Orders needs its own SQL Server database, like Catalog. The Catalog service does not have to run.

1. Check the connection string in `Cat.Demo.OrderService/Cat.Demo.OrderService.Api/appsettings.Development.json`:
   ```
   Server=.;Database=orders;Trusted_Connection=True;TrustServerCertificate=True
   ```
2. Start the service from the root of the repository:
   ```
   dotnet run --project demo/Cat.Demo.OrderService/Cat.Demo.OrderService.Api
   ```
3. Open `http://localhost:5102`.

In `Development` the service applies the EF Core migrations at startup and adds the three order statuses.

Things to know:

- **No login yet.** The `X-Demo-User` header picks the user: `alice` (the default), `bob` or `admin`. Alice and Bob only see their own orders. The real login comes with the gateway and Keycloak.
- **Fakes for the other services.** Prices, stock and payment are fakes, because Catalog, Inventory and a payment provider are not connected yet.
  - The price of a book is made from its id, between 5.95 and 44.95 euro.
  - A line of more than 50 copies is out of stock.
  - A total above 500 euro is declined.
- **Order numbers** look like `20261105-0001`. The counter restarts every UTC day. The development endpoint `POST /development/scheduler/clean-up-order-counters` removes the counters of earlier days. The scheduler will do that every night.

Open `Cat.Demo.OrderService/Cat.Demo.OrderService.Api/OrderRequests.http` in Visual Studio or Rider and run the requests from top to bottom.

## Health checks and telemetry

Both services use `Cat.Demo.ServiceDefaults`.

- **Health checks.** `/health` is the readiness check and `/alive` the liveness check. Both are available in every environment and answer with a plain `Healthy` or `Unhealthy`.
- **Telemetry.** Logs, metrics and traces go through OpenTelemetry. They are exported when `OTEL_EXPORTER_OTLP_ENDPOINT` is set, which the Aspire AppHost will do. Without it nothing leaves the process.
- **Traces of the CAT modules.** The wildcard source `Cat.*` covers the service request decorator and the workflows.
- **HTTP clients.** Every `HttpClient` gets service discovery and the standard resilience handler: retries, timeouts and a circuit breaker.

## Run the tests

Run all tests of the repository, including the demo tests:

```
dotnet cake --target=Test
```
