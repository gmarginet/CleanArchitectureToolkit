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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESILIENCE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Resilience Assembly](index.md 'index') >> [Cat\.Resilience\.Extensions Namespace](Cat.Resilience.Extensions.md 'Cat\.Resilience\.Extensions') >> [HttpClientBuilderExtensions Class](HttpClientBuilderExtensions.md 'Cat\.Resilience\.Extensions\.HttpClientBuilderExtensions')

## HttpClientBuilderExtensions\.AddCatResilience\(this IHttpClientBuilder, string\) Method

Puts the resilience profile on the client\. The pipeline replaces any resilience handler that the client already has,
such as the one a `ConfigureHttpClientDefaults` call added, so a client never has two retry layers\.
The profile has a rate limiter, a total timeout, a retry, a circuit breaker and a timeout per try\.
The circuit breaker state is kept per client and per process\.
A name that no profile has fails the startup of the host\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IHttpClientBuilder AddCatResilience(this Microsoft.Extensions.DependencyInjection.IHttpClientBuilder builder, string profileName="Internal");
```
#### Parameters

<a name='Cat.Resilience.Extensions.HttpClientBuilderExtensions.AddCatResilience(thisMicrosoft.Extensions.DependencyInjection.IHttpClientBuilder,string).builder'></a>

`builder` [Microsoft\.Extensions\.DependencyInjection\.IHttpClientBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.ihttpclientbuilder 'Microsoft\.Extensions\.DependencyInjection\.IHttpClientBuilder')

The client builder\.

<a name='Cat.Resilience.Extensions.HttpClientBuilderExtensions.AddCatResilience(thisMicrosoft.Extensions.DependencyInjection.IHttpClientBuilder,string).profileName'></a>

`profileName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the profile\. The default is [Internal](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/CatResilienceProfile.Internal.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfile\.Internal')\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IHttpClientBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.ihttpclientbuilder 'Microsoft\.Extensions\.DependencyInjection\.IHttpClientBuilder')  
The same client builder, for chaining\.