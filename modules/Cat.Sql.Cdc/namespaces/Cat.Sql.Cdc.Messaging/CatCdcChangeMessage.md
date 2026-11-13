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

## CatCdcChangeMessage Class

The message a table gets when it is added without a mapping\. It carries the change as column dictionaries\.
Map the table to a message of your own to get a typed message instead\.

```csharp
public class CatCdcChangeMessage : Cat.Messaging.Abstractions.CatEventMessage
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatEventMessage](../../../Cat.Messaging/namespaces/Cat.Messaging.Abstractions/CatEventMessage.md 'Cat\.Messaging\.Abstractions\.CatEventMessage') → CatCdcChangeMessage

| Properties | |
| :--- | :--- |
| [Keys](CatCdcChangeMessage.Keys.md 'Cat\.Sql\.Cdc\.Messaging\.CatCdcChangeMessage\.Keys') | The key columns and their values\. |
| [New](CatCdcChangeMessage.New.md 'Cat\.Sql\.Cdc\.Messaging\.CatCdcChangeMessage\.New') | The values after the change, or `null` for a delete\. |
| [Old](CatCdcChangeMessage.Old.md 'Cat\.Sql\.Cdc\.Messaging\.CatCdcChangeMessage\.Old') | The values before the change, or `null` for an insert\. |
| [Operation](CatCdcChangeMessage.Operation.md 'Cat\.Sql\.Cdc\.Messaging\.CatCdcChangeMessage\.Operation') | What happened to the row\. |
| [Table](CatCdcChangeMessage.Table.md 'Cat\.Sql\.Cdc\.Messaging\.CatCdcChangeMessage\.Table') | The capture instance the change comes from\. |
| [TransactionId](CatCdcChangeMessage.TransactionId.md 'Cat\.Sql\.Cdc\.Messaging\.CatCdcChangeMessage\.TransactionId') | The id of the transaction\. All changes of one transaction share it\. |
| [TransactionTime](CatCdcChangeMessage.TransactionTime.md 'Cat\.Sql\.Cdc\.Messaging\.CatCdcChangeMessage\.TransactionTime') | When the transaction committed\. |
