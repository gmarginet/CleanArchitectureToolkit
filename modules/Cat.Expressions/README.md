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

# Cat.Expressions <!-- omit in toc -->  

<!-- Intro start-->
Cat.Expressions caches compiled member access delegates. Compiling a `LambdaExpression` through reflection has a real cost, so this module compiles it once per expression and reuses the result on every later call.

Use the caching implementation when the same expression gets called repeatedly, like a property accessor used in a loop. Swap in the no-cache implementation when caching isn't worth it, for example when expressions are built fresh each time anyway.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Compile a member expression](#compile-a-member-expression)
  - [What gets cached](#what-gets-cached)
  - [Choose between the cache and no cache](#choose-between-the-cache-and-no-cache)
  - [Errors and exceptions](#errors-and-exceptions)

## NuGet packages
<!-- NuGet start -->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Expressions)](https://www.nuget.org/packages/gmarginet.Cat.Expressions/)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Expressions.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Expressions.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.Expressions.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Expressions.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.Expressions.Abstractions/) |
| [Cat.Expressions](https://www.nuget.org/packages/gmarginet.Cat.Expressions/) | Implementation | `dotnet add package gmarginet.Cat.Expressions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Expressions)](https://www.nuget.org/packages/gmarginet.Cat.Expressions/) |

<!-- NuGet end -->

## Namespaces
<!-- Namespaces start-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Expressions.Abstractions](namespaces/Cat.Expressions.Abstractions/index.md) | Interfaces for compiling member expressions. |
| [Cat.Expressions](namespaces/Cat.Expressions/index.md) | The caching and no-cache compilers, and the module registration. |

<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->

| Module | Why Cat.Expressions needs it |
|--------|-----------------------------|
| [Cat.Extensions](../Cat.Extensions/README.md) | Small helpers for service registration. |

<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

Pick one of two registration methods. Both register `ICatCompiledMemberExpressionCache<T>` as an open generic singleton, so one cache exists per type `T`.

```csharp
using Cat.Expressions.Extensions;

// Compile once, reuse afterwards
services.AddCatCompiledMemberExpressionCache();

// Or compile on every call
services.AddCatNoCacheCompiledMemberExpressionCache();
```

### Compile a member expression

Resolve the cache for the type you read from, and call `GetOrAdd` with a lambda.

```csharp
using Cat.Expressions.Abstractions;

var cache = serviceProvider.GetRequiredService<ICatCompiledMemberExpressionCache<Order>>();

Func<Order, int> getOrderId = cache.GetOrAdd(order => order.Id);

var orderId = getOrderId(order);
```

Inject the cache into a class that reads properties in a loop:

```csharp
public class OrderExporter
{
    private readonly ICatCompiledMemberExpressionCache<Order> _cache;

    public OrderExporter(ICatCompiledMemberExpressionCache<Order> cache)
    {
        _cache = cache;
    }

    public IEnumerable<int> GetIds(IEnumerable<Order> orders)
    {
        var getId = _cache.GetOrAdd(order => order.Id);

        return orders.Select(getId);
    }
}
```

If you already know which member the expression points to, pass it as the second argument. The cache then skips the lookup:

```csharp
var member = typeof(Order).GetProperty(nameof(Order.Id));
Func<Order, int> getOrderId = cache.GetOrAdd(order => order.Id, member);
```

### What gets cached

The cache key is the member plus the text of the expression. Calling `GetOrAdd` again with an equivalent expression returns the delegate compiled the first time, instead of compiling a new one.

- **A direct member access:** `order => order.Id` or `order => order.Customer.Name` is cached.
- **Anything else:** A method call, a calculation or a constant is compiled on every call and never cached, because there is no single member to key on.

```csharp
cache.GetOrAdd(order => order.Id);              // cached
cache.GetOrAdd(order => order.Customer.Name);   // cached
cache.GetOrAdd(order => order.Total * 2);       // compiled every time
```

### Choose between the cache and no cache

| Implementation | Registration | Use it when |
|----------------|--------------|-------------|
| Caching | `AddCatCompiledMemberExpressionCache` | The same expressions run many times, like in validators or mappers. |
| No cache | `AddCatNoCacheCompiledMemberExpressionCache` | Expressions are built fresh each time, so cached entries would never be reused. It also suits tests. |

Both implement `ICatCompiledMemberExpressionCache<T>`, so you switch by changing the registration only.

The caching implementation keeps its delegates for the life of the application. Keep the set of expressions small and fixed.

### Errors and exceptions

The module has no response types. It throws for invalid input and stays quiet otherwise.

| Situation | What you get |
|-----------|--------------|
| `GetOrAdd` gets `null` as the expression | An `ArgumentNullException` with the parameter name `expression`. |
| The expression isn't a direct member access | No error. The expression is compiled and returned, but not cached. |
| The type `T` isn't a class | A compile error. `T` is constrained to reference types. |
| The cache for `T` isn't registered | An `InvalidOperationException` from the service provider when you resolve it. |

Other CAT modules use this cache too. Cat.Validators reads property values through it, so register it before you register the validators module.
<!-- Usage end-->
