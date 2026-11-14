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

## CatSagaAnswerHandler\<TAnswer\> Class

The handler for an answer message\. It gives the answer to the saga with the same correlation id\.
Register it for a message type with `AddCatSagaAnswer`, and declare the type with `Receive` on the event processor\.

```csharp
public sealed class CatSagaAnswerHandler<TAnswer> : Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TAnswer>
    where TAnswer : class, Cat.Messaging.Abstractions.ICatMessage, Cat.ServiceRequests.Abstractions.ICatServiceRequest
```
#### Type parameters

<a name='Cat.Sagas.CatSagaAnswerHandler_TAnswer_.TAnswer'></a>

`TAnswer`

The answer message\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSagaAnswerHandler\<TAnswer\>

Implements [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')[TAnswer](CatSagaAnswerHandler_TAnswer_.md#Cat.Sagas.CatSagaAnswerHandler_TAnswer_.TAnswer 'Cat\.Sagas\.CatSagaAnswerHandler\<TAnswer\>\.TAnswer')[&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')

| Constructors | |
| :--- | :--- |
| [CatSagaAnswerHandler\(ICatSagaDispatcher\)](CatSagaAnswerHandler_TAnswer_..ctor.T6BL865PIIO6MSOZTV7H5VHOC.md 'Cat\.Sagas\.CatSagaAnswerHandler\<TAnswer\>\.CatSagaAnswerHandler\(Cat\.Sagas\.Abstractions\.ICatSagaDispatcher\)') | Creates the handler\. |

| Fields | |
| :--- | :--- |
| [\_dispatcher](CatSagaAnswerHandler_TAnswer_._dispatcher.md 'Cat\.Sagas\.CatSagaAnswerHandler\<TAnswer\>\.\_dispatcher') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TAnswer, CancellationToken\)](CatSagaAnswerHandler_TAnswer_.HandleAsync.QDHZR0WGYNNMVWGDN8LIFLRL6.md 'Cat\.Sagas\.CatSagaAnswerHandler\<TAnswer\>\.HandleAsync\(TAnswer, System\.Threading\.CancellationToken\)') | Runs the service request\. |
