<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Commands](index.md 'index') > [Cat\.Commands](Cat.Commands.md 'Cat\.Commands') > [CatCommandProcessor](CatCommandProcessor.md 'Cat\.Commands\.CatCommandProcessor')

## CatCommandProcessor\(IServiceProvider, ICatDecoratorFactory\) Constructor

Creates the processor\.

```csharp
public CatCommandProcessor(System.IServiceProvider serviceProvider, Cat.Decorators.Abstractions.ICatDecoratorFactory decoratorFactory);
```
#### Parameters

<a name='Cat.Commands.CatCommandProcessor.CatCommandProcessor(System.IServiceProvider,Cat.Decorators.Abstractions.ICatDecoratorFactory).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Used to open a scope for each command\.

<a name='Cat.Commands.CatCommandProcessor.CatCommandProcessor(System.IServiceProvider,Cat.Decorators.Abstractions.ICatDecoratorFactory).decoratorFactory'></a>

`decoratorFactory` [ICatDecoratorFactory](../Cat.Decorators.Abstractions/ICatDecoratorFactory.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactory')

Builds the handler together with its registered decorators\.