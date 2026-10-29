<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyStringMaximumLengthValidatorRule\<TModel\> Class

Passes when the text is not longer than the maximum\. A `null` string passes\.
Fails with [MaximumLength](CatValidatorErrorDefinitions.MaximumLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MaximumLength') otherwise\.

```csharp
internal class PropertyStringMaximumLengthValidatorRule<TModel> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyStringMaximumLengthValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyStringMaximumLengthValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMaximumLengthValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyStringMaximumLengthValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMaximumLengthValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyStringMaximumLengthValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringMaximumLengthValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyStringMaximumLengthValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [PropertyStringMaximumLengthValidatorRule\(int\)](PropertyStringMaximumLengthValidatorRule_TModel_..ctor.DMLSUXPRSHFRIIMWJC5GGK7H8.md 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthValidatorRule\<TModel\>\.PropertyStringMaximumLengthValidatorRule\(int\)') | Passes when the text is not longer than the maximum\. A `null` string passes\. Fails with [MaximumLength](CatValidatorErrorDefinitions.MaximumLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.MaximumLength') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(string, string, TModel\)](PropertyStringMaximumLengthValidatorRule_TModel_.Validate.BXMI6SJDUAPOGIT9PQG3BPFV1.md 'Cat\.Validators\.Rules\.PropertyStringMaximumLengthValidatorRule\<TModel\>\.Validate\(string, string, TModel\)') | |
