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

# Cat.Sagas <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Sagas runs a workflow over a long time. A workflow sends a message, waits for the answer and goes on when the answer arrives, maybe hours later. While it waits, its state sits in a store and nothing stays in memory.

It builds on `Cat.FluentWorkflows`. The engine there can stop at a step and go on from the same place later. This module adds what a long wait needs: a saved instance, a step that sends a request and waits, and a handler that gives the answer to the right instance. It covers any long running workflow, not only the classic saga with compensation.

A message that arrives twice, or a workflow that changed while instances wait, does not corrupt an instance. See [Rules to follow](#rules-to-follow).  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Write the messages](#write-the-messages)
  - [Write the workflow](#write-the-workflow)
  - [Register the module](#register-the-module)
  - [Keep the instances in your database](#keep-the-instances-in-your-database)
  - [Start a saga](#start-a-saga)
  - [What happens at the wait step](#what-happens-at-the-wait-step)
  - [Use the outbox](#use-the-outbox)
  - [Answer from another service](#answer-from-another-service)
  - [Skip a repeated answer](#skip-a-repeated-answer)
  - [Wait for more than one kind of answer](#wait-for-more-than-one-kind-of-answer)
  - [Time out a wait](#time-out-a-wait)
  - [Rules to follow](#rules-to-follow)
  - [Test a saga](#test-a-saga)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Sagas)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Sagas.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Sagas.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.Sagas.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Sagas.Abstractions)](#nuget-packages) |
| [Cat.Sagas](https://www.nuget.org/packages/gmarginet.Cat.Sagas/) | Implementation | `dotnet add package gmarginet.Cat.Sagas` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Sagas)](#nuget-packages) |
| [Cat.Sagas.EFCore](https://www.nuget.org/packages/gmarginet.Cat.Sagas.EFCore/) | Optional store for EF Core | `dotnet add package gmarginet.Cat.Sagas.EFCore` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Sagas.EFCore)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Sagas.Abstractions](namespaces/Cat.Sagas.Abstractions/index.md) | The saga instance and its status, the store, the serializer, the runner and the dispatcher. |
| [Cat.Sagas](namespaces/Cat.Sagas/index.md) | The runner, the dispatcher, the wait step, the answer handler, the JSON serializer, an in-memory store and the registration. |
| [Cat.Sagas.EFCore](namespaces/Cat.Sagas.EFCore/index.md) | The saga table and the store on EF Core. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.Sagas needs it |
|--------|-----------------------------|
| [Cat.FluentWorkflows](../Cat.FluentWorkflows/README.md) | The engine that stops a workflow at a step and goes on from there. |
| [Cat.Messaging](../Cat.Messaging/README.md) | The wait step sends its request through the message sender. |
| [Cat.ServiceRequests](../Cat.ServiceRequests/README.md) | An answer message is a service request, and the answer handler is a service request handler. |
| [Cat.Responses](../Cat.Responses/README.md) | The dispatcher answers with a response, which tells the event processor what to do with the message. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Write the messages
The request is a message that you send. The answer is a message and a service request at the same time, so the event processor can hand it to a handler. Both inherit the base classes of `Cat.Messaging`, so they have a `CorrelationId` that you can set:

```csharp
public class TakePayment : CatCommandMessage
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
}

public class PaymentTaken : CatEventMessage, ICatServiceRequest
{
    public Guid OrderId { get; set; }
}
```

The saga puts its instance id in the `CorrelationId` of the request. The other service must copy it into its answer. That is how an answer finds its instance. There is no other way to match, so a service that cannot copy the id cannot answer a saga.

### Write the workflow
A saga is a workflow of `Cat.FluentWorkflows` with a `SendAndWait` step. Give the step a name that never changes, because the saved position points at it:

```csharp
public class PlaceOrderWorkflow : ICatWorkflow<PlaceOrderState>
{
    public void Build(ICatWorkflowBuilder<PlaceOrderState> builder)
    {
        builder.Run(state => state.Status = "Pending");

        builder.SendAndWait<PlaceOrderState, TakePayment, PaymentTaken>("payment")
            .Input(state => state.OrderId, step => step.Request.OrderId)
            .Input(state => state.Total, step => step.Request.Amount)
            .Output(step => step.Answer, state => state.Payment);

        builder.Run(state => state.Status = "Confirmed");
    }
}
```

`Input` fills the request before it goes out. `Output` copies the answer into the state after the workflow resumes. The steps after the wait step run when the answer is there.

### Register the module
Register the fluent workflows module and the messaging module first. Then register the sagas module, a store, every saga and every answer message:

```csharp
using Cat.Sagas.Extensions;

services.AddCatSagasModule();
services.AddCatSagasInMemoryStore();
services.AddCatSaga<PlaceOrderWorkflow, PlaceOrderState>();
services.AddCatSagaAnswer<PaymentTaken>();
```

`AddCatSagaAnswer` registers the handler that gives the answer to its saga. Declare the same message type with `Receive` on the event processor, as the [Cat.EventProcessor](../Cat.EventProcessor/README.md) readme describes.

### Keep the instances in your database
The in-memory store loses every instance when the process stops. For a real service add the `Cat.Sagas.EFCore` package. Map the table in the context of the service, then register the store. It replaces the store in memory:

```csharp
using Cat.Sagas.EFCore;
using Cat.Sagas.EFCore.Extensions;

public class OrdersDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddCatSagas();
    }
}

services.AddCatSagasEFCore<OrdersDbContext>();
```

Add a migration afterwards, so the table `CatSagas` exists. The table has one row per instance. The state and the position are JSON text, and `Version` is the concurrency token.

Things to know:
- **The store saves at once.** `AddAsync` and `UpdateAsync` call `SaveChangesAsync` on the context of the scope. Other pending changes of that context are saved in the same call.
- **Two answers at the same moment cannot both win.** The update checks the version it loaded. The loser gets a `CatSagaConcurrencyException`, and the event processor abandons its message. The next delivery sees the new state.
- **The context is scoped.** The store lives in the scope of the message, so the runner and the dispatcher must run in a scope too, as they do in the event processor.

### Start a saga
Ask for an `ICatSagaRunner` and start the workflow with its state:

```csharp
var result = await runner.StartAsync<PlaceOrderWorkflow, PlaceOrderState>(new PlaceOrderState { OrderId = orderId, Total = 120m });
```

The result holds the instance id and the status: `Waiting`, `Completed` or `Failed`. Pass a correlation id as the second argument when you already have the id you want to use. Only an instance that waits is saved. A workflow that never reaches a wait step just runs and returns.

### What happens at the wait step
The step does not send the request at once. It hands the request to the saga, and the workflow stops. The saga then does this, in this order:

1. It saves the state, the position and the list of open waits.
2. It sends the request through `ICatMessageSender`.

An answer can therefore never arrive before its instance exists. If the process stops between the two, the instance waits and the request is lost. The outbox of `Cat.Messaging` closes that gap, see [Use the outbox](#use-the-outbox).

### Use the outbox
With the outbox of [Cat.Messaging](../Cat.Messaging/README.md) on, `ICatMessageSender` does not send. It adds a row to the context, and the next `SaveChanges` saves it. The order above would then add the request row after the instance is saved, and nothing would save it. Tell the saga about the outbox, next to the outbox registration:

```csharp
services.AddCatMessagingOutboxEfCore<OrdersDbContext>();
services.AddCatMessagingOutbox();
services.AddCatSagasModule();
services.AddCatSagasEFCore<OrdersDbContext>();
services.AddCatSagasOutbox();
```

The engine then hands the request to the sender first and saves once. The instance and the request row commit in the same `SaveChanges`, so a crash loses neither or both. When the save fails, for example on a version conflict, no request row is saved either.

Call `AddCatSagasOutbox` only when the outbox is on, and use the EF Core store on the same context. Without the outbox the request would leave before the instance is saved, and a fast answer could find no instance.

### Answer from another service
The other service receives the request, does its work and sends the answer with the same correlation id. In your service, the event processor receives the answer and hands it to the handler of `AddCatSagaAnswer`. The handler gives it to the dispatcher, which does this:

- It loads the instance by the correlation id and checks that it waits.
- It loads the state and the position, resumes the workflow at the wait step with the answer, and saves the result.
- It answers with a response, and the event processor settles the message from it.

| Situation | The response | What the event processor does |
|---|---|---|
| The answer was used | Succeeded | Completes the message. |
| The instance is not waiting any more, for example a repeated answer | Succeeded, nothing changes | Completes the message. |
| There is no instance with that id | `NotFound` (`CAT-SAG-1001`) | Dead letters the message. |
| The answer does not fit the step, or the workflow changed | `Conflict` (`CAT-SAG-1003`) | Dead letters the message. |
| The saga is not registered in this service | `InternalServerError` (`CAT-SAG-1002`) | Abandons the message, so the bus delivers it again after a fix. |
| Another message changed the instance at the same moment | `CatSagaConcurrencyException` is thrown | Abandons the message. The next try sees the new state. |

### Skip a repeated answer
The bus delivers a message at least once, so the same answer can arrive twice. A repeat is harmless when the instance is no longer waiting, because the dispatcher ignores it. It is not harmless when the instance waits at a later step for the same answer type. Use the inbox of [Cat.EventProcessor](../Cat.EventProcessor/README.md) for that.

Switch the inbox on for the answer message types, and map its table in the same context as the saga table:

```csharp
builder.Services.AddCatEventProcessor(builder.Configuration, processor => processor
    .Receive<PaymentTaken>(options => options.UseInbox = true));
builder.Services.AddCatEventProcessorInbox<OrdersDbContext>();
```

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.AddCatSagas();
    modelBuilder.AddCatInbox();
}
```

The receiver checks the inbox before the handler and adds the id of the message to the context. The store of the saga then saves that row in the same `SaveChanges` as the instance update. A repeated delivery of the same message id is skipped, and a failed update leaves no inbox row, so the bus delivers the message again. The saga module needs no code for this.

The inbox skips a repeated delivery of the same `MessageId`. It does not catch a second answer that the other service sends with a new id.

### Wait for more than one kind of answer
A wait step waits for one answer type. For several outcomes, such as `PaymentTaken` and `PaymentDeclined`, give the answers a common base class or interface and wait for that:

```csharp
public abstract class PaymentAnswer : CatEventMessage, ICatServiceRequest
{
    public Guid OrderId { get; set; }
}

public class PaymentTaken : PaymentAnswer { }
public class PaymentDeclined : PaymentAnswer { }

builder.SendAndWait<PlaceOrderState, TakePayment, PaymentAnswer>("payment")
    .Output(step => step.Answer is PaymentDeclined, state => state.Declined);
builder.If(state => state.Declined,
    then => then.Run(state => state.Status = "Cancelled"),
    otherwise => otherwise.Run(state => state.Status = "Confirmed"));
```

Register every derived type with `AddCatSagaAnswer`. The state keeps simple values, such as the `Declined` flag. The JSON of a base class property would lose the derived type.

### Time out a wait
A wait can have a limit. Pass a `timeout` to `SendAndWait`. The step then has a `TimedOut` flag next to `Answer`. On a timeout `Answer` is null and `TimedOut` is true. Copy the flag with `Output` and branch with `If`, so the workflow can compensate:

```csharp
builder.SendAndWait<PlaceOrderState, TakePayment, PaymentTaken>("payment", TimeSpan.FromHours(24))
    .Output(step => step.Answer, state => state.Payment)
    .Output(step => step.TimedOut, state => state.PaymentTimedOut);
builder.If(state => state.PaymentTimedOut,
    then => then.Run(state => state.Status = "Cancelled"),
    otherwise => otherwise.Run(state => state.Status = "Confirmed"));
```

The timeout is a message of the module, `CatSagaTimeout`. The saga sends it to the own queue of the service with a scheduled time, in the same step that sends the request. The module registers the handler. You declare the message on the event processor, next to the answers:

```csharp
builder.Services.AddCatEventProcessor(builder.Configuration, processor => processor
    .Receive<PaymentTaken>()
    .Receive<CatSagaTimeout>());
```

Things to know:
- **The bus cannot cancel a scheduled message.** An answer that arrives in time leaves the timeout on the bus. The dispatcher finds no open wait for it and ignores it.
- **The instance keeps a list of open waits.** The `Waits` column holds one entry per open wait, with the step name, a wait id, the answer type and the time limit. A timeout carries the wait id, and it only fires that wait. A late timeout of an earlier step never fires the wait that follows.
- **Waits can run side by side.** In a `Parallel` step every waiting branch has its own entry. An answer finds its wait by the answer type, so a second wait for the same answer type in the same moment is a `Conflict`.
- **With the outbox on, the timeout message is saved with the instance.** It goes into the outbox in the same `SaveChanges` as the request.

### Rules to follow
- **The state must be serializable.** The default serializer is `System.Text.Json` with the web defaults. Keep services, delegates and interfaces out of the state. Replace `ICatSagaSerializer` to use another format.
- **`Build` must give the same steps every time.** The workflow is built again on every resume, and the saved position points into those steps.
- **Name every step that waits, and keep the names unique.** The name is how the instance finds its wait, so two wait steps in one workflow must not share a name. A name does not change when you add a step before it. Never remove or reorder a step while instances wait. Raise the version of the workflow when you must, see `ICatVersionedWorkflow` in the [Cat.FluentWorkflows](../Cat.FluentWorkflows/README.md) readme. A resume with another version fails with a `Conflict`.
- **Steps before a wait step may run twice.** When two answers race, the loser has already run its steps when the store refuses its update. Write them so that a second run does no harm.
- **Write the other side to copy the correlation id.** Without it the answer finds no instance.

### Test a saga
Use `CatInMemorySagaStore` and a fake message sender, such as `FakeMessageSender` of [Cat.UnitTesting](../Cat.UnitTesting/README.md). Start the saga, read the request from the sender, then call `ICatSagaDispatcher.ResumeAsync` with an answer that carries the same correlation id. Read the instance from the store to see the status and the state.

<!-- region end: Usage-->
