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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MESSAGING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Messaging\.Outbox Assembly](index.md 'index') >> [Cat\.Messaging\.Outbox\.Extensions Namespace](Cat.Messaging.Outbox.Extensions.md 'Cat\.Messaging\.Outbox\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the outbox\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatMessagingOutbox\(this IServiceCollection, Action&lt;CatOutboxOptions&gt;\)](ServiceCollectionExtensions.AddCatMessagingOutbox.RHC2GIP1FL69S5KQBYMUJZ5W8.md 'Cat\.Messaging\.Outbox\.Extensions\.ServiceCollectionExtensions\.AddCatMessagingOutbox\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Action\<Cat\.Messaging\.Outbox\.CatOutboxOptions\>\)') | Turns the outbox on\. The message sender then stores messages instead of sending them, and a background service sends the stored messages to the transport\. Call it after `AddCatMessagingModule`, and register an [ICatOutboxStore](ICatOutboxStore.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore') too, such as the one from `Cat.Messaging.Outbox.EFCore`\. |
