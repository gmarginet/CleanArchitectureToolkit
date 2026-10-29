<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyEqualValidatorRule\<TModel,TProperty\> Class

Passes when the value equals the given value\.
Fails with [Equal](CatValidatorErrorDefinitions.Equal.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Equal') otherwise\.

```csharp
internal class PropertyEqualValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyEqualValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyEqualValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyEqualValidatorRule\(TProperty, IEqualityComparer&lt;TProperty&gt;\)](PropertyEqualValidatorRule_TModel,TProperty_..ctor.KUGORPES236F5IMUVHKY7YEWB.md 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>\.PropertyEqualValidatorRule\(TProperty, System\.Collections\.Generic\.IEqualityComparer\<TProperty\>\)') | Passes when the value equals the given value\. Fails with [Equal](CatValidatorErrorDefinitions.Equal.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Equal') otherwise\. |

| Fields | |
| :--- | :--- |
| [\_comparer](PropertyEqualValidatorRule_TModel,TProperty_._comparer.md 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>\.\_comparer') | |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyEqualValidatorRule_TModel,TProperty_.Validate.2V7C8D7ESQ3NQDDGW7XLR0ME.md 'Cat\.Validators\.Rules\.PropertyEqualValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
