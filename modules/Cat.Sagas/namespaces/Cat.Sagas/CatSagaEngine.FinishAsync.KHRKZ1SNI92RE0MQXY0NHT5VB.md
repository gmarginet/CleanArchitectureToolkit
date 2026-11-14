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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas') >> [CatSagaEngine Class](CatSagaEngine.md 'Cat\.Sagas\.CatSagaEngine')

## CatSagaEngine\.FinishAsync\(ICatSagaDefinition, CatSagaInstance, Guid, object, ICatWorkflowResponse, CancellationToken\) Method

```csharp
public System.Threading.Tasks.Task<Cat.Sagas.Abstractions.CatSagaResult> FinishAsync(Cat.Sagas.ICatSagaDefinition definition, Cat.Sagas.Abstractions.CatSagaInstance? instance, System.Guid id, object state, Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse response, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Sagas.CatSagaEngine.FinishAsync(Cat.Sagas.ICatSagaDefinition,Cat.Sagas.Abstractions.CatSagaInstance,System.Guid,object,Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Threading.CancellationToken).definition'></a>

`definition` [ICatSagaDefinition](ICatSagaDefinition.md 'Cat\.Sagas\.ICatSagaDefinition')

<a name='Cat.Sagas.CatSagaEngine.FinishAsync(Cat.Sagas.ICatSagaDefinition,Cat.Sagas.Abstractions.CatSagaInstance,System.Guid,object,Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Threading.CancellationToken).instance'></a>

`instance` [CatSagaInstance](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaInstance.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance')

<a name='Cat.Sagas.CatSagaEngine.FinishAsync(Cat.Sagas.ICatSagaDefinition,Cat.Sagas.Abstractions.CatSagaInstance,System.Guid,object,Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Threading.CancellationToken).id'></a>

`id` [System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')

<a name='Cat.Sagas.CatSagaEngine.FinishAsync(Cat.Sagas.ICatSagaDefinition,Cat.Sagas.Abstractions.CatSagaInstance,System.Guid,object,Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Threading.CancellationToken).state'></a>

`state` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.Sagas.CatSagaEngine.FinishAsync(Cat.Sagas.ICatSagaDefinition,Cat.Sagas.Abstractions.CatSagaInstance,System.Guid,object,Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Threading.CancellationToken).response'></a>

`response` [ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')

<a name='Cat.Sagas.CatSagaEngine.FinishAsync(Cat.Sagas.ICatSagaDefinition,Cat.Sagas.Abstractions.CatSagaInstance,System.Guid,object,Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CatSagaResult](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaResult.md 'Cat\.Sagas\.Abstractions\.CatSagaResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')