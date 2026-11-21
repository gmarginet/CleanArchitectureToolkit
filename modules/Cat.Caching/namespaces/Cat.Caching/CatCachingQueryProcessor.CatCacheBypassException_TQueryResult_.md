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

## CatCachingQueryProcessor\.CatCacheBypassException\<TQueryResult\> Class

Carries a response that must not be stored out of the factory of the cache\. A cache does not store a factory that throws\.

```csharp
private sealed class CatCachingQueryProcessor.CatCacheBypassException<TQueryResult> : System.Exception
```
#### Type parameters

<a name='Cat.Caching.CatCachingQueryProcessor.CatCacheBypassException_TQueryResult_.TQueryResult'></a>

`TQueryResult`

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception') → CatCacheBypassException\<TQueryResult\>

| Constructors | |
| :--- | :--- |
| [CatCacheBypassException\(ICatResponse&lt;TQueryResult&gt;\)](CatCachingQueryProcessor.CatCacheBypassException_TQueryResult_..ctor.ELZJPSSZK4MNUZR6LSEN3GYGB.md 'Cat\.Caching\.CatCachingQueryProcessor\.CatCacheBypassException\<TQueryResult\>\.CatCacheBypassException\(Cat\.Responses\.Abstractions\.ICatResponse\<TQueryResult\>\)') | Carries a response that must not be stored out of the factory of the cache\. A cache does not store a factory that throws\. |

| Properties | |
| :--- | :--- |
| [Response](CatCachingQueryProcessor.CatCacheBypassException_TQueryResult_.Response.md 'Cat\.Caching\.CatCachingQueryProcessor\.CatCacheBypassException\<TQueryResult\>\.Response') | |
