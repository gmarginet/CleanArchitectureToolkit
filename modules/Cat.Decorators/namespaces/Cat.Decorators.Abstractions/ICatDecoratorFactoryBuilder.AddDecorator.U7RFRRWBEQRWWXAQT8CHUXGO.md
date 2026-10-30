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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.DECORATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Decorators\.Abstractions Assembly](index.md 'index') >> [Cat\.Decorators\.Abstractions Namespace](Cat.Decorators.Abstractions.md 'Cat\.Decorators\.Abstractions') >> [ICatDecoratorFactoryBuilder Interface](ICatDecoratorFactoryBuilder.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder')

## ICatDecoratorFactoryBuilder\.AddDecorator\(Type, Type, ICatDecoratorParameter\[\]\) Method

Adds a decorator for a service\. The first decorator you add is the innermost one\.
Each later decorator wraps the one before it\.

```csharp
void AddDecorator(System.Type serviceType, System.Type decoratorType, params Cat.Decorators.Abstractions.ICatDecoratorParameter[] decoratorParameters);
```
#### Parameters

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactoryBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic service type, like `typeof(IHandler<>)`\.

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactoryBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).decoratorType'></a>

`decoratorType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic decorator type\. It needs exactly one public constructor\.

<a name='Cat.Decorators.Abstractions.ICatDecoratorFactoryBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).decoratorParameters'></a>

`decoratorParameters` [ICatDecoratorParameter](ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Values for constructor parameters, matched by parameter name\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The service type or the decorator type isn't an open generic type\.