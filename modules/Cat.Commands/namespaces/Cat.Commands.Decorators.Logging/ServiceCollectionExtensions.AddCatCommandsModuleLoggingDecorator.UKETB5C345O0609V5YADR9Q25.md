<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands\.Decorators\.Logging](index.md 'index') > [Cat\.Commands\.Decorators\.Logging\.Extensions](Cat.Commands.Decorators.Logging.Extensions.md 'Cat\.Commands\.Decorators\.Logging\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.Commands\.Decorators\.Logging\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatCommandsModuleLoggingDecorator\(this IServiceProvider\) Method

Adds the logging decorator to all command handlers\.

```csharp
public static void AddCatCommandsModuleLoggingDecorator(this System.IServiceProvider serviceProvider);
```
#### Parameters

<a name='Cat.Commands.Decorators.Logging.Extensions.ServiceCollectionExtensions.AddCatCommandsModuleLoggingDecorator(thisSystem.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Must be able to resolve [ICatDecoratorFactoryBuilder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')\.