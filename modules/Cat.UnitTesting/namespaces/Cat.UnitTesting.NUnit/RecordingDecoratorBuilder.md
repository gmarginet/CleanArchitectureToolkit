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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.UNITTESTING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.UnitTesting\.NUnit Assembly](index.md 'index') >> [Cat\.UnitTesting\.NUnit Namespace](Cat.UnitTesting.NUnit.md 'Cat\.UnitTesting\.NUnit')

## RecordingDecoratorBuilder Class

An [ICatDecoratorFactoryBuilder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder') that only records the calls, so a test can check
which decorator a module adds and with which order\.

```csharp
public sealed class RecordingDecoratorBuilder : Cat.Decorators.Abstractions.ICatDecoratorFactoryBuilder
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → RecordingDecoratorBuilder

Implements [ICatDecoratorFactoryBuilder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')

| Properties | |
| :--- | :--- |
| [Added](RecordingDecoratorBuilder.Added.md 'Cat\.UnitTesting\.NUnit\.RecordingDecoratorBuilder\.Added') | The decorators that were added, in the sequence of the calls\. |

| Methods | |
| :--- | :--- |
| [AddDecorator\(Type, Type, ICatDecoratorParameter\[\]\)](RecordingDecoratorBuilder.AddDecorator.md#Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]) 'Cat\.UnitTesting\.NUnit\.RecordingDecoratorBuilder\.AddDecorator\(System\.Type, System\.Type, Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)') | Adds a decorator for a service, with the order [Default](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/CatDecoratorOrder.Default.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Default')\. A lower number is the outer decorator\. When two decorators have the same number, the first one you add is the innermost one, and each later one wraps the one before it\. |
| [AddDecorator\(Type, Type, int, ICatDecoratorParameter\[\]\)](RecordingDecoratorBuilder.AddDecorator.md#Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[]) 'Cat\.UnitTesting\.NUnit\.RecordingDecoratorBuilder\.AddDecorator\(System\.Type, System\.Type, int, Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)') | Adds a decorator for a service, with an order\. A lower number is the outer decorator\. Use the numbers of [CatDecoratorOrder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/CatDecoratorOrder.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder'), or a number in between to slot a decorator of your own\. When two decorators have the same number, the first one you add is the innermost one\. |
| [CreateServiceProvider\(\)](RecordingDecoratorBuilder.CreateServiceProvider().md 'Cat\.UnitTesting\.NUnit\.RecordingDecoratorBuilder\.CreateServiceProvider\(\)') | Creates a service provider that hands out this builder, to pass to an `AddCat...Decorator` method\. |
