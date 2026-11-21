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

## CatHybridQueryCache Class

The default [ICatQueryCache](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/ICatQueryCache.md 'Cat\.Caching\.Abstractions\.ICatQueryCache')\. It uses `HybridCache`, so a developer gets a memory level and, with an
`IDistributedCache` in the container, a shared level\. `HybridCache` runs one factory call per key on one instance\.

```csharp
internal sealed class CatHybridQueryCache : Cat.Caching.Abstractions.ICatQueryCache
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatHybridQueryCache

Implements [ICatQueryCache](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/ICatQueryCache.md 'Cat\.Caching\.Abstractions\.ICatQueryCache')

| Constructors | |
| :--- | :--- |
| [CatHybridQueryCache\(HybridCache\)](CatHybridQueryCache..ctor.P53SB7TFIU1AHMYFHCONAZQ5.md 'Cat\.Caching\.CatHybridQueryCache\.CatHybridQueryCache\(Microsoft\.Extensions\.Caching\.Hybrid\.HybridCache\)') | The default [ICatQueryCache](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/ICatQueryCache.md 'Cat\.Caching\.Abstractions\.ICatQueryCache')\. It uses `HybridCache`, so a developer gets a memory level and, with an `IDistributedCache` in the container, a shared level\. `HybridCache` runs one factory call per key on one instance\. |

| Methods | |
| :--- | :--- |
| [GetOrCreateAsync&lt;T&gt;\(string, Func&lt;CancellationToken,Task&lt;T&gt;&gt;, CatQueryCacheEntryOptions, CancellationToken\)](CatHybridQueryCache.GetOrCreateAsync.Y9UXTN7I3294FWIBBZEERPOWD.md 'Cat\.Caching\.CatHybridQueryCache\.GetOrCreateAsync\<T\>\(string, System\.Func\<System\.Threading\.CancellationToken,System\.Threading\.Tasks\.Task\<T\>\>, Cat\.Caching\.Abstractions\.CatQueryCacheEntryOptions, System\.Threading\.CancellationToken\)') | Returns the value of a key\. When the cache has none, it calls the factory and stores the result\. A burst of calls for the same missing key should run the factory once\. The default implementation does that per instance\. When the factory throws, nothing is stored and the exception goes to the caller\. |
| [RemoveByTagAsync\(string, CancellationToken\)](CatHybridQueryCache.RemoveByTagAsync.QH6LIPD9IJHYSDVKPDLL01V1C.md 'Cat\.Caching\.CatHybridQueryCache\.RemoveByTagAsync\(string, System\.Threading\.CancellationToken\)') | Removes every entry that has the tag\. A cache that is spread over several instances may keep the entry in the memory of the other instances until its local lifetime ends\. |
