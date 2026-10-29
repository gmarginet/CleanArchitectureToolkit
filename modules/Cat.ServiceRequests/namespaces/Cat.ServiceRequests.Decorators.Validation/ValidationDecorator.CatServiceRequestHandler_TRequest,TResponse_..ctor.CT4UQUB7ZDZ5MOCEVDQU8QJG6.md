<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Validation](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Validation](Cat.ServiceRequests.Decorators.Validation.md 'Cat\.ServiceRequests\.Decorators\.Validation') > [ValidationDecorator](ValidationDecorator.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator') > [CatServiceRequestHandler&lt;TRequest,TResponse&gt;](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>')

## CatServiceRequestHandler\(ICatServiceRequestHandler\<TRequest,TResponse\>, ICatValidatorProcessor, bool\) Constructor

Creates the decorator\.

```csharp
public CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest,TResponse> innerHandler, Cat.Validators.Abstractions.ICatValidatorProcessor catValidatorProcessor, bool validationRequired);
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest,TResponse_,Cat.Validators.Abstractions.ICatValidatorProcessor,bool).innerHandler'></a>

`innerHandler` [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TRequest](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TRequest')[,](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TResponse](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TResponse')[&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')

The handler to wrap\.

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest,TResponse_,Cat.Validators.Abstractions.ICatValidatorProcessor,bool).catValidatorProcessor'></a>

`catValidatorProcessor` [ICatValidatorProcessor](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')

Runs the validators for the request\.

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest,TResponse_,Cat.Validators.Abstractions.ICatValidatorProcessor,bool).validationRequired'></a>

`validationRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When `true`, a request without a validator counts as a failure\.