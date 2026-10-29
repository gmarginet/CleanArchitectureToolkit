<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\> Class

Passes when the value is greater than the lower bound and less than the upper bound, using your own comparer\.
Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\.

```csharp
internal class PropertyExclusiveBetweenWithComparerValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyExclusiveBetweenWithComparerValidatorRule\(TProperty, TProperty, IComparer&lt;TProperty&gt;\)](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_..ctor.5A61ODA583QIADP26OZG6L1SC.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.PropertyExclusiveBetweenWithComparerValidatorRule\(TProperty, TProperty, System\.Collections\.Generic\.IComparer\<TProperty\>\)') | Passes when the value is greater than the lower bound and less than the upper bound, using your own comparer\. Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyExclusiveBetweenWithComparerValidatorRule_TModel,TProperty_.Validate.3AA8FSFTHDSH0RZYKEIRD72L2.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithComparerValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
