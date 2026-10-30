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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EXPRESSIONS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Expressions Assembly](index.md 'index') >> [Cat\.Expressions Namespace](Cat.Expressions.md 'Cat\.Expressions') >> [CatCompiledMemberExpressionKey Class](CatCompiledMemberExpressionKey.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey')

## CatCompiledMemberExpressionKey\.Equals Method

| Overloads | |
| :--- | :--- |
| [Equals\(CatCompiledMemberExpressionKey\)](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey) 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(Cat\.Expressions\.CatCompiledMemberExpressionKey\)') | Checks whether this key refers to the same member and expression text as [other](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey).other 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(Cat\.Expressions\.CatCompiledMemberExpressionKey\)\.other')\. |
| [Equals\(object\)](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object) 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)') | Checks whether [obj](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object).obj 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)\.obj') is a key that refers to the same member and expression text\. |

<a name='Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey)'></a>

## CatCompiledMemberExpressionKey\.Equals\(CatCompiledMemberExpressionKey\) Method

Checks whether this key refers to the same member and expression text as [other](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey).other 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(Cat\.Expressions\.CatCompiledMemberExpressionKey\)\.other')\.

```csharp
public bool Equals(Cat.Expressions.CatCompiledMemberExpressionKey other);
```
#### Parameters

<a name='Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey).other'></a>

`other` [CatCompiledMemberExpressionKey](CatCompiledMemberExpressionKey.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey')

The key to compare against\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if both keys refer to the same member and expression text\.

<a name='Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object)'></a>

## CatCompiledMemberExpressionKey\.Equals\(object\) Method

Checks whether [obj](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object).obj 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)\.obj') is a key that refers to the same member and expression text\.

```csharp
public override bool Equals(object? obj);
```
#### Parameters

<a name='Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object).obj'></a>

`obj` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The object to compare against\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if [obj](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object).obj 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)\.obj') is a key with the same member and expression text\.