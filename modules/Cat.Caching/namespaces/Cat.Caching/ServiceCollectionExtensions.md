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
  
##### >> [Cat\.Caching Assembly](index.md 'index') >> [Cat\.Caching\.Extensions Namespace](Cat.Caching.Extensions.md 'Cat\.Caching\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the query cache\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatQueryCaching\(this IServiceCollection, Action&lt;CatQueryCacheOptions&gt;\)](ServiceCollectionExtensions.AddCatQueryCaching.KZVJ693KND9553T75V57VOPOC.md 'Cat\.Caching\.Extensions\.ServiceCollectionExtensions\.AddCatQueryCaching\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Action\<Cat\.Caching\.Abstractions\.CatQueryCacheOptions\>\)') | Caches the query types that you list, in front of the query processor\. Nothing is cached by default\. Register the queries module with `AddCatQueriesModule` first, because the processor is wrapped\. The default cache uses `HybridCache`\. Add an `IDistributedCache`, such as Redis, to the container to share entries between instances\. A cache of your own replaces the default: register an [ICatQueryCache](../../../Cat.Caching/namespaces/Cat.Caching.Abstractions/ICatQueryCache.md 'Cat\.Caching\.Abstractions\.ICatQueryCache') after this call\. The cache sits outside the retry of `Cat.Resilience`, whatever the order of the lines\. Call it once\. The options are registered as a service, so a test can check which query types are cached\. |
