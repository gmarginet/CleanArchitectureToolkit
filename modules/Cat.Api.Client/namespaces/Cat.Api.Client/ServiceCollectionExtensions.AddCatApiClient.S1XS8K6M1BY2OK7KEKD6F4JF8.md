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
  
##### >> [Cat\.Api\.Client Assembly](index.md 'index') >> [Cat\.Api\.Client\.Extensions Namespace](Cat.Api.Client.Extensions.md 'Cat\.Api\.Client\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Api\.Client\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatApiClient\<TClient,TImplementation\>\(this IServiceCollection, string\) Method

Registers a generated client with its own [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient'), pointed at the API gateway\.
The address can be a plain address from configuration, or an address that service discovery resolves,
such as `https+http://gateway`\. The module does not reference service discovery or Aspire\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IHttpClientBuilder AddCatApiClient<TClient,TImplementation>(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, string gatewayAddress)
    where TClient : class
    where TImplementation : class, TClient;
```
#### Type parameters

<a name='Cat.Api.Client.Extensions.ServiceCollectionExtensions.AddCatApiClient_TClient,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,string).TClient'></a>

`TClient`

The interface of the client\.

<a name='Cat.Api.Client.Extensions.ServiceCollectionExtensions.AddCatApiClient_TClient,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,string).TImplementation'></a>

`TImplementation`

The generated client class\. It takes an [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient') in its constructor\.
#### Parameters

<a name='Cat.Api.Client.Extensions.ServiceCollectionExtensions.AddCatApiClient_TClient,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,string).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add the client to\.

<a name='Cat.Api.Client.Extensions.ServiceCollectionExtensions.AddCatApiClient_TClient,TImplementation_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,string).gatewayAddress'></a>

`gatewayAddress` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The address of the API gateway\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IHttpClientBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.ihttpclientbuilder 'Microsoft\.Extensions\.DependencyInjection\.IHttpClientBuilder')  
The builder of the [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient'), to add handlers such as retries\.