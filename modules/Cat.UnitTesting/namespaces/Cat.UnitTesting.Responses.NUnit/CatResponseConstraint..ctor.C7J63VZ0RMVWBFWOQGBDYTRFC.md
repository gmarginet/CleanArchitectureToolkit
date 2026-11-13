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
  
##### >> [Cat\.UnitTesting\.Responses\.NUnit Assembly](index.md 'index') >> [Cat\.UnitTesting\.Responses\.NUnit Namespace](Cat.UnitTesting.Responses.NUnit.md 'Cat\.UnitTesting\.Responses\.NUnit') >> [CatResponseConstraint Class](CatResponseConstraint.md 'Cat\.UnitTesting\.Responses\.NUnit\.CatResponseConstraint')

## CatResponseConstraint\(bool, CatResponseType, string\) Constructor

Creates the constraint\.

```csharp
public CatResponseConstraint(bool succeeded, Cat.Responses.Abstractions.CatResponseType? type, string? errorCode);
```
#### Parameters

<a name='Cat.UnitTesting.Responses.NUnit.CatResponseConstraint.CatResponseConstraint(bool,Cat.Responses.Abstractions.CatResponseType,string).succeeded'></a>

`succeeded` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

`true` when the response must have succeeded, `false` when it must have failed\.

<a name='Cat.UnitTesting.Responses.NUnit.CatResponseConstraint.CatResponseConstraint(bool,Cat.Responses.Abstractions.CatResponseType,string).type'></a>

`type` [CatResponseType](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.md 'Cat\.Responses\.Abstractions\.CatResponseType')

The type the response must have, or `null` for any type\.

<a name='Cat.UnitTesting.Responses.NUnit.CatResponseConstraint.CatResponseConstraint(bool,Cat.Responses.Abstractions.CatResponseType,string).errorCode'></a>

`errorCode` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The code that one of the errors must have, or `null` for no check\.