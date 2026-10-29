<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyNotEqualWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>')

## PropertyNotEqualWithFuncValidatorRule\(Expression\<Func\<TModel,TProperty\>\>, IEqualityComparer\<TProperty\>\) Constructor

Passes when the value doesn't equal another property of the model\.
Fails with [NotEqual](CatValidatorErrorDefinitions.NotEqual.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.NotEqual') otherwise\.

```csharp
public PropertyNotEqualWithFuncValidatorRule(System.Linq.Expressions.Expression<System.Func<TModel,TProperty>> expression, System.Collections.Generic.IEqualityComparer<TProperty?>? comparer=null);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.PropertyNotEqualWithFuncValidatorRule(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Collections.Generic.IEqualityComparer_TProperty_).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

<a name='Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.PropertyNotEqualWithFuncValidatorRule(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Collections.Generic.IEqualityComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IEqualityComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')[TProperty](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')