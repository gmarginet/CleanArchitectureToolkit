<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyLessThanValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanValidatorRule\<TModel,TProperty\>')

## PropertyLessThanValidatorRule\(TProperty\) Constructor

Passes when the value is less than the given value\.
Fails with [LessThan](CatValidatorErrorDefinitions.LessThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.LessThan') otherwise\.

```csharp
public PropertyLessThanValidatorRule(TProperty valueToCompare);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyLessThanValidatorRule_TModel,TProperty_.PropertyLessThanValidatorRule(TProperty).valueToCompare'></a>

`valueToCompare` [TProperty](PropertyLessThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyLessThanValidatorRule\<TModel,TProperty\>\.TProperty')