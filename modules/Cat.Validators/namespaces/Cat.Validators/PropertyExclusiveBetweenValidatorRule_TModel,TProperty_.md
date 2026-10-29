<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\> Class

Passes when the value is greater than the lower bound and less than the upper bound\.
Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\.

```csharp
internal class PropertyExclusiveBetweenValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyExclusiveBetweenValidatorRule\(TProperty, TProperty\)](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_..ctor.TKYYKCTTJ89Y4H08DSZXSTA89.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.PropertyExclusiveBetweenValidatorRule\(TProperty, TProperty\)') | Passes when the value is greater than the lower bound and less than the upper bound\. Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyExclusiveBetweenValidatorRule_TModel,TProperty_.Validate.UCP4RUYS3V75A08C1K7UJ5SI6.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
