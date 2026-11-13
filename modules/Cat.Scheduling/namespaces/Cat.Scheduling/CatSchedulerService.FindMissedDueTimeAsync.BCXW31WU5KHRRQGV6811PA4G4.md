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

## CatSchedulerService\.FindMissedDueTimeAsync\(CatJobRegistration, CronSchedule, DateTimeOffset, CancellationToken\) Method

```csharp
private System.Threading.Tasks.Task<System.Nullable<System.DateTimeOffset>> FindMissedDueTimeAsync(Cat.Scheduling.Abstractions.CatJobRegistration job, Cat.Scheduling.CronSchedule schedule, System.DateTimeOffset now, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Scheduling.CatSchedulerService.FindMissedDueTimeAsync(Cat.Scheduling.Abstractions.CatJobRegistration,Cat.Scheduling.CronSchedule,System.DateTimeOffset,System.Threading.CancellationToken).job'></a>

`job` [CatJobRegistration](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobRegistration.md 'Cat\.Scheduling\.Abstractions\.CatJobRegistration')

<a name='Cat.Scheduling.CatSchedulerService.FindMissedDueTimeAsync(Cat.Scheduling.Abstractions.CatJobRegistration,Cat.Scheduling.CronSchedule,System.DateTimeOffset,System.Threading.CancellationToken).schedule'></a>

`schedule` [CronSchedule](CronSchedule.md 'Cat\.Scheduling\.CronSchedule')

<a name='Cat.Scheduling.CatSchedulerService.FindMissedDueTimeAsync(Cat.Scheduling.Abstractions.CatJobRegistration,Cat.Scheduling.CronSchedule,System.DateTimeOffset,System.Threading.CancellationToken).now'></a>

`now` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

<a name='Cat.Scheduling.CatSchedulerService.FindMissedDueTimeAsync(Cat.Scheduling.Abstractions.CatJobRegistration,Cat.Scheduling.CronSchedule,System.DateTimeOffset,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')