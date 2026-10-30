<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.QUERIES](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Queries\.Decorators\.Logging Assembly](index.md 'index') >> [Cat\.Queries\.Decorators\.Logging Namespace](Cat.Queries.Decorators.Logging.md 'Cat\.Queries\.Decorators\.Logging') >> [LoggingDecorator Class](LoggingDecorator.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator') >> [CatQueryHandler&lt;TQuery,TQueryResult&gt; Class](LoggingDecorator.CatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Decorators\.Logging\.LoggingDecorator\.CatQueryHandler\<TQuery,TQueryResult\>')

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