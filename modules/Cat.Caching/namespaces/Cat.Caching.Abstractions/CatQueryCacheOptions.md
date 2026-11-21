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

## CatQueryCacheOptions Class

Lists the query types that are cached\. Nothing is cached by default, also no query\.
The options are registered as a service, so a test can read [Rules](CatQueryCacheOptions.Rules.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.Rules') and check that a query type is not cached\.

```csharp
public sealed class CatQueryCacheOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatQueryCacheOptions

| Fields | |
| :--- | :--- |
| [\_rules](CatQueryCacheOptions._rules.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.\_rules') | |

| Properties | |
| :--- | :--- |
| [DefaultExpiration](CatQueryCacheOptions.DefaultExpiration.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.DefaultExpiration') | How long an entry lives when the rule of a query type sets no lifetime\. The default is 5 minutes\. |
| [Rules](CatQueryCacheOptions.Rules.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.Rules') | The cached query types and their rules\. |

| Methods | |
| :--- | :--- |
| [Cache&lt;TQuery&gt;\(Action&lt;CatQueryCacheRule&lt;TQuery&gt;&gt;\)](CatQueryCacheOptions.Cache.CZDYXFEMZ0WR7XF3JC8LBBCLC.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.Cache\<TQuery\>\(System\.Action\<Cat\.Caching\.Abstractions\.CatQueryCacheRule\<TQuery\>\>\)') | Caches a query type\. Every other query is not cached\. Never cache a query that a write or a price decision depends on, such as a query that prices an order or checks for a duplicate\. |
| [IsQuery\(Type\)](CatQueryCacheOptions.IsQuery.AATWI9NRKL73MBR2V74BZICIA.md 'Cat\.Caching\.Abstractions\.CatQueryCacheOptions\.IsQuery\(System\.Type\)') | |
