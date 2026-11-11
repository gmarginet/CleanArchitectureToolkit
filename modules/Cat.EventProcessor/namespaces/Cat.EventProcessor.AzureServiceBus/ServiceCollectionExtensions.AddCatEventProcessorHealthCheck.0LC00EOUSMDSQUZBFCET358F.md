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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EVENTPROCESSOR](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.EventProcessor\.AzureServiceBus\.Extensions Namespace](Cat.EventProcessor.AzureServiceBus.Extensions.md 'Cat\.EventProcessor\.AzureServiceBus\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.EventProcessor\.AzureServiceBus\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatEventProcessorHealthCheck\(this IHealthChecksBuilder, string\) Method

Adds the health check of the listeners\. It is unhealthy when a listener has stopped, and degraded for a minute after an error\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IHealthChecksBuilder AddCatEventProcessorHealthCheck(this Microsoft.Extensions.DependencyInjection.IHealthChecksBuilder builder, string name="cat-event-processor");
```
#### Parameters

<a name='Cat.EventProcessor.AzureServiceBus.Extensions.ServiceCollectionExtensions.AddCatEventProcessorHealthCheck(thisMicrosoft.Extensions.DependencyInjection.IHealthChecksBuilder,string).builder'></a>

`builder` [Microsoft\.Extensions\.DependencyInjection\.IHealthChecksBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.ihealthchecksbuilder 'Microsoft\.Extensions\.DependencyInjection\.IHealthChecksBuilder')

The health checks builder\.

<a name='Cat.EventProcessor.AzureServiceBus.Extensions.ServiceCollectionExtensions.AddCatEventProcessorHealthCheck(thisMicrosoft.Extensions.DependencyInjection.IHealthChecksBuilder,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the check\. The default is `cat-event-processor`\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IHealthChecksBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.ihealthchecksbuilder 'Microsoft\.Extensions\.DependencyInjection\.IHealthChecksBuilder')  
The same builder, so calls can be chained\.