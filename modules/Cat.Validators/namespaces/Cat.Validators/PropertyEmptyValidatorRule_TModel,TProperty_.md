<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyEmptyValidatorRule\<TModel,TProperty\> Class

Passes when the value is `null`, a blank string, an empty collection or the default value of its type\.
Fails with [Empty](CatValidatorErrorDefinitions.Empty.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Empty') otherwise\.

```csharp
internal class PropertyEmptyValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyEmptyValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyEmptyValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyEmptyValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEmptyValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyEmptyValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyEmptyValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEmptyValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyEmptyValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyEmptyValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEmptyValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyEmptyValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyEmptyValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEmptyValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyEmptyValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyEmptyValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEmptyValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyEmptyValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyEmptyValidatorRule\<TModel,TProperty\>

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyEmptyValidatorRule_TModel,TProperty_.Validate.HCXIXEG9MAMC3C804WHLD7CE8.md 'Cat\.Validators\.Rules\.PropertyEmptyValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
