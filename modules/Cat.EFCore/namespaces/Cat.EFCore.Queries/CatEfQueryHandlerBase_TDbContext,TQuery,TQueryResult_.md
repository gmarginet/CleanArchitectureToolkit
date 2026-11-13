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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EFCORE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EFCore\.Queries Assembly](index.md 'index') >> [Cat\.EFCore\.Queries Namespace](Cat.EFCore.Queries.md 'Cat\.EFCore\.Queries')

## CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\> Class

Base class for query handlers that read from Entity Framework Core\.
It holds the [DbContext](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.DbContext.md 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.DbContext') and gives out entity sets without change tracking\.

```csharp
public abstract class CatEfQueryHandlerBase<TDbContext,TQuery,TQueryResult> : Cat.Queries.Abstractions.ICatQueryHandler<TQuery, TQueryResult>
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
    where TQuery : class, Cat.Queries.Abstractions.ICatQuery<TQueryResult>
```
#### Type parameters

<a name='Cat.EFCore.Queries.CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.TDbContext'></a>

`TDbContext`

The context type\. Any [Microsoft\.EntityFrameworkCore\.DbContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext 'Microsoft\.EntityFrameworkCore\.DbContext') works, also a scaffolded one\.

<a name='Cat.EFCore.Queries.CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.TQuery'></a>

`TQuery`

The query this handler can answer\.

<a name='Cat.EFCore.Queries.CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.TQueryResult'></a>

`TQueryResult`

The type of the data the handler returns\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>

Implements [Cat\.Queries\.Abstractions\.ICatQueryHandler&lt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')[TQuery](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.md#Cat.EFCore.Queries.CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.TQuery 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.TQuery')[,](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')[TQueryResult](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.md#Cat.EFCore.Queries.CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.TQueryResult 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.TQueryResult')[&gt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryHandler_TQuery,TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQueryHandler\`2')

| Constructors | |
| :--- | :--- |
| [CatEfQueryHandlerBase\(TDbContext\)](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_..ctor.9EVE3WR251MH544LEMUK92EU2.md 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.CatEfQueryHandlerBase\(TDbContext\)') | Creates the handler\. |

| Properties | |
| :--- | :--- |
| [DbContext](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.DbContext.md 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.DbContext') | The context to read from\. |
| [TrackChanges](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.TrackChanges.md 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.TrackChanges') | Tells whether [Set&lt;TEntity&gt;\(\)](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.Set_TEntity_().md 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.Set\<TEntity\>\(\)') tracks the entities it returns\. The default is `false`\. Override it in a handler that needs tracking\. |

| Methods | |
| :--- | :--- |
| [HandleAsync\(TQuery, CancellationToken\)](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.HandleAsync.L18PABR26LZL8NJVJ6L8NVJ62.md 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.HandleAsync\(TQuery, System\.Threading\.CancellationToken\)') | |
| [Set&lt;TEntity&gt;\(\)](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.Set_TEntity_().md 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.Set\<TEntity\>\(\)') | Gives the entities of one type to start a query on\. They are not tracked, unless [TrackChanges](CatEfQueryHandlerBase_TDbContext,TQuery,TQueryResult_.TrackChanges.md 'Cat\.EFCore\.Queries\.CatEfQueryHandlerBase\<TDbContext,TQuery,TQueryResult\>\.TrackChanges') is `true`\. |
