<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## PropertyMustValidatorRule\<TModel,TProperty\> Class

Checks a property with your own code\.

```csharp
internal class PropertyMustValidatorRule<TModel,TProperty> : Cat.Validators.CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.PropertyMustValidatorRule_TModel,TProperty_.TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Rules.PropertyMustValidatorRule_TModel,TProperty_.TProperty'></a>

`TProperty`

The type of the property\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](PropertyMustValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMustValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyMustValidatorRule\<TModel,TProperty\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') → [Cat\.Validators\.CatValidatorPropertyRuleAsyncBase&lt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TModel](PropertyMustValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMustValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyMustValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')[TProperty](PropertyMustValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMustValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyMustValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>') → [Cat\.Validators\.CatValidatorPropertyRuleBase&lt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TModel](PropertyMustValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMustValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyMustValidatorRule\<TModel,TProperty\>\.TModel')[,](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')[TProperty](PropertyMustValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyMustValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyMustValidatorRule\<TModel,TProperty\>\.TProperty')[&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>') → PropertyMustValidatorRule\<TModel,TProperty\>

| Constructors | |
| :--- | :--- |
| [PropertyMustValidatorRule\(Func&lt;TProperty,string,List&lt;ICatValidatorError&gt;&gt;\)](PropertyMustValidatorRule_TModel,TProperty_..ctor.8SUKQMGSDIH0TNGZR9EKND89C.md 'Cat\.Validators\.Rules\.PropertyMustValidatorRule\<TModel,TProperty\>\.PropertyMustValidatorRule\(System\.Func\<TProperty,string,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)') | Checks a property with your own code\. |

| Methods | |
| :--- | :--- |
| [Validate\(TProperty, string, TModel\)](PropertyMustValidatorRule_TModel,TProperty_.Validate.5YNT2CPBF3M2GO9Y41AJXCMAD.md 'Cat\.Validators\.Rules\.PropertyMustValidatorRule\<TModel,TProperty\>\.Validate\(TProperty, string, TModel\)') | |
