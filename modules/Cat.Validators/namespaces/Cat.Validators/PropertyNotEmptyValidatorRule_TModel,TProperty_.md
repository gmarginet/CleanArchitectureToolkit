<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyNotEmptyValidatorRule\<TModel,TProperty\> Class

Passes when the value is not `null`, not a blank string, not an empty collection and not the default value of its type\.
Fails with [NotEmpty](CatValidatorErrorDefinitions.NotEmpty.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.NotEmpty') otherwise\.

```csharp
internal class PropertyNotEmptyValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyNotEmptyValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyNotEmptyValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyNotEmptyValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEmptyValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEmptyValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyNotEmptyValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEmptyValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEmptyValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyNotEmptyValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEmptyValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNotEmptyValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyNotEmptyValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEmptyValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEmptyValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyNotEmptyValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEmptyValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNotEmptyValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') → PropertyNotEmptyValidatorRule\<TModel,TProperty\>

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyNotEmptyValidatorRule_TModel,TProperty_.Validate.RYD00XAWKY1637319UBAJD0H8.md 'Cat\.Validators\.Rules\.PropertyNotEmptyValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
