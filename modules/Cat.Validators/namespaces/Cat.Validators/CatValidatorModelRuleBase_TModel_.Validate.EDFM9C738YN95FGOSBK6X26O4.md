<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorModelRuleBase&lt;TModel&gt;](CatValidatorModelRuleBase_TModel_.md 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>')

## CatValidatorModelRuleBase\<TModel\>\.Validate\(TModel\) Method

Runs the rule\.

```csharp
protected abstract System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError> Validate(TModel model);
```
#### Parameters

<a name='Cat.Validators.CatValidatorModelRuleBase_TModel_.Validate(TModel).model'></a>

`model` [TModel](CatValidatorModelRuleBase_TModel_.md#Cat.Validators.CatValidatorModelRuleBase_TModel_.TModel 'Cat\.Validators\.CatValidatorModelRuleBase\<TModel\>\.TModel')

The model to check\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](..\Cat.Validators.Abstractions\ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The failures found\. Return [Valid\(\)](CatValidatorResult.Valid().md 'Cat\.Validators\.CatValidatorResult\.Valid\(\)') when the model is valid\.