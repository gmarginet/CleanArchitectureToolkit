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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.GATEWAY](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Middleware Namespace](Cat.Api.Gateway.Middleware.md 'Cat\.Api\.Gateway\.Middleware')

## RequestLimitsMiddleware Class

Rejects a request body that is larger than [MaxRequestBodySize](CatGatewayLimitsOptions.MaxRequestBodySize.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayLimitsOptions\.MaxRequestBodySize')\.

```csharp
internal sealed class RequestLimitsMiddleware
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → RequestLimitsMiddleware

| Constructors | |
| :--- | :--- |
| [RequestLimitsMiddleware\(RequestDelegate, CatGatewayConfigurationProvider\)](RequestLimitsMiddleware..ctor.J5U9EVHLBJN0LS9I2C1V37JZ4.md 'Cat\.Api\.Gateway\.Middleware\.RequestLimitsMiddleware\.RequestLimitsMiddleware\(Microsoft\.AspNetCore\.Http\.RequestDelegate, Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider\)') | |

| Fields | |
| :--- | :--- |
| [\_configuration](RequestLimitsMiddleware._configuration.md 'Cat\.Api\.Gateway\.Middleware\.RequestLimitsMiddleware\.\_configuration') | |
| [\_next](RequestLimitsMiddleware._next.md 'Cat\.Api\.Gateway\.Middleware\.RequestLimitsMiddleware\.\_next') | |

| Methods | |
| :--- | :--- |
| [InvokeAsync\(HttpContext\)](RequestLimitsMiddleware.InvokeAsync.DGWWG61ZXLULOUWU6KR0C2RPB.md 'Cat\.Api\.Gateway\.Middleware\.RequestLimitsMiddleware\.InvokeAsync\(Microsoft\.AspNetCore\.Http\.HttpContext\)') | |
