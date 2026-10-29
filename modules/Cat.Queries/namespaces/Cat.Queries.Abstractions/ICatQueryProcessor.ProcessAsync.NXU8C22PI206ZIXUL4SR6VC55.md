<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries\.Abstractions](index.md 'index') > [Cat\.Queries\.Abstractions](Cat.Queries.Abstractions.md 'Cat\.Queries\.Abstractions') > [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')

## ICatQueryProcessor\.ProcessAsync\<TQueryResult\>\(ICatQuery\<TQueryResult\>, CancellationToken\) Method

Runs a query\.

```csharp
System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(Cat.Queries.Abstractions.ICatQuery<TQueryResult> catQuery, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.Queries.Abstractions.ICatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).TQueryResult'></a>

`TQueryResult`

The type of the data the query returns\.
#### Parameters

<a name='Cat.Queries.Abstractions.ICatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).catQuery'></a>

`catQuery` [Cat\.Queries\.Abstractions\.ICatQuery&lt;](ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>')[TQueryResult](ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md#Cat.Queries.Abstractions.ICatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).TQueryResult 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)\.TQueryResult')[&gt;](ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>')

The query to run\.

<a name='Cat.Queries.Abstractions.ICatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TQueryResult](ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md#Cat.Queries.Abstractions.ICatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).TQueryResult 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)\.TQueryResult')[&gt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The response of the handler, with the data when it succeeded\.