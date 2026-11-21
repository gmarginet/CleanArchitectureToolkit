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
  
##### >> [Cat\.Caching Assembly](index.md 'index') >> [Cat\.Caching Namespace](Cat.Caching.md 'Cat\.Caching')

## CatCachingQueryProcessor Class

Wraps the query processor\. A listed query type is answered from the cache, so a hit skips the new scope and the handler\.
Every other type passes straight through\.
Only a successful response is stored\. A `NotFound` is stored too when the rule asks for it\. Every other failure is never stored\.

```csharp
internal sealed class CatCachingQueryProcessor : Cat.Queries.Abstractions.ICatQueryProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCachingQueryProcessor

Implements [ICatQueryProcessor](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')

| Constructors | |
| :--- | :--- |
| [CatCachingQueryProcessor\(ICatQueryProcessor, ICatQueryCache, CatQueryCacheOptions, ICatUser\)](CatCachingQueryProcessor..ctor.YKF7TTXRZEN170PL2SNK3I0EB.md 'Cat\.Caching\.CatCachingQueryProcessor\.CatCachingQueryProcessor\(Cat\.Queries\.Abstractions\.ICatQueryProcessor, Cat\.Caching\.Abstractions\.ICatQueryCache, Cat\.Caching\.Abstractions\.CatQueryCacheOptions, Cat\.Users\.Abstractions\.ICatUser\)') | Wraps the query processor\. A listed query type is answered from the cache, so a hit skips the new scope and the handler\. Every other type passes straight through\. Only a successful response is stored\. A `NotFound` is stored too when the rule asks for it\. Every other failure is never stored\. |

| Methods | |
| :--- | :--- |
| [CreateEntryOptions\(CatQueryCacheRule, TimeSpan\)](CatCachingQueryProcessor.CreateEntryOptions.DAOEQJZA3VGLRERPLQ8HMGU2D.md 'Cat\.Caching\.CatCachingQueryProcessor\.CreateEntryOptions\(Cat\.Caching\.Abstractions\.CatQueryCacheRule, System\.TimeSpan\)') | |
| [Process&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;\)](CatCachingQueryProcessor.Process.M4FFOFNEFFAOL67YRGF0K3356.md 'Cat\.Caching\.CatCachingQueryProcessor\.Process\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>\)') | Runs a query and blocks until it finishes\. Prefer [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.ProcessAsync.NXU8C22PI206ZIXUL4SR6VC55.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor\.ProcessAsync\`\`1\(Cat\.Queries\.Abstractions\.ICatQuery\{\`\`0\},System\.Threading\.CancellationToken\)') when you can\. |
| [ProcessAsync&lt;TQueryResult&gt;\(ICatQuery&lt;TQueryResult&gt;, CancellationToken\)](CatCachingQueryProcessor.ProcessAsync.EVUJEOYSO5C7EO747UT4EB741.md 'Cat\.Caching\.CatCachingQueryProcessor\.ProcessAsync\<TQueryResult\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, System\.Threading\.CancellationToken\)') | Runs a query\. |
| [RunAsync&lt;TQueryResult,TCached&gt;\(ICatQuery&lt;TQueryResult&gt;, string, string, CatQueryCacheRule, CancellationToken\)](CatCachingQueryProcessor.RunAsync.JQO835YXXMNC0MIAT74YJ0LM6.md 'Cat\.Caching\.CatCachingQueryProcessor\.RunAsync\<TQueryResult,TCached\>\(Cat\.Queries\.Abstractions\.ICatQuery\<TQueryResult\>, string, string, Cat\.Caching\.Abstractions\.CatQueryCacheRule, System\.Threading\.CancellationToken\)') | |
