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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.MINIMAL.API](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') >> [CatEndpointRouteBuilderExtensions Class](CatEndpointRouteBuilderExtensions.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions')

## CatEndpointRouteBuilderExtensions\.TryGetRequest\<TRequest\>\(TRequest, TRequest\) Method

Uses the request from the body\. An empty body falls back to the parameterless constructor\.

```csharp
private static bool TryGetRequest<TRequest>(TRequest? body, out TRequest request)
    where TRequest : class;
```
#### Type parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.TryGetRequest_TRequest_(TRequest,TRequest).TRequest'></a>

`TRequest`
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.TryGetRequest_TRequest_(TRequest,TRequest).body'></a>

`body` [TRequest](CatEndpointRouteBuilderExtensions.TryGetRequest.D60HW2G8417SGSPTDUFV5WQ3A.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.TryGetRequest_TRequest_(TRequest,TRequest).TRequest 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.TryGetRequest\<TRequest\>\(TRequest, TRequest\)\.TRequest')

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.TryGetRequest_TRequest_(TRequest,TRequest).request'></a>

`request` [TRequest](CatEndpointRouteBuilderExtensions.TryGetRequest.D60HW2G8417SGSPTDUFV5WQ3A.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.TryGetRequest_TRequest_(TRequest,TRequest).TRequest 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.TryGetRequest\<TRequest\>\(TRequest, TRequest\)\.TRequest')

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`false` when the body is empty and the request type has no parameterless constructor\.