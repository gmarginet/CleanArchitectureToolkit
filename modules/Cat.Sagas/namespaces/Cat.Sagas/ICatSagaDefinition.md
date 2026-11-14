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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas')

## ICatSagaDefinition Interface

A registered saga: its name, and a way to resume it without knowing its types at the call site\.

```csharp
internal interface ICatSagaDefinition
```

Derived  
↳ [CatSagaDefinition&lt;TWorkflow,TWorkflowState&gt;](CatSagaDefinition_TWorkflow,TWorkflowState_.md 'Cat\.Sagas\.CatSagaDefinition\<TWorkflow,TWorkflowState\>')

| Properties | |
| :--- | :--- |
| [Name](ICatSagaDefinition.Name.md 'Cat\.Sagas\.ICatSagaDefinition\.Name') | |
| [StateType](ICatSagaDefinition.StateType.md 'Cat\.Sagas\.ICatSagaDefinition\.StateType') | |
| [WorkflowType](ICatSagaDefinition.WorkflowType.md 'Cat\.Sagas\.ICatSagaDefinition\.WorkflowType') | |

| Methods | |
| :--- | :--- |
| [ResumeAsync\(ICatWorkflowProcessor, object, CatWorkflowCheckpoint, object, string, CancellationToken\)](ICatSagaDefinition.ResumeAsync.QLINHJVG7D1VR703LDSOKKS53.md 'Cat\.Sagas\.ICatSagaDefinition\.ResumeAsync\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor, object, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, object, string, System\.Threading\.CancellationToken\)') | |
