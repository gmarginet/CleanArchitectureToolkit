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
  
##### >> [Cat\.EventProcessor\.Inbox\.EFCore Assembly](index.md 'index') >> [Cat\.EventProcessor\.Inbox\.EFCore Namespace](Cat.EventProcessor.Inbox.EFCore.md 'Cat\.EventProcessor\.Inbox\.EFCore') >> [InboxDecorator Class](InboxDecorator.md 'Cat\.EventProcessor\.Inbox\.EFCore\.InboxDecorator')

## InboxDecorator\.CatServiceRequestHandler\<TRequest\> Class

```csharp
internal sealed class InboxDecorator.CatServiceRequestHandler<TRequest> : Cat.ServiceRequests.Abstractions.ICatServiceRequestHandler<TRequest>
    where TRequest : class, Cat.ServiceRequests.Abstractions.ICatServiceRequest
```
#### Type parameters

<a name='Cat.EventProcessor.Inbox.EFCore.InboxDecorator.CatServiceRequestHandler_TRequest_.TRequest'></a>

`TRequest`

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatServiceRequestHandler\<TRequest\>

Implements [Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler&lt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')[TRequest](InboxDecorator.CatServiceRequestHandler_TRequest_.md#Cat.EventProcessor.Inbox.EFCore.InboxDecorator.CatServiceRequestHandler_TRequest_.TRequest 'Cat\.EventProcessor\.Inbox\.EFCore\.InboxDecorator\.CatServiceRequestHandler\<TRequest\>\.TRequest')[&gt;](../../../Cat.ServiceRequests/namespaces/Cat.ServiceRequests.Abstractions/ICatServiceRequestHandler_TRequest_.md 'Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\`1')

| Constructors | |
| :--- | :--- |
| [CatServiceRequestHandler\(ICatServiceRequestHandler&lt;TRequest&gt;, ICatInboxStore\)](InboxDecorator.CatServiceRequestHandler_TRequest_..ctor.OU558TLI696NE4Y0AB5BG4378.md 'Cat\.EventProcessor\.Inbox\.EFCore\.InboxDecorator\.CatServiceRequestHandler\<TRequest\>\.CatServiceRequestHandler\(Cat\.ServiceRequests\.Abstractions\.ICatServiceRequestHandler\<TRequest\>, Cat\.EventProcessor\.Inbox\.EFCore\.ICatInboxStore\)') | |

| Fields | |
| :--- | :--- |
| [\_innerHandler](InboxDecorator.CatServiceRequestHandler_TRequest_._innerHandler.md 'Cat\.EventProcessor\.Inbox\.EFCore\.InboxDecorator\.CatServiceRequestHandler\<TRequest\>\.\_innerHandler') | |
| [\_store](InboxDecorator.CatServiceRequestHandler_TRequest_._store.md 'Cat\.EventProcessor\.Inbox\.EFCore\.InboxDecorator\.CatServiceRequestHandler\<TRequest\>\.\_store') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TRequest, CancellationToken\)](InboxDecorator.CatServiceRequestHandler_TRequest_.HandleAsync.KQBIUFQAL95YNPURNQ3QU4IIA.md 'Cat\.EventProcessor\.Inbox\.EFCore\.InboxDecorator\.CatServiceRequestHandler\<TRequest\>\.HandleAsync\(TRequest, System\.Threading\.CancellationToken\)') | |
