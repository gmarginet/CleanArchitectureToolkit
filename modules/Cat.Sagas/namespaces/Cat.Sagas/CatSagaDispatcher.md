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

## CatSagaDispatcher Class

Default [ICatSagaDispatcher](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaDispatcher.md 'Cat\.Sagas\.Abstractions\.ICatSagaDispatcher')\.

```csharp
internal sealed class CatSagaDispatcher : Cat.Sagas.Abstractions.ICatSagaDispatcher
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSagaDispatcher

Implements [ICatSagaDispatcher](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaDispatcher.md 'Cat\.Sagas\.Abstractions\.ICatSagaDispatcher')

| Constructors | |
| :--- | :--- |
| [CatSagaDispatcher\(ICatSagaStore, ICatSagaSerializer, ICatWorkflowProcessor, CatSagaRegistry, CatSagaContext, CatSagaEngine, ILogger&lt;CatSagaDispatcher&gt;\)](CatSagaDispatcher..ctor.RSF8ULM888VEF8X7HQHW0GAM2.md 'Cat\.Sagas\.CatSagaDispatcher\.CatSagaDispatcher\(Cat\.Sagas\.Abstractions\.ICatSagaStore, Cat\.Sagas\.Abstractions\.ICatSagaSerializer, Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor, Cat\.Sagas\.CatSagaRegistry, Cat\.Sagas\.CatSagaContext, Cat\.Sagas\.CatSagaEngine, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Sagas\.CatSagaDispatcher\>\)') | |

| Fields | |
| :--- | :--- |
| [\_context](CatSagaDispatcher._context.md 'Cat\.Sagas\.CatSagaDispatcher\.\_context') | |
| [\_engine](CatSagaDispatcher._engine.md 'Cat\.Sagas\.CatSagaDispatcher\.\_engine') | |
| [\_logger](CatSagaDispatcher._logger.md 'Cat\.Sagas\.CatSagaDispatcher\.\_logger') | |
| [\_processor](CatSagaDispatcher._processor.md 'Cat\.Sagas\.CatSagaDispatcher\.\_processor') | |
| [\_registry](CatSagaDispatcher._registry.md 'Cat\.Sagas\.CatSagaDispatcher\.\_registry') | |
| [\_serializer](CatSagaDispatcher._serializer.md 'Cat\.Sagas\.CatSagaDispatcher\.\_serializer') | |
| [\_store](CatSagaDispatcher._store.md 'Cat\.Sagas\.CatSagaDispatcher\.\_store') | |

| Methods | |
| :--- | :--- |
| [ResumeAsync\(Guid, object, CancellationToken\)](CatSagaDispatcher.ResumeAsync.RBDOHS185C449F8SHQQLJNBRC.md 'Cat\.Sagas\.CatSagaDispatcher\.ResumeAsync\(System\.Guid, object, System\.Threading\.CancellationToken\)') | Resumes the instance with the answer\. |
