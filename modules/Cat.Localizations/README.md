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

# Cat.Localizations <!-- omit in toc -->  

> **!!! This module is still under development, wait for final version before you use it !!!**
<!-- Intro start-->
Cat.Localizations defines a contract for looking up localized strings by key, so the rest of your app doesn't need to know which localization provider sits behind it.

The module ships with a no-op implementation that returns the key as-is, with placeholders filled in. It's a safe default, and handy in tests. Plug in your own `ICatLocalizer` backed by resource files, a translation service, or whatever fits your app, when you need real localization.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Look up a string](#look-up-a-string)
  - [Write your own localizer](#write-your-own-localizer)
  - [Errors and exceptions](#errors-and-exceptions)

## NuGet packages
<!-- NuGet start -->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Localizations)](https://www.nuget.org/packages/gmarginet.Cat.Localizations/)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Localizations.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Localizations.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.Localizations.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Localizations.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.Localizations.Abstractions/) |
| [Cat.Localizations](https://www.nuget.org/packages/gmarginet.Cat.Localizations/) | Implementation | `dotnet add package gmarginet.Cat.Localizations` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Localizations)](https://www.nuget.org/packages/gmarginet.Cat.Localizations/) |

<!-- NuGet end -->

## Namespaces
<!-- Namespaces start-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Localizations.Abstractions](namespaces/Cat.Localizations.Abstractions/index.md) | The `ICatLocalizer` interface. |
| [Cat.Localizations](namespaces/Cat.Localizations/index.md) | The no-op localizer and the module registration. |

<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->

| Module | Why Cat.Localizations needs it |
|--------|-------------------------------|
| [Cat.Extensions](../Cat.Extensions/README.md) | Small helpers for service registration. |

<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

Call `AddCatNoLocalizationLocalizer` to register `ICatLocalizer` as a singleton, backed by the no-op implementation.

```csharp
using Cat.Localizations.Extensions;

services.AddCatNoLocalizationLocalizer();
```

### Look up a string

Resolve the localizer and use its indexers. One takes a key. The other takes a key and the values for its placeholders.

```csharp
using Cat.Localizations.Abstractions;

var localizer = serviceProvider.GetRequiredService<ICatLocalizer>();

var title = localizer["Order.Title"];
var message = localizer["Order.Created", orderId];
```

The no-op implementation returns the key itself. It only fills in placeholders when the key contains them, in the order of the arguments:

```csharp
localizer["Order.Title"];                              // "Order.Title"
localizer["Order {OrderId} was created", 42];          // "Order 42 was created"
```

Inject the localizer into the classes that need text:

```csharp
public class OrderMessages
{
    private readonly ICatLocalizer _localizer;

    public OrderMessages(ICatLocalizer localizer)
    {
        _localizer = localizer;
    }

    public string Created(int orderId) => _localizer["Order.Created", orderId];
}
```

### Write your own localizer

Implement `ICatLocalizer` and register it instead of the no-op one. Fill the placeholders of the localized text from `arguments`, in order.

```csharp
using Cat.Localizations.Abstractions;
using Cat.String.Extensions;

public class ResourceCatLocalizer : ICatLocalizer
{
    private readonly IStringProvider _stringProvider;

    public ResourceCatLocalizer(IStringProvider stringProvider)
    {
        _stringProvider = stringProvider;
    }

    public string this[string key] => _stringProvider.Get(key) ?? key;

    public string this[string key, params object[] arguments] => this[key].NamedFormat(arguments);
}

services.AddSingleton<ICatLocalizer, ResourceCatLocalizer>();
```

### Errors and exceptions

The contract doesn't define errors. A localizer returns a string for every key, and it doesn't use responses.

| Situation | What you get |
|-----------|--------------|
| The no-op localizer gets any key | The key itself. It never fails on an unknown key. |
| The key has more placeholders than arguments | A `FormatException` from the no-op localizer. |
| The key has fewer placeholders than arguments | The extra arguments are ignored. |
| `ICatLocalizer` isn't registered | An `InvalidOperationException` from the service provider when you resolve it. |

What your own localizer does for a missing key is up to you. Returning the key, as in the example, makes a missing translation easy to spot in the UI.
<!-- Usage end-->
