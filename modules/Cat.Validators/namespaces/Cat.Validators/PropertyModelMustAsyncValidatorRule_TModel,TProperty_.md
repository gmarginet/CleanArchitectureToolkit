<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyModelMustAsyncValidatorRule\<TModel,TProperty\> Class

Checks a property with your own async code that can also look at the whole model\.

```csharp
internal class PropertyModelMustAsyncValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleAsyncBase<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') &#129106; PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyModelMustAsyncValidatorRule\(Func&lt;TProperty,string,TModel,CancellationToken,Task&lt;List&lt;ICatValidatorError&gt;&gt;&gt;\)](PropertyModelMustAsyncValidatorRule_TModel,TProperty_..ctor.1CDGVL97AVMV3NLTS1I0AITY1.md 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>\.PropertyModelMustAsyncValidatorRule\(System\.Func\<TProperty,string,TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)') | Checks a property with your own async code that can also look at the whole model\. |

| Methods | |
| :--- | :--- |
| [ValidateAsync\(TProperty, string, TModel, CancellationToken\)](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.ValidateAsync.72TMCGRTKIPF6GG36LBX1AHQD.md 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, System\.Threading\.CancellationToken\)') | |
