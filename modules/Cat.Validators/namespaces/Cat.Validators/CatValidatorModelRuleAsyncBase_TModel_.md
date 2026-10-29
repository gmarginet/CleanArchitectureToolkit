<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators')

## CatValidatorModelRuleAsyncBase\<TModel\> Class

Base class for a model rule that needs async work\.
Derive from it when you write your own rule\. Use [CatValidatorModelRuleBase&lt;TModel&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>') for sync work\.

```csharp
public abstract class CatValidatorModelRuleAsyncBase<TModel> : Cat.Validators.Abstractions.ICatValidatorModelRule<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorModelRuleAsyncBase_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatValidatorModelRuleAsyncBase\<TModel\>

Derived  
&#8627; [CatValidatorModelRuleBase&lt;TModel&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>')  
&#8627; [CatValidatorPropertyRuleAsyncBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')  
&#8627; [ModelMustAsyncValidatorRule&lt;TModel&gt;](ModelMustAsyncValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>')

Implements [Cat\.Validators\.Abstractions\.ICatValidatorModelRule&lt;](..\Cat.Validators.Abstractions\ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1')[TModel](CatValidatorModelRuleAsyncBase_TModel_.md#Cat.Validators.CatValidatorModelRuleAsyncBase_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>\.TModel')[&gt;](..\Cat.Validators.Abstractions\ICatValidatorModelRule_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1')

| Properties | |
| :--- | :--- |
| [RulesConditionFuncAsyncList](CatValidatorModelRuleAsyncBase_TModel_.RulesConditionFuncAsyncList.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>\.RulesConditionFuncAsyncList') | Conditions that decide whether the rule runs\. The rule is skipped when any of them returns `false`\. |

| Methods | |
| :--- | :--- |
| [ValidateAsync\(TModel, CancellationToken\)](CatValidatorModelRuleAsyncBase_TModel_.ValidateAsync.SJ8T3ZY2PGV2DCY11AQNS4WO4.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>\.ValidateAsync\(TModel, System\.Threading\.CancellationToken\)') | Runs the rule\. |
