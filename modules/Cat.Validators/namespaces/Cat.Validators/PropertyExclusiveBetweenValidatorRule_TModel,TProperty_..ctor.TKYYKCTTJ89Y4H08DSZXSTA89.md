<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyExclusiveBetweenValidatorRule&lt;TModel,TProperty&gt;](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>')

## PropertyExclusiveBetweenValidatorRule\(TProperty, TProperty\) Constructor

Passes when the value is greater than the lower bound and less than the upper bound\.
Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\.

```csharp
public PropertyExclusiveBetweenValidatorRule(TProperty lowerBound, TProperty upperBound);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenValidatorRule(TProperty,TProperty).lowerBound'></a>

`lowerBound` [TProperty](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.PropertyExclusiveBetweenValidatorRule(TProperty,TProperty).upperBound'></a>

`upperBound` [TProperty](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.TProperty')