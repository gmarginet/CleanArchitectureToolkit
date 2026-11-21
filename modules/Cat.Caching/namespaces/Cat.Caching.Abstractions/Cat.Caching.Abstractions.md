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
  
##### >> [Cat\.Caching\.Abstractions Assembly](index.md 'index')

## Cat\.Caching\.Abstractions Namespace

The contract of the query cache and the settings that list which query types are cached\.
A developer who wants another cache implements [ICatQueryCache](ICatQueryCache.md 'Cat\.Caching\.Abstractions\.ICatQueryCache')\.

| Classes | |
| :--- | :--- |
| [CatQueryCacheEntryOptions](CatQueryCacheEntryOptions.md 'Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions') | The settings of one cache entry\. The expiry is absolute\. There is no sliding expiry\. |
| [CatQueryCacheOptions](CatQueryCacheOptions.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions') | Lists the query types that are cached\. Nothing is cached by default, also no query\. The options are registered as a service, so a test can read [Rules](CatQueryCacheOptions.Rules.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.Rules') and check that a query type is not cached\. |
| [CatQueryCacheRule](CatQueryCacheRule.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule') | The settings of one cached query type\. Read them through [Rules](CatQueryCacheOptions.Rules.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.Rules')\. |
| [CatQueryCacheRule&lt;TQuery&gt;](CatQueryCacheRule_TQuery_.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>') | The settings of one cached query type, set in a fluent way in [Cache&lt;TQuery&gt;\(Action&lt;CatQueryCacheRule&lt;TQuery&gt;&gt;\)](CatQueryCacheOptions.Cache.CZDYXFEMZ0WR7XF3JC8LBBCLC.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.Cache\<TQuery\>\(System\.Action\<Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\>\)')\. |

| Interfaces | |
| :--- | :--- |
| [ICatQueryCache](ICatQueryCache.md 'Cat\.Caching\.Abstractions\.ICatQueryCache') | The cache behind the query cache of `Cat.Caching`\. The default implementation uses `HybridCache`\. Implement it to bring an own cache, for example one with sliding expiry, and register it before or after `AddCatQueryCaching`\. The last registration wins\. |
