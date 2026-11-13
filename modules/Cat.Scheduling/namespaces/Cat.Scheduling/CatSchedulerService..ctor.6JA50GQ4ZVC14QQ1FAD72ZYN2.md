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
  
##### >> [Cat\.Scheduling Assembly](index.md 'index') >> [Cat\.Scheduling Namespace](Cat.Scheduling.md 'Cat\.Scheduling') >> [CatSchedulerService Class](CatSchedulerService.md 'Cat\.Scheduling\.CatSchedulerService')

## CatSchedulerService\(ICatJobRegistry, ICatJobClaimStore, CatJobRunner, TimeProvider, ILogger\<CatSchedulerService\>\) Constructor

Creates the service\.

```csharp
public CatSchedulerService(Cat.Scheduling.Abstractions.ICatJobRegistry registry, Cat.Scheduling.Abstractions.ICatJobClaimStore store, Cat.Scheduling.CatJobRunner runner, System.TimeProvider timeProvider, Microsoft.Extensions.Logging.ILogger<Cat.Scheduling.CatSchedulerService> logger);
```
#### Parameters

<a name='Cat.Scheduling.CatSchedulerService.CatSchedulerService(Cat.Scheduling.Abstractions.ICatJobRegistry,Cat.Scheduling.Abstractions.ICatJobClaimStore,Cat.Scheduling.CatJobRunner,System.TimeProvider,Microsoft.Extensions.Logging.ILogger_Cat.Scheduling.CatSchedulerService_).registry'></a>

`registry` [ICatJobRegistry](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobRegistry.md 'Cat\.Scheduling\.Abstractions\.ICatJobRegistry')

Holds the declared jobs\.

<a name='Cat.Scheduling.CatSchedulerService.CatSchedulerService(Cat.Scheduling.Abstractions.ICatJobRegistry,Cat.Scheduling.Abstractions.ICatJobClaimStore,Cat.Scheduling.CatJobRunner,System.TimeProvider,Microsoft.Extensions.Logging.ILogger_Cat.Scheduling.CatSchedulerService_).store'></a>

`store` [ICatJobClaimStore](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobClaimStore.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore')

Decides which instance runs a job at a due time\.

<a name='Cat.Scheduling.CatSchedulerService.CatSchedulerService(Cat.Scheduling.Abstractions.ICatJobRegistry,Cat.Scheduling.Abstractions.ICatJobClaimStore,Cat.Scheduling.CatJobRunner,System.TimeProvider,Microsoft.Extensions.Logging.ILogger_Cat.Scheduling.CatSchedulerService_).runner'></a>

`runner` [CatJobRunner](CatJobRunner.md 'Cat\.Scheduling\.CatJobRunner')

Runs a job\.

<a name='Cat.Scheduling.CatSchedulerService.CatSchedulerService(Cat.Scheduling.Abstractions.ICatJobRegistry,Cat.Scheduling.Abstractions.ICatJobClaimStore,Cat.Scheduling.CatJobRunner,System.TimeProvider,Microsoft.Extensions.Logging.ILogger_Cat.Scheduling.CatSchedulerService_).timeProvider'></a>

`timeProvider` [System\.TimeProvider](https://learn.microsoft.com/en-us/dotnet/api/system.timeprovider 'System\.TimeProvider')

The clock\.

<a name='Cat.Scheduling.CatSchedulerService.CatSchedulerService(Cat.Scheduling.Abstractions.ICatJobRegistry,Cat.Scheduling.Abstractions.ICatJobClaimStore,Cat.Scheduling.CatJobRunner,System.TimeProvider,Microsoft.Extensions.Logging.ILogger_Cat.Scheduling.CatSchedulerService_).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[CatSchedulerService](CatSchedulerService.md 'Cat\.Scheduling\.CatSchedulerService')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

Logs skipped runs and failures of the scheduler itself\.