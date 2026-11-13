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

## RecordedDecorator Class

One recorded call of [AddDecorator\(Type, Type, int, ICatDecoratorParameter\[\]\)](RecordingDecoratorBuilder.AddDecorator.md#Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[]) 'Cat\.UnitTesting\.NUnit\.RecordingDecoratorBuilder\.AddDecorator\(System\.Type, System\.Type, int, Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)')\.

```csharp
public sealed record RecordedDecorator : System.IEquatable<Cat.UnitTesting.NUnit.RecordedDecorator>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → RecordedDecorator

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[RecordedDecorator](RecordedDecorator.md 'Cat\.UnitTesting\.NUnit\.RecordedDecorator')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [RecordedDecorator\(Type, Type, int, IDictionary&lt;string,object&gt;\)](RecordedDecorator..ctor.TX91AKK3MP28UEQBXA6P4DMV1.md 'Cat\.UnitTesting\.NUnit\.RecordedDecorator\.RecordedDecorator\(System\.Type, System\.Type, int, System\.Collections\.Generic\.IDictionary\<string,object\>\)') | One recorded call of [AddDecorator\(Type, Type, int, ICatDecoratorParameter\[\]\)](RecordingDecoratorBuilder.AddDecorator.md#Cat.UnitTesting.NUnit.RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[]) 'Cat\.UnitTesting\.NUnit\.RecordingDecoratorBuilder\.AddDecorator\(System\.Type, System\.Type, int, Cat\.Decorators\.Abstractions\.ICatDecoratorParameter\[\]\)')\. |

| Properties | |
| :--- | :--- |
| [DecoratorType](RecordedDecorator.DecoratorType.md 'Cat\.UnitTesting\.NUnit\.RecordedDecorator\.DecoratorType') | |
| [Order](RecordedDecorator.Order.md 'Cat\.UnitTesting\.NUnit\.RecordedDecorator\.Order') | |
| [Parameters](RecordedDecorator.Parameters.md 'Cat\.UnitTesting\.NUnit\.RecordedDecorator\.Parameters') | |
| [ServiceType](RecordedDecorator.ServiceType.md 'Cat\.UnitTesting\.NUnit\.RecordedDecorator\.ServiceType') | |
