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

#### To check at the build
- The exact Aspire call for a Node.js app in `Aspire.Hosting.JavaScript` 13.6.5, and whether it runs `npm install` itself.
- Every place that names `PaymentService` or the resource `payment`: the AppHost, the solution, the demo readme, the demo drawing `CatDemoArchitecture.excalidraw.svg` and the `cat-internal-create-demo-unit` skill.

#### What the build changes
- Remove the three .NET projects and their entries in `CleanArchitectureToolkit.slnx`.
- Add the Node.js API in `demo/Cat.Demo.PaymentProvider/`.
- Run it from the AppHost with the same port, API key, failure settings and health check.
- Update the demo readme and the demo drawing with the `cat-internal-create-demo-readme` skill.
<!-- region end: PhaseDescription-->

### Open Questions
<!-- region start: PhaseOpenQuestions-->

<!-- region start: Question 1-->
#### Question 1
Do we write it in TypeScript or in plain JavaScript? The options:
- **TypeScript.** The same language as the web client, with types for the requests and the answers. Cost: a build or a type stripping step before it runs.
- **Plain JavaScript.** Node runs it as it is. Cost: no types, and a second style of code next to the web client.

Recommendation: TypeScript. The web client already sets the style, and the types make the contract easy to read next to the OpenAPI document.
<!-- region end: Question 1-->

<!-- region start: Question 2-->
#### Question 2
Which HTTP layer do we use? The options:
- **The built-in `node:http`.** No packages at all. Cost: more code for routing, JSON and errors.
- **Express.** The best known choice. Cost: one package, and its typing is a separate package.
- **Fastify.** Small, fast and typed, with schema checks for the body. Cost: one package that fewer readers know.

Recommendation: Fastify. It keeps the code short, it checks the request body with a schema, and it has its own types.
<!-- region end: Question 2-->

<!-- region start: Question 3-->
#### Question 3
Where does the OpenAPI document come from? The options:
- **A static file,** the current document, served at `/openapi/v1.json`. Cost: a change to an endpoint also means a change to the file by hand.
- **Generated from the route schemas,** for example with `@fastify/swagger`. Cost: the document will differ from the copy in Orders, such as the `decimal` format, and the client of Orders may change.

Recommendation: the static file. It is the contract that was decided to stay the same, and the refresh script of Orders keeps working.
<!-- region end: Question 3-->

<!-- region start: Question 4-->
#### Question 4
Where do the tests run? The 10 tests of `PaymentProcessorTests` move to a Node.js test runner. The options:
- **In the package only,** with `npm test`, like the web client today. Cost: `dotnet cake --target=Test` and the build workflow no longer test the provider.
- **Also from Cake,** with a step in the `Test` target that runs `npm test` for the provider, and the web client too. Cost: a change to `build.cake` and Node.js on the build agent. A commit that changes `build.cake` publishes.

Recommendation: in the package only, with Vitest like the web client, and a separate decision about Node.js tests in Cake for both. The provider is a stand-in, and the tests of Orders cover how the shop handles its answers.
<!-- region end: Question 4-->

<!-- region start: Question 5-->
#### Question 5
What do the settings look like? The .NET names are `Provider__ApiKey` and `PaymentFailures__Latency`, and the latency is a `TimeSpan` such as `00:00:02`. The options:
- **Keep the names and the formats.** Cost: a Node.js app that reads .NET style settings, which hides that it is outside.
- **Node.js style names,** such as `PROVIDER_API_KEY`, `FAILURE_LATENCY_MS`, `FAILURE_ERROR_PERCENTAGE` and `FAILURE_OUTAGE`, with the latency in milliseconds. The AppHost maps `Payment:Latency` and the others to them. Cost: the setting `Payment:Latency` in the AppHost changes to milliseconds, and the demo readme with it.

Recommendation: Node.js style names, with the latency in milliseconds. A real provider has its own settings, and the AppHost is the one place that maps them.
<!-- region end: Question 5-->

<!-- region start: Question 6-->
#### Question 6
Does the provider export telemetry? The .NET provider exports none today, and the client of Orders stops the trace at its boundary. The options:
- **No telemetry,** as today. Cost: the dashboard shows only its logs.
- **OpenTelemetry for Node.js.** Cost: packages and setup, and a trace of an outside system that a real provider would never send.

Recommendation: no telemetry. A real provider sends none, and the trace boundary of Orders is built for that.
<!-- region end: Question 6-->
<!-- region end: PhaseOpenQuestions-->
<!-- region end: Phase 1-->
