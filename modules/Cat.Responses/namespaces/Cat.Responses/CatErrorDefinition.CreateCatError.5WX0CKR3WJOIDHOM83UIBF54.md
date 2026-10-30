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
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses') >> [CatErrorDefinition Class](CatErrorDefinition.md 'Cat\.Responses\.CatErrorDefinition')

## CatErrorDefinition\.CreateCatError\(object\[\]\) Method

Creates an [ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError') from this definition, with the given values filled into the message's placeholders\.

```csharp
public Cat.Responses.Abstractions.ICatError CreateCatError(params object?[] arguments);
```
#### Parameters

<a name='Cat.Responses.CatErrorDefinition.CreateCatError(object[]).arguments'></a>

`arguments` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The values to substitute into the message's placeholders, in order\.

#### Returns
[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')  
An error carrying this definition's code and message, with [arguments](CatErrorDefinition.CreateCatError.5WX0CKR3WJOIDHOM83UIBF54.md#Cat.Responses.CatErrorDefinition.CreateCatError(object[]).arguments 'Cat\.Responses\.CatErrorDefinition\.CreateCatError\(object\[\]\)\.arguments') attached\.