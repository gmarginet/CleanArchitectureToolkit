<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries\.Abstractions](index.md 'index')

## Cat\.Queries\.Abstractions Namespace

Defines the contracts for queries: the query marker, the handlers that answer them,
and the processor that finds the right handler and returns an [ICatResponse&lt;TResponse&gt;](../Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')\.

| Interfaces | |
| :--- | :--- |
| [ICatQuery&lt;TQueryResult&gt;](ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>') | Marks a query that reads data and returns it in a response\. Handle it with [ICatQueryHandler&lt;TQuery,TQueryResult&gt;](ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>')\. |
| [ICatQueryHandler&lt;TQuery,TQueryResult&gt;](ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>') | Handles one kind of query\. Implement it once per query type\. The module finds and registers it for you\. |
| [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor') | Single entry point for running queries\. It finds the handler for a query, runs it through the registered decorators and returns the response\. |
