<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests\.Abstractions](index.md 'index') > [Cat\.ServiceRequests\.Abstractions](Cat.ServiceRequests.Abstractions.md 'Cat\.ServiceRequests\.Abstractions')

## ICatServiceRequest\<TResponse\> Interface

Marks a service request that returns a response with a payload\.
Handle it with [ICatServiceRequestHandler&lt;TRequest,TResponse&gt;](ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest,TResponse\>')\.

```csharp
public interface ICatServiceRequest<out TResponse>
```
#### Type parameters

<a name='Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_.TResponse'></a>

`TResponse`

The type of the payload the handler returns\.