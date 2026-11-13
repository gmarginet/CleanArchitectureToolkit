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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor\.Authorization Assembly](index.md 'index') >> [Cat\.EventProcessor\.Authorization Namespace](Cat.EventProcessor.Authorization.md 'Cat\.EventProcessor\.Authorization') >> [CatMessageAuthorizer Class](CatMessageAuthorizer.md 'Cat\.EventProcessor\.Authorization\.CatMessageAuthorizer')

## CatMessageAuthorizer\.AuthorizeAsync\(CatIncomingMessage, CatReceiveOptions, CancellationToken\) Method

Reads the token of the message, sets the user of the scope and checks the policy of the message type\.

```csharp
public System.Threading.Tasks.Task<Cat.EventProcessor.Abstractions.CatAuthorizationResult> AuthorizeAsync(Cat.EventProcessor.Abstractions.CatIncomingMessage message, Cat.EventProcessor.Abstractions.CatReceiveOptions options, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.EventProcessor.Authorization.CatMessageAuthorizer.AuthorizeAsync(Cat.EventProcessor.Abstractions.CatIncomingMessage,Cat.EventProcessor.Abstractions.CatReceiveOptions,System.Threading.CancellationToken).message'></a>

`message` [CatIncomingMessage](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatIncomingMessage.md 'Cat\.EventProcessor\.Abstractions\.CatIncomingMessage')

The incoming message\.

<a name='Cat.EventProcessor.Authorization.CatMessageAuthorizer.AuthorizeAsync(Cat.EventProcessor.Abstractions.CatIncomingMessage,Cat.EventProcessor.Abstractions.CatReceiveOptions,System.Threading.CancellationToken).options'></a>

`options` [CatReceiveOptions](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatReceiveOptions.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions')

The settings of the message type, with its policy\.

<a name='Cat.EventProcessor.Authorization.CatMessageAuthorizer.AuthorizeAsync(Cat.EventProcessor.Abstractions.CatIncomingMessage,Cat.EventProcessor.Abstractions.CatReceiveOptions,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [AuthorizeAsync\(CatIncomingMessage, CatReceiveOptions, CancellationToken\)](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/ICatMessageAuthorizer.AuthorizeAsync.TPMAGSOMK6XLIJQYYP93QM4O8.md 'Cat\.EventProcessor\.Abstractions\.ICatMessageAuthorizer\.AuthorizeAsync\(Cat\.EventProcessor\.Abstractions\.CatIncomingMessage,Cat\.EventProcessor\.Abstractions\.CatReceiveOptions,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CatAuthorizationResult](../../../Cat.EventProcessor/namespaces/Cat.EventProcessor.Abstractions/CatAuthorizationResult.md 'Cat\.EventProcessor\.Abstractions\.CatAuthorizationResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
Whether the handler may run, and why not when it may not\.