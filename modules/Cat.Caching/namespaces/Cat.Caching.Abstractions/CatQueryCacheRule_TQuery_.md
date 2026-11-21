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
  
##### >> [Cat\.Caching\.Abstractions Assembly](index.md 'index') >> [Cat\.Caching\.Abstractions Namespace](Cat.Caching.Abstractions.md 'Cat\.Caching\.Abstractions')

## CatQueryCacheRule\<TQuery\> Class

The settings of one cached query type, set in a fluent way in [Cache&lt;TQuery&gt;\(Action&lt;CatQueryCacheRule&lt;TQuery&gt;&gt;\)](CatQueryCacheOptions.Cache.CZDYXFEMZ0WR7XF3JC8LBBCLC.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.Cache\<TQuery\>\(System\.Action\<Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\>\)')\.

```csharp
public sealed class CatQueryCacheRule<TQuery> : Cat.Caching.Abstractions.CatQueryCacheRule
    where TQuery : class
```
#### Type parameters

<a name='Cat.Caching.Abstractions.CatQueryCacheRule_TQuery_.TQuery'></a>

`TQuery`

The query type\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatQueryCacheRule](CatQueryCacheRule.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule') → CatQueryCacheRule\<TQuery\>

| Methods | |
| :--- | :--- |
| [CacheNotFound\(TimeSpan\)](CatQueryCacheRule_TQuery_.CacheNotFound.52LP042SBIAZT7OASXRTQHU09.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\.CacheNotFound\(System\.TimeSpan\)') | Caches a `NotFound` response too, for its own lifetime\. A response with another failure is never cached\. After an item is created, the old `NotFound` stays until the lifetime ends or its tag is removed\. |
| [Expires\(TimeSpan\)](CatQueryCacheRule_TQuery_.Expires.5Y9BFI39H8CMUDBG58YTJ19KB.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\.Expires\(System\.TimeSpan\)') | Sets how long an entry lives\. The expiry is absolute\. |
| [ExpiresLocally\(TimeSpan\)](CatQueryCacheRule_TQuery_.ExpiresLocally.P97AO582TOKY64VXRJBOKZIB5.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\.ExpiresLocally\(System\.TimeSpan\)') | Sets how long the memory level keeps an entry\. A shorter time bounds how long another instance serves an entry that was removed by its tag\. |
| [Key\(Func&lt;TQuery,string&gt;\)](CatQueryCacheRule_TQuery_.Key.R1ST5A8VTWGDS99O0BAVSUOLC.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\.Key\(System\.Func\<TQuery,string\>\)') | Builds the part of the key that comes from the query, for a query where the serialized form is not right\. The function must return the same text for queries that give the same answer, and a different text otherwise\. |
| [Shared\(\)](CatQueryCacheRule_TQuery_.Shared().md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\.Shared\(\)') | Lets every user share one entry\. Use it only for a query that gives every user the same answer\. |
| [Tag\(string\[\]\)](CatQueryCacheRule_TQuery_.Tag.E6J5O0VOJLIV86OEYM3TUMTPE.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\.Tag\(string\[\]\)') | Gives the entries of this query type one or more tags\. A command or an event subscriber clears them with [RemoveByTagAsync\(string, CancellationToken\)](ICatQueryCache.RemoveByTagAsync.Q4XVLUZIZAIKVFB9547OBLINC.md 'Cat\.Caching\.Abstractions\.ICatQueryCache\.RemoveByTagAsync\(string, System\.Threading\.CancellationToken\)')\. |
