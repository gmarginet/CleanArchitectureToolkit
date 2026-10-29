<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries\.Abstractions](index.md 'index') > [Cat\.Queries\.Abstractions](Cat.Queries.Abstractions.md 'Cat\.Queries\.Abstractions')

## ICatQuery\<TQueryResult\> Interface

Marks a query that reads data and returns it in a response\.
Handle it with [ICatQueryHandler&lt;TQuery,TQueryResult&gt;](ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>')\.

```csharp
public interface ICatQuery<out TQueryResult>
```
#### Type parameters

<a name='Cat.Queries.Abstractions.ICatQuery_TQueryResult_.TQueryResult'></a>

`TQueryResult`

The type of the data the handler returns\.