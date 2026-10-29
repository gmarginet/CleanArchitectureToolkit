<link href="../../resources/styles/style.css" rel="stylesheet" />

# Clean Architecture Toolkit for .NET <!-- omit in toc -->  

[CAT](../../README.md 'Readme of the CAT project\.')  
[Module overview](../../README.md#module-overview 'List of all the CAT modules\.')  

# Cat.Extensions <!-- omit in toc -->  

<!-- Intro start-->
Cat.Extensions is a collection of small, focused extension method libraries. Each namespace targets one type, IEnumerable, Expression, IServiceCollection, string, or general objects, and has no dependency on any other CAT module, so you can pull in just the ones you need.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Enumerable](#enumerable)
  - [Expression](#expression)
  - [Object](#object)
  - [ServiceCollection](#servicecollection)
  - [String](#string)
  - [Errors and exceptions](#errors-and-exceptions)

## Namespaces
<!-- Namespaces start-->
- [Cat.Enumerable.Extensions](namespaces/Cat.Enumerable.Extensions/index.md)  
- [Cat.Expression.Extensions](namespaces/Cat.Expression.Extensions/index.md)  
- [Cat.Object.Extensions](namespaces/Cat.Object.Extensions/index.md)  
- [Cat.ServiceCollection.Extensions](namespaces/Cat.ServiceCollection.Extensions/index.md)  
- [Cat.String.Extensions](namespaces/Cat.String.Extensions/index.md)  
<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->
<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

This module has nothing to register. Add a `using` for the namespace you need, and the extension methods show up on the type.

### Enumerable

`IsEmpty` checks whether a sequence has any elements. It works on any `IEnumerable`, and it reads at most one element.

```csharp
using Cat.Enumerable.Extensions;

if (items.IsEmpty()) return;
```

### Expression

`GetMemberInfo` resolves the member a lambda expression points to. It returns `null` when the expression isn't a direct member access on its parameter.

```csharp
using Cat.Expression.Extensions;

Expression<Func<Order, int>> expression = order => order.Id;
MemberInfo? member = expression.GetMemberInfo();            // the Id property

Expression<Func<Order, string>> nested = order => order.Customer.Name;
MemberInfo? nestedMember = nested.GetMemberInfo();          // the Name property

Expression<Func<Order, int>> calculation = order => order.Id + 1;
MemberInfo? none = calculation.GetMemberInfo();             // null
```

### Object

Validate arguments without hand-written null and range checks.

- **`ThrowIfNull`:** Returns the argument when it isn't `null`, so you can use it inline.
- **`ThrowIfGreaterThanOrEqualTo`:** Checks that a lower bound is less than an upper bound. It uses the default comparison of the type, or a comparer you pass.

```csharp
using Cat.Object.Extensions;

public Order(Customer customer, int minQuantity, int maxQuantity)
{
    _customer = customer.ThrowIfNull(nameof(customer));
    minQuantity.ThrowIfGreaterThanOrEqualTo(maxQuantity, nameof(minQuantity), nameof(maxQuantity));
}
```

With your own comparer:

```csharp
start.ThrowIfGreaterThanOrEqualTo(end, StringComparer.OrdinalIgnoreCase, nameof(start), nameof(end));
```

### ServiceCollection

`HasRegistrationFor` checks whether a service is already registered. Use it to register something once, however many modules ask for it.

```csharp
using Cat.ServiceCollection.Extensions;

if (services.HasRegistrationFor<ICatEventAggregator>()) return;
```

Pass a type when you only have it at runtime. An open generic type matches any registration for that generic definition:

```csharp
var hasHandlers = services.HasRegistrationFor(typeof(ICatCommandHandler<>));
```

### String

`NamedFormat` formats a named message template. The names are only for readability. Values are matched by position, in order.

```csharp
using Cat.String.Extensions;

var message = "User {UserId} logged in at {Timestamp}".NamedFormat(userId, timestamp);
var padded = "Total: {Total,10:N2}".NamedFormat(total);
```

`CreateRegex` compiles a regular expression with a two-second matching timeout, so a pathological pattern can't hang the caller.

```csharp
var regex = @"^\d{3}-\d{4}$".CreateRegex();
var ignoreCase = @"^[a-z]+$".CreateRegex(RegexOptions.IgnoreCase);
```

### Errors and exceptions

These methods throw exceptions. They don't return responses.

| Method | Situation | What you get |
|--------|-----------|--------------|
| `ThrowIfNull` | The argument is `null` | An `ArgumentNullException` with the parameter name you passed. |
| `ThrowIfGreaterThanOrEqualTo` | The lower bound is greater than or equal to the upper bound | An `ArgumentOutOfRangeException` with the message `<lowerBoundName> must be less than <upperBoundName>.` |
| `ThrowIfGreaterThanOrEqualTo` without a comparer | `T` doesn't implement `IComparable<T>` | An `ArgumentException` with the message `TProperty is not IComparable<TProperty>`. |
| `CreateRegex` | The pattern isn't a valid regular expression | An `ArgumentException` with the message `Invalid regex expression: <pattern>`. The original exception is the inner exception. |
| `NamedFormat` | There are fewer values than placeholders | A `FormatException` from `string.Format`. |
| `GetMemberInfo` | The expression isn't a direct member access | `null`. No exception. |
| `IsEmpty`, `HasRegistrationFor` | Never | These don't throw for valid input. |
<!-- Usage end-->
