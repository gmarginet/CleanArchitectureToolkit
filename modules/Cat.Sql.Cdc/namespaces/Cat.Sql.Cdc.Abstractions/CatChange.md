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
  
##### >> [Cat\.Sql\.Cdc\.Abstractions Assembly](index.md 'index') >> [Cat\.Sql\.Cdc\.Abstractions Namespace](Cat.Sql.Cdc.Abstractions.md 'Cat\.Sql\.Cdc\.Abstractions')

## CatChange Class

One captured row change\. It is the unit the module hands to the sink: one message per row change\.

```csharp
public class CatChange
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatChange

| Properties | |
| :--- | :--- |
| [Keys](CatChange.Keys.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.Keys') | The key columns and their values\. Empty when the capture instance has no index columns\. |
| [Lsn](CatChange.Lsn.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.Lsn') | The log sequence number of the transaction that made the change\. It is 10 bytes\. |
| [MessageId](CatChange.MessageId.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.MessageId') | A stable id for this change, made from the LSN, the sequence value and the operation\. The same change always gets the same id, so a bus can drop a repeat and a receiver can recognize one\. The module uses it as the message id\. |
| [New](CatChange.New.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.New') | The values after the change\. It is `null` for a delete\. |
| [Old](CatChange.Old.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.Old') | The values before the change\. It is `null` for an insert\. |
| [Operation](CatChange.Operation.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.Operation') | What happened to the row\. |
| [SequenceValue](CatChange.SequenceValue.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.SequenceValue') | The sequence value that orders the row changes inside one transaction\. It is 10 bytes\. |
| [Table](CatChange.Table.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.Table') | The capture instance the change comes from, such as `dbo_BookPrice`\. |
| [TransactionId](CatChange.TransactionId.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.TransactionId') | The id of the transaction, from `cdc.lsn_time_mapping`\. All changes of one transaction share it\. |
| [TransactionTime](CatChange.TransactionTime.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange\.TransactionTime') | When the transaction committed\. |
