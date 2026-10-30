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

# Cat.Validators <!-- omit in toc -->  

<!-- Intro start-->
Cat.Validators checks a model against a set of rules and tells you everything that is wrong with it. You describe the rules for a model in a validator class. The processor runs the rules and returns an `ICatResponse`: Ok when the model is valid, BadRequest with one error per failure when it is not.

The rules are fluent and read like a sentence. Every rule has a stable error code and a message template, so clients can react to a failure without parsing text. You can replace the field name, the message and the code per rule, and run a rule only when a condition is true.

Rules never stop at the first failure. One call reports every problem.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Write a validator](#write-a-validator)
  - [Validate a model](#validate-a-model)
  - [The error you get back](#the-error-you-get-back)
  - [Rules](#rules)
    - [Null and empty rules](#null-and-empty-rules)
    - [Comparison rules](#comparison-rules)
    - [Between rules](#between-rules)
    - [String rules](#string-rules)
    - [Nested validation rules](#nested-validation-rules)
    - [Custom rules with Must](#custom-rules-with-must)
  - [Rule options](#rule-options)
    - [When and WhenAsync](#when-and-whenasync)
    - [WithFieldName](#withfieldname)
    - [WithMessage](#withmessage)
    - [WithCode](#withcode)
  - [Write your own rule class](#write-your-own-rule-class)
  - [Validate service requests automatically](#validate-service-requests-automatically)
  - [Errors and exceptions](#errors-and-exceptions)

## NuGet packages
<!-- NuGet start -->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Validators)](https://www.nuget.org/packages/gmarginet.Cat.Validators/)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Validators.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Validators.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.Validators.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Validators.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.Validators.Abstractions/) |
| [Cat.Validators](https://www.nuget.org/packages/gmarginet.Cat.Validators/) | Implementation | `dotnet add package gmarginet.Cat.Validators` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Validators)](https://www.nuget.org/packages/gmarginet.Cat.Validators/) |

<!-- NuGet end -->

## Namespaces
<!-- Namespaces start-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Validators.Abstractions](namespaces/Cat.Validators.Abstractions/index.md) | Validator and rule interfaces. |
| [Cat.Validators](namespaces/Cat.Validators/index.md) | The fluent rules, the processor and the module registration. |

<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->

| Module | Why Cat.Validators needs it |
|--------|----------------------------|
| [Cat.Responses](../Cat.Responses/README.md) | Validation returns an `ICatResponse` with one error per failure. |
| [Cat.Expressions](../Cat.Expressions/README.md) | Rules read property values through compiled expressions. |
| [Cat.Extensions](../Cat.Extensions/README.md) | Small helpers for service registration. |

<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

Call `AddCatValidatorsModule` and pass one type from each assembly that holds validators. The module scans those assemblies and registers every non-generic validator with a scoped lifetime. It also registers `ICatValidatorProcessor`.

The rules read property values through the compiled member expression cache from `Cat.Expressions`, so register that too.

```csharp
using Cat.Expressions.Extensions;
using Cat.Validators.Extensions;

builder.Services.AddCatCompiledMemberExpressionCache();
builder.Services.AddCatValidatorsModule(typeof(TodoValidator));
```

### Write a validator

A validator implements `ICatValidator<TModel>` for one model type. In `Build`, pick a property with a lambda and add rules to it. Chain as many rules as you like.

```csharp
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

public class TodoValidator : ICatValidator<Todo>
{
    public void Build(ICatValidatorBuilder<Todo> validator)
    {
        validator.AddPropertyRules(m => m.Title, b =>
        {
            b.NotEmpty();
            b.MaximumLength(100);
        });

        validator.AddPropertyRules(m => m.Priority, b =>
        {
            b.InclusiveBetween(1, 5);
        });
    }
}
```

### Validate a model

Inject `ICatValidatorProcessor` and pass it the model.

```csharp
using Cat.Validators.Abstractions;

public class TodoService
{
    private readonly ICatValidatorProcessor _validatorProcessor;

    public TodoService(ICatValidatorProcessor validatorProcessor)
    {
        _validatorProcessor = validatorProcessor;
    }

    public async Task<ICatResponse> CheckAsync(Todo todo, CancellationToken cancellationToken)
    {
        return await _validatorProcessor.ValidateAsync(todo, cancellationToken: cancellationToken);
    }
}
```

What you get back:

- **Valid model:** An Ok response.
- **Invalid model:** A BadRequest response with one error for each failed rule.
- **No validator registered:** An exception by default. Pass `validatorRequired: false` and the model counts as valid instead.

Prefer `ValidateAsync`. `Validate` blocks until the rules finish, so keep it for places where you can't await.

### The error you get back

Every failure becomes an error with a code, a message template and arguments:

- **Code:** A stable code like `CAT-VAL-1001`. Match on this, not on the text.
- **Message:** A template with named placeholders, like `'{propertyName}' should not be empty.`
- **Arguments:** The values for the placeholders, in order. The first argument is always the field name. The rule adds the rest, like the limit it checked or the length you entered.

The field name is the name of the property, like `Title`. Nested validation adds a prefix, like `Todo.Title` or `Items[0].Title`.

### Rules

Every rule below is an extension method you call on the builder inside `AddPropertyRules`. Each failed rule adds one error. Placeholders are listed in the order of the arguments, after the field name.

#### Null and empty rules

| Rule | Passes when | Code | Message |
|------|-------------|------|---------|
| `NotNull()` | The value is not `null`. | `CAT-VAL-1001` | `'{propertyName}' should not be Null (Empty).` |
| `Null()` | The value is `null`. | `CAT-VAL-1002` | `'{propertyName}' should be Null (Empty).` |
| `NotEmpty()` | The value is not `null`, not a blank string, not an empty collection and not the default of its type, like `0` or `Guid.Empty`. | `CAT-VAL-1003` | `'{propertyName}' should not be empty.` |
| `Empty()` | The value is `null`, a blank string, an empty collection or the default of its type. | `CAT-VAL-1004` | `'{propertyName}' should be empty.` |

These rules have no extra arguments.

```csharp
validator.AddPropertyRules(m => m.Title, b => b.NotEmpty());
validator.AddPropertyRules(m => m.DeletedOn, b => b.Null());
```

#### Comparison rules

Each comparison rule has two forms. Pass a fixed value, or pass a lambda that picks another property of the same model.

| Rule | Passes when | Code | Message | Extra arguments |
|------|-------------|------|---------|-----------------|
| `Equal` | The value equals the other value. | `CAT-VAL-1011` | `'{propertyName}' should be equal to '{comparisonValue}'` | `comparisonValue` |
| `NotEqual` | The value differs from the other value. | `CAT-VAL-1010` | `'{propertyName}' should not be equal to '{comparisonValue}.'` | `comparisonValue` |
| `LessThan` | The value is less than the other value. | `CAT-VAL-1012` | `'{propertyName}' should be less than '{comparisonValue}'.` | `comparisonValue` |
| `LessThanOrEqualTo` | The value is less than or equal to the other value. | `CAT-VAL-1013` | `'{propertyName}' should be less than or equal to '{comparisonValue}'.` | `comparisonValue` |
| `GreaterThan` | The value is greater than the other value. | `CAT-VAL-1014` | `'{propertyName}' should be greater than '{comparisonValue}'.` | `comparisonValue` |
| `GreaterThanOrEqualTo` | The value is greater than or equal to the other value. | `CAT-VAL-1015` | `'{propertyName}' should be greater than or equal to '{comparisonValue}'.` | `comparisonValue` |

`Equal` and `NotEqual` take an optional `IEqualityComparer`. Strings compare ordinal by default, so case matters.

`LessThan`, `LessThanOrEqualTo`, `GreaterThan` and `GreaterThanOrEqualTo` work on any type that implements `IComparable`.

```csharp
validator.AddPropertyRules(m => m.Quantity, b => b.GreaterThan(0));
validator.AddPropertyRules(m => m.EndDate, b => b.GreaterThan(m => m.StartDate));
validator.AddPropertyRules(m => m.Email, b => b.NotEqual("admin@example.com"));
validator.AddPropertyRules(m => m.ConfirmPassword, b => b.Equal(m => m.Password));
```

#### Between rules

Both rules take a lower and an upper bound. The lower bound must be less than the upper bound, or the rule throws when it runs.

| Rule | Passes when | Code | Message | Extra arguments |
|------|-------------|------|---------|-----------------|
| `InclusiveBetween` | The value is between the bounds, bounds included. | `CAT-VAL-1016` | `'{propertyName}' should be between '{lowerBound}' and '{upperBound}' (inclusive). You entered '{propertyValue}'.` | `lowerBound`, `upperBound`, `propertyValue` |
| `ExclusiveBetween` | The value is between the bounds, bounds excluded. | `CAT-VAL-1017` | `'{propertyName}' should be between '{lowerBound}' and '{upperBound}' (exclusive). You entered '{propertyValue}'.` | `lowerBound`, `upperBound`, `propertyValue` |

Each rule has four forms:

- **Fixed bounds:** `InclusiveBetween(1, 10)`
- **Bounds from the model:** `InclusiveBetween(m => m.Min, m => m.Max)`
- **Fixed bounds with your own comparer:** `InclusiveBetween(1, 10, comparer)`
- **Bounds from the model with your own comparer:** `InclusiveBetween(m => m.Min, m => m.Max, comparer)`

```csharp
validator.AddPropertyRules(m => m.Rating, b => b.InclusiveBetween(1, 5));
validator.AddPropertyRules(m => m.Price, b => b.ExclusiveBetween(m => m.MinPrice, m => m.MaxPrice));
```

#### String rules

String rules only compile on `string` properties. They all let a `null` string pass, so pair them with `NotNull` or `NotEmpty` when the text is required.

| Rule | Passes when | Code | Message | Extra arguments |
|------|-------------|------|---------|-----------------|
| `Length(min, max)` | The length is between `min` and `max`. | `CAT-VAL-1005` | `'{propertyName}' should be between '{minLength}' and '{maxLength}' characters. You entered '{length}' characters.` | `minLength`, `maxLength`, `length` |
| `ExactLength(n)` | The length is exactly `n`. | `CAT-VAL-1006` | `'{propertyName}' should be '{exactLength}' characters in length. You entered '{length}' characters.` | `exactLength`, `length` |
| `MaximumLength(n)` | The length is at most `n`. | `CAT-VAL-1007` | `The length of '{propertyName}' should be '{maxLength}' characters or fewer. You entered '{length}' characters.` | `maxLength`, `length` |
| `MinimumLength(n)` | The length is at least `n`. | `CAT-VAL-1008` | `The length of '{propertyName}' should be at least '{minLength}' characters. You entered '{length}' characters.` | `minLength`, `length` |
| `MatchesRegex` | The text matches the regular expression. | `CAT-VAL-1009` | `'{propertyName}' is not in the correct format. [regex: {regexPattern}]` | `regexPattern` |

`Length` needs `min` to be less than `max`, or the rule throws when it runs.

Each length rule also takes a lambda instead of a number, so the limit can come from the model: `MaximumLength(m => m.MaxTitleLength)`.

`MatchesRegex` has four forms:

- **A pattern:** `MatchesRegex(@"^\d{4}$")`, with optional `RegexOptions`.
- **A pattern from the model:** `MatchesRegex(m => m.Pattern)`, with optional `RegexOptions`.
- **A `Regex`:** `MatchesRegex(new Regex(@"^\d{4}$"))`
- **A `Regex` from the model:** `MatchesRegex(m => m.Regex)`

```csharp
validator.AddPropertyRules(m => m.Title, b =>
{
    b.NotEmpty();
    b.Length(3, 100);
});

validator.AddPropertyRules(m => m.PostalCode, b =>
{
    b.NotEmpty();
    b.MatchesRegex(@"^\d{4}[A-Z]{2}$");
});
```

#### Nested validation rules

These rules run another validator on a property. Register that validator too. The `validatorRequired` flag of the top level call decides what happens when a type has no validator:

- **`validatorRequired: true` (default):** The rule throws.
- **`validatorRequired: false`:** The type is skipped and passes.

| Rule | Does |
|------|------|
| `Validate()` | Runs the validator of the property type. A `null` property passes. |
| `ValidateEnumerable()` | Runs the validator of the item type on every item of a collection. A `null` collection passes. A `null` item is skipped but still counts for the index. |

The errors of the nested validator keep their own code and message. Only the field name changes:

- **`Validate()`:** The property name goes in front, like `Todo.Title`.
- **`ValidateEnumerable()`:** The property name and the index go in front, like `Items[0].Title`.

```csharp
validator.AddPropertyRules(m => m.Todo, b => b.NotNull());
validator.AddPropertyRules(m => m.Todo, b => b.Validate());
validator.AddPropertyRules(m => m.Items, b => b.ValidateEnumerable());
```

#### Custom rules with Must

When no built-in rule fits, write the check yourself. `Must` and `MustAsync` hand you the value and the field name, and you return the list of errors. Return `CatValidatorResult.Valid()` when all is well.

Use `CatValidatorError.Create(code, fieldName, message, arguments)` to build an error.

```csharp
validator.AddPropertyRules(m => m.Title, b =>
{
    b.Must((title, fieldName) => title.StartsWith("TODO")
        ? CatValidatorResult.Valid()
        : CatValidatorResult.Invalid(
            CatValidatorError.Create("APP-1001", fieldName, "'{propertyName}' should start with TODO.")));
});
```

There are four forms:

| Method | Gets |
|--------|------|
| `Must` | The value and the field name. |
| `MustAsync` | The value, the field name and a cancellation token. |
| `Must` | The value, the field name and the whole model. |
| `MustAsync` | The value, the field name, the whole model and a cancellation token. |

To check the whole model instead of one property, use `AddRules`. The lambda gets the model, or the model and a cancellation token for `MustAsync`.

```csharp
validator.AddRules(b =>
{
    b.Must(todo => todo.EndDate >= todo.StartDate
        ? CatValidatorResult.Valid()
        : CatValidatorResult.Invalid(
            CatValidatorError.Create("APP-1002", "EndDate", "The end date should not be before the start date.")));
});
```

`Must` and `MustAsync` return nothing, so you can't chain rule options after them. You build the errors yourself, so set the code, field name and message there.

### Rule options

Every built-in rule returns an options builder. Chain options right after the rule. Each option applies only to that one rule.

```csharp
validator.AddPropertyRules(m => m.Title, b =>
{
    b.NotEmpty()
        .WithFieldName("Name")
        .WithCode("APP-2001")
        .WithMessage("Please enter a name.")
        .When(m => m.IsPublished);
});
```

#### When and WhenAsync

`When` runs the rule only when the condition returns `true`. When it returns `false`, the rule is skipped and adds no error. `WhenAsync` does the same with an async condition.

Add several conditions to one rule and all of them must be `true`.

```csharp
b.MaximumLength(50).When(m => m.IsDraft);

b.NotNull().WhenAsync((m, ct) => featureFlags.IsEnabledAsync("todo-title", ct));
```

The condition gets the whole model, so you can look at other properties. The async condition is an expression, so it can't be an `async` lambda. Return the `Task<bool>` directly.

#### WithFieldName

`WithFieldName` replaces the field name in the error. By default the field name is the property name. Use it when your API calls the field something else.

```csharp
b.NotEmpty().WithFieldName("name");
```

The new name is also the first argument of the error, so it shows up in the message.

#### WithMessage

`WithMessage` replaces the message template. The arguments of the rule stay the same, so you can keep using its placeholders.

```csharp
b.MaximumLength(100).WithMessage("'{propertyName}' is too long. The limit is '{maxLength}'.");
```

#### WithCode

`WithCode` replaces the error code. Use it to give a rule a code of your own, so clients can tell two uses of the same rule apart.

```csharp
b.NotEmpty().WithCode("APP-2001");
```

### Write your own rule class

When you reuse a check in many validators, wrap it in a rule class. Derive from one of the base classes and add a small extension method.

| Base class | Use it for |
|------------|------------|
| `CatValidatorPropertyRuleBase<TModel, TProperty>` | A synchronous rule on a property. Implement `Validate(value, fieldName, model)`. |
| `CatValidatorPropertyRuleAsyncBase<TModel, TProperty>` | An async rule on a property. Implement `ValidateAsync(value, fieldName, model, ct)`. |
| `CatValidatorModelRuleBase<TModel>` | A synchronous rule on the whole model. Implement `Validate(model)`. |
| `CatValidatorModelRuleAsyncBase<TModel>` | An async rule on the whole model. Implement `ValidateAsync(model, ct)`. |

The property bases give you `ErrorCode`, `FieldName` and `ErrorMessage`, so `WithCode`, `WithFieldName` and `WithMessage` work on your rule too. Fall back to your own defaults like the built-in rules do.

```csharp
public class PropertyStartsWithTodoRule<TModel> : CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(string value, string fieldName, TModel model)
    {
        return value.StartsWith("TODO")
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid(
                CatValidatorError.Create(
                    code: ErrorCode ?? "APP-1001",
                    fieldName: FieldName ?? fieldName,
                    message: ErrorMessage ?? "'{propertyName}' should start with TODO."));
    }
}

public static class TodoRuleExtensions
{
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> StartsWithTodo<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder)
        where TModel : class
    {
        return builder.AddPropertyRule(new PropertyStartsWithTodoRule<TModel>());
    }
}
```

### Validate service requests automatically

You rarely call the processor by hand. The Cat.ServiceRequests module has a validation decorator that runs the validator of a request before its handler. An invalid request never reaches the handler. See the [Cat.ServiceRequests](../Cat.ServiceRequests/README.md) module.

### Errors and exceptions

A broken model never throws. The processor returns a response. Mistakes in how you set up the validators throw exceptions.

| Situation | What you get |
|-----------|--------------|
| The model passes every rule | An `Ok` response. |
| One or more rules fail | A `BadRequest` response with one error for each failed rule. See [The error you get back](#the-error-you-get-back). |
| A condition from `When` or `WhenAsync` returns `false` | The rule is skipped and adds no error. |
| No validator is registered for the model | An `InvalidOperationException` from the service provider. Pass `validatorRequired: false` to treat the model as valid instead. |
| A nested type used with `Validate()` or `ValidateEnumerable()` has no validator | The same exception, or a pass with `validatorRequired: false`. |
| `ICatCompiledMemberExpressionCache<T>` isn't registered | An `InvalidOperationException` from the service provider when the rules run. Register the Cat.Expressions cache. |
| `Length` gets a minimum that isn't less than the maximum | An `ArgumentOutOfRangeException` with the message `<lowerBoundName> must be less than <upperBoundName>.` when the rule runs. |
| `InclusiveBetween` or `ExclusiveBetween` gets a lower bound that isn't less than the upper bound | The same `ArgumentOutOfRangeException`. |
| `MatchesRegex` gets an invalid pattern | An `ArgumentException` with the message `Invalid regex expression: <pattern>`. |
| A rule class isn't a property rule or a model rule | An `ArgumentException` with the message `Rule <name> is not a valid property rule` or `Rule <name> is not a valid model rule`. |

The code, message and arguments of every built-in rule are listed in [Rules](#rules). `CAT-VAL-1000` (`Unknown validation error occurred.`) is defined as a fallback.

Codes you pass to `WithCode` or `CatValidatorError.Create` appear in the response as you wrote them. Give your own codes a prefix of your own, like `APP-`, so they don't clash with `CAT-VAL-` or `CAT-GEN-`.
<!-- Usage end-->
