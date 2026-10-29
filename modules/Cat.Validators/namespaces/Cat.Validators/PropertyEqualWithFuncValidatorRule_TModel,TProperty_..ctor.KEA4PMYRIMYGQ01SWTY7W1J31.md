<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyEqualWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>')

## PropertyEqualWithFuncValidatorRule\(Expression\<Func\<TModel,TProperty\>\>, IEqualityComparer\<TProperty\>\) Constructor

Passes when the value equals another property of the model\.
Fails with [Equal](CatValidatorErrorDefinitions.Equal.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Equal') otherwise\.

```csharp
public PropertyEqualWithFuncValidatorRule(System.Linq.Expressions.Expression<System.Func<TModel,TProperty>> expression, System.Collections.Generic.IEqualityComparer<TProperty?>? comparer=null);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.PropertyEqualWithFuncValidatorRule(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Collections.Generic.IEqualityComparer_TProperty_).expression'></a>

`expression` [System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')

<a name='Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.PropertyEqualWithFuncValidatorRule(System.Linq.Expressions.Expression_System.Func_TModel,TProperty__,System.Collections.Generic.IEqualityComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IEqualityComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')[TProperty](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer-1 'System\.Collections\.Generic\.IEqualityComparer\`1')