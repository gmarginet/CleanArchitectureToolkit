<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests\.Decorators\.Validation](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Validation](Cat.ServiceRequests.Decorators.Validation.md 'Cat\.ServiceRequests\.Decorators\.Validation') > [ValidationDecorator](ValidationDecorator.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator') > [CatServiceRequestHandler&lt;TRequest&gt;](ValidationDecorator.CatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest\>')

## CatServiceRequestHandler\(ICatServiceRequestHandler\<TRequest\>, ICatValidatorProcessor, bool\) Constructor

Creates the decorator\.

```csharp
public CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest> innerHandler, Cat.Validators.Abstractions.ICatValidatorProcessor catValidatorProcessor, bool validationRequired);
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest_.CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest_,Cat.Validators.Abstractions.ICatValidatorProcessor,bool).innerHandler'></a>

`innerHandler` [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')[TRequest](ValidationDecorator.CatServiceRequestHandler_TRequest_.md#Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest_.TRequest 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest\>\.TRequest')[&gt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')

The handler to wrap\.

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest_.CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest_,Cat.Validators.Abstractions.ICatValidatorProcessor,bool).catValidatorProcessor'></a>

`catValidatorProcessor` [ICatValidatorProcessor](..\Cat.Validators.Abstractions\ICatValidatorProcessor.md 'Cat\.Validators\.Abstractions\.ICatValidatorProcessor')

Runs the validators for the request\.

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest_.CatServiceRequestHandler(Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler_TRequest_,Cat.Validators.Abstractions.ICatValidatorProcessor,bool).validationRequired'></a>

`validationRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When `true`, a request without a validator counts as a failure\.