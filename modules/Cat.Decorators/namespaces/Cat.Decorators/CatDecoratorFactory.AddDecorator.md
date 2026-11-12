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
  
##### >> [Cat\.Decorators Assembly](index.md 'index') >> [Cat\.Decorators Namespace](Cat.Decorators.md 'Cat\.Decorators') >> [CatDecoratorFactory Class](CatDecoratorFactory.md 'Cat\.Decorators\.CatDecoratorFactory')

## CatDecoratorFactory\.AddDecorator Method

| Overloads | |
| :--- | :--- |
| [AddDecorator\(Type, Type, int, Dictionary&lt;string,object&gt;\)](CatDecoratorFactory.AddDecorator.md#Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,int,System.Collections.Generic.Dictionary_string,object_) 'Cat\.Decorators\.CatDecoratorFactory\.AddDecorator\(System\.Type, System\.Type, int, System\.Collections\.Generic\.Dictionary\<string,object\>\)') | Adds a decorator for a service, with an order\. A lower number is the outer decorator\. With equal order numbers, the first decorator you add is the innermost one\. |
| [AddDecorator\(Type, Type, Dictionary&lt;string,object&gt;\)](CatDecoratorFactory.AddDecorator.md#Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,System.Collections.Generic.Dictionary_string,object_) 'Cat\.Decorators\.CatDecoratorFactory\.AddDecorator\(System\.Type, System\.Type, System\.Collections\.Generic\.Dictionary\<string,object\>\)') | Adds a decorator for a service, with the order [Default](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/CatDecoratorOrder.Default.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Default')\. With equal order numbers, the first decorator you add is the innermost one\. |

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,int,System.Collections.Generic.Dictionary_string,object_)'></a>

## CatDecoratorFactory\.AddDecorator\(Type, Type, int, Dictionary\<string,object\>\) Method

Adds a decorator for a service, with an order\. A lower number is the outer decorator\.
With equal order numbers, the first decorator you add is the innermost one\.

```csharp
public void AddDecorator(System.Type serviceType, System.Type decoratorType, int order, System.Collections.Generic.Dictionary<string,object>? decoratorParameterDictionary);
```
#### Parameters

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,int,System.Collections.Generic.Dictionary_string,object_).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic service type\.

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,int,System.Collections.Generic.Dictionary_string,object_).decoratorType'></a>

`decoratorType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic decorator type\. It needs exactly one public constructor\.

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,int,System.Collections.Generic.Dictionary_string,object_).order'></a>

`order` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The order of the decorator, from the outside in\.

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,int,System.Collections.Generic.Dictionary_string,object_).decoratorParameterDictionary'></a>

`decoratorParameterDictionary` [System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

Constructor values by parameter name, or `null` for none\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The service type or the decorator type isn't an open generic type\.

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,System.Collections.Generic.Dictionary_string,object_)'></a>

## CatDecoratorFactory\.AddDecorator\(Type, Type, Dictionary\<string,object\>\) Method

Adds a decorator for a service, with the order [Default](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/CatDecoratorOrder.Default.md 'Cat\.Decorators\.Abstractions\.CatDecoratorOrder\.Default')\.
With equal order numbers, the first decorator you add is the innermost one\.

```csharp
public void AddDecorator(System.Type serviceType, System.Type decoratorType, System.Collections.Generic.Dictionary<string,object>? decoratorParameterDictionary);
```
#### Parameters

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,System.Collections.Generic.Dictionary_string,object_).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic service type\.

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,System.Collections.Generic.Dictionary_string,object_).decoratorType'></a>

`decoratorType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The open generic decorator type\. It needs exactly one public constructor\.

<a name='Cat.Decorators.CatDecoratorFactory.AddDecorator(System.Type,System.Type,System.Collections.Generic.Dictionary_string,object_).decoratorParameterDictionary'></a>

`decoratorParameterDictionary` [System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

Constructor values by parameter name, or `null` for none\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The service type or the decorator type isn't an open generic type\.