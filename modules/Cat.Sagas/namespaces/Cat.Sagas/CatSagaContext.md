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

## CatSagaContext Class

The saga that runs in this scope\. The runner and the dispatcher set it before the workflow runs, and the wait step uses it
to hand over its request message, so the message goes out only after the state is saved\.

```csharp
public sealed class CatSagaContext : Cat.Sagas.Abstractions.ICatSagaContext
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSagaContext

Implements [ICatSagaContext](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaContext.md 'Cat\.Sagas\.Abstractions\.ICatSagaContext')

| Properties | |
| :--- | :--- |
| [InstanceId](CatSagaContext.InstanceId.md 'Cat\.Sagas\.CatSagaContext\.InstanceId') | The id of the running instance\. It is the correlation id for every message of the saga\. |
| [Pending](CatSagaContext.Pending.md 'Cat\.Sagas\.CatSagaContext\.Pending') | |
| [WaitingFor](CatSagaContext.WaitingFor.md 'Cat\.Sagas\.CatSagaContext\.WaitingFor') | |

| Methods | |
| :--- | :--- |
| [Begin\(Guid\)](CatSagaContext.Begin.Y3FM99N7DL09F96XBT9DAX364.md 'Cat\.Sagas\.CatSagaContext\.Begin\(System\.Guid\)') | |
