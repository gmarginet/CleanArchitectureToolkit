<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyStringExactLengthWithFuncValidatorRule\<TModel\> Class

Passes when the text has exactly the length taken from the model\. A `null` string passes\.
Fails with [ExactLength](CatValidatorErrorDefinitions.ExactLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExactLength') otherwise\.

```csharp
internal class PropertyStringExactLengthWithFuncValidatorRule<TModel> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyStringExactLengthWithFuncValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyStringExactLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringExactLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringExactLengthWithFuncValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyStringExactLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringExactLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringExactLengthWithFuncValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyStringExactLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringExactLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringExactLengthWithFuncValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyStringExactLengthWithFuncValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [PropertyStringExactLengthWithFuncValidatorRule\(Func&lt;TModel,int&gt;\)](PropertyStringExactLengthWithFuncValidatorRule_TModel_..ctor.FUBKVAQP5Z6UL7J5GSNHY4EJ.md 'Cat\.Validators\.Rules\.PropertyStringExactLengthWithFuncValidatorRule\<TModel\>\.PropertyStringExactLengthWithFuncValidatorRule\(System\.Func\<TModel,int\>\)') | Passes when the text has exactly the length taken from the model\. A `null` string passes\. Fails with [ExactLength](CatValidatorErrorDefinitions.ExactLength.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExactLength') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(string, string, TModel\)](PropertyStringExactLengthWithFuncValidatorRule_TModel_.Validate.V0HM1Z1ZUPEWZ2M4KSMTW2JB7.md 'Cat\.Validators\.Rules\.PropertyStringExactLengthWithFuncValidatorRule\<TModel\>\.Validate\(string, string, TModel\)') | |
