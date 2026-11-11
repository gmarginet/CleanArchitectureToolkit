<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: ../.. -->
<link href="../../resources/styles/style.css" rel="stylesheet" />
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
            <img src='../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-module-readme skill to update this readme.-->
<!-- region end: TemplateSkill-->

# Cat.Api.Client <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Api.Client lets one service call another service through the API gateway with a typed client. Services never call each other directly, so the call always goes to the gateway, which forwards it.

The client class is generated from the OpenAPI document of the other service. This module holds what the generated code needs: the exception it throws, the plain class for the error body, and one helper that turns the outcome of a call into an `ICatResponse`. A failed call then looks like any other failed use case.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [What a client project holds](#what-a-client-project-holds)
  - [Start from the settings template](#start-from-the-settings-template)
  - [Generate the client](#generate-the-client)
  - [Name the methods](#name-the-methods)
  - [Share the Contracts of a service](#share-the-contracts-of-a-service)
  - [Call a service](#call-a-service)
  - [Register the client](#register-the-client)
  - [Forward the token](#forward-the-token)
  - [How errors map to a response](#how-errors-map-to-a-response)
  - [Resilience](#resilience)
  - [What the first version covers](#what-the-first-version-covers)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Api.Client)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Api.Client](https://www.nuget.org/packages/gmarginet.Cat.Api.Client/) | Implementation | `dotnet add package gmarginet.Cat.Api.Client` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Api.Client)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Api.Client](namespaces/Cat.Api.Client/index.md) | The exception and the error body class for generated clients, the call helper, and the registration of a client. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.Api.Client needs it |
|--------|-----------------------------|
| [Cat.Responses](../Cat.Responses/README.md) | The call helper returns an `ICatResponse` and builds its errors with `CatError`. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
The module targets `netstandard2.0`. It has no reference to Aspire, to ASP.NET Core or to service discovery. A service that calls another service references the client project of that service and nothing else from this module.

### What a client project holds
A service that offers a client gets a project named `ServiceName.Api.Client`. It holds:

- a saved copy of the OpenAPI document of the service,
- the settings for the generator (NSwag),
- the generated client code, which is checked in.

The project references `Cat.Api.Client` and nothing else. By default the generated code has its own models, so the caller does not need the contracts of the other service. Nothing needs a reference to the API project of the service, because the generator reads the saved document.

### Start from the settings template
The package ships a template of the NSwag settings. It is off by default, so no project gets a file it did not ask for. Turn it on in the client project:

```xml
<PropertyGroup>
    <CatApiClientNswagTemplate>true</CatApiClientNswagTemplate>
</PropertyGroup>
```

The next build copies the template to `nswag.json` in the project folder. A `nswag.json` that already exists is never overwritten, so you can remove the property afterwards.

Change these settings in your copy for the service:

- `json`: the saved OpenAPI document of the service.
- `className`: the name of the generated client, such as `CatalogClient`.
- `namespace`: the namespace of the client project.
- `output`: the file that NSwag writes, such as `CatalogClient.cs`.

Leave the rest as it is. The next chapter explains it.

### Generate the client
The template makes the generated code throw `CatApiException` from this module, use System.Text.Json and take an `HttpClient` in its constructor. These are its settings:

| Setting | Value |
|---------|-------|
| `jsonLibrary` | `SystemTextJson` |
| `injectHttpClient` | `true` |
| `useBaseUrl` | `false` |
| `generateClientInterfaces` | `true` |
| `generateExceptionClasses` | `false` |
| `exceptionClass` | `CatApiException` |
| `additionalNamespaceUsages` | `Cat.Api.Client` |
| `excludedTypeNames` | `CatProblemDetails`, `ICatError` |
| `generateNullableReferenceTypes` | `true` |
| `operationGenerationMode` | `SingleClientFromOperationId` |

The generated class throws `CatApiException` for a failed call. It also throws `CatApiException<TResult>` when the document describes the error body. Both classes come from this module.

The error body of every service has the same shape. The generator would write its own `CatProblemDetails` and `ICatError` into every client. This module already has a `CatProblemDetails`, and `ICatError` belongs to `Cat.Responses`. So the template leaves both out, and the generated code finds `CatProblemDetails` through the `Cat.Api.Client` namespace. A caller that uses several clients and `Cat.Responses` then needs no alias for these two types.

To generate the client again, download the OpenAPI document of the service and run NSwag:

```
dotnet tool restore
dotnet nswag run nswag.json
```

NSwag is a local tool of the repository, listed in `dotnet-tools.json`. The services only publish their document in Development, so start the service first. Commit the changed document and the changed client together.

The demo has a script for this in every client project, such as `Refresh-CatalogClient.ps1`. It downloads the document and runs NSwag. The scripts are not part of the package. Write one like it for your own client.

### Name the methods
NSwag builds the method names of the generated client from the operation id of each endpoint. An endpoint without a name gets a generated one, such as `BooksGETAsync`. Name your endpoints with `WithName` in the service and the methods get clear names, such as `GetBookPricesAsync`. The readme of `Cat.Minimal.Api` explains it in [Name your endpoints](../Cat.Minimal.Api/README.md#name-your-endpoints).

### Share the Contracts of a service
By default the client has its own generated models, so the caller does not need the contracts of the other service. Sharing the `Contracts` project of the service is your choice. It saves the duplicate models, and it ties the caller to the contracts of the other service.

The generated class and its methods are the same either way. To share, make two changes:

- Reference the `Contracts` project of the service from the client project. It still references `Cat.Api.Client`.
- In `nswag.json`, add the models that `Contracts` already holds to `excludedTypeNames`, and add the namespace of `Contracts` to `additionalNamespaceUsages`. The generator then skips those models and imports the namespace.

The Inventory client of the demo does this:

```json
"excludedTypeNames": [ "CatProblemDetails", "ICatError", "StockReservationModel", "StockLineModel" ],
"additionalNamespaceUsages": [ "Cat.Api.Client", "Cat.Demo.InventoryService.Contracts.Models" ],
```

Add a name to `excludedTypeNames` whenever a new model joins the `Contracts` project. The Catalog and payment clients of the demo use their own models.
### Call a service
Wrap the call in `CatApiCall.ExecuteAsync`. It returns an `ICatResponse<T>`, so the caller never catches the exceptions of the client. Use it in a query or command handler in the infrastructure of the service. A request handler can use it directly as well.

```csharp
var response = await CatApiCall.ExecuteAsync(
    () => _catalogClient.GetBookPricesAsync(bookIds, cancellationToken),
    "Catalog",
    cancellationToken);

if (response.IsFailed)
{
    return response.Cast<IReadOnlyDictionary<Guid, decimal>>();
}

return CatResponse.Ok<IReadOnlyDictionary<Guid, decimal>>(
    response.Value.ToDictionary(x => x.BookId, x => x.Price));
```

A cancel by the caller is not turned into a response. The call throws as usual.

### Register the client
`AddCatApiClient` registers the generated client with its own `HttpClient`, pointed at the gateway. It returns the `IHttpClientBuilder`, so you can add handlers.

```csharp
services.AddCatApiClient<ICatalogClient, CatalogClient>(configuration["Gateway:Address"]!);
```

The address is a plain string. It can come from configuration, or it can be an address that service discovery resolves, such as `https+http://gateway`. The module does not reference service discovery.

### Forward the token
The module does not forward the token of the caller. When the gateway route is not anonymous, add a handler that passes the `Authorization` header on to the call. `AddCatApiClient` returns the `IHttpClientBuilder`, so you add the handler there.

```csharp
public class ForwardBearerTokenHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ForwardBearerTokenHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var authorization = _httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization].ToString();
        if (!string.IsNullOrEmpty(authorization) && request.Headers.Authorization is null)
        {
            request.Headers.TryAddWithoutValidation(HeaderNames.Authorization, authorization);
        }

        return base.SendAsync(request, cancellationToken);
    }
}
```

```csharp
services.AddHttpContextAccessor();
services.TryAddTransient<ForwardBearerTokenHandler>();
services.AddCatApiClient<IPaymentClient, PaymentClient>("https+http://gateway")
    .AddHttpMessageHandler<ForwardBearerTokenHandler>();
```

Orders in the demo does this for the payment client. Without an incoming request, for example in a background job, there is no token to pass, and the gateway answers 401. A call with a token of the service itself, from client credentials, is not part of the module.
### How errors map to a response
All services share one error body. `CatProblemDetails` of `Cat.Api.Client` reads it. It has the same name and the same JSON shape as `CatProblemDetails` of `Cat.Minimal.Api`, without the ASP.NET Core base type. The helper keeps the errors of the service with their codes and arguments. A generated client keeps the body text only when it could not read the body, so the helper also reads the error body from the model that the client filled.

| The call | The response |
|----------|--------------|
| Succeeds | `Ok`, with the value. |
| Answers 400 | `BadRequest` with the errors of the service. |
| Answers 401 | `Unauthorized` with the errors of the service. |
| Answers 403 | `Forbidden` with the errors of the service. |
| Answers 404 | `NotFound` with the errors of the service. |
| Answers 409 | `Conflict` with the errors of the service. |
| Answers anything else | `InternalServerError` with the errors of the service. |
| Answers without usable errors | The status picks the type, and the error is `CAT-GEN-1001`, an unexpected response from the named service. |
| Cannot connect, times out or reads a body it does not understand | `InternalServerError` with `CAT-GEN-1001`. |

An exception that is not about the call, such as a bug in your own code, is not caught.

### Resilience
The module adds no retries and no circuit breaker. Add them to the `HttpClient` the way the host does for every client, for example with the standard resilience handler of `ServiceDefaults`. Two retry layers multiply, so use one.

### What the first version covers
- The clients are for .NET code. The React client of the demo does not use this module. It generates TypeScript from the same OpenAPI documents.
- The first version is made for JSON calls with GET and POST. It has no support for versioned APIs, file uploads or streaming.
<!-- region end: Usage-->
