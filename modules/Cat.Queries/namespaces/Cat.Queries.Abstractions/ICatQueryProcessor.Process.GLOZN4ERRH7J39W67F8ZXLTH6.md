<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries\.Abstractions](index.md 'index') > [Cat\.Queries\.Abstractions](Cat.Queries.Abstractions.md 'Cat\.Queries\.Abstractions') > [ICatQueryProcessor](ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')

## ICatQueryProcessor\.Process\<TQueryResult\>\(ICatQuery\<TQueryResult\>\) Method

Runs a query and blocks until it finishes\.
Prefer [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)') when you can\.

```csharp
Cat.Responses.Abstractions.ICatResponse<TQueryResult> Process<TQueryResult>(Cat.Queries.Abstractions.ICatQuery<TQueryResult> catQuery);
```
#### Type parameters

<a name='Cat.Queries.Abstractions.ICatQueryProcessor.Process_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_).TQueryResult'></a>

`TQueryResult`

The type of the data the query returns\.
#### Parameters

<a name='Cat.Queries.Abstractions.ICatQueryProcessor.Process_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_).catQuery'></a>

`catQuery` [Cat\.Queries\.Abstractions\.ICatQuery&lt;](ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>')[TQueryResult](ICatQueryProcessor.Process.GLOZN4ERRH7J39W67F8ZXLTH6.md#Cat.Queries.Abstractions.ICatQueryProcessor.Process_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_).TQueryResult 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.Process\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>\)\.TQueryResult')[&gt;](ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>')

The query to run\.

#### Returns
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TQueryResult](ICatQueryProcessor.Process.GLOZN4ERRH7J39W67F8ZXLTH6.md#Cat.Queries.Abstractions.ICatQueryProcessor.Process_TQueryResult_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_).TQueryResult 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.Process\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>\)\.TQueryResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')  
The response of the handler, with the data when it succeeded\.