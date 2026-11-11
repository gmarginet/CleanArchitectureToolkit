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

## CatDeadLetterMetricsOptions Class

Settings of the dead letter metric\. The metric is off until the developer adds it,
because reading the counts needs the manage right on the namespace\.

```csharp
public class CatDeadLetterMetricsOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatDeadLetterMetricsOptions

| Properties | |
| :--- | :--- |
| [PollInterval](CatDeadLetterMetricsOptions.PollInterval.md 'Cat\.Messaging\.AzureServiceBus\.CatDeadLetterMetricsOptions\.PollInterval') | How often the counts are read\. The default is 60 seconds\. |
| [Queues](CatDeadLetterMetricsOptions.Queues.md 'Cat\.Messaging\.AzureServiceBus\.CatDeadLetterMetricsOptions\.Queues') | The queues to watch\. |
| [Subscriptions](CatDeadLetterMetricsOptions.Subscriptions.md 'Cat\.Messaging\.AzureServiceBus\.CatDeadLetterMetricsOptions\.Subscriptions') | The subscriptions to watch, as pairs of a topic name and a subscription name\. |
