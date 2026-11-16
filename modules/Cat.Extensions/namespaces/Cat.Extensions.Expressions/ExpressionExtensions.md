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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EXTENSIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Extensions\.Expressions Assembly](index.md 'index') >> [Cat\.Extensions\.Expressions Namespace](Cat.Extensions.Expressions.md 'Cat\.Extensions\.Expressions')

## ExpressionExtensions Class

Extension methods for inspecting [System\.Linq\.Expressions\.Expression](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression 'System\.Linq\.Expressions\.Expression') trees\.

```csharp
public static class ExpressionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ExpressionExtensions

| Methods | |
| :--- | :--- |
| [GetMemberInfo&lt;T,TProperty&gt;\(this Expression&lt;Func&lt;T,TProperty&gt;&gt;\)](ExpressionExtensions.GetMemberInfo.C20LKFLJHX1LXGEDETVFH0K29.md 'Cat\.Extensions\.Expressions\.ExpressionExtensions\.GetMemberInfo\<T,TProperty\>\(this System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>\)') | Resolves the member a simple member access expression points to, for example the `Id` property in `x => x.Id`\. |
| [RemoveUnary\(Expression\)](ExpressionExtensions.RemoveUnary.GOZ7BM62N3WPJ6PVOOMEDUI39.md 'Cat\.Extensions\.Expressions\.ExpressionExtensions\.RemoveUnary\(System\.Linq\.Expressions\.Expression\)') | Unwraps a unary expression, such as a boxing conversion, to get at its underlying operand\. |
