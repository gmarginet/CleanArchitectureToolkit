<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Validation](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Validation](Cat.ServiceRequests.Decorators.Validation.md 'Cat\.ServiceRequests\.Decorators\.Validation') > [ValidationDecorator](ValidationDecorator.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator')

## ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\> Class

Validates requests for a handler that returns a payload\.

```csharp
internal sealed class ValidationDecorator.CatServiceRequestHandler<TRequest,TResponse> : Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest, TResponse>
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest<TResponse>
```
#### Type parameters

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest'></a>

`TRequest`

The service request being handled\.

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse'></a>

`TResponse`

The type of the payload\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatServiceRequestHandler\<TRequest,TResponse\>

Implements [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TRequest](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.TRequest 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TRequest')[,](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')[TResponse](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.md#Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.TResponse 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.TResponse')[&gt;](..\Cat.ServiceRequests.Abstractions\ICatServiceRequestHandler_TRequest,TResponse_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`2')

| Constructors | |
| :--- | :--- |
| [CatServiceRequestHandler\(ICatServiceRequestHandler&lt;TRequest,TResponse&gt;, ICatValidatorProcessor, bool\)](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_..ctor.CT4UQUB7ZDZ5MOCEVDQU8QJG6.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.CatServiceRequestHandler\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest,TResponse\>, Cat\.Validators\.Abstractions\.ICatValidatorProcessor, bool\)') | Creates the decorator\. |

| Fields | |
| :--- | :--- |
| [\_catValidatorProcessor](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_._catValidatorProcessor.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.\_catValidatorProcessor') | |
| [\_innerHandler](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_._innerHandler.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.\_innerHandler') | |
| [\_validationRequired](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_._validationRequired.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.\_validationRequired') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TRequest, CancellationToken\)](ValidationDecorator.CatServiceRequestHandler_TRequest,TResponse_.HandleAsync.WMNIBCMB7EOBH4BZHQ0QWQHX.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest,TResponse\>\.HandleAsync\(TRequest, System\.Threading\.CancellationToken\)') | Runs the service request\. |
