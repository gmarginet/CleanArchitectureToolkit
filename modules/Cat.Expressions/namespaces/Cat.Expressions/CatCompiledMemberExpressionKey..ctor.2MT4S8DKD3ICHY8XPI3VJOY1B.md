<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Expressions](index.md 'index') > [Cat\.Expressions](Cat.Expressions.md 'Cat\.Expressions') > [CatCompiledMemberExpressionKey](CatCompiledMemberExpressionKey.md 'Cat\.Expressions\.CatCompiledMemberExpressionKey')

## CatCompiledMemberExpressionKey\(MemberInfo, Expression\) Constructor

Captures the member and the expression's string form, so two keys built from equivalent expressions compare equal\.

```csharp
public CatCompiledMemberExpressionKey(System.Reflection.MemberInfo memberInfo, System.Linq.Expressions.Expression expression);
```
#### Parameters

<a name='Cat.Expressions.CatCompiledMemberExpressionKey.CatCompiledMemberExpressionKey(System.Reflection.MemberInfo,System.Linq.Expressions.Expression).memberInfo'></a>

`memberInfo` [System\.Reflection\.MemberInfo](https://learn.microsoft.com/en-us/dotnet/api/system.reflection.memberinfo 'System\.Reflection\.MemberInfo')

The member the expression resolves to\.

<a name='Cat.Expressions.CatCompiledMemberExpressionKey.CatCompiledMemberExpressionKey(System.Reflection.MemberInfo,System.Linq.Expressions.Expression).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression 'System\.Linq\.Expressions\.Expression')

The expression to key on\.