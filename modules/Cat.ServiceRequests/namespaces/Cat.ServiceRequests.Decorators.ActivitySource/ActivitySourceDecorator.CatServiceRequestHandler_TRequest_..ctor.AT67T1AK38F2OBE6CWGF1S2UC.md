<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests\.Decorators\.ActivitySource](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.ActivitySource](Cat.ServiceRequests.Decorators.ActivitySource.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource') > [ActivitySourceDecorator](ActivitySourceDecorator.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator') > [CatServiceRequestHandler&lt;TRequest&gt;](ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>')

## CatServiceRequestHandler\(ICatServiceRequestHandler\<TRequest\>\) Constructor

Creates the decorator\.

```csharp
public CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest> innerHandler);
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest_).innerHandler'></a>

`innerHandler` [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')[TRequest](ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.md#Cat.ServiceRequests.Decorators.ActivitySource.ActivitySourceDecorator.CatServiceRequestHandler_TRequest_.TRequest 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.ActivitySourceDecorator\.CatServiceRequestHandler\<TRequest\>\.TRequest')[&gt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')

The handler to wrap\.