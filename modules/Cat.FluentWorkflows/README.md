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

|&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Cat.FluentWorkflows <!-- omit in toc -->  

<!-- Intro start-->
Cat.FluentWorkflows lets you describe a business process as a list of steps in plain C#. Each step does one small thing: run some code, set a value, make a decision, loop over a collection, or call a command or a query. You read the workflow from top to bottom like a recipe.

A workflow works on a state object. Steps read from it and write to it, so the data a process needs travels through the steps in one place. Steps can decide to stop the process early, leave a loop, or report errors.

The module ships the common steps for you, and you can write your own.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [The building blocks](#the-building-blocks)
  - [Write a workflow](#write-a-workflow)
  - [Run a workflow](#run-a-workflow)
  - [How a step decides what happens next](#how-a-step-decides-what-happens-next)
  - [Built-in steps](#built-in-steps)
    - [Run code](#run-code)
    - [Run code that decides what happens next](#run-code-that-decides-what-happens-next)
    - [Set](#set)
    - [Log](#log)
    - [If](#if)
    - [While](#while)
    - [Foreach](#foreach)
    - [Switch](#switch)
    - [Break](#break)
    - [Break if](#break-if)
    - [Run a sub-workflow](#run-a-sub-workflow)
    - [Process a command](#process-a-command)
    - [Process a query](#process-a-query)
  - [Create your own steps](#create-your-own-steps)
    - [A step that works on inputs and outputs](#a-step-that-works-on-inputs-and-outputs)
    - [A step that works on the workflow state](#a-step-that-works-on-the-workflow-state)
    - [Register your steps and workflows](#register-your-steps-and-workflows)
  - [Errors and exceptions](#errors-and-exceptions)
  - [Tracing](#tracing)

## NuGet packages
<!-- NuGet start -->
![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.FluentWorkflows)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.FluentWorkflows.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.FluentWorkflows.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.FluentWorkflows.Abstractions` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.FluentWorkflows.Abstractions) |
| [Cat.FluentWorkflows](https://www.nuget.org/packages/gmarginet.Cat.FluentWorkflows/) | Implementation | `dotnet add package gmarginet.Cat.FluentWorkflows` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.FluentWorkflows) |
| [Cat.FluentWorkflows.Commands](https://www.nuget.org/packages/gmarginet.Cat.FluentWorkflows.Commands/) | Optional steps | `dotnet add package gmarginet.Cat.FluentWorkflows.Commands` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.FluentWorkflows.Commands) |
| [Cat.FluentWorkflows.Queries](https://www.nuget.org/packages/gmarginet.Cat.FluentWorkflows.Queries/) | Optional steps | `dotnet add package gmarginet.Cat.FluentWorkflows.Queries` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.FluentWorkflows.Queries) |
<!-- NuGet end -->

## Namespaces
<!-- Namespaces start-->
| Namespace | What it holds |
|-----------|---------------|
| [Cat.FluentWorkflows.Abstractions](namespaces/Cat.FluentWorkflows.Abstractions/index.md) | Interfaces for workflows, steps and the workflow state. |
| [Cat.FluentWorkflows](namespaces/Cat.FluentWorkflows/index.md) | The workflow engine, the built-in steps and the module registration. |
| [Cat.FluentWorkflows.Commands](namespaces/Cat.FluentWorkflows.Commands/index.md) | A step that processes a command. |
| [Cat.FluentWorkflows.Queries](namespaces/Cat.FluentWorkflows.Queries/index.md) | A step that processes a query. |
<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->
| Module | Why Cat.FluentWorkflows needs it |
|--------|---------------------------------|
| [Cat.Responses](../Cat.Responses/README.md) | Workflows and steps report their outcome as a response. |
| [Cat.Commands](../Cat.Commands/README.md) | The command step hands commands to the command processor. |
| [Cat.Queries](../Cat.Queries/README.md) | The query step hands queries to the query processor. |
| [Cat.Extensions](../Cat.Extensions/README.md) | Small helpers for service registration. |
<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

Call `AddCatFluentWorkflowsModule` to register the processors and every built-in step. Register logging too, because every step gets a logger.

Then register your own workflows and steps. Pass one type from each assembly that holds them.

```csharp
using Cat.FluentWorkflows.Extensions;

builder.Services.AddLogging();
builder.Services.AddCatFluentWorkflowsModule();
builder.Services.AddCatFluentWorkflowsFlows(typeof(ProcessOrderWorkflow));
builder.Services.AddCatFluentWorkflowsSteps(typeof(CalculateDiscountStep));
```

If you use the command or query steps, register those too. Both need their own module:

```csharp
using Cat.FluentWorkflows.Commands.Extensions;
using Cat.FluentWorkflows.Queries.Extensions;

builder.Services.AddCatBuildInCommandWorkflowStep();
builder.Services.AddCatBuildInQueryWorkflowStep();
```

### The building blocks

| Block | What it is |
|-------|------------|
| **Workflow state** | A class that holds the data of one run. Steps read from it and write to it. |
| **Workflow** | A class that lists the steps in order. |
| **Step** | One unit of work. Built-in steps cover the common cases. |
| **Step body** | The class behind a step that does the work. You write one for your own steps. |
| **Workflow processor** | Runs a workflow on a state and gives you the outcome. |

The examples in this chapter use this state:

```csharp
using Cat.FluentWorkflows.Abstractions;

public enum OrderType { Standard, Express, Pickup }

public record OrderLine(string ProductId, int Quantity, decimal Price);

public class OrderState : ICatWorkflowState<OrderState>
{
    public List<OrderLine> Lines { get; set; } = [];
    public OrderType Type { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public int Attempts { get; set; }
    public string Status { get; set; } = "New";
}
```

A state implements `ICatWorkflowState<T>` with the class itself as `T`.

### Write a workflow

A workflow implements `ICatWorkflow<TState>`. In `Build`, call the builder to add steps. They run in the order you add them.

The steps are extension methods on the builder. Add `using Cat.FluentWorkflows.Extensions;` to see them.

```csharp
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;

public class ProcessOrderWorkflow : ICatWorkflow<OrderState>
{
    public void Build(ICatWorkflowBuilder<OrderState> builder)
    {
        builder.Set(s => s.Total, s => s.Lines.Sum(l => l.Quantity * l.Price));

        builder.If(s => s.Total >= 100,
            then => then.Set(s => s.Discount, s => s.Total * 0.1m));

        builder.Run(s => s.Status = "Processed");
    }
}
```

### Run a workflow

Inject `ICatWorkflowProcessor` and call `RunAsync`. Give it the workflow type, the state type and a state. The steps change that state, so read your results from it afterwards.

```csharp
using Cat.FluentWorkflows.Abstractions;

public class OrderService
{
    private readonly ICatWorkflowProcessor _workflowProcessor;

    public OrderService(ICatWorkflowProcessor workflowProcessor)
    {
        _workflowProcessor = workflowProcessor;
    }

    public async Task<OrderState> ProcessAsync(OrderState state, CancellationToken cancellationToken)
    {
        var response = await _workflowProcessor.RunAsync<ProcessOrderWorkflow, OrderState>(state, cancellationToken);

        if (response.ErrorList.Count > 0)
        {
            // a step reported errors
        }

        return state;
    }
}
```

The response holds two things:

- **`WorkflowResult`:** How the workflow ended, as a `CatStepExecutionResult`.
- **`ErrorList`:** The errors a step reported. The list is empty when nothing failed.

### How a step decides what happens next

Every step returns a result. The step processor reads it after the step and decides what to do.

| Result | What happens |
|--------|--------------|
| `Continue` | Go on with the next step. |
| `BreakCascade` | Stop this list of steps and every list around it. The workflow ends with this result. Use it to end a workflow on a failure. |
| `BreakFromCurrentFlowOnly` | Stop this list of steps. A workflow ends, and its caller goes on as if it succeeded. Inside a foreach it ends only the current item. |
| `BreakFromLoop` | Leave the nearest loop, a while or a foreach, and go on with the step after it. |
| `ContinueLoop` | Reserved for loops. The step processor does not stop on it, and no built-in step returns it. |

"A list of steps" means the steps of a workflow, or the inner steps of an if, a while, a foreach or a switch case.

The workflow processor reports `BreakFromCurrentFlowOnly` as `Continue`, so the caller of a workflow never sees it.

### Built-in steps

Every built-in step is an extension method on the workflow builder, in the `Cat.FluentWorkflows.Extensions` namespace. The command and query steps live in their own namespaces, as described below.

#### Run code

`Run` adds a step that runs your code on the state. The workflow always goes on with the next step. Use it for small bits of logic that don't deserve a step class.

There are two forms. The second one also gets a logger.

```csharp
builder.Run(s => s.Attempts++);

builder.Run((logger, s) => logger.LogInformation("Order has {count} lines", s.Lines.Count));
```

`Run` with an action can't stop the workflow. To stop it, use the next step or a break step.

#### Run code that decides what happens next

`Run` with a function returns a response. A succeeded response carries the `CatStepExecutionResult` to use. A failed response ends the workflow with `BreakCascade` and passes its errors on.

The function gets the state, or a logger and the state.

```csharp
using Cat.Responses;

builder.Run(s =>
{
    if (s.Lines.Count == 0)
    {
        return CatResponse.BadRequest<CatStepExecutionResult>(
            CatError.Create("ORD-1001", "An order needs at least one line."));
    }

    return CatResponse.Ok(CatStepExecutionResult.Continue);
});
```

The example above ends the workflow on an empty order and reports the error. Return `CatResponse.Ok(CatStepExecutionResult.BreakFromCurrentFlowOnly)` to end the workflow without an error.

#### Set

`Set` calculates a value and writes it to a property of the state. Pick the property with a lambda, and give a function that calculates the value from the state.

```csharp
builder.Set(s => s.Total, s => s.Lines.Sum(l => l.Quantity * l.Price));
```

The second form gets a logger too. It takes an expression, so keep it to a single expression:

```csharp
builder.Set(s => s.Status, (logger, s) => s.Total > 0 ? "Priced" : "Empty");
```

#### Log

`Log` writes a log entry from inside the workflow. Give a message template, and a function that returns the values for its placeholders from the state.

There is a method per level: `LogTrace`, `LogDebug`, `LogInformation`, `LogWarning`, `LogError` and `LogCritical`. `Log` takes the level as its first argument.

```csharp
builder.LogInformation("Order total is {total}", s => [s.Total]);

builder.Log(LogLevel.Warning, "Order has {attempts} attempts", s => [s.Attempts]);
```

A log step never stops the workflow.

#### If

`If` runs one list of steps when a condition is `true`, and another when it is `false`. The else part is optional. Both lists work on the same state.

```csharp
builder.If(s => s.Type == OrderType.Express,
    then =>
    {
        then.Set(s => s.Status, s => "Express");
        then.LogInformation("Express order", s => []);
    },
    otherwise =>
    {
        otherwise.Set(s => s.Status, s => "Standard");
    });
```

A break inside an if goes on to the steps around it. A `BreakCascade` in the then part ends the whole workflow. A `BreakFromCurrentFlowOnly` in the then part ends the whole workflow too, because the if is part of it.

Leave out the else part to do nothing when the condition is `false`:

```csharp
builder.If(s => s.Total >= 100, then => then.Set(s => s.Discount, s => s.Total * 0.1m));
```

#### While

`While` repeats a list of steps while a condition is `true`. The condition is checked before every pass. Make sure something in the loop changes the state, or the loop never ends.

```csharp
builder.While(s => s.Attempts < 3, loop =>
{
    loop.Run(s => s.Attempts++);
    loop.LogInformation("Attempt {attempts}", s => [s.Attempts]);
});
```

Leave the loop early with a break:

- **`BreakFromLoop` or `BreakFromLoopIf`:** Leaves the loop and goes on with the step after it.
- **`BreakCascade` or `BreakCascadeIf`:** Leaves the loop and ends the workflow with `BreakCascade`.

```csharp
builder.While(s => s.Attempts < 10, loop =>
{
    loop.Run(s => s.Attempts++);
    loop.BreakFromLoopIf(s => s.Status == "Done");
});

builder.While(s => s.Attempts < 10, loop =>
{
    loop.Run(s => s.Attempts++);
    loop.BreakCascadeIf(s => s.Status == "Failed");
});
```

The errors of every pass are kept. See [Errors and exceptions](#errors-and-exceptions).

#### Foreach

`Foreach` runs a list of steps for every item of a collection. The collection is read once, when the loop starts.

The inner steps don't work on your state. They work on a loop state that holds:

- **`CurrentItem`:** The item the loop is on.
- **`ParentWorkflowState`:** Your state, so the inner steps can still read and change it.

```csharp
builder.Foreach(s => s.Lines, loop =>
{
    loop.Run(item => item.ParentWorkflowState.Total += item.CurrentItem.Quantity * item.CurrentItem.Price);
});
```

When the inner steps need extra data next to the current item, write your own loop state. It implements `ICatForeachState<TItem, TState>` and `ICatWorkflowState<TLoopState>`, and needs a parameterless constructor. The loop creates one instance and reuses it for every item.

With your own state the compiler can't work out the type arguments, so give all three: the workflow state, the item type and the loop state.

```csharp
public class OrderLineState : ICatForeachState<OrderLine, OrderState>, ICatWorkflowState<OrderLineState>
{
    public OrderLine CurrentItem { get; set; } = null!;
    public OrderState ParentWorkflowState { get; set; } = null!;
    public decimal LineTotal { get; set; }
}

builder.Foreach<OrderState, OrderLine, OrderLineState>(s => s.Lines, loop =>
{
    loop.Set(l => l.LineTotal, l => l.CurrentItem.Quantity * l.CurrentItem.Price);
    loop.Run(l => l.ParentWorkflowState.Total += l.LineTotal);
});
```

How breaks behave inside a foreach:

| Break | Effect |
|-------|--------|
| `BreakFromLoop` | Leaves the loop. The workflow goes on after the foreach. |
| `BreakCascade` | Leaves the loop and ends the workflow. |
| `BreakFromCurrentFlowOnly` | Ends only the current item. The loop goes on with the next item. |

```csharp
builder.Foreach(s => s.Lines, loop =>
{
    loop.BreakFromLoopIf(item => item.CurrentItem.Quantity == 0);
    loop.Run(item => item.ParentWorkflowState.Attempts++);
});
```

#### Switch

`Switch` runs the list of steps of the case that matches a value. The value must be a struct, like an enum or an int. Give it a function that reads the value from the state, and describe the cases.

```csharp
builder.Switch(s => s.Type, cases =>
{
    cases.Case(OrderType.Standard, steps => steps.Set(s => s.Status, s => "Standard"));
    cases.Case(OrderType.Express, steps => steps.Set(s => s.Status, s => "Express"));
    cases.Default(steps => steps.Set(s => s.Status, s => "Other"));
});
```

The rules:

- **`Case(value, steps)`:** Runs the steps when the value matches.
- **`Case(value)` without steps:** Falls through to the next case that has steps. Use it to share steps between values.
- **`Default(steps)`:** Runs when no case matches.
- **No match and no default:** The switch does nothing and the workflow goes on.
- **Duplicate case:** Using the same value twice throws when the workflow is built.

Sharing steps between values:

```csharp
builder.Switch(s => s.Type, cases =>
{
    cases.Case(OrderType.Express);
    cases.Case(OrderType.Pickup, steps => steps.Set(s => s.Status, s => "Fast lane"));
});
```

Here both `Express` and `Pickup` run the steps of the `Pickup` case.

#### Break

A break step stops the current list of steps right away.

| Method | Effect |
|--------|--------|
| `BreakCascade()` | Stops this list and every list around it. The workflow ends with `BreakCascade`. |
| `BreakFromCurrentFlowOnly()` | Stops this list. A workflow ends and its caller goes on as if it succeeded. |
| `BreakFromLoop()` | Leaves the nearest while or foreach. |

Use a break inside an `If` to stop on a condition:

```csharp
builder.If(s => s.Lines.Count == 0, then =>
{
    then.LogWarning("Empty order", s => []);
    then.BreakFromCurrentFlowOnly();
});
```

#### Break if

The `If` variants break only when a check returns `true`. They are shorter than an `If` with a break inside. Each one has a form with a logger.

| Method | Same as |
|--------|---------|
| `BreakCascadeIf(check)` | `BreakCascade()` when the check is `true` |
| `BreakFromCurrentFlowOnlyIf(check)` | `BreakFromCurrentFlowOnly()` when the check is `true` |
| `BreakFromLoopIf(check)` | `BreakFromLoop()` when the check is `true` |

```csharp
builder.BreakFromCurrentFlowOnlyIf(s => s.Lines.Count == 0);

builder.BreakCascadeIf((logger, s) =>
{
    logger.LogWarning("Total {total}", s.Total);
    return s.Total < 0;
});
```

#### Run a sub-workflow

A sub-workflow is a workflow that another workflow runs as one step. Use it to split a big process into pieces, or to reuse a piece.

The sub-workflow has its own state. The state of the main workflow carries it by implementing `ICatHasSubWorkflowState<TSubState>`. Fill the sub state before the step runs.

```csharp
public class PaymentState : ICatWorkflowState<PaymentState>
{
    public decimal Amount { get; set; }
    public bool Paid { get; set; }
}

public class OrderState : ICatWorkflowState<OrderState>, ICatHasSubWorkflowState<PaymentState>
{
    // other properties as before
    public PaymentState WorkflowState { get; set; } = new();
}

public class PaymentWorkflow : ICatWorkflow<PaymentState>
{
    public void Build(ICatWorkflowBuilder<PaymentState> builder)
    {
        builder.Run(s => s.Paid = s.Amount > 0);
    }
}

public class CheckoutWorkflow : ICatWorkflow<OrderState>
{
    public void Build(ICatWorkflowBuilder<OrderState> builder)
    {
        builder.Run(s => s.WorkflowState.Amount = s.Total);
        builder.Run<PaymentWorkflow, PaymentState, OrderState>();
        builder.Run(s => s.Status = s.WorkflowState.Paid ? "Paid" : "Unpaid");
    }
}
```

Register the sub-workflow with `AddCatFluentWorkflowsFlows`, like any other workflow.

How breaks cross the boundary:

- **`BreakFromCurrentFlowOnly` in the sub-workflow:** Ends only the sub-workflow. The main workflow goes on.
- **`BreakCascade` in the sub-workflow:** Ends the main workflow too.

#### Process a command

`ProcessCommand` sends a command through Cat.Commands. It lives in `Cat.FluentWorkflows.Commands`.

The step creates the command with its parameterless constructor. Fill the command with `Input`, which copies a value from the state into a member of the step. A command with positional parameters needs an extra parameterless constructor.

```csharp
using Cat.Commands.Abstractions;
using Cat.FluentWorkflows.Commands;

public record SaveOrderCommand(string Status) : ICatCommand
{
    public SaveOrderCommand() : this("")
    {
    }
}

builder.ProcessCommand<OrderState, SaveOrderCommand>()
    .Input(s => s.Status, step => step.Command.Status);
```

What happens after the command ran:

- **Succeeded:** The workflow goes on with the next step.
- **Failed:** The workflow ends with `BreakCascade` and carries the errors of the command.
- **Exception:** The step logs it and throws it again.

The step keeps the response of the command in `Response`. Read it with `Output` when you need it.

#### Process a query

`ProcessQuery` sends a query through Cat.Queries. It lives in `Cat.FluentWorkflows.Queries`. It works like the command step. The query needs a parameterless constructor, you fill it with `Input`, and you read the result with `Output`.

```csharp
using Cat.FluentWorkflows.Queries;
using Cat.Queries.Abstractions;

public record GetDiscountQuery : ICatQuery<decimal>
{
    public decimal Total { get; set; }
}

builder.ProcessQuery<OrderState, GetDiscountQuery, decimal>()
    .Input(s => s.Total, step => step.Query.Total)
    .Output(step => step.Response!.Value, s => s.Discount);
```

A failed query ends the workflow with `BreakCascade` and carries the errors of the query. The output is copied after the step ran, so check the workflow response for errors before you trust the value.

### Create your own steps

A step you write is a class, called a step body. The workflow builder runs it with `Run<TWorkflowState, TStepBody>()`. Give both type arguments, like `builder.Run<OrderState, CheckStockStep>()`. You connect it to the state with two calls:

- **`Input(source, target)`:** Before the step runs, copies a value from the state into a member of the step.
- **`Output(source, target)`:** After the step ran, copies a value from a member of the step into the state.

Both take two lambdas. The target of each must be a member access, like `step => step.Total`, with a public setter.

A step returns a `CatWorkflowResponse`. Create one with `CatWorkflowResponse.Succeeded(result)` or `CatWorkflowResponse.Failed(result, errors)`.

Pick the base class that fits:

| Base class | Use it when |
|------------|-------------|
| `CatStepBody` | The work is synchronous and the step only needs its inputs. |
| `CatStepBodyAsync` | The work is asynchronous and the step only needs its inputs. |
| `CatStepBody<TState>` | The work is synchronous and the step needs the workflow state. |
| `CatStepBodyAsync<TState>` | The work is asynchronous and the step needs the workflow state. |

Every base class gives you a `Logger`.

#### A step that works on inputs and outputs

This step has no idea what an order is. It gets a total and hands a discount back, so you can reuse it in any workflow.

```csharp
using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

public class CalculateDiscountStep : CatStepBody
{
    public CalculateDiscountStep(ILogger<CalculateDiscountStep> logger)
        : base(logger)
    {
    }

    public decimal Total { get; set; }

    public decimal Discount { get; private set; }

    protected override ICatWorkflowResponse Run()
    {
        Discount = Total >= 100 ? Total * 0.1m : 0m;

        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
```

Use it in a workflow and connect it to the state:

```csharp
builder.Run<OrderState, CalculateDiscountStep>()
    .Input(s => s.Total, step => step.Total)
    .Output(step => step.Discount, s => s.Discount);
```

#### A step that works on the workflow state

This step is asynchronous, gets a service from dependency injection, and reads the state through `WorkflowState`. When something is wrong it ends the workflow and reports an error.

```csharp
using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses;
using Microsoft.Extensions.Logging;

public class CheckStockStep : CatStepBodyAsync<OrderState>
{
    private readonly IStockService _stockService;

    public CheckStockStep(IStockService stockService, ILogger<CheckStockStep> logger)
        : base(logger)
    {
        _stockService = stockService;
    }

    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        foreach (var line in WorkflowState.Lines)
        {
            if (await _stockService.IsInStockAsync(line.ProductId, line.Quantity, cancellationToken) is false)
            {
                Logger.LogWarning("Product {productId} is out of stock", line.ProductId);

                return CatWorkflowResponse.Failed(
                    CatStepExecutionResult.BreakCascade,
                    CatError.Create("ORD-1002", "Product '{productId}' is out of stock.", line.ProductId));
            }
        }

        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
```

This step needs no `Input` or `Output`. Add it to the workflow as it is:

```csharp
builder.Run<OrderState, CheckStockStep>();
```

#### Register your steps and workflows

The step processor gets every step body from the service provider, so each one must be registered. `AddCatFluentWorkflowsSteps` finds them for you, and `AddCatFluentWorkflowsFlows` does the same for workflows. Both scan the assemblies of the types you pass. They register public classes that are not generic, with a transient lifetime.

```csharp
builder.Services.AddCatFluentWorkflowsSteps(typeof(CalculateDiscountStep));
builder.Services.AddCatFluentWorkflowsFlows(typeof(ProcessOrderWorkflow));
```

Steps are transient, so a step is never shared between runs. Keep step state in properties that `Input` fills, not in static fields.

### Errors and exceptions

A step reports an expected failure as errors in its response. A mistake in how you build or register the workflow throws an exception.

The workflow response combines two things:

- **The result:** The result of the last step that ran. It tells you how the workflow ended.
- **The errors:** The errors of every step that ran, including the steps inside an if, a loop or a sub-workflow. A loop keeps the errors of every pass.

So a step can fail and let the workflow go on. Its errors are still in the final response:

```csharp
// returns CatWorkflowResponse.Failed(CatStepExecutionResult.Continue, error)
builder.Run<OrderState, ValidateOptionalDataStep>();
builder.Run(s => s.Status = "Done");
```

The workflow above ends with `Continue` and the error of the first step in `ErrorList`. That makes `ErrorList.Count > 0` mean "something failed somewhere". To also stop the workflow on a failure, return `BreakCascade` with the errors, as the examples above do.

The built-in steps that call other code stop on a failure. A failed `ProcessCommand`, a failed `ProcessQuery` and a failed `Run` with a function all end the workflow with `BreakCascade`. A break step ends the workflow with no errors of its own.

Exceptions are not turned into responses. They leave the workflow processor, so catch them where you call it.

| Situation | What you get |
|-----------|--------------|
| A step returns a failed `CatWorkflowResponse` | The errors land in `ErrorList`. The workflow stops only when the step returns `BreakCascade`. |
| `Run` with a function returns a failed response | The workflow ends with `BreakCascade` and carries the errors. |
| `ProcessCommand` or `ProcessQuery` gets a failed response | The workflow ends with `BreakCascade` and carries the errors of the command or query. |
| `ProcessCommand` or `ProcessQuery` throws | The step logs the exception and throws it again. |
| The state you pass to `RunAsync` is `null` | An `ArgumentNullException` with the parameter name `workflowState`. |
| A step body or a workflow isn't registered | An `InvalidOperationException` from the service provider when the processor asks for it. Check `AddCatFluentWorkflowsSteps` and `AddCatFluentWorkflowsFlows`. |
| The target of `Input` or `Output` isn't a member access, like `step => step.Total` | A `NotSupportedException` when you build the workflow. |
| `Switch` gets the same case value twice | An `Exception` with the message `Case with value '<value>' is already defined.` when you build the workflow. |
| A step throws | The exception leaves the workflow processor as it is. |

### Tracing

The workflow processor starts an activity named `Processing Workflow <name>` for every run. The activity source is called `Cat.FluentWorkFlows`. Add it to your OpenTelemetry setup to collect the traces:

```csharp
using Cat.FluentWorkflows.Telemetry;

tracing.AddSource(CatWorkFlowActivitySource.ActivitySourceName);
```
<!-- Usage end-->
