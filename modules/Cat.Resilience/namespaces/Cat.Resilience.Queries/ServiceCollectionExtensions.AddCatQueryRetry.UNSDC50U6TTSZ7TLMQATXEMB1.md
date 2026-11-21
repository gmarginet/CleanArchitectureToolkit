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
  
##### >> [Cat\.Resilience\.Queries Assembly](index.md 'index') >> [Cat\.Resilience\.Queries\.Extensions Namespace](Cat.Resilience.Queries.Extensions.md 'Cat\.Resilience\.Queries\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Resilience\.Queries\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatQueryRetry\(this IServiceCollection, Action\<CatQueryRetryOptions\>\) Method

Retries the query types that you list, through a resilience profile, with a fresh scope for every try\.
Register the queries module with `AddCatQueriesModule` and the resilience module with `AddCatResilienceModule` first,
because the processor is wrapped and the pipelines come from there\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatQueryRetry(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Cat.Resilience.Queries.CatQueryRetryOptions> configure);
```
#### Parameters

<a name='Cat.Resilience.Queries.Extensions.ServiceCollectionExtensions.AddCatQueryRetry(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Resilience.Queries.CatQueryRetryOptions_).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.Resilience.Queries.Extensions.ServiceCollectionExtensions.AddCatQueryRetry(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Resilience.Queries.CatQueryRetryOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatQueryRetryOptions](CatQueryRetryOptions.md 'Cat\.Resilience\.Queries\.CatQueryRetryOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Lists the query types, for example `options.Retry<GetPriceQuery>()`\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, for chaining\.

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')  
A query type is listed, but no `ICatQueryProcessor` is registered yet\.