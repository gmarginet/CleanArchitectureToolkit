<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.ActivitySource](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.ActivitySource](Cat.ServiceRequests.Decorators.ActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource') > [ActivitySourceDecorator](ActivitySourceDecorator.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator')

## ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\> Class

Traces a handler that returns a payload\.

```csharp
internal sealed class ActivitySourceDecorator.CatServiceRequestHandler<TRequest,TResponse> : Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest, TResponse>
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse>
```
#### Type parameters

<a name='Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest'></a>

`TRequest`

The service request being handled\.

<a name='Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse'></a>

`TResponse`

The type of the payload\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatServiceRequestHandler\<TRequest,TResponse\>

Implements [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TRequest](ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TRequest')[,](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TResponse](ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TResponse')[&gt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')

| Constructors | |
| :--- | :--- |
| [CatServiceRequestHandler\(ICatServiceRequestHandler&lt;TRequest,TResponse&gt;\)](ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_..ctor.ZH1P9TCN9D2ZVHSB8CN6QVPV4.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.CatServiceRequestHandler\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest,TResponse\>\)') | Creates the decorator\. |

| Fields | |
| :--- | :--- |
| [\_innerHandler](ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_._innerHandler.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.\_innerHandler') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TRequest, CancellationToken\)](ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.HandleAsync.E4VU8YSO8BHOVOUZZLGW56ZZE.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.HandleAsync\(TRequest, System\.Threading\.CancellationToken\)') | Runs the service request\. |
