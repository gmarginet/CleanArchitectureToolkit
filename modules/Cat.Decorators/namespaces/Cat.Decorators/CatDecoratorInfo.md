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
  
##### >> [Cat\.Decorators Assembly](index.md 'index') >> [Cat\.Decorators Namespace](Cat.Decorators.md 'Cat\.Decorators')

## CatDecoratorInfo Class

Describes one registered decorator: its open generic type and the constructor values to pass to it\.

```csharp
public record CatDecoratorInfo : System.IEquatable<Cat.Decorators.CatDecoratorInfo>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatDecoratorInfo

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CatDecoratorInfo](CatDecoratorInfo.md 'Cat\.Decorators\.CatDecoratorInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CatDecoratorInfo\(Type, IDictionary&lt;string,object&gt;\)](CatDecoratorInfo..ctor.7N6RUQYPU2QAFERC8RWFG9II1.md 'Cat\.Decorators\.CatDecoratorInfo\.CatDecoratorInfo\(System\.Type, System\.Collections\.Generic\.IDictionary\<string,object\>\)') | Creates the description\. |

| Properties | |
| :--- | :--- |
| [DecoratorGenericTypeDefinition](CatDecoratorInfo.DecoratorGenericTypeDefinition.md 'Cat\.Decorators\.CatDecoratorInfo\.DecoratorGenericTypeDefinition') | The open generic decorator type\. |
| [DecoratorParameterDictionary](CatDecoratorInfo.DecoratorParameterDictionary.md 'Cat\.Decorators\.CatDecoratorInfo\.DecoratorParameterDictionary') | Constructor values by parameter name, or `null` for none\. |
