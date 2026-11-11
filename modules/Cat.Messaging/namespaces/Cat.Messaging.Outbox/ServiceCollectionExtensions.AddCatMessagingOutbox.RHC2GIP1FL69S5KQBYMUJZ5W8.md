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
  
##### >> [Cat\.Messaging\.Outbox Assembly](index.md 'index') >> [Cat\.Messaging\.Outbox\.Extensions Namespace](Cat.Messaging.Outbox.Extensions.md 'Cat\.Messaging\.Outbox\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Messaging\.Outbox\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatMessagingOutbox\(this IServiceCollection, Action\<CatOutboxOptions\>\) Method

Turns the outbox on\. The message sender then stores messages instead of sending them,
and a background service sends the stored messages to the transport\.
Call it after `AddCatMessagingModule`, and register an [ICatOutboxStore](ICatOutboxStore.md 'Cat\.Messaging\.Outbox\.ICatOutboxStore') too,
such as the one from `Cat.Messaging.Outbox.EFCore`\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatMessagingOutbox(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Cat.Messaging.Outbox.CatOutboxOptions>? configure=null);
```
#### Parameters

<a name='Cat.Messaging.Outbox.Extensions.ServiceCollectionExtensions.AddCatMessagingOutbox(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Messaging.Outbox.CatOutboxOptions_).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.Messaging.Outbox.Extensions.ServiceCollectionExtensions.AddCatMessagingOutbox(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Messaging.Outbox.CatOutboxOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatOutboxOptions](CatOutboxOptions.md 'Cat\.Messaging\.Outbox\.CatOutboxOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Changes the settings of the outbox sender\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, so calls can be chained\.