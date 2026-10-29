<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Expression\.Extensions](index.md 'index') > [Cat\.Expression\.Extensions](Cat.Expression.Extensions.md 'Cat\.Expression\.Extensions') > [ExpressionExtensions](ExpressionExtensions.md 'Cat\.Expression\.Extensions\.ExpressionExtensions')

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