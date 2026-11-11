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
  
##### >> [Cat\.EventProcessor\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.EventProcessor\.AzureServiceBus Namespace](Cat.EventProcessor.AzureServiceBus.md 'Cat\.EventProcessor\.AzureServiceBus')

## ListenerStatus Class

Tracks the state of the listeners, for the health check\.

```csharp
internal sealed class ListenerStatus
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ListenerStatus

| Fields | |
| :--- | :--- |
| [\_isRunning](ListenerStatus._isRunning.md 'Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus\.\_isRunning') | |
| [\_lastError](ListenerStatus._lastError.md 'Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus\.\_lastError') | |
| [\_lock](ListenerStatus._lock.md 'Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus\.\_lock') | |

| Properties | |
| :--- | :--- |
| [Count](ListenerStatus.Count.md 'Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus\.Count') | The number of listeners\. |
| [LastError](ListenerStatus.LastError.md 'Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus\.LastError') | When the last error was reported, if any\. |
| [StoppedCount](ListenerStatus.StoppedCount.md 'Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus\.StoppedCount') | The number of listeners that are not processing\. |

| Methods | |
| :--- | :--- |
| [Add\(Func&lt;bool&gt;\)](ListenerStatus.Add.YEGZ5LWMHUSV6RMOBO6A3PLC5.md 'Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus\.Add\(System\.Func\<bool\>\)') | Adds a listener to watch\. |
| [ReportError\(\)](ListenerStatus.ReportError().md 'Cat\.EventProcessor\.AzureServiceBus\.ListenerStatus\.ReportError\(\)') | Records an error that a listener reported\. |
