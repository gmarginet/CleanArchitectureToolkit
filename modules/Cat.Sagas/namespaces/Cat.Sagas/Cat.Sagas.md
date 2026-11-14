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
  
##### >> [Cat\.Sagas Assembly](index.md 'index')

## Cat\.Sagas Namespace

Runs a workflow over a long time\. It saves the state at a wait step, sends the request message and goes on when the answer arrives\.
It holds the runner, the dispatcher, the JSON serializer, an in\-memory store and the registration of the module\.

| Classes | |
| :--- | :--- |
| [CatInMemorySagaStore](CatInMemorySagaStore.md 'Cat\.Sagas\.CatInMemorySagaStore') | An [ICatSagaStore](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaStore.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore') that keeps the instances in memory\. Use it for tests and for trying a saga\. The instances are gone when the process stops, so it is no store for a real service\. Register it as a singleton\. |
| [CatPendingMessage](CatPendingMessage.md 'Cat\.Sagas\.CatPendingMessage') | A message a step wants to send, with the moment the bus must deliver it\. |
| [CatSagaAnswerHandler&lt;TAnswer&gt;](CatSagaAnswerHandler_TAnswer_.md 'Cat\.Sagas\.CatSagaAnswerHandler\<TAnswer\>') | The handler for an answer message\. It gives the answer to the saga with the same correlation id\. Register it for a message type with `AddCatSagaAnswer`, and declare the type with `Receive` on the event processor\. |
| [CatSagaContext](CatSagaContext.md 'Cat\.Sagas\.CatSagaContext') | The saga that runs in this scope\. The runner and the dispatcher set it before the workflow runs, and the wait step uses it to hand over its request message and its wait, so the messages go out only after the state is saved\. |
| [CatSagaDefinition&lt;TWorkflow,TWorkflowState&gt;](CatSagaDefinition_TWorkflow,TWorkflowState_.md 'Cat\.Sagas\.CatSagaDefinition\<TWorkflow,TWorkflowState\>') | |
| [CatSagaDispatcher](CatSagaDispatcher.md 'Cat\.Sagas\.CatSagaDispatcher') | Default [ICatSagaDispatcher](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaDispatcher.md 'Cat\.Sagas\.Abstractions\.ICatSagaDispatcher')\. |
| [CatSagaEngine](CatSagaEngine.md 'Cat\.Sagas\.CatSagaEngine') | The part that runner and dispatcher share\. It turns the outcome of a workflow run into a saved instance, and sends the request messages only after the instance is saved\. An answer can then never arrive before its instance exists\. |
| [CatSagaErrors](CatSagaErrors.md 'Cat\.Sagas\.CatSagaErrors') | |
| [CatSagaOptions](CatSagaOptions.md 'Cat\.Sagas\.CatSagaOptions') | Settings of the saga engine\. Register them with the extension methods and do not create them yourself\. |
| [CatSagaRegistry](CatSagaRegistry.md 'Cat\.Sagas\.CatSagaRegistry') | Finds the registered sagas by workflow type or by name\. |
| [CatSagaRunner](CatSagaRunner.md 'Cat\.Sagas\.CatSagaRunner') | Default [ICatSagaRunner](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaRunner.md 'Cat\.Sagas\.Abstractions\.ICatSagaRunner')\. |
| [CatSagaTimedOut](CatSagaTimedOut.md 'Cat\.Sagas\.CatSagaTimedOut') | The "answer" the dispatcher gives to a wait step that timed out\. The step sets its `TimedOut` flag when it gets it\. |
| [CatSagaTimeout](CatSagaTimeout.md 'Cat\.Sagas\.CatSagaTimeout') | The message that times out a wait\. The wait step sends it to the own queue of the service with a scheduled time\. Declare it with `Receive` on the event processor of the service\. The module registers its handler\. The bus cannot cancel a scheduled message, so it arrives even when the answer came first\. The dispatcher then ignores it\. |
| [CatSagaTimeoutHandler](CatSagaTimeoutHandler.md 'Cat\.Sagas\.CatSagaTimeoutHandler') | The handler for [CatSagaTimeout](CatSagaTimeout.md 'Cat\.Sagas\.CatSagaTimeout')\. It gives the timeout to the dispatcher\. |
| [SystemTextJsonSagaSerializer](SystemTextJsonSagaSerializer.md 'Cat\.Sagas\.SystemTextJsonSagaSerializer') | [ICatSagaSerializer](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaSerializer.md 'Cat\.Sagas\.Abstractions\.ICatSagaSerializer') on System\.Text\.Json with the web defaults\.             It also gives the loop state of a foreach in a checkpoint its type back, because the checkpoint holds it as an object\. |

| Interfaces | |
| :--- | :--- |
| [ICatSagaDefinition](ICatSagaDefinition.md 'Cat\.Sagas\.ICatSagaDefinition') | A registered saga: its name, and a way to resume it without knowing its types at the call site\. |
