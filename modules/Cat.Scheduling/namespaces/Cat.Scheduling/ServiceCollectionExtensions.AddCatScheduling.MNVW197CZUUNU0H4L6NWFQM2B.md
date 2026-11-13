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
  
##### >> [Cat\.Scheduling Assembly](index.md 'index') >> [Cat\.Scheduling\.Extensions Namespace](Cat.Scheduling.Extensions.md 'Cat\.Scheduling\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Scheduling\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatScheduling\(this IServiceCollection, IConfiguration, Action\<CatSchedulerBuilder\>\) Method

Registers the scheduler, the jobs the service declares and the runner\. The scheduler starts with the host\.
The settings per job come from the code\. The configuration wins, so whoever runs the service can change a cron expression
or switch a job off without a build\. A cron expression or a time zone that is not valid throws here, so the service fails at startup\.
Register the service request module too\. The claim store is in memory unless you register another one, such as
the EF Core store of `Cat.Scheduling.EFCore`\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatScheduling(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration, System.Action<Cat.Scheduling.CatSchedulerBuilder> declare);
```
#### Parameters

<a name='Cat.Scheduling.Extensions.ServiceCollectionExtensions.AddCatScheduling(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.Action_Cat.Scheduling.CatSchedulerBuilder_).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.Scheduling.Extensions.ServiceCollectionExtensions.AddCatScheduling(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.Action_Cat.Scheduling.CatSchedulerBuilder_).configuration'></a>

`configuration` [Microsoft\.Extensions\.Configuration\.IConfiguration](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration 'Microsoft\.Extensions\.Configuration\.IConfiguration')

The configuration of the service\.

<a name='Cat.Scheduling.Extensions.ServiceCollectionExtensions.AddCatScheduling(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.Action_Cat.Scheduling.CatSchedulerBuilder_).declare'></a>

`declare` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[CatSchedulerBuilder](CatSchedulerBuilder.md 'Cat\.Scheduling\.CatSchedulerBuilder')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Declares the jobs\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, so calls can be chained\.