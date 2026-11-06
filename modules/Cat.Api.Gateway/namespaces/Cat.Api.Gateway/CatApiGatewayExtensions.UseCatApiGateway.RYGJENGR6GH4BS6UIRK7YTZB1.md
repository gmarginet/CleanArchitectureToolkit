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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.GATEWAY](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway Namespace](Cat.Api.Gateway.md 'Cat\.Api\.Gateway') >> [CatApiGatewayExtensions Class](CatApiGatewayExtensions.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions')

## CatApiGatewayExtensions\.UseCatApiGateway\(this IApplicationBuilder\) Method

Adds the middleware of the gateway: the correlation id, the request log, the request limits, the rate limit,
CORS, authentication and authorization, in that order\.

```csharp
public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseCatApiGateway(this Microsoft.AspNetCore.Builder.IApplicationBuilder app);
```
#### Parameters

<a name='Cat.Api.Gateway.CatApiGatewayExtensions.UseCatApiGateway(thisMicrosoft.AspNetCore.Builder.IApplicationBuilder).app'></a>

`app` [Microsoft\.AspNetCore\.Builder\.IApplicationBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder 'Microsoft\.AspNetCore\.Builder\.IApplicationBuilder')

The application builder\.

#### Returns
[Microsoft\.AspNetCore\.Builder\.IApplicationBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder 'Microsoft\.AspNetCore\.Builder\.IApplicationBuilder')  
The same application builder\.

### Remarks
Call it after `UseRouting` when you use an application builder that does not add routing itself\. A
`WebApplication` does\.