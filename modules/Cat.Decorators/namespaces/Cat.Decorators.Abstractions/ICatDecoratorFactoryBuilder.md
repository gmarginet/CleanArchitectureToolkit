<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators\.Abstractions](index.md 'index') > [Cat\.Decorators\.Abstractions](Cat.Decorators.Abstractions.md 'Cat\.Decorators\.Abstractions')

## ICatDecoratorFactoryBuilder Interface

Registers decorators for open generic services\.

```csharp
public interface ICatDecoratorFactoryBuilder
```

| Methods | |
| :--- | :--- |
| [AddDecorator\(Type, Type, ICatDecoratorParameter\[\]\)](ICatDecoratorFactoryBuilder.AddDecorator.U7RFRRWBEQRWWXAQT8CHUXGO.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder\.AddDecorator\(System\.Type, System\.Type, Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)') | Adds a decorator for a service\. The first decorator you add is the innermost one\. Each later decorator wraps the one before it\. |
