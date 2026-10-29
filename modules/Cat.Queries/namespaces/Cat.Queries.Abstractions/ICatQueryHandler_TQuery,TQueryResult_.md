<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Queries\.Abstractions](index.md 'index') > [Cat\.Queries\.Abstractions](Cat.Queries.Abstractions.md 'Cat\.Queries\.Abstractions')

## ICatQueryHandler\<TQuery,TQueryResult\> Interface

Handles one kind of query\.
Implement it once per query type\. The module finds and registers it for you\.

```csharp
public interface ICatQueryHandler<in TQuery,TQueryResult>
    where TQuery : class, Cat.Queries.Abstractions.ICatQuery<TQueryResult>
```
#### Type parameters

<a name='Cat.Queries.Abstractions.ICatQueryHandler_TQuery,TQueryResult_.TQuery'></a>

`TQuery`

The query this handler can answer\.

<a name='Cat.Queries.Abstractions.ICatQueryHandler_TQuery,TQueryResult_.TQueryResult'></a>

`TQueryResult`

The type of the data the handler returns\.

| Methods | |
| :--- | :--- |
| [HandleAsync\(TQuery, CancellationToken\)](ICatQueryHandler_TQuery,TQueryResult_.HandleAsync.569S9MAD4IYXQV8MCHY5U72UA.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>\.HandleAsync\(TQuery, System\.Threading\.CancellationToken\)') | Runs the query\. |
