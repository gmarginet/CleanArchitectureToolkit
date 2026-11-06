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

# CAT Bookshop Demo <!-- omit in toc -->  

A small bookshop that shows how the Clean Architecture Toolkit modules work together.  
The full plan is in [Demo.md](../plans/Demo.md).

## Table of contents <!-- omit in toc -->  

- [What the bookshop does](#what-the-bookshop-does)
- [Architecture](#architecture)
- [How to run](#how-to-run)
- [Building blocks](#building-blocks)
  - [React client](#react-client)
  - [Aspire AppHost and dashboard](#aspire-apphost-and-dashboard)
  - [API Gateway](#api-gateway)
  - [Service Bus emulator](#service-bus-emulator)
  - [Catalog service](#catalog-service)
  - [Orders service](#orders-service)
  - [Inventory service](#inventory-service)
  - [Notifications service](#notifications-service)
  - [Aspire ServiceDefaults](#aspire-servicedefaults)
  - [Payment service](#payment-service)

## What the bookshop does

The demo is an online bookshop. Customers look at books and place orders. An admin keeps the catalog up to date.

What you can do today:

- **Browse the catalog.** See the categories and the books in them. Search for a book. Open a book to see its details.
- **See prices.** Every book has a current price in euro. The shop keeps the older prices as well.
- **Manage the catalog.** An admin can add a book or change one.
- **Place an order.** Pick books and quantities. The shop looks up the prices, checks that the books are in stock, takes the payment and confirms the order.
- **Get an order number.** Every order gets a number like `20261105-0001`. The date is the day of the order. The counter starts again every day.
- **Follow your orders.** See a list of your orders and open one to see its lines, its total and its status.
- **Cancel an order.** Change your mind after ordering and cancel it.
- **Log in.** Alice, Bob and the admin each have an account. You need to be logged in to place or follow orders. Anyone can browse the catalog without a login.
- **Stay private.** A customer only sees their own orders. An admin sees all of them. Only an admin can add or change a book.
- **Use the web shop.** Open the shop in the browser, search the books by text or category, open a book and log in. Placing and following orders in the browser comes next.

What the shop does when something goes wrong:

- A book that is not in stock stops the order. The order is cancelled and the customer is told which book is the problem.
- A payment that is declined stops the order in the same way.
- A payment service that is down or too slow stops the order too. The order is cancelled, the customer is told to try again later and is not charged. A short hiccup is retried, so most customers never notice it.

For now stock is pretend. Any line of more than 50 copies is out of stock. When you start the shop with Aspire, the order asks the catalog for the real price of every book, and a separate payment service takes the payment. That service declines any total above 500 euro. It never charges an order twice.

What comes later:

- A real stock service that keeps the stock levels.
- Emails when an order is confirmed or shipped.
- A basket, checkout and an order overview in the web shop.
- Nightly jobs, such as cancelling orders that are not paid.

## Architecture

The demo is a small system of services, each with its own database. The services are built the same way, with the project structure from the root [README](../README.md#service-project-structure). A client talks to them through an API gateway, which checks the login. Services tell each other about events through a message bus.

![Architecture](../resources/schemas/CatDemoArchitecture.excalidraw.svg)

Hatched boxes are not built yet. Solid boxes are. The drawing and the status of every block are kept in sync with the code.

### How the pieces fit

- **Clients** only talk to the API gateway. It checks the token, lets the public catalog reads through and forwards the call with the token unchanged. Orders still calls Catalog directly for prices. That call moves to the gateway with `Cat.Api.Client`.
- **Login.** Keycloak runs as a container and holds the users. The gateway and each service check the token. A service does not trust the network. See [Things to know](#things-to-know).
- **Services** own their data. A service never reads the database of another service. Where one needs data of another, it asks through an interface. Orders asks Catalog for prices and the payment service for payments over HTTP when you run through Aspire. Stock is still a fake.
- **Contracts.** Sharing the contracts of a service is a choice per connection. The React client and the price call from Orders to Catalog keep their own models. A later service to service call will share contracts, so the demo shows both. See [Sharing contracts](../plans/Demo.md#sharing-contracts).
- **Events** between services will travel over the Service Bus. Inside a service, events stay in memory.
- **Databases.** Every service has its own SQL Server database.
- **Aspire** starts everything with one command: the gateway, the services, Keycloak and SQL Server in containers, and the dashboard. You can still start a service on its own.

### How a request flows through a service

1. An endpoint receives the HTTP request and turns it into a service request.
2. The service request processor runs the decorators: logging, tracing and validation.
3. A handler runs the use case. It reads through queries and changes data through commands.
4. The result comes back as a response, either a value or a list of errors.
5. The endpoint turns the response into an HTTP status code and a body.

### Where the CAT modules sit

| Layer | Modules |
|---|---|
| API | `Cat.Minimal.Api` |
| Core service | `Cat.ServiceRequests`, `Cat.Queries`, `Cat.Commands`, `Cat.Validators`, `Cat.Responses`, and in Orders also `Cat.FluentWorkflows` and `Cat.EventAggregators` |
| Infrastructure | `Cat.EFCore` |
| Everywhere | `Cat.Expressions` |

The [building blocks](#building-blocks) explain where each module is used and why.

## How to run

The main route is the Aspire AppHost. One command starts the gateway, Catalog, Orders, the payment service, Keycloak, SQL Server and the React client, and opens the dashboard. You can also start one service on its own, see [Run one service](#run-one-service).

### Prerequisites

- The .NET SDK that `global.json` asks for.
- **Node.js 24 or newer** for the React client. The AppHost runs `npm install` and `npm run dev` for you, so you only need Node and npm on the path.
- **Docker Desktop** for the default route. SQL Server and Keycloak run in containers.
- Or a SQL Server you already have, and no Docker. Temporal tables need SQL Server, so SQLite and PostgreSQL do not work.

### Run with Aspire

1. Clone the repository and open a terminal in its root folder.
2. Start the AppHost:
   ```
   dotnet run --project demo/Cat.Demo.AppHost/Cat.Demo.AppHost --launch-profile http
   ```
3. Wait until the dashboard shows `gateway`, `catalog`, `orders` and `web` as running. The first start pulls the SQL Server and Keycloak images, so it takes a few minutes. Keycloak needs a moment to import the realm.
4. Open the dashboard at `http://localhost:15101`. It needs no login. It shows the logs, traces, metrics and health checks of the services.
5. Try the endpoints. The gateway runs on `http://localhost:5100` and is the door for every call. Keycloak runs on `http://localhost:8180`. Open these files in Visual Studio or Rider and run the requests from top to bottom. Run the login requests at the top first. Later requests use ids from earlier responses.
   - `demo/Cat.Demo.CatalogService/Cat.Demo.CatalogService.Api/CatalogRequests.http`
   - `demo/Cat.Demo.OrderService/Cat.Demo.OrderService.Api/OrderRequests.http`
   - The web shop runs on `http://localhost:5104`. You can browse the books and log in as `alice` with the password `alice`. See [React client](#react-client).
6. Place an order and open its trace in the dashboard. It shows the call from Orders to Catalog for the prices.
7. Press Ctrl+C to stop. The database lives in the Docker volume `cat-demo-sql-data`, so the data is still there at the next start.

To start again with empty databases, stop the AppHost and remove the volume:

```
docker volume rm cat-demo-sql-data
```

### SQL Server modes

The setting `Sql:Mode` of the AppHost picks where the databases live.

| Mode | What happens | Needs |
|---|---|---|
| `Container` (default) | The AppHost starts a SQL Server container with the data volume and creates the databases `catalog` and `orders`. The password is generated and kept in the user secrets. | Docker |
| `Existing` | The AppHost passes the connection strings `ConnectionStrings:catalog` and `ConnectionStrings:orders` to the services. The defaults point to the local default instance. | A SQL Server you can reach |

To use `Existing`, set the mode in the user secrets of the AppHost:

```
dotnet user-secrets set "Sql:Mode" "Existing" --project demo/Cat.Demo.AppHost/Cat.Demo.AppHost
```

To point it at another server, set `ConnectionStrings:catalog` and `ConnectionStrings:orders` in the same way. The defaults use Windows authentication, which works for a local process only.

### Docker memory

Docker Desktop on Windows runs on WSL2. By default the WSL2 virtual machine can take half of your RAM and keeps it while it runs.

- **Limit WSL2.** Create `%UserProfile%\.wslconfig`, then run `wsl --shutdown` and restart Docker Desktop. This is an example for a machine with 32 GB:
  ```
  [wsl2]
  memory=8GB
  processors=4
  swap=2GB

  [experimental]
  autoMemoryReclaim=gradual
  sparseVhd=true
  ```
- **Use the WSL 2 backend** in Docker Desktop, and turn off start at sign-in.
- **SQL Server is capped.** The AppHost sets `MSSQL_MEMORY_LIMIT_MB` to 2048 on the container. An idle container uses about 620 MiB.
- **Give the memory back.** When you are done, quit Docker Desktop and run `wsl --shutdown`.

### Run one service

Every service still starts on its own, with its own `appsettings`. It needs a SQL Server that you start yourself, and no Docker is involved. Without the AppHost, Orders uses a fake for prices, and there is no gateway and no login.

1. Start the Catalog service. First check the connection string in `demo/Cat.Demo.CatalogService/Cat.Demo.CatalogService.Api/appsettings.Development.json`. The default points to the local default instance:
   ```
   Server=.;Database=catalog;Trusted_Connection=True;TrustServerCertificate=True
   ```
   Then run:
   ```
   dotnet run --project demo/Cat.Demo.CatalogService/Cat.Demo.CatalogService.Api
   ```
   Open `http://localhost:5101`. The OpenAPI document is at `http://localhost:5101/openapi/v1.json`.
2. Start the Order service in a second terminal. It needs its own database. The Catalog service does not have to run. Check `demo/Cat.Demo.OrderService/Cat.Demo.OrderService.Api/appsettings.Development.json`:
   ```
   Server=.;Database=orders;Trusted_Connection=True;TrustServerCertificate=True
   ```
   Then run:
   ```
   dotnet run --project demo/Cat.Demo.OrderService/Cat.Demo.OrderService.Api
   ```
   Open `http://localhost:5102`.
3. Call the services directly on ports 5101 and 5102. The requests in the `.http` files that go through the gateway need the AppHost. Change their host to the service port and remove the `Authorization` line to use them here.

In `Development` both services apply their EF Core migrations at startup. Catalog adds 4 categories and 7 books when its tables are empty. Orders adds the three order statuses.
### Things to know

- **Users.** Keycloak holds three users: `alice`, `bob` and `admin`. The password is the same as the name. Alice and Bob only see their own orders. The admin sees all orders and may save books. The Keycloak admin console at `http://localhost:8180` uses `admin` and `admin`. Use these settings in the demo only.
- **Tokens.** The `.http` files get a token from Keycloak with the password grant of the client `cat-demo-cli`. The gateway needs a valid token for everything except reading books and categories. The services check the token again, so a call straight to port 5101 or 5102 without a token gets a 401 too.
- **Run without the AppHost.** Without the setting `Authentication:Authority` a service has no login. Orders then reads the `X-Demo-User` header (`alice` by default, `bob` or `admin`).
- **Fakes for the other services.** Stock is a fake, because the Inventory service is not built yet. Payment is a fake only without the AppHost.
  - Prices are real under the AppHost, because Orders asks Catalog. Without the AppHost the price of a book is made from its id, between 5.95 and 44.95 euro.
  - A line of more than 50 copies is out of stock.
  - A total above 500 euro is declined, by the payment service under the AppHost and by a fake without it.
- **Payment failures.** The payment service can fail on purpose, to show the retries and the circuit breaker. See [Payment service](#payment-service) for the settings.- **Order numbers** look like `20261105-0001`. The counter restarts every UTC day. The development endpoint `POST /development/scheduler/clean-up-order-counters` removes the counters of earlier days. The scheduler will do that every night.

### Health checks

The gateway and both services answer `/health` (ready) and `/alive` (running) in every environment, with a plain `Healthy` or `Unhealthy`, and no token is needed. The AppHost watches `/health` of all three. The gateway also calls `/health` of Catalog and Orders and stops sending calls to an instance that fails.

### Things to know about the dashboard

The dashboard may say "No trusted development certificate was found". That is harmless for now, because the AppHost, the dashboard and the services all run on HTTP. Anyone on your machine can open the dashboard on localhost, which is fine for a local demo.

### Run the tests

Run all tests of the repository, including the demo tests:

```
dotnet cake --target=Test
```

## Building blocks

One chapter for every box in the drawing. A database sits in the chapter of the service that owns it.

| Block | Status | What it is |
|---|---|---|
| [React client](#react-client) | Built | The web shop. It shows the books and has a login. The basket and the orders come next. |
| [Aspire AppHost and dashboard](#aspire-apphost-and-dashboard) | Built | Starts the whole system and shows how it runs. |
| [API Gateway](#api-gateway) | Built | The one door for clients. |
| [Keycloak](#keycloak) | Built | The identity provider that holds the users and signs the tokens. |
| [Service Bus emulator](#service-bus-emulator) | Planned | Messages between services. |
| [Catalog service](#catalog-service) | Built | Books, categories and prices. |
| [Orders service](#orders-service) | Built | Placing and following orders. |
| [Inventory service](#inventory-service) | Planned | Stock levels and reservations. |
| [Notifications service](#notifications-service) | Planned | Messages to customers and scheduled jobs. |
| [Aspire ServiceDefaults](#aspire-servicedefaults) | Built | Shared telemetry, health checks and resilience. |
| [Payment service](#payment-service) | Built | A separate pretend payment service that can fail on purpose. |

### React client

**Status:** Built

**What it is.** A thin web client with a book list, a basket and an order overview. It uses React with TypeScript, built with Vite.

**Where it stands.** Steps 1 to 3 of stage 3 are done. The app is in `demo/Cat.Demo.WebClient/Cat.Demo.WebClient.App`, a Vite, React and TypeScript project. The AppHost starts it as `web` on the fixed port 5104, and the gateway lists `http://localhost:5104` as an allowed CORS origin. It has two screens, the book list and the book detail, and a login. The book list has a search box and a category filter, and keeps them in the address. One error component shows the message, the code and the trace id of every failed call. The basket, the checkout and the orders come in the next steps.
**Work on the client.** Run these in the app folder. Node 24 or newer is needed.

| Command | What it does |
|---|---|
| `npm run dev` | Starts Vite on port 5104. It needs the gateway on port 5100, which the AppHost starts. |
| `npm test` | Runs the Vitest tests. The Cake build does not run them. |
| `npm run build` | Checks the types and builds the app. |
| `npm run api:refresh` | Saves the OpenAPI document of Catalog from a running AppHost into `api/`. Commit the change. |

**Types.** `npm run api:generate` makes the TypeScript types from `api/catalog.openapi.json`. It runs before `dev`, `build` and `test`. The generated file is not committed. The saved copy of the document is, so a fresh clone builds without a running service. TypeScript is pinned to 5.x, because `openapi-typescript` does not support 7 yet.
**How it works.**
- It only talks to the API gateway.
- The Log in button sends the browser to Keycloak. The login uses authorization code with PKCE (`react-oidc-context`). After the login the person is back on the page they came from, and the top bar shows their name.
- The access token lives in memory only. A page refresh loses it, so the app asks Keycloak for a new token without showing the login page. This works while the Keycloak session lasts. A tab flag, kept in session storage, says that the person was logged in. It holds no token.
- Every call to the gateway carries the token when a person is logged in. Catalog reads need none.
- Log out ends the Keycloak session as well.
- It has no shared code with the services. The types come from a saved copy of the OpenAPI documents of the services.

**CAT modules.**

| Module | Where | Why |
|---|---|---|
| `Cat.Minimal.Api` | Produces the OpenAPI documents the client is built from | One description of every endpoint and every possible response. |

**Pros.**
- The client stays independent of .NET. The services expose a normal HTTP API.
- React is the most widely known option.

**Cons.**
- No shared contracts, so a change in a service needs `npm run api:refresh` and a commit of the saved document.
- Blazor WebAssembly would share the contracts, but it makes the demo look .NET only.

**More.** `demo/Cat.Demo.WebClient`. [React client plan](../plans/Demo.md#react-client).

### Aspire AppHost and dashboard

**Status:** Built

**What it is.** One project that describes the system: the gateway, Catalog, Orders, Keycloak and SQL Server. The Aspire dashboard shows logs, traces, metrics and health checks. The React client starts from it too. The Service Bus emulator joins later.

**How it works.**
- `demo/Cat.Demo.AppHost/Cat.Demo.AppHost` adds the Api project of each service. The services keep their ports, 5101 and 5102, with no Aspire proxy. The dashboard runs on 15101.
- The setting `Sql:Mode` picks `Container` (the default) or `Existing`. See [SQL Server modes](#sql-server-modes).
- In `Container` mode the AppHost adds a SQL Server container with a named data volume and the databases `catalog` and `orders`. The services wait for their database, and Orders waits for Catalog.
- The services read `GetConnectionString("catalog")` and `GetConnectionString("orders")` in both modes. They do not know which mode runs.
- Orders gets the address of Catalog through service discovery. That switches on `CatalogPriceProvider`.
- Keycloak is a plain container on port 8180. The realm file `keycloak/cat-demo-realm.json` is mounted and imported at the start. The official Aspire Keycloak package is only a preview, so the demo does not use it.
- The gateway runs on port 5100. It finds Catalog and Orders through service discovery. The AppHost gives the gateway, Catalog and Orders the address of the Keycloak realm.
- Every service still starts on its own with `dotnet run`. The AppHost is a convenience, not a requirement.

**CAT modules.** None. The AppHost is demo infrastructure. The modules never depend on Aspire.

**Pros.**
- One command to start everything.
- Traces across services in one place.
- A fresh clone needs no connection strings.

**Cons.**
- Docker Desktop eats memory. See [Docker memory](#docker-memory) for the limits.
- The first start pulls a SQL Server image of about 1.5 GB, and the Keycloak image.
- It is one more thing to learn.

**More.** `demo/Cat.Demo.AppHost`.
### API Gateway

**Status:** Built

**What it is.** The one door for clients. It checks the token and forwards calls to Catalog and Orders. It holds no business logic. The block is a small host project on top of the `Cat.Api.Gateway` module.

**How it works.**
- `demo/Cat.Demo.Api.Gateway/Cat.Demo.Api.Gateway` is a web project of about twenty lines. It calls `AddCatApiGateway`, adds the Aspire service discovery for YARP, and calls `UseCatApiGateway` and `MapCatApiGateway`.
- The `CatGateway` section of `appsettings.json` names the services `catalog` and `orders`. The path of a service is its name, so `/catalog/**` goes to Catalog and `/orders/**` goes to Orders. Both services already use that prefix, so `StripPrefix` is off.
- The AppHost sets the addresses to `http://catalog` and `http://orders`, which service discovery resolves. Without the AppHost the defaults point to ports 5101 and 5102.
- Catalog lists `GET /books/**` and `GET /categories/**` as public. Everything else needs a token. Saving a book needs a token, and the Catalog service wants the `admin` role on top.
- The gateway checks that the token comes from the Keycloak realm and has the audience `cat-gateway`. It does not look at roles. It forwards the token unchanged, and the service checks it again.
- Identity headers a caller sends, such as `X-Demo-User`, never reach a service.
- The `/health` and `/alive` endpoints of the gateway are mapped with `AllowAnonymous`, because the gateway is closed by default.

**CAT modules.**

| Module | Where | Why |
|---|---|---|
| `Cat.Api.Gateway` | The gateway project | Routes, token check, header cleaning and rate limits from configuration. |

The gateway only option of the module is not used in the demo. The services check the token themselves.

**Pros.**
- Clients know one address.
- Adding a service is a few lines of configuration.
- The token check sits in one place and the services stay safe on their own.

**Cons.**
- One more hop and one more process to run.
- The demo keeps its Keycloak settings in plain text. That is fine for a demo and wrong for production.

**More.** `demo/Cat.Demo.Api.Gateway`. [Decisions in the plan](../plans/Demo.md#decided).

### Keycloak

**Status:** Built

**What it is.** The identity provider of the demo. It holds the users, checks passwords and signs the access tokens. Any OpenID Connect provider would do. Keycloak is only the demo choice.

**How it works.**
- The AppHost starts it as a plain container on port 8180. There is no data volume, so every start imports the realm again.
- The realm file `demo/Cat.Demo.AppHost/Cat.Demo.AppHost/keycloak/cat-demo-realm.json` holds the realm `cat-demo`, the role `admin` and the users `alice`, `bob` and `admin`. The user ids equal the user names, so the `sub` claim of a token matches the seeded data.
- Two public clients exist. `cat-demo-web` is for the React app. It uses the authorization code flow with PKCE. Its web origin is `http://localhost:5104`, so the browser may call the token endpoint of Keycloak. `cat-demo-cli` allows the password grant, for the `.http` files only.
- Both clients add the audience `cat-gateway` and a flat `roles` claim to the access token.
- The gateway and the services read the signing keys from the realm and check every token themselves. See [API Gateway](#api-gateway).

**CAT modules.** None. The toolkit works with any OpenID Connect provider, so Keycloak is no dependency of a module.

**Pros.**
- Real tokens and a real login flow, with no account or tenant to create.
- The realm is a file in the repository, so every clone gets the same users.

**Cons.**
- Another container to start and a few hundred MB of memory.
- The passwords and the admin console login are public and simple. That is fine for a demo and wrong for production.

**More.** `demo/Cat.Demo.AppHost/Cat.Demo.AppHost/keycloak`. [Identity provider in the plan](../plans/Demo.md#authentication-and-authorization).
### Service Bus emulator

**Status:** Planned

**What it is.** The Azure Service Bus emulator, started by the AppHost. Services publish events such as `OrderPlaced` on it, and other services listen.

**CAT modules.** All planned.

| Module | Where | Why |
|---|---|---|
| `Cat.Messaging` (future) | Publishing and consuming | Same handler style as the other modules. |
| `Cat.EventProcessor` (future) | Inventory and Notifications | Turns incoming messages into service requests. |
| `Cat.Sagas` (future) | Orders | A workflow that waits for a message. |

**Pros.**
- Services do not need to know each other.
- A slow service does not block an order.

**Cons.**
- It runs in Docker.
- Failures are harder to follow than a direct call.

**More.** [Messaging in the plan](../plans/Demo.md#messaging), [Cat.Sagas](../plans/Cat.Sagas.md).

### Catalog service

**Status:** Built

**What it is.** Books, categories and prices. Mostly reads, with a small admin part. It is the first service of the demo and is built code first.

**How it works.**
- Endpoints, all under `/catalog`:
  - `GET /books` searches books.
  - `GET /books/{bookId}` returns one book.
  - `GET /books/prices` returns the price list, which Orders uses under the AppHost.
  - `POST /books` adds or changes a book.
  - `GET /categories` lists the categories.
- Each endpoint maps to a service request such as `BookSearchRequest`. A handler turns it into queries and commands.
- Entities are `Category`, `Book` and `BookPrice`. `BookPrice` is a temporal table, so every old price stays in the history.
- Saving a book checks that the ISBN is unique.
- The folder is `demo/Cat.Demo.CatalogService`, with the projects of the service project structure.

**Database.** The `catalog` database is built. It is a SQL Server database that only Catalog reads. In `Development` the service applies its EF Core migrations at startup and adds 4 categories and 7 books when the tables are empty. Every entity inherits `CatEntityBase`, so each has a `Guid` `Id` as non-clustered primary key and an identity `SequenceId` that holds the clustered index. `BookPrice` inherits `CatTemporalEntityBase`. SQL Server keeps every old price in a history table, and `ValidFrom` and `ValidUntil` are the period columns. Names and columns are not final.

```mermaid
erDiagram
    Category ||--o{ Book : groups
    Book ||--o| BookPrice : "priced by"

    Category {
        Guid Id PK
        int SequenceId
        string Name
    }
    Book {
        Guid Id PK
        int SequenceId
        string Isbn UK
        Guid CategoryId FK
        string Title
        string Author
    }
    BookPrice {
        Guid Id PK
        int SequenceId
        Guid BookId FK
        decimal Amount
        datetime ValidFrom
        datetime ValidUntil
    }
```

**CAT modules.**

| Module | Where | Why |
|---|---|---|
| `Cat.ServiceRequests` and its logging, tracing and validation decorators | Core service, wired in the Api | One entry point per use case, with cross cutting work done once. |
| `Cat.Queries`, `Cat.Commands` and their logging decorators | Core service and Infrastructure | Reads and writes are separate handlers that are easy to test. |
| `Cat.Validators` | Core service | Rules for a book and for the price list request, with every problem returned at once. |
| `Cat.Responses` | Everywhere | A result is either a value or a list of errors. No exceptions for business failures. |
| `Cat.Minimal.Api` | Api | Maps service requests to endpoints and documents the responses. |
| `Cat.EFCore` | DataModels and Infrastructure | Entity base classes, and the temporal price table. |
| `Cat.Expressions` | Api | Compiled member access that is reused. |

**Pros.**
- Every use case has the same shape, so a new one is easy to add.
- The core service has no web or database code, so it is easy to unit test.
- Price history costs one base class.

**Cons.**
- Many small types for a small service: a request, a handler, a query, a query handler and a validator.
- Temporal tables tie the demo to SQL Server.
- Category names are plain text. `Cat.Localizations` is not used yet.

**More.** Code in `demo/Cat.Demo.CatalogService`. Requests in `CatalogRequests.http`. [Data model](../plans/Demo.md#catalog).

### Orders service

**Status:** Built

**What it is.** The main service. Customers place and track orders. Built code first.

**How it works.**
- Endpoints, all under `/orders`:
  - `POST /` places an order.
  - `GET /` lists the orders of the user.
  - `GET /{orderId}` returns one order.
  - `POST /{orderId}/cancel` cancels an order.
- The place order process is a workflow, in `PlaceOrderWorkflow`:
  1. Find or create the customer from the current user.
  2. Look up the price of every line and add up the total.
  3. Create the order. It gets its number and the status `Pending` in one transaction.
  4. Reserve the stock. If a book is out of stock, cancel the order and stop.
  5. Take the payment and save it. If it is declined, cancel the order and stop. If the payment service cannot answer, cancel the order with `CAT-ORD-1006` and stop. Nothing is saved then.
  6. Confirm the order.
- Confirmed and cancelled are events. Subscribers set the status, write an audit record and release the stock.
- Stock, price and payment sit behind interfaces: `IStockReservation`, `IPriceProvider` and `IPaymentProvider`. A fake answers for stock. For prices, `CatalogPriceProvider` calls `GET /catalog/books/prices` over HTTP when the host gives Orders an address for Catalog, as the AppHost does. Without it, `FakePriceProvider` answers. For payments, `PaymentServiceProvider` calls the payment service the same way, and `FakePaymentProvider` answers without an address.
- `CatalogPriceProvider` maps the answers of Catalog. A 200 gives the prices and a 404 becomes `PriceUnavailable`. Any other status, a network error or a timeout becomes an error response, because Orders never trusts a half answer. The resilience handler adds retries and a circuit breaker. Catalog reads are public, so the call sends no token. The unit tests use a fake `HttpMessageHandler`, so they need no database and no running service.
- `ICurrentUser` tells the core service who is calling. With a login it reads the claims of the token (`sub`, `name`, `email` and the `admin` role). Without one, a development stub reads the `X-Demo-User` header. Orders of other users come back as not found.
- Order numbers come from a `DailyOrderCounter` table, increased in one atomic statement in the same transaction that saves the order.

**Database.** The `orders` database is built. It is a SQL Server database that only Orders reads. In `Development` the service applies its EF Core migrations at startup and adds the three order statuses. All tables are regular entities that inherit `CatEntityBase`. `OrderNumber` is unique. `OrderLine` refers to a book with `BookId` and has no foreign key, because the book lives in the Catalog database. `DailyOrderCounter` has no relationship with the other tables. Names and columns are not final.

```mermaid
erDiagram
    Customer ||--o{ Order : places
    OrderStatus ||--o{ Order : describes
    Order ||--|{ OrderLine : contains
    Order ||--o| Payment : "paid by"

    Customer {
        Guid Id PK
        int SequenceId
        string ExternalId UK "sub claim of the token"
        string Name
        string Email
    }
    OrderStatus {
        Guid Id PK
        int SequenceId
        string Code
    }
    Order {
        Guid Id PK
        int SequenceId
        string OrderNumber UK
        Guid CustomerId FK
        Guid OrderStatusId FK
        datetime PlacedAt
        decimal Total
    }
    OrderLine {
        Guid Id PK
        int SequenceId
        Guid OrderId FK
        Guid BookId "Book in Catalog, no foreign key"
        int Quantity
        decimal UnitPrice
    }
    Payment {
        Guid Id PK
        int SequenceId
        Guid OrderId FK
        decimal Amount
        string Status
        datetime PaidAt
    }
    DailyOrderCounter {
        Guid Id PK
        int SequenceId
        datetime Date UK "UTC day"
        int LastNumber
    }
```

**CAT modules.**

| Module | Where | Why |
|---|---|---|
| `Cat.FluentWorkflows` and its command step | Core service | The place order process reads as a list of steps, with an `if` for out of stock and a `foreach` over the lines. |
| `Cat.EventAggregators` | Core service | In-process events. The workflow publishes, subscribers react, and neither knows the other. |
| `Cat.ServiceRequests`, `Cat.Queries`, `Cat.Commands`, `Cat.Validators`, `Cat.Responses` | Core service | The same use case shape as Catalog. |
| `Cat.Minimal.Api` | Api | Endpoints and OpenAPI. |
| `Cat.EFCore` | DataModels and Infrastructure | Entities with `Guid` ids and sequence ids. |
| `Cat.Expressions` | Api | Compiled member access. |

**Pros.**
- The business process is one readable class.
- Events keep the status update, audit and cleanup out of the workflow.
- Interfaces with fakes let the demo run without the other services.

**Cons.**
- Events cannot drive the process. They return no answer, and a failing subscriber throws. Calls that decide the next step go through interfaces instead.
- Subscribers live as long as the app, because the aggregator holds them with weak references. A subscriber that needs the `DbContext` opens its own scope.
- A cancelled order keeps its approved payment, because there is no refund step yet.
- The state lives in the order status. A payment over messages needs `Cat.Sagas`.

**More.** Code in `demo/Cat.Demo.OrderService`. Requests in `OrderRequests.http`. [Data model](../plans/Demo.md#orders), [events and interfaces](../plans/Demo.md#events-and-interfaces), [known gaps](../plans/Demo.md#known-gaps-in-orders).

### Inventory service

**Status:** Planned

**What it is.** Tracks stock and reserves it when an order comes in. It is built database first, with SQL scripts that the AppHost runs.

**How it will work.**
- It identifies a book by `Isbn` and an order by `OrderNumber`, because it does not share a database with the other services.
- It replaces `FakeStockReservation`.
- It listens to `OrderPlaced`.

**Database.** The `inventory` database is planned. Inventory is the database first service. A stock database often exists already, owned by a warehouse team, so the schema comes from SQL scripts and not from C# classes. The AppHost creates the database and runs the scripts on startup. The entities are scaffolded with `dotnet ef dbcontext scaffold`, and nobody edits the generated files. They do not inherit `CatEntityBase` and have no `SequenceId`. Names and columns are not final.

```mermaid
erDiagram
    Warehouse ||--o{ StockItem : holds
    StockItem ||--o{ StockReservation : "reserved by"

    Warehouse {
        int Id PK
        string Name
        string Location
    }
    StockItem {
        int Id PK
        int WarehouseId FK
        string Isbn
        int QuantityOnHand
    }
    StockReservation {
        int Id PK
        int StockItemId FK
        string OrderNumber
        int Quantity
        datetime ReservedAt
    }
```

**CAT modules.** Planned: `Cat.Messaging` and `Cat.EventProcessor` to listen, and the usual service request modules. The plan describes how the database first approach fits the toolkit.

**Pros.** Shows that CAT also works when the database comes first.

**Cons.** Two ways to build a service means two ways to explain.

**More.** [Inventory data model](../plans/Demo.md#inventory).

### Notifications service

**Status:** Planned

**What it is.** Sends the order confirmed and order shipped messages. It also runs scheduled jobs, such as the nightly clean up of order counters and cancelling unpaid orders.

**CAT modules.** Planned: `Cat.Scheduling`, `Cat.EventProcessor` and `Cat.Localizations` for texts in several languages.

**Pros.** A natural place for scheduled work and for the localization module.

**Cons.** Not decided yet where it stores its data.

**More.** [Services in the plan](../plans/Demo.md#services).

### Aspire ServiceDefaults

**Status:** Built

**What it is.** A shared project with the defaults every service uses. Only the demo uses it. The CAT modules never reference it.

**How it works.** `AddServiceDefaults()` in the `Program.cs` of a service sets up:
- Logs, metrics and traces with OpenTelemetry. The wildcard source `Cat.*` covers the CAT decorators and workflows. Data leaves the process only when `OTEL_EXPORTER_OTLP_ENDPOINT` is set, which the AppHost does.
- A readiness check at `/health` and a liveness check at `/alive`.
- The token check of the services. `AddDemoJwtAuthentication` turns on JWT validation when `Authentication:Authority` is set.
- Service discovery and the standard resilience handler on every `HttpClient`: retries, timeouts and a circuit breaker. The pipeline is chosen per service address, so a failing service opens its own circuit and not the circuit of the others.

**CAT modules.** None are referenced. It works next to them: the tracing decorator of `Cat.ServiceRequests` shows up in the traces.

**Pros.**
- Every service gets the same setup in one line.
- It shows that CAT sits next to the standard .NET tools.

**Cons.**
- The demo uses Aspire, so it does not use the future `Cat.Telemetry` and `Cat.Resilience` modules.
- The health checks only say that the process runs. They check no database yet.

**More.** [Plan](../plans/Demo.md#aspire-servicedefaults).

### Payment service

**Status:** Built

**What it is.** A small separate service, `Cat.Demo.PaymentService`, that pretends to be a payment provider. Orders calls it over HTTP, so retry and circuit breaker have a real call to protect. It has no database and no login.

**How it works.**
- `POST /payments` takes an order number and an amount. It answers 200 with `approved` and a `reference`. An amount up to 500 euro is approved. A higher amount is declined, which is an answer and not an error. Bad input gets a 400.
- The order number is the idempotency key. The service remembers the answer per order number in memory. A retried call gets the same answer and nothing is charged twice.
- The service runs on port 5103. The AppHost starts it and gives Orders its address. Orders finds it by name, `services:payment:*`, like Catalog.
- In Orders, `PaymentServiceProvider` implements `IPaymentProvider`. The resilience handler of ServiceDefaults gives the client retries, a timeout and a circuit breaker. When no answer comes, the provider says the payment is unavailable. The place order workflow then cancels the order with `CAT-ORD-1006`, saves no payment and releases the stock.
- Without the AppHost, `FakePaymentProvider` answers in the process, the way `FakePriceProvider` does for prices.
- The `Cat.Demo.PaymentService.CoreService` project holds the rules and the failure switches. The `Api` project is one endpoint.

**Failures on purpose.** The settings of the service switch them on. A call cannot ask for a failure. All are off by default.

| Setting | What it does |
|---|---|
| `PaymentFailures:Latency` | Waits this long before every answer, for example `00:00:05`. A long delay shows the timeout. |
| `PaymentFailures:ErrorPercentage` | The share of calls, 0 to 100, that fail with a 503 after the payment is taken. The retry shows that nothing is charged twice. |
| `PaymentFailures:Outage` | `true` makes every call fail at once, and nothing is taken. The retries run out, and after a burst of failing calls the circuit opens and orders end at once. |

Under the AppHost, set `Payment:Latency`, `Payment:ErrorPercentage` or `Payment:Outage` in the configuration of the AppHost and start it again. For example:

```
dotnet user-secrets set "Payment:Outage" "true" --project demo/Cat.Demo.AppHost/Cat.Demo.AppHost
```

Remove the secret to switch the failure off again. When you run the service on its own, change `PaymentFailures` in its `appsettings.json` or set `PaymentFailures__Outage=true`. A running service reads a changed setting again. Place an order and open the trace in the dashboard to see the retries.

**CAT modules.** The service uses none on purpose. It is a plain stand-in for something outside the toolkit.

| Module | Where | Why |
|---|---|---|
| `Cat.FluentWorkflows` | The step in Orders that calls it | The workflow only knows the interface. |
| `Cat.Resilience` (future) | Around the client in Orders | Retry and circuit breaker on a call that can really fail. The demo uses the ServiceDefaults handler for now. |

**Pros.**
- Retry and circuit breaker have a real call to protect, and you can switch the failures on in a demo.
- The demo shows a call to a service that does not behave, and how the order ends when it fails.

**Cons.**
- One more project to build and run.
- The service has no login and forgets its answers when it restarts. It is a fake, so it stays simple on purpose.
- The service is still pretend. It proves nothing about a real provider.

**More.** `demo/Cat.Demo.PaymentService`, `PaymentServiceProvider` in `demo/Cat.Demo.OrderService/Cat.Demo.OrderService.Infrastructure/PaymentServices`. [Payment decisions and open questions](../plans/Demo.md#decided), [Cat.Resilience](../plans/Cat.Resilience.md).