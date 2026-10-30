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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.RESPONSES](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Responses Assembly](index.md 'index') >> [Cat\.Responses Namespace](Cat.Responses.md 'Cat\.Responses')

## CatResponse Class

The default [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse') implementation\. Create instances through its static factory methods,
such as [Ok\(\)](CatResponse.Ok.md#Cat.Responses.CatResponse.Ok() 'Cat\.Responses\.CatResponse\.Ok\(\)') and [NotFound\(ICatError\[\]\)](CatResponse.NotFound.md#Cat.Responses.CatResponse.NotFound(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.NotFound\(Cat\.Responses\.Abstractions\.ICatError\[\]\)'), rather than its constructors directly\.

```csharp
public class CatResponse : Cat.Responses.Abstractions.ICatResponse
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatResponse

Derived  
↳ [CatResponse&lt;TResponse&gt;](CatResponse_TResponse_.md 'Cat\.Responses\.CatResponse\<TResponse\>')

Implements [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

| Constructors | |
| :--- | :--- |
| [CatResponse\(Failed, IReadOnlyList&lt;ICatError&gt;\)](CatResponse.CatResponse.md#Cat.Responses.CatResponse.CatResponse(Cat.Responses.Abstractions.CatResponseType.Failed,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_) 'Cat\.Responses\.CatResponse\.CatResponse\(Cat\.Responses\.Abstractions\.CatResponseType\.Failed, System\.Collections\.Generic\.IReadOnlyList\<Cat\.Responses\.Abstractions\.ICatError\>\)') | Creates a failed response with the given errors\. |
| [CatResponse\(Succeeded\)](CatResponse.CatResponse.md#Cat.Responses.CatResponse.CatResponse(Cat.Responses.Abstractions.CatResponseType.Succeeded) 'Cat\.Responses\.CatResponse\.CatResponse\(Cat\.Responses\.Abstractions\.CatResponseType\.Succeeded\)') | Creates a succeeded response with no errors\. |

| Properties | |
| :--- | :--- |
| [ErrorList](CatResponse.ErrorList.md 'Cat\.Responses\.CatResponse\.ErrorList') | The errors that caused the operation to fail\. Empty when [IsSucceeded](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.IsSucceeded.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsSucceeded') is `true`\. |
| [IsFailed](CatResponse.IsFailed.md 'Cat\.Responses\.CatResponse\.IsFailed') | `true` if the operation failed\. |
| [IsSucceeded](CatResponse.IsSucceeded.md 'Cat\.Responses\.CatResponse\.IsSucceeded') | `true` if the operation succeeded\. |
| [Type](CatResponse.Type.md 'Cat\.Responses\.CatResponse\.Type') | The specific outcome of the operation, such as [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') or [NotFound](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound')\. |

| Methods | |
| :--- | :--- |
| [BadRequest\(ICatError\[\]\)](CatResponse.BadRequest.md#Cat.Responses.CatResponse.BadRequest(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.BadRequest\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [BadRequest](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.BadRequest') outcome\. |
| [BadRequest&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.BadRequest.md#Cat.Responses.CatResponse.BadRequest_TResponse_(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.BadRequest\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [BadRequest](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.BadRequest.md 'Cat\.Responses\.Abstractions\.CatResponseType\.BadRequest') outcome\. |
| [Cast&lt;TResponse&gt;\(\)](CatResponse.Cast.md#Cat.Responses.CatResponse.Cast_TResponse_() 'Cat\.Responses\.CatResponse\.Cast\<TResponse\>\(\)') | Converts this response into an [ICatResponse&lt;TResponse&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1'), carrying over its type and errors\. Only valid when [IsFailed](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.IsFailed.md 'Cat\.Responses\.Abstractions\.ICatResponse\.IsFailed') is `true`, since no value is supplied for the succeeded case\. |
| [Cast&lt;TResponse&gt;\(TResponse\)](CatResponse.Cast.md#Cat.Responses.CatResponse.Cast_TResponse_(TResponse) 'Cat\.Responses\.CatResponse\.Cast\<TResponse\>\(TResponse\)') | Converts this response into an [ICatResponse&lt;TResponse&gt;](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1') carrying the given value, keeping this response's type\. |
| [Created\(\)](CatResponse.Created.md#Cat.Responses.CatResponse.Created() 'Cat\.Responses\.CatResponse\.Created\(\)') | Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome and no value\. |
| [Created&lt;TResponse&gt;\(TResponse\)](CatResponse.Created.md#Cat.Responses.CatResponse.Created_TResponse_(TResponse) 'Cat\.Responses\.CatResponse\.Created\<TResponse\>\(TResponse\)') | Creates a succeeded response with the [Created](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Created.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Created') outcome, carrying the given value\. |
| [InternalServerError\(ICatError\[\]\)](CatResponse.InternalServerError.md#Cat.Responses.CatResponse.InternalServerError(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.InternalServerError\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [InternalServerError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError') outcome\. |
| [InternalServerError&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.InternalServerError.md#Cat.Responses.CatResponse.InternalServerError_TResponse_(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.InternalServerError\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [InternalServerError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.InternalServerError.md 'Cat\.Responses\.Abstractions\.CatResponseType\.InternalServerError') outcome\. |
| [NoContent\(\)](CatResponse.NoContent.md#Cat.Responses.CatResponse.NoContent() 'Cat\.Responses\.CatResponse\.NoContent\(\)') | Creates a succeeded response with the [NoContent](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent') outcome\. |
| [NoContent&lt;TResponse&gt;\(\)](CatResponse.NoContent.md#Cat.Responses.CatResponse.NoContent_TResponse_() 'Cat\.Responses\.CatResponse\.NoContent\<TResponse\>\(\)') | Creates a succeeded response with the [NoContent](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NoContent.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NoContent') outcome and no value\. |
| [NotFound\(ICatError\[\]\)](CatResponse.NotFound.md#Cat.Responses.CatResponse.NotFound(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.NotFound\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [NotFound](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound') outcome\. |
| [NotFound&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.NotFound.md#Cat.Responses.CatResponse.NotFound_TResponse_(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.NotFound\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [NotFound](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.NotFound.md 'Cat\.Responses\.Abstractions\.CatResponseType\.NotFound') outcome\. |
| [Ok\(\)](CatResponse.Ok.md#Cat.Responses.CatResponse.Ok() 'Cat\.Responses\.CatResponse\.Ok\(\)') | Creates a succeeded response with the [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') outcome and no value\. |
| [Ok&lt;TResponse&gt;\(TResponse\)](CatResponse.Ok.md#Cat.Responses.CatResponse.Ok_TResponse_(TResponse) 'Cat\.Responses\.CatResponse\.Ok\<TResponse\>\(TResponse\)') | Creates a succeeded response with the [Ok](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Ok.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Ok') outcome, carrying the given value\. |
| [Unauthorized\(ICatError\[\]\)](CatResponse.Unauthorized.md#Cat.Responses.CatResponse.Unauthorized(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.Unauthorized\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [Unauthorized](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Unauthorized') outcome\. |
| [Unauthorized&lt;TResponse&gt;\(ICatError\[\]\)](CatResponse.Unauthorized.md#Cat.Responses.CatResponse.Unauthorized_TResponse_(Cat.Responses.Abstractions.ICatError[]) 'Cat\.Responses\.CatResponse\.Unauthorized\<TResponse\>\(Cat\.Responses\.Abstractions\.ICatError\[\]\)') | Creates a failed response with the [Unauthorized](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/CatResponseType.Unauthorized.md 'Cat\.Responses\.Abstractions\.CatResponseType\.Unauthorized') outcome\. |
