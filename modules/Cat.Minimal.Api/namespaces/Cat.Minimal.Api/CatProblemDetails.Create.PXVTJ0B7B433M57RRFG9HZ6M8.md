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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MINIMAL.API](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') >> [CatProblemDetails Class](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails')

## CatProblemDetails\.Create\(HttpContext, int, string, string, IReadOnlyList\<ICatError\>\) Method

Creates problem details for the current request, with the trace id filled in\.

```csharp
internal static Cat.Minimal.Api.CatProblemDetails Create(Microsoft.AspNetCore.Http.HttpContext httpContext, int status, string title, string detail, System.Collections.Generic.IReadOnlyList<Cat.Responses.Abstractions.ICatError>? catErrors=null);
```
#### Parameters

<a name='Cat.Minimal.Api.CatProblemDetails.Create(Microsoft.AspNetCore.Http.HttpContext,int,string,string,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).httpContext'></a>

`httpContext` [Microsoft\.AspNetCore\.Http\.HttpContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpcontext 'Microsoft\.AspNetCore\.Http\.HttpContext')

The current request\.

<a name='Cat.Minimal.Api.CatProblemDetails.Create(Microsoft.AspNetCore.Http.HttpContext,int,string,string,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).status'></a>

`status` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The http status code\.

<a name='Cat.Minimal.Api.CatProblemDetails.Create(Microsoft.AspNetCore.Http.HttpContext,int,string,string,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).title'></a>

`title` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

A short summary of the problem\.

<a name='Cat.Minimal.Api.CatProblemDetails.Create(Microsoft.AspNetCore.Http.HttpContext,int,string,string,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).detail'></a>

`detail` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An explanation specific to this occurrence of the problem\.

<a name='Cat.Minimal.Api.CatProblemDetails.Create(Microsoft.AspNetCore.Http.HttpContext,int,string,string,System.Collections.Generic.IReadOnlyList_Cat.Responses.Abstractions.ICatError_).catErrors'></a>

`catErrors` [System\.Collections\.Generic\.IReadOnlyList&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')[ICatError](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatError.md 'Cat\.Responses\.Abstractions\.ICatError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist-1 'System\.Collections\.Generic\.IReadOnlyList\`1')

The errors of the failed response\. Defaults to an empty list\.

#### Returns
[CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails')  
The new problem details\.