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
  
##### >> [Cat\.Api\.Client Assembly](index.md 'index')

## Cat\.Api\.Client Namespace

Holds what a generated client needs to call another service through the API gateway: the exception it throws,
the plain class for the error body, and the helper that turns the outcome of a call into a response\.
The `Extensions` namespace registers a generated client\.

| Classes | |
| :--- | :--- |
| [CatApiCall](CatApiCall.md 'Cat\.Api\.Client\.CatApiCall') | Runs a call of a generated client and turns the outcome into an [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')\. A failed call looks like any other failed use case, so the caller never needs to catch the exceptions of the client\. |
| [CatApiException](CatApiException.md 'Cat\.Api\.Client\.CatApiException') | Thrown by a generated client when a call fails or answers with something it did not expect\. The generator settings point at this class, so the generated code needs no exception class of its own\. Use [CatApiCall](CatApiCall.md 'Cat\.Api\.Client\.CatApiCall') to turn it into an `ICatResponse`\. |
| [CatApiException&lt;TResult&gt;](CatApiException_TResult_.md 'Cat\.Api\.Client\.CatApiException\<TResult\>') | A [CatApiException](CatApiException.md 'Cat\.Api\.Client\.CatApiException') that also carries the error body the generated client read from the answer\. |
| [CatProblemDetails](CatProblemDetails.md 'Cat\.Api\.Client\.CatProblemDetails') | The body of a failed answer of a CAT service, as a plain class\. It has the same name and the same JSON shape as `CatProblemDetails` of `Cat.Minimal.Api`, without the ASP\.NET Core base type\. A generated client finds this class through the `Cat.Api.Client` namespace\. |
| [CatProblemDetailsItem](CatProblemDetailsItem.md 'Cat\.Api\.Client\.CatProblemDetailsItem') | One error in a [CatProblemDetails](CatProblemDetails.md 'Cat\.Api\.Client\.CatProblemDetails')\. |
