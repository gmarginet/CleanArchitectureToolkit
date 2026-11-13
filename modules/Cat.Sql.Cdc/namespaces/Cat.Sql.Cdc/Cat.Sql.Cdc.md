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
  
##### >> [Cat\.Sql\.Cdc Assembly](index.md 'index')

## Cat\.Sql\.Cdc Namespace

Reads the change data capture tables of SQL Server and hands every row change to a sink\. It keeps its position in the captured database, runs as a hosted service and reports its health\.

| Classes | |
| :--- | :--- |
| [CatCdcBinary](CatCdcBinary.md 'Cat\.Sql\.Cdc\.CatCdcBinary') | |
| [CatCdcBuilder](CatCdcBuilder.md 'Cat\.Sql\.Cdc\.CatCdcBuilder') | Collects the tables to capture\. You get one in `AddCatSqlCdc`\. |
| [CatCdcGapException](CatCdcGapException.md 'Cat\.Sql\.Cdc\.CatCdcGapException') | The change tables were cleaned up past the position of the reader, so changes may be lost\. The reader of the table stops and reports unhealthy\. See [CatCdcGapBehavior](CatCdcGapBehavior.md 'Cat\.Sql\.Cdc\.CatCdcGapBehavior')\. |
| [CatCdcHealthCheck](CatCdcHealthCheck.md 'Cat\.Sql\.Cdc\.CatCdcHealthCheck') | |
| [CatCdcPosition](CatCdcPosition.md 'Cat\.Sql\.Cdc\.CatCdcPosition') | The place the reader has come to: everything up to and including this LSN and sequence value is handed over\. A `null` sequence value means the whole LSN is still to be read\. |
| [CatCdcRawRow](CatCdcRawRow.md 'Cat\.Sql\.Cdc\.CatCdcRawRow') | A row as it comes out of the change function\. Operation 1 is a delete, 2 an insert, 3 the old values of an update and 4 the new values\. |
| [CatCdcRowMapper](CatCdcRowMapper.md 'Cat\.Sql\.Cdc\.CatCdcRowMapper') | |
| [CatCdcService](CatCdcService.md 'Cat\.Sql\.Cdc\.CatCdcService') | The hosted service\. It runs one loop for every captured table\. |
| [CatCdcSettings](CatCdcSettings.md 'Cat\.Sql\.Cdc\.CatCdcSettings') | The settings of the reader\. Bind them from the configuration section `CatSqlCdc`\. |
| [CatCdcStatus](CatCdcStatus.md 'Cat\.Sql\.Cdc\.CatCdcStatus') | What the readers report: which table stopped for good, and which one failed on its last poll\. The health check reads it\. |
| [CatCdcTable](CatCdcTable.md 'Cat\.Sql\.Cdc\.CatCdcTable') | One captured table and what its changes become\. |
| [CatCdcTableBuilder&lt;TMessage&gt;](CatCdcTableBuilder_TMessage_.md 'Cat\.Sql\.Cdc\.CatCdcTableBuilder\<TMessage\>') | Sets the mapping of one table to a message type\. |
| [CatCdcTableReader](CatCdcTableReader.md 'Cat\.Sql\.Cdc\.CatCdcTableReader') | Reads one capture instance\. One call of [PollAsync\(CancellationToken\)](CatCdcTableReader.PollAsync.L0BOLLOUDHMFKYKZEEK2KDWBA.md 'Cat\.Sql\.Cdc\.CatCdcTableReader\.PollAsync\(System\.Threading\.CancellationToken\)') is one round: claim, read, hand over, save the position\. The position is saved after the changes were handed to the sink, so a crash in between repeats them \(at least once\)\. |
| [CatSqlCdcTelemetry](CatSqlCdcTelemetry.md 'Cat\.Sql\.Cdc\.CatSqlCdcTelemetry') | The meter of the module\. Add [SourceName](CatSqlCdcTelemetry.SourceName.md 'Cat\.Sql\.Cdc\.CatSqlCdcTelemetry\.SourceName') to your OpenTelemetry setup to collect the metrics\. |
| [SqlServerCdcDatabase](SqlServerCdcDatabase.md 'Cat\.Sql\.Cdc\.SqlServerCdcDatabase') | The SQL Server side of the reader\. It calls the change data capture functions and keeps the position in a table of its own\. A capture instance name is part of a function name, so it is checked before it goes into the SQL text\. Every other value goes in as a parameter\. |

| Interfaces | |
| :--- | :--- |
| [ICatCdcDatabase](ICatCdcDatabase.md 'Cat\.Sql\.Cdc\.ICatCdcDatabase') | Everything the reader needs from the database: the change tables, the position and the claim\. |

| Enums | |
| :--- | :--- |
| [CatCdcGapBehavior](CatCdcGapBehavior.md 'Cat\.Sql\.Cdc\.CatCdcGapBehavior') | What to do when the change tables were cleaned up past the position of the reader, so changes may be lost\. |
