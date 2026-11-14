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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas') >> [CatSagaRunner Class](CatSagaRunner.md 'Cat\.Sagas\.CatSagaRunner')

## CatSagaRunner\(ICatWorkflowProcessor, CatSagaRegistry, CatSagaContext, CatSagaEngine\) Constructor

```csharp
public CatSagaRunner(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor processor, Cat.Sagas.CatSagaRegistry registry, Cat.Sagas.CatSagaContext context, Cat.Sagas.CatSagaEngine engine);
```
#### Parameters

<a name='Cat.Sagas.CatSagaRunner.CatSagaRunner(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,Cat.Sagas.CatSagaRegistry,Cat.Sagas.CatSagaContext,Cat.Sagas.CatSagaEngine).processor'></a>

`processor` [ICatWorkflowProcessor](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor')

<a name='Cat.Sagas.CatSagaRunner.CatSagaRunner(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,Cat.Sagas.CatSagaRegistry,Cat.Sagas.CatSagaContext,Cat.Sagas.CatSagaEngine).registry'></a>

`registry` [CatSagaRegistry](CatSagaRegistry.md 'Cat\.Sagas\.CatSagaRegistry')

<a name='Cat.Sagas.CatSagaRunner.CatSagaRunner(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,Cat.Sagas.CatSagaRegistry,Cat.Sagas.CatSagaContext,Cat.Sagas.CatSagaEngine).context'></a>

`context` [CatSagaContext](CatSagaContext.md 'Cat\.Sagas\.CatSagaContext')

<a name='Cat.Sagas.CatSagaRunner.CatSagaRunner(Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor,Cat.Sagas.CatSagaRegistry,Cat.Sagas.CatSagaContext,Cat.Sagas.CatSagaEngine).engine'></a>

`engine` [CatSagaEngine](CatSagaEngine.md 'Cat\.Sagas\.CatSagaEngine')