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
  
##### >> [Cat\.Caching Assembly](index.md 'index')

## Cat\.Caching Namespace

Caches the answers of the query types a developer lists, in front of the query processor\.
The default cache uses `HybridCache`, with a memory level and an optional distributed level\.

| Classes | |
| :--- | :--- |
| [CachedError](CachedError.md 'Cat\.Caching\.CachedError') | An error of a cached `NotFound`\. The arguments are kept as text, so a reader of an argument gets text and not the original object\. |
| [CachedQueryResponse&lt;T&gt;](CachedQueryResponse_T_.md 'Cat\.Caching\.CachedQueryResponse\<T\>') | What the cache stores for a query\. A `CatResponse` cannot be read back from JSON, so the cache stores the outcome, the value and, for a `NotFound`, the errors as code and message\. A hit rebuilds the response with the factories of `CatResponse`\. The two derived classes only differ in how `HybridCache` sees them, see [CatImmutableTypes](CatImmutableTypes.md 'Cat\.Caching\.CatImmutableTypes')\. |
| [CatCachingQueryProcessor](CatCachingQueryProcessor.md 'Cat\.Caching\.CatCachingQueryProcessor') | Wraps the query processor\. A listed query type is answered from the cache, so a hit skips the new scope and the handler\. Every other type passes straight through\. Only a successful response is stored\. A `NotFound` is stored too when the rule asks for it\. Every other failure is never stored\. |
| [CatCachingQueryProcessor\.CatCacheBypassException&lt;TQueryResult&gt;](CatCachingQueryProcessor.CatCacheBypassException_TQueryResult_.md 'Cat\.Caching\.CatCachingQueryProcessor\.CatCacheBypassException\<TQueryResult\>') | Carries a response that must not be stored out of the factory of the cache\. A cache does not store a factory that throws\. |
| [CatCachingTelemetry](CatCachingTelemetry.md 'Cat\.Caching\.CatCachingTelemetry') | The metrics of the query cache\. The tag `query` holds the short name of the query type\. The key of an entry never goes into a tag, because a key can hold personal data\. |
| [CatHybridQueryCache](CatHybridQueryCache.md 'Cat\.Caching\.CatHybridQueryCache') | The default [ICatQueryCache](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/ICatQueryCache.md 'Cat\.Caching\.Abstractions\.ICatQueryCache')\. It uses `HybridCache`, so a developer gets a memory level and, with an `IDistributedCache` in the container, a shared level\. `HybridCache` runs one factory call per key on one instance\. |
| [CatImmutableTypes](CatImmutableTypes.md 'Cat\.Caching\.CatImmutableTypes') | Tells whether `HybridCache` sees a type as immutable: a `string`, a value type, or a sealed class marked with `[ImmutableObject(true)]`\. Every other type is mutable, and `HybridCache` hands out a copy on every hit\. The module follows that rule and adds no copy logic of its own\. |
| [CatQueryCacheKeys](CatQueryCacheKeys.md 'Cat\.Caching\.CatQueryCacheKeys') | Builds the key of a cache entry\. The key holds the query type name and a hash of the user and the query\. The hash keeps personal data out of the key, and out of the distributed cache\. A key is never logged or used as a tag\. |
| [ImmutableCachedQueryResponse&lt;T&gt;](ImmutableCachedQueryResponse_T_.md 'Cat\.Caching\.ImmutableCachedQueryResponse\<T\>') | The stored form for a value that is immutable\. `HybridCache` hands out the same instance on a hit\. |
| [MutableCachedQueryResponse&lt;T&gt;](MutableCachedQueryResponse_T_.md 'Cat\.Caching\.MutableCachedQueryResponse\<T\>') | The stored form for a value that `HybridCache` must treat as mutable\. Every hit gets a copy\. |
