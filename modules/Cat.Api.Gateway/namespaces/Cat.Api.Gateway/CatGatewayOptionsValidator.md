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
  
##### >> [Cat\.Api\.Gateway Assembly](index.md 'index') >> [Cat\.Api\.Gateway\.Configuration Namespace](Cat.Api.Gateway.Configuration.md 'Cat\.Api\.Gateway\.Configuration')

## CatGatewayOptionsValidator Class

Checks the gateway configuration\. A configuration that fails never goes live\.

```csharp
internal static class CatGatewayOptionsValidator
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayOptionsValidator

| Constructors | |
| :--- | :--- |
| [CatGatewayOptionsValidator\(\)](CatGatewayOptionsValidator.CatGatewayOptionsValidator().md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.CatGatewayOptionsValidator\(\)') | |

| Fields | |
| :--- | :--- |
| [MaximumAssertionLifetime](CatGatewayOptionsValidator.MaximumAssertionLifetime.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.MaximumAssertionLifetime') | |
| [MinimumAssertionLifetime](CatGatewayOptionsValidator.MinimumAssertionLifetime.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.MinimumAssertionLifetime') | |

| Methods | |
| :--- | :--- |
| [EffectiveAddresses\(CatGatewayServiceOptions\)](CatGatewayOptionsValidator.EffectiveAddresses.47BINWLI25QGD434H6V0Y74R3.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.EffectiveAddresses\(Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\)') | |
| [EffectiveGatewayOnly\(CatGatewayOptions, CatGatewayServiceOptions\)](CatGatewayOptionsValidator.EffectiveGatewayOnly.ZJLVMNAPCS900YQQZSY5CJBX6.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.EffectiveGatewayOnly\(Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions, Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\)') | |
| [EffectivePath\(string, CatGatewayServiceOptions\)](CatGatewayOptionsValidator.EffectivePath.U66IBN4X7MT1MXC18BJZKRTN8.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.EffectivePath\(string, Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\)') | |
| [EffectiveTimeout\(CatGatewayOptions, CatGatewayServiceOptions\)](CatGatewayOptionsValidator.EffectiveTimeout.X7WLDNYH5W88CQL2ID0RQ5JF8.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.EffectiveTimeout\(Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions, Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\)') | |
| [IsFullyAnonymous\(CatGatewayServiceOptions\)](CatGatewayOptionsValidator.IsFullyAnonymous.VWOPSMRX0PXBCWBT50LJFUU94.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.IsFullyAnonymous\(Cat\.Api\.Gateway\.Configuration\.CatGatewayServiceOptions\)') | |
| [IsValidName\(string\)](CatGatewayOptionsValidator.IsValidName.IMF1Q8VWIZJ4WO1C2XOWA76UE.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.IsValidName\(string\)') | |
| [IsValidPath\(string\)](CatGatewayOptionsValidator.IsValidPath.PLHKX3NOICGZO2TIGO27HU7K1.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.IsValidPath\(string\)') | |
| [Validate\(CatGatewayOptions, bool\)](CatGatewayOptionsValidator.Validate.JJWCZWA2R6MXM3AKW0XDAYQY8.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.Validate\(Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions, bool\)') | |
| [ValidateAssertion\(CatGatewayOptions, List&lt;string&gt;\)](CatGatewayOptionsValidator.ValidateAssertion.CTR09C8I6U392W3BKPYFKCNPA.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.ValidateAssertion\(Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions, System\.Collections\.Generic\.List\<string\>\)') | |
| [ValidateAuthentication\(CatGatewayOptions, List&lt;string&gt;\)](CatGatewayOptionsValidator.ValidateAuthentication.V6MBH1G7GUU0O8QE2W39IWKK2.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.ValidateAuthentication\(Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions, System\.Collections\.Generic\.List\<string\>\)') | |
| [ValidateCors\(CatGatewayCorsOptions, List&lt;string&gt;\)](CatGatewayOptionsValidator.ValidateCors.PSY7LD713L7KPEMJ7QG4I6L27.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.ValidateCors\(Cat\.Api\.Gateway\.Configuration\.CatGatewayCorsOptions, System\.Collections\.Generic\.List\<string\>\)') | |
| [ValidateServices\(CatGatewayOptions, bool, List&lt;string&gt;\)](CatGatewayOptionsValidator.ValidateServices.FW711YJ41R3GBXDU1U4A985PA.md 'Cat\.Api\.Gateway\.Configuration\.CatGatewayOptionsValidator\.ValidateServices\(Cat\.Api\.Gateway\.Configuration\.CatGatewayOptions, bool, System\.Collections\.Generic\.List\<string\>\)') | |
