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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Extensions Namespace](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') >> [CatWorkflowBuilderExtensions Class](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.Run Method

| Overloads | |
| :--- | :--- |
| [Run&lt;TSubWorkflow,TSubWorkflowState,TWorkflowState&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;\)](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TSubWorkflow,TSubWorkflowState,TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)') | Adds a step that runs another workflow, the sub\-workflow, on its own state\. The state of the main workflow holds the state of the sub\-workflow in [WorkflowState](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatHasSubWorkflowState_TSubWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.Abstractions\.ICatHasSubWorkflowState\`1\.WorkflowState')\. A [BreakFromCurrentFlowOnly](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakFromCurrentFlowOnly 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakFromCurrentFlowOnly') inside the sub\-workflow ends only the sub\-workflow\. |
| [Run&lt;TWorkflowState,TStepBody&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;\)](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState,TStepBody_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState,TStepBody\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)') | Adds a step that runs your own step body\. Register the body with `AddCatFluentWorkflowsSteps`\. Give both type arguments, like `builder.Run<OrderState, CheckStockStep>()`\. |
| [Run&lt;TWorkflowState&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Action&lt;ILogger,TWorkflowState&gt;\)](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Microsoft.Extensions.Logging.ILogger,TWorkflowState_) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Action\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState\>\)') | Adds a step that runs your code with a logger\. The workflow always goes on with the next step\. |
| [Run&lt;TWorkflowState&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Action&lt;TWorkflowState&gt;\)](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_TWorkflowState_) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Action\<TWorkflowState\>\)') | Adds a step that runs your code\. The workflow always goes on with the next step\. |
| [Run&lt;TWorkflowState&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Func&lt;ILogger,TWorkflowState,ICatResponse&lt;CatStepExecutionResult&gt;&gt;\)](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,Cat\.Responses\.Abstractions\.ICatResponse\<Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\>\>\)') | Adds a step that runs your code with a logger and decides how the workflow goes on\. A succeeded response carries the [CatStepExecutionResult](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult') to use\. A failed response ends the workflow with [BreakCascade](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') and the errors\. |
| [Run&lt;TWorkflowState&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;, Func&lt;TWorkflowState,ICatResponse&lt;CatStepExecutionResult&gt;&gt;\)](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__) 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,Cat\.Responses\.Abstractions\.ICatResponse\<Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\>\>\)') | Adds a step that runs your code and decides how the workflow goes on\. A succeeded response carries the [CatStepExecutionResult](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult') to use\. A failed response ends the workflow with [BreakCascade](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') and the errors\. |

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_)'></a>

## CatWorkflowBuilderExtensions\.Run\<TSubWorkflow,TSubWorkflowState,TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>\) Method

Adds a step that runs another workflow, the sub\-workflow, on its own state\.
The state of the main workflow holds the state of the sub\-workflow in [WorkflowState](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatHasSubWorkflowState_TSubWorkflowState_.WorkflowState.md 'Cat\.FluentWorkflows\.Abstractions\.ICatHasSubWorkflowState\`1\.WorkflowState')\.
A [BreakFromCurrentFlowOnly](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakFromCurrentFlowOnly 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakFromCurrentFlowOnly') inside the sub\-workflow ends only the sub\-workflow\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatStepBuilder<TWorkflowState,Cat.FluentWorkflows.Steps.CatRunSubWorkflowStep<TWorkflowState,TSubWorkflow,TSubWorkflowState>> Run<TSubWorkflow,TSubWorkflowState,TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> workflowBuilder)
    where TSubWorkflow : Cat.FluentWorkflows.Abstractions.ICatWorkflow<TSubWorkflowState>
    where TSubWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TSubWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>, Cat.FluentWorkflows.Abstractions.ICatHasSubWorkflowState<TSubWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TSubWorkflow'></a>

`TSubWorkflow`

The workflow to run\. It must be registered\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TSubWorkflowState'></a>

`TSubWorkflowState`

The state of the sub\-workflow\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState'></a>

`TWorkflowState`

The state of the main workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).workflowBuilder'></a>

