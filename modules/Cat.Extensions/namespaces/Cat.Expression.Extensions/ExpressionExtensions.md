<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Expression\.Extensions](index.md 'index') > [Cat\.Expression\.Extensions](Cat.Expression.Extensions.md 'Cat\.Expression\.Extensions')

## ExpressionExtensions Class

Extension methods for inspecting [System\.Linq\.Expressions\.Expression](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression 'System\.Linq\.Expressions\.Expression') trees\.

```csharp
public static class ExpressionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ExpressionExtensions

| Methods | |
| :--- | :--- |
| [GetMemberInfo&lt;T,TProperty&gt;\(this Expression&lt;Func&lt;T,TProperty&gt;&gt;\)](ExpressionExtensions.GetMemberInfo.SL3Z04KEI38E0AB9IM8W24VY4.md 'Cat\.Expression\.Extensions\.ExpressionExtensions\.GetMemberInfo\<T,TProperty\>\(this System\.Linq\.Expressions\.Expression\<System\.Func\<T,TProperty\>\>\)') | Resolves the member a simple member access expression points to, for example the `Id` property in `x => x.Id`\. |
| [RemoveUnary\(Expression\)](ExpressionExtensions.RemoveUnary.KQZPWSU4BFZVWS9S5R986BYU.md 'Cat\.Expression\.Extensions\.ExpressionExtensions\.RemoveUnary\(System\.Linq\.Expressions\.Expression\)') | Unwraps a unary expression, such as a boxing conversion, to get at its underlying operand\. |
