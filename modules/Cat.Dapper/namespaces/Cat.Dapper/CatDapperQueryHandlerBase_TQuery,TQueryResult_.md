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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.DAPPER](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Dapper Assembly](index.md 'index') >> [Cat\.Dapper Namespace](Cat.Dapper.md 'Cat\.Dapper')

## CatDapperQueryHandlerBase\<TQuery,TQueryResult\> Class

Base class for query handlers that read with plain SQL and Dapper\.
It holds the [ICatDbSession](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbSession.md 'Cat\.Dapper\.Abstractions\.ICatDbSession')\. Run the SQL with the extension methods of [CatDbSessionExtensions](CatDbSessionExtensions.md 'Cat\.Dapper\.CatDbSessionExtensions')\.

```csharp
public abstract class CatDapperQueryHandlerBase<TQuery,TQueryResult> : Cat.Queries.Abstractions.ICatQueryHandler<TQuery, TQueryResult>
    where TQuery : class, Cat.Queries.Abstractions.ICatQuery<TQueryResult>
```
#### Type parameters

<a name='Cat.Dapper.CatDapperQueryHandlerBase_TQuery,TQueryResult_.TQuery'></a>

`TQuery`

The query this handler can answer\.

<a name='Cat.Dapper.CatDapperQueryHandlerBase_TQuery,TQueryResult_.TQueryResult'></a>

`TQueryResult`

The type of the data the handler returns\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatDapperQueryHandlerBase\<TQuery,TQueryResult\>

Implements [Cat\.Queries\.Abstractions\.ICatQueryHandler&lt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')[TQuery](CatDapperQueryHandlerBase_TQuery,TQueryResult_.md#Cat.Dapper.CatDapperQueryHandlerBase_TQuery,TQueryResult_.TQuery 'Cat\.Dapper\.CatDapperQueryHandlerBase\<TQuery,TQueryResult\>\.TQuery')[,](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')[TQueryResult](CatDapperQueryHandlerBase_TQuery,TQueryResult_.md#Cat.Dapper.CatDapperQueryHandlerBase_TQuery,TQueryResult_.TQueryResult 'Cat\.Dapper\.CatDapperQueryHandlerBase\<TQuery,TQueryResult\>\.TQueryResult')[&gt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')

| Constructors | |
| :--- | :--- |
| [CatDapperQueryHandlerBase\(ICatDbSession\)](CatDapperQueryHandlerBase_TQuery,TQueryResult_..ctor.KMEBK6H9Q64JPYH2RX1ESA0NE.md 'Cat\.Dapper\.CatDapperQueryHandlerBase\<TQuery,TQueryResult\>\.CatDapperQueryHandlerBase\(Cat\.Dapper\.Abstractions\.ICatDbSession\)') | Creates the handler\. |

| Properties | |
| :--- | :--- |
| [Session](CatDapperQueryHandlerBase_TQuery,TQueryResult_.Session.md 'Cat\.Dapper\.CatDapperQueryHandlerBase\<TQuery,TQueryResult\>\.Session') | The session to read with\. |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TQuery, CancellationToken\)](CatDapperQueryHandlerBase_TQuery,TQueryResult_.HandleAsync.GM9ME00FDRU54I9ICVLA8VLU3.md 'Cat\.Dapper\.CatDapperQueryHandlerBase\<TQuery,TQueryResult\>\.HandleAsync\(TQuery, System\.Threading\.CancellationToken\)') | Runs the query\. |
