<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyGreaterThanOrEqualToValidatorRule&lt;TModel,TProperty&gt;](PropertyGreaterThanOrEqualToValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyGreaterThanOrEqualToValidatorRule\<TModel,TProperty\>')

## PropertyGreaterThanOrEqualToValidatorRule\(TProperty\) Constructor

Passes when the value is greater than or equal to the given value\.
Fails with [GreaterThanOrEqualTo](CatValidatorErrorDefinitions.GreaterThanOrEqualTo.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThanOrEqualTo') otherwise\.

```csharp
public PropertyGreaterThanOrEqualToValidatorRule(TProperty valueToCompare);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyGreaterThanOrEqualToValidatorRule_TModel,TProperty_.PropertyGreaterThanOrEqualToValidatorRule(TProperty).valueToCompare'></a>

`valueToCompare` [TProperty](PropertyGreaterThanOrEqualToValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanOrEqualToValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyGreaterThanOrEqualToValidatorRule\<TModel,TProperty\>\.TProperty')