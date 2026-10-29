<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyInclusiveBetweenWithFuncAndComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>')

## PropertyInclusiveBetweenWithFuncAndComparerValidatorRule\(Func\<TModel,TProperty\>, Func\<TModel,TProperty\>, IComparer\<TProperty\>\) Constructor

Passes when the value is between the bounds, bounds included\.
Both bounds come from the model and your own comparer orders the values\.
Fails with [InclusiveBetween](CatValidatorErrorDefinitions.InclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.InclusiveBetween') otherwise\.

```csharp
public PropertyInclusiveBetweenWithFuncAndComparerValidatorRule(System.Func<TModel,TProperty> lowerBoundFunc, System.Func<TModel,TProperty> upperBoundFunc, System.Collections.Generic.IComparer<TProperty> comparer);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule(System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).lowerBoundFunc'></a>

`lowerBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule(System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).upperBoundFunc'></a>

`upperBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule(System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[TProperty](PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')