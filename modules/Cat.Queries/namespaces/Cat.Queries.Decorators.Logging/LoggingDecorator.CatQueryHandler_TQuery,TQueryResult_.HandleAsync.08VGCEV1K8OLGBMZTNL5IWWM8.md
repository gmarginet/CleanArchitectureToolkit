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