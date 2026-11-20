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
  
##### >> [Cat\.Dapper\.PostgreSQL Assembly](index.md 'index')

## Cat\.Dapper\.PostgreSQL Namespace

Holds what is specific to PostgreSQL: the connection factory, a paging helper that returns an
[ICatPagedList&lt;TList&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1') and the bulk operations\.

| Classes | |
| :--- | :--- |
| [BulkRowSource](BulkRowSource.md 'Cat\.Dapper\.PostgreSQL\.BulkRowSource') | The rows that go to a `COPY`, one at a time\. |
| [EnumerableRowSource&lt;T&gt;](EnumerableRowSource_T_.md 'Cat\.Dapper\.PostgreSQL\.EnumerableRowSource\<T\>') | Rows from a list of objects, read through the columns of the row class\. |
| [ImporterWriter](ImporterWriter.md 'Cat\.Dapper\.PostgreSQL\.ImporterWriter') | Writes a value of any type to a binary importer\. The importer picks the PostgreSQL type from the type of the value, so the type of the value must match the type of the column\. |
| [PostgreSQLBulkExtensions](PostgreSQLBulkExtensions.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkExtensions') | Bulk insert, update, delete and merge on PostgreSQL, on the connection and the transaction of the session\. |
| [PostgreSQLBulkSql](PostgreSQLBulkSql.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql') | Builds the SQL text of the bulk operations\. Every table and column name goes through [QuoteName\(string\)](PostgreSQLBulkSql.QuoteName.BTCXSMZ5IG7MGGZ4A39TGZAA1.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLBulkSql\.QuoteName\(string\)')\. |
| [PostgreSQLConnectionFactory](PostgreSQLConnectionFactory.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLConnectionFactory') | Creates PostgreSQL connections for one connection string\. |
| [PostgreSQLPagingExtensions](PostgreSQLPagingExtensions.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLPagingExtensions') | Paging with plain SQL on PostgreSQL, with the same result as the paging of `Cat.EFCore.Queries`\. |
| [ReaderRowSource](ReaderRowSource.md 'Cat\.Dapper\.PostgreSQL\.ReaderRowSource') | Rows from a data reader\. The source does not close the reader\. |
