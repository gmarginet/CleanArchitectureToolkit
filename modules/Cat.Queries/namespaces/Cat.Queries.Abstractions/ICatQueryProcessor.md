<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Queries\.Abstractions](index.md 'index') > [Cat\.Queries\.Abstractions](Cat.Queries.Abstractions.md 'Cat\.Queries\.Abstractions')

## ICatQueryProcessor Interface

Single entry point for running queries\.
It finds the handler for a query, runs it through the registered decorators and returns the response\.

```csharp
public interface ICatQueryProcessor
```

| Methods | |
| :--- | :--- |
| [Process&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;\)](ICatQueryProcessor.Process.GLOZN4ERRH7J39W67F8ZXLTH6.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.Process\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>\)') | Runs a query and blocks until it finishes\. Prefer [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)') | Runs a query\. |
