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
  
##### >> [Cat\.Sagas\.Abstractions Assembly](index.md 'index')

## Cat\.Sagas\.Abstractions Namespace

The contracts of a long running workflow: the saga instance and its status, the store, the serializer, the runner that starts a saga and the dispatcher that resumes it\.

| Classes | |
| :--- | :--- |
| [CatSagaConcurrencyException](CatSagaConcurrencyException.md 'Cat\.Sagas\.Abstractions\.CatSagaConcurrencyException') | Thrown by a store when another message changed the instance since it was loaded\. Let it pass\. The message is delivered again and the next try sees the new state\. |
| [CatSagaInstance](CatSagaInstance.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance') | The saved record of one saga: the state of the workflow and the place where it waits\. A store keeps one record per instance\. |
| [CatSagaResult](CatSagaResult.md 'Cat\.Sagas\.Abstractions\.CatSagaResult') | What a saga run came to: waiting for an answer, done, or failed\. |
| [CatSagaWait](CatSagaWait.md 'Cat\.Sagas\.Abstractions\.CatSagaWait') | One open wait of an instance: a wait step that sent its request and has no answer yet\. An instance with a parallel step can have several\. |

| Interfaces | |
| :--- | :--- |
| [ICatSagaContext](ICatSagaContext.md 'Cat\.Sagas\.Abstractions\.ICatSagaContext') | The saga that is running right now\. A step reads it to know its instance\. It is empty outside a saga run\. |
| [ICatSagaDispatcher](ICatSagaDispatcher.md 'Cat\.Sagas\.Abstractions\.ICatSagaDispatcher') | Gives an answer to a waiting saga\. It finds the instance, resumes the workflow at the wait step and saves the result\. The handler that `AddCatSagaAnswer` registers calls it for you\. |
| [ICatSagaRunner](ICatSagaRunner.md 'Cat\.Sagas\.Abstractions\.ICatSagaRunner') | Starts a saga\. The workflow runs until it ends or reaches a wait step\. At a wait step its state is saved and the request message is sent\. |
| [ICatSagaSerializer](ICatSagaSerializer.md 'Cat\.Sagas\.Abstractions\.ICatSagaSerializer') | Turns the workflow state and the checkpoint into text and back\. The default one uses System\.Text\.Json\. Register your own to use another format\. |
| [ICatSagaStore](ICatSagaStore.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore') | Keeps the saga instances\. A store must refuse an update when the instance changed since it was loaded\. |

| Enums | |
| :--- | :--- |
| [CatSagaStatus](CatSagaStatus.md 'Cat\.Sagas\.Abstractions\.CatSagaStatus') | Where a saga instance is in its life\. |
