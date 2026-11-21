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
  
##### >> [Cat\.Caching\.Abstractions Assembly](index.md 'index') >> [Cat\.Caching\.Abstractions Namespace](Cat.Caching.Abstractions.md 'Cat\.Caching\.Abstractions') >> [CatQueryCacheOptions Class](CatQueryCacheOptions.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions')

## CatQueryCacheOptions\.Cache\<TQuery\>\(Action\<CatQueryCacheRule\<TQuery\>\>\) Method

Caches a query type\. Every other query is not cached\.
Never cache a query that a write or a price decision depends on, such as a query that prices an order or checks for a duplicate\.

```csharp
public Cat.Caching.Abstractions.CatQueryCacheOptions Cache<TQuery>(System.Action<Cat.Caching.Abstractions.CatQueryCacheRule<TQuery>>? configure=null)
    where TQuery : class;
```
#### Type parameters

<a name='Cat.Caching.Abstractions.CatQueryCacheOptions.Cache_TQuery_(System.Action_Cat.Caching.Abstractions.CatQueryCacheRule_TQuery__).TQuery'></a>

`TQuery`

The query type, which implements `ICatQuery<TQueryResult>`\.
#### Parameters

<a name='Cat.Caching.Abstractions.CatQueryCacheOptions.Cache_TQuery_(System.Action_Cat.Caching.Abstractions.CatQueryCacheRule_TQuery__).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.Caching\.Abstractions\.CatQueryCacheRule&lt;](CatQueryCacheRule_TQuery_.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>')[TQuery](CatQueryCacheOptions.Cache.CZDYXFEMZ0WR7XF3JC8LBBCLC.md#Cat.Caching.Abstractions.CatQueryCacheOptions.Cache_TQuery_(System.Action_Cat.Caching.Abstractions.CatQueryCacheRule_TQuery__).TQuery 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.Cache\<TQuery\>\(System\.Action\<Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\>\)\.TQuery')[&gt;](CatQueryCacheRule_TQuery_.md 'Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Sets the lifetime, the tags and the other settings of the query type\. Optional\.

#### Returns
[CatQueryCacheOptions](CatQueryCacheOptions.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions')  
The same options, for chaining\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The type is not a query\.