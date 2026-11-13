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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatWorkflowProcessor Class](CatWorkflowProcessor.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor')

## CatWorkflowProcessor\.ResumeAsync Method

| Overloads | |
| :--- | :--- |
| [ResumeAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CatWorkflowCheckpoint, object, string, CancellationToken\)](CatWorkflowProcessor.ResumeAsync.md#Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken) 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.ResumeAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, object, string, System\.Threading\.CancellationToken\)') | Builds the workflow again and goes on at the step that suspended, with the answer, for the waiting step with the given name\. Use this when a parallel step has several waiting branches\. |
| [ResumeAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CatWorkflowCheckpoint, object, CancellationToken\)](CatWorkflowProcessor.ResumeAsync.md#Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken) 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.ResumeAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, object, System\.Threading\.CancellationToken\)') | Builds the workflow again and goes on at the step that suspended, with the answer\. The workflow must be the same as when it suspended, see [ICatVersionedWorkflow](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatVersionedWorkflow.md 'Cat\.FluentWorkflows\.Abstractions\.ICatVersionedWorkflow')\. Use this when only one step waits\. A result of [Suspend](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Suspend 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Suspend') means the workflow waits again, and the response holds a new checkpoint\. |

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken)'></a>

## CatWorkflowProcessor\.ResumeAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, CatWorkflowCheckpoint, object, string, CancellationToken\) Method

Builds the workflow again and goes on at the step that suspended, with the answer, for the waiting step with the given name\.
Use this when a parallel step has several waiting branches\.

```csharp
public System.Threading.Tasks.Task<Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse> ResumeAsync<TWorkflow,TWorkflowState>(TWorkflowState workflowState, Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint checkpoint, object? answer, string? target, System.Threading.CancellationToken cancellationToken)
    where TWorkflow : Cat.FluentWorkflows.Abstractions.ICatWorkflow<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).TWorkflow'></a>

`TWorkflow`

The workflow to resume\. It must be registered\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\. Give the state as it was when the workflow suspended\.
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).workflowState'></a>

`workflowState` [TWorkflowState](CatWorkflowProcessor.ResumeAsync.md#Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).TWorkflowState 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.ResumeAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, object, string, System\.Threading\.CancellationToken\)\.TWorkflowState')

The state the steps work on\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).checkpoint'></a>

`checkpoint` [CatWorkflowCheckpoint](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatWorkflowCheckpoint.md 'Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint')

The checkpoint from the response of the suspended run\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).answer'></a>

`answer` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The answer for the waiting step\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).target'></a>

`target` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the waiting step that gets the answer, or `null` when only one step waits\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [ResumeAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CatWorkflowCheckpoint, object, string, CancellationToken\)](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowProcessor.ResumeAsync.md#Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken) 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor\.ResumeAsync\`\`2\(\`\`1,Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint,System\.Object,System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the last step that ran, with the errors of every step that ran\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The checkpoint does not fit the workflow, or the target is not one waiting step\. See the message\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken)'></a>

## CatWorkflowProcessor\.ResumeAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, CatWorkflowCheckpoint, object, CancellationToken\) Method

Builds the workflow again and goes on at the step that suspended, with the answer\.
The workflow must be the same as when it suspended, see [ICatVersionedWorkflow](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatVersionedWorkflow.md 'Cat\.FluentWorkflows\.Abstractions\.ICatVersionedWorkflow')\.
Use this when only one step waits\. A result of [Suspend](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Suspend 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Suspend') means the workflow waits again, and the response holds a new checkpoint\.

```csharp
public System.Threading.Tasks.Task<Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse> ResumeAsync<TWorkflow,TWorkflowState>(TWorkflowState workflowState, Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint checkpoint, object? answer, System.Threading.CancellationToken cancellationToken)
    where TWorkflow : Cat.FluentWorkflows.Abstractions.ICatWorkflow<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken).TWorkflow'></a>

`TWorkflow`

The workflow to resume\. It must be registered\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\. Give the state as it was when the workflow suspended\.
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken).workflowState'></a>

`workflowState` [TWorkflowState](CatWorkflowProcessor.ResumeAsync.md#Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken).TWorkflowState 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.ResumeAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, object, System\.Threading\.CancellationToken\)\.TWorkflowState')

The state the steps work on\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken).checkpoint'></a>

`checkpoint` [CatWorkflowCheckpoint](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatWorkflowCheckpoint.md 'Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint')

The checkpoint from the response of the suspended run\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken).answer'></a>

`answer` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

The answer for the waiting step\. It reaches the step as the argument of [ResumeAsync\(object, CancellationToken\)](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatResumableStepBody.ResumeAsync.HP5PHZV9SR380TQFY6XTWDFQB.md 'Cat\.FluentWorkflows\.Abstractions\.ICatResumableStepBody\.ResumeAsync\(System\.Object,System\.Threading\.CancellationToken\)')\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [ResumeAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CatWorkflowCheckpoint, object, CancellationToken\)](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowProcessor.ResumeAsync.md#Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor.ResumeAsync_TWorkflow,TWorkflowState_(TWorkflowState,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,System.Threading.CancellationToken) 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor\.ResumeAsync\`\`2\(\`\`1,Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint,System\.Object,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result of the last step that ran, with the errors of every step that ran\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
The checkpoint does not fit the workflow, or more than one step waits\. See the message\.