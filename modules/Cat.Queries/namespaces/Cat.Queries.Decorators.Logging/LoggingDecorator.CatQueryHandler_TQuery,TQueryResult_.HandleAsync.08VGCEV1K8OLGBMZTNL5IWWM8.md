<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries\.Decorators\.Logging](index.md 'index') > [Cat\.Queries\.Decorators\.Logging](Cat.Queries.Decorators.Logging.md 'Cat\.Queries\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator') > [CatQueryHandler&lt;TQuery,TQueryResult&gt;](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>')

## LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.HandleAsync\(TQuery, CancellationToken\) Method

Runs the query\.

```csharp
public System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TQueryResult>> HandleAsync(TQuery query, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.HandleAsync(TQuery,System.Threading.CancellationToken).query'></a>

`query` [TQuery](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md#Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.TQuery 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.TQuery')

The query to handle\.

<a name='Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.HandleAsync(TQuery,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [HandleAsync\(TQuery, CancellationToken\)](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.HandleAsync.569S9MAD4IYXQV8MCHY5U72UA.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2\.HandleAsync\(\`0,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TQueryResult](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md#Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.TQueryResult 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.TQueryResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response with the data when it succeeded, or the errors when it failed\.