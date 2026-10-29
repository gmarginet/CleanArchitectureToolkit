<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Logging](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Logging](Cat.ServiceRequests.Decorators.Logging.md 'Cat\.ServiceRequests\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator')

## LoggingDecorator\.CatServiceRequestHandler\<TRequest\> Class

Logs a handler that returns no payload\.

```csharp
internal sealed class LoggingDecorator.CatServiceRequestHandler<TRequest> : Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest>
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest
```
#### Type parameters

<a name='Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest_.TRequest'></a>

`TRequest`

The service request being handled\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatServiceRequestHandler\<TRequest\>

Implements [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')[TRequest](LoggingDecorator.CatServiceRequestHandler_TRequest_.md#Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest_.TRequest 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>\.TRequest')[&gt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')

| Constructors | |
| :--- | :--- |
| [CatServiceRequestHandler\(ICatServiceRequestHandler&lt;TRequest&gt;, ILogger&lt;CatServiceRequestHandler&lt;TRequest&gt;&gt;\)](LoggingDecorator.CatServiceRequestHandler_TRequest_..ctor.2EYVQCFK6DVUIXTY625U99MY.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>\.CatServiceRequestHandler\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest\>, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>\>\)') | Creates the decorator\. |

| Fields | |
| :--- | :--- |
| [\_innerHandler](LoggingDecorator.CatServiceRequestHandler_TRequest_._innerHandler.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>\.\_innerHandler') | |
| [\_logger](LoggingDecorator.CatServiceRequestHandler_TRequest_._logger.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>\.\_logger') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TRequest, CancellationToken\)](LoggingDecorator.CatServiceRequestHandler_TRequest_.HandleAsync.OD6PUD6ISBYLFSO0DPPVN4PI2.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>\.HandleAsync\(TRequest, System\.Threading\.CancellationToken\)') | Runs the service request\. |
