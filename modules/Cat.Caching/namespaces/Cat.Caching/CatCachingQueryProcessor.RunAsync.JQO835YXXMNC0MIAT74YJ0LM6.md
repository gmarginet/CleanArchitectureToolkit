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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.CACHING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Caching Assembly](index.md 'index') >> [Cat\.Caching Namespace](Cat.Caching.md 'Cat\.Caching') >> [CatCachingQueryProcessor Class](CatCachingQueryProcessor.md 'Cat\.Caching\.CatCachingQueryProcessor')

## CatCachingQueryProcessor\.RunAsync\<TQueryResult,TCached\>\(ICatQuery\<TQueryResult\>, string, string, CatQueryCacheRule, CancellationToken\) Method

```csharp
private System.Threading.Tasks.Task<Cat.Responses.Abstractions.ICatResponse<TQueryResult>> RunAsync<TQueryResult,TCached>(Cat.Queries.Abstractions.ICatQuery<TQueryResult> catQuery, string queryName, string key, Cat.Caching.Abstractions.CatQueryCacheRule rule, System.Threading.CancellationToken cancellationToken)
    where TCached : Cat.Caching.CachedQueryResponse<TQueryResult>, new();
```
#### Type parameters

<a name='Cat.Caching.CatCachingQueryProcessor.RunAsync_TQueryResult,TCached_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,string,string,Cat.Caching.Abstractions.CatQueryCacheRule,System.Threading.CancellationToken).TQueryResult'></a>

`TQueryResult`

<a name='Cat.Caching.CatCachingQueryProcessor.RunAsync_TQueryResult,TCached_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,string,string,Cat.Caching.Abstractions.CatQueryCacheRule,System.Threading.CancellationToken).TCached'></a>

`TCached`
#### Parameters

<a name='Cat.Caching.CatCachingQueryProcessor.RunAsync_TQueryResult,TCached_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,string,string,Cat.Caching.Abstractions.CatQueryCacheRule,System.Threading.CancellationToken).catQuery'></a>

`catQuery` [Cat\.Queries\.Abstractions\.ICatQuery&lt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\`1')[TQueryResult](CatCachingQueryProcessor.RunAsync.JQO835YXXMNC0MIAT74YJ0LM6.md#Cat.Caching.CatCachingQueryProcessor.RunAsync_TQueryResult,TCached_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,string,string,Cat.Caching.Abstractions.CatQueryCacheRule,System.Threading.CancellationToken).TQueryResult 'Cat\.Caching\.CatCachingQueryProcessor\.RunAsync\<TQueryResult,TCached\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, string, string, Cat\.Caching\.Abstractions\.CatQueryCacheRule, System\.Threading\.CancellationToken\)\.TQueryResult')[&gt;](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQuery_TQueryResult_.md 'Cat\.Queries\.Abstractions\.ICatQuery\`1')

<a name='Cat.Caching.CatCachingQueryProcessor.RunAsync_TQueryResult,TCached_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,string,string,Cat.Caching.Abstractions.CatQueryCacheRule,System.Threading.CancellationToken).queryName'></a>

`queryName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Caching.CatCachingQueryProcessor.RunAsync_TQueryResult,TCached_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,string,string,Cat.Caching.Abstractions.CatQueryCacheRule,System.Threading.CancellationToken).key'></a>

`key` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Cat.Caching.CatCachingQueryProcessor.RunAsync_TQueryResult,TCached_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,string,string,Cat.Caching.Abstractions.CatQueryCacheRule,System.Threading.CancellationToken).rule'></a>

`rule` [CatQueryCacheRule](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/CatQueryCacheRule.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule')

<a name='Cat.Caching.CatCachingQueryProcessor.RunAsync_TQueryResult,TCached_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,string,string,Cat.Caching.Abstractions.CatQueryCacheRule,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TQueryResult](CatCachingQueryProcessor.RunAsync.JQO835YXXMNC0MIAT74YJ0LM6.md#Cat.Caching.CatCachingQueryProcessor.RunAsync_TQueryResult,TCached_(Cat.Queries.Abstractions.ICatQuery_TQueryResult_,string,string,Cat.Caching.Abstractions.CatQueryCacheRule,System.Threading.CancellationToken).TQueryResult 'Cat\.Caching\.CatCachingQueryProcessor\.RunAsync\<TQueryResult,TCached\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, string, string, Cat\.Caching\.Abstractions\.CatQueryCacheRule, System\.Threading\.CancellationToken\)\.TQueryResult')[&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')