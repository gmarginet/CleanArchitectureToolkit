<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\> Class

Passes when the value is greater than another property of the model\.
Fails with [GreaterThan](CatValidatorErrorDefinitions.GreaterThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThan') otherwise\.

```csharp
internal class PropertyGreaterThanWithFuncValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : System.IComparable<TProperty>, System.IComparable
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') &#129106; PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyGreaterThanWithFuncValidatorRule\(Expression&lt;Func&lt;TModel,TProperty&gt;&gt;\)](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_..ctor.VEP56ILTT7DU3S5JVWY508IO5.md 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>\.PropertyGreaterThanWithFuncValidatorRule\(System\.Linq\.Expressions\.Expression\<System\.Func\<TModel,TProperty\>\>\)') | Passes when the value is greater than another property of the model\. Fails with [GreaterThan](CatValidatorErrorDefinitions.GreaterThan.md 'Cat\.Validators\.CatValidatorErrorDefinitions\.GreaterThan') otherwise\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyGreaterThanWithFuncValidatorRule_TModel,TProperty_.Validate.KK1AC58VVF8KQGHHE3VS7JTMA.md 'Cat\.Validators\.Rules\.PropertyGreaterThanWithFuncValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
