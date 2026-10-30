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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.VALIDATORS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Rules Namespace](Cat.Validators.Rules.md 'Cat\.Validators\.Rules') >> [PropertyModelMustAsyncValidatorRule&lt;TModel,TProperty&gt; Class](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.md 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>')

## PropertyModelMustAsyncValidatorRule\(Func\<TProperty,string,TModel,CancellationToken,Task\<List\<ICatValidatorError\>\>\>\) Constructor

Checks a property with your own async code that can also look at the whole model\.

```csharp
public PropertyModelMustAsyncValidatorRule(System.Func<TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>>> predicate);
```
#### Parameters

<a name='Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.PropertyModelMustAsyncValidatorRule(System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[TProperty](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.TProperty 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>\.TProperty')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[TModel](PropertyModelMustAsyncValidatorRule_TModel,TProperty_.md#Cat.Validators.Rules.PropertyModelMustAsyncValidatorRule_TModel,TProperty_.TModel 'Cat\.Validators\.Rules\.PropertyModelMustAsyncValidatorRule\<TModel,TProperty\>\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')