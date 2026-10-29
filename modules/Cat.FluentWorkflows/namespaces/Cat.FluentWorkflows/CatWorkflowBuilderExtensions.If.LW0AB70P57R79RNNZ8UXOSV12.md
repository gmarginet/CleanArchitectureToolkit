<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Extensions](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') > [CatWorkflowBuilderExtensions](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.If\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Func\<TWorkflowState,bool\>, Action\<ICatWorkflowBuilder\<TWorkflowState\>\>, Action\<ICatWorkflowBuilder\<TWorkflowState\>\>\) Method

Adds a step that runs one of two lists of steps, depending on a condition\.

```csharp
public static void If<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Func<TWorkflowState,bool> condition, System.Action<Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState>> buildThen, System.Action<Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState>>? buildElse=null)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.If_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.If_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.If.LW0AB70P57R79RNNZ8UXOSV12.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.If_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.If\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,bool\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.If_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).condition'></a>

`condition` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.If.LW0AB70P57R79RNNZ8UXOSV12.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.If_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.If\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,bool\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the workflow state\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.If_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).buildThen'></a>

`buildThen` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.If.LW0AB70P57R79RNNZ8UXOSV12.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.If_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.If\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,bool\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the steps to run when the condition is `true`\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.If_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).buildElse'></a>

`buildElse` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.If.LW0AB70P57R79RNNZ8UXOSV12.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.If_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.If\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,bool\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the steps to run when the condition is `false`\. Leave it out to do nothing\.