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

# Cat.Responses <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Responses models the outcome of an operation as a response: either succeeded, optionally carrying a value, or failed, carrying one or more errors.

Handlers across the other CAT modules (commands, queries, service requests) return `ICatResponse` or `ICatResponse<TResponse>`, so callers get one consistent return type instead of exceptions for outcomes the caller is expected to handle, like a missing resource or a failed validation.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Response types](#response-types)
  - [Create a response](#create-a-response)
  - [Create a list response](#create-a-list-response)
  - [Create a paged list response](#create-a-paged-list-response)
  - [Read a response](#read-a-response)
  - [Cast a response](#cast-a-response)
  - [Define and raise errors](#define-and-raise-errors)
  - [Log the errors of a response](#log-the-errors-of-a-response)
  - [Errors and exceptions](#errors-and-exceptions)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Responses)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Responses.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Responses.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.Responses.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Responses.Abstractions)](#nuget-packages) |
| [Cat.Responses](https://www.nuget.org/packages/gmarginet.Cat.Responses/) | Implementation | `dotnet add package gmarginet.Cat.Responses` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Responses)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Responses.Abstractions](namespaces/Cat.Responses.Abstractions/index.md) | Response, paged list and error interfaces. |
| [Cat.Responses](namespaces/Cat.Responses/index.md) | The response types, the paged list and error definitions. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.Responses needs it |
|--------|---------------------------|
| [Cat.Extensions](../Cat.Extensions/README.md) | `CatPagedList` checks its values with `ThrowIfNull` and `ThrowIfLessThan`. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Register the module

This module has nothing to register. Reference `Cat.Responses.Abstractions` in projects that only read responses. Reference `Cat.Responses` in projects that create them.

### Response types

Every response has a `Type` of `CatResponseType`. Each type is either a `Succeeded` or a `Failed` variant, so you can tell the two apart without knowing the exact outcome. `IsSucceeded` and `IsFailed` do the same check for you.

| Type | Group | Use it when | Errors | Value |
|------|-------|-------------|--------|-------|
| `Ok` | Succeeded | The operation worked. | None | Optional |
| `Created` | Succeeded | The operation worked and made a new resource. | None | Optional |
| `NoContent` | Succeeded | The operation worked and has nothing to return. | None | None |
| `BadRequest` | Failed | The request was invalid, for example a failed validation. | One or more | None |
| `NotFound` | Failed | The requested resource doesn't exist. | One or more | None |
| `Unauthorized` | Failed | The caller isn't authenticated. | One or more | None |
| `Forbidden` | Failed | The caller is authenticated but isn't allowed to do this. | One or more | None |
| `Conflict` | Failed | The request conflicts with the current state of the resource. | One or more | None |
| `InternalServerError` | Failed | Something unexpected went wrong. | One or more | None |

### Create a response

Use the static factory methods on `CatResponse`. Each type has two flavors:

- **Without a value:** returns `ICatResponse`. Use it for commands that only report success or failure.
- **With a value:** returns `ICatResponse<TResponse>`. Use it for queries that hand data back.

```csharp
using Cat.Responses;
using Cat.Responses.Abstractions;

// Succeeded, no value
ICatResponse ok = CatResponse.Ok();
ICatResponse created = CatResponse.Created();
ICatResponse noContent = CatResponse.NoContent();

// Succeeded, with a value
ICatResponse<Todo> okWithValue = CatResponse.Ok(todo);
ICatResponse<Todo> createdWithValue = CatResponse.Created(todo);
ICatResponse<Todo> noContentTyped = CatResponse.NoContent<Todo>();

// Failed, no value type. Pass one or more errors.
ICatResponse badRequest = CatResponse.BadRequest(error1, error2);
ICatResponse notFound = CatResponse.NotFound(error);
ICatResponse unauthorized = CatResponse.Unauthorized(error);
ICatResponse forbidden = CatResponse.Forbidden(error);
ICatResponse conflict = CatResponse.Conflict(error);
ICatResponse serverError = CatResponse.InternalServerError(error);

// Failed, typed to a value so it fits a handler that returns ICatResponse<Todo>
ICatResponse<Todo> typedNotFound = CatResponse.NotFound<Todo>(error);
```

Return a response from a handler, instead of throwing for an expected failure:

```csharp
public async Task<ICatResponse<Todo>> HandleAsync(TodoGetQuery query, CancellationToken cancellationToken = default)
{
    var todo = await _demoDatabase.GetTodoAsync(query.TodoId!.Value, cancellationToken);

    return todo is null
        ? CatResponse.NotFound<Todo>(CatDemoErrorDefinitions.NotFound.CreateCatError("Todo", query.TodoId!.Value))
        : CatResponse.Ok(todo);
}
```

### Create a list response

Use `CatResponse.List` for a response that carries a list of items. It returns `ICatResponse<IReadOnlyList<TResponse>>`, and it has the same outcomes as the other factories.

```csharp
using Cat.Responses;
using Cat.Responses.Abstractions;

// Succeeded. Pass any IReadOnlyList<T>, such as an array or a List<T>.
ICatResponse<IReadOnlyList<Todo>> ok = CatResponse.List.Ok(todos);
ICatResponse<IReadOnlyList<Todo>> created = CatResponse.List.Created(todos);
ICatResponse<IReadOnlyList<Todo>> noContent = CatResponse.List.NoContent<Todo>();

// Failed. Pass one or more errors.
ICatResponse<IReadOnlyList<Todo>> badRequest = CatResponse.List.BadRequest<Todo>(error);
ICatResponse<IReadOnlyList<Todo>> notFound = CatResponse.List.NotFound<Todo>(error);
ICatResponse<IReadOnlyList<Todo>> unauthorized = CatResponse.List.Unauthorized<Todo>(error);
ICatResponse<IReadOnlyList<Todo>> forbidden = CatResponse.List.Forbidden<Todo>(error);
ICatResponse<IReadOnlyList<Todo>> conflict = CatResponse.List.Conflict<Todo>(error);
ICatResponse<IReadOnlyList<Todo>> serverError = CatResponse.List.InternalServerError<Todo>(error);
```

### Create a paged list response

Use `CatResponse.PagedList` for one page of a larger list. It returns `ICatResponse<ICatPagedList<TResponse>>`. Build the page from values, or pass a page you already have.

```csharp
// Build the page from values
ICatResponse<ICatPagedList<Todo>> ok = CatResponse.PagedList.Ok(
    todos, pageNumber: 2, pageSize: 10, totalItemCount: 25);

// Or pass an existing page
var page = new CatPagedList<Todo>(todos, 2, 10, 25);
ICatResponse<ICatPagedList<Todo>> created = CatResponse.PagedList.Created(page);

// No page, or a failure
ICatResponse<ICatPagedList<Todo>> noContent = CatResponse.PagedList.NoContent<Todo>();
ICatResponse<ICatPagedList<Todo>> notFound = CatResponse.PagedList.NotFound<Todo>(error);
```

`BadRequest`, `Unauthorized`, `Forbidden`, `Conflict` and `InternalServerError` work the same way as `NotFound`.

A page (`ICatPagedList<T>`) holds these values:

| Property | Meaning |
|----------|---------|
| `List` | The items on this page. |
| `PageNumber` | The number of this page. The first page is 1. |
| `PageSize` | The maximum number of items on a page. |
| `TotalItemCount` | The number of items across all pages. |
| `TotalPages` | The number of pages needed to hold all items. It is calculated for you. |

`CatPagedList<T>` checks its values when you set them. The list can't be `null`, the page number and page size must be 1 or higher, and the total item count can't be negative. Copy a page with a different value using `with`. The new value is checked too:

```csharp
var nextPage = page with { PageNumber = page.PageNumber + 1 };
```

Two pages are equal when their numbers and their items are equal. The list is compared item by item, not by reference.

### Read a response

Check the outcome with `IsSucceeded` and `IsFailed`. A failed response carries its errors in `ErrorList`. A failed `ICatResponse<TResponse>` has no value, so only read `Value` after you've checked `IsSucceeded`.

```csharp
using Cat.Responses.Abstractions;

if (response.IsFailed)
{
    foreach (var error in response.ErrorList)
    {
        Console.WriteLine($"{error.Code}: {error.Message}");
    }
}
```

Match on `Type` when you need to react to the exact outcome:

```csharp
var message = response.Type switch
{
    CatResponseType.Succeeded.Created => "Saved as a new item.",
    CatResponseType.Succeeded => "Done.",
    CatResponseType.Failed.NotFound => "We couldn't find it.",
    CatResponseType.Failed => "Something went wrong.",
    _ => "Unknown outcome."
};
```

Order the more specific patterns first, as in the example. The base types `Succeeded` and `Failed` catch everything the specific ones didn't.

### Cast a response

`Cast` moves a response from one value type to another. It follows two rules:

- **Failed to failed:** `Cast<TResponse>()` keeps the type and errors, and drops the value. Use it to pass a failure up through a handler with a different return type.
- **Succeeded to succeeded:** `Cast<TResponse>(value)` on `ICatResponse`, or `Cast(convertValue)` on `ICatResponse<TResponse>`, keeps the type and swaps in a new value.

`Cast(convertValue)` on a failed `ICatResponse<TResponse>` is safe. It keeps the type and errors and doesn't call the converter. The other casts throw an `InvalidOperationException` when they cross the line. See [Errors and exceptions](#errors-and-exceptions).

```csharp
// Convert the value of a success. A failure passes through unchanged.
ICatResponse<TodoModel> modelResponse = todoResponse.Cast(todo => todo.ToModel());
```

Cast a failed response through to a different value type, for example when a decorator's own check fails before it calls the inner handler:

```csharp
return validationResponse.Type switch
{
    CatResponseType.Succeeded => await _innerHandler.HandleAsync(serviceRequest, cancellationToken),
    CatResponseType.Failed => validationResponse.Cast<TResponse>(),
    _ => CatResponse.InternalServerError<TResponse>(CatGeneralErrorDefinitions.UnexpectedResponse.CreateCatError())
};
```

### Define and raise errors

An error has a `Code`, a `Message` template and `Arguments`. The template holds named placeholders. The arguments fill them in order.

Define reusable errors once, as static fields, instead of building `CatError` instances by hand everywhere:

```csharp
using Cat.Responses;

public static class OrderErrorDefinitions
{
    private const string OrderErrorCodePrefix = "DEM-ORD";

    public static readonly CatErrorDefinition NotFound = CatErrorDefinition.Create(
        OrderErrorCodePrefix,
        1000,
        "{ResourceName} with id {id} could not be found.");
}

// Raise it with the values for the placeholders
var error = OrderErrorDefinitions.NotFound.CreateCatError("Book", 42);
```

`Create(prefix, number, message)` builds the code as `DEM-ORD-1000`. It does not check the prefix. If you prefer, pass the whole code as one string with `Create(code, message)`.

For a one-off error, build it directly:

```csharp
var error = CatError.Create("DEM-ORD-1001", "An order needs at least one line.");
var errorWithArguments = CatError.Create("DEM-ORD-1002", "Product '{productId}' is out of stock.", productId);
```

The module also ships three definitions for common cases:

| Definition | Code | Message | Arguments |
|------------|------|---------|-----------|
| `CatGeneralErrorDefinitions.Unknown` | `CAT-GEN-1000` | `An unknown error occurred.` | None |
| `CatGeneralErrorDefinitions.UnexpectedResponse` | `CAT-GEN-1001` | `An unexpected response was returned. ({Service})` | `Service` |
| `CatGeneralErrorDefinitions.ResourceNotFound` | `CAT-GEN-1002` | `The requested {ResourceName} with id {ResourceId} was not found.` | `ResourceName`, `ResourceId` |

Cat.Validators has its own definitions with the `CAT-VAL` prefix, so its codes never clash with these.

#### The error code convention

Clients match on the code, not on the text, so a code is stable. CAT follows these rules:

- **Pattern:** `<APPLICATION>-<AREA>-<number>`. The application and the area are 3 uppercase characters each, like `CAT-VAL-1001` or `DEM-ORD-1001`.
- **CAT codes:** `CAT` is the application. The area is a 3 letter acronym of the module, like `GEN` for this module and `VAL` for Cat.Validators.
- **Numbers:** They start at 1000 and count up. A number is unique within its prefix and is never reused. There are no ranges for kinds of errors.
- **One place per module:** A module defines its codes in one class, like `CatGeneralErrorDefinitions`, and its readme lists them.
- **Your own codes:** You are not obliged to follow the convention. Any valid string works. Use a prefix of your own, like `DEM-ORD` in the demo, so your codes never clash with the `CAT-` codes.

### Log the errors of a response

`LogCatResponseErrors` writes your message at error level, then one line per error as `code: message`:

```csharp
using Cat.Responses.Abstractions.Extensions;

if (response.IsFailed)
{
    logger.LogCatResponseErrors(response, "Failed to process the request.");
}
```

### Errors and exceptions

Responses exist so expected failures don't become exceptions. The only exceptions this module throws come from `Cast` and from `CatPagedList` when you give it invalid values.

| Situation | What you get |
|-----------|--------------|
| `Cast<TResponse>()` on a succeeded response | An `InvalidOperationException` with the message `Cannot cast a succeeded response to a failed response.` |
| `Cast<TResponse>(value)` on a failed `ICatResponse` | An `InvalidOperationException` with the message `Cannot cast a failed response to a succeeded response.` |
| A paged list gets a `null` list | An `ArgumentNullException` for `List`. |
| A paged list gets a page number or page size below 1 | An `ArgumentOutOfRangeException` for `PageNumber` or `PageSize`, with the message `<name> must be 1 or higher.` |
| A paged list gets a negative total item count | An `ArgumentOutOfRangeException` for `TotalItemCount`, with the message `TotalItemCount must be 0 or higher.` |

The paged list exceptions also come from `CatResponse.PagedList.Ok` and `Created` when you build the page from values, and from a `with` copy.

Check `IsFailed` or `IsSucceeded` before you cast, as in the cast example above.

The failures a response reports are errors, not exceptions. Which codes you can get depends on the module that produced the response:

- **Cat.Validators:** `BadRequest` with the `CAT-VAL-1001` to `CAT-VAL-1020` rule errors.
- **Cat.ServiceRequests validation decorator:** `InternalServerError` with `CAT-GEN-1001`, when the validator returns neither a succeeded nor a failed response.
- **Cat.Minimal.Api:** maps each failed type to an HTTP status. See [Cat.Minimal.Api](../Cat.Minimal.Api/README.md).
- **Your handlers:** the codes you define yourself.
<!-- region end: Usage-->
