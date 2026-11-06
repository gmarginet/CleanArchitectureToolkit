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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Transforms Namespace](Cat.Api.Gateway.Transforms.md 'Cat\.Api\.Gateway\.Transforms')

## CatGatewayTransformProvider Class

Adds the security transforms to every route, also to routes that come from plain YARP configuration\.

```csharp
internal sealed class CatGatewayTransformProvider : Yarp.ReverseProxy.Transforms.Builder.ITransformProvider
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayTransformProvider

Implements [Yarp\.ReverseProxy\.Transforms\.Builder\.ITransformProvider](https://learn.microsoft.com/en-us/dotnet/api/yarp.reverseproxy.transforms.builder.itransformprovider 'Yarp\.ReverseProxy\.Transforms\.Builder\.ITransformProvider')

### Remarks
- Removes the headers a caller could use to fake an identity, and the gateway assertion header.
- Replaces the `X-Forwarded-*` headers, unless you trust an earlier proxy.
- Adds the gateway assertion to routes of a service that is gateway only.

            The header removal runs after YARP copied the request headers, so the copy cannot bring a header back\.

| Constructors | |
| :--- | :--- |
| [CatGatewayTransformProvider\(CatGatewayConfigurationProvider, CatGatewaySigningKeys\)](CatGatewayTransformProvider..ctor.QOGJWHOL1CBB0TFCTGS2CZ9Y6.md 'Cat\.Api\.Gateway\.Transforms\.CatGatewayTransformProvider\.CatGatewayTransformProvider\(Cat\.Api\.Gateway\.Configuration\.CatGatewayConfigurationProvider, Cat\.Api\.Gateway\.Assertion\.CatGatewaySigningKeys\)') | |

| Fields | |
| :--- | :--- |
| [BuiltInStripHeaders](CatGatewayTransformProvider.BuiltInStripHeaders.md 'Cat\.Api\.Gateway\.Transforms\.CatGatewayTransformProvider\.BuiltInStripHeaders') | |
| [\_configuration](CatGatewayTransformProvider._configuration.md 'Cat\.Api\.Gateway\.Transforms\.CatGatewayTransformProvider\.\_configuration') | |
| [\_signingKeys](CatGatewayTransformProvider._signingKeys.md 'Cat\.Api\.Gateway\.Transforms\.CatGatewayTransformProvider\.\_signingKeys') | |

| Methods | |
| :--- | :--- |
| [Apply\(TransformBuilderContext\)](CatGatewayTransformProvider.Apply.9WZ3AK3G5L3LQOQ23KNBNSL0C.md 'Cat\.Api\.Gateway\.Transforms\.CatGatewayTransformProvider\.Apply\(Yarp\.ReverseProxy\.Transforms\.Builder\.TransformBuilderContext\)') | |
| [ValidateCluster\(TransformClusterValidationContext\)](CatGatewayTransformProvider.ValidateCluster.0M7S1PA6Y5BUA99BFO8NM1Q7A.md 'Cat\.Api\.Gateway\.Transforms\.CatGatewayTransformProvider\.ValidateCluster\(Yarp\.ReverseProxy\.Transforms\.Builder\.TransformClusterValidationContext\)') | |
| [ValidateRoute\(TransformRouteValidationContext\)](CatGatewayTransformProvider.ValidateRoute.I3ZFNNO906APMYU1ORR5WS589.md 'Cat\.Api\.Gateway\.Transforms\.CatGatewayTransformProvider\.ValidateRoute\(Yarp\.ReverseProxy\.Transforms\.Builder\.TransformRouteValidationContext\)') | |
