<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\> Class

Passes when the value is greater than the lower bound and less than the upper bound\.
Both bounds come from the model and your own comparer orders the values\.
Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\.

```csharp
internal class PropertyExclusiveBetweenWithFuncAndComparerValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\(Func&lt;TModel,TProperty&gt;, Func&lt;TModel,TProperty&gt;, IComparer&lt;TProperty&gt;\)](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_..ctor.UN48AQFFSI7L1PRE91B4XRJ0E.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\(System\.Func\<TModel,TProperty\>, System\.Func\<TModel,TProperty\>, System\.Collections\.Generic\.IComparer\<TProperty\>\)') | Passes when the value is greater than the lower bound and less than the upper bound\. Both bounds come from the model and your own comparer orders the values\. Fails with [ExclusiveBetween](CatValidatorErrorDefinitions.ExclusiveBetween.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.ExclusiveBetween') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyExclusiveBetweenWithFuncAndComparerValidatorRule_TModel,TProperty_.Validate.M333D6VEQ8748ZSTYVDCVJCRB.md 'Cat\.Validators\.Rules\.PropertyExclusiveBetweenWithFuncAndComparerValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
