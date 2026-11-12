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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.DECORATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Decorators\.Abstractions Assembly](index.md 'index') >> [Cat\.Decorators\.Abstractions Namespace](Cat.Decorators.Abstractions.md 'Cat\.Decorators\.Abstractions')

## ICatDecoratorFactoryBuilder Interface

Registers decorators for open generic services\.

```csharp
public interface ICatDecoratorFactoryBuilder
```

| Methods | |
| :--- | :--- |
| [AddDecorator\(Type, Type, ICatDecoratorParameter\[\]\)](ICatDecoratorFactoryBuilder.AddDecorator.md#Cat.Decorators.Abstractions.ICatDecoratorFactoryBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder\.AddDecorator\(System\.Type, System\.Type, Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)') | Adds a decorator for a service, with the order [Default](CatDecoratorOrder.Default.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Default')\. A lower number is the outer decorator\. When two decorators have the same number, the first one you add is the innermost one, and each later one wraps the one before it\. |
| [AddDecorator\(Type, Type, int, ICatDecoratorParameter\[\]\)](ICatDecoratorFactoryBuilder.AddDecorator.md#Cat.Decorators.Abstractions.ICatDecoratorFactoryBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[]) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder\.AddDecorator\(System\.Type, System\.Type, int, Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)') | Adds a decorator for a service, with an order\. A lower number is the outer decorator\. Use the numbers of [CatDecoratorOrder](CatDecoratorOrder.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder'), or a number in between to slot a decorator of your own\. When two decorators have the same number, the first one you add is the innermost one\. |
