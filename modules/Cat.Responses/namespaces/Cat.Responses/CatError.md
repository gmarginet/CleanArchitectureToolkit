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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses')

## CatError Class

The default [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError') implementation\. Create instances through its static `Create` overloads,
or build one from a reusable [CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition') instead\.

```csharp
public record CatError : Cat.Responses.Abstractions.ICatError, System.IEquatable<Cat.Responses.CatError>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatError

Implements [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError'), [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CatError](CatError.md 'Cat\.Responses\.CatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CatError\(string, string, object\[\]\)](CatError..ctor.6388ROMK40MNSHIGSSKKVZTIE.md 'Cat\.Responses\.CatError\.CatError\(string, string, object\[\]\)') | Creates an error with the given code, message, and arguments\. |

| Properties | |
| :--- | :--- |
| [Arguments](CatError.Arguments.md 'Cat\.Responses\.CatError\.Arguments') | The values to substitute into the message's placeholders, in order\. |
| [Code](CatError.Code.md 'Cat\.Responses\.CatError\.Code') | A stable code identifying the kind of error, independent of its message text\. |
| [Message](CatError.Message.md 'Cat\.Responses\.CatError\.Message') | A human\-readable message describing the error\. Can contain placeholders filled in by [Arguments](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.Arguments.md 'Cat\.Responses\.Abstractions\.ICatError\.Arguments')\. |

| Methods | |
| :--- | :--- |
| [Create\(string, string, object\[\]\)](CatError.Create.md#Cat.Responses.CatError.Create(string,string,object[]) 'Cat\.Responses\.CatError\.Create\(string, string, object\[\]\)') | Creates an error with the given code, message, and arguments\. |
| [Create\(string, string, List&lt;object&gt;\)](CatError.Create.md#Cat.Responses.CatError.Create(string,string,System.Collections.Generic.List_object_) 'Cat\.Responses\.CatError\.Create\(string, string, System\.Collections\.Generic\.List\<object\>\)') | Creates an error with the given code, message, and arguments\. |
