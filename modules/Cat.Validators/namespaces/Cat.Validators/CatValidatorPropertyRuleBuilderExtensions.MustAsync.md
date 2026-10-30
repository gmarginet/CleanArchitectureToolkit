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
  
##### >> [Cat\.Validators Assembly](index.md 'index') >> [Cat\.Validators\.Extensions Namespace](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') >> [CatValidatorPropertyRuleBuilderExtensions Class](CatValidatorPropertyRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions')

## CatValidatorPropertyRuleBuilderExtensions\.MustAsync Method

| Overloads | |
| :--- | :--- |
| [MustAsync&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Func&lt;TProperty,string,CancellationToken,Task&lt;List&lt;ICatValidatorError&gt;&gt;&gt;\)](CatValidatorPropertyRuleBuilderExtensions.MustAsync.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)') | Adds an async rule that checks the property with your own code\. You build the errors yourself, so the other options don't apply\. |
| [MustAsync&lt;TModel,TProperty&gt;\(this ICatValidatorPropertyRuleBuilder&lt;TModel,TProperty&gt;, Func&lt;TProperty,string,TModel,CancellationToken,Task&lt;List&lt;ICatValidatorError&gt;&gt;&gt;\)](CatValidatorPropertyRuleBuilderExtensions.MustAsync.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___) 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)') | Adds an async rule that checks the property with your own code and can look at the whole model\. You build the errors yourself, so the other options don't apply\. |

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Func\<TProperty,string,CancellationToken,Task\<List\<ICatValidatorError\>\>\>\) Method

Adds an async rule that checks the property with your own code\.
You build the errors yourself, so the other options don't apply\.

```csharp
public static void MustAsync<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Func<TProperty,string,System.Threading.CancellationToken,System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>>> predicate)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MustAsync.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MustAsync.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MustAsync.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)\.TProperty')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-4 'System\.Func\`4')

Gets the value, the field name and a cancellation token\. Returns the failures, or an empty list\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___)'></a>

## CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, Func\<TProperty,string,TModel,CancellationToken,Task\<List\<ICatValidatorError\>\>\>\) Method

Adds an async rule that checks the property with your own code and can look at the whole model\.
You build the errors yourself, so the other options don't apply\.

```csharp
public static void MustAsync<TModel,TProperty>(this Cat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder<TModel,TProperty> builder, System.Func<TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>>> predicate)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TModel'></a>

`TModel`

The type being validated\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TProperty'></a>

`TProperty`

The type of the property\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TModel](CatValidatorPropertyRuleBuilderExtensions.MustAsync.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)\.TModel')[,](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MustAsync.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)\.TProperty')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorPropertyRuleBuilder_TModel,TProperty_.md 'Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\`2')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[TProperty](CatValidatorPropertyRuleBuilderExtensions.MustAsync.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TProperty 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)\.TProperty')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[TModel](CatValidatorPropertyRuleBuilderExtensions.MustAsync.md#Cat.Validators.Extensions.CatValidatorPropertyRuleBuilderExtensions.MustAsync_TModel,TProperty_(thisCat.Validators.Abstractions.ICatValidatorPropertyRuleBuilder_TModel,TProperty_,System.Func_TProperty,string,TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TModel 'Cat\.Validators\.Extensions\.CatValidatorPropertyRuleBuilderExtensions\.MustAsync\<TModel,TProperty\>\(this Cat\.Validators\.Abstractions\.ICatValidatorPropertyRuleBuilder\<TModel,TProperty\>, System\.Func\<TProperty,string,TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-5 'System\.Func\`5')

Gets the value, the field name, the model and a cancellation token\. Returns the failures, or an empty list\.