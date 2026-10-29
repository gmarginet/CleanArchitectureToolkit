<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Logging](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Logging](Cat.ServiceRequests.Decorators.Logging.md 'Cat\.ServiceRequests\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator')

## LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\> Class

Logs a handler that returns a payload\.

```csharp
internal sealed class LoggingDecorator.CatServiceRequestHandler<TRequest,TResponse> : Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest, TResponse>
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse>
```
#### Type parameters

<a name='Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest'></a>

`TRequest`

The service request being handled\.

<a name='Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse'></a>

`TResponse`

The type of the payload\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatServiceRequestHandler\<TRequest,TResponse\>

Implements [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TRequest](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TRequest')[,](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TResponse](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TResponse')[&gt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')

| Constructors | |
| :--- | :--- |
| [CatServiceRequestHandler\(ICatServiceRequestHandler&lt;TRequest,TResponse&gt;, ILogger&lt;CatServiceRequestHandler&lt;TRequest,TResponse&gt;&gt;\)](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_..ctor.3LY7CPRK64VZ0IO512T6UY9Z2.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.CatServiceRequestHandler\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest,TResponse\>, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\>\)') | Creates the decorator\. |

| Fields | |
| :--- | :--- |
| [\_innerHandler](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_._innerHandler.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.\_innerHandler') | |
| [\_logger](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_._logger.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.\_logger') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TRequest, CancellationToken\)](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.HandleAsync.7HZM5WMP6QAYC4TKY9GHHVSS1.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.HandleAsync\(TRequest, System\.Threading\.CancellationToken\)') | Runs the service request\. |
