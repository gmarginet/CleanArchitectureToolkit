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
  
##### >> [Cat\.Scheduling Assembly](index.md 'index') >> [Cat\.Scheduling Namespace](Cat.Scheduling.md 'Cat\.Scheduling')

## CatSchedulerService Class

Hosted service that runs one loop per enabled job\. A loop waits for the next due time, claims it and runs the job\.

```csharp
internal sealed class CatSchedulerService : Microsoft.Extensions.Hosting.BackgroundService
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.Extensions\.Hosting\.BackgroundService](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.backgroundservice 'Microsoft\.Extensions\.Hosting\.BackgroundService') → CatSchedulerService

| Constructors | |
| :--- | :--- |
| [CatSchedulerService\(ICatJobRegistry, ICatJobClaimStore, CatJobRunner, TimeProvider, ILogger&lt;CatSchedulerService&gt;\)](CatSchedulerService..ctor.6JA50GQ4ZVC14QQ1FAD72ZYN2.md 'Cat\.Scheduling\.CatSchedulerService\.CatSchedulerService\(Cat\.Scheduling\.Abstractions\.ICatJobRegistry, Cat\.Scheduling\.Abstractions\.ICatJobClaimStore, Cat\.Scheduling\.CatJobRunner, System\.TimeProvider, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Scheduling\.CatSchedulerService\>\)') | Creates the service\. |

| Fields | |
| :--- | :--- |
| [MaximumMissedCount](CatSchedulerService.MaximumMissedCount.md 'Cat\.Scheduling\.CatSchedulerService\.MaximumMissedCount') | |
| [\_logger](CatSchedulerService._logger.md 'Cat\.Scheduling\.CatSchedulerService\.\_logger') | |
| [\_registry](CatSchedulerService._registry.md 'Cat\.Scheduling\.CatSchedulerService\.\_registry') | |
| [\_runner](CatSchedulerService._runner.md 'Cat\.Scheduling\.CatSchedulerService\.\_runner') | |
| [\_store](CatSchedulerService._store.md 'Cat\.Scheduling\.CatSchedulerService\.\_store') | |
| [\_timeProvider](CatSchedulerService._timeProvider.md 'Cat\.Scheduling\.CatSchedulerService\.\_timeProvider') | |

| Methods | |
| :--- | :--- |
| [ExecuteAsync\(CancellationToken\)](CatSchedulerService.ExecuteAsync.7O067T0OUWE9GZVMCP1J1D9X9.md 'Cat\.Scheduling\.CatSchedulerService\.ExecuteAsync\(System\.Threading\.CancellationToken\)') | |
| [ExecuteDueAsync\(CatJobRegistration, DateTimeOffset, CancellationToken\)](CatSchedulerService.ExecuteDueAsync.RZNSSOFO1QAWCDS6KOTE9YEY9.md 'Cat\.Scheduling\.CatSchedulerService\.ExecuteDueAsync\(Cat\.Scheduling\.Abstractions\.CatJobRegistration, System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | |
| [ExecuteSafelyAsync\(CatJobRegistration, DateTimeOffset, CancellationToken\)](CatSchedulerService.ExecuteSafelyAsync.FPIFLCV37S8EOOE9NOM1Z7Z6A.md 'Cat\.Scheduling\.CatSchedulerService\.ExecuteSafelyAsync\(Cat\.Scheduling\.Abstractions\.CatJobRegistration, System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | |
| [FindMissedDueTimeAsync\(CatJobRegistration, CronSchedule, DateTimeOffset, CancellationToken\)](CatSchedulerService.FindMissedDueTimeAsync.BCXW31WU5KHRRQGV6811PA4G4.md 'Cat\.Scheduling\.CatSchedulerService\.FindMissedDueTimeAsync\(Cat\.Scheduling\.Abstractions\.CatJobRegistration, Cat\.Scheduling\.CronSchedule, System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | |
| [RunLoopAsync\(CatJobRegistration, CronSchedule, CancellationToken\)](CatSchedulerService.RunLoopAsync.8L5VG8R7CATMKUGIFT3Q55VI7.md 'Cat\.Scheduling\.CatSchedulerService\.RunLoopAsync\(Cat\.Scheduling\.Abstractions\.CatJobRegistration, Cat\.Scheduling\.CronSchedule, System\.Threading\.CancellationToken\)') | |
