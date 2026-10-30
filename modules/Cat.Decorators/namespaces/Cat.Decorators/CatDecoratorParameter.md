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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
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

## CatDecoratorParameter Class

Default [ICatDecoratorParameter](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter')\.

```csharp
public record CatDecoratorParameter : Cat.Decorators.Abstractions.ICatDecoratorParameter, System.IEquatable<Cat.Decorators.CatDecoratorParameter>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatDecoratorParameter

Implements [ICatDecoratorParameter](../../../Cat.Decorators/namespaces/Cat.Decorators.Abstractions/ICatDecoratorParameter.md 'Cat\.Decorators\.Abstractions\.ICatDecoratorParameter'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CatDecoratorParameter](CatDecoratorParameter.md 'Cat\.Decorators\.CatDecoratorParameter')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CatDecoratorParameter\(string, object\)](CatDecoratorParameter..ctor.GSF504BV2LLXS4FC3L5HUPYO1.md 'Cat\.Decorators\.CatDecoratorParameter\.CatDecoratorParameter\(string, object\)') | Creates the parameter\. |

| Properties | |
| :--- | :--- |
| [Name](CatDecoratorParameter.Name.md 'Cat\.Decorators\.CatDecoratorParameter\.Name') | The name of the constructor parameter\. |
| [Value](CatDecoratorParameter.Value.md 'Cat\.Decorators\.CatDecoratorParameter\.Value') | The value to pass\. Its type must fit the parameter type\. |
