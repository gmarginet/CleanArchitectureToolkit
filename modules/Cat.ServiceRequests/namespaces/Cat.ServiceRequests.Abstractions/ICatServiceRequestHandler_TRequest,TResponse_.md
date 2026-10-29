<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Abstractions](index.md 'index') > [Cat\.ServiceRequests\.Abstractions](Cat.ServiceRequests.Abstractions.md 'Cat\.ServiceRequests\.Abstractions')

## ICatServiceRequestHandler\<TRequest,TResponse\> Interface

Handles one kind of service request that returns a payload\.
Implement it once per request type\. The module finds and registers it for you\.

```csharp
public interface ICatServiceRequestHandler<in TRequest,TResponse>
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse>
```
#### Type parameters

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest,TResponse_.TRequest'></a>

`TRequest`

The service request this handler can process\.

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest,TResponse_.TResponse'></a>

`TResponse`

The type of the payload the handler returns\.

| Methods | |
| :--- | :--- |
| [HandleAsync\(TRequest, CancellationToken\)](ICatServiceRequestHandler_TRequest,TResponse_.HandleAsync.TZWIOXWSUV7KFO64E34V9YC46.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest,TResponse\>\.HandleAsync\(TRequest, System\.Threading\.CancellationToken\)') | Runs the service request\. |
