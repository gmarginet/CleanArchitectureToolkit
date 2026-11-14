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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas') >> [CatInMemorySagaStore Class](CatInMemorySagaStore.md 'Cat\.Sagas\.CatInMemorySagaStore')

## CatInMemorySagaStore\.UpdateAsync\(CatSagaInstance, CancellationToken\) Method

Saves the changes of an instance and raises [Version](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaInstance.Version.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Version') by one\.

```csharp
public System.Threading.Tasks.Task UpdateAsync(Cat.Sagas.Abstractions.CatSagaInstance instance, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Sagas.CatInMemorySagaStore.UpdateAsync(Cat.Sagas.Abstractions.CatSagaInstance,System.Threading.CancellationToken).instance'></a>

`instance` [CatSagaInstance](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaInstance.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance')

The instance to save\. Its version is the version it had when it was loaded\.

<a name='Cat.Sagas.CatInMemorySagaStore.UpdateAsync(Cat.Sagas.Abstractions.CatSagaInstance,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [UpdateAsync\(CatSagaInstance, CancellationToken\)](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaStore.UpdateAsync.607OADSCKT13JO7W8PRH4OLU3.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore\.UpdateAsync\(Cat\.Sagas\.Abstractions\.CatSagaInstance,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that completes when the instance is saved\.

#### Exceptions

[CatSagaConcurrencyException](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaConcurrencyException.md 'Cat\.Sagas\.Abstractions\.CatSagaConcurrencyException')  
The saved version is not the version of [instance](CatInMemorySagaStore.UpdateAsync.27K3DPON6MGXZKMC4PHDA9FG4.md#Cat.Sagas.CatInMemorySagaStore.UpdateAsync(Cat.Sagas.Abstractions.CatSagaInstance,System.Threading.CancellationToken).instance 'Cat\.Sagas\.CatInMemorySagaStore\.UpdateAsync\(Cat\.Sagas\.Abstractions\.CatSagaInstance, System\.Threading\.CancellationToken\)\.instance')\.