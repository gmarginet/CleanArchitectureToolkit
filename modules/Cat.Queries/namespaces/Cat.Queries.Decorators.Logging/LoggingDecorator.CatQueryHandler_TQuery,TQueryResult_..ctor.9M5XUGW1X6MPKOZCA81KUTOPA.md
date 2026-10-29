<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries\.Decorators\.Logging](index.md 'index') > [Cat\.Queries\.Decorators\.Logging](Cat.Queries.Decorators.Logging.md 'Cat\.Queries\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator') > [CatQueryHandler&lt;TQuery,TQueryResult&gt;](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>')

## CatQueryHandler\(ICatQueryHandler\<TQuery,TQueryResult\>, ILogger\<CatQueryHandler\<TQuery,TQueryResult\>\>\) Constructor

Creates the decorator\.

```csharp
public CatQueryHandler(Cat.Queries.Abstractions.ICatQueryHandler<TQuery,TQueryResult> innerHandler, Microsoft.Extensions.Logging.ILogger<Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler<TQuery,TQueryResult>> logger);
```
#### Parameters

<a name='Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.CatQueryHandler(Cat.Queries.Abstractions.ICatQueryHandler_TQuery,TQueryResult_,Microsoft.Extensions.Logging.ILogger_Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult__).innerHandler'></a>

`innerHandler` [Cat\.Queries\.Abstractions\.ICatQueryHandler&lt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')[TQuery](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md#Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.TQuery 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.TQuery')[,](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')[TQueryResult](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md#Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.TQueryResult 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.TQueryResult')[&gt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')

The handler to wrap\.

<a name='Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.CatQueryHandler(Cat.Queries.Abstractions.ICatQueryHandler_TQuery,TQueryResult_,Microsoft.Extensions.Logging.ILogger_Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler&lt;](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>')[TQuery](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md#Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.TQuery 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.TQuery')[,](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>')[TQueryResult](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md#Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.TQueryResult 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.TQueryResult')[&gt;](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

Receives the log entries\.