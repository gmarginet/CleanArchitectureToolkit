<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyExclusiveBetweenWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>')

## PropertyExclusiveBetweenWithFuncValidatorRule\(Func\<TModel,TProperty\>, Func\<TModel,TProperty\>\) Constructor

Passes when the value is greater than the lower bound and less than the upper bound\.
Both bounds come from the model\.
Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\.

```csharp
public PropertyExclusiveBetweenWithFuncValidatorRule(System.Func<TModel,TProperty> lowerBoundFunc, System.Func<TModel,TProperty> upperBoundFunc);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenWithFuncValidatorRule(System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).lowerBoundFunc'></a>

`lowerBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenWithFuncValidatorRule(System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).upperBoundFunc'></a>

`upperBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')