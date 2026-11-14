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

## CatSagaEngine Class

The part that runner and dispatcher share\. It turns the outcome of a workflow run into a saved instance,
and sends the request messages only after the instance is saved\. An answer can then never arrive before its instance exists\.

```csharp
internal sealed class CatSagaEngine
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSagaEngine

| Constructors | |
| :--- | :--- |
| [CatSagaEngine\(ICatSagaStore, ICatSagaSerializer, CatSagaContext, ICatMessageSender, CatSagaOptions\)](CatSagaEngine..ctor.66FHRKW7SPX3KL18WCCTVL096.md 'Cat\.Sagas\.CatSagaEngine\.CatSagaEngine\(Cat\.Sagas\.Abstractions\.ICatSagaStore, Cat\.Sagas\.Abstractions\.ICatSagaSerializer, Cat\.Sagas\.CatSagaContext, Cat\.Messaging\.Abstractions\.ICatMessageSender, Cat\.Sagas\.CatSagaOptions\)') | |

| Fields | |
| :--- | :--- |
| [\_context](CatSagaEngine._context.md 'Cat\.Sagas\.CatSagaEngine\.\_context') | |
| [\_options](CatSagaEngine._options.md 'Cat\.Sagas\.CatSagaEngine\.\_options') | |
| [\_sender](CatSagaEngine._sender.md 'Cat\.Sagas\.CatSagaEngine\.\_sender') | |
| [\_serializer](CatSagaEngine._serializer.md 'Cat\.Sagas\.CatSagaEngine\.\_serializer') | |
| [\_store](CatSagaEngine._store.md 'Cat\.Sagas\.CatSagaEngine\.\_store') | |

| Methods | |
| :--- | :--- |
| [FinishAsync\(ICatSagaDefinition, CatSagaInstance, Guid, object, ICatWorkflowResponse, string, CancellationToken\)](CatSagaEngine.FinishAsync.XJSU3R194Z9CWS6GGY0AXPAQB.md 'Cat\.Sagas\.CatSagaEngine\.FinishAsync\(Cat\.Sagas\.ICatSagaDefinition, Cat\.Sagas\.Abstractions\.CatSagaInstance, System\.Guid, object, Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowResponse, string, System\.Threading\.CancellationToken\)') | Saves the result of a run and sends the messages it collected\. |
| [ReadWaits\(CatSagaInstance\)](CatSagaEngine.ReadWaits.QBTT9RVX54K1RASLMRPQ268J4.md 'Cat\.Sagas\.CatSagaEngine\.ReadWaits\(Cat\.Sagas\.Abstractions\.CatSagaInstance\)') | |
| [SendPendingAsync\(CancellationToken\)](CatSagaEngine.SendPendingAsync.XX4UQ648XF76R6EZALBLUCHT9.md 'Cat\.Sagas\.CatSagaEngine\.SendPendingAsync\(System\.Threading\.CancellationToken\)') | |
