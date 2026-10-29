<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators](Cat.Validators.md 'Cat\.Validators') > [CatValidatorPropertyRuleAsyncBase&lt;TModel,TProperty&gt;](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')

## CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ValidateAsync Method

| Overloads | |
| :--- | :--- |
| [ValidateAsync\(TModel, CancellationToken\)](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TModel,System.Threading.CancellationToken) 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ValidateAsync\(TModel, System\.Threading\.CancellationToken\)') | Runs the rule\. |
| [ValidateAsync\(TProperty, string, TModel, CancellationToken\)](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken) 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, System\.Threading\.CancellationToken\)') | Runs the rule against the property value\. |

<a name='Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TModel,System.Threading.CancellationToken)'></a>

## CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ValidateAsync\(TModel, CancellationToken\) Method

Runs the rule\.

```csharp
public override System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> ValidateAsync(TModel model, System.Threading.CancellationToken ct);
```
#### Parameters

<a name='Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TModel,System.Threading.CancellationToken).model'></a>

`model` [TModel](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.TModel')

The model to check\.

<a name='Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TModel,System.Threading.CancellationToken).ct'></a>

`ct` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [ValidateAsync\(TModel, CancellationToken\)](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRule_TModel_.ValidateAsync.OP5PLME0CZWG5EGZ8QRKTRTC6.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRule\`1\.ValidateAsync\(\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The failures found\. The list is empty when the model is valid\.

<a name='Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken)'></a>

## CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.ValidateAsync\(TProperty, string, TModel, CancellationToken\) Method

Runs the rule against the property value\.

```csharp
protected abstract System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>> ValidateAsync(TProperty value, string fieldName, TModel model, System.Threading.CancellationToken ct);
```
#### Parameters

<a name='Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).value'></a>

`value` [TProperty](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.TProperty 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.TProperty')

The value of the property\.

<a name='Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).fieldName'></a>

`fieldName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the property\.

<a name='Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).model'></a>

`model` [TModel](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md#Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.TModel 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>\.TModel')

The model that owns the property\.

<a name='Cat.Validators.CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.ValidateAsync(TProperty,string,TModel,System.Threading.CancellationToken).ct'></a>

`ct` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The failures found\. Return [Valid\(\)](CatValidatorResult.Valid().md 'Cat\.Validators\.CatValidatorResult\.Valid\(\)') when the value is valid\.