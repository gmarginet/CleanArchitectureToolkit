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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EXPRESSIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Expressions Assembly](index.md 'index') >> [Cat\.Expressions Namespace](Cat.Expressions.md 'Cat\.Expressions')

## CatCompiledMemberExpressionKey Class

Identifies a compiled member expression by its member and the expression's text, so it can be used as a cache key\.

```csharp
internal class CatCompiledMemberExpressionKey
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCompiledMemberExpressionKey

| Constructors | |
| :--- | :--- |
| [CatCompiledMemberExpressionKey\(MemberInfo, Expression\)](CatCompiledMemberExpressionKey..ctor.2MT4S8DKD3ICHY8XPI3VJOY1B.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.CatCompiledMemberExpressionKey\(System\.Reflection\.MemberInfo, System\.Linq\.Expressions\.Expression\)') | Captures the member and the expression's string form, so two keys built from equivalent expressions compare equal\. |

| Fields | |
| :--- | :--- |
| [\_expressionKey](CatCompiledMemberExpressionKey._expressionKey.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.\_expressionKey') | |
| [\_memberInfo](CatCompiledMemberExpressionKey._memberInfo.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.\_memberInfo') | |

| Methods | |
| :--- | :--- |
| [Equals\(CatCompiledMemberExpressionKey\)](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey) 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(Cat\.Expressions\.CatCompiledMemberExpressionKey\)') | Checks whether this key refers to the same member and expression text as [other](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(Cat.Expressions.CatCompiledMemberExpressionKey).other 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(Cat\.Expressions\.CatCompiledMemberExpressionKey\)\.other')\. |
| [Equals\(object\)](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object) 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)') | Checks whether [obj](CatCompiledMemberExpressionKey.Equals.md#Cat.Expressions.CatCompiledMemberExpressionKey.Equals(object).obj 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.Equals\(object\)\.obj') is a key that refers to the same member and expression text\. |
| [GetHashCode\(\)](CatCompiledMemberExpressionKey.GetHashCode().md 'Cat\.Expressions\.CatCompiledMemberExpressionKey\.GetHashCode\(\)') | Builds a hash code from the member and the expression text, so equal keys land in the same cache bucket\. |
