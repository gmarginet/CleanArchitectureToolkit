<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyLessThanOrEqualToValidatorRule&lt;TModel,TProperty&gt;](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>')

## PropertyLessThanOrEqualToValidatorRule\(TProperty\) Constructor

Passes when the value is less than or equal to the given value\.
Fails with [LessThanOrEqualTo](CatValidatorErrorDefinitions.LessThanOrEqualTo.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.LessThanOrEqualTo') otherwise\.

```csharp
public PropertyLessThanOrEqualToValidatorRule(TProperty valueToCompare);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.PropertyLessThanOrEqualToValidatorRule(TProperty).valueToCompare'></a>

`valueToCompare` [TProperty](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>\.TProperty')