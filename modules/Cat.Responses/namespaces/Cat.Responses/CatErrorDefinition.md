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

## CatErrorDefinition Class

A reusable definition for one kind of error: a stable code and a message template\. Define these once, as static
fields, and call [CreateCatError\(object\[\]\)](CatErrorDefinition.CreateCatError.5WX0CKR3WJOIDHOM83UIBF54.md 'Cat\.Responses\.CatErrorDefinition\.CreateCatError\(object\[\]\)') wherever that error needs to be raised with specific argument values\.

```csharp
public record CatErrorDefinition : System.IEquatable<Cat.Responses.CatErrorDefinition>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatErrorDefinition

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[CatErrorDefinition](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [CatErrorDefinition\(string, string\)](CatErrorDefinition..ctor.IGMLEK3XRV75B8Y09313OXAO6.md 'Cat\.Responses\.CatErrorDefinition\.CatErrorDefinition\(string, string\)') | Creates a definition with the given code and message template\. |

| Properties | |
| :--- | :--- |
| [Code](CatErrorDefinition.Code.md 'Cat\.Responses\.CatErrorDefinition\.Code') | A stable code identifying the kind of error, independent of its message text\. |
| [Message](CatErrorDefinition.Message.md 'Cat\.Responses\.CatErrorDefinition\.Message') | A human\-readable message describing the error\. Can contain placeholders filled in by [Arguments](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.Arguments.md 'Cat\.Responses\.Abstractions\.ICatError\.Arguments')\. |

| Methods | |
| :--- | :--- |
| [Create\(string, string\)](CatErrorDefinition.Create.Y0S1RWZVWY7EIAVA1URQ5FOD8.md 'Cat\.Responses\.CatErrorDefinition\.Create\(string, string\)') | Creates a new error definition\. |
| [CreateCatError\(object\[\]\)](CatErrorDefinition.CreateCatError.5WX0CKR3WJOIDHOM83UIBF54.md 'Cat\.Responses\.CatErrorDefinition\.CreateCatError\(object\[\]\)') | Creates an [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError') from this definition, with the given values filled into the message's placeholders\. |
