<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\> Class

Passes when the value is less than or equal to the given value\.
Fails with [LessThanOrEqualTo](CatValidatorErrorDefinitions.LessThanOrEqualTo.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.LessThanOrEqualTo') otherwise\.

```csharp
internal class PropertyLessThanOrEqualToValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyLessThanOrEqualToValidatorRule\(TProperty\)](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_..ctor.PWF1QG20GJ7PQBNUXCY54WRCA.md 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>\.PropertyLessThanOrEqualToValidatorRule\(TProperty\)') | Passes when the value is less than or equal to the given value\. Fails with [LessThanOrEqualTo](CatValidatorErrorDefinitions.LessThanOrEqualTo.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.LessThanOrEqualTo') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyLessThanOrEqualToValidatorRule_TModel,TProperty_.Validate.DWBUB1NXAGUFEXXRCCMIU9T1C.md 'Cat\.Validators\.Rules\.PropertyLessThanOrEqualToValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
