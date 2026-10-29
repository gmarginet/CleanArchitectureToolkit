<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyInclusiveBetweenWithFuncValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>')

## PropertyInclusiveBetweenWithFuncValidatorRule\(Func\<TModel,TProperty\>, Func\<TModel,TProperty\>\) Constructor

Passes when the value is between the bounds, bounds included\.
Both bounds come from the model\.
Fails with [InclusiveBetween](CatValidatorErrorDefinitions.InclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.InclusiveBetween') otherwise\.

```csharp
public PropertyInclusiveBetweenWithFuncValidatorRule(System.Func<TModel,TProperty> lowerBoundFunc, System.Func<TModel,TProperty> upperBoundFunc);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.PropertyInclusiveBetweenWithFuncValidatorRule(System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).lowerBoundFunc'></a>

`lowerBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.PropertyInclusiveBetweenWithFuncValidatorRule(System.Func_TModel,TProperty_,System.Func_TModel,TProperty_).upperBoundFunc'></a>

`upperBoundFunc` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TModel](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')