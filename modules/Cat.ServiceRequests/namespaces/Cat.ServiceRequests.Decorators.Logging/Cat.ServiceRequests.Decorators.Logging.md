<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Logging](index.md 'index')

## Cat\.ServiceRequests\.Decorators\.Logging Namespace

Adds a decorator that logs the start and end of every service request handler,
including the errors of a failed response\.

| Classes | |
| :--- | :--- |
| [LoggingDecorator](LoggingDecorator.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator') | Wraps service request handlers with debug logging and error logging\. |
| [LoggingDecorator\.CatServiceRequestHandler&lt;TRequest,TResponse&gt;](LoggingDecorator.CatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>') | Logs a handler that returns a payload\. |
| [LoggingDecorator\.CatServiceRequestHandler&lt;TRequest&gt;](LoggingDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.Logging\.LoggingDecorator\.CatServiceRequestHandler\<TRequest\>') | Logs a handler that returns no payload\. |
