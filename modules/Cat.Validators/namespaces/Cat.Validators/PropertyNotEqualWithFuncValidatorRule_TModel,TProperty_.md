<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\> Class

Passes when the value doesn't equal another property of the model\.
Fails with [NotEqual](CatValidatorErrorDefinitions.NotEqual.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.NotEqual') otherwise\.

```csharp
internal class PropertyNotEqualWithFuncValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyNotEqualWithFuncValidatorRule\(Expression&lt;Func&lt;TModel,TProperty&gt;&gt;, IEqualityComparer&lt;TProperty&gt;\)](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_..ctor.BCF8L85E9DAO6ONYYA2CFQSQE.md 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.PropertyNotEqualWithFuncValidatorRule\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, System\.Collections\.Generic\.IEqualityComparer\<TProperty\>\)') | Passes when the value doesn't equal another property of the model\. Fails with [NotEqual](CatValidatorErrorDefinitions.NotEqual.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.NotEqual') otherwise\. |

| Fields | |
| :--- | :--- |
| [\_comparer](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_._comparer.md 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.\_comparer') | |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyNotEqualWithFuncValidatorRule_TModel,TProperty_.Validate.9WVIR8VGAMKQQOIGFJLIHBZE5.md 'Cat\.Validators\.Rules\.PropertyNotEqualWithFuncValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
