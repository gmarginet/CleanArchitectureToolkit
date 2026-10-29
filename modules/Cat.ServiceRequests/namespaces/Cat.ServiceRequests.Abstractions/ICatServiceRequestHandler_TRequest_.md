<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Abstractions](index.md 'index') > [Cat\.ServiceRequests\.Abstractions](Cat.ServiceRequests.Abstractions.md 'Cat\.ServiceRequests\.Abstractions')

## ICatServiceRequestHandler\<TRequest\> Interface

Handles one kind of service request that returns no payload\.
Implement it once per request type\. The module finds and registers it for you\.

```csharp
public interface ICatServiceRequestHandler<in TRequest>
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest
```
#### Type parameters

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest_.TRequest'></a>

`TRequest`

The service request this handler can process\.

| Methods | |
| :--- | :--- |
| [HandleAsync\(TRequest, CancellationToken\)](ICatServiceRequestHandler_TRequest_.HandleAsync.UKV07R1O984838HBFKEWL7KL.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest\>\.HandleAsync\(TRequest, System\.Threading\.CancellationToken\)') | Runs the service request\. |
