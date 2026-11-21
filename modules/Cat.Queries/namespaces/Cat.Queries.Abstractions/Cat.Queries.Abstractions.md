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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.QUERIES](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Queries\.Abstractions Assembly](index.md 'index')

## Cat\.Queries\.Abstractions Namespace

Defines the contracts for queries: the query marker, the handlers that answer them,
and the processor that finds the right handler and returns an [ICatResponse&lt;TResponse&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')\.

| Classes | |
| :--- | :--- |
| [CatQueryProcessorOrder](CatQueryProcessorOrder.md 'Cat\.Queries\.Abstractions\.CatQueryProcessorOrder') | The default order of the wrappers around [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor'), from the outside in\. A lower number is further out\. It runs first on the way in and last on the way out\. Every module that wraps the processor uses one of these numbers, so the order is the same whatever the sequence of the registration lines\. The numbers are spaced out in steps of 100, so a wrapper of your own can slot in between, for example 150\. |
| [CatQueryProcessorWrapperExtensions](CatQueryProcessorWrapperExtensions.md 'Cat\.Queries\.Abstractions\.CatQueryProcessorWrapperExtensions') | Registers a wrapper around [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor'), such as a cache or a retry\. Wrappers from different modules go in the order of their number, see [CatQueryProcessorOrder](CatQueryProcessorOrder.md 'Cat\.Queries\.Abstractions\.CatQueryProcessorOrder'), and not in the order of the registration lines\. |
| [CatQueryProcessorWrapperExtensions\.CatQueryProcessorWrappers](CatQueryProcessorWrapperExtensions.CatQueryProcessorWrappers.md 'Cat\.Queries\.Abstractions\.CatQueryProcessorWrapperExtensions\.CatQueryProcessorWrappers') | |

| Interfaces | |
| :--- | :--- |
| [ICatQuery&lt;TQueryResult&gt;](ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>') | Marks a query that reads data and returns it in a response\. Handle it with [ICatQueryHandler&lt;TQuery,TQueryResult&gt;](ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>')\. |
| [ICatQueryHandler&lt;TQuery,TQueryResult&gt;](ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>') | Handles one kind of query\. Implement it once per query type\. The module finds and registers it for you\. |
| [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor') | Single entry point for running queries\. It finds the handler for a query, runs it through the registered decorators and returns the response\. |
