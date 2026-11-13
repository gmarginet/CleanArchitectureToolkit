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
  
##### >> [Cat\.Scheduling Assembly](index.md 'index')

## Cat\.Scheduling Namespace

The scheduler\. It declares the jobs of a service, waits for their due times with a cron parser, claims every run
so only one instance runs it, and sends the service request of the job as a system user\. It also holds the claim store in memory\.

| Classes | |
| :--- | :--- |
| [CatJobRunner](CatJobRunner.md 'Cat\.Scheduling\.CatJobRunner') | Default [ICatJobRunner](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobRunner.md 'Cat\.Scheduling\.Abstractions\.ICatJobRunner')\. The scheduler uses it for every run too, so a run from a development endpoint behaves like a run at a due time\. |
| [CatSchedulerBuilder](CatSchedulerBuilder.md 'Cat\.Scheduling\.CatSchedulerBuilder') | Declares the jobs of a service\. You get one from `AddCatScheduling`\. |
| [CatSchedulerService](CatSchedulerService.md 'Cat\.Scheduling\.CatSchedulerService') | Hosted service that runs one loop per enabled job\. A loop waits for the next due time, claims it and runs the job\. |
| [CatSchedulerSettings](CatSchedulerSettings.md 'Cat\.Scheduling\.CatSchedulerSettings') | The settings that are not per job\. |
| [CatSchedulingTelemetry](CatSchedulingTelemetry.md 'Cat\.Scheduling\.CatSchedulingTelemetry') | The trace source and the metrics of the scheduler\. |
| [CronSchedule](CronSchedule.md 'Cat\.Scheduling\.CronSchedule') | The due times of a job, worked out from its cron expression and time zone\. |
| [InMemoryJobClaimStore](InMemoryJobClaimStore.md 'Cat\.Scheduling\.InMemoryJobClaimStore') | [ICatJobClaimStore](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobClaimStore.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore') in memory\. It is right for a service with one instance\.             The claims are gone after a restart, so a missed run cannot be found at startup\. |
| [InMemoryJobClaimStore\.Run](InMemoryJobClaimStore.Run.md 'Cat\.Scheduling\.InMemoryJobClaimStore\.Run') | |
| [JobRegistry](JobRegistry.md 'Cat\.Scheduling\.JobRegistry') | Default [ICatJobRegistry](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobRegistry.md 'Cat\.Scheduling\.Abstractions\.ICatJobRegistry')\. |
| [TimeProviderDelay](TimeProviderDelay.md 'Cat\.Scheduling\.TimeProviderDelay') | Waits on a [System\.TimeProvider](https://learn.microsoft.com/en-us/dotnet/api/system.timeprovider 'System\.TimeProvider'), so a test with a fake clock can move time forward\. |
