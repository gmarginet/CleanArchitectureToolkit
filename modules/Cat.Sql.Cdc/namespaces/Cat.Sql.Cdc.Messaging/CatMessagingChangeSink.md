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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SQL.CDC](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sql\.Cdc\.Messaging Assembly](index.md 'index') >> [Cat\.Sql\.Cdc\.Messaging Namespace](Cat.Sql.Cdc.Messaging.md 'Cat\.Sql\.Cdc\.Messaging')

## CatMessagingChangeSink Class

Sends the changes as event messages through [ICatMessageSender](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/ICatMessageSender.md 'Cat\.Messaging\.Abstractions\.ICatMessageSender')\.
The message id is always the id of the change, so the bus can drop a repeat\.
It sends straight to the transport and does not use an outbox: the position of the reader is the safety net, and a failed send repeats the change\.

```csharp
public class CatMessagingChangeSink : Cat.Sql.Cdc.Abstractions.ICatChangeSink
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMessagingChangeSink

Implements [ICatChangeSink](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/ICatChangeSink.md 'Cat\.Sql\.Cdc\.Abstractions\.ICatChangeSink')

| Constructors | |
| :--- | :--- |
| [CatMessagingChangeSink\(IServiceScopeFactory\)](CatMessagingChangeSink..ctor.0UNTVYNH9ASDW2OJZK4S00ZV.md 'Cat\.Sql\.Cdc\.Messaging\.CatMessagingChangeSink\.CatMessagingChangeSink\(Microsoft\.Extensions\.DependencyInjection\.IServiceScopeFactory\)') | Creates the sink\. |

| Fields | |
| :--- | :--- |
| [\_scopeFactory](CatMessagingChangeSink._scopeFactory.md 'Cat\.Sql\.Cdc\.Messaging\.CatMessagingChangeSink\.\_scopeFactory') | |

| Methods | |
| :--- | :--- |
| [Convert\(CatChange\)](CatMessagingChangeSink.Convert.011XK7JMH4G20YZPK5WJ8EG58.md 'Cat\.Sql\.Cdc\.Messaging\.CatMessagingChangeSink\.Convert\(Cat\.Sql\.Cdc\.Abstractions\.CatChange\)') | |
| [SendAsync\(CatChange, object, CancellationToken\)](CatMessagingChangeSink.SendAsync.NK2AT9ELHT2CCMMGJ2RWVYQH9.md 'Cat\.Sql\.Cdc\.Messaging\.CatMessagingChangeSink\.SendAsync\(Cat\.Sql\.Cdc\.Abstractions\.CatChange, object, System\.Threading\.CancellationToken\)') | Sends one change\. When it throws, the module does not move its position and tries the same change again\. |
