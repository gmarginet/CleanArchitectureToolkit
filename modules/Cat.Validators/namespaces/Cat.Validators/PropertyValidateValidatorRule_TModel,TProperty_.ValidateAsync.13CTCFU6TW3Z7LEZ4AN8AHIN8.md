<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Rules](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') > [PropertyValidateValidatorRule&lt;TModel,TProperty&gt;](PropertyValidateValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyValidateValidatorRule\<TModel,TProperty\>')

## PropertyValidateValidatorRule\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, CancellationToken\) Method

```csharp
protected override System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> ValidateAsync(TProperty value, string fieldName, TModel model, System.Threading.CancellationToken ct);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).value'></a>

`value` [TProperty](PropertyValidateValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyValidateValidatorRule\<TModel,TProperty\>\.TProperty')

<a name='Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).fieldName'></a>

`fieldName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).model'></a>

`model` [TModel](PropertyValidateValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyValidateValidatorRule\<TModel,TProperty\>\.TModel')

<a name='Cat.Validators.Rules.PropertyValidateValidatorRule_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).ct'></a>

`ct` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](..\Cat.Validators.Abstractions\ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')