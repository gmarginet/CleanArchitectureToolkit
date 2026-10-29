<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyInclusiveBetweenValidatorRule&lt;TModel,TProperty&gt;](PropertyInclusiveBetweenValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenValidatorRule\<TModel,TProperty\>')

## PropertyInclusiveBetweenValidatorRule\(TProperty, TProperty\) Constructor

Passes when the value is between the bounds, bounds included\.
Fails with [InclusiveBetween](CatValidatorErrorDefinitions.InclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.InclusiveBetween') otherwise\.

```csharp
public PropertyInclusiveBetweenValidatorRule(TProperty lowerBound, TProperty upperBound);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenValidatorRule_TModel,TProperty_.PropertyInclusiveBetweenValidatorRule(TProperty,TProperty).lowerBound'></a>

`lowerBound` [TProperty](PropertyInclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyInclusiveBetweenValidatorRule_TModel,TProperty_.PropertyInclusiveBetweenValidatorRule(TProperty,TProperty).upperBound'></a>

`upperBound` [TProperty](PropertyInclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyInclusiveBetweenValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyInclusiveBetweenValidatorRule\<TModel,TProperty\>\.TProperty')