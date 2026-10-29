<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests\.Decorators\.Logging](index.md 'index') > [Cat\.ServiceRequests\.Decorators\.Logging\.Extensions](Cat.ServiceRequests.Decorators.Logging.Extensions.md 'Cat\.ServiceRequests\.Decorators\.Logging\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.ServiceRequests\.Decorators\.Logging\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatServiceRequestsModuleLoggingDecorator\(this IServiceProvider\) Method

Adds the logging decorator to all service request handlers\.

```csharp
public static void AddCatServiceRequestsModuleLoggingDecorator(this System.IServiceProvider serviceProvider);
```
#### Parameters

<a name='Cat.ServiceRequests.Decorators.Logging.Extensions.ServiceCollectionExtensions.AddCatServiceRequestsModuleLoggingDecorator(thisSystem.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Must be able to resolve [ICatDecoratorFactoryBuilder](..\Cat.Decorators.Abstractions\ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')\.