`workflowBuilder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TSubWorkflow,TSubWorkflowState,TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TSubWorkflow,TSubWorkflowState,TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep&lt;](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TSubWorkflow,TSubWorkflowState,TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[,](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')[TSubWorkflow](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TSubWorkflow 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TSubWorkflow,TSubWorkflowState,TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TSubWorkflow')[,](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')[TSubWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TSubWorkflow,TSubWorkflowState,TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TSubWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TSubWorkflow,TSubWorkflowState,TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TSubWorkflowState')[&gt;](CatRunSubWorkflowStep_TWorkflowState,TSubWorkflow,TSubWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatRunSubWorkflowStep\<TWorkflowState,TSubWorkflow,TSubWorkflowState\>')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')  
A builder to connect the step to the state with `Input` and `Output`\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState,TStepBody_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_)'></a>

## CatWorkflowBuilderExtensions\.Run\<TWorkflowState,TStepBody\>\(this ICatWorkflowBuilder\<TWorkflowState\>\) Method

Adds a step that runs your own step body\. Register the body with `AddCatFluentWorkflowsSteps`\.
Give both type arguments, like `builder.Run<OrderState, CheckStockStep>()`\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatStepBuilder<TWorkflowState,TStepBody> Run<TWorkflowState,TStepBody>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TStepBody : class, Cat.FluentWorkflows.Abstractions.ICatStepBodyAsync;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState,TStepBody_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState,TStepBody_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TStepBody'></a>

`TStepBody`

The step body to run\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState,TStepBody_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState,TStepBody_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState,TStepBody\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState,TStepBody_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState,TStepBody\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TStepBody](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState,TStepBody_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TStepBody 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState,TStepBody\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TStepBody')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')  
A builder to connect the step to the state with `Input` and `Output`\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Microsoft.Extensions.Logging.ILogger,TWorkflowState_)'></a>

## CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Action\<ILogger,TWorkflowState\>\) Method

Adds a step that runs your code with a logger\. The workflow always goes on with the next step\.

```csharp
public static void Run<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Action<Microsoft.Extensions.Logging.ILogger,TWorkflowState> body)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Microsoft.Extensions.Logging.ILogger,TWorkflowState_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Microsoft.Extensions.Logging.ILogger,TWorkflowState_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Microsoft.Extensions.Logging.ILogger,TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Action\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Microsoft.Extensions.Logging.ILogger,TWorkflowState_).body'></a>

`body` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_Microsoft.Extensions.Logging.ILogger,TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Action\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState\>\)\.TWorkflowState')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')

Gets the logger and the workflow state\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_TWorkflowState_)'></a>

## CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Action\<TWorkflowState\>\) Method

Adds a step that runs your code\. The workflow always goes on with the next step\.

```csharp
public static void Run<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Action<TWorkflowState> body)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_TWorkflowState_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_TWorkflowState_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Action\<TWorkflowState\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_TWorkflowState_).body'></a>

`body` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Action_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Action\<TWorkflowState\>\)\.TWorkflowState')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Gets the workflow state\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__)'></a>

## CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Func\<ILogger,TWorkflowState,ICatResponse\<CatStepExecutionResult\>\>\) Method

Adds a step that runs your code with a logger and decides how the workflow goes on\.
A succeeded response carries the [CatStepExecutionResult](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult') to use\.
A failed response ends the workflow with [BreakCascade](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') and the errors\.

```csharp
public static void Run<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Func<Microsoft.Extensions.Logging.ILogger,TWorkflowState,Cat.Responses.Abstractions.ICatResponse<Cat.FluentWorkflows.Abstractions.CatStepExecutionResult>> body)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,Cat\.Responses\.Abstractions\.ICatResponse\<Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\>\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__).body'></a>

`body` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_Microsoft.Extensions.Logging.ILogger,TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<Microsoft\.Extensions\.Logging\.ILogger,TWorkflowState,Cat\.Responses\.Abstractions\.ICatResponse\<Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\>\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[CatStepExecutionResult](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')

Gets the logger and the workflow state\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__)'></a>

## CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this ICatWorkflowBuilder\<TWorkflowState\>, Func\<TWorkflowState,ICatResponse\<CatStepExecutionResult\>\>\) Method

Adds a step that runs your code and decides how the workflow goes on\.
A succeeded response carries the [CatStepExecutionResult](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult') to use\.
A failed response ends the workflow with [BreakCascade](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakCascade 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakCascade') and the errors\.

```csharp
public static void Run<TWorkflowState>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder, System.Func<TWorkflowState,Cat.Responses.Abstractions.ICatResponse<Cat.FluentWorkflows.Abstractions.CatStepExecutionResult>> body)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,Cat\.Responses\.Abstractions\.ICatResponse\<Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\>\>\)\.TWorkflowState')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

<a name='Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__).body'></a>

`body` [System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWorkflowBuilderExtensions.Run.md#Cat.FluentWorkflows.Extensions.CatWorkflowBuilderExtensions.Run_TWorkflowState_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_,System.Func_TWorkflowState,Cat.Responses.Abstractions.ICatResponse_Cat.FluentWorkflows.Abstractions.CatStepExecutionResult__).TWorkflowState 'Cat\.FluentWorkflows\.Extensions\.CatWorkflowBuilderExtensions\.Run\<TWorkflowState\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, System\.Func\<TWorkflowState,Cat\.Responses\.Abstractions\.ICatResponse\<Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\>\>\)\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[CatStepExecutionResult](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')

Gets the workflow state\.