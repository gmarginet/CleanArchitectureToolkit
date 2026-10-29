<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyEqualWithFuncValidatorRule\<TModel,TProperty\> Class

Passes when the value equals another property of the model\.
Fails with [Equal](CatValidatorErrorDefinitions.Equal.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Equal') otherwise\.

```csharp
internal class PropertyEqualWithFuncValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyEqualWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyEqualWithFuncValidatorRule\(Expression&lt;Func&lt;TModel,TProperty&gt;&gt;, IEqualityComparer&lt;TProperty&gt;\)](PropertyEqualWithFuncValidatorRule_TModel,TProperty_..ctor.KEA4PMYRIMYGQ01SWTY7W1J31.md 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.PropertyEqualWithFuncValidatorRule\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>, System\.Collections\.Generic\.IEqualityComparer\<TProperty\>\)') | Passes when the value equals another property of the model\. Fails with [Equal](CatValidatorErrorDefinitions.Equal.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.Equal') otherwise\. |

| Fields | |
| :--- | :--- |
| [\_comparer](PropertyEqualWithFuncValidatorRule_TModel,TProperty_._comparer.md 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.\_comparer') | |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyEqualWithFuncValidatorRule_TModel,TProperty_.Validate.OJRRW20BPGD18ZK16E7DQUD4C.md 'Cat\.Validators\.Rules\.PropertyEqualWithFuncValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
