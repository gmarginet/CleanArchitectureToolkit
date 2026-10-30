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

# Cat.Commands <!-- omit in toc -->  

<!-- Intro start-->
Cat.Commands gives you one entry point for changing state. You describe a change as a command, write one handler for it, and hand the command to the processor. The processor finds the handler for you and returns an `ICatResponse`.

A command changes state and returns no data, only the outcome. Use Cat.Queries to read data.

Handlers can be wrapped in decorators for cross-cutting work. The module ships a logging decorator. You switch it on only when you need it.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Define a command](#define-a-command)
  - [Write a handler](#write-a-handler)
  - [Process a command](#process-a-command)
  - [Add decorators](#add-decorators)
  - [Errors and exceptions](#errors-and-exceptions)

## NuGet packages  
<!-- NuGet start -->
![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Commands)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Commands.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Commands.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.Commands.Abstractions` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Commands.Abstractions) |
| [Cat.Commands](https://www.nuget.org/packages/gmarginet.Cat.Commands/) | Implementation | `dotnet add package gmarginet.Cat.Commands` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Commands) |
| [Cat.Commands.Decorators.Logging](https://www.nuget.org/packages/gmarginet.Cat.Commands.Decorators.Logging/) | Optional decorator | `dotnet add package gmarginet.Cat.Commands.Decorators.Logging` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Commands.Decorators.Logging) |
<!-- NuGet end -->

## Namespaces
<!-- Namespaces start-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Commands.Abstractions](namespaces/Cat.Commands.Abstractions/index.md) | Command, handler and processor interfaces. |
| [Cat.Commands](namespaces/Cat.Commands/index.md) | The processor and the module registration. |
| [Cat.Commands.Decorators.Logging](namespaces/Cat.Commands.Decorators.Logging/index.md) | The logging decorator for handlers. |
<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->

| Module | Why Cat.Commands needs it |
|--------|---------------------------|
| [Cat.Responses](../Cat.Responses/README.md) | Handlers return an `ICatResponse`. |
| [Cat.Decorators](../Cat.Decorators/README.md) | Builds the handlers and runs their decorators. |
<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

Call `AddCatCommandsModule` and pass one type from each assembly that holds handlers. The module scans those assemblies and registers every non-generic handler with a scoped lifetime. It also registers `ICatCommandProcessor`.

The module needs the `Cat.Decorators` module to build its handlers. If you haven't registered `Cat.Decorators` yet, `AddCatCommandsModule` does it for you.

```csharp
using Cat.Commands.Extensions;

builder.Services.AddCatCommandsModule(typeof(TodoSaveCommandHandler));
```

Handlers live in more than one assembly? Pass one type per assembly:

```csharp
builder.Services.AddCatCommandsModule(typeof(TodoSaveCommandHandler), typeof(OrderPlaceCommandHandler));
```

### Define a command

A command is a plain type that implements `ICatCommand`. Put the data the handler needs in the command. Keep it free of behavior.

```csharp
using Cat.Commands.Abstractions;

public record TodoSaveCommand(Todo Todo) : ICatCommand;
```

A command can also have no data at all:

```csharp
public record TodoClearCompletedCommand : ICatCommand;
```

### Write a handler

Implement `ICatCommandHandler<TCommand>` once per command type. Return a response instead of throwing for failures the caller should expect.

```csharp
using Cat.Commands.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

public class TodoSaveCommandHandler : ICatCommandHandler<TodoSaveCommand>
{
    private readonly IDemoDatabase _demoDatabase;

    public TodoSaveCommandHandler(IDemoDatabase demoDatabase)
    {
        _demoDatabase = demoDatabase;
    }

    public async Task<ICatResponse> HandleAsync(TodoSaveCommand command, CancellationToken cancellationToken = default)
    {
        await _demoDatabase.SaveAsync(command.Todo, cancellationToken);

        return CatResponse.Ok();
    }
}
```

Pick the success response that fits the outcome, and return a failed response when the caller should know what went wrong:

```csharp
public async Task<ICatResponse> HandleAsync(TodoDeleteCommand command, CancellationToken cancellationToken = default)
{
    var todo = await _demoDatabase.GetTodoAsync(command.TodoId, cancellationToken);
    if (todo is null)
    {
        return CatResponse.NotFound(CatGeneralErrorDefinitions.ResourceNotFound.CreateCatError("Todo", command.TodoId));
    }

    await _demoDatabase.DeleteAsync(todo, cancellationToken);

    return CatResponse.NoContent();
}
```

The handler gets its dependencies from the constructor. Each command runs in its own scope, so scoped services like a database context are safe to inject.

### Process a command

Inject `ICatCommandProcessor` and pass it the command. Each call opens its own scope, so the handler and its dependencies live only as long as the command.

```csharp
using Cat.Commands.Abstractions;

public class TodoService
{
    private readonly ICatCommandProcessor _commandProcessor;

    public TodoService(ICatCommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    public async Task<ICatResponse> SaveAsync(Todo todo, CancellationToken cancellationToken)
    {
        return await _commandProcessor.ProcessAsync(new TodoSaveCommand(todo), cancellationToken);
    }
}
```

Prefer the async method. `Process` blocks until the handler finishes, so keep it for places where you can't await.

```csharp
var response = _commandProcessor.Process(new TodoSaveCommand(todo));
```

Check the outcome on the response:

```csharp
var response = await _commandProcessor.ProcessAsync(new TodoSaveCommand(todo), cancellationToken);

if (response.IsFailed)
{
    foreach (var error in response.ErrorList)
    {
        Console.WriteLine($"{error.Code}: {error.Message}");
    }
}
```

### Add decorators

Decorators run through the `Cat.Decorators` module. `AddCatCommandsModule` already registers it, so you don't have to.

Each decorator has its own registration method. Call it on the built service provider, after `Build()`.

```csharp
using Cat.Commands.Decorators.Logging.Extensions;

var app = builder.Build();

app.Services.AddCatCommandsModuleLoggingDecorator();
```

What the logging decorator does:

- **Start and end:** Logs `Start handling Command {commandName}` and `Finished handling Command {commandName}` at debug level for every handler.
- **Failures:** A failed response logs `Error occurred during handling of Command {commandName}:` at error level. One more line follows for each error, as `code: message`.

### Errors and exceptions

The processor never turns a failure into an exception for you. What you get back depends on where the problem sits.

| Situation | What you get |
|-----------|--------------|
| The handler returns `Ok`, `Created` or `NoContent` | A succeeded response. |
| The handler returns `BadRequest`, `NotFound`, `Unauthorized` or `InternalServerError` | A failed response with the errors the handler passed. The processor hands it back untouched. |
| No handler is registered for the command | An `InvalidOperationException` with the message `No decorated service found for service type ICatCommandHandler<YourCommand>`. Check that `AddCatCommandsModule` got a type from the handler's assembly. |
| The handler throws | The original exception reaches the caller as it is. It isn't wrapped in a `TargetInvocationException`. |

The error codes and messages come from the handler, so each application defines its own. See [Cat.Responses](../Cat.Responses/README.md) for how to define reusable errors.
<!-- Usage end-->
