<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries\.Decorators\.Logging](index.md 'index') > [Cat\.Queries\.Decorators\.Logging\.Extensions](Cat.Queries.Decorators.Logging.Extensions.md 'Cat\.Queries\.Decorators\.Logging\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.Queries\.Decorators\.Logging\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatQueriesModuleLoggingDecorator\(this IServiceProvider\) Method

Adds the logging decorator to all query handlers\.

```csharp
public static void AddCatQueriesModuleLoggingDecorator(this System.IServiceProvider serviceProvider);
```
#### Parameters

<a name='Cat.Queries.Decorators.Logging.Extensions.ServiceCollectionExtensions.AddCatQueriesModuleLoggingDecorator(thisSystem.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Must be able to resolve [ICatDecoratorFactoryBuilder](..\Cat.Decorators.Abstractions\ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')\.