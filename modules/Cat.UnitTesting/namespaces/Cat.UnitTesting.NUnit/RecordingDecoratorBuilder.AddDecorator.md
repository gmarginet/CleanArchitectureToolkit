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
  
##### >> [Cat\.UnitTesting\.NUnit Assembly](index.md 'index') >> [Cat\.UnitTesting\.NUnit Namespace](Cat.UnitTesting.NUnit.md 'Cat\.UnitTesting\.NUnit') >> [RecordingDecoratorBuilder Class](RecordingDecoratorBuilder.md 'Cat\.UnitTesting\.NUnit\.RecordingDecoratorBuilder')

## RecordingDecoratorBuilder\.AddDecorator Method

| Overloads | |
| :--- | :--- |
| [AddDecorator\(Type, Type, ICatDecoratorParameter\[\]\)](RecordingDecoratorBuilder.AddDecorator.md#Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]) 'Cat\.UnitTesting\.NUnit\.RecordingDecoratorBuilder\.AddDecorator\(System\.Type, System\.Type, Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)') | Adds a decorator for a service, with the order [Default](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/CatDecoratorOrder.Default.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Default')\. A lower number is the outer decorator\. When two decorators have the same number, the first one you add is the innermost one, and each later one wraps the one before it\. |
| [AddDecorator\(Type, Type, int, ICatDecoratorParameter\[\]\)](RecordingDecoratorBuilder.AddDecorator.md#Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[]) 'Cat\.UnitTesting\.NUnit\.RecordingDecoratorBuilder\.AddDecorator\(System\.Type, System\.Type, int, Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)') | Adds a decorator for a service, with an order\. A lower number is the outer decorator\. Use the numbers of [CatDecoratorOrder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/CatDecoratorOrder.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder'), or a number in between to slot a decorator of your own\. When two decorators have the same number, the first one you add is the innermost one\. |

<a name='Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[])'></a>

## RecordingDecoratorBuilder\.AddDecorator\(Type, Type, ICatDecoratorParameter\[\]\) Method

Adds a decorator for a service, with the order [Default](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/CatDecoratorOrder.Default.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Default')\.
A lower number is the outer decorator\. When two decorators have the same number, the first one you add is the innermost one,
and each later one wraps the one before it\.

```csharp
public void AddDecorator(System.Type serviceType, System.Type decoratorType, params Cat.Decorators.Abstractions.ICatDecoratorParameter[] decoratorParameters);
```
#### Parameters

<a name='Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic service type, like `typeof(IHandler<>)`\.

<a name='Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).decoratorType'></a>

`decoratorType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic decorator type\. It needs exactly one public constructor\.

<a name='Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).decoratorParameters'></a>

`decoratorParameters` [ICatDecoratorParameter](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Values for constructor parameters, matched by parameter name\.

Implements [AddDecorator\(Type, Type, ICatDecoratorParameter\[\]\)](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.AddDecorator.md#Cat.Decorators.Abstractions.ICatDecoratorFactoryBuilder.AddDecorator(System.Type,System.Type,Cat.Decorators.Abstractions.ICatDecoratorParameter[]) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder\.AddDecorator\(System\.Type,System\.Type,Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)')

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The service type or the decorator type isn't an open generic type\.

<a name='Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[])'></a>

## RecordingDecoratorBuilder\.AddDecorator\(Type, Type, int, ICatDecoratorParameter\[\]\) Method

Adds a decorator for a service, with an order\. A lower number is the outer decorator\.
Use the numbers of [CatDecoratorOrder](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/CatDecoratorOrder.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder'), or a number in between to slot a decorator of your own\.
When two decorators have the same number, the first one you add is the innermost one\.

```csharp
public void AddDecorator(System.Type serviceType, System.Type decoratorType, int order, params Cat.Decorators.Abstractions.ICatDecoratorParameter[] decoratorParameters);
```
#### Parameters

<a name='Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic service type, like `typeof(IHandler<>)`\.

<a name='Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).decoratorType'></a>

`decoratorType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic decorator type\. It needs exactly one public constructor\.

<a name='Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).order'></a>

`order` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The order of the decorator, from the outside in\.

<a name='Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[]).decoratorParameters'></a>

`decoratorParameters` [ICatDecoratorParameter](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

Values for constructor parameters, matched by parameter name\.

Implements [AddDecorator\(Type, Type, int, ICatDecoratorParameter\[\]\)](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorFactoryBuilder.AddDecorator.md#Cat.Decorators.Abstractions.ICatDecoratorFactoryBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[]) 'Cat\.Decorators\.Abstractions\.ICatDecoratorFactoryBuilder\.AddDecorator\(System\.Type,System\.Type,System\.Int32,Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)')

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The service type or the decorator type isn't an open generic type\.