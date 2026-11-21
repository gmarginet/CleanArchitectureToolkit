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

## CatQueryCacheEntryOptions Class

The settings of one cache entry\. The expiry is absolute\. There is no sliding expiry\.

```csharp
public sealed class CatQueryCacheEntryOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatQueryCacheEntryOptions

| Properties | |
| :--- | :--- |
| [Expiration](CatQueryCacheEntryOptions.Expiration.md 'Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions\.Expiration') | How long the entry lives, counted from the moment it is stored\. |
| [LocalExpiration](CatQueryCacheEntryOptions.LocalExpiration.md 'Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions\.LocalExpiration') | How long the memory level of the cache keeps the entry\. Empty means the same as [Expiration](CatQueryCacheEntryOptions.Expiration.md 'Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions\.Expiration')\. A short value bounds how long another instance serves an entry that was removed by its tag\. |
| [Tags](CatQueryCacheEntryOptions.Tags.md 'Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions\.Tags') | The tags of the entry\. [RemoveByTagAsync\(string, CancellationToken\)](ICatQueryCache.RemoveByTagAsync.Q4XVLUZIZAIKVFB9547OBLINC.md 'Cat\.Caching\.Abstractions\.ICatQueryCache\.RemoveByTagAsync\(string, System\.Threading\.CancellationToken\)') removes the entries of a tag\. |
