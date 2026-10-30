<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators Namespace](Cat.Validators.md 'Cat\.Validators') >> [CatValidatorPropertyRuleAsyncBase&lt;TModel,TProperty&gt; Class](CatValidatorPropertyRuleAsyncBase_TModel,TProperty_.md 'Cat\.Validators\.CatValidatorPropertyRuleAsyncBase\<TModel,TProperty\>')

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