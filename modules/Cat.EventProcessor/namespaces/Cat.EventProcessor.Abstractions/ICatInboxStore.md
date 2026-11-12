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
  
##### >> [Cat\.EventProcessor\.Abstractions Assembly](index.md 'index') >> [Cat\.EventProcessor\.Abstractions Namespace](Cat.EventProcessor.Abstractions.md 'Cat\.EventProcessor\.Abstractions')

## ICatInboxStore Interface

Remembers which messages the service handled\. The receiver calls it for a message type that has
[UseInbox](CatReceiveOptions.UseInbox.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions\.UseInbox') on\. The store works on the context of the current scope,
the same one the handler uses, so the row is saved by the `SaveChanges` of the handler\.

```csharp
public interface ICatInboxStore
```

| Methods | |
| :--- | :--- |
| [Add\(string, string\)](ICatInboxStore.Add.UU452UCKDNFMMBAMI19088PP6.md 'Cat\.EventProcessor\.Abstractions\.ICatInboxStore\.Add\(string, string\)') | Adds the message to the inbox\. It does not save by itself\. The `SaveChanges` of the handler saves it with the work\. |
| [ExistsAsync\(string, CancellationToken\)](ICatInboxStore.ExistsAsync.4N8X6TCE59U7MPLFMFY3AFQ59.md 'Cat\.EventProcessor\.Abstractions\.ICatInboxStore\.ExistsAsync\(string, System\.Threading\.CancellationToken\)') | Tells whether the message was handled before\. |
