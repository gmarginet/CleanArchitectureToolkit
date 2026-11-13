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

## CatCdcTableReader Class

Reads one capture instance\. One call of [PollAsync\(CancellationToken\)](CatCdcTableReader.PollAsync.L0BOLLOUDHMFKYKZEEK2KDWBA.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.PollAsync\(System\.Threading\.CancellationToken\)') is one round: claim, read, hand over, save the position\.
The position is saved after the changes were handed to the sink, so a crash in between repeats them \(at least once\)\.

```csharp
internal sealed class CatCdcTableReader
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCdcTableReader

| Constructors | |
| :--- | :--- |
| [CatCdcTableReader\(CatCdcTable, ICatCdcDatabase, ICatChangeSink, CatCdcSettings, string, ILogger\)](CatCdcTableReader..ctor.T1ZEYODWL3INEJMZMWZMDT2Q5.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.CatCdcTableReader\(Cat\.Sql\.Cdc\.CatCdcTable, Cat\.Sql\.Cdc\.ICatCdcDatabase, Cat\.Sql\.Cdc\.Abstractions\.ICatChangeSink, Cat\.Sql\.Cdc\.CatCdcSettings, string, Microsoft\.Extensions\.Logging\.ILogger\)') | |

| Fields | |
| :--- | :--- |
| [\_database](CatCdcTableReader._database.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.\_database') | |
| [\_keyColumns](CatCdcTableReader._keyColumns.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.\_keyColumns') | |
| [\_logger](CatCdcTableReader._logger.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.\_logger') | |
| [\_owner](CatCdcTableReader._owner.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.\_owner') | |
| [\_settings](CatCdcTableReader._settings.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.\_settings') | |
| [\_sink](CatCdcTableReader._sink.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.\_sink') | |
| [\_table](CatCdcTableReader._table.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.\_table') | |

| Properties | |
| :--- | :--- |
| [Name](CatCdcTableReader.Name.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.Name') | |

| Methods | |
| :--- | :--- |
| [InitializeAsync\(CancellationToken\)](CatCdcTableReader.InitializeAsync.O7C244GHBI59V8FCNI4BCFQW9.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.InitializeAsync\(System\.Threading\.CancellationToken\)') | |
| [PollAsync\(CancellationToken\)](CatCdcTableReader.PollAsync.L0BOLLOUDHMFKYKZEEK2KDWBA.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.PollAsync\(System\.Threading\.CancellationToken\)') | Does one round\. |
| [SaveAsync\(CatCdcPosition, CancellationToken\)](CatCdcTableReader.SaveAsync.PSC4LHQESRTW9U439DLRLK7TA.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.SaveAsync\(Cat\.Sql\.Cdc\.CatCdcPosition, System\.Threading\.CancellationToken\)') | |
