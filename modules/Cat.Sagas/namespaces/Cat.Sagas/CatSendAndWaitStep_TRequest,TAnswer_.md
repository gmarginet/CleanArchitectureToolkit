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
  
##### >> [Cat\.Sagas Assembly](index.md 'index') >> [Cat\.Sagas\.Steps Namespace](Cat.Sagas.Steps.md 'Cat\.Sagas\.Steps')

## CatSendAndWaitStep\<TRequest,TAnswer\> Class

Built\-in step behind `SendAndWait`\. It hands the request message to the saga and suspends the workflow\.
The saga saves the state first and sends the message after that\. When the answer comes, the step ends and the workflow goes on\.

```csharp
public class CatSendAndWaitStep<TRequest,TAnswer> : Cat.FluentWorkflows.CatResumableStepBody<TAnswer>
    where TRequest : class, Cat.Messaging.Abstractions.ICatMessage
    where TAnswer : class
```
#### Type parameters

<a name='Cat.Sagas.Steps.CatSendAndWaitStep_TRequest,TAnswer_.TRequest'></a>

`TRequest`

The request message\. It is an event or a command message with a parameterless constructor and a settable `CorrelationId`\.

<a name='Cat.Sagas.Steps.CatSendAndWaitStep_TRequest,TAnswer_.TAnswer'></a>

`TAnswer`

The answer the step waits for\. It can be a base class or an interface when the step accepts more than one answer message\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows/CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [Cat\.FluentWorkflows\.CatResumableStepBody&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows/CatResumableStepBody_TAnswer_.md 'Cat\.FluentWorkflows\.CatResumableStepBody\`1')[TAnswer](CatSendAndWaitStep_TRequest,TAnswer_.md#Cat.Sagas.Steps.CatSendAndWaitStep_TRequest,TAnswer_.TAnswer 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.TAnswer')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows/CatResumableStepBody_TAnswer_.md 'Cat\.FluentWorkflows\.CatResumableStepBody\`1') → CatSendAndWaitStep\<TRequest,TAnswer\>

| Constructors | |
| :--- | :--- |
| [CatSendAndWaitStep\(CatSagaContext, ILogger&lt;CatSendAndWaitStep&lt;TRequest,TAnswer&gt;&gt;\)](CatSendAndWaitStep_TRequest,TAnswer_..ctor.8XA457S7Q6LS224ME0SV0XKJE.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.CatSendAndWaitStep\(Cat\.Sagas\.CatSagaContext, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\>\)') | Creates the step and the request, using the parameterless constructor of the request\. |

| Fields | |
| :--- | :--- |
| [\_context](CatSendAndWaitStep_TRequest,TAnswer_._context.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.\_context') | |

| Properties | |
| :--- | :--- |
| [Answer](CatSendAndWaitStep_TRequest,TAnswer_.Answer.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.Answer') | The answer, after the step resumed\. Read it with `Output`\. |
| [Request](CatSendAndWaitStep_TRequest,TAnswer_.Request.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.Request') | The request message\. Fill its members with `Input`\. |

| Methods | |
| :--- | :--- |
| [ResumeAsync\(TAnswer, CancellationToken\)](CatSendAndWaitStep_TRequest,TAnswer_.ResumeAsync.SINGI8J9TDPOHUMMTNHVOX26D.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.ResumeAsync\(TAnswer, System\.Threading\.CancellationToken\)') | |
| [RunAsync\(CancellationToken\)](CatSendAndWaitStep_TRequest,TAnswer_.RunAsync.J6ZDTHIJPRNCHIHJK1R81JMZD.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
