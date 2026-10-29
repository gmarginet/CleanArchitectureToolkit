<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Expression\.Extensions](index.md 'index') > [Cat\.Expression\.Extensions](Cat.Expression.Extensions.md 'Cat\.Expression\.Extensions') > [ExpressionExtensions](ExpressionExtensions.md 'Cat\.Expression\.Extensions\.ExpressionExtensions')

## ExpressionExtensions\.RemoveUnary\(Expression\) Method

Unwraps a unary expression, such as a boxing conversion, to get at its underlying operand\.

```csharp
private static System.Linq.Expressions.Expression RemoveUnary(System.Linq.Expressions.Expression expression);
```
#### Parameters

<a name='Cat.Expression.Extensions.ExpressionExtensions.RemoveUnary(System.Linq.Expressions.Expression).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression 'System\.Linq\.Expressions\.Expression')

The expression to unwrap\.

#### Returns
[System\.Linq\.Expressions\.Expression](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression 'System\.Linq\.Expressions\.Expression')  
The operand of a unary expression, or the expression itself if it isn't unary\.