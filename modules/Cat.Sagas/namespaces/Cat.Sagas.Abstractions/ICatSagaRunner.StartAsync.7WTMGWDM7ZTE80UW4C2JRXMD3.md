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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SAGAS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sagas\.Abstractions Assembly](index.md 'index') >> [Cat\.Sagas\.Abstractions Namespace](Cat.Sagas.Abstractions.md 'Cat\.Sagas\.Abstractions') >> [ICatSagaRunner Interface](ICatSagaRunner.md 'Cat\.Sagas\.Abstractions\.ICatSagaRunner')

## ICatSagaRunner\.StartAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, Nullable\<Guid\>, CancellationToken\) Method

Runs the workflow on the state\. The workflow must be registered with `AddCatSaga`\.

```csharp
System.Threading.Tasks.Task<Cat.Sagas.Abstractions.CatSagaResult> StartAsync<TWorkflow,TWorkflowState>(TWorkflowState state, System.Nullable<System.Guid> correlationId=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken))
    where TWorkflow : Cat.FluentWorkflows.Abstractions.ICatWorkflow<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>;
```
#### Type parameters

<a name='Cat.Sagas.Abstractions.ICatSagaRunner.StartAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Nullable_System.Guid_,System.Threading.CancellationToken).TWorkflow'></a>

`TWorkflow`

The workflow to run\.

<a name='Cat.Sagas.Abstractions.ICatSagaRunner.StartAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Nullable_System.Guid_,System.Threading.CancellationToken).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\. It must be serializable\.
#### Parameters

<a name='Cat.Sagas.Abstractions.ICatSagaRunner.StartAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Nullable_System.Guid_,System.Threading.CancellationToken).state'></a>

`state` [TWorkflowState](ICatSagaRunner.StartAsync.7WTMGWDM7ZTE80UW4C2JRXMD3.md#Cat.Sagas.Abstractions.ICatSagaRunner.StartAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Nullable_System.Guid_,System.Threading.CancellationToken).TWorkflowState 'Cat\.Sagas\.Abstractions\.ICatSagaRunner\.StartAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, System\.Nullable\<System\.Guid\>, System\.Threading\.CancellationToken\)\.TWorkflowState')

The state the steps work on\.

<a name='Cat.Sagas.Abstractions.ICatSagaRunner.StartAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Nullable_System.Guid_,System.Threading.CancellationToken).correlationId'></a>

`correlationId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The id of the new instance\. Leave it empty to get a new one\.

<a name='Cat.Sagas.Abstractions.ICatSagaRunner.StartAsync_TWorkflow,TWorkflowState_(TWorkflowState,System.Nullable_System.Guid_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CatSagaResult](CatSagaResult.md 'Cat\.Sagas\.Abstractions\.CatSagaResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The result, with the instance id and the status\. Only a waiting instance is saved\.