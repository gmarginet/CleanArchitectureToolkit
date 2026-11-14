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
  
##### >> [Cat\.Sagas\.Abstractions Assembly](index.md 'index') >> [Cat\.Sagas\.Abstractions Namespace](Cat.Sagas.Abstractions.md 'Cat\.Sagas\.Abstractions')

## CatSagaInstance Class

The saved record of one saga: the state of the workflow and the place where it waits\.
A store keeps one record per instance\.

```csharp
public class CatSagaInstance
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSagaInstance

| Properties | |
| :--- | :--- |
| [Checkpoint](CatSagaInstance.Checkpoint.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Checkpoint') | The checkpoint of the workflow as JSON\. It is empty when the instance is not waiting\. |
| [CreatedAt](CatSagaInstance.CreatedAt.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.CreatedAt') | When the instance was created\. |
| [Id](CatSagaInstance.Id.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Id') | The id of the instance\. It is also the correlation id of the messages of the saga, so an answer finds its instance with it\. |
| [State](CatSagaInstance.State.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.State') | The workflow state as JSON\. |
| [Status](CatSagaInstance.Status.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Status') | Where the instance is in its life\. |
| [UpdatedAt](CatSagaInstance.UpdatedAt.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.UpdatedAt') | When the instance was last saved\. |
| [Version](CatSagaInstance.Version.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Version') | The number of the saved version\. The store raises it on every update and refuses an update that holds an older number\. |
| [WaitingFor](CatSagaInstance.WaitingFor.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.WaitingFor') | The name of the type of answer the instance waits for\. It is empty when the instance is not waiting\. |
| [WorkflowType](CatSagaInstance.WorkflowType.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.WorkflowType') | The name of the saga, as it was registered\. It tells the dispatcher which workflow to resume\. |
| [WorkflowVersion](CatSagaInstance.WorkflowVersion.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.WorkflowVersion') | The version of the workflow when the instance last suspended, see `ICatVersionedWorkflow`\. |
