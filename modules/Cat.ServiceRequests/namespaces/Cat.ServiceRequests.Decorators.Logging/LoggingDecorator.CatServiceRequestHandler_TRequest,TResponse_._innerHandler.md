<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Logging](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Logging](Cat.ServiceRequests.Decorators.Logging.md 'Cat\.ServiceRequests\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator') > [CatServiceRequestHandler&lt;TRequest,TResponse&gt;](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>')

## LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.\_innerHandler Field

```csharp
private readonly ICatServiceRequestHandler<TRequest,TResponse> _innerHandler;
```

#### Field Value
[Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TRequest](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TRequest')[,](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TResponse](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TResponse')[&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')