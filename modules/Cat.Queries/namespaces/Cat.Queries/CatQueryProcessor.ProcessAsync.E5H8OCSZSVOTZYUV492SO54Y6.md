<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Queries](index.md 'index') > [Cat\.Queries](Cat.Queries.md 'Cat\.Queries') > [CatQueryProcessor](CatQueryProcessor.md 'Cat\.Queries\.CatQueryProcessor')

## CatQueryProcessor\.ProcessAsync\<TQueryResult\>\(ICatQuery\<TQueryResult\>, CancellationToken\) Method

Runs a query\.

```csharp
public System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TQueryResult>> ProcessAsync<TQueryResult>(Cat.Queries.Abstractions.ICatQuery<TQueryResult> catQuery, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Type parameters

<a name='Cat.Queries.CatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).TQueryResult'></a>

`TQueryResult`

The type of the data the query returns\.
#### Parameters

<a name='Cat.Queries.CatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).catQuery'></a>

`catQuery` [Cat\.Queries\.Abstractions\.ICatQuery&lt;](..\Cat.Queries.Abstractions\ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\`1')[TQueryResult](CatQueryProcessor.ProcessAsync.E5H8OCSZSVOTZYUV492SO54Y6.md#Cat.Queries.CatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).TQueryResult 'Cat\.Queries\.CatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)\.TQueryResult')[&gt;](..\Cat.Queries.Abstractions\ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\`1')

The query to run\.

<a name='Cat.Queries.CatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](..\Cat.Queries.Abstractions\ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\`\`1\(Cat\.Queries\.Abstractions\.ICatQuery\{\`\`0\},System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TQueryResult](CatQueryProcessor.ProcessAsync.E5H8OCSZSVOTZYUV492SO54Y6.md#Cat.Queries.CatQueryProcessor.ProcessAsync_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,System.Threading.CancellationToken).TQueryResult 'Cat\.Queries\.CatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)\.TQueryResult')[&gt;](..\Cat.Responses.Abstractions\ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The response of the handler, with the data when it succeeded\.