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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway Namespace](Cat.Api.Gateway.md 'Cat\.Api\.Gateway')

## CatApiGatewayExtensions Class

Sets up a gateway in a host project, in three calls\.

```csharp
public static class CatApiGatewayExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatApiGatewayExtensions

### Remarks

A host project calls [AddCatApiGateway\(this IServiceCollection, IConfiguration\)](CatApiGatewayExtensions.AddCatApiGateway.LR897ZD6NMBCCEGNHUQYZHC1D.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions\.AddCatApiGateway\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Microsoft\.Extensions\.Configuration\.IConfiguration\)') on the services, [UseCatApiGateway\(this IApplicationBuilder\)](CatApiGatewayExtensions.UseCatApiGateway.RYGJENGR6GH4BS6UIRK7YTZB1.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions\.UseCatApiGateway\(this Microsoft\.AspNetCore\.Builder\.IApplicationBuilder\)') on the
application and [MapCatApiGateway\(this IEndpointRouteBuilder\)](CatApiGatewayExtensions.MapCatApiGateway.QS3DULSU3Q2N52HOBF7OHS5I2.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions\.MapCatApiGateway\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder\)') on the endpoints:

```csharp
builder.Services.AddCatApiGateway(builder.Configuration);
var app = builder.Build();
app.UseCatApiGateway();
app.MapCatApiGateway();
app.Run();
```

The gateway is secure by default. Every endpoint needs a valid token, unless a service lists it as anonymous.
This also goes for every other endpoint that you map in the host, so mark an endpoint like a health check
with `AllowAnonymous`.

| Fields | |
| :--- | :--- |
| [CorsPolicyName](CatApiGatewayExtensions.CorsPolicyName.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions\.CorsPolicyName') | |

| Methods | |
| :--- | :--- |
| [AddAuthentication\(IServiceCollection, CatGatewayOptions\)](CatApiGatewayExtensions.AddAuthentication.4X694V7XP13TU06FBMFI6FZUE.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions\.AddAuthentication\(Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions\)') | |
| [AddCatApiGateway\(this IServiceCollection, IConfiguration\)](CatApiGatewayExtensions.AddCatApiGateway.LR897ZD6NMBCCEGNHUQYZHC1D.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions\.AddCatApiGateway\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Microsoft\.Extensions\.Configuration\.IConfiguration\)') | Registers the gateway\. It reads the `CatGateway` section of the configuration\. |
| [AddCors\(IServiceCollection, CatGatewayCorsOptions\)](CatApiGatewayExtensions.AddCors.CXHJBNHXIITH855RTW051GT84.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions\.AddCors\(Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Cat\.Api\.Gateway\.Configuration\.CatGatewayCorsOptions\)') | |
| [AddRateLimiting\(IServiceCollection, CatGatewayRateLimitOptions\)](CatApiGatewayExtensions.AddRateLimiting.ARUJD2JGEA7IYV7T1IXC0P0G8.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions\.AddRateLimiting\(Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Cat\.Api\.Gateway\.Configuration\.CatGatewayRateLimitOptions\)') | |
| [MapCatApiGateway\(this IEndpointRouteBuilder\)](CatApiGatewayExtensions.MapCatApiGateway.QS3DULSU3Q2N52HOBF7OHS5I2.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions\.MapCatApiGateway\(this Microsoft\.AspNetCore\.Routing\.IEndpointRouteBuilder\)') | Maps the reverse proxy, and the endpoint that publishes the public keys of the gateway assertion when the gateway has a signing key\. |
| [UseCatApiGateway\(this IApplicationBuilder\)](CatApiGatewayExtensions.UseCatApiGateway.RYGJENGR6GH4BS6UIRK7YTZB1.md 'Cat\.Api\.Gateway\.CatApiGatewayExtensions\.UseCatApiGateway\(this Microsoft\.AspNetCore\.Builder\.IApplicationBuilder\)') | Adds the middleware of the gateway: the correlation id, the request log, the request limits, the rate limit, CORS, authentication and authorization, in that order\. |
