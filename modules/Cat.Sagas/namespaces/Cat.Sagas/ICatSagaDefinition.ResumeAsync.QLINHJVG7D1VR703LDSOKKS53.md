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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas') >> [ICatSagaDefinition Interface](ICatSagaDefinition.md 'Cat\.Sagas\.ICatSagaDefinition')

## ICatSagaDefinition\.ResumeAsync\(ICatWorkflowProcessor, object, CatWorkflowCheckpoint, object, string, CancellationToken\) Method

```csharp
System.Threading.Tasks.Task<Cat.FluentWorkflows.Abstractions.ICatWorkflowResponse> ResumeAsync(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor processor, object state, Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint checkpoint, object answer, string target, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Sagas.ICatSagaDefinition.ResumeAsync(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,object,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).processor'></a>

`processor` [ICatWorkflowProcessor](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor')

<a name='Cat.Sagas.ICatSagaDefinition.ResumeAsync(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,object,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).state'></a>

`state` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.Sagas.ICatSagaDefinition.ResumeAsync(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,object,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).checkpoint'></a>

`checkpoint` [CatWorkflowCheckpoint](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatWorkflowCheckpoint.md 'Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint')

<a name='Cat.Sagas.ICatSagaDefinition.ResumeAsync(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,object,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).answer'></a>

`answer` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.Sagas.ICatSagaDefinition.ResumeAsync(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,object,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).target'></a>

`target` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Sagas.ICatSagaDefinition.ResumeAsync(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,object,Cat.FluentWorkflows.Abstractions.CatWorkflowCheckpoint,object,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatWorkflowResponse](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowResponse.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')