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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.QUERIES](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Queries\.Abstractions Assembly](index.md 'index')

## Cat\.Queries\.Abstractions Namespace

Defines the contracts for queries: the query marker, the handlers that answer them,
and the processor that finds the right handler and returns an [ICatResponse&lt;TResponse&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')\.

| Interfaces | |
| :--- | :--- |
| [ICatQuery&lt;TQueryResult&gt;](ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>') | Marks a query that reads data and returns it in a response\. Handle it with [ICatQueryHandler&lt;TQuery,TQueryResult&gt;](ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>')\. |
| [ICatQueryHandler&lt;TQuery,TQueryResult&gt;](ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>') | Handles one kind of query\. Implement it once per query type\. The module finds and registers it for you\. |
| [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor') | Single entry point for running queries\. It finds the handler for a query, runs it through the registered decorators and returns the response\. |
