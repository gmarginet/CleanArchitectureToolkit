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

## CatCachingQueryProcessor\(ICatQueryProcessor, ICatQueryCache, CatQueryCacheOptions, ICatUser\) Constructor

Wraps the query processor\. A listed query type is answered from the cache, so a hit skips the new scope and the handler\.
Every other type passes straight through\.
Only a successful response is stored\. A `NotFound` is stored too when the rule asks for it\. Every other failure is never stored\.

```csharp
public CatCachingQueryProcessor(Cat.Queries.Abstractions.ICatQueryProcessor inner, Cat.Caching.Abstractions.ICatQueryCache cache, Cat.Caching.Abstractions.CatQueryCacheOptions options, Cat.Users.Abstractions.ICatUser? user);
```
#### Parameters

<a name='Cat.Caching.CatCachingQueryProcessor.CatCachingQueryProcessor(Cat.Queries.Abstractions.ICatQueryProcessor,Cat.Caching.Abstractions.ICatQueryCache,Cat.Caching.Abstractions.CatQueryCacheOptions,Cat.Users.Abstractions.ICatUser).inner'></a>

`inner` [ICatQueryProcessor](../../../Cat.Queries/namespaces/Cat.Queries.Abstractions/ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')

<a name='Cat.Caching.CatCachingQueryProcessor.CatCachingQueryProcessor(Cat.Queries.Abstractions.ICatQueryProcessor,Cat.Caching.Abstractions.ICatQueryCache,Cat.Caching.Abstractions.CatQueryCacheOptions,Cat.Users.Abstractions.ICatUser).cache'></a>

`cache` [ICatQueryCache](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/ICatQueryCache.md 'Cat\.Caching\.Abstractions\.ICatQueryCache')

<a name='Cat.Caching.CatCachingQueryProcessor.CatCachingQueryProcessor(Cat.Queries.Abstractions.ICatQueryProcessor,Cat.Caching.Abstractions.ICatQueryCache,Cat.Caching.Abstractions.CatQueryCacheOptions,Cat.Users.Abstractions.ICatUser).options'></a>

`options` [CatQueryCacheOptions](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/CatQueryCacheOptions.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions')

<a name='Cat.Caching.CatCachingQueryProcessor.CatCachingQueryProcessor(Cat.Queries.Abstractions.ICatQueryProcessor,Cat.Caching.Abstractions.ICatQueryCache,Cat.Caching.Abstractions.CatQueryCacheOptions,Cat.Users.Abstractions.ICatUser).user'></a>

`user` [ICatUser](../../../Cat.Users/namespaces/Cat.Users.Abstractions/ICatUser.md 'Cat\.Users\.Abstractions\.ICatUser')