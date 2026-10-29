<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators](Cat.Decorators.md 'Cat\.Decorators') > [CatDecoratorFactoryBuilder](CatDecoratorFactoryBuilder.md 'Cat\.Decorators\.CatDecoratorFactoryBuilder')

## CatDecoratorFactoryBuilder\.AddDecorator\(Type, Type, ICatDecoratorParameter\[\]\) Method

Adds a decorator for a service\. The first decorator you add is the innermost one\.
Each later decorator wraps the one before it\.

```csharp
public void AddDecorator(System.Type serviceType, System.Type decoratorType, params Cat.Decorators.Abstractions.ICatDecoratorParameter[] decoratorParameters);
```
#### Parameters

<a name='Cat.Decorators.CatDecoratorFactoryBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic service type, like `typeof(IHandler<>)`\.

<a name='Cat.Decorators.CatDecoratorFactoryBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).decoratorType'></a>

`decoratorType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic decorator type\. It needs exactly one public constructor\.

<a name='Cat.Decorators.CatDecoratorFactoryBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).decoratorParameters'></a>

`decoratorParameters` [ICatDecoratorParameter](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Values for constructor parameters, matched by parameter name\.

Implements [AddDecorator\(Type, Type, ICatDecoratorParameter\[\]\)](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.AddDecorator.U7RFRRWBEQRWWXAQT8CHUXGO.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder\.AddDecorator\(System\.Type,System\.Type,Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)')

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The service type or the decorator type isn't an open generic type\.