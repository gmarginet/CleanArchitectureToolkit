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
  
##### >> [Cat\.Messaging\.AzureServiceBus Assembly](index.md 'index') >> [Cat\.Messaging\.AzureServiceBus Namespace](Cat.Messaging.AzureServiceBus.md 'Cat\.Messaging\.AzureServiceBus') >> [DeadLetterMetricsService Class](DeadLetterMetricsService.md 'Cat\.Messaging\.AzureServiceBus\.DeadLetterMetricsService')

## DeadLetterMetricsService\.ExecuteAsync\(CancellationToken\) Method

This method is called when the [Microsoft\.Extensions\.Hosting\.IHostedService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostedservice 'Microsoft\.Extensions\.Hosting\.IHostedService') starts\. The implementation should return a task that represents
the lifetime of the long running operation\(s\) being performed\.

```csharp
protected override System.Threading.Tasks.Task ExecuteAsync(System.Threading.CancellationToken stoppingToken);
```
#### Parameters

<a name='Cat.Messaging.AzureServiceBus.DeadLetterMetricsService.ExecuteAsync(System.Threading.CancellationToken).stoppingToken'></a>

`stoppingToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Triggered when [Microsoft\.Extensions\.Hosting\.IHostedService\.StopAsync\(System\.Threading\.CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostedservice.stopasync#microsoft-extensions-hosting-ihostedservice-stopasync(system-threading-cancellationtoken) 'Microsoft\.Extensions\.Hosting\.IHostedService\.StopAsync\(System\.Threading\.CancellationToken\)') is called\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A [System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task') that represents the long running operations\.

### Remarks
See [Worker Services in \.NET](https://learn.microsoft.com/dotnet/core/extensions/workers 'https://learn\.microsoft\.com/dotnet/core/extensions/workers') for implementation guidelines\.