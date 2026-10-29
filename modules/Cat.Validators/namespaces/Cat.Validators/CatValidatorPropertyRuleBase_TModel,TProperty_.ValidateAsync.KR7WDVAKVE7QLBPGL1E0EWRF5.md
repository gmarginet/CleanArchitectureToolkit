<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorPropertyRuleBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>')

## CatValidatorPropertyRuleBase\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, CancellationToken\) Method

Runs the rule against the property value\.

```csharp
protected override System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> ValidateAsync(TProperty value, string fieldName, TModel model, System.Threading.CancellationToken ct);
```
#### Parameters

<a name='Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).value'></a>

`value` [TProperty](CatValidatorPropertyRuleBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.TProperty 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.TProperty')

The value of the property\.

<a name='Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).fieldName'></a>

`fieldName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the property\.

<a name='Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).model'></a>

`model` [TModel](CatValidatorPropertyRuleBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleBase\<TModel,TProperty\>\.TModel')

The model that owns the property\.

<a name='Cat.Validators.CatValidatorPropertyRuleBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).ct'></a>

`ct` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](..\Cat.Validators.Abstractions\ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The failures found\. Return [Valid\(\)](CatValidatorResult.Valid().md 'Cat\.Validators\.CatValidatorResult\.Valid\(\)') when the value is valid\.