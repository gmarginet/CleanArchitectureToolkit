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

## ICatQueryCache Interface

The cache behind the query cache of `Cat.Caching`\. The default implementation uses `HybridCache`\.
Implement it to bring an own cache, for example one with sliding expiry, and register it before or after `AddCatQueryCaching`\.
The last registration wins\.

```csharp
public interface ICatQueryCache
```

| Methods | |
| :--- | :--- |
| [GetOrCreateAsync&lt;T&gt;\(string, Func&lt;CancellationToken,Task&lt;T&gt;&gt;, CatQueryCacheEntryOptions, CancellationToken\)](ICatQueryCache.GetOrCreateAsync.332ALBIV4QS7ZHE84MUYAQQWC.md 'Cat\.Caching\.Abstractions\.ICatQueryCache\.GetOrCreateAsync\<T\>\(string, System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<T\>\>, Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions, System\.Threading\.CancellationToken\)') | Returns the value of a key\. When the cache has none, it calls the factory and stores the result\. A burst of calls for the same missing key should run the factory once\. The default implementation does that per instance\. When the factory throws, nothing is stored and the exception goes to the caller\. |
| [RemoveByTagAsync\(string, CancellationToken\)](ICatQueryCache.RemoveByTagAsync.Q4XVLUZIZAIKVFB9547OBLINC.md 'Cat\.Caching\.Abstractions\.ICatQueryCache\.RemoveByTagAsync\(string, System\.Threading\.CancellationToken\)') | Removes every entry that has the tag\. A cache that is spread over several instances may keep the entry in the memory of the other instances until its local lifetime ends\. |
