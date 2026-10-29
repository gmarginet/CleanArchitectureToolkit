<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyGreaterThanValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>')

## PropertyGreaterThanValidatorRule\(TProperty\) Constructor

Passes when the value is greater than the given value\.
Fails with [GreaterThan](CatValidatorErrorDefinitions.GreaterThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThan') otherwise\.

```csharp
public PropertyGreaterThanValidatorRule(TProperty valueToCompare);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.PropertyGreaterThanValidatorRule(TProperty).valueToCompare'></a>

`valueToCompare` [TProperty](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TProperty')