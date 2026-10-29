<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Minimal\.Api](index.md 'index') > [Cat\.Minimal\.Api](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') > [CatProblemDetails](CatProblemDetails.md 'Cat\.Minimal\.Api\.CatProblemDetails')

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

`catResponse` [ICatResponse](..\Cat.Responses.Abstractions\ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')

The failed response\.

<a name='Cat.Minimal.Api.CatProblemDetails.CatProblemDetails(Cat.Responses.Abstractions.ICatResponse,string,string).instance'></a>

`instance` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path of the request\.

<a name='Cat.Minimal.Api.CatProblemDetails.CatProblemDetails(Cat.Responses.Abstractions.ICatResponse,string,string).catTraceId'></a>

`catTraceId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The id to find this request in the logs\.