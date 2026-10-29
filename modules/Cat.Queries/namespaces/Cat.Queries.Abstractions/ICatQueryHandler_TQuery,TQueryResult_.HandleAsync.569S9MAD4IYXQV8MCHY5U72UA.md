<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries\.Abstractions](index.md 'index') > [Cat\.Queries\.Abstractions](Cat.Queries.Abstractions.md 'Cat\.Queries\.Abstractions') > [ICatQueryHandler&lt;TQuery,TQueryResult&gt;](ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>')

## ICatQueryHandler\<TQuery,TQueryResult\>\.HandleAsync\(TQuery, CancellationToken\) Method

Runs the query\.

```csharp
System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TQueryResult>> HandleAsync(TQuery query, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Queries.Abstractions.ICatQueryHandler_TQuery,TQueryResult_.HandleAsync(TQuery,System.Threading.CancellationToken).query'></a>

`query` [TQuery](ICatQueryHandler_TQuery,TQueryResult_.md#Cat.Queries.Abstractions.ICatQueryHandler_TQuery,TQueryResult_.TQuery 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>\.TQuery')

The query to handle\.

<a name='Cat.Queries.Abstractions.ICatQueryHandler_TQuery,TQueryResult_.HandleAsync(TQuery,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TQueryResult](ICatQueryHandler_TQuery,TQueryResult_.md#Cat.Queries.Abstractions.ICatQueryHandler_TQuery,TQueryResult_.TQueryResult 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>\.TQueryResult')[&gt;](../Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response with the data when it succeeded, or the errors when it failed\.