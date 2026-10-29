<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## ModelMustValidatorRule\<TModel\> Class

Checks the whole model with your own code\.

```csharp
internal class ModelMustValidatorRule<TModel> : Cat.Validators.CatValidatorModelRuleBase<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.ModelMustValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](ModelMustValidatorRule_TModel_.md#Cat.Validators.Rules.ModelMustValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; [Cat\.Validators\.CatValidatorModelRuleBase&lt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>')[TModel](ModelMustValidatorRule_TModel_.md#Cat.Validators.Rules.ModelMustValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>') &#129106; ModelMustValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [ModelMustValidatorRule\(Func&lt;TModel,List&lt;ICatValidatorError&gt;&gt;\)](ModelMustValidatorRule_TModel_..ctor.14EHNGQVKXH6I2OCTJN78M598.md 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>\.ModelMustValidatorRule\(System\.Func\<TModel,System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\)') | Checks the whole model with your own code\. |

| Methods | |
| :--- | :--- |
| [Validate\(TModel\)](ModelMustValidatorRule_TModel_.Validate.NSP625J6MZTAJL5VES09QI7R.md 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>\.Validate\(TModel\)') | |
