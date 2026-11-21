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

## ServiceCollectionExtensions Class

Registration helpers for the resilience module\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatResilienceModule\(this IServiceCollection, Action&lt;CatResilienceOptions&gt;\)](ServiceCollectionExtensions.AddCatResilienceModule.5UB2WOLLX95VBEC3WR5ZPV1I2.md 'Cat\.Resilience\.Extensions\.ServiceCollectionExtensions\.AddCatResilienceModule\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Action\<Cat\.Resilience\.Abstractions\.CatResilienceOptions\>\)') | Registers the resilience profiles and [ICatResiliencePipelines](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/ICatResiliencePipelines.md 'Cat\.Resilience\.Abstractions\.ICatResiliencePipelines')\. The profiles [Internal](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/CatResilienceProfile.Internal.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfile\.Internal') and [External](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/CatResilienceProfile.External.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfile\.External') exist with their defaults\. Configuration under `Cat:Resilience:Profiles:{name}` wins over the code\. Calling [AddCatResilience\(this IHttpClientBuilder, string\)](HttpClientBuilderExtensions.AddCatResilience.FXCLOKNB1SDIMB6GI4NZN9BU7.md 'Cat\.Resilience\.Extensions\.HttpClientBuilderExtensions\.AddCatResilience\(this Microsoft\.Extensions\.DependencyInjection\.IHttpClientBuilder, string\)') registers the module too, so calling this one is only needed to add profiles or to use [ICatResiliencePipelines](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/ICatResiliencePipelines.md 'Cat\.Resilience\.Abstractions\.ICatResiliencePipelines')\. |
