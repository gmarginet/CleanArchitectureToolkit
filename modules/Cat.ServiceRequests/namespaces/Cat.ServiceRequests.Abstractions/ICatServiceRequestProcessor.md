<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Abstractions](index.md 'index') > [Cat\.ServiceRequests\.Abstractions](Cat.ServiceRequests.Abstractions.md 'Cat\.ServiceRequests\.Abstractions')

## ICatServiceRequestProcessor Interface

Single entry point for running service requests\.
It finds the handler for a request, runs it through the registered decorators and returns the response\.

```csharp
public interface ICatServiceRequestProcessor
```

| Methods | |
| :--- | :--- |
| [Process\(ICatServiceRequest\)](ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process(Cat.ServiceRequests.Abstractions.ICatServiceRequest) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\)') | Runs a service request that returns no payload and blocks until it finishes\. Prefer [ProcessAsync\(ICatServiceRequest, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest, System\.Threading\.CancellationToken\)') when you can\. |
| [Process&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;\)](ICatServiceRequestProcessor.Process.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.Process_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.Process\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>\)') | Runs a service request that returns a payload and blocks until it finishes\. Prefer [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>, System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync\(ICatServiceRequest, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync(Cat.ServiceRequests.Abstractions.ICatServiceRequest,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest, System\.Threading\.CancellationToken\)') | Runs a service request that returns no payload\. |
| [ProcessAsync&lt;TResponse&gt;\(ICatServiceRequest&lt;TResponse&gt;, CancellationToken\)](ICatServiceRequestProcessor.ProcessAsync.md#Cat.ServiceRequests.Abstractions.ICatServiceRequestProcessor.ProcessAsync_TResponse_(Cat.ServiceRequests.Abstractions.ICatServiceRequest_TResponse_,System.Threading.CancellationToken) 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor\.ProcessAsync\<TResponse\>\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>, System\.Threading\.CancellationToken\)') | Runs a service request that returns a payload\. |
