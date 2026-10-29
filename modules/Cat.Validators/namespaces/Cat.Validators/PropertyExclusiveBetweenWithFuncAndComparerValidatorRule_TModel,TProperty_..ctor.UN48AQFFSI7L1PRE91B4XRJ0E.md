<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyExclusiveBetweenWithFuncAndComparerValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>')

## PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\(Func\<TModel,TProperty\>, Func\<TModel,TProperty\>, IComparer\<TProperty\>\) Constructor

Passes when the value is greater than the lower bound and less than the upper bound\.
Both bounds come from the model and your own comparer orders the values\.
Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\.

```csharp
public PropertyExclusiveBetweenWithFuncAndComparerValidatorRule(System.Func<TModel,TProperty> lowerBoundFunc, System.Func<TModel,TProperty> upperBoundFunc, System.Collections.Generic.IComparer<TProperty> comparer);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule(System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).lowerBoundFunc'></a>

`lowerBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule(System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).upperBoundFunc'></a>

`upperBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule(System.Func_TModel,TProperty_,System.Func_TModel,TProperty_,System.Collections.Generic.IComparer_TProperty_).comparer'></a>

`comparer` [System\.Collections\.Generic\.IComparer&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')[TProperty](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1 'System\.Collections\.Generic\.IComparer\`1')