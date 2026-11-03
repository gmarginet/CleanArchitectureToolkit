# Demo plan

This is a working plan for the demo application. Nothing here is final.  
The open decisions are listed at the end.

## The idea

Replace the todo demo with a small bookshop.  
A todo app is too limited to show every module. A bookshop is easy to understand, and it gives every current and future module a natural place.

## Services

| Service | Job |
|---|---|
| Catalog | Books, categories and prices. Mostly reads, with a bit of admin. |
| Orders | Customers place and track orders. This is the main service. |
| Inventory | Tracks stock and reserves it when an order comes in. |
| Notifications | Sends the order confirmed and order shipped messages. Runs the scheduled jobs. |

Start small. Catalog plus a basic Orders service already covers most of the current modules.

Catalog and Orders are built code first. Inventory is built database first, to show that the toolkit supports both. See [Database first service](#database-first-service).

## Where each module fits

| Module | Demonstrated by |
|---|---|
| Commands, Queries, ServiceRequests | `PlaceOrder`, `CancelOrder`, `GetOrder`, `SearchProducts` |
| Responses, Validators | Validating an order. Stock and payment failures come back as error responses. |
| Decorators | Logging, validation and tracing on every request. |
| Minimal.Api | The endpoints of each service. |
| FluentWorkflows | The place order process: validate, reserve stock, take payment, confirm. It has an `if` for out of stock and a `foreach` over the order lines. |
| EventAggregators | In-process events inside Orders, such as `OrderConfirmed` triggering a status update. |
| EFCore | Books and categories as reference data, orders as regular entities, price history as temporal data. |
| Localizations | Categories, order statuses and email texts in a few languages. |
| Expressions, Extensions | Used inside the services. |

### Future modules

| Module | Demonstrated by |
|---|---|
| Messaging, EventProcessor | Orders publishes `OrderPlaced`. Inventory and Notifications consume it. |
| Scheduling | Cancel unpaid orders after 24 hours. A nightly low stock report. |
| Api.Client | Orders asks Catalog for current prices through the gateway. |
| Dapper | Fast read-only order overview queries, next to EF Core for writes. |
| Caching | Cached catalog queries. |
| Transactions | Saving an order and its lines in one go. |
| Auditing | Who changed a price or cancelled an order. |
| Authorization | Customers see their own orders. Admins edit the catalog. |
| Resilience | Retry and circuit breaker on the payment call, which uses a fake provider. |
| Telemetry, Testing | Tracing one order across all services. The unit tests. |

## Client

Decision: **React** with TypeScript, built with Vite.

- Keeps the demo client-agnostic. The services expose a normal HTTP API.
- Most widely known option.
- No shared contracts with the services, so the client comes from the OpenAPI documentation that `Cat.Minimal.Api` produces.
- Keep it thin: a book list, a basket and an order overview.

Blazor WebAssembly was the alternative. It would share the `Contracts` projects, but it makes the demo look .NET only.

## Database

Proposal: **SQL Server in a container, started by the Aspire AppHost. Every service still reads its database from a connection string, so LocalDB or an existing instance also work.**

`Cat.EFCore` configures temporal tables, and only SQL Server supports them. So SQLite and PostgreSQL are out.

Aspire and Docker are also a good way for the owner to learn both, which is a reason to use them as the main path.

### Setup

One `AppHost` project in `demo/` describes the whole system:

- A SQL Server container with a volume, so data survives restarts.
- One database per service (`catalog`, `orders`, `inventory`).
- The .NET services.
- The React app.
- Later, the gateway and a Service Bus emulator.

Aspire passes connection strings and service URLs to each project. Nobody edits config files.

### What a user does after cloning

1. Install the .NET SDK, Node and Docker Desktop.
2. Run `dotnet run --project demo/Demo.AppHost`.
3. Open the Aspire dashboard, which links to the React app.

### Keeping the memory under control

Docker Desktop on Windows runs on WSL2. The VM can take up to half of the RAM by default and keeps it while it is running.

- Limit the VM in `C:\Users\<you>\.wslconfig`, for example `memory=4GB`. The limit covers the whole VM, including all containers.
- Limit SQL Server itself with `MSSQL_MEMORY_LIMIT_MB`.
- Only start Docker Desktop when running the demo. Afterwards quit it and run `wsl --shutdown`. That gives all the memory back to Windows.
- The readme of the demo explains these steps.

### Lighter alternative

For anyone who does not want containers, point the connection strings to LocalDB or an existing SQL Server instance. LocalDB is the real SQL Server engine, so temporal tables work. It needs no VM and stops by itself when idle. The services and the React app then start with `dotnet run` and `npm run dev`.

A plain `docker-compose.yml` with only SQL Server is a third option, for people who want a container but no Aspire.

### Schema and seed data

- Each service applies its EF Core migrations at startup, in `Development` only.
- A small seeder fills in books, categories and stock when the tables are empty.
- Reset is `docker volume rm`, or a reset command on the AppHost.

## Database first service

Inventory is the database first service.  
A stock database often already exists, owned by a warehouse team or a DBA, with its own tables, views and maybe stored procedures. That makes it a natural fit.

### How it works

- **The database is the source of truth.** A folder with SQL scripts, or an SDK style SQL project that builds a dacpac, defines the schema and the seed data. People change the database, not C# classes.
- **Aspire applies it.** The AppHost creates the `inventory` database in the SQL Server container and runs the scripts on startup.
- **The model is scaffolded.** `dotnet ef dbcontext scaffold` generates the entities and the `DbContext` into `Inventory.Infrastructure`. Nobody edits the generated files. They are regenerated after a database change. Custom behavior goes in partial classes.
- **The rest of the service stays the same.** Api, CoreService and Contracts follow the normal service structure. Only the data access differs. The business logic does not care how the model was made.
- **Dapper fits well.** Views and stored procedures suit the future `Cat.Dapper` module, so Inventory can read through Dapper next to the scaffolded EF Core model.

### How it fits with the toolkit

`Cat.EFCore` is built for code first entities, with base classes for regular, temporal and reference data. Scaffolded entities do not inherit from those, and that is fine.  
Inventory uses commands, queries, responses and decorators, but not the entity base classes. It shows that you use only the modules you need.

The temporal and reference data examples stay in Catalog and Orders.

### Cost

- A small SQL scripts project and one extra step in the AppHost.
- A readme section on how to scaffold again after a database change.

## Messaging transport

The Azure Service Bus emulator runs in Docker, so it fits the Aspire setup.  
When `Cat.Messaging` arrives, the AppHost can start the emulator next to SQL Server. An in-process transport can be the lighter option for people without Docker.

## Aspire ServiceDefaults

Decision: the demo uses the Aspire ServiceDefaults project.

It sets up telemetry, health checks and resilience, which overlaps with the future `Cat.Telemetry` and `Cat.Resilience` modules. That is fine, because CAT is a toolbox.

- Use only what you need. The more modules you use, the more dependencies you get.
- The future `Cat.Telemetry` and `Cat.Resilience` modules must work in projects that do not use Aspire.
- The modules must not depend on Aspire or on ServiceDefaults.
- Both can live side by side. In the demo, ServiceDefaults covers the basics and the CAT modules add what it does not cover, such as the decorators on service requests.

## Open decisions

- Which service to build first? Suggestion: Catalog, then Orders.
- Service Bus emulator or in-process transport as the default for messaging?
- Update the readme of the current todo demo once the plan is agreed.

## Interesting documentation
- [.NET Aspire for beginners](https://learn.microsoft.com/nl-nl/shows/dotnet-aspire-for-beginners/)