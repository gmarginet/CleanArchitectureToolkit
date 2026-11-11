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
  
##### >> [Cat\.Messaging\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.Messaging\.AzureServiceBus Namespace](Cat.Messaging.AzureServiceBus.md 'Cat\.Messaging\.AzureServiceBus')

## DeadLetterMetricsService Class

Reads the dead letter counts on an interval and publishes them as the gauge `cat.messaging.dead_letters`
on the meter `Cat.Messaging`\. A dashboard that listens to the meter, such as the Aspire dashboard, shows it\.

```csharp
internal sealed class DeadLetterMetricsService : Microsoft.Extensions.Hosting.BackgroundService
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.Extensions\.Hosting\.BackgroundService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.backgroundservice 'Microsoft\.Extensions\.Hosting\.BackgroundService') → DeadLetterMetricsService

| Constructors | |
| :--- | :--- |
| [DeadLetterMetricsService\(ServiceBusAdministrationClient, IOptions&lt;CatDeadLetterMetricsOptions&gt;, ILogger&lt;DeadLetterMetricsService&gt;\)](DeadLetterMetricsService..ctor.ZTKQ2X9MDTRUKZ4R19BJQR2P9.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\.DeadLetterMetricsService\(Azure\.Messaging\.ServiceBus\.Administration\.ServiceBusAdministrationClient, Microsoft\.Extensions\.Options\.IOptions\<Cat\.Messaging\.AzureServiceBus\.CatDeadLetterMetricsOptions\>, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\>\)') | Creates the service\. |

| Fields | |
| :--- | :--- |
| [MeterName](DeadLetterMetricsService.MeterName.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\.MeterName') | The name of the meter\. |
| [\_admin](DeadLetterMetricsService._admin.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\.\_admin') | |
| [\_counts](DeadLetterMetricsService._counts.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\.\_counts') | |
| [\_logger](DeadLetterMetricsService._logger.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\.\_logger') | |
| [\_meter](DeadLetterMetricsService._meter.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\.\_meter') | |
| [\_options](DeadLetterMetricsService._options.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\.\_options') | |

| Methods | |
| :--- | :--- |
| [Dispose\(\)](DeadLetterMetricsService.Dispose().md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\.Dispose\(\)') | Performs application\-defined tasks associated with freeing, releasing, or resetting unmanaged resources\. |
| [ExecuteAsync\(CancellationToken\)](DeadLetterMetricsService.ExecuteAsync.C25WADBNNBSSJ523RLPGZFS04.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') | This method is called when the [Microsoft\.Extensions\.Hosting\.IHostedService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostedservice 'Microsoft\.Extensions\.Hosting\.IHostedService') starts\. The implementation should return a task that represents the lifetime of the long running operation\(s\) being performed\. |
| [ReadCountsAsync\(CancellationToken\)](DeadLetterMetricsService.ReadCountsAsync.AGIBOLUT3ETH2H04PN9RBLE98.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService\.ReadCountsAsync\(System\.Threading\.CancellationToken\)') | |
