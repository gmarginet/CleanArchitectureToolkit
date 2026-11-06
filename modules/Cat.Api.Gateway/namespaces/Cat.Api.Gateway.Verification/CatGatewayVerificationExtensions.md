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
  
##### >> [Cat\.Api\.Gateway\.Verification Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Verification Namespace](Cat.Api.Gateway.Verification.md 'Cat\.Api\.Gateway\.Verification')

## CatGatewayVerificationExtensions Class

Makes a service accept only the calls that come from the gateway\.

```csharp
public static class CatGatewayVerificationExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayVerificationExtensions

### Remarks

Register the check with [AddCatGatewayVerification\(this IServiceCollection, IConfiguration\)](CatGatewayVerificationExtensions.AddCatGatewayVerification.md#Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration) 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.AddCatGatewayVerification\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Microsoft\.Extensions\.Configuration\.IConfiguration\)') and switch
it on for the whole service with [UseCatGatewayOnly\(this IApplicationBuilder\)](CatGatewayVerificationExtensions.UseCatGatewayOnly.YJQT1V052H6AD7GF455OZJGA8.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.UseCatGatewayOnly\(this Microsoft\.AspNetCore\.Builder\.IApplicationBuilder\)'):

```csharp
builder.Services.AddCatGatewayVerification(builder.Configuration);
var app = builder.Build();
app.UseCatGatewayOnly();
```

A request without a valid assertion gets a 401 answer. Mark an endpoint that must stay reachable without the
gateway, such as a health check, with [AllowDirectAccess&lt;TBuilder&gt;\(this TBuilder\)](CatGatewayVerificationExtensions.AllowDirectAccess.SCG2JQADQHI5IQ6J55H0GVC64.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.AllowDirectAccess\<TBuilder\>\(this TBuilder\)').

Prefer an authorization policy for finer control. The scheme name is
[AuthenticationScheme](CatGatewayVerificationDefaults.AuthenticationScheme.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationDefaults\.AuthenticationScheme').

| Methods | |
| :--- | :--- |
| [AddCatGatewayVerification\(this IServiceCollection, IConfiguration\)](CatGatewayVerificationExtensions.AddCatGatewayVerification.md#Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration) 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.AddCatGatewayVerification\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Microsoft\.Extensions\.Configuration\.IConfiguration\)') | Registers the check\. It reads the `CatGatewayVerification` section of the configuration\. |
| [AddCatGatewayVerification\(this IServiceCollection, Action&lt;CatGatewayVerificationOptions&gt;\)](CatGatewayVerificationExtensions.AddCatGatewayVerification.md#Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AddCatGatewayVerification(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Api.Gateway.Verification.CatGatewayVerificationOptions_) 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.AddCatGatewayVerification\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Action\<Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions\>\)') | Registers the check with settings from code\. |
| [AllowDirectAccess&lt;TBuilder&gt;\(this TBuilder\)](CatGatewayVerificationExtensions.AllowDirectAccess.SCG2JQADQHI5IQ6J55H0GVC64.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.AllowDirectAccess\<TBuilder\>\(this TBuilder\)') | Lets an endpoint skip the gateway check, so a caller can reach it without the gateway\. |
| [UseCatGatewayOnly\(this IApplicationBuilder\)](CatGatewayVerificationExtensions.UseCatGatewayOnly.YJQT1V052H6AD7GF455OZJGA8.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.UseCatGatewayOnly\(this Microsoft\.AspNetCore\.Builder\.IApplicationBuilder\)') | Rejects every request that has no valid gateway assertion, except for endpoints that allow direct access\. |
