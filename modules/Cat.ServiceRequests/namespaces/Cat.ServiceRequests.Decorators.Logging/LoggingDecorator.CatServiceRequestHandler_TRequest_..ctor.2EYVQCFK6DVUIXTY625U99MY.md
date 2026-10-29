<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Logging](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Logging](Cat.ServiceRequests.Decorators.Logging.md 'Cat\.ServiceRequests\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator') > [CatServiceRequestHandler&lt;TRequest&gt;](LoggingDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>')

## CatServiceRequestHandler\(ICatServiceRequestHandler\<TRequest\>, ILogger\<CatServiceRequestHandler\<TRequest\>\>\) Constructor

Creates the decorator\.

```csharp
public CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest> innerHandler, Microsoft.Extensions.Logging.ILogger<Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler<TRequest>> logger);
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest_.CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest_,Microsoft.Extensions.Logging.ILogger_Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest__).innerHandler'></a>

`innerHandler` [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')[TRequest](LoggingDecorator.CatServiceRequestHandler_TRequest_.md#Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest_.TRequest 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>\.TRequest')[&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')

The handler to wrap\.

<a name='Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest_.CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest_,Microsoft.Extensions.Logging.ILogger_Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler&lt;](LoggingDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>')[TRequest](LoggingDecorator.CatServiceRequestHandler_TRequest_.md#Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest_.TRequest 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>\.TRequest')[&gt;](LoggingDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

Receives the log entries\.