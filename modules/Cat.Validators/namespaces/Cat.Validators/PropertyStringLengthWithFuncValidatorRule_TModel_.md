<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyStringLengthWithFuncValidatorRule\<TModel\> Class

Passes when the text length is between a minimum and a maximum taken from the model\. A `null` string passes\.
Fails with [Length](CatValidatorErrorDefinitions.Length.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Length') otherwise\.

```csharp
internal class PropertyStringLengthWithFuncValidatorRule<TModel> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, string>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyStringLengthWithFuncValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyStringLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringLengthWithFuncValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyStringLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringLengthWithFuncValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyStringLengthWithFuncValidatorRule_TModel_.md#Cat.Validators.Rules.PropertyStringLengthWithFuncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.PropertyStringLengthWithFuncValidatorRule\<TModel\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyStringLengthWithFuncValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [PropertyStringLengthWithFuncValidatorRule\(Func&lt;TModel,int&gt;, Func&lt;TModel,int&gt;\)](PropertyStringLengthWithFuncValidatorRule_TModel_..ctor.YCPQ54B2MT98781SOD0CH1DV5.md 'Cat\.Validators\.Rules\.PropertyStringLengthWithFuncValidatorRule\<TModel\>\.PropertyStringLengthWithFuncValidatorRule\(System\.Func\<TModel,int\>, System\.Func\<TModel,int\>\)') | Passes when the text length is between a minimum and a maximum taken from the model\. A `null` string passes\. Fails with [Length](CatValidatorErrorDefinitions.Length.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Length') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(string, string, TModel\)](PropertyStringLengthWithFuncValidatorRule_TModel_.Validate.7DGG5922CWI11YPW2EN4XI462.md 'Cat\.Validators\.Rules\.PropertyStringLengthWithFuncValidatorRule\<TModel\>\.Validate\(string, string, TModel\)') | |
