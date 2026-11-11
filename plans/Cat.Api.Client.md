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

# Plans for `Cat.Api.Client` <!-- omit in toc -->  

<!-- region start: StatusBadge-->
[![PLANNING](https://img.shields.io/badge/Status-PLANNING-orange)](#plans-for-catapiclient)
<!-- region end: StatusBadge-->

## Table of contents <!-- omit in toc -->  
<!-- region start: Phases-->
- [Phase 1](#phase-1)
<!-- region end: Phases-->

<!-- region start: Phase 1-->
## Phase 1

### Description
<!-- region start: PhaseDescription-->
#### Goal
`Cat.Api.Client` is built and Orders uses it. This phase finishes the module: settle whether it is stable, add the missing chapters to the module readme, and then close out this plan.

#### The idea
A service sometimes needs data or an action from another service, and it needs the answer to go on. The architecture says that call always goes through the API gateway. Writing a plain `HttpClient` call every time means repeating the same work: the address, the token, the error mapping and the retries.

`Cat.Api.Client` gives a typed client for that call. It returns an `ICatResponse`, like everything else in the toolkit, so a failed call looks like any other failed use case.

#### Background
From the readme:
- Services never call each other directly. The call goes through the API gateway.
- A service only needs to know the gateway address.
- The `Contracts` project of a service has almost no dependencies, so other services and clients can reference it. Sharing it is a choice of the developer, not a rule.

From the module conventions:
- `Cat.Minimal.Api` maps service requests to endpoints and documents the responses. A client could be the mirror image: a service request type goes in, an HTTP call is made, a response comes out.
- Infrastructure treats an integration like a database. The core never calls it directly. It sends a query or a command, and a handler calls the other service.

From the demo and the code:
- Orders needs the current price of every book. `IPriceProvider` hides that behind an interface in the core.
- The first real version was a plain `HttpClient` class, `CatalogPriceProvider`, in `Orders.Infrastructure`. It called `GET /catalog/books/prices?bookIds=<id>` directly, which broke the rule that services go through the gateway. The module was built from that working code, so the design follows what we learned.
- Orders does not reference `Catalog.Contracts`. It reads the response into a small model that belongs to Orders. That is a choice for this call. The Inventory call shares contracts, to show the other option.
- Catalog reads, such as the price endpoint, are public at the gateway. The realm has no client for calls without a user.
- `CatProblemDetails` is the error body of every service. It lives in `Cat.Minimal.Api`, which targets `net10.0`. It derives from the ASP.NET Core `ProblemDetails`, and its errors are `ICatError` interfaces that a client cannot deserialize. So a `netstandard2.0` client needs a plain class of its own for that shape.
- `Cat.Responses` and `Cat.Api.Gateway.Abstractions` already target `netstandard2.0`.
- `ServiceDefaults` adds the standard resilience handler, with retries and a circuit breaker, to every `HttpClient`. `Cat.Resilience` is only a plan.
- The AppHost makes the gateway wait for Orders. Orders must not wait for the gateway, or both wait forever. The gateway has a fixed port, so Orders can also get the address from configuration.
- The React client generates its types from a saved OpenAPI document of each service, in its `api/` folder, and a script refreshes the copy from the running AppHost. The services only publish the document in Development.
- The mapping table of the Aspire plan was the start of the error mapping: 200 gives an Ok response, 404 a failed response, 400 and other statuses an error response, a network error or timeout an error response.

#### What exists today
- The project `Cat.Api.Client` holds `CatApiCall`, `CatApiException`, `CatErrorResponse` and `CatErrorResponseItem`, and the registration extensions.
- The module has 27 tests.
- The shared `Contracts` variant is checked with the Inventory client. Its `nswag.json` lists `StockReservationModel` and `StockLineModel` in `excludedTypeNames` and adds the namespace of `Contracts` to `additionalNamespaceUsages`. The generated `InventoryClient.cs` does not define the two models and only imports the namespace. The client project references `Cat.Api.Client` and the `Contracts` project of Inventory.
- Orders uses three generated clients: Catalog, payment and Inventory. Each has a `ServiceName.Api.Client` project with a refresh script, such as `Refresh-CatalogClient.ps1`.
- Orders forwards the token of the caller with its own `ForwardBearerTokenHandler`.
- The module readme covers the layout of a client project, the NSwag settings, the call helper, the registration, the error mapping and resilience.
- The readme still marks the module as in development.

#### Decided
- **Route.** Calls go through the API gateway.
- **Result.** The client returns an `ICatResponse`.
- **Order of work.** The module is built from the working `HttpClient` code of Orders. The owner wants it before the Inventory stage of the demo.
- **Aspire.** The module never references Aspire.
- **What matters.** The client has no references except the module. It is easy to set up. A caller references the client and sets the address of the gateway.
- **Declaration.** The clients are generated with NSwag from a saved OpenAPI document. The generated code is checked in, so a fresh clone builds without the generator.
- **Generation project.** None. NSwag reads the saved document, so no project needs a reference to the API project.
- **Layout.** A service that offers a client gets a `ServiceName.Api.Client` project. It references the module and nothing else. The saved OpenAPI document and the NSwag settings sit with it.
- **Errors.** The generated code throws on a failed call. The module turns that into an `ICatResponse` in one place, so the generated code stays as it is.
- **Models.** By default the client has its own generated models. Sharing the `Contracts` project of the service is the choice of the developer, see the readme.
- **Shared Contracts.** The generated class and its methods are the same with and without shared `Contracts`. When the developer shares `Contracts`, the generator skips the models and imports the namespace of `Contracts`, and the client project references `Contracts`. The module is referenced in both cases, because it holds the base class, the exception type, the wrapper to `ICatResponse` and the NSwag settings template. The Inventory client of the demo uses this variant. Its `nswag.json` lists the models that `Contracts` already holds in `excludedTypeNames` and adds the namespace of `Contracts` to `additionalNamespaceUsages`. The Catalog and payment clients use their own models.
- **Token.** The client forwards the token of the caller. A client credentials token waits until a call needs it, because the realm has no client for that.
- **Error class.** The error body shape for clients is a plain class named `CatProblemDetails` in the namespace `Cat.Api.Client`. It replaces `CatErrorResponse`, which is renamed. Only the client uses it, so it is not shared and needs no project of its own. It has the same JSON shape as `CatProblemDetails` of `Cat.Minimal.Api` and a concrete error item, `CatProblemDetailsItem`, which replaces `CatErrorResponseItem`. The type in `Cat.Minimal.Api` stays, because it needs the ASP.NET Core `ProblemDetails` base. The two have the same name in different namespaces. The generated clients import only `Cat.Api.Client`, so they see one. A test keeps the two shapes equal. The wrapper of the module reads the body text of a failed call into the class, so it does not depend on the generated models.
- **Address.** The address of the gateway can come from configuration or from service discovery. Both work, and the module works without Aspire.
- **Serializer.** The generated code uses System.Text.Json, so the client has no extra package.
- **Resilience.** For now the client relies on the `HttpClient` handler from `ServiceDefaults`. Later, a developer who does not use Aspire should be able to use `Cat.Resilience` instead. That is looked at together with the plan of that module, see [Cat.Resilience.md](Cat.Resilience.md).
- **Refresh.** A script refreshes the saved OpenAPI document and runs the generation, like `api:refresh` of the React client. The output is checked in. Other ways, such as an MSBuild step, can come later.
- **Use.** The typed client is used inside a query or command handler in the infrastructure, as the readmes describe the architecture. A developer who wants to use it directly from a request handler can do so. The module does not forbid it.
- **Tracing.** The trace continues across the call. Whether the `HttpClient` instrumentation is enough for that is checked when the first call works.
- **First version.** No versioned APIs. JSON with GET and POST only, without file uploads and streaming.
- **First client.** Catalog, for the price call of Orders.
- **Direct calls.** Services never call each other directly, the payment service included. Every call goes through the gateway. The drawing of the demo shows this.
- **Order of the calls.** The call to Catalog came first. The payment call followed.
- **Payment call.** Orders calls the payment service through the gateway, with a generated client like the Catalog one. The gateway has a restricted route for `payment`, so a token is needed. Orders forwards the token of the user with a handler of its own, and the payment service validates the same token. Client credentials are not built, because no call without a user exists yet.
- **Audience.** The clients are for .NET code. The React client does not use the module. It generates TypeScript from the same OpenAPI documents.
- **Clashing types.** A developer needs no aliases for `CatProblemDetails` and `ICatError`. The settings template lists both in `excludedTypeNames`, so the generator does not write them, and the generated code finds `CatProblemDetails` through the `Cat.Api.Client` namespace that the template imports. Checked on a scratch copy of the Catalog client: the build had 0 errors. Aliases remain the way for other clashes, such as the alias for `IPaymentClient` in Orders.
- **Settings template.** The `Cat.Api.Client` package ships the NSwag settings template and a `build/Cat.Api.Client.targets` file that copies the template to `nswag.json` in the project folder when that file is missing, and never overwrites an existing one. It is off by default, so no project gets the file unasked. A project that wants it turns it on with an MSBuild property. The property name is picked when it is built, for example `CatApiClientNswagTemplate`. The module readme explains how to turn it on. A file in `contentFiles` alone does not reach the project folder, which is why the targets file is needed. This was checked in a scratch package.
- **Operation names.** The developer names the endpoints with `WithName` of ASP.NET Core, and the generator uses the name as the operation id, so the generated methods get clear names instead of `BooksGETAsync`. `Cat.Minimal.Api` does not set a default name. Endpoint names must be unique in the app, and a request type can be mapped more than once, so a default from the request type would fail with a 500 on the first request of an existing service. The module readme of `Cat.Minimal.Api` recommends `WithName`. In the demo every endpoint gets a clear name, as an example of that recommendation.

#### What to build
The module itself is built. What is left is the documentation and the close out.

**Error class:**
- Rename `CatErrorResponse` to `CatProblemDetails` and `CatErrorResponseItem` to `CatProblemDetailsItem` in `CatApiCall`, the test, the readme and the generated pages. This is a breaking change of two public types, and it changes code in `modules/`.
- The settings template lists `CatProblemDetails` and `ICatError` in `excludedTypeNames`.
- The three demo clients use the template and are generated again. Their aliases for these two types go.

**Settings template:**
- The package ships the template and the `build/Cat.Api.Client.targets` file, with the opt-in property.
- A test or a check that a project without the property gets no file, and a project with it gets the file once.

**Operation names in the demo:**
- Every endpoint of the demo services gets a name with `WithName`. Inventory has its two already.
- The saved OpenAPI documents and the generated clients are refreshed, and the code in Orders that calls the renamed methods is adjusted.

**The readme lacks these decisions of the plan:**
- The error class `CatProblemDetails` and why the clients need no alias for it and for `ICatError`.
- The settings template and how to turn it on with the property.
- Operation names. A short pointer to the chapter "Name your endpoints" in the readme of `Cat.Minimal.Api`, because the method names of a generated client depend on it.
- The token. The module does not forward it. The demo does that with its own `ForwardBearerTokenHandler` in Orders. A reader needs to know that, and how to add such a handler.
- The refresh script that downloads the OpenAPI document and runs the generation, such as `Refresh-CatalogClient.ps1`.
- The first version limits: no versioned APIs, GET and POST with JSON only, no uploads or streaming.
- The audience: the clients are for .NET code, and the React client generates TypeScript from the same documents.
- The shared `Contracts` variant, which the Inventory client of the demo uses.

**When both checks of question 1 are settled:**
- The readme gets these chapters.
- The roadmap stage 3b is marked done. It is not yet.
- The status of the module in the repo overview becomes Stable.
- The plan file and its links go. Links to remove: the badge link of the module row in the repo overview of the readme, `plans/Demo.md` (stage 3b and the notes), and `plans/Cat.Resilience.md` and `plans/Cat.Telemetry.md` if they link it.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->
<!-- region start: Question 1-->
#### Question 1
Is the module stable? The module is built and 27 tests pass. Orders uses it for three generated clients (Catalog, payment and Inventory). One thing from the decisions is still open, so the module is not called stable, and the badge, the roadmap and this plan are untouched. It is the owner's call once these are settled.

##### Question 1.2
Does the trace continue across the call? The decision says to check this. Check it in the Aspire dashboard with one placed order.
<!-- region end: Question 1-->

<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->