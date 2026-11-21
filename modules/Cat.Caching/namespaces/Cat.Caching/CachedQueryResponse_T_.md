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

## CachedQueryResponse\<T\> Class

What the cache stores for a query\. A `CatResponse` cannot be read back from JSON, so the cache stores the outcome,
the value and, for a `NotFound`, the errors as code and message\. A hit rebuilds the response with the factories of `CatResponse`\.
The two derived classes only differ in how `HybridCache` sees them, see [CatImmutableTypes](CatImmutableTypes.md 'Cat\.Caching\.CatImmutableTypes')\.

```csharp
internal abstract class CachedQueryResponse<T>
```
#### Type parameters

<a name='Cat.Caching.CachedQueryResponse_T_.T'></a>

`T`

The type of the value of the response\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CachedQueryResponse\<T\>

Derived  
↳ [ImmutableCachedQueryResponse&lt;T&gt;](ImmutableCachedQueryResponse_T_.md 'Cat\.Caching\.ImmutableCachedQueryResponse\<T\>')  
↳ [MutableCachedQueryResponse&lt;T&gt;](MutableCachedQueryResponse_T_.md 'Cat\.Caching\.MutableCachedQueryResponse\<T\>')

| Fields | |
| :--- | :--- |
| [Accepted](CachedQueryResponse_T_.Accepted.md 'Cat\.Caching\.CachedQueryResponse\<T\>\.Accepted') | |
| [Created](CachedQueryResponse_T_.Created.md 'Cat\.Caching\.CachedQueryResponse\<T\>\.Created') | |
| [NoContent](CachedQueryResponse_T_.NoContent.md 'Cat\.Caching\.CachedQueryResponse\<T\>\.NoContent') | |
| [NotFound](CachedQueryResponse_T_.NotFound.md 'Cat\.Caching\.CachedQueryResponse\<T\>\.NotFound') | |
| [Ok](CachedQueryResponse_T_.Ok.md 'Cat\.Caching\.CachedQueryResponse\<T\>\.Ok') | |

| Properties | |
| :--- | :--- |
| [Errors](CachedQueryResponse_T_.Errors.md 'Cat\.Caching\.CachedQueryResponse\<T\>\.Errors') | |
| [Outcome](CachedQueryResponse_T_.Outcome.md 'Cat\.Caching\.CachedQueryResponse\<T\>\.Outcome') | |
| [Value](CachedQueryResponse_T_.Value.md 'Cat\.Caching\.CachedQueryResponse\<T\>\.Value') | |

| Methods | |
| :--- | :--- |
| [From&lt;TCached&gt;\(ICatResponse&lt;T&gt;\)](CachedQueryResponse_T_.From.RV4M2DSX9YW3CG6VQ6HWYPSUA.md 'Cat\.Caching\.CachedQueryResponse\<T\>\.From\<TCached\>\(Cat\.Responses\.Abstractions\.ICatResponse\<T\>\)') | |
| [IsNotFound\(ICatResponse&lt;T&gt;\)](CachedQueryResponse_T_.IsNotFound.BKB7AJ92K3ESQNZUMYRBJA7Y9.md 'Cat\.Caching\.CachedQueryResponse\<T\>\.IsNotFound\(Cat\.Responses\.Abstractions\.ICatResponse\<T\>\)') | |
| [ToResponse\(\)](CachedQueryResponse_T_.ToResponse().md 'Cat\.Caching\.CachedQueryResponse\<T\>\.ToResponse\(\)') | |
