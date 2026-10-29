<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests\.Abstractions](index.md 'index')

## Cat\.ServiceRequests\.Abstractions Namespace

Defines the contracts for service requests: the request markers, the handlers that run them,
and the processor that finds the right handler and returns an [ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')\.

| Interfaces | |
| :--- | :--- |
| [ICatServiceRequest](ICatServiceRequest.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest') | Marks a service request that returns a response without a payload\. Handle it with [ICatServiceRequestHandler&lt;TRequest&gt;](ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest\>')\. |
| [ICatServiceRequest&lt;TResponse&gt;](ICatServiceRequest_TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\<TResponse\>') | Marks a service request that returns a response with a payload\. Handle it with [ICatServiceRequestHandler&lt;TRequest,TResponse&gt;](ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest,TResponse\>')\. |
| [ICatServiceRequestHandler&lt;TRequest,TResponse&gt;](ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest,TResponse\>') | Handles one kind of service request that returns a payload\. Implement it once per request type\. The module finds and registers it for you\. |
| [ICatServiceRequestHandler&lt;TRequest&gt;](ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest\>') | Handles one kind of service request that returns no payload\. Implement it once per request type\. The module finds and registers it for you\. |
| [ICatServiceRequestProcessor](ICatServiceRequestProcessor.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestProcessor') | Single entry point for running service requests\. It finds the handler for a request, runs it through the registered decorators and returns the response\. |
