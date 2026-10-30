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

# Cat.Decorators <!-- omit in toc -->  

<!-- Intro start-->
Cat.Decorators wraps a service in decorators for cross-cutting work like logging, validation or tracing. You register a decorator once for an open generic service, like `ICatQueryHandler<,>`. The factory then wraps every closed version of that service when you ask for it.

The Commands, Queries and ServiceRequests modules use it for their handlers. You only touch it directly when you write your own decorators.

Why does this module exist? Scrutor can't apply decorators to open generic registrations. The Scrutor maintainers discuss this in [issue 39](https://github.com/khellang/Scrutor/issues/39). It comes from a limitation of the Microsoft DI container that Scrutor builds on, not from Scrutor itself.

CAT registers its handlers as open generics, like `ICatQueryHandler<,>`, so Scrutor decorators were not an option. Cat.Decorators works around the limitation. It keeps its own list of decorators and wraps the service by hand when you ask the factory for it.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Write a decorator](#write-a-decorator)
  - [Add a decorator](#add-a-decorator)
  - [Pass fixed values](#pass-fixed-values)
  - [Get a decorated service](#get-a-decorated-service)
  - [Decorator order](#decorator-order)
  - [Errors and exceptions](#errors-and-exceptions)

## NuGet packages
<!-- NuGet start -->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Decorators)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Decorators.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Decorators.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.Decorators.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Decorators.Abstractions)](#nuget-packages) |
| [Cat.Decorators](https://www.nuget.org/packages/gmarginet.Cat.Decorators/) | Implementation | `dotnet add package gmarginet.Cat.Decorators` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Decorators)](#nuget-packages) |

<!-- NuGet end -->

## Namespaces
<!-- Namespaces start-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Decorators.Abstractions](namespaces/Cat.Decorators.Abstractions/index.md) | Interfaces for decorators and the decorated service factory. |
| [Cat.Decorators](namespaces/Cat.Decorators/index.md) | The factory that wraps services in decorators, and the module registration. |

<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->

| Module | Why Cat.Decorators needs it |
|--------|----------------------------|
| [Cat.Extensions](../Cat.Extensions/README.md) | Small helpers for service registration. |

<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

Call `AddCatDecoratorsModule` to register the factory and the builder as singletons. You can call it more than once. A service that is already registered is skipped.

The Commands, Queries and ServiceRequests modules call it for you, so you rarely need it yourself.

```csharp
using Cat.Decorators.Extensions;

builder.Services.AddCatDecoratorsModule();
```

### Write a decorator

A decorator is an open generic class that implements the same open generic interface as the service it wraps. Follow these rules:

- **One public constructor:** The factory fails if there are none or several.
- **Take the inner service:** Add a constructor parameter of the service type. The factory passes the service it is wrapping.
- **Take anything else from DI:** Other parameters are resolved from the service provider.

```csharp
public sealed class LoggingDecorator<TRequest, TResponse> : IHandler<TRequest, TResponse>
{
    private readonly IHandler<TRequest, TResponse> _innerHandler;
    private readonly ILogger<LoggingDecorator<TRequest, TResponse>> _logger;

    public LoggingDecorator(
        IHandler<TRequest, TResponse> innerHandler,
        ILogger<LoggingDecorator<TRequest, TResponse>> logger)
    {
        _innerHandler = innerHandler;
        _logger = logger;
    }

    public async Task<TResponse> HandleAsync(TRequest request)
    {
        _logger.LogDebug("Start handling {RequestName}", typeof(TRequest).Name);

        return await _innerHandler.HandleAsync(request);
    }
}
```

### Add a decorator

Inject `ICatDecoratorFactoryBuilder` from the built service provider and call `AddDecorator`. Pass the open generic service type and the open generic decorator type. Both must be open generic types, or `AddDecorator` throws an `ArgumentException`.

```csharp
using Cat.Decorators.Abstractions;

var app = builder.Build();

var decoratorBuilder = app.Services.GetRequiredService<ICatDecoratorFactoryBuilder>();
decoratorBuilder.AddDecorator(typeof(IHandler<,>), typeof(LoggingDecorator<,>));
```

### Pass fixed values

Some decorators need a value that doesn't come from DI, like a flag. Pass it as a `CatDecoratorParameter`. The factory matches it to the constructor parameter by name and type.

```csharp
using Cat.Decorators;

decoratorBuilder.AddDecorator(
    typeof(IHandler<,>),
    typeof(ValidationDecorator<,>),
    new CatDecoratorParameter("validationRequired", true));
```

```csharp
public ValidationDecorator(
    IHandler<TRequest, TResponse> innerHandler,
    IValidator validator,
    bool validationRequired)
```

For each constructor parameter, the factory picks the first match from this list:

1. **A named value:** A `CatDecoratorParameter` with the same name and a fitting type.
2. **The inner service:** The service it is wrapping, when the parameter type fits.
3. **A registered service:** Anything the service provider can resolve.

### Get a decorated service

Inject `ICatDecoratorFactory` and ask for the service with a closed generic type. The factory resolves the service from the provider, then wraps it in every decorator you added.

```csharp
using Cat.Decorators.Abstractions;

public class Processor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICatDecoratorFactory _decoratorFactory;

    public Processor(IServiceProvider serviceProvider, ICatDecoratorFactory decoratorFactory)
    {
        _serviceProvider = serviceProvider;
        _decoratorFactory = decoratorFactory;
    }

    public IHandler<MyRequest, MyResponse> GetHandler()
    {
        return _decoratorFactory.GetRequiredDecoratedService<IHandler<MyRequest, MyResponse>>(_serviceProvider);
    }
}
```

Pick the method that fits:

- **`GetRequiredDecoratedService`:** Throws an `InvalidOperationException` when the service isn't registered.
- **`GetDecoratedService`:** Returns `null` when the service isn't registered.

### Decorator order

The first decorator you add is the innermost one. Each later decorator wraps the one before it, so the last one you add runs first on the way in and last on the way out.

```csharp
decoratorBuilder.AddDecorator(typeof(IHandler<,>), typeof(ValidationDecorator<,>)); // innermost
decoratorBuilder.AddDecorator(typeof(IHandler<,>), typeof(LoggingDecorator<,>));    // outermost
```

Here a call runs logging, then validation, then your handler.

### Errors and exceptions

The module reports every problem as an exception. It has no response types, because decorators run before any handler can answer.

| Situation | What you get |
|-----------|--------------|
| `AddDecorator` gets a service type that isn't an open generic type | An `ArgumentException` with the message `Service type must be a generic type definition`. |
| `AddDecorator` gets a decorator type that isn't an open generic type | An `ArgumentException` with the message `Decorator type must be a generic type definition`. |
| `GetRequiredDecoratedService` can't find the service | An `InvalidOperationException` with the message `No decorated service found for service type <type>`. |
| `GetDecoratedService` can't find the service | `null`. No exception. |
| A decorator has no public constructor, or more than one | An `InvalidOperationException` from the factory when it builds the decorator. |
| A decorator constructor asks for a service the provider can't resolve | An `InvalidOperationException` from the service provider, naming the missing service. |

The factory only wraps a service when you ask for it. A mistake in a decorator therefore shows up the first time something requests the decorated service, not at startup.
<!-- Usage end-->
