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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatWorkflowProcessor Class](CatWorkflowProcessor.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor')

## CatWorkflowProcessor\.RunAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, CancellationToken\) Method

Builds the workflow, runs its steps on the given state and returns the outcome\.
A [BreakFromCurrentFlowOnly](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakFromCurrentFlowOnly 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakFromCurrentFlowOnly') result is reported as [Continue](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Continue 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Continue')\.

```csharp
public System.Threading.Tasks.Task<Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse> RunAsync<TWorkflow,TWorkflowState>(TWorkflowState workflowState, System.Threading.CancellationToken cancellationToken)
    where TWorkflow : Cat.FluentWorkflows.Abstractions.ICatWorkflow<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.RunAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Threading.CancellationToken).TWorkflow'></a>

`TWorkflow`

The workflow to run\. It must be registered\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.RunAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Threading.CancellationToken).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.RunAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Threading.CancellationToken).workflowState'></a>

`workflowState` [TWorkflowState](CatWorkflowProcessor.RunAsync.LKKIV0SEAAO6ACSDPU7IZPK9C.md#Cat.FluentWorkflows.CatWorkflowProcessor.RunAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Threading.CancellationToken).TWorkflowState 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.RunAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, System\.Threading\.CancellationToken\)\.TWorkflowState')

The state the steps work on\. Read it afterwards to get the results\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.RunAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [RunAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CancellationToken\)](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowProcessor.RunAsync.R1HS9NJ8EQXVXKZLXHU6G4NG5.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor\.RunAsync\`\`2\(\`\`1,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the last step that ran, with the errors of every step that ran\.