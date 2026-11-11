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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses') >> [CatResponse Class](CatResponse.md 'Cat\.Responses\.CatResponse')

## CatResponse\.PagedList Class

Factory methods for responses that carry one page of a larger list\.

```csharp
public static class CatResponse.PagedList
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → PagedList

| Methods | |
| :--- | :--- |
| [BadRequest&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.PagedList.BadRequest.H3PYHN5SN2J9LM3TVJGHXNQQC.md 'Cat\.Responses\.CatResponse\.PagedList\.BadRequest\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [BadRequest](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.BadRequest') outcome\. |
| [Conflict&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.PagedList.Conflict.99HF9A0A2NNYNI2RSRRGELB74.md 'Cat\.Responses\.CatResponse\.PagedList\.Conflict\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [Conflict](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Conflict.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Conflict') outcome\. |
| [Created&lt;TResponse&gt;\(ICatPagedList&lt;TResponse&gt;\)](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(Cat.Responses.Abstractions.ICatPagedList_TResponse_) 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatPagedList\<TResponse\>\)') | Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying the given page\. |
| [Created&lt;TResponse&gt;\(IReadOnlyList&lt;TResponse&gt;, int, int, int\)](CatResponse.PagedList.Created.md#Cat.Responses.CatResponse.PagedList.Created_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int) 'Cat\.Responses\.CatResponse\.PagedList\.Created\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>, int, int, int\)') | Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying a page built from the given values\. |
| [Forbidden&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.PagedList.Forbidden.HW4YZRV5HWC5GP0ILU2644YD5.md 'Cat\.Responses\.CatResponse\.PagedList\.Forbidden\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [Forbidden](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Forbidden.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Forbidden') outcome\. |
| [InternalServerError&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.PagedList.InternalServerError.S8042UHRMMATEBBRCP4Z4V686.md 'Cat\.Responses\.CatResponse\.PagedList\.InternalServerError\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [InternalServerError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError') outcome\. |
| [NoContent&lt;TResponse&gt;\(\)](CatResponse.PagedList.NoContent_TResponse_().md 'Cat\.Responses\.CatResponse\.PagedList\.NoContent\<TResponse\>\(\)') | Creates a succeeded response with the [NoContent](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent') outcome and no page\. |
| [NotFound&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.PagedList.NotFound.8F88M2NUU3SI04ZYVP3O07QW1.md 'Cat\.Responses\.CatResponse\.PagedList\.NotFound\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [NotFound](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound') outcome\. |
| [Ok&lt;TResponse&gt;\(ICatPagedList&lt;TResponse&gt;\)](CatResponse.PagedList.Ok.md#Cat.Responses.CatResponse.PagedList.Ok_TResponse_(Cat.Responses.Abstractions.ICatPagedList_TResponse_) 'Cat\.Responses\.CatResponse\.PagedList\.Ok\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatPagedList\<TResponse\>\)') | Creates a succeeded response with the [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') outcome, carrying the given page\. |
| [Ok&lt;TResponse&gt;\(IReadOnlyList&lt;TResponse&gt;, int, int, int\)](CatResponse.PagedList.Ok.md#Cat.Responses.CatResponse.PagedList.Ok_TResponse_(System.Collections.Generic.IReadOnlyList_TResponse_,int,int,int) 'Cat\.Responses\.CatResponse\.PagedList\.Ok\<TResponse\>\(System\.Collections\.Generic\.IReadOnlyList\<TResponse\>, int, int, int\)') | Creates a succeeded response with the [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') outcome, carrying a page built from the given values\. |
| [Unauthorized&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.PagedList.Unauthorized.FCV6FHSJ3ATQ3D5PFESB96O7A.md 'Cat\.Responses\.CatResponse\.PagedList\.Unauthorized\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [Unauthorized](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Unauthorized') outcome\. |
