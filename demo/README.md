# Demo

A small bookshop that shows how the Clean Architecture Toolkit modules work together.  
The full plan is in [DemoPlan.md](DemoPlan.md).

## Contents

- [What is here](#what-is-here)
- [Run the Catalog service](#run-the-catalog-service)
- [Try the endpoints](#try-the-endpoints)
- [Run the tests](#run-the-tests)

## What is here

| Folder | What it is |
|---|---|
| `Cat.Demo.CatalogService` | Books, categories and prices. The first service of the plan. |

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

## Run the tests

Run all tests of the repository, including the demo tests:

```
dotnet cake --target=Test
```
