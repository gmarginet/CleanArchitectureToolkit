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

|&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Cat.Minimal.Api <!-- omit in toc -->  

<!-- Intro start-->
Cat.Minimal.Api turns service requests into ASP.NET Core minimal API endpoints. You map a request type to a route with one line. The endpoint reads the JSON body, runs the request through the service request processor and writes the result.

A succeeded response becomes a 200 with the payload. A failed response becomes a problem details object with the right status and the CAT errors, so clients always get one consistent error shape. Unexpected exceptions are caught and reported the same way.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Map a service request](#map-a-service-request)
  - [What the endpoint returns](#what-the-endpoint-returns)
  - [The problem details body](#the-problem-details-body)
  - [Errors and exceptions](#errors-and-exceptions)
    - [Unexpected exceptions](#unexpected-exceptions)

## NuGet packages
<!-- NuGet start -->
![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Minimal.Api)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Minimal.Api](https://www.nuget.org/packages/gmarginet.Cat.Minimal.Api/) | Implementation | `dotnet add package gmarginet.Cat.Minimal.Api` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Minimal.Api) |
<!-- NuGet end -->

## Namespaces
<!-- Namespaces start-->
| Namespace | What it holds |
|-----------|---------------|
| [Cat.Minimal.Api](namespaces/Cat.Minimal.Api/index.md) | Maps service requests to minimal API endpoints. |
<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->
| Module | Why Cat.Minimal.Api needs it |
|--------|-----------------------------|
| [Cat.Responses](../Cat.Responses/README.md) | Endpoints turn responses into results and problem details. |
| [Cat.ServiceRequests](../Cat.ServiceRequests/README.md) | Endpoints run requests through the service request processor. |
<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

Call `AddCatMinimalApiModule` to register the exception handler and the problem details services. Add `UseExceptionHandler` to the pipeline so the handler catches unexpected exceptions.

The endpoints run through `ICatServiceRequestProcessor`, so register the Cat.ServiceRequests module too.

```csharp
using Cat.Minimal.Api.Extensions;
using Cat.ServiceRequests.Extensions;

builder.Services.AddCatMinimalApiModule();
builder.Services.AddCatServiceRequestsModule(typeof(TodoGetRequestHandler));

var app = builder.Build();

app.UseExceptionHandler();
```

### Map a service request

Call `MapCatServiceRequest` on the app or on a route group. Pass the request type and a route pattern. Each call creates one POST endpoint.

There are two forms:

- **`MapCatServiceRequest<TRequest>`:** For a request that implements `ICatServiceRequest`. The endpoint returns no body on success.
- **`MapCatServiceRequest<TRequest, TResponse>`:** For a request that implements `ICatServiceRequest<TResponse>`. The endpoint returns the payload on success.

```csharp
using Cat.Minimal.Api;

var group = app.MapGroup("/todo");

group.MapCatServiceRequest<TodoGetListRequest, IList<TodoModel>>("/list");
group.MapCatServiceRequest<TodoGetRequest, TodoModel>("/get");
group.MapCatServiceRequest<TodoSaveRequest>("/create-update");
```

Clients send the request as a JSON body:

```http
POST /todo/get HTTP/1.1
Content-Type: application/json

{"todoId":1}
```

An empty body creates the request with its parameterless constructor. A request type without one, like a record with positional parameters, gets a 400 instead.

### What the endpoint returns

| Outcome of the response | HTTP status | Body |
|-------------------------|-------------|------|
| Succeeded, with a payload | 200 | The payload as JSON. |
| Succeeded, without a payload | 200 | None. |
| BadRequest, like a failed validation | 400 | Problem details. |
| Empty body, and the request type has no parameterless constructor | 400 | Problem details. |
| Unauthorized | 401 | Problem details. |
| NotFound | 404 | Problem details. |
| Any other failure | 500 | Problem details. |

The endpoint also logs every failed response with its errors and a trace id.

The generated OpenAPI description lists 200, 400, 401, 404 and 500.

### The problem details body

A failed response is written as `CatProblemDetails`. It is a standard problem details object with two extra properties:

- **`catErrors`:** One entry per error, each with a `code`, a `message` template and `arguments`.
- **`catTraceId`:** The id to find this request in the logs.

```json
{
  "title": "A bad request was made.",
  "status": 400,
  "detail": "Look at the CatErrors property for more details.",
  "instance": "/todo/get",
  "catErrors": [
    {
      "code": "CAT-VAL-1001",
      "message": "'{propertyName}' should not be Null (Empty).",
      "arguments": [ "TodoId" ]
    }
  ],
  "catTraceId": "00-4bf92f3577b34da6a3ce929d0e0e4736-00f067aa0ba902b7-00"
}
```

The message is a template. Fill its placeholders with the `arguments`, in order. The first argument is the field name for validation errors.

### Errors and exceptions

Every failure reaches the client as a `CatProblemDetails` body. These are the kinds you can get:

| Kind | Status | `title` | `detail` | `catErrors` |
|------|--------|---------|----------|-------------|
| A failed `BadRequest` response | 400 | `A bad request was made.` | `Look at the CatErrors property for more details.` | The errors of the response. |
| A failed `NotFound` response | 404 | `The requested resource was not found.` | `Look at the CatErrors property for more details.` | The errors of the response. |
| A failed `Unauthorized` response | 401 | `The request was not authorized.` | `Look at the CatErrors property for more details.` | The errors of the response. |
| Any other failed response | 500 | `An unexpected error occurred.` | `Look at the CatErrors property for more details.` | The errors of the response. |
| An empty body for a request without a parameterless constructor | 400 | `A bad request was made.` | `The request body is required.` | An empty list. |
| An unexpected exception | 500 | `An unexpected error occurred.` | Depends on the environment, see below. | An empty list. |

The failed responses you can get depend on the handler and its decorators. A request that fails validation gives the rule errors of [Cat.Validators](../Cat.Validators/README.md#rules) in `catErrors`, with `CAT-VAL-` codes. A handler that returns `NotFound` gives the code and message it chose, like `CAT-DEM-1000` in the demo.

A client can branch on the status first, then on the `code` of each error:

```csharp
var response = await httpClient.PostAsJsonAsync("/todo/get", new { todoId = 1 });

if (response.IsSuccessStatusCode is false)
{
    var problem = await response.Content.ReadFromJsonAsync<CatProblemDetails>();

    foreach (var error in problem!.CatErrors ?? [])
    {
        Console.WriteLine($"{error.Code}: {error.Message}");
    }
}
```

Other things to know:

- **Module not registered:** Without `AddCatMinimalApiModule` and `UseExceptionHandler`, an unexpected exception gives the default ASP.NET Core 500 and not a `CatProblemDetails`.
- **Service requests not registered:** Without `AddCatServiceRequestsModule`, the endpoint can't resolve `ICatServiceRequestProcessor`, and the exception handler turns that into a 500.
- **Handler not found:** A request type without a registered handler also ends as a 500 for the same reason.

#### Unexpected exceptions

When a handler throws, the exception handler logs it and answers with a 500 `CatProblemDetails`:

- **`title`:** `An unexpected error occurred.`
- **`status`:** `500`
- **`catErrors`:** An empty list.
- **`catTraceId`:** The id to find the exception in the logs.

What the client sees about the exception depends on the environment, so internal details stay private:

| Environment | `type` | `detail` |
|-------------|--------|----------|
| Development | The name of the exception type. | The exception message. |
| Any other | Not set. | `Use the CatTraceId to find the error in the logs.` |

Expected failures, like a missing resource or a failed validation, should come back as failed responses, not exceptions. They give the client a useful status and error codes.
<!-- Usage end-->
