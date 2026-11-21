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

## ICatHandledMessages Interface

Remembers the messages that were handled, so the receiver can skip a message that comes again\.
The receiver asks the container for it when [UseInbox](CatReceiveOptions.UseInbox.md 'Cat\.EventProcessor\.Abstractions\.CatReceiveOptions\.UseInbox') is on\.
Register it with the project `Cat.EventProcessor.Inbox`, which uses the inbox of `Cat.Inbox`\.

```csharp
public interface ICatHandledMessages
```

### Remarks
[MarkHandled\(string, string\)](ICatHandledMessages.MarkHandled.V2UADE1CLQW8M7YJS2VYHCE7D.md 'Cat\.EventProcessor\.Abstractions\.ICatHandledMessages\.MarkHandled\(string, string\)') only adds a row to the unit of work of the current scope\. The handler saves it
            with the work, in one `SaveChanges`, so a message that fails leaves nothing behind\.

| Methods | |
| :--- | :--- |
| [MarkHandled\(string, string\)](ICatHandledMessages.MarkHandled.V2UADE1CLQW8M7YJS2VYHCE7D.md 'Cat\.EventProcessor\.Abstractions\.ICatHandledMessages\.MarkHandled\(string, string\)') | Adds a row for the message to the unit of work of the current scope\. It does not save\. |
| [WasHandledAsync\(string, CancellationToken\)](ICatHandledMessages.WasHandledAsync.JBNDRWBMDFI99Q1KSK1VT93T6.md 'Cat\.EventProcessor\.Abstractions\.ICatHandledMessages\.WasHandledAsync\(string, System\.Threading\.CancellationToken\)') | Tells whether the message was handled before\. |
