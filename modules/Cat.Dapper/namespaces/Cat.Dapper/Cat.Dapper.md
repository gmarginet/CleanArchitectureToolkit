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
  
##### >> [Cat\.Dapper Assembly](index.md 'index')

## Cat\.Dapper Namespace

Holds the session that gives a handler one connection, the base classes for query and command handlers
that use plain SQL, the extension methods that run the SQL with Dapper, and the result of a bulk merge\. It works with any database\.

| Classes | |
| :--- | :--- |
| [BulkColumn](BulkColumn.md 'Cat\.Dapper\.BulkColumn') | One column of a bulk call: its name, the type of its values and how to read it from a row\. |
| [BulkColumns](BulkColumns.md 'Cat\.Dapper\.BulkColumns') | Finds the columns of a row class by reflection, once per type, and keeps them\. |
| [BulkPlan](BulkPlan.md 'Cat\.Dapper\.BulkPlan') | The checks and the column choices that the bulk operations of every database share\. |
| [CatBulkMergeResult](CatBulkMergeResult.md 'Cat\.Dapper\.CatBulkMergeResult') | The outcome of a bulk merge, on every database that has one\. |
| [CatDapperCommandHandlerBase&lt;TCommand,TResult&gt;](CatDapperCommandHandlerBase_TCommand,TResult_.md 'Cat\.Dapper\.CatDapperCommandHandlerBase\<TCommand,TResult\>') | Base class for command handlers that change data with plain SQL and Dapper and return a result\. It only gives the handler its [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')\. The handler decides when to start a transaction and when to commit it\. |
| [CatDapperCommandHandlerBase&lt;TCommand&gt;](CatDapperCommandHandlerBase_TCommand_.md 'Cat\.Dapper\.CatDapperCommandHandlerBase\<TCommand\>') | Base class for command handlers that change data with plain SQL and Dapper and return no result\. It only gives the handler its [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')\. The handler decides when to start a transaction and when to commit it\. |
| [CatDapperQueryHandlerBase&lt;TQuery,TQueryResult&gt;](CatDapperQueryHandlerBase_TQuery,TQueryResult_.md 'Cat\.Dapper\.CatDapperQueryHandlerBase\<TQuery,TQueryResult\>') | Base class for query handlers that read with plain SQL and Dapper\. It holds the [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')\. Run the SQL with the extension methods of [CatDbSessionExtensions](CatDbSessionExtensions.md 'Cat\.Dapper\.CatDbSessionExtensions')\. |
| [CatDbSession](CatDbSession.md 'Cat\.Dapper\.CatDbSession') | The default [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')\. It takes one connection from the factory, opens it on first use and disposes it, and a transaction that was not committed, with the scope\. |
| [CatDbSessionExtensions](CatDbSessionExtensions.md 'Cat\.Dapper\.CatDbSessionExtensions') | Runs plain SQL on a [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession') with Dapper\. Every method opens the connection when it is needed and takes part in the transaction of the session, if one is running\. |
| [ColumnPlan](ColumnPlan.md 'Cat\.Dapper\.ColumnPlan') | The columns of an update, a delete or a merge: the key columns and the columns to change\. |
