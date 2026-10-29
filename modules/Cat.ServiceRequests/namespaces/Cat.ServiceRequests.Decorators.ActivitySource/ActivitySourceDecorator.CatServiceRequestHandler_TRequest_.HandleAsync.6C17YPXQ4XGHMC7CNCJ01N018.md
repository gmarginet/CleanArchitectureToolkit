<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests\.Decorators\.ActivitySource](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.ActivitySource](Cat.ServiceRequests.Decorators.ActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource') > [ActivitySourceDecorator](ActivitySourceDecorator.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator') > [CatServiceRequestHandler&lt;TRequest&gt;](ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>')

## ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>\.HandleAsync\(TRequest, CancellationToken\) Method

Runs the service request\.

```csharp
public System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> HandleAsync(TRequest serviceRequest, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.HandleAsync(TRequest,System.Threading.CancellationToken).serviceRequest'></a>

`serviceRequest` [TRequest](ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.md#Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.TRequest 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>\.TRequest')

The request to handle\.

<a name='Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.HandleAsync(TRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [HandleAsync\(TRequest, CancellationToken\)](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest_.HandleAsync.UKV07R1O984838HBFKEWL7KL.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1\.HandleAsync\(\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response that tells whether the request succeeded, and why not if it failed\.