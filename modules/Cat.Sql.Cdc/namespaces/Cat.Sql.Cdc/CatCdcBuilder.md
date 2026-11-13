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
  
##### >> [Cat\.Sql\.Cdc Assembly](index.md 'index') >> [Cat\.Sql\.Cdc Namespace](Cat.Sql.Cdc.md 'Cat\.Sql\.Cdc')

## CatCdcBuilder Class

Collects the tables to capture\. You get one in `AddCatSqlCdc`\.

```csharp
public sealed class CatCdcBuilder
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCdcBuilder

| Fields | |
| :--- | :--- |
| [NamePattern](CatCdcBuilder.NamePattern.md 'Cat\.Sql\.Cdc\.CatCdcBuilder\.NamePattern') | |
| [\_tables](CatCdcBuilder._tables.md 'Cat\.Sql\.Cdc\.CatCdcBuilder\.\_tables') | |

| Properties | |
| :--- | :--- |
| [Tables](CatCdcBuilder.Tables.md 'Cat\.Sql\.Cdc\.CatCdcBuilder\.Tables') | |

| Methods | |
| :--- | :--- |
| [Add\(string, Func&lt;CatChange,object&gt;\)](CatCdcBuilder.Add.7L96YNDPCYRF19MK5H1LFYL8A.md 'Cat\.Sql\.Cdc\.CatCdcBuilder\.Add\(string, System\.Func\<Cat\.Sql\.Cdc\.Abstractions\.CatChange,object\>\)') | |
| [AddTable\(string\)](CatCdcBuilder.AddTable.md#Cat.Sql.Cdc.CatCdcBuilder.AddTable(string) 'Cat\.Sql\.Cdc\.CatCdcBuilder\.AddTable\(string\)') | Captures a table and sends every change as it is\. The sink gets the [CatChange](../../../Cat.Sql.Cdc/namespaces/Cat.Sql.Cdc.Abstractions/CatChange.md 'Cat\.Sql\.Cdc\.Abstractions\.CatChange') as the message\. |
| [AddTable&lt;TMessage&gt;\(string, Action&lt;CatCdcTableBuilder&lt;TMessage&gt;&gt;\)](CatCdcBuilder.AddTable.md#Cat.Sql.Cdc.CatCdcBuilder.AddTable_TMessage_(string,System.Action_Cat.Sql.Cdc.CatCdcTableBuilder_TMessage__) 'Cat\.Sql\.Cdc\.CatCdcBuilder\.AddTable\<TMessage\>\(string, System\.Action\<Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>\>\)') | Captures a table and turns every change into a message of your own type\. |
