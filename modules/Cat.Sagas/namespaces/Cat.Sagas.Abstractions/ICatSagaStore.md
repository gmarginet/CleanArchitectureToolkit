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

## ICatSagaStore Interface

Keeps the saga instances\. A store must refuse an update when the instance changed since it was loaded\.

```csharp
public interface ICatSagaStore
```

| Methods | |
| :--- | :--- |
| [AddAsync\(CatSagaInstance, CancellationToken\)](ICatSagaStore.AddAsync.7MULTR44YMMYAWMMC8WLSFFV2.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore\.AddAsync\(Cat\.Sagas\.Abstractions\.CatSagaInstance, System\.Threading\.CancellationToken\)') | Saves a new instance with [Version](CatSagaInstance.Version.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Version') 1\. |
| [FindAsync\(Guid, CancellationToken\)](ICatSagaStore.FindAsync.3PK0II465KD7RWQ37ZL8JNCU.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore\.FindAsync\(System\.Guid, System\.Threading\.CancellationToken\)') | Finds an instance\. |
| [UpdateAsync\(CatSagaInstance, CancellationToken\)](ICatSagaStore.UpdateAsync.607OADSCKT13JO7W8PRH4OLU3.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore\.UpdateAsync\(Cat\.Sagas\.Abstractions\.CatSagaInstance, System\.Threading\.CancellationToken\)') | Saves the changes of an instance and raises [Version](CatSagaInstance.Version.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Version') by one\. |
