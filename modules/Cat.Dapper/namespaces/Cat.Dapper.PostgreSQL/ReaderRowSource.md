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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.DAPPER](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Dapper\.PostgreSQL Assembly](index.md 'index') >> [Cat\.Dapper\.PostgreSQL Namespace](Cat.Dapper.PostgreSQL.md 'Cat\.Dapper\.PostgreSQL')

## ReaderRowSource Class

Rows from a data reader\. The source does not close the reader\.

```csharp
internal sealed class ReaderRowSource : Cat.Dapper.PostgreSQL.BulkRowSource
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [BulkRowSource](BulkRowSource.md 'Cat\.Dapper\.PostgreSQL\.BulkRowSource') → ReaderRowSource

| Constructors | |
| :--- | :--- |
| [ReaderRowSource\(IDataReader\)](ReaderRowSource..ctor.O7JNICGC7FK06AKUFUAT7KPBC.md 'Cat\.Dapper\.PostgreSQL\.ReaderRowSource\.ReaderRowSource\(System\.Data\.IDataReader\)') | |

| Fields | |
| :--- | :--- |
| [\_reader](ReaderRowSource._reader.md 'Cat\.Dapper\.PostgreSQL\.ReaderRowSource\.\_reader') | |

| Properties | |
| :--- | :--- |
| [FieldCount](ReaderRowSource.FieldCount.md 'Cat\.Dapper\.PostgreSQL\.ReaderRowSource\.FieldCount') | |

| Methods | |
| :--- | :--- |
| [GetValue\(int\)](ReaderRowSource.GetValue.86DXU0Z849MFPA25MC1L63L5D.md 'Cat\.Dapper\.PostgreSQL\.ReaderRowSource\.GetValue\(int\)') | |
| [Read\(\)](ReaderRowSource.Read().md 'Cat\.Dapper\.PostgreSQL\.ReaderRowSource\.Read\(\)') | |
