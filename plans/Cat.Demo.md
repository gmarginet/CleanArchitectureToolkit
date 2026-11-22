<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: .. -->
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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-plan skill to update this plan.-->
<!-- region end: TemplateSkill-->

# Plans for `Cat.Demo` <!-- omit in toc -->  

<!-- region start: FirstStableVersion-->
**First stable version:** reached
<!-- region end: FirstStableVersion-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
<!-- no toc -->
- [Phase 1](#phase-1)
- [Phase 2](#phase-2)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
Turn the stand-in payment provider into a Node.js API, so it is plain to see that it is an outside system and not a service of the shop.

#### The idea
The payment provider is laid out like a CAT service today, with an `Api`, a `CoreService` and a `CoreService.Tests` project. A reader who skims the solution takes it for one of the services of the shop. A Node.js API in another language shows the real boundary: the shop and the provider share nothing but an OpenAPI contract and an API key.

#### Background
From the demo:
- The provider lives in `demo/Cat.Demo.PaymentService/`, with the projects `Cat.Demo.PaymentService.Api`, `Cat.Demo.PaymentService.CoreService` and `Cat.Demo.PaymentService.CoreService.Tests`. It uses no CAT modules and no `ServiceDefaults`, and it is not behind the gateway.
- It has two endpoints, `POST /charges` and `POST /refunds`. A call needs the API key as a bearer token and an `Idempotency-Key` header, or it gets 401 or 400. A repeated key gets the first answer and charges or refunds nothing again.
- A charge above 500 euro is declined with status 200. A refund of an order with no approved charge answers `nothing_to_refund`. Payments and refunds live in memory.
- It fails on purpose with the settings `PaymentFailures:Latency`, `PaymentFailures:ErrorPercentage` and `PaymentFailures:Outage`, and then answers 503. The AppHost passes them from `Payment:Latency`, `Payment:ErrorPercentage` and `Payment:Outage`, and the API key as `Provider__ApiKey`.
- It serves `/health`, which the AppHost waits for, and `/openapi/v1.json` in Development. The document says `format: decimal` for the amount, so the client of Orders keeps money a decimal.
- The AppHost runs it with `AddProject` on port 5103, under the resource name `payment`. Orders gets its address as `PaymentProvider__Url`.
- Orders keeps a copy of the document, `payment-provider.openapi.json`, and generates `IPaymentProviderClient` from it with NSwag. `Refresh-PaymentProviderClient.ps1` downloads the document from `http://localhost:5103/openapi/v1.json`.
- `PaymentProcessorTests` holds 10 NUnit tests of the charges, the refunds, the idempotency and the failures. `dotnet cake --target=Test` runs them.
- The provider exports no telemetry, and the client of Orders has a trace boundary, see the demo readme.

From the repository:
- The AppHost already references `Aspire.Hosting.JavaScript` and runs the React web client with `AddViteApp`. Node.js is already needed on the machine.
- The web client uses TypeScript, Vitest and oxlint. Neither `build.cake` nor the GitHub workflows run its tests.
- `CleanArchitectureToolkit.slnx` lists the three Payment projects. The web client is not in the solution.

#### Decided
- **Node.js.** The payment provider becomes a Node.js API (owner, 2026-11-22).
- **Name.** It is renamed to `Cat.Demo.PaymentProvider` (owner, 2026-11-22).
- **Same contract.** It keeps the same endpoints, answers and OpenAPI document, so Orders and its generated client do not change (owner, 2026-11-22).
- **TypeScript without a build step.** Node.js runs the `.ts` files as they are, with type stripping. `tsc --noEmit` checks the types, and `tsconfig.json` sets `erasableSyntaxOnly`, so the code uses no `enum`, `namespace` or parameter properties (owner, 2026-11-22).
- **Fastify.** The HTTP layer is Fastify 5. JSON schemas on the routes check the body and the `Idempotency-Key` header, and one `setErrorHandler` turns every error into an `application/problem+json` answer with the `ProblemDetails` shape of the contract (owner, 2026-11-22).
- **Design first.** The OpenAPI document is a static file, the current document with `Cat.Demo.PaymentService.Api` in the title and the tag renamed, served at `/openapi/v1.json`. Fastify takes the request schemas from it and checks every request against it, with `fastify-openapi-glue` or a small loader of our own. `format: decimal` gets a custom format. The NSwag client of Orders takes its names from the operation ids, so it does not change (owner, 2026-11-22).
- **Node.js tests in Cake.** The `Test` target of `build.cake` also runs `npm test` for the provider and for the web client, so `dotnet cake --target=Test` and the build workflow test both. The build workflow installs Node.js with `actions/setup-node`, because type stripping needs Node.js 22.18 or later (owner, 2026-11-22).
- **Node.js style settings.** The provider reads `PROVIDER_API_KEY`, `FAILURE_LATENCY_MS`, `FAILURE_ERROR_PERCENTAGE` and `FAILURE_OUTAGE`. The settings of the AppHost stay as they are: `Payment:Latency` is still a `TimeSpan` such as `00:00:05`, and the AppHost converts it to milliseconds, so `00:00:05` becomes `FAILURE_LATENCY_MS=5000`. A bad value fails when the AppHost starts. In the demo readme only the settings table of the provider changes (owner, 2026-11-22).
- **No telemetry.** The provider exports no traces, logs or metrics, as today, because a real provider sends none. The Fastify logger writes one JSON line per request to stdout, which the dashboard shows as its console log, and the trace boundary of the client of Orders stays as it is (owner, 2026-11-22).
- **`node:test`.** The 10 tests of `PaymentProcessorTests` move to the built-in `node:test`, run with `node --test`, so they run the code with type stripping, the way the AppHost runs it. Fastify's `inject` drives the requests without a port, and `mock.timers` covers the latency. The web client keeps Vitest, because it runs through Vite and needs JSX and a DOM (owner, 2026-11-22).

#### To check at the build
- The exact Aspire call for a Node.js app in `Aspire.Hosting.JavaScript` 13.6.5, and whether it runs `npm install` itself.
- Whether `fastify-openapi-glue` reads OpenAPI 3.2. If not, a small loader of our own reads the schemas from the document.
- Whether `node --test` finds the `*.test.ts` files with no pattern given.
- Every place that names `PaymentService` or the resource `payment`: the AppHost, the solution, the demo readme, the demo drawing `CatDemoArchitecture.excalidraw.svg` and the `cat-internal-create-demo-unit` skill.

#### What the build changes
- Remove the three .NET projects and their entries in `CleanArchitectureToolkit.slnx`.
- Add the Node.js API in `demo/Cat.Demo.PaymentProvider/`.
- Run it from the AppHost with the same port, API key, failure settings and health check.
- Update the demo readme and the demo drawing with the `cat-internal-create-demo-readme` skill.
- Add the `npm test` steps to the `Test` target of `build.cake` and `actions/setup-node` to `.github/workflows/build.yml`. Build files count as code, so this commit publishes.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->

<!-- region start: Phase 2-->
## Phase 2

### Description
<!-- region start: PhaseDescription-->
#### Goal
Turn the SQL scripts of Inventory into a SQL database project, so the build checks the schema and the AppHost deploys it.

#### The idea
Inventory is database first. A team that owns a database on SQL Server often keeps its schema in a SQL database project. The build checks every object and produces a `.dacpac` file, and a deploy brings any database up to that schema. The demo then shows the usual way of working, and the AppHost no longer glues the scripts together by hand.

#### Background
From the demo:
- `demo/Cat.Demo.InventoryService/Cat.Demo.InventoryService.Database/` is a folder with 5 scripts and no project. Every script only creates what is missing, so it can run at every start.
  - `001-schema.sql` creates `Warehouse`, `StockItem` and `StockReservation`, with the checks `CK_StockItem_QuantityOnHand` and `CK_StockReservation_Quantity` and the unique constraints `UQ_StockItem_Warehouse_Isbn` and `(StockItemId, OrderNumber)`.
  - `002-seed.sql` adds one warehouse and 50 copies of each of the 7 books of the Catalog seed.
  - `003-reservation-confirmed.sql` adds the column `ConfirmedAt` to `StockReservation`.
  - `004-scheduling.sql` creates `CatJobRun` and its index for `Cat.Scheduling.EFCore`. It must match the model of `AddCatScheduling()`.
  - `005-change-capture.sql` waits for the SQL Server Agent, then switches change data capture on for the database and for `StockItem`, with the capture instance `dbo_StockItem`. It tries again for up to a minute.
- The AppHost reads the folder in `BuildInventoryCreationScript`. It drops the `GO` lines, wraps every file in `EXEC` and passes the result to `WithCreationScript` of the `inventory-db` database. The SQL Server container runs with `MSSQL_AGENT_ENABLED=true`.
- `Scaffold-InventoryModel.ps1` scaffolds the entities into DataModels and the `InventoryDbContext` into Infrastructure, from the running database. It takes the three stock tables only.
- The demo readme says the folder is not a project.

From the repository:
- The AppHost uses `Aspire.Hosting.SqlServer` 13.6.5. `Directory.Packages.props` has no SQL project package yet.
- `global.json` asks for SDK 10.0.0 with `rollForward` `latestMajor`.

#### Decided
- **SQL project.** `Cat.Demo.InventoryService.Database` becomes an SDK-style SQL project with the `Microsoft.Build.Sql` SDK (owner, 2026-11-22).
- **Deploy from the AppHost.** The AppHost deploys the project with `CommunityToolkit.Aspire.Hosting.SqlDatabaseProjects`, and `BuildInventoryCreationScript` goes (owner, 2026-11-22).
- **Change data capture.** The post-deployment script switches change data capture on for the database and for `StockItem` when it is missing, and nothing switches it off. A rebuild of `StockItem` then gets a new capture instance at the end of the deploy. A column that a deploy adds in place is not in the capture instance until the data volume is removed, and the demo readme says so (owner, 2026-11-22).
- **Seed.** The seed lives in the post-deployment script, next to the change data capture, and only adds what is missing. Only the AppHost deploys the project, so the seed never reaches a database that is not a demo (owner, 2026-11-22).
- **Scheduler table.** `CatJobRun` and its index `IX_CatJobRun_JobName_Status_StartedAt` become a table of the SQL project, like the stock tables. A database first team owns every table of its database. The table copies the model of `Cat.Scheduling.EFCore` and follows it by hand, because neither the SQL build nor EF Core compares the two (owner, 2026-11-22).
- **PostgreSQL.** No counterpart. Inventory is the SQL Server database first showcase and reads changes with `Cat.Sql.Cdc`, which PostgreSQL does not have. Notifications is the PostgreSQL showcase.
- **Integration tests.** None. This is demo code and not database code in a module.

#### To check at the build
- The current versions of `Microsoft.Build.Sql` and `CommunityToolkit.Aspire.Hosting.SqlDatabaseProjects`, and that they work with .NET 11, SDK roll forward and Aspire 13.6.5.
- That the SQL project builds with `dotnet cake --target=Build` and on the Linux agent of the build workflow, and how Cake treats it next to the `*.Tests.csproj` and pack steps.
- Whether `AddSqlProject<Projects.X>` needs a project reference from the AppHost, and how that reference sits in `CleanArchitectureToolkit.slnx`.
- How DacFx handles a table that has change data capture on. A change that rebuilds `StockItem` can fail or lose the capture.
- That dropping `StockItem` in a rebuild also drops the capture instance `dbo_StockItem`, so the post-deployment script switches it on again.
- That a column added in place stays out of the capture instance, and what `Cat.Sql.Cdc` does when the capture instance is new and the stored position is older than its first LSN.
- That a deploy keeps the `cdc` schema and its objects, which are not in the project.
- That the scaffold still takes the three stock tables only.

#### What the build changes
- Add `Cat.Demo.InventoryService.Database.sqlproj` with one file per table, `CatJobRun` included, and the `ConfirmedAt` column in the table `StockReservation`.
- Turn the seed and the change data capture into deployment scripts.
- Remove the 5 numbered scripts and `BuildInventoryCreationScript`.
- Add the SQL project to the AppHost, and let Inventory wait until the deploy is done.
- Add the projects to `CleanArchitectureToolkit.slnx` with the `cat-internal-create-demo-unit` skill.
- Update the demo readme with the `cat-internal-create-demo-readme` skill.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 2-->
