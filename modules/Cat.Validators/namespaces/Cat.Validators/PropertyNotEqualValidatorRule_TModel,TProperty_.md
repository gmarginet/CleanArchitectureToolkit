<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyNotEqualValidatorRule\<TModel,TProperty\> Class

Passes when the value doesn't equal the given value\.
Fails with [NotEqual](CatValidatorErrorDefinitions.NotEqual.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.NotEqual') otherwise\.

```csharp
internal class PropertyNotEqualValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyNotEqualValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyNotEqualValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyNotEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEqualValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyNotEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEqualValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyNotEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNotEqualValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyNotEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEqualValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyNotEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNotEqualValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') → PropertyNotEqualValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyNotEqualValidatorRule\(TProperty, IEqualityComparer&lt;TProperty&gt;\)](PropertyNotEqualValidatorRule_TModel,TProperty_..ctor.7J5UBVILHAJCOV8V39LNFKD33.md 'Cat\.Validators\.Rules\.PropertyNotEqualValidatorRule\<TModel,TProperty\>\.PropertyNotEqualValidatorRule\(TProperty, System\.Collections\.Generic\.IEqualityComparer\<TProperty\>\)') | Passes when the value doesn't equal the given value\. Fails with [NotEqual](CatValidatorErrorDefinitions.NotEqual.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.NotEqual') otherwise\. |

| Fields | |
| :--- | :--- |
| [\_comparer](PropertyNotEqualValidatorRule_TModel,TProperty_._comparer.md 'Cat\.Validators\.Rules\.PropertyNotEqualValidatorRule\<TModel,TProperty\>\.\_comparer') | |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyNotEqualValidatorRule_TModel,TProperty_.Validate.OGG4ZOYE8AXBM79B0YXJ1UOU6.md 'Cat\.Validators\.Rules\.PropertyNotEqualValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
