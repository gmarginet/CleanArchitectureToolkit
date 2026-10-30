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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Cat.ServiceRequests <!-- omit in toc -->  

<!-- Intro start-->
Cat.ServiceRequests gives you one entry point for running application use cases. You describe a use case as a service request, write one handler for it, and hand the request to the processor. The processor finds the handler for you and returns an `ICatResponse`.

Handlers can be wrapped in decorators for cross-cutting work. The module ships three: validation, logging and activity tracing. You switch each one on only when you need it.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Define a request](#define-a-request)
  - [Write a handler](#write-a-handler)
  - [Process a request](#process-a-request)
  - [Add decorators](#add-decorators)
    - [Validation](#validation)
    - [Logging](#logging)
    - [ActivitySource](#activitysource)
  - [Errors and exceptions](#errors-and-exceptions)

## NuGet packages
<!-- NuGet start -->
![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.ServiceRequests)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.ServiceRequests.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.ServiceRequests.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.ServiceRequests.Abstractions` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.ServiceRequests.Abstractions) |
| [Cat.ServiceRequests](https://www.nuget.org/packages/gmarginet.Cat.ServiceRequests/) | Implementation | `dotnet add package gmarginet.Cat.ServiceRequests` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.ServiceRequests) |
| [Cat.ServiceRequests.Decorators.ActivitySource](https://www.nuget.org/packages/gmarginet.Cat.ServiceRequests.Decorators.ActivitySource/) | Optional decorator | `dotnet add package gmarginet.Cat.ServiceRequests.Decorators.ActivitySource` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.ServiceRequests.Decorators.ActivitySource) |
| [Cat.ServiceRequests.Decorators.Logging](https://www.nuget.org/packages/gmarginet.Cat.ServiceRequests.Decorators.Logging/) | Optional decorator | `dotnet add package gmarginet.Cat.ServiceRequests.Decorators.Logging` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.ServiceRequests.Decorators.Logging) |
| [Cat.ServiceRequests.Decorators.Validation](https://www.nuget.org/packages/gmarginet.Cat.ServiceRequests.Decorators.Validation/) | Optional decorator | `dotnet add package gmarginet.Cat.ServiceRequests.Decorators.Validation` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.ServiceRequests.Decorators.Validation) |

<!-- NuGet end -->

## Namespaces
<!-- Namespaces start-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.ServiceRequests.Abstractions](namespaces/Cat.ServiceRequests.Abstractions/index.md) | Request, handler and processor interfaces. |
| [Cat.ServiceRequests](namespaces/Cat.ServiceRequests/index.md) | The processor and the module registration. |
| [Cat.ServiceRequests.Decorators.ActivitySource](namespaces/Cat.ServiceRequests.Decorators.ActivitySource/index.md) | The activity tracing decorator for handlers. |
| [Cat.ServiceRequests.Decorators.Logging](namespaces/Cat.ServiceRequests.Decorators.Logging/index.md) | The logging decorator for handlers. |
| [Cat.ServiceRequests.Decorators.Validation](namespaces/Cat.ServiceRequests.Decorators.Validation/index.md) | The validation decorator for handlers. |

<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->

| Module | Why Cat.ServiceRequests needs it |
|--------|---------------------------------|
| [Cat.Responses](../Cat.Responses/README.md) | Handlers return an `ICatResponse`. |
| [Cat.Decorators](../Cat.Decorators/README.md) | Builds the handlers and runs their decorators. |
| [Cat.Validators](../Cat.Validators/README.md) | The validation decorator checks requests with validators. |

<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

Call `AddCatServiceRequestsModule` and pass one type from each assembly that holds handlers. The module scans those assemblies and registers every non-generic handler with a scoped lifetime. It also registers `ICatServiceRequestProcessor`.

The module needs the `Cat.Decorators` module to build its handlers. If you haven't registered `Cat.Decorators` yet, `AddCatServiceRequestsModule` does it for you.

```csharp
using Cat.ServiceRequests.Extensions;

builder.Services.AddCatServiceRequestsModule(typeof(TodoGetRequestHandler));
```

Handlers live in more than one assembly? Pass one type per assembly:

```csharp
builder.Services.AddCatServiceRequestsModule(typeof(TodoGetRequestHandler), typeof(OrderPlaceRequestHandler));
```

### Define a request

A request is a plain type that implements one of two interfaces:

- **`ICatServiceRequest`:** The handler returns a response without a payload.
- **`ICatServiceRequest<TResponse>`:** The handler returns a response with a payload.

```csharp
using Cat.ServiceRequests.Abstractions;

// With a payload
public record TodoGetRequest(int? TodoId) : ICatServiceRequest<TodoModel>;

// Without a payload
public record TodoSaveRequest(TodoModel Todo) : ICatServiceRequest;
```

### Write a handler

Implement the matching handler interface once per request type. Return a response instead of throwing for failures the caller should expect.

With a payload, implement `ICatServiceRequestHandler<TRequest, TResponse>`:

```csharp
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

public class TodoGetRequestHandler : ICatServiceRequestHandler<TodoGetRequest, TodoModel>
{
    private readonly ICatQueryProcessor _queryProcessor;

    public TodoGetRequestHandler(ICatQueryProcessor queryProcessor)
    {
        _queryProcessor = queryProcessor;
    }

    public async Task<ICatResponse<TodoModel>> HandleAsync(TodoGetRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var response = await _queryProcessor.ProcessAsync(serviceRequest.ToQuery(), cancellationToken);

        return response.Cast(x => x.ToModel());
    }
}
```

Without a payload, implement `ICatServiceRequestHandler<TRequest>`:

```csharp
public class TodoSaveRequestHandler : ICatServiceRequestHandler<TodoSaveRequest>
{
    private readonly ICatCommandProcessor _commandProcessor;

    public TodoSaveRequestHandler(ICatCommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    public async Task<ICatResponse> HandleAsync(TodoSaveRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        return await _commandProcessor.ProcessAsync(serviceRequest.ToCommand(), cancellationToken);
    }
}
```

A handler passes the failed response of a query or command straight on. Use `Cast` to give it the payload type of the handler.

### Process a request

Inject `ICatServiceRequestProcessor` and pass it the request. Each call opens its own scope, so the handler and its dependencies live only as long as the request.

```csharp
using Cat.ServiceRequests.Abstractions;

public class TodoEndpoints
{
    private readonly ICatServiceRequestProcessor _processor;

    public TodoEndpoints(ICatServiceRequestProcessor processor)
    {
        _processor = processor;
    }

    public async Task<ICatResponse<TodoModel>> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _processor.ProcessAsync(new TodoGetRequest(id), cancellationToken);
    }

    public async Task<ICatResponse> SaveAsync(TodoModel todo, CancellationToken cancellationToken)
    {
        return await _processor.ProcessAsync(new TodoSaveRequest(todo), cancellationToken);
    }
}
```

Prefer the async methods. The `Process` methods block until the handler finishes, so keep them for places where you can't await.

```csharp
var response = _processor.Process(new TodoGetRequest(id));
```

To expose a request as an HTTP endpoint, see [Cat.Minimal.Api](../Cat.Minimal.Api/README.md).

### Add decorators

Decorators run through the `Cat.Decorators` module. `AddCatServiceRequestsModule` already registers it, so you don't have to.

Each decorator has its own registration method. Call it on the built service provider, after `Build()`. Decorators wrap the handler in the order you register them. The last one you register is the outermost, so it runs first.

```csharp
using Cat.ServiceRequests.Decorators.ActivitySource.Extensions;
using Cat.ServiceRequests.Decorators.Logging.Extensions;
using Cat.ServiceRequests.Decorators.Validation.Extensions;

var app = builder.Build();

app.Services.AddCatServiceRequestsModuleValidationDecorator();
app.Services.AddCatServiceRequestsModuleLoggingDecorator();
app.Services.AddCatServiceRequestsModuleActivitySourceDecorator();
```

With this order a request runs the activity, then logging, then validation, then your handler. Register only the ones you need.

#### Validation

Runs the validators of the request before the handler. An invalid request never reaches the handler. The caller gets the validation failure instead.

Pass `validationRequired: true` to treat a request without a validator as a failure too. The default is `false`, so a request without a validator goes straight to the handler.

```csharp
// Requests without a validator are allowed
app.Services.AddCatServiceRequestsModuleValidationDecorator();

// Requests without a validator fail
app.Services.AddCatServiceRequestsModuleValidationDecorator(validationRequired: true);
```

Write the validator with [Cat.Validators](../Cat.Validators/README.md).

#### Logging

Logs the start and end of every handler at debug level. A failed response logs its errors.

#### ActivitySource

Starts an activity on the `Cat.ServiceRequests` source around every handler, tagged with the request type. Add that source to your OpenTelemetry setup to collect the traces:

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource("Cat.ServiceRequests"));
```

### Errors and exceptions

The processor never turns a failure into an exception for you. What you get back depends on where the problem sits.

| Situation | What you get |
|-----------|--------------|
| The handler returns `Ok`, `Created` or `NoContent` | A succeeded response. |
| The handler returns `BadRequest`, `NotFound`, `Unauthorized` or `InternalServerError` | A failed response with the errors the handler passed. It has no payload. |
| The validation decorator finds an invalid request | A `BadRequest` response with one error for each failed rule. The handler never runs. See the rule codes in [Cat.Validators](../Cat.Validators/README.md#rules). |
| The validation decorator is on with `validationRequired: true` and the request has no validator | An `InvalidOperationException` from the service provider, because the validator for the request isn't registered. |
| The validator processor returns a response that is neither succeeded nor failed | An `InternalServerError` with `CAT-GEN-1001` and the message `An unexpected response was returned. ({Service})`. This should not happen with the built-in processor. |
| No handler is registered for the request | An `InvalidOperationException` with the message `No decorated service found for service type ICatServiceRequestHandler<YourRequest>`. Check that `AddCatServiceRequestsModule` got a type from the handler's assembly. |
| The handler throws | The original exception reaches the caller as it is. It isn't wrapped in a `TargetInvocationException`. |

Over HTTP, [Cat.Minimal.Api](../Cat.Minimal.Api/README.md) turns each of these into a status code and a problem details body.
<!-- Usage end-->
