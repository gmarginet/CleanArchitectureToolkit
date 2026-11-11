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

# Cat.Minimal.Api <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Minimal.Api turns service requests into ASP.NET Core minimal API endpoints. You map a request type to a route with one line per http method. The endpoint runs the request through the service request processor and writes the result.

You decide which response types your handler returns. The OpenAPI description lists exactly those status codes, so the consumers of your api see what the endpoint really does. A failed response becomes a problem details object with the CAT errors, so clients always get one consistent error shape. Unexpected exceptions and requests that can't be bound are reported the same way.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Map a service request](#map-a-service-request)
  - [Choose the response types](#choose-the-response-types)
  - [Return the created value with a location](#return-the-created-value-with-a-location)
  - [Patch with a JSON Patch document](#patch-with-a-json-patch-document)
  - [What the endpoint returns](#what-the-endpoint-returns)
  - [The OpenAPI description](#the-openapi-description)
  - [The problem details body](#the-problem-details-body)
  - [Errors and exceptions](#errors-and-exceptions)
    - [Unexpected exceptions](#unexpected-exceptions)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Minimal.Api)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Minimal.Api](https://www.nuget.org/packages/gmarginet.Cat.Minimal.Api/) | Implementation | `dotnet add package gmarginet.Cat.Minimal.Api` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Minimal.Api)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Minimal.Api](namespaces/Cat.Minimal.Api/index.md) | Maps service requests to minimal API endpoints and reports failures as problem details. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.Minimal.Api needs it |
|--------|-----------------------------|
| [Cat.Responses](../Cat.Responses/README.md) | Endpoints turn responses into results and problem details, and list the response types in the OpenAPI description. |
| [Cat.ServiceRequests](../Cat.ServiceRequests/README.md) | Endpoints run requests through the service request processor. The patch endpoint uses its `PatchDocumentRequest`. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Register the module

Call `AddCatMinimalApiModule` to register the exception handler and the problem details services. Call `UseCatMinimalApiModule` early in the pipeline, before you map the endpoints.

The endpoints run through `ICatServiceRequestProcessor`, so register the Cat.ServiceRequests module too.

```csharp
using Cat.Minimal.Api.Extensions;
using Cat.ServiceRequests.Extensions;

builder.Services.AddCatMinimalApiModule();
builder.Services.AddCatServiceRequestsModule(typeof(TodoGetRequestHandler));

var app = builder.Build();

app.UseCatMinimalApiModule();
```

What the two calls set up:

- **Exception handler:** Catches exceptions that escape an endpoint and answers with a problem details body.
- **Binding failures:** A request that can't be bound, like malformed JSON, throws in every environment. ASP.NET Core only does that in Development by default. Now the handler answers with a 400 problem details body everywhere.
- **One error shape:** Problem details the framework creates itself, like a 404 for an unknown route, get the `catErrors` and `catTraceId` properties too.
- **One trace id:** The framework's own `traceId` property is removed, because `catTraceId` holds the same value.
- **Status code pages:** An empty error response, like a 404, gets a problem details body.

### Map a service request

Call one of the `MapCat` methods on the app or on a route group. Pass the request type and a route pattern. Each call maps one http method.

| Method | Http method | The request implements | Default response type |
|--------|-------------|------------------------|-----------------------|
| `MapCatGet<TRequest, TResponse>` | GET | `ICatServiceRequest<TResponse>` | `Ok` |
| `MapCatGetList<TRequest, TResponse>` | GET | `ICatServiceRequest<IList<TResponse>>` | `Ok` |
| `MapCatGetPagedList<TRequest, TResponse>` | GET | `ICatServiceRequest<ICatPagedList<TResponse>>` | `Ok` |
| `MapCatPost<TRequest>` | POST | `ICatServiceRequest` | `Created` |
| `MapCatPost<TRequest, TResponse>` | POST | `ICatServiceRequest<TResponse>` | `Created` |
| `MapCatPut<TRequest>` | PUT | `ICatServiceRequest` | `NoContent` |
| `MapCatPatch<TRequest>` | PATCH | `ICatServiceRequest` | `NoContent` |
| `MapCatPatchDocument<TRouteParameters, TModel>` | PATCH | None, see [Patch with a JSON Patch document](#patch-with-a-json-patch-document) | `NoContent` |
| `MapCatDelete<TRequest>` | DELETE | `ICatServiceRequest` | `NoContent` |

Every method returns the `RouteHandlerBuilder`, so you can chain `WithName`, `RequireAuthorization` and the other endpoint methods.

```csharp
using Cat.Minimal.Api;
using Cat.Responses.Abstractions;

var group = app.MapGroup("/todo");

group.MapCatGetList<TodoGetListRequest, TodoModel>("/");
group.MapCatGet<TodoGetRequest, TodoModel>("/{todoId:int}", CatResponseType.Ok, CatResponseType.NotFound)
    .WithName("GetTodo");
group.MapCatPost<TodoSaveRequest>("/", CatResponseType.Ok);
```

The endpoint reads the request like any minimal API handler with `[AsParameters]`. A property binds from the route, the query string, the headers or the body.

- **Route and query:** Name the property like the route parameter. `TodoId` binds the `{todoId:int}` in the route.
- **Body:** A property of a complex type binds from the JSON body on POST, PUT and PATCH. Add `[FromBody]` to make that explicit.

```csharp
public record TodoGetRequest(int? TodoId) : ICatServiceRequest<TodoModel>;

public record TodoSaveRequest(TodoModel? Todo) : ICatServiceRequest;
```

The body holds the `TodoModel` itself. It doesn't wrap it in the request:

```http
POST /todo/ HTTP/1.1
Content-Type: application/json

{"id":1,"categoryId":1,"title":"Todo 1","description":"Description for todo 1."}
```

### Choose the response types

Pass the response types your handler returns as the last arguments. The endpoint documents them and allows them at runtime.

Leave them out and the endpoint uses the default of its http method:

| Http method | Default |
|-------------|---------|
| GET | `Ok` |
| POST | `Created` |
| PUT, PATCH and DELETE | `NoContent` |

Your list replaces the default. List `Ok` again when you still return it.

Some status codes can always happen, so every endpoint allows and documents them, whatever you pass:

- **400:** The request can fail to bind, like malformed JSON or a value that doesn't parse.
- **500:** An unexpected exception can always occur.
- **415:** Only for an endpoint that reads a body, because the content type can be wrong.

These are the response types you can pass:

| Response type | HTTP status |
|---------------|-------------|
| `Ok` | 200 |
| `Created` | 201 |
| `NoContent` | 204 |
| `BadRequest` | 400 |
| `Unauthorized` | 401 |
| `Forbidden` | 403 |
| `NotFound` | 404 |
| `Conflict` | 409 |
| `InternalServerError` | 500 |

The endpoint checks the response type of the handler at runtime. A handler that returns a type the endpoint doesn't list causes a 500. In the Development environment the detail names the type to add:

```text
The ServiceRequestHandler that handled the TodoGetRequest request returned CatResponseType Conflict.
This GET endpoint only allows Ok, NotFound, BadRequest, InternalServerError.
Add Conflict to the responseTypes argument where the endpoint is mapped.
```

That way the OpenAPI description and the real behavior can't drift apart unnoticed.

### Return the created value with a location

`MapCatPost<TRequest, TResponse>` returns the created value in the body of a `Created` response. Pass a `location` to add the Location header. It builds the header from the created value.

```csharp
group.MapCatPost<TodoCreateRequest, TodoModel>("/", todo => $"/todo/{todo.Id}", CatResponseType.Created, CatResponseType.Conflict);
```

Without a `location`, or when it returns `null`, the response has no Location header.

### Patch with a JSON Patch document

`MapCatPatchDocument` accepts a JSON Patch document (`application/json-patch+json`). Give it a type for the route values and the model the patch applies to.

```csharp
public record TodoRouteParameters(int TodoId);

group.MapCatPatchDocument<TodoRouteParameters, TodoModel>("/{todoId:int}");
```

The handler receives a `PatchDocumentRequest<TRouteParameters, TModel>` from the Cat.ServiceRequests.Minimal.Api package. See [Cat.ServiceRequests](../Cat.ServiceRequests/README.md#handle-a-json-patch-document) for the handler.

```http
PATCH /todo/1 HTTP/1.1
Content-Type: application/json-patch+json

[{ "op": "replace", "path": "/title", "value": "New title" }]
```

A request without a patch document in its body gets a 400. A request with another content type gets a 415.

The patch types come from `Microsoft.AspNetCore.JsonPatch.SystemTextJson`, which supports `net10.0` and up.

### What the endpoint returns

| Response of the handler | HTTP status | Body |
|-------------------------|-------------|------|
| `Ok` with a value | 200 | The value as JSON. |
| `Ok` without a value | 200 | None. |
| `Created` with a value | 201 | The value as JSON. A Location header when you pass a `location`. |
| `Created` without a value | 201 | None. |
| `NoContent` | 204 | None. |
| `BadRequest`, like a failed validation | 400 | Problem details. |
| `Unauthorized` | 401 | Problem details. |
| `Forbidden` | 403 | Problem details. |
| `NotFound` | 404 | Problem details. |
| `Conflict` | 409 | Problem details. |
| `InternalServerError` | 500 | Problem details. |
| A type the endpoint doesn't list | 500 | Problem details. |

Use `Unauthorized` when the caller isn't authenticated. Use `Forbidden` when the caller is authenticated but isn't allowed to do this.

### The OpenAPI description

Each endpoint lists the response types you passed, plus 400 and 500, plus 415 when it reads a body. It lists nothing else.

- **Succeeded types:** `Ok` and `Created` document the value as `application/json`. The other succeeded types have no body.
- **Failed types:** They document `CatProblemDetails` as `application/problem+json`.

For the endpoints in the example above, the description lists:

| Endpoint | Documented status codes |
|----------|-------------------------|
| `GET /todo` | 200, 400, 500 |
| `GET /todo/{todoId}` | 200, 404, 400, 500 |
| `POST /todo` | 200, 400, 500, 415 |

A consumer of your api reads the status codes the handler really uses, not a fixed list of everything the module supports.

### The problem details body

A failed response is written as `CatProblemDetails`. It is a standard problem details object with two extra properties:

- **`catErrors`:** One entry per error, each with a `code`, a `message` template and `arguments`.
- **`catTraceId`:** The id to find this request in the logs.

```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
  "title": "The requested resource was not found.",
  "status": 404,
  "detail": "Look at the CatErrors property for more details.",
  "instance": "/todo/99999",
  "catErrors": [
    {
      "code": "CAT-DEM-1000",
      "message": "{ResourceName} with id {id} could not be found.",
      "arguments": [ "Todo", 99999 ]
    }
  ],
  "catTraceId": "00-4830c1162ed931d8ea980122e08eb547-6e98ab8852f34d7e-00"
}
```

The message is a template. Fill its placeholders with the `arguments`, in order. The first argument is the field name for validation errors.

### Errors and exceptions

Every failure reaches the client as a problem details body with the `catErrors` and `catTraceId` properties. These are the kinds you can get:

| Kind | Status | `title` | `detail` | `catErrors` |
|------|--------|---------|----------|-------------|
| A failed `BadRequest` response | 400 | `The request isn't valid.` | `Look at the CatErrors property for more details.` | The errors of the response. |
| A failed `Unauthorized` response | 401 | `Authentication is required for this request.` | `Look at the CatErrors property for more details.` | The errors of the response. |
| A failed `Forbidden` response | 403 | `The caller isn't allowed to perform this request.` | `Look at the CatErrors property for more details.` | The errors of the response. |
| A failed `NotFound` response | 404 | `The requested resource was not found.` | `Look at the CatErrors property for more details.` | The errors of the response. |
| A failed `Conflict` response | 409 | `The request conflicts with the current state of the resource.` | `Look at the CatErrors property for more details.` | The errors of the response. |
| A failed `InternalServerError` response | 500 | `An unexpected error occurred.` | `Look at the CatErrors property for more details.` | The errors of the response. |
| A request that can't be bound, like malformed JSON | 400 | `The request isn't valid.` | The reason from ASP.NET Core. | An empty list. |
| A patch endpoint without a patch document | 400 | `The request isn't valid.` | `The request has no patch document in its body.` | An empty list. |
| A content type the endpoint doesn't read | 415 | `Unsupported Media Type` | None. | An empty list. |
| An unknown route or a method that isn't mapped | 404 or 405 | The standard title of the status. | None. | An empty list. |
| A response type the endpoint doesn't list | 500 | `An unexpected error occurred.` | Depends on the environment, see below. | An empty list. |
| An unexpected exception | 500 | `An unexpected error occurred.` | Depends on the environment, see below. | An empty list. |

The failed responses you can get depend on the handler and its decorators. A request that fails validation gives the rule errors of [Cat.Validators](../Cat.Validators/README.md#rules) in `catErrors`, with `CAT-VAL-` codes. A handler that returns `NotFound` gives the code and message it chose, like `CAT-DEM-1000` in the demo.

A client can branch on the status first, then on the `code` of each error:

```csharp
var response = await httpClient.GetAsync("/todo/1");

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

- **Module not registered:** Without `AddCatMinimalApiModule` and `UseCatMinimalApiModule`, an unexpected exception gives the default ASP.NET Core 500 and not a `CatProblemDetails`.
- **Service requests not registered:** Without `AddCatServiceRequestsModule`, the endpoint can't resolve `ICatServiceRequestProcessor`, and the exception handler turns that into a 500.
- **Handler not found:** A request type without a registered handler also ends as a 500 for the same reason.
- **Client left:** When the client closes the request, the handler answers with status 499 and no body. It logs this at debug level, not as an error.

#### Unexpected exceptions

When a handler throws, or returns a response type the endpoint doesn't list, the exception handler logs it and answers with a 500 `CatProblemDetails`:

- **`title`:** `An unexpected error occurred.`
- **`status`:** `500`
- **`catErrors`:** An empty list.
- **`catTraceId`:** The id to find the exception in the logs.

What the client sees about the exception depends on the environment, so internal details stay private:

| Environment | `detail` |
|-------------|----------|
| Development | The exception type name and message, like `InvalidOperationException: secret detail`. |
| Any other | `Use the CatTraceId to find the error in the logs.` |

Expected failures, like a missing resource or a failed validation, should come back as failed responses, not exceptions. They give the client a useful status and error codes.
<!-- region end: Usage-->
