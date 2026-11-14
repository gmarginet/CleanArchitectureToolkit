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

## Cat\.Sagas\.Steps Namespace

| Classes | |
| :--- | :--- |
| [CatSendAndWaitStep&lt;TRequest,TAnswer&gt;](CatSendAndWaitStep_TRequest,TAnswer_.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>') | Built\-in step behind `SendAndWait`\. It hands the request message to the saga and suspends the workflow\. The saga saves the state first and sends the message after that\. When the answer comes, the step ends and the workflow goes on\. When the wait has a timeout and it passes first, the step ends with [TimedOut](CatSendAndWaitStep_TRequest,TAnswer_.TimedOut.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.TimedOut') set and no [Answer](CatSendAndWaitStep_TRequest,TAnswer_.Answer.md 'Cat\.Sagas\.Steps\.CatSendAndWaitStep\<TRequest,TAnswer\>\.Answer')\. |
