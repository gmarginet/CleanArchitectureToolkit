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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatWorkflowProcessor Class

Default [ICatWorkflowProcessor](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor')\.
Gets the workflow from the service provider, builds its steps, and runs them inside a tracing activity\.
A resume builds the steps again and goes on at the step that suspended\.

```csharp
public class CatWorkflowProcessor : Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatWorkflowProcessor

Implements [ICatWorkflowProcessor](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor')

| Constructors | |
| :--- | :--- |
| [CatWorkflowProcessor\(IServiceProvider, ICatStepProcessor\)](CatWorkflowProcessor..ctor.6484LEV7COQPI7DE3ZYGZG8TC.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.CatWorkflowProcessor\(System\.IServiceProvider, Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor\)') | Creates the processor\. |

| Fields | |
| :--- | :--- |
| [\_serviceProvider](CatWorkflowProcessor._serviceProvider.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.\_serviceProvider') | |
| [\_stepProcessor](CatWorkflowProcessor._stepProcessor.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.\_stepProcessor') | |

| Methods | |
| :--- | :--- |
| [CheckTarget\(CatWorkflowCheckpoint, string\)](CatWorkflowProcessor.CheckTarget.DLD9TGBIFHLYJS1PGX5AUBSG9.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.CheckTarget\(Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, string\)') | |
| [CheckVersion\(object, string, CatWorkflowCheckpoint\)](CatWorkflowProcessor.CheckVersion.OJXBOOYXXQZWTH3D5TAIU4A67.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.CheckVersion\(object, string, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint\)') | |
| [Finish\(ICatWorkflowResponse, object\)](CatWorkflowProcessor.Finish.0JDV5WZEOB4B74ASIH3CH0J0C.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.Finish\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, object\)') | |
| [GetVersion\(object\)](CatWorkflowProcessor.GetVersion.CXO3RENP829J9T2HH4DQ9G3Y7.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.GetVersion\(object\)') | |
| [ResumeAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CatWorkflowCheckpoint, object, string, CancellationToken\)](CatWorkflowProcessor.ResumeAsync.md#Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken) 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.ResumeAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, object, string, System\.Threading\.CancellationToken\)') | Builds the workflow again and goes on at the step that suspended, with the answer, for the waiting step with the given name\. Use this when a parallel step has several waiting branches\. |
| [ResumeAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CatWorkflowCheckpoint, object, CancellationToken\)](CatWorkflowProcessor.ResumeAsync.md#Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken) 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.ResumeAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, object, System\.Threading\.CancellationToken\)') | Builds the workflow again and goes on at the step that suspended, with the answer\. The workflow must be the same as when it suspended, see [ICatVersionedWorkflow](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatVersionedWorkflow.md 'Cat\.FluentWorkflows\.Abstractions\.ICatVersionedWorkflow')\. Use this when only one step waits\. A result of [Suspend](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Suspend 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Suspend') means the workflow waits again, and the response holds a new checkpoint\. |
| [RunAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CancellationToken\)](CatWorkflowProcessor.RunAsync.LKKIV0SEAAO6ACSDPU7IZPK9C.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.RunAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, System\.Threading\.CancellationToken\)') | Builds the workflow, runs its steps on the given state and returns the outcome\. A [BreakFromCurrentFlowOnly](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakFromCurrentFlowOnly 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakFromCurrentFlowOnly') result is reported as [Continue](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Continue 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Continue')\. |
