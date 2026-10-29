<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceRequests\.Decorators\.Validation](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Validation\.Extensions](Cat.ServiceRequests.Decorators.Validation.Extensions.md 'Cat\.ServiceRequests\.Decorators\.Validation\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.ServiceRequests\.Decorators\.Validation\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatServiceRequestsModuleValidationDecorator\(this IServiceProvider, bool\) Method

Adds the validation decorator to all service request handlers\.

```csharp
public static System.IServiceProvider AddCatServiceRequestsModuleValidationDecorator(this System.IServiceProvider serviceProvider, bool validationRequired=false);
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.Validation.Extensions.ServiceCollectionExtensions.AddCatServiceRequestsModuleValidationDecorator(thisSystem.IServiceProvider,bool).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Must be able to resolve [ICatDecoratorFactoryBuilder](..\Cat.Decorators.Abstractions\ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')\.

<a name='Cat.ServiceRequests.Decorators.Validation.Extensions.ServiceCollectionExtensions.AddCatServiceRequestsModuleValidationDecorator(thisSystem.IServiceProvider,bool).validationRequired'></a>

`validationRequired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When `true`, a request without a validator counts as a failure\.

#### Returns
[System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')  
The same service provider, so calls can be chained\.