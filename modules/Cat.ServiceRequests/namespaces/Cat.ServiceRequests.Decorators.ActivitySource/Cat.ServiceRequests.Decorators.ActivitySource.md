<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests\.Decorators\.ActivitySource](index.md 'index')

## Cat\.ServiceRequests\.Decorators\.ActivitySource Namespace

Adds a decorator that starts a [System\.Diagnostics\.Activity](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activity 'System\.Diagnostics\.Activity') around every service request handler,
so each request shows up in your distributed traces\.

| Classes | |
| :--- | :--- |
| [ActivitySourceDecorator](ActivitySourceDecorator.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator') | Wraps service request handlers in an [System\.Diagnostics\.Activity](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activity 'System\.Diagnostics\.Activity') for tracing\. |
| [ActivitySourceDecorator\.CatServiceRequestHandler&lt;TRequest,TResponse&gt;](ActivitySourceDecorator.CatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>') | Traces a handler that returns a payload\. |
| [ActivitySourceDecorator\.CatServiceRequestHandler&lt;TRequest&gt;](ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>') | Traces a handler that returns no payload\. |
| [ActivitySourceDecorator\.ServiceRequestActivitySource](ActivitySourceDecorator.ServiceRequestActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.ServiceRequestActivitySource') | Owns the shared [System\.Diagnostics\.ActivitySource](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activitysource 'System\.Diagnostics\.ActivitySource') named "Cat\.ServiceRequests"\. |
