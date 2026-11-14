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

## CatSagaDefinition\<TWorkflow,TWorkflowState\> Class

```csharp
internal sealed class CatSagaDefinition<TWorkflow,TWorkflowState>
    where TWorkflow : Cat.FluentWorkflows.Abstractions.ICatWorkflow<TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.Sagas.CatSagaDefinition_TWorkflow,TWorkflowState_.TWorkflow'></a>

`TWorkflow`

<a name='Cat.Sagas.CatSagaDefinition_TWorkflow,TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSagaDefinition\<TWorkflow,TWorkflowState\>

| Properties | |
| :--- | :--- |
| [Name](CatSagaDefinition_TWorkflow,TWorkflowState_.Name.md 'Cat\.Sagas\.CatSagaDefinition\<TWorkflow,TWorkflowState\>\.Name') | |
| [StateType](CatSagaDefinition_TWorkflow,TWorkflowState_.StateType.md 'Cat\.Sagas\.CatSagaDefinition\<TWorkflow,TWorkflowState\>\.StateType') | |
| [WorkflowType](CatSagaDefinition_TWorkflow,TWorkflowState_.WorkflowType.md 'Cat\.Sagas\.CatSagaDefinition\<TWorkflow,TWorkflowState\>\.WorkflowType') | |

| Methods | |
| :--- | :--- |
| [ResumeAsync\(ICatWorkflowProcessor, object, CatWorkflowCheckpoint, object, CancellationToken\)](CatSagaDefinition_TWorkflow,TWorkflowState_.ResumeAsync.4X9TI0UDJC7J1BMUEAYMY29W5.md 'Cat\.Sagas\.CatSagaDefinition\<TWorkflow,TWorkflowState\>\.ResumeAsync\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor, object, Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint, object, System\.Threading\.CancellationToken\)') | |
