<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators](Cat.Decorators.md 'Cat\.Decorators')

## CatDecoratorFactoryBuilder Class

Default [ICatDecoratorFactoryBuilder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')\.
Hands the decorators over to the [CatDecoratorFactory](CatDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactory')\.

```csharp
public class CatDecoratorFactoryBuilder : Cat.Decorators.Abstractions.ICatDecoratorFactoryBuilder
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatDecoratorFactoryBuilder

Implements [ICatDecoratorFactoryBuilder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')

| Constructors | |
| :--- | :--- |
| [CatDecoratorFactoryBuilder\(ICatDecoratorFactory\)](CatDecoratorFactoryBuilder..ctor.NCL4FYVPSYHI37DGQYOWQDRT6.md 'Cat\.Decorators\.CatDecoratorFactoryBuilder\.CatDecoratorFactoryBuilder\(Cat\.Decorators\.Abstractions\.ICatDecoratorFactory\)') | Creates the builder\. |

| Fields | |
| :--- | :--- |
| [\_catDecoratorFactory](CatDecoratorFactoryBuilder._catDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactoryBuilder\.\_catDecoratorFactory') | |

| Methods | |
| :--- | :--- |
| [AddDecorator\(Type, Type, ICatDecoratorParameter\[\]\)](CatDecoratorFactoryBuilder.AddDecorator.0FWK4GPSYA3AU4KQPYOKK3Q47.md 'Cat\.Decorators\.CatDecoratorFactoryBuilder\.AddDecorator\(System\.Type, System\.Type, Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)') | Adds a decorator for a service\. The first decorator you add is the innermost one\. Each later decorator wraps the one before it\. |
