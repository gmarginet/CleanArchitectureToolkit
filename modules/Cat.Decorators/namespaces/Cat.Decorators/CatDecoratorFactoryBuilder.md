<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.DECORATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Decorators Assembly](index.md 'index') >> [Cat\.Decorators Namespace](Cat.Decorators.md 'Cat\.Decorators')

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
