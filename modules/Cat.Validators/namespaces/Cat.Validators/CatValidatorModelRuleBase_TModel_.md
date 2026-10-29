<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators')

## CatValidatorModelRuleBase\<TModel\> Class

Base class for a model rule that works synchronously\.
Derive from it when you write your own rule and implement [Validate\(TModel\)](CatValidatorModelRuleBase_TModel_.Validate.EDFM9C738YN95FGOSBK6X26O4.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.Validate\(TModel\)')\.

```csharp
public abstract class CatValidatorModelRuleBase<TModel> : Cat.Validators.CatValidatorModelRuleAsyncBase<TModel>
    where TModel : class
```
#### Type parameters

<a name='Cat.Validators.CatValidatorModelRuleBase_TModel_.TModel'></a>

`TModel`

The type being validated\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Cat\.Validators\.CatValidatorModelRuleAsyncBase&lt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>')[TModel](CatValidatorModelRuleBase_TModel_.md#Cat.Validators.CatValidatorModelRuleBase_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.TModel')[&gt;](CatValidatorModelRuleAsyncBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleAsyncBase\<TModel\>') &#129106; CatValidatorModelRuleBase\<TModel\>

Derived  
&#8627; [ModelMustValidatorRule&lt;TModel&gt;](ModelMustValidatorRule_TModel_.md 'Cat\.Validators\.Rules\.ModelMustValidatorRule\<TModel\>')

| Methods | |
| :--- | :--- |
| [Validate\(TModel\)](CatValidatorModelRuleBase_TModel_.Validate.EDFM9C738YN95FGOSBK6X26O4.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.Validate\(TModel\)') | Runs the rule\. |
| [ValidateAsync\(TModel, CancellationToken\)](CatValidatorModelRuleBase_TModel_.ValidateAsync.ZOFUXL5PEI6F097RSRSC7PZOC.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.ValidateAsync\(TModel, System\.Threading\.CancellationToken\)') | Runs the rule\. |
