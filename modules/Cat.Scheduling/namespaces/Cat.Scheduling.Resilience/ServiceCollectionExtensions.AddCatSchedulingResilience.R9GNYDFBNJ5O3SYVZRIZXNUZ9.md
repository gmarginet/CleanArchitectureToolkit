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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SCHEDULING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Scheduling\.Resilience Assembly](index.md 'index') >> [Cat\.Scheduling\.Resilience\.Extensions Namespace](Cat.Scheduling.Resilience.Extensions.md 'Cat\.Scheduling\.Resilience\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Scheduling\.Resilience\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatSchedulingResilience\(this IServiceCollection, Action\<CatSchedulingResilienceOptions\>\) Method

Retries a failed run of every job through a resilience profile\.
Register the resilience module too, with `AddCatResilienceModule` of `Cat.Resilience`,
because the pipelines come from there\. Call this before or after `AddCatScheduling`\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatSchedulingResilience(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Cat.Scheduling.Resilience.CatSchedulingResilienceOptions>? configure=null);
```
#### Parameters

<a name='Cat.Scheduling.Resilience.Extensions.ServiceCollectionExtensions.AddCatSchedulingResilience(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Scheduling.Resilience.CatSchedulingResilienceOptions_).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.Scheduling.Resilience.Extensions.ServiceCollectionExtensions.AddCatSchedulingResilience(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Action_Cat.Scheduling.Resilience.CatSchedulingResilienceOptions_).configure'></a>

`configure` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatSchedulingResilienceOptions](CatSchedulingResilienceOptions.md 'Cat\.Scheduling\.Resilience\.CatSchedulingResilienceOptions')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Sets the profile of all jobs or of single jobs\. Optional\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, for chaining\.