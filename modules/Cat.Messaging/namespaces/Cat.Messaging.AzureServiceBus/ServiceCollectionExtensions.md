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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.MESSAGING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Messaging\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.Messaging\.AzureServiceBus\.Extensions Namespace](Cat.Messaging.AzureServiceBus.Extensions.md 'Cat\.Messaging\.AzureServiceBus\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the Azure Service Bus transport\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatDeadLetterMetric\(this IServiceCollection, Action&lt;CatDeadLetterMetricsOptions&gt;\)](ServiceCollectionExtensions.AddCatDeadLetterMetric.IL2F3QW92J28Y4BSCR55LT7H.md 'Cat\.Messaging\.AzureServiceBus\.Extensions\.ServiceCollectionExtensions\.AddCatDeadLetterMetric\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Action\<Cat\.Messaging\.AzureServiceBus\.CatDeadLetterMetricsOptions\>\)') | Turns the dead letter metric on\. It is off by default, because reading the counts needs the manage right on the namespace\. The metric is the gauge `cat.messaging.dead_letters` on the meter `Cat.Messaging`\. Call it after [AddCatMessagingAzureServiceBus\(this IServiceCollection, Action&lt;CatServiceBusOptions&gt;\)](ServiceCollectionExtensions.AddCatMessagingAzureServiceBus.LQN2F76STM0M5LRLB46ELNO44.md 'Cat\.Messaging\.AzureServiceBus\.Extensions\.ServiceCollectionExtensions\.AddCatMessagingAzureServiceBus\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Action\<Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\>\)')\. |
| [AddCatMessagingAzureServiceBus\(this IServiceCollection, Action&lt;CatServiceBusOptions&gt;\)](ServiceCollectionExtensions.AddCatMessagingAzureServiceBus.LQN2F76STM0M5LRLB46ELNO44.md 'Cat\.Messaging\.AzureServiceBus\.Extensions\.ServiceCollectionExtensions\.AddCatMessagingAzureServiceBus\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Action\<Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\>\)') | Registers the Azure Service Bus transport, and the helper that creates the queues and topics on request\. Nothing is created at startup\. Call [EnsureTopologyAsync\(IEnumerable&lt;Assembly&gt;, CancellationToken\)](ICatServiceBusTopology.EnsureTopologyAsync.BIVLHFG4Y7114YB5ZHKJ7MEBE.md 'Cat\.Messaging\.AzureServiceBus\.ICatServiceBusTopology\.EnsureTopologyAsync\(System\.Collections\.Generic\.IEnumerable\<System\.Reflection\.Assembly\>, System\.Threading\.CancellationToken\)') when you want the entities\. The administration client connects only when it is used, so a service that never creates entities needs no manage right\. |
| [CreateAdministrationClient\(CatServiceBusOptions\)](ServiceCollectionExtensions.CreateAdministrationClient.0YCN7N9WHWU5OQKGKI85TDE7B.md 'Cat\.Messaging\.AzureServiceBus\.Extensions\.ServiceCollectionExtensions\.CreateAdministrationClient\(Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\)') | |
| [CreateClient\(CatServiceBusOptions\)](ServiceCollectionExtensions.CreateClient.UKTT6XTQ0M6FKVSBEOSBCGVR6.md 'Cat\.Messaging\.AzureServiceBus\.Extensions\.ServiceCollectionExtensions\.CreateClient\(Cat\.Messaging\.AzureServiceBus\.CatServiceBusOptions\)') | |
