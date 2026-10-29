<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Validation](index.md 'index')

## Cat\.ServiceRequests\.Decorators\.Validation Namespace

Adds a decorator that validates a service request before its handler runs\.
An invalid request never reaches the handler and returns the validation errors instead\.

| Classes | |
| :--- | :--- |
| [ValidationDecorator](ValidationDecorator.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator') | Wraps service request handlers with request validation\. |
| [ValidationDecorator\.CatServiceRequestHandler&lt;TRequest,TResponse&gt;](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>') | Validates requests for a handler that returns a payload\. |
| [ValidationDecorator\.CatServiceRequestHandler&lt;TRequest&gt;](ValidationDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest\>') | Validates requests for a handler that returns no payload\. |
