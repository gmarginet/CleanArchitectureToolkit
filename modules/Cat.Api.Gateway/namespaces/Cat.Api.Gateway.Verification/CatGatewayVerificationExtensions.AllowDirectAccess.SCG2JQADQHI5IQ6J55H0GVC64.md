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
  
##### >> [Cat\.Api\.Gateway\.Verification Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Verification Namespace](Cat.Api.Gateway.Verification.md 'Cat\.Api\.Gateway\.Verification') >> [CatGatewayVerificationExtensions Class](CatGatewayVerificationExtensions.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions')

## CatGatewayVerificationExtensions\.AllowDirectAccess\<TBuilder\>\(this TBuilder\) Method

Lets an endpoint skip the gateway check, so a caller can reach it without the gateway\.

```csharp
public static TBuilder AllowDirectAccess<TBuilder>(this TBuilder builder)
    where TBuilder : Microsoft.AspNetCore.Builder.IEndpointConventionBuilder;
```
#### Type parameters

<a name='Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AllowDirectAccess_TBuilder_(thisTBuilder).TBuilder'></a>

`TBuilder`

The type of the endpoint convention builder\.
#### Parameters

<a name='Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AllowDirectAccess_TBuilder_(thisTBuilder).builder'></a>

`builder` [TBuilder](CatGatewayVerificationExtensions.AllowDirectAccess.SCG2JQADQHI5IQ6J55H0GVC64.md#Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AllowDirectAccess_TBuilder_(thisTBuilder).TBuilder 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.AllowDirectAccess\<TBuilder\>\(this TBuilder\)\.TBuilder')

The endpoint convention builder\.

#### Returns
[TBuilder](CatGatewayVerificationExtensions.AllowDirectAccess.SCG2JQADQHI5IQ6J55H0GVC64.md#Cat.Api.Gateway.Verification.CatGatewayVerificationExtensions.AllowDirectAccess_TBuilder_(thisTBuilder).TBuilder 'Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationExtensions\.AllowDirectAccess\<TBuilder\>\(this TBuilder\)\.TBuilder')  
The same builder\.