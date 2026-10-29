<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') > [CatValidatorModelRuleBuilderExtensions](CatValidatorModelRuleBuilderExtensions.md 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions')

## CatValidatorModelRuleBuilderExtensions\.MustAsync\<TModel\>\(this ICatValidatorModelRuleBuilder\<TModel\>, Func\<TModel,CancellationToken,Task\<List\<ICatValidatorError\>\>\>\) Method

Adds an async rule that checks the whole model with your own code\.

```csharp
public static void MustAsync<TModel>(this Cat.Validators.Abstractions.ICatValidatorModelRuleBuilder<TModel> builder, System.Func<TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task<System.Collections.Generic.List<Cat.Validators.Abstractions.ICatValidatorError>>> predicate)
    where TModel : class;
```
#### Type parameters

<a name='Cat.Validators.Extensions.CatValidatorModelRuleBuilderExtensions.MustAsync_TModel_(thisCat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_,System.Func_TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TModel'></a>

`TModel`

The type being validated\.
#### Parameters

<a name='Cat.Validators.Extensions.CatValidatorModelRuleBuilderExtensions.MustAsync_TModel_(thisCat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_,System.Func_TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).builder'></a>

`builder` [Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder&lt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')[TModel](CatValidatorModelRuleBuilderExtensions.MustAsync.KSZGXCJ7IYV0EP10K4VUN8J86.md#Cat.Validators.Extensions.CatValidatorModelRuleBuilderExtensions.MustAsync_TModel_(thisCat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_,System.Func_TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TModel 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions\.MustAsync\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>, System\.Func\<TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)\.TModel')[&gt;](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorModelRuleBuilder_TModel_.md 'Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\`1')

The builder to add the rule to\.

<a name='Cat.Validators.Extensions.CatValidatorModelRuleBuilderExtensions.MustAsync_TModel_(thisCat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_,System.Func_TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).predicate'></a>

`predicate` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TModel](CatValidatorModelRuleBuilderExtensions.MustAsync.KSZGXCJ7IYV0EP10K4VUN8J86.md#Cat.Validators.Extensions.CatValidatorModelRuleBuilderExtensions.MustAsync_TModel_(thisCat.Validators.Abstractions.ICatValidatorModelRuleBuilder_TModel_,System.Func_TModel,System.Threading.CancellationToken,System.Threading.Tasks.Task_System.Collections.Generic.List_Cat.Validators.Abstractions.ICatValidatorError___).TModel 'Cat\.Validators\.Extensions\.CatValidatorModelRuleBuilderExtensions\.MustAsync\<TModel\>\(this Cat\.Validators\.Abstractions\.ICatValidatorModelRuleBuilder\<TModel\>, System\.Func\<TModel,System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<System\.Collections\.Generic\.List\<Cat\.Validators\.Abstractions\.ICatValidatorError\>\>\>\)\.TModel')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatValidatorError](../../../Cat.Validators/namespaces/Cat.Validators.Abstractions/ICatValidatorError.md 'Cat\.Validators\.Abstractions\.ICatValidatorError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

Returns the failures it finds, or an empty list when the model is valid\.