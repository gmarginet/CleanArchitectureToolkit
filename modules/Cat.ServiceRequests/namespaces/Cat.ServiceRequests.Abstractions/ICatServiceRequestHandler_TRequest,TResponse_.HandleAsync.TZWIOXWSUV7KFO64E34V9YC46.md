<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests\.Abstractions](index.md 'index') > [Cat\.ServiceRequests\.Abstractions](Cat.ServiceRequests.Abstractions.md 'Cat\.ServiceRequests\.Abstractions') > [ICatServiceRequestHandler&lt;TRequest,TResponse&gt;](ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest,TResponse\>')

## ICatServiceRequestHandler\<TRequest,TResponse\>\.HandleAsync\(TRequest, CancellationToken\) Method

Runs the service request\.

```csharp
System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TResponse>> HandleAsync(TRequest serviceRequest, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest,TResponse_.HandleAsync(TRequest,System.Threading.CancellationToken).serviceRequest'></a>

`serviceRequest` [TRequest](ICatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest,TResponse_.TRequest 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest,TResponse\>\.TRequest')

The request to handle\.

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest,TResponse_.HandleAsync(TRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResponse](ICatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest,TResponse_.TResponse 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest,TResponse\>\.TResponse')[&gt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response with the payload when it succeeded, or the errors when it failed\.