<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyGreaterThanValidatorRule\<TModel,TProperty\> Class

Passes when the value is greater than the given value\.
Fails with [GreaterThan](CatValidatorErrorDefinitions.GreaterThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThan') otherwise\.

```csharp
internal class PropertyGreaterThanValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyGreaterThanValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyGreaterThanValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyGreaterThanValidatorRule\(TProperty\)](PropertyGreaterThanValidatorRule_TModel,TProperty_..ctor.1S1GXDFZB4LZOP8R495080CLE.md 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.PropertyGreaterThanValidatorRule\(TProperty\)') | Passes when the value is greater than the given value\. Fails with [GreaterThan](CatValidatorErrorDefinitions.GreaterThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThan') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyGreaterThanValidatorRule_TModel,TProperty_.Validate.CR6WMBKZNPL2U97DXNGARWS77.md 'Cat\.Validators\.Rules\.PropertyGreaterThanValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
