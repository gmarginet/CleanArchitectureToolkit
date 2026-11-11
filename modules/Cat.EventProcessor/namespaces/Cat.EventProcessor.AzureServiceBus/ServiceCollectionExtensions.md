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
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.EventProcessor\.AzureServiceBus\.Extensions Namespace](Cat.EventProcessor.AzureServiceBus.Extensions.md 'Cat\.EventProcessor\.AzureServiceBus\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the Azure Service Bus listener\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatEventProcessorAzureServiceBus\(this IServiceCollection, Action&lt;CatEventProcessorServiceBusOptions&gt;\)](ServiceCollectionExtensions.AddCatEventProcessorAzureServiceBus.6K0Z4EWEIYY0GJA65E7JQ6N49.md 'Cat\.EventProcessor\.AzureServiceBus\.Extensions\.ServiceCollectionExtensions\.AddCatEventProcessorAzureServiceBus\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Action\<Cat\.EventProcessor\.AzureServiceBus\.CatEventProcessorServiceBusOptions\>\)') | Registers the listener that starts a processor for every declared message type\. Call it after `AddCatEventProcessor` and `AddCatMessagingAzureServiceBus`, which holds the connection\. |
| [AddCatEventProcessorHealthCheck\(this IHealthChecksBuilder, string\)](ServiceCollectionExtensions.AddCatEventProcessorHealthCheck.0LC00EOUSMDSQUZBFCET358F.md 'Cat\.EventProcessor\.AzureServiceBus\.Extensions\.ServiceCollectionExtensions\.AddCatEventProcessorHealthCheck\(this Microsoft\.Extensions\.DependencyInjection\.IHealthChecksBuilder, string\)') | Adds the health check of the listeners\. It is unhealthy when a listener has stopped, and degraded for a minute after an error\. |
