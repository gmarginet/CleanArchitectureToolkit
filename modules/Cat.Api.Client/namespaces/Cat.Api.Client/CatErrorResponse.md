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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.CLIENT](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Client Assembly](index.md 'index') >> [Cat\.Api\.Client Namespace](Cat.Api.Client.md 'Cat\.Api\.Client')

## CatErrorResponse Class

The body of a failed answer of a CAT service, as a plain class\.
It has the same JSON shape as `CatProblemDetails` of `Cat.Minimal.Api`, without the ASP\.NET Core base type\.

```csharp
public class CatErrorResponse
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatErrorResponse

| Properties | |
| :--- | :--- |
| [CatErrors](CatErrorResponse.CatErrors.md 'Cat\.Api\.Client\.CatErrorResponse\.CatErrors') | The errors of the failed response\. |
| [CatTraceId](CatErrorResponse.CatTraceId.md 'Cat\.Api\.Client\.CatErrorResponse\.CatTraceId') | The id to find the request in the logs of the service\. |
| [Detail](CatErrorResponse.Detail.md 'Cat\.Api\.Client\.CatErrorResponse\.Detail') | An explanation specific to this occurrence of the problem\. |
| [Instance](CatErrorResponse.Instance.md 'Cat\.Api\.Client\.CatErrorResponse\.Instance') | The path of the request that failed\. |
| [Status](CatErrorResponse.Status.md 'Cat\.Api\.Client\.CatErrorResponse\.Status') | The HTTP status code\. |
| [Title](CatErrorResponse.Title.md 'Cat\.Api\.Client\.CatErrorResponse\.Title') | A short summary of the problem\. |
| [Type](CatErrorResponse.Type.md 'Cat\.Api\.Client\.CatErrorResponse\.Type') | A link to the description of the problem type\. |
