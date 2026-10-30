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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EXTENSIONS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Object\.Extensions Assembly](index.md 'index') >> [System\.Diagnostics\.CodeAnalysis Namespace](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis') >> [MemberNotNullAttribute Class](MemberNotNullAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute')

## MemberNotNullAttribute Constructors

| Overloads | |
| :--- | :--- |
| [MemberNotNullAttribute\(string\)](MemberNotNullAttribute.MemberNotNullAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute\.MemberNotNullAttribute\(string\)') | Initializes the attribute with a field or property member\. |
| [MemberNotNullAttribute\(string\[\]\)](MemberNotNullAttribute.MemberNotNullAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string[]) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullAttribute\.MemberNotNullAttribute\(string\[\]\)') | Initializes the attribute with the list of field and property members\. |

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string)'></a>

## MemberNotNullAttribute\(string\) Constructor

Initializes the attribute with a field or property member\.

```csharp
public MemberNotNullAttribute(string member);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string).member'></a>

`member` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The field or property member that is promised to be not\-null\.

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string[])'></a>

## MemberNotNullAttribute\(string\[\]\) Constructor

Initializes the attribute with the list of field and property members\.

```csharp
public MemberNotNullAttribute(params string[] members);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.MemberNotNullAttribute(string[]).members'></a>

`members` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The list of field and property members that are promised to be not\-null\.