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
  
##### >> [Cat\.Dapper\.SqlServer Assembly](index.md 'index')

## Cat\.Dapper\.SqlServer Namespace

Holds what is specific to SQL Server: the connection factory and a paging helper that returns an
[ICatPagedList&lt;TList&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatPagedList_TList_.md 'Cat\.Responses\.Abstractions\.ICatPagedList\`1')\.

| Classes | |
| :--- | :--- |
| [BulkColumn](BulkColumn.md 'Cat\.Dapper\.SqlServer\.BulkColumn') | One column of a bulk call: its name, the type of its values and how to read it from a row\. |
| [BulkColumns](BulkColumns.md 'Cat\.Dapper\.SqlServer\.BulkColumns') | Finds the columns of a row class by reflection, once per type, and keeps them\. |
| [BulkDataReader&lt;T&gt;](BulkDataReader_T_.md 'Cat\.Dapper\.SqlServer\.BulkDataReader\<T\>') | Streams the rows of an enumerable to `SqlBulkCopy` one at a time, so the rows are never copied into a table in memory\. |
| [CatBulkMergeResult](CatBulkMergeResult.md 'Cat\.Dapper\.SqlServer\.CatBulkMergeResult') | The outcome of a bulk merge\. |
| [SqlServerBulkExtensions](SqlServerBulkExtensions.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions') | Bulk insert, update, delete and merge on SQL Server, on the connection and the transaction of the session\. |
| [SqlServerBulkExtensions\.ColumnPlan](SqlServerBulkExtensions.ColumnPlan.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkExtensions\.ColumnPlan') | |
| [SqlServerBulkSql](SqlServerBulkSql.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql') | Builds the SQL text of the bulk operations\. Every table and column name goes through [QuoteName\(string\)](SqlServerBulkSql.QuoteName.YWQRMXMN2RQ1R9COJGRX9YWU9.md 'Cat\.Dapper\.SqlServer\.SqlServerBulkSql\.QuoteName\(string\)')\. |
| [SqlServerConnectionFactory](SqlServerConnectionFactory.md 'Cat\.Dapper\.SqlServer\.SqlServerConnectionFactory') | Creates SQL Server connections for one connection string\. |
| [SqlServerPagingExtensions](SqlServerPagingExtensions.md 'Cat\.Dapper\.SqlServer\.SqlServerPagingExtensions') | Paging with plain SQL on SQL Server, with the same result as the paging of `Cat.EFCore.Queries`\. |
