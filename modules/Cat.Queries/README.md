<link href="../../resources/styles/style.css" rel="stylesheet" />

# Clean Architecture Toolkit for .NET <!-- omit in toc -->  

[CAT](../../README.md 'Readme of the CAT project\.')  
[Module overview](../../README.md#module-overview 'List of all the CAT modules\.')  

# Cat.Queries <!-- omit in toc -->  

<!-- Intro start-->
Cat.Queries gives you one entry point for reading data. You describe a read as a query, write one handler for it, and hand the query to the processor. The processor finds the handler for you and returns an `ICatResponse<TQueryResult>`.

A query only reads. It never changes state. Use Cat.Commands for writes.

Handlers can be wrapped in decorators for cross-cutting work. The module ships a logging decorator. You switch it on only when you need it.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Define a query](#define-a-query)
  - [Write a handler](#write-a-handler)
  - [Process a query](#process-a-query)
  - [Add decorators](#add-decorators)
  - [Errors and exceptions](#errors-and-exceptions)

## Namespaces
<!-- Namespaces start-->
- [Cat.Queries.Abstractions](namespaces/Cat.Queries.Abstractions/index.md)  
- [Cat.Queries](namespaces/Cat.Queries/index.md)  
- [Cat.Queries.Decorators.Logging](namespaces/Cat.Queries.Decorators.Logging/index.md)  
<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->
- [Cat.Responses](../Cat.Responses/README.md)  
- [Cat.Decorators](../Cat.Decorators/README.md)  
<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

Call `AddCatQueriesModule` and pass one type from each assembly that holds handlers. The module scans those assemblies and registers every non-generic handler with a scoped lifetime. It also registers `ICatQueryProcessor`.

The module needs the `Cat.Decorators` module to build its handlers. If you haven't registered `Cat.Decorators` yet, `AddCatQueriesModule` does it for you.

```csharp
using Cat.Queries.Extensions;

builder.Services.AddCatQueriesModule(typeof(TodoGetQueryHandler));
```

Handlers live in more than one assembly? Pass one type per assembly:

```csharp
builder.Services.AddCatQueriesModule(typeof(TodoGetQueryHandler), typeof(OrderGetQueryHandler));
```

### Define a query

A query is a plain type that implements `ICatQuery<TQueryResult>`. The type parameter is the data the handler returns.

```csharp
using Cat.Queries.Abstractions;

public record TodoGetQuery(int? TodoId) : ICatQuery<Todo>;
```

A query can return a collection, and it can have no parameters:

```csharp
public record TodoGetListQuery : ICatQuery<IList<Todo>>;
```

### Write a handler

Implement `ICatQueryHandler<TQuery, TQueryResult>` once per query type. Return a response instead of throwing for failures the caller should expect, like a missing resource.

```csharp
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

public class TodoGetQueryHandler : ICatQueryHandler<TodoGetQuery, Todo>
{
    private readonly IDemoDatabase _demoDatabase;

    public TodoGetQueryHandler(IDemoDatabase demoDatabase)
    {
        _demoDatabase = demoDatabase;
    }

    public async Task<ICatResponse<Todo>> HandleAsync(TodoGetQuery query, CancellationToken cancellationToken = default)
    {
        var todo = await _demoDatabase.GetTodoAsync(query.TodoId!.Value, cancellationToken);

        return todo is null
            ? CatResponse.NotFound<Todo>(CatDemoErrorDefinitions.NotFound.CreateCatError("Todo", query.TodoId!.Value))
            : CatResponse.Ok(todo);
    }
}
```

A handler that always has an answer simply returns `Ok` with the data:

```csharp
public class TodoGetListQueryHandler : ICatQueryHandler<TodoGetListQuery, IList<Todo>>
{
    private readonly IDemoDatabase _demoDatabase;

    public TodoGetListQueryHandler(IDemoDatabase demoDatabase)
    {
        _demoDatabase = demoDatabase;
    }

    public async Task<ICatResponse<IList<Todo>>> HandleAsync(TodoGetListQuery query, CancellationToken cancellationToken = default)
    {
        var todoList = await _demoDatabase.GetTodoListAsync(cancellationToken);

        return CatResponse.Ok(todoList);
    }
}
```

### Process a query

Inject `ICatQueryProcessor` and pass it the query. Each call opens its own scope, so the handler and its dependencies live only as long as the query.

```csharp
using Cat.Queries.Abstractions;

public class TodoService
{
    private readonly ICatQueryProcessor _queryProcessor;

    public TodoService(ICatQueryProcessor queryProcessor)
    {
        _queryProcessor = queryProcessor;
    }

    public async Task<ICatResponse<Todo>> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _queryProcessor.ProcessAsync(new TodoGetQuery(id), cancellationToken);
    }
}
```

Prefer the async method. `Process` blocks until the handler finishes, so keep it for places where you can't await.

```csharp
var response = _queryProcessor.Process(new TodoGetQuery(id));
```

Read the value only after you checked the outcome:

```csharp
var response = await _queryProcessor.ProcessAsync(new TodoGetQuery(id), cancellationToken);

if (response.IsSucceeded)
{
    Console.WriteLine(response.Value.Title);
}
else
{
    foreach (var error in response.ErrorList)
    {
        Console.WriteLine($"{error.Code}: {error.Message}");
    }
}
```

### Add decorators

Decorators run through the `Cat.Decorators` module. `AddCatQueriesModule` already registers it, so you don't have to.

Each decorator has its own registration method. Call it on the built service provider, after `Build()`.

```csharp
using Cat.Queries.Decorators.Logging.Extensions;

var app = builder.Build();

app.Services.AddCatQueriesModuleLoggingDecorator();
```

What the logging decorator does:

- **Start and end:** Logs the start and the end of every handler at debug level, with the name of the query.
- **Failures:** A failed response logs an error line, followed by one line per error as `code: message`.

### Errors and exceptions

The processor never turns a failure into an exception for you. What you get back depends on where the problem sits.

| Situation | What you get |
|-----------|--------------|
| The handler returns `Ok`, `Created` or `NoContent` | A succeeded response. |
| The handler returns `BadRequest`, `NotFound`, `Unauthorized` or `InternalServerError` | A failed response with the errors the handler passed. It has no value. |
| No handler is registered for the query | An `InvalidOperationException` with the message `No decorated service found for service type ICatQueryHandler<YourQuery, YourResult>`. Check that `AddCatQueriesModule` got a type from the handler's assembly. |
| The handler throws | The original exception reaches the caller as it is. It isn't wrapped in a `TargetInvocationException`. |

A failed response has no value, so read `Value` only after `IsSucceeded` is `true`.

The error codes and messages come from the handler, so each application defines its own. See [Cat.Responses](../Cat.Responses/README.md) for how to define reusable errors.
<!-- Usage end-->
