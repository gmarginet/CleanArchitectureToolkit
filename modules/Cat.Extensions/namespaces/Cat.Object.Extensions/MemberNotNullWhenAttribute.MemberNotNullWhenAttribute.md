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
  
##### >> [Cat\.Object\.Extensions Assembly](index.md 'index') >> [System\.Diagnostics\.CodeAnalysis Namespace](System.Diagnostics.CodeAnalysis.md 'System\.Diagnostics\.CodeAnalysis') >> [MemberNotNullWhenAttribute Class](MemberNotNullWhenAttribute.md 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute')

## MemberNotNullWhenAttribute Constructors

| Overloads | |
| :--- | :--- |
| [MemberNotNullWhenAttribute\(bool, string\)](MemberNotNullWhenAttribute.MemberNotNullWhenAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute\.MemberNotNullWhenAttribute\(bool, string\)') | Initializes the attribute with the specified return value condition and a field or property member\. |
| [MemberNotNullWhenAttribute\(bool, string\[\]\)](MemberNotNullWhenAttribute.MemberNotNullWhenAttribute.md#System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string[]) 'System\.Diagnostics\.CodeAnalysis\.MemberNotNullWhenAttribute\.MemberNotNullWhenAttribute\(bool, string\[\]\)') | Initializes the attribute with the specified return value condition and list of field and property members\. |

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string)'></a>

## MemberNotNullWhenAttribute\(bool, string\) Constructor

Initializes the attribute with the specified return value condition and a field or property member\.

```csharp
public MemberNotNullWhenAttribute(bool returnValue, string member);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string).returnValue'></a>

`returnValue` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The return value condition\. If the method returns this value,
the associated parameter will not be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string).member'></a>

`member` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The field or property member that is promised to be not\-[null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string[])'></a>

## MemberNotNullWhenAttribute\(bool, string\[\]\) Constructor

Initializes the attribute with the specified return value condition and list
of field and property members\.

```csharp
public MemberNotNullWhenAttribute(bool returnValue, params string[] members);
```
#### Parameters

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string[]).returnValue'></a>

`returnValue` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

The return value condition\. If the method returns this value,
the associated parameter will not be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute.MemberNotNullWhenAttribute(bool,string[]).members'></a>

`members` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

The list of field and property members that are promised to be not\-null\.