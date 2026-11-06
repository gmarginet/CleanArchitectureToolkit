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

## CatGatewayKeyProvider Class

Gives the public keys of the gateway: the configured keys, and the keys it downloads from the gateway\.

```csharp
internal sealed class CatGatewayKeyProvider : System.IDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatGatewayKeyProvider

Implements [System\.IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable 'System\.IDisposable')

| Constructors | |
| :--- | :--- |
| [CatGatewayKeyProvider\(CatGatewayVerificationOptions, IHttpClientFactory, TimeProvider, ILogger&lt;CatGatewayKeyProvider&gt;\)](CatGatewayKeyProvider..ctor.V9CCNV1DH3I0OOBPZA1UV1M1F.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.CatGatewayKeyProvider\(Cat\.Api\.Gateway\.Verification\.CatGatewayVerificationOptions, System\.Net\.Http\.IHttpClientFactory, System\.TimeProvider, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\>\)') | |

| Fields | |
| :--- | :--- |
| [HttpClientName](CatGatewayKeyProvider.HttpClientName.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.HttpClientName') | |
| [\_configuredKeys](CatGatewayKeyProvider._configuredKeys.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.\_configuredKeys') | |
| [\_download](CatGatewayKeyProvider._download.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.\_download') | |
| [\_downloaded](CatGatewayKeyProvider._downloaded.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.\_downloaded') | |
| [\_httpClientFactory](CatGatewayKeyProvider._httpClientFactory.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.\_httpClientFactory') | |
| [\_lastDownload](CatGatewayKeyProvider._lastDownload.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.\_lastDownload') | |
| [\_logger](CatGatewayKeyProvider._logger.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.\_logger') | |
| [\_options](CatGatewayKeyProvider._options.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.\_options') | |
| [\_owned](CatGatewayKeyProvider._owned.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.\_owned') | |
| [\_refreshAt](CatGatewayKeyProvider._refreshAt.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.\_refreshAt') | |
| [\_time](CatGatewayKeyProvider._time.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.\_time') | |

| Methods | |
| :--- | :--- |
| [CreateKey\(string\)](CatGatewayKeyProvider.CreateKey.G3VQT0X6TXNH74IWDJMXZKV4B.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.CreateKey\(string\)') | |
| [Dispose\(\)](CatGatewayKeyProvider.Dispose().md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.Dispose\(\)') | |
| [DownloadAsync\(DateTimeOffset, CancellationToken\)](CatGatewayKeyProvider.DownloadAsync.HRZY2183BYM6OM55IGHATWQS.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.DownloadAsync\(System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | |
| [GetKeysAsync\(string, CancellationToken\)](CatGatewayKeyProvider.GetKeysAsync.OIH35MIKOM0VYXCO74VSPLOB3.md 'Cat\.Api\.Gateway\.Verification\.CatGatewayKeyProvider\.GetKeysAsync\(string, System\.Threading\.CancellationToken\)') | Gives the keys to check an assertion with\. |
