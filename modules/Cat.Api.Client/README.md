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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

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
  - [Generate the client](#generate-the-client)
  - [Call a service](#call-a-service)
  - [Register the client](#register-the-client)
  - [How errors map to a response](#how-errors-map-to-a-response)
  - [Resilience](#resilience)

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

### Generate the client
Use these NSwag settings. They make the generated code throw `CatApiException` from this module, use System.Text.Json and take an `HttpClient` in its constructor.

| Setting | Value |
|---------|-------|
| `jsonLibrary` | `SystemTextJson` |
| `injectHttpClient` | `true` |
| `useBaseUrl` | `false` |
| `generateClientInterfaces` | `true` |
| `generateExceptionClasses` | `false` |
| `exceptionClass` | `CatApiException` |
| `additionalNamespaceUsages` | `Cat.Api.Client` |
| `generateNullableReferenceTypes` | `true` |
| `operationGenerationMode` | `SingleClientFromOperationId` |

The generated class throws `CatApiException` for a failed call. It also throws `CatApiException<TResult>` when the document describes the error body. Both classes come from this module.

### Call a service
Wrap the call in `CatApiCall.ExecuteAsync`. It returns an `ICatResponse<T>`, so the caller never catches the exceptions of the client. Use it in a query or command handler in the infrastructure of the service. A request handler can use it directly as well.

```csharp
var response = await CatApiCall.ExecuteAsync(
    () => _catalogClient.PricesAsync(bookIds, cancellationToken),
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

### How errors map to a response
All services share one error body. `CatErrorResponse` reads it. It has the same JSON shape as `CatProblemDetails` of `Cat.Minimal.Api`, without the ASP.NET Core base type. The helper keeps the errors of the service with their codes and arguments. A generated client keeps the body text only when it could not read the body, so the helper also reads the error body from the model that the client filled.

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
<!-- region end: Usage-->
