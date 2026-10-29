<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Logging](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Logging](Cat.ServiceRequests.Decorators.Logging.md 'Cat\.ServiceRequests\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator') > [CatServiceRequestHandler&lt;TRequest,TResponse&gt;](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>')

## LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.HandleAsync\(TRequest, CancellationToken\) Method

Runs the service request\.

```csharp
public System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TResponse>> HandleAsync(TRequest serviceRequest, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.HandleAsync(TRequest,System.Threading.CancellationToken).serviceRequest'></a>

`serviceRequest` [TRequest](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TRequest')

The request to handle\.

<a name='Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.HandleAsync(TRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [HandleAsync\(TRequest, CancellationToken\)](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.HandleAsync.TZWIOXWSUV7KFO64E34V9YC46.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2\.HandleAsync\(\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Logging.LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TResponse')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response with the payload when it succeeded, or the errors when it failed\.