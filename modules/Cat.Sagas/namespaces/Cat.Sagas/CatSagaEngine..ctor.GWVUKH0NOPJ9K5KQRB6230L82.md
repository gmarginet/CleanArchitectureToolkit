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

## CatSagaEngine\(ICatSagaStore, ICatSagaSerializer, CatSagaContext, ICatMessageSender\) Constructor

```csharp
public CatSagaEngine(Cat.Sagas.Abstractions.ICatSagaStore store, Cat.Sagas.Abstractions.ICatSagaSerializer serializer, Cat.Sagas.CatSagaContext context, Cat.Messaging.Abstractions.ICatMessageSender sender);
```
#### Parameters

<a name='Cat.Sagas.CatSagaEngine.CatSagaEngine(Cat.Sagas.Abstractions.ICatSagaStore,Cat.Sagas.Abstractions.ICatSagaSerializer,Cat.Sagas.CatSagaContext,Cat.Messaging.Abstractions.ICatMessageSender).store'></a>

`store` [ICatSagaStore](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaStore.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore')

<a name='Cat.Sagas.CatSagaEngine.CatSagaEngine(Cat.Sagas.Abstractions.ICatSagaStore,Cat.Sagas.Abstractions.ICatSagaSerializer,Cat.Sagas.CatSagaContext,Cat.Messaging.Abstractions.ICatMessageSender).serializer'></a>

`serializer` [ICatSagaSerializer](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaSerializer.md 'Cat\.Sagas\.Abstractions\.ICatSagaSerializer')

<a name='Cat.Sagas.CatSagaEngine.CatSagaEngine(Cat.Sagas.Abstractions.ICatSagaStore,Cat.Sagas.Abstractions.ICatSagaSerializer,Cat.Sagas.CatSagaContext,Cat.Messaging.Abstractions.ICatMessageSender).context'></a>

`context` [CatSagaContext](CatSagaContext.md 'Cat\.Sagas\.CatSagaContext')

<a name='Cat.Sagas.CatSagaEngine.CatSagaEngine(Cat.Sagas.Abstractions.ICatSagaStore,Cat.Sagas.Abstractions.ICatSagaSerializer,Cat.Sagas.CatSagaContext,Cat.Messaging.Abstractions.ICatMessageSender).sender'></a>

`sender` [ICatMessageSender](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender')