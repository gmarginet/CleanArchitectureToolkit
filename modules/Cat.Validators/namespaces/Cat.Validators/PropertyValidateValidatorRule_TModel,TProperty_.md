<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyValidateValidatorRule\<TModel,TProperty\> Class

Validates a property with its own validator\.
Prefixes the field name of every error with the property name\.
A `null` property passes\. A property without a validator is skipped only when the top level call
has `validatorRequired` set to `false`\. Otherwise it throws\.

```csharp
internal class PropertyValidateValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleAsyncBase<TModel, TProperty>
    where TModel : class
    where TProperty : class?
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyValidateValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyValidateValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyValidateValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyValidateValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyValidateValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyValidateValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; PropertyValidateValidatorRule\<TModel,TProperty\>

| Methods | |
| :--- | :--- |
| [ValidateAsync\(TProperty, string, TModel, CancellationToken\)](PropertyValidateValidatorRule_TModel,TProperty_.ValidateAsync.13CTCFU6TW3Z7LEZ4AN8AHIN8.md 'Cat\.Validators\.Rules\.PropertyValidateValidatorRule\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, System\.Threading\.CancellationToken\)') | |
