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

## CatSagaWait Class

One open wait of an instance: a wait step that sent its request and has no answer yet\.
An instance with a parallel step can have several\.

```csharp
public class CatSagaWait
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSagaWait

| Properties | |
| :--- | :--- |
| [AnswerType](CatSagaWait.AnswerType.md 'Cat\.Sagas\.Abstractions\.CatSagaWait\.AnswerType') | The assembly qualified name of the type of answer the step waits for\. An answer finds its step by this type\. |
| [StepName](CatSagaWait.StepName.md 'Cat\.Sagas\.Abstractions\.CatSagaWait\.StepName') | The name of the wait step\. A wait step needs a name that is unique in the whole workflow, because an answer and a timeout point at it\. |
| [TimeoutAt](CatSagaWait.TimeoutAt.md 'Cat\.Sagas\.Abstractions\.CatSagaWait\.TimeoutAt') | The moment the wait times out, or null when it has no timeout\. |
| [WaitId](CatSagaWait.WaitId.md 'Cat\.Sagas\.Abstractions\.CatSagaWait\.WaitId') | The id of this wait\. A timeout carries it, so a timeout of an earlier wait never fires a later one\. |
