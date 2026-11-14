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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas Namespace](Cat.Sagas.md 'Cat\.Sagas') >> [CatSagaDispatcher Class](CatSagaDispatcher.md 'Cat\.Sagas\.CatSagaDispatcher')

## CatSagaDispatcher\.TimeoutAsync\(Guid, Guid, CancellationToken\) Method

Times out one wait of the instance\. The workflow resumes at the wait step with `TimedOut` set and no answer\.
The handler for `CatSagaTimeout` calls it for you\.

```csharp
public System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse> TimeoutAsync(System.Guid correlationId, System.Guid waitId, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Sagas.CatSagaDispatcher.TimeoutAsync(System.Guid,System.Guid,System.Threading.CancellationToken).correlationId'></a>

`correlationId` [System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')

The id of the instance\.

<a name='Cat.Sagas.CatSagaDispatcher.TimeoutAsync(System.Guid,System.Guid,System.Threading.CancellationToken).waitId'></a>

`waitId` [System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')

The id of the wait that timed out, see [WaitId](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaWait.WaitId.md 'Cat\.Sagas\.Abstractions\.CatSagaWait\.WaitId')\.

<a name='Cat.Sagas.CatSagaDispatcher.TimeoutAsync(System.Guid,System.Guid,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [TimeoutAsync\(Guid, Guid, CancellationToken\)](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaDispatcher.TimeoutAsync.FW7ZC320WTINFPP98AU9EN7A6.md 'Cat\.Sagas\.Abstractions\.ICatSagaDispatcher\.TimeoutAsync\(System\.Guid,System\.Guid,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A succeeded response when the wait timed out, and also when it no longer applies, such as an answer that came first\.
A NotFound response when there is no such instance\.

#### Exceptions

[CatSagaConcurrencyException](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaConcurrencyException.md 'Cat\.Sagas\.Abstractions\.CatSagaConcurrencyException')  
Another message changed the instance at the same time\.