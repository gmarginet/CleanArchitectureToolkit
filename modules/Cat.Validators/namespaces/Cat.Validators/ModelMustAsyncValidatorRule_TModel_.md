<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules')

## ModelMustAsyncValidatorRule\<TModel\> Class

Checks the whole model with your own async code\.

```csharp
internal class ModelMustAsyncValidatorRule<TModel> : Cat.Validators.CatValidatorModelRuleAsyncBase<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.Rules.ModelMustAsyncValidatorRule_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](ModelMustAsyncValidatorRule_TModel_.md#Cat.Validators.Rules.ModelMustAsyncValidatorRule_TModel_.TModel 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; ModelMustAsyncValidatorRule\<TModel\>

| Constructors | |
| :--- | :--- |
| [ModelMustAsyncValidatorRule\(Func&lt;TModel,CancellationToken,Task&lt;List&lt;ICatValidatorError&gt;&gt;&gt;\)](ModelMustAsyncValidatorRule_TModel_..ctor.0QDR9YXMZA86BCQS78BWIH25B.md 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>\.ModelMustAsyncValidatorRule\(System\.Func\<TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)') | Checks the whole model with your own async code\. |

| Methods | |
| :--- | :--- |
| [ValidateAsync\(TModel, CancellationToken\)](ModelMustAsyncValidatorRule_TModel_.ValidateAsync.E4M9Z45B1WFUY7KVCLBBQ86P6.md 'Cat\.Validators\.Rules\.ModelMustAsyncValidatorRule\<TModel\>\.ValidateAsync\(TModel, System\.Threading\.CancellationToken\)') | |
