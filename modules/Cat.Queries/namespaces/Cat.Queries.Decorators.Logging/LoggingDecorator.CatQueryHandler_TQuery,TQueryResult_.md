<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries\.Decorators\.Logging](index.md 'index') > [Cat\.Queries\.Decorators\.Logging](Cat.Queries.Decorators.Logging.md 'Cat\.Queries\.Decorators\.Logging') > [LoggingDecorator](LoggingDecorator.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator')

## LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\> Class

Logs the start and end of a query handler\.

```csharp
internal sealed class LoggingDecorator.CatQueryHandler<TQuery,TQueryResult> : Cat.Queries.Abstractions.ICatQueryHandler<TQuery, TQueryResult>
    where TQuery : class, Cat.Queries.Abstractions.ICatQuery<TQueryResult>
```
#### Type parameters

<a name='Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.TQuery'></a>

`TQuery`

The query being handled\.

<a name='Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.TQueryResult'></a>

`TQueryResult`

The type of the data the handler returns\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatQueryHandler\<TQuery,TQueryResult\>

Implements [Cat\.Queries\.Abstractions\.ICatQueryHandler&lt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')[TQuery](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md#Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.TQuery 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.TQuery')[,](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')[TQueryResult](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md#Cat.Queries.Decorators.Logging.LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.TQueryResult 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.TQueryResult')[&gt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')

| Constructors | |
| :--- | :--- |
| [CatQueryHandler\(ICatQueryHandler&lt;TQuery,TQueryResult&gt;, ILogger&lt;CatQueryHandler&lt;TQuery,TQueryResult&gt;&gt;\)](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_..ctor.9M5XUGW1X6MPKOZCA81KUTOPA.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.CatQueryHandler\(Cat\.Queries\.Abstractions\.ICatQueryHandler\<TQuery,TQueryResult\>, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\>\)') | Creates the decorator\. |

| Fields | |
| :--- | :--- |
| [\_innerHandler](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_._innerHandler.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.\_innerHandler') | |
| [\_logger](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_._logger.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.\_logger') | |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TQuery, CancellationToken\)](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.HandleAsync.08VGCEV1K8OLGBMZTNL5IWWM8.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>\.HandleAsync\(TQuery, System\.Threading\.CancellationToken\)') | Runs the query\. |
