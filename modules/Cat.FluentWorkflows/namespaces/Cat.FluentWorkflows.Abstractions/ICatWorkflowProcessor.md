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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows\.Abstractions Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Abstractions Namespace](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatWorkflowProcessor Interface

Single entry point for running a workflow\.

```csharp
public interface ICatWorkflowProcessor
```

| Methods | |
| :--- | :--- |
| [ResumeAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CatWorkflowCheckpoint, object, string, CancellationToken\)](ICatWorkflowProcessor.ResumeAsync.md#Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken) 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor\.ResumeAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, object, string, System\.Threading\.CancellationToken\)') | Builds the workflow again and goes on at the step that suspended, with the answer, for the waiting step with the given name\. Use this when a parallel step has several waiting branches\. |
| [ResumeAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CatWorkflowCheckpoint, object, CancellationToken\)](ICatWorkflowProcessor.ResumeAsync.md#Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken) 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor\.ResumeAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, object, System\.Threading\.CancellationToken\)') | Builds the workflow again and goes on at the step that suspended, with the answer\. The workflow must be the same as when it suspended, see [ICatVersionedWorkflow](ICatVersionedWorkflow.md 'Cat\.FluentWorkflows\.Abstractions\.ICatVersionedWorkflow')\. Use this when only one step waits\. A result of [Suspend](CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Suspend 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Suspend') means the workflow waits again, and the response holds a new checkpoint\. |
| [RunAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CancellationToken\)](ICatWorkflowProcessor.RunAsync.R1HS9NJ8EQXVXKZLXHU6G4NG5.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor\.RunAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, System\.Threading\.CancellationToken\)') | Builds the workflow, runs its steps on the given state and returns the outcome\. A [BreakFromCurrentFlowOnly](CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakFromCurrentFlowOnly 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakFromCurrentFlowOnly') result is reported as [Continue](CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Continue 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Continue')\. |
