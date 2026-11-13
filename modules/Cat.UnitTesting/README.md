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

# Cat.UnitTesting <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.UnitTesting gives you test doubles for the unit tests of your core service. The core service has no technology in it, so its tests need no database. They replace the processors with fakes that record what they got and answer what the test says.

The module is a toolbox of small projects, one per CAT module. You reference only the fakes of the modules you use, so a test project does not pull in fakes for things it never tests.

A fake is dumb on purpose. It returns what the test sets up. It fills no ids and sets no timestamps.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Fake the command processor](#fake-the-command-processor)
  - [Fake the query processor](#fake-the-query-processor)
  - [Fake the service request processor](#fake-the-service-request-processor)
  - [Record events](#record-events)
  - [Fake the message sender](#fake-the-message-sender)
  - [Assert on a response](#assert-on-a-response)
  - [A user for the test](#a-user-for-the-test)
  - [Reset between tests](#reset-between-tests)
  - [A base class with a service provider](#a-base-class-with-a-service-provider)
  - [Check which decorators a module adds](#check-which-decorators-a-module-adds)
  - [The clock](#the-clock)
  - [What the module leaves out](#what-the-module-leaves-out)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.UnitTesting.Commands)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.UnitTesting.Commands](https://www.nuget.org/packages/gmarginet.Cat.UnitTesting.Commands/) | Fake command processor | `dotnet add package gmarginet.Cat.UnitTesting.Commands` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.UnitTesting.Commands)](#nuget-packages) |
| [Cat.UnitTesting.EventAggregators](https://www.nuget.org/packages/gmarginet.Cat.UnitTesting.EventAggregators/) | Recording subscriber and fake event aggregator | `dotnet add package gmarginet.Cat.UnitTesting.EventAggregators` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.UnitTesting.EventAggregators)](#nuget-packages) |
| [Cat.UnitTesting.Messaging](https://www.nuget.org/packages/gmarginet.Cat.UnitTesting.Messaging/) | Fake message sender | `dotnet add package gmarginet.Cat.UnitTesting.Messaging` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.UnitTesting.Messaging)](#nuget-packages) |
| [Cat.UnitTesting.NUnit](https://www.nuget.org/packages/gmarginet.Cat.UnitTesting.NUnit/) | NUnit base class and decorator recorder | `dotnet add package gmarginet.Cat.UnitTesting.NUnit` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.UnitTesting.NUnit)](#nuget-packages) |
| [Cat.UnitTesting.Queries](https://www.nuget.org/packages/gmarginet.Cat.UnitTesting.Queries/) | Fake query processor | `dotnet add package gmarginet.Cat.UnitTesting.Queries` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.UnitTesting.Queries)](#nuget-packages) |
| [Cat.UnitTesting.Responses.NUnit](https://www.nuget.org/packages/gmarginet.Cat.UnitTesting.Responses.NUnit/) | NUnit constraints for responses | `dotnet add package gmarginet.Cat.UnitTesting.Responses.NUnit` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.UnitTesting.Responses.NUnit)](#nuget-packages) |
| [Cat.UnitTesting.ServiceRequests](https://www.nuget.org/packages/gmarginet.Cat.UnitTesting.ServiceRequests/) | Fake service request processor | `dotnet add package gmarginet.Cat.UnitTesting.ServiceRequests` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.UnitTesting.ServiceRequests)](#nuget-packages) |
| [Cat.UnitTesting.Users](https://www.nuget.org/packages/gmarginet.Cat.UnitTesting.Users/) | Fake user and user accessor | `dotnet add package gmarginet.Cat.UnitTesting.Users` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.UnitTesting.Users)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.UnitTesting.Commands](namespaces/Cat.UnitTesting.Commands/index.md) | A command processor for unit tests. It records the commands and returns the responses that the test sets up. |
| [Cat.UnitTesting.EventAggregators](namespaces/Cat.UnitTesting.EventAggregators/index.md) | Test doubles for the event aggregator: a subscriber that records the events it gets, and an aggregator that records what is published. |
| [Cat.UnitTesting.Messaging](namespaces/Cat.UnitTesting.Messaging/index.md) | A message sender for unit tests. It records the messages that were published or sent, and when they were scheduled. |
| [Cat.UnitTesting.NUnit](namespaces/Cat.UnitTesting.NUnit/index.md) | Helpers for NUnit tests: a base class that builds a service provider, and a recorder for decorator calls. |
| [Cat.UnitTesting.Queries](namespaces/Cat.UnitTesting.Queries/index.md) | A query processor for unit tests. It records the queries and returns the responses that the test sets up. |
| [Cat.UnitTesting.Responses.NUnit](namespaces/Cat.UnitTesting.Responses.NUnit/index.md) | NUnit constraints for responses, such as succeeded, failed, the response type and an error code. |
| [Cat.UnitTesting.ServiceRequests](namespaces/Cat.UnitTesting.ServiceRequests/index.md) | A service request processor for unit tests. It records the service requests and returns the responses that the test sets up. |
| [Cat.UnitTesting.Users](namespaces/Cat.UnitTesting.Users/index.md) | A user and a user accessor for unit tests. The test sets the id, the name, the login state and the roles. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.UnitTesting needs it |
|--------|------------------------------|
| [Cat.Commands](../Cat.Commands/README.md) | `Cat.UnitTesting.Commands` fakes `ICatCommandProcessor`. It references the abstractions only. |
| [Cat.Decorators](../Cat.Decorators/README.md) | `Cat.UnitTesting.NUnit` records the decorators that a module adds. It references the abstractions only. |
| [Cat.EventAggregators](../Cat.EventAggregators/README.md) | `Cat.UnitTesting.EventAggregators` fakes `ICatEventAggregator` and implements `ICatHandleEvent<T>`. It references the abstractions only. |
| [Cat.Messaging](../Cat.Messaging/README.md) | `Cat.UnitTesting.Messaging` fakes `ICatMessageSender`. It references the abstractions only. |
| [Cat.Users](../Cat.Users/README.md) | `Cat.UnitTesting.Users` implements `ICatUser` and `ICatUserAccessor`. It references the abstractions only. |
| [Cat.ServiceRequests](../Cat.ServiceRequests/README.md) | `Cat.UnitTesting.ServiceRequests` fakes `ICatServiceRequestProcessor`. It references the abstractions only. |
| [Cat.Queries](../Cat.Queries/README.md) | `Cat.UnitTesting.Queries` fakes `ICatQueryProcessor`. It references the abstractions only. |
| [Cat.Responses](../Cat.Responses/README.md) | The fakes answer with `ICatResponse`, and the command fake starts with `CatResponse.Ok()`. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Fake the command processor

Give the class under test a `FakeCommandProcessor` instead of the real `ICatCommandProcessor`. It records every command in `Commands`, in order, and `Of<T>()` gives the ones of one type.

A command without a result gets `DefaultResponse`, which starts as `CatResponse.Ok()`. Change it, or set a response per command type with `Respond`:

```csharp
using Cat.UnitTesting.Commands;

var commands = new FakeCommandProcessor()
    .Respond<TodoDeleteCommand>(CatResponse.NotFound());

var service = new TodoService(commands);
await service.DeleteAsync(7);

Assert.That(commands.Of<TodoDeleteCommand>().Single().TodoId, Is.EqualTo(7));
```

`Respond` also takes a function. The function gets the command, so the response can depend on it. It can change the command too, as a real handler would, for instance to set an id:

```csharp
commands.Respond<CustomerCreateOrUpdateCommand>(command =>
{
    command.CustomerId = customerId;
    return CatResponse.Ok();
});
```

A command with a result has no default, because a fake cannot guess the data. Set it up with both type arguments. A command without a set up response throws a `NotSupportedException` that names the command. The command is still recorded.

```csharp
commands.Respond<TodoCreateCommand, int>(CatResponse.Ok(42));
commands.Respond<TodoCreateCommand, int>(command => CatResponse.Ok(command.Title.Length));
```

### Fake the query processor

`FakeQueryProcessor` works the same way, with two differences. Every query has a result, so `Respond` always takes both type arguments. And there is no default response, so a query without a set up response throws.

```csharp
using Cat.UnitTesting.Queries;

var queries = new FakeQueryProcessor()
    .Respond<TodoGetQuery, Todo>(CatResponse.Ok(todo))
    .Respond<TodoGetListQuery, IList<Todo>>(CatResponse.NotFound<IList<Todo>>());
```

### Fake the service request processor

`FakeServiceRequestProcessor` of `Cat.UnitTesting.ServiceRequests` works like the command fake. It records the requests in `Requests`, `Of<T>()` gives the ones of one type, a request without a result gets `DefaultResponse`, and a request with a result needs a set up response.

```csharp
using Cat.UnitTesting.ServiceRequests;

var requests = new FakeServiceRequestProcessor()
    .Respond<CleanUpRequest>(CatResponse.InternalServerError())
    .Respond<OrderGetRequest, Order>(request => CatResponse.Ok(order));
```

### Record events

`RecordingSubscriber<TEvent>` of `Cat.UnitTesting.EventAggregators` collects the events it gets in `Events`. Subscribe it to the aggregator of the test. The type can be an interface or a base type, to collect several event types. Keep a reference to the subscriber, because the aggregator holds a subscriber weakly.

```csharp
using Cat.UnitTesting.EventAggregators;

var events = new RecordingSubscriber<IOrderEvent>();
aggregator.Subscribe(events);

await service.PlaceAsync(order);

Assert.That(events.Events.Single(), Is.TypeOf<OrderConfirmedEvent>());
```

To test code that only publishes, give it a `FakeEventAggregator`. It records `Published` and `Subscribers`, `Of<T>()` gives the events of one type, and it calls no subscriber. `HasSubscribersForEvent` answers from the subscribers that the test added.

### Fake the message sender

`FakeMessageSender` of `Cat.UnitTesting.Messaging` takes the place of `ICatMessageSender`. It records every published event and every sent command in `Sent`, in order, with the time the caller asked to send it at. `Of<T>()` filters by message class, or by `ICatEventMessage` or `ICatCommandMessage`. It sends nothing.

```csharp
using Cat.UnitTesting.Messaging;

var sender = new FakeMessageSender();

await handler.HandleAsync(request);

Assert.That(sender.Of<OrderPlaced>().Single().OrderId, Is.EqualTo(orderId));
Assert.That(sender.Sent.Single().ScheduledAt, Is.Null);
```

### Assert on a response

`CatIs` of `Cat.UnitTesting.Responses.NUnit` has NUnit constraints for an `ICatResponse`, typed or not. A failure shows as a normal NUnit failure and prints the response, for example `Failed NotFound [DEM-ORD-1004]`.

```csharp
using Cat.Responses.Abstractions;
using Cat.UnitTesting.Responses.NUnit;

Assert.That(response, CatIs.Succeeded);
Assert.That(response, CatIs.SucceededWith(CatResponseType.Created));
Assert.That(response, CatIs.Failed);
Assert.That(response, CatIs.FailedWith(CatResponseType.NotFound));
Assert.That(response, CatIs.FailedWithCode("DEM-ORD-1004"));
Assert.That(response, CatIs.FailedWith(CatResponseType.NotFound, "DEM-ORD-1004"));
```

`FailedWithCode` accepts the code anywhere in the list of errors. The constraints work with `!` and `&`, like other NUnit constraints. The package targets the latest stable .NET, because NUnit 5 has no `netstandard2.0` build.

### A user for the test

`FakeUser` of `Cat.UnitTesting.Users` is an `ICatUser` that the test can change. It starts as a logged in user without roles. Set `UserId`, `Name` and `IsAuthenticated`, and give it roles with `InRole` or by changing `Roles`. When the user never changes during the test, `CatUser` of `Cat.Users.Abstractions` is enough.

```csharp
using Cat.UnitTesting.Users;

var user = new FakeUser { UserId = "alice", Name = "Alice" }.InRole("admin");

var accessor = new FakeUserAccessor { User = user };
```

`FakeUserAccessor` is an `ICatUserAccessor`. It starts with `CatUser.Anonymous`, like a request without a login. To add properties of your own application, such as an email address, derive from `FakeUser`.

### Reset between tests

`Reset()` clears the recorded commands, queries, requests, events or messages and the set up responses. The command and service request fakes also get their original default response back. A new fake per test is simpler, so use `Reset()` only when a fake lives across tests.

### A base class with a service provider

`UnitTestBase` of `Cat.UnitTesting.NUnit` suits a fixture that tests against a real service provider, such as the registration of a module. It builds the provider once per fixture from `ConfigureServices`, and disposes it after the last test. The provider is in `ServiceProvider`.

```csharp
using Cat.Queries.Abstractions;
using Cat.Queries.Extensions;
using Cat.UnitTesting.NUnit;
using Microsoft.Extensions.DependencyInjection;

[TestFixture]
public class TodoQueryTests : UnitTestBase
{
    protected override void ConfigureServices(ServiceCollection services)
    {
        services.AddCatQueriesModule(typeof(TodoGetQueryHandler));
    }

    [Test]
    public void TheProcessorIsRegistered()
    {
        using var scope = ServiceProvider.CreateScope();

        Assert.That(scope.ServiceProvider.GetService<ICatQueryProcessor>(), Is.Not.Null);
    }
}
```

The package targets the latest stable .NET. The fakes of the other projects target `netstandard2.0`.

### Check which decorators a module adds

A module that adds a decorator calls `ICatDecoratorFactoryBuilder`. `RecordingDecoratorBuilder` only records those calls, so a test can check which decorator was added and in which order. `CreateServiceProvider()` gives a provider that hands the recorder out. Call the `AddCat...Decorator` extension method of the module on it.

```csharp
using Cat.Decorators.Abstractions;
using Cat.Queries.Decorators.Logging.Extensions;
using Cat.UnitTesting.NUnit;

var builder = new RecordingDecoratorBuilder();

builder.CreateServiceProvider().AddCatQueriesModuleLoggingDecorator();

Assert.That(builder.Added.Select(added => added.Order), Is.EqualTo(new[] { CatDecoratorOrder.Logging }));
```

### The clock

The module has no clock of its own. .NET has `FakeTimeProvider` in the `Microsoft.Extensions.TimeProvider.Testing` package. Use that one, and give it to the class under test as a `TimeProvider`. A test that waits on a delay starts the call, checks that it still waits, moves the clock with `Advance`, and then awaits the result.

### What the module leaves out

- **No database.** The unit tests of a core service never need one. The fakes replace the processors, so the tests run without a database.
- **No integration tests.** If CAT gets integration testing, it will be a separate module.
- **No fake workflow or validator processors.** Run the real ones through a service provider, as `UnitTestBase` builds it.
- **No fake of the guesses.** A fake returns what the test says. It fills no ids and sets no timestamps. A test that needs those sets them up with `Respond`.
- **Other test frameworks.** The fakes in `Cat.UnitTesting.Commands`, `Queries`, `ServiceRequests`, `EventAggregators`, `Messaging` and `Users` do not depend on a test framework. The NUnit parts are `Cat.UnitTesting.NUnit` and `Cat.UnitTesting.Responses.NUnit`. Another framework gets its own project.
<!-- region end: Usage-->
