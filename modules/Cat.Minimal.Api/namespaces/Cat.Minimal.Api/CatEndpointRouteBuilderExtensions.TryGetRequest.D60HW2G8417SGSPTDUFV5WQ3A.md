<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Minimal\.Api](index.md 'index') > [Cat\.Minimal\.Api](Cat.Minimal.Api.md 'Cat\.Minimal\.Api') > [CatEndpointRouteBuilderExtensions](CatEndpointRouteBuilderExtensions.md 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions')

## CatEndpointRouteBuilderExtensions\.TryGetRequest\<TRequest\>\(TRequest, TRequest\) Method

Uses the request from the body\. An empty body falls back to the parameterless constructor\.

```csharp
private static bool TryGetRequest<TRequest>(TRequest? body, out TRequest request)
    where TRequest : class;
```
#### Type parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.TryGetRequest_TRequest_(TRequest,TRequest).TRequest'></a>

`TRequest`
#### Parameters

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.TryGetRequest_TRequest_(TRequest,TRequest).body'></a>

`body` [TRequest](CatEndpointRouteBuilderExtensions.TryGetRequest.D60HW2G8417SGSPTDUFV5WQ3A.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.TryGetRequest_TRequest_(TRequest,TRequest).TRequest 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.TryGetRequest\<TRequest\>\(TRequest, TRequest\)\.TRequest')

<a name='Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.TryGetRequest_TRequest_(TRequest,TRequest).request'></a>

`request` [TRequest](CatEndpointRouteBuilderExtensions.TryGetRequest.D60HW2G8417SGSPTDUFV5WQ3A.md#Cat.Minimal.Api.CatEndpointRouteBuilderExtensions.TryGetRequest_TRequest_(TRequest,TRequest).TRequest 'Cat\.Minimal\.Api\.CatEndpointRouteBuilderExtensions\.TryGetRequest\<TRequest\>\(TRequest, TRequest\)\.TRequest')

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`false` when the body is empty and the request type has no parameterless constructor\.