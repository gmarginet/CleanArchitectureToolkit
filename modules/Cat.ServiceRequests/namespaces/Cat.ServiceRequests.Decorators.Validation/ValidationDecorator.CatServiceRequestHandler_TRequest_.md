<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Validation](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Validation](Cat.ServiceRequests.Decorators.Validation.md 'Cat\.ServiceRequests\.Decorators\.Validation') > [ValidationDecorator](ValidationDecorator.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator')

## ValidationDecorator\.CatServiceRequestHandler\<TRequest\> Class

Validates requests for a handler that returns no payload\.

```csharp
internal sealed class ValidationDecorator.CatServiceRequestHandler<TRequest> : Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest>
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest
```
#### Type parameters

<a name='Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest_.TRequest'></a>

`TRequest`

The service request being handled\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatServiceRequestHandler\<TRequest\>

Implements [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')[TRequest](ValidationDecorator.CatServiceRequestHandler_TRequest_.md#Cat.ServiceRequests.Decorators.Validation.ValidationDecorator.CatServiceRequestHandler_TRequest_.TRequest 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest\>\.TRequest')[&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')

| Constructors | |
| :--- | :--- |
| [CatServiceRequestHandler\(ICatServiceRequestHandler&lt;TRequest&gt;, ICatValidatorProcessor, bool\)](ValidationDecorator.CatServiceRequestHandler_TRequest_..ctor.EWHHGW1KQ9DLR4JY3O1SWUUX5.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest\>\.CatServiceRequestHandler\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest\>, Cat\.Validators\.Abstractions\.ICatValidatorProcessor, bool\)') | Creates the decorator\. |

| Fields | |
| :--- | :--- |
| [\_catValidatorProcessor](ValidationDecorator.CatServiceRequestHandler_TRequest_._catValidatorProcessor.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest\>\.\_catValidatorProcessor') | |
| [\_innerHandler](ValidationDecorator.CatServiceRequestHandler_TRequest_._innerHandler.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest\>\.\_innerHandler') | |
| [\_validationRequired](ValidationDecorator.CatServiceRequestHandler_TRequest_._validationRequired.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest\>\.\_validationRequired') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TRequest, CancellationToken\)](ValidationDecorator.CatServiceRequestHandler_TRequest_.HandleAsync.ROZ2TUCET43PITVFOWREMMD6E.md 'Cat\.ServiceRequests\.Decorators\.Validation\.ValidationDecorator\.CatServiceRequestHandler\<TRequest\>\.HandleAsync\(TRequest, System\.Threading\.CancellationToken\)') | Runs the service request\. |
