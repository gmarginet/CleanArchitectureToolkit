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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.API.CLIENT](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Api\.Client Assembly](index.md 'index') >> [Cat\.Api\.Client Namespace](Cat.Api.Client.md 'Cat\.Api\.Client')

## CatProblemDetails Class

The body of a failed answer of a CAT service, as a plain class\.
It has the same name and the same JSON shape as `CatProblemDetails` of `Cat.Minimal.Api`, without the ASP\.NET Core base type\.
A generated client finds this class through the `Cat.Api.Client` namespace\.

```csharp
public class CatProblemDetails
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatProblemDetails

| Properties | |
| :--- | :--- |
| [CatErrors](CatProblemDetails.CatErrors.md 'Cat\.Api\.Client\.CatProblemDetails\.CatErrors') | The errors of the failed response\. |
| [CatTraceId](CatProblemDetails.CatTraceId.md 'Cat\.Api\.Client\.CatProblemDetails\.CatTraceId') | The id to find the request in the logs of the service\. |
| [Detail](CatProblemDetails.Detail.md 'Cat\.Api\.Client\.CatProblemDetails\.Detail') | An explanation specific to this occurrence of the problem\. |
| [Instance](CatProblemDetails.Instance.md 'Cat\.Api\.Client\.CatProblemDetails\.Instance') | The path of the request that failed\. |
| [Status](CatProblemDetails.Status.md 'Cat\.Api\.Client\.CatProblemDetails\.Status') | The HTTP status code\. |
| [Title](CatProblemDetails.Title.md 'Cat\.Api\.Client\.CatProblemDetails\.Title') | A short summary of the problem\. |
| [Type](CatProblemDetails.Type.md 'Cat\.Api\.Client\.CatProblemDetails\.Type') | A link to the description of the problem type\. |
