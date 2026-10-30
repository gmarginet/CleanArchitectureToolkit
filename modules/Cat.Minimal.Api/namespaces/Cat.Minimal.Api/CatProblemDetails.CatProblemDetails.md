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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.MINIMAL.API](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Minimal\.Api Assembly](index.md 'index') >> [Cat\.Minimal\.Api Namespace](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') >> [CatProblemDetails Class](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails')

## CatProblemDetails Constructors

| Overloads | |
| :--- | :--- |
| [CatProblemDetails\(\)](CatProblemDetails.CatProblemDetails.md#Cat.Minimal.Api.CatProblemDetails.CatProblemDetails() 'Cat\.Minimal\.Api\.CatProblemDetails\.CatProblemDetails\(\)') | Creates an empty instance\. Use it when you fill in the properties yourself\. |
| [CatProblemDetails\(ICatResponse, string, string\)](CatProblemDetails.CatProblemDetails.md#Cat.Minimal.Api.CatProblemDetails.CatProblemDetails(Cat.Responses.Abstractions.ICatResponse,string,string) 'Cat\.Minimal\.Api\.CatProblemDetails\.CatProblemDetails\(Cat\.Responses\.Abstractions\.ICatResponse, string, string\)') | Creates problem details from a failed response\. The status follows the response type: BadRequest gives 400, NotFound gives 404, Unauthorized gives 401\. Every other failure gives 500\. |

<a name='Cat.Minimal.Api.CatProblemDetails.CatProblemDetails()'></a>

## CatProblemDetails\(\) Constructor

Creates an empty instance\. Use it when you fill in the properties yourself\.

```csharp
public CatProblemDetails();
```

<a name='Cat.Minimal.Api.CatProblemDetails.CatProblemDetails(Cat.Responses.Abstractions.ICatResponse,string,string)'></a>

## CatProblemDetails\(ICatResponse, string, string\) Constructor

Creates problem details from a failed response\.
The status follows the response type: BadRequest gives 400, NotFound gives 404, Unauthorized gives 401\.
Every other failure gives 500\.

```csharp
public CatProblemDetails(Cat.Responses.Abstractions.ICatResponse catResponse, string instance, string catTraceId);
```
#### Parameters

<a name='Cat.Minimal.Api.CatProblemDetails.CatProblemDetails(Cat.Responses.Abstractions.ICatResponse,string,string).catResponse'></a>

`catResponse` [ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

The failed response\.

<a name='Cat.Minimal.Api.CatProblemDetails.CatProblemDetails(Cat.Responses.Abstractions.ICatResponse,string,string).instance'></a>

`instance` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the request\.

<a name='Cat.Minimal.Api.CatProblemDetails.CatProblemDetails(Cat.Responses.Abstractions.ICatResponse,string,string).catTraceId'></a>

`catTraceId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The id to find this request in the logs\.