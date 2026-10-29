<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyStringExactLengthValidatorRule\<TModel\> Class

Passes when the text has exactly the given length\. A `null` string passes\.
Fails with [ExactLength](CatValidatorErrorDefinitions.ExactLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExactLength') otherwise\.

```csharp
internal class PropertyStringExactLengthValidatorRule<TModel> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyStringExactLengthValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyStringExactLengthValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringExactLengthValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringExactLengthValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyStringExactLengthValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringExactLengthValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringExactLengthValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyStringExactLengthValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringExactLengthValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringExactLengthValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyStringExactLengthValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [PropertyStringExactLengthValidatorRule\(int\)](PropertyStringExactLengthValidatorRule_TModel_..ctor.6OB8V3UR6KTWE6F0NTWI86754.md 'Cat\.Validators\.Rules\.PropertyStringExactLengthValidatorRule\<TModel\>\.PropertyStringExactLengthValidatorRule\(int\)') | Passes when the text has exactly the given length\. A `null` string passes\. Fails with [ExactLength](CatValidatorErrorDefinitions.ExactLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExactLength') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(string, string, TModel\)](PropertyStringExactLengthValidatorRule_TModel_.Validate.4TXZLMC6DUMUNC46D3TYP6NF3.md 'Cat\.Validators\.Rules\.PropertyStringExactLengthValidatorRule\<TModel\>\.Validate\(string, string, TModel\)') | |
