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
  
##### >> [Cat\.Resilience Assembly](index.md 'index') >> [Cat\.Resilience\.Extensions Namespace](Cat.Resilience.Extensions.md 'Cat\.Resilience\.Extensions')

## HttpClientBuilderExtensions Class

Puts a resilience profile on an [Microsoft\.Extensions\.DependencyInjection\.IHttpClientBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.ihttpclientbuilder 'Microsoft\.Extensions\.DependencyInjection\.IHttpClientBuilder')\.

```csharp
public static class HttpClientBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → HttpClientBuilderExtensions

| Fields | |
| :--- | :--- |
| [TooManyRequests](HttpClientBuilderExtensions.TooManyRequests.md 'Cat\.Resilience\.Extensions\.HttpClientBuilderExtensions\.TooManyRequests') | |

| Methods | |
| :--- | :--- |
| [AddCatResilience\(this IHttpClientBuilder, string\)](HttpClientBuilderExtensions.AddCatResilience.FXCLOKNB1SDIMB6GI4NZN9BU7.md 'Cat\.Resilience\.Extensions\.HttpClientBuilderExtensions\.AddCatResilience\(this Microsoft\.Extensions\.DependencyInjection\.IHttpClientBuilder, string\)') | Puts the resilience profile on the client\. The pipeline replaces any resilience handler that the client already has, such as the one a `ConfigureHttpClientDefaults` call added, so a client never has two retry layers\. The profile has a rate limiter, a total timeout, a retry, a circuit breaker and a timeout per try\. The circuit breaker state is kept per client and per process\. A name that no profile has fails the startup of the host\. |
| [Build\(ResiliencePipelineBuilder&lt;HttpResponseMessage&gt;, CatResilienceProfileOptions, TimeProvider\)](HttpClientBuilderExtensions.Build.CZ54FVRQ6H981UCA4EWWFJRI1.md 'Cat\.Resilience\.Extensions\.HttpClientBuilderExtensions\.Build\(ResiliencePipelineBuilder\<System\.Net\.Http\.HttpResponseMessage\>, Cat\.Resilience\.Abstractions\.CatResilienceProfileOptions, System\.TimeProvider\)') | |
| [IsSafe\(HttpMethod\)](HttpClientBuilderExtensions.IsSafe.XI8LYRTY7VBFW2ZC49IQ88ZP5.md 'Cat\.Resilience\.Extensions\.HttpClientBuilderExtensions\.IsSafe\(System\.Net\.Http\.HttpMethod\)') | |
| [ShouldRetry\(RetryPredicateArguments&lt;HttpResponseMessage&gt;, CatRetryOptions\)](HttpClientBuilderExtensions.ShouldRetry.PROX5SBRN3LP5NJFIPX9WKMU9.md 'Cat\.Resilience\.Extensions\.HttpClientBuilderExtensions\.ShouldRetry\(RetryPredicateArguments\<System\.Net\.Http\.HttpResponseMessage\>, Cat\.Resilience\.Abstractions\.CatRetryOptions\)') | |
