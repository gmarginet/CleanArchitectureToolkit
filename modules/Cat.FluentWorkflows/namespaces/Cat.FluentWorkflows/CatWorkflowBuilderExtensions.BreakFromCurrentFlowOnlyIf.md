<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Extensions](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') > [CatWorkflowBuilderExtensions](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf Method

| Overloads | |
| :--- | :--- |
| [BreakFromCurrentFlowOnlyIf&lt;TWorkflowState&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Func&lt;ILogger,TWorkflowState,bool&gt;\)](CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,bool\>\)') | Adds a step that ends the workflow when the check returns `true`, using a logger\. The caller of the workflow goes on as if it succeeded\. |
| [BreakFromCurrentFlowOnlyIf&lt;TWorkflowState&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Func&lt;TWorkflowState,bool&gt;\)](CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,bool\>\)') | Adds a step that ends the workflow when the check returns `true`\. The caller of the workflow goes on as if it succeeded\. |

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_)'></a>

## CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Func\<ILogger,TWorkflowState,bool\>\) Method

Adds a step that ends the workflow when the check returns `true`, using a logger\.
The caller of the workflow goes on as if it succeeded\.

```csharp
public static void BreakFromCurrentFlowOnlyIf<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Func<Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool> check)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,bool\>\)\.TWorkflowState')[&gt;](../Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_).check'></a>

`check` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TWorkflowState](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,bool\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

Gets the logger and the workflow state\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_)'></a>

## CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Func\<TWorkflowState,bool\>\) Method

Adds a step that ends the workflow when the check returns `true`\.
The caller of the workflow goes on as if it succeeded\.

```csharp
public static void BreakFromCurrentFlowOnlyIf<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Func<TWorkflowState,bool> check)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,bool\>\)\.TWorkflowState')[&gt;](../Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_).check'></a>

`check` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.BreakFromCurrentFlowOnlyIf_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,bool_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.BreakFromCurrentFlowOnlyIf\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,bool\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the workflow state\.