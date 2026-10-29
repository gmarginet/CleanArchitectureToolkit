<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\> Class

Passes when the value is less than or equal to another property of the model\.
Fails with [LessThanOrEqualTo](CatValidatorErrorDefinitions.LessThanOrEqualTo.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.LessThanOrEqualTo') otherwise\.

```csharp
internal class PropertyLessThanOrEqualToWithFuncValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyLessThanOrEqualToWithFuncValidatorRule\(Expression&lt;Func&lt;TModel,TProperty&gt;&gt;\)](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_..ctor.JBPPEFIGKX4DQ5YKERLIO8ZEE.md 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.PropertyLessThanOrEqualToWithFuncValidatorRule\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>\)') | Passes when the value is less than or equal to another property of the model\. Fails with [LessThanOrEqualTo](CatValidatorErrorDefinitions.LessThanOrEqualTo.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.LessThanOrEqualTo') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyLessThanOrEqualToWithFuncValidatorRule_TModel,TProperty_.Validate.18KUC2191JS3IMDKCBD9YGTB.md 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToWithFuncValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
