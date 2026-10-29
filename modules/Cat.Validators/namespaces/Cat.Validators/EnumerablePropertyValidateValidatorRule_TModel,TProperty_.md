<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## EnumerablePropertyValidateValidatorRule\<TModel,TProperty\> Class

Validates each item of a collection with its own validator\.
Prefixes the field name of every error with the property name and the item index\.
A `null` item is skipped but still counts for the index\. An item without a validator is skipped only when the top level call
has `validatorRequired` set to `false`\. Otherwise it throws\.

```csharp
internal class EnumerablePropertyValidateValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleAsyncBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.Collections.IEnumerable?
```
#### Type parameters

<a name='Cat.Validators.Rules.EnumerablePropertyValidateValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.EnumerablePropertyValidateValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the collection\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](EnumerablePropertyValidateValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.EnumerablePropertyValidateValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.EnumerablePropertyValidateValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](EnumerablePropertyValidateValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.EnumerablePropertyValidateValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.EnumerablePropertyValidateValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](EnumerablePropertyValidateValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.EnumerablePropertyValidateValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.EnumerablePropertyValidateValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; EnumerablePropertyValidateValidatorRule\<TModel,TProperty\>

| Fields | |
| :--- | :--- |
| [\_internalValidateAsyncMethod](EnumerablePropertyValidateValidatorRule_TModel,TProperty_._internalValidateAsyncMethod.md 'Cat\.Validators\.Rules\.EnumerablePropertyValidateValidatorRule\<TModel,TProperty\>\.\_internalValidateAsyncMethod') | |

| Methods | |
| :--- | :--- |
| [ValidateAsync\(TProperty, string, TModel, CancellationToken\)](EnumerablePropertyValidateValidatorRule_TModel,TProperty_.ValidateAsync.37XT8KX44ZPE0WK73L4UZZ51.md 'Cat\.Validators\.Rules\.EnumerablePropertyValidateValidatorRule\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, System\.Threading\.CancellationToken\)') | |
