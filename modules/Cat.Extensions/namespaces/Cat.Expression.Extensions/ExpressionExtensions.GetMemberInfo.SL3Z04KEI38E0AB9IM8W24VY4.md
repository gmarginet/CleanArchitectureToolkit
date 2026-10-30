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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EXTENSIONS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Expression\.Extensions Assembly](index.md 'index') >> [Cat\.Expression\.Extensions Namespace](Cat.Expression.Extensions.md 'Cat\.Expression\.Extensions') >> [ExpressionExtensions Class](ExpressionExtensions.md 'Cat\.Expression\.Extensions\.ExpressionExtensions')

## ExpressionExtensions\.GetMemberInfo\<T,TProperty\>\(this Expression\<Func\<T,TProperty\>\>\) Method

Resolves the member a simple member access expression points to, for example the `Id` property in `x => x.Id`\.

```csharp
public static System.Reflection.MemberInfo? GetMemberInfo<T,TProperty>(this System.Linq.Expressions.Expression<System.Func<T,TProperty>> expression);
```
#### Type parameters

<a name='Cat.Expression.Extensions.ExpressionExtensions.GetMemberInfo_T,TProperty_(thisSystem.Linq.Expressions.Expression_System.Func_T,TProperty__).T'></a>

`T`

The type the expression's parameter is evaluated against\.

<a name='Cat.Expression.Extensions.ExpressionExtensions.GetMemberInfo_T,TProperty_(thisSystem.Linq.Expressions.Expression_System.Func_T,TProperty__).TProperty'></a>

`TProperty`

The type of value the expression returns\.
#### Parameters

<a name='Cat.Expression.Extensions.ExpressionExtensions.GetMemberInfo_T,TProperty_(thisSystem.Linq.Expressions.Expression_System.Func_T,TProperty__).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[T](ExpressionExtensions.GetMemberInfo.SL3Z04KEI38E0AB9IM8W24VY4.md#Cat.Expression.Extensions.ExpressionExtensions.GetMemberInfo_T,TProperty_(thisSystem.Linq.Expressions.Expression_System.Func_T,TProperty__).T 'Cat\.Expression\.Extensions\.ExpressionExtensions\.GetMemberInfo\<T,TProperty\>\(this System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>\)\.T')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](ExpressionExtensions.GetMemberInfo.SL3Z04KEI38E0AB9IM8W24VY4.md#Cat.Expression.Extensions.ExpressionExtensions.GetMemberInfo_T,TProperty_(thisSystem.Linq.Expressions.Expression_System.Func_T,TProperty__).TProperty 'Cat\.Expression\.Extensions\.ExpressionExtensions\.GetMemberInfo\<T,TProperty\>\(this System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>\)\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

The expression to inspect\.

#### Returns
[System\.Reflection\.MemberInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.memberinfo 'System\.Reflection\.MemberInfo')  
The resolved member, or `null` if the expression isn't a direct member access on its parameter\.