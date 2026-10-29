<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.ActivitySource](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.ActivitySource\.Extensions](Cat.ServiceRequests.Decorators.ActivitySource.Extensions.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.ServiceRequests\.Decorators\.ActivitySource\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatServiceRequestsModuleActivitySourceDecorator\(this IServiceProvider\) Method

Adds the activity source decorator to all service request handlers\.

```csharp
public static void AddCatServiceRequestsModuleActivitySourceDecorator(this System.IServiceProvider serviceProvider);
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.ActivitySource.Extensions.ServiceCollectionExtensions.AddCatServiceRequestsModuleActivitySourceDecorator(thisSystem.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Must be able to resolve [ICatDecoratorFactoryBuilder](../Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')\.