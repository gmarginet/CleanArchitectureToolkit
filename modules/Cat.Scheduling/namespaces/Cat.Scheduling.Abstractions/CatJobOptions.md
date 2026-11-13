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
  
##### >> [Cat\.Scheduling\.Abstractions Assembly](index.md 'index') >> [Cat\.Scheduling\.Abstractions Namespace](Cat.Scheduling.Abstractions.md 'Cat\.Scheduling\.Abstractions')

## CatJobOptions Class

The settings of one scheduled job\. The code sets them when it declares the job\.
The configuration section `CatScheduling:Jobs:<job name>` wins, so whoever runs the service
can change a cron expression or switch a job off per environment without a build\.

```csharp
public class CatJobOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatJobOptions

| Properties | |
| :--- | :--- |
| [AllowOverlap](CatJobOptions.AllowOverlap.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.AllowOverlap') | Lets a new run start while the previous run is still busy\. The default is `false`: the new run is skipped and a warning is logged\. |
| [Cron](CatJobOptions.Cron.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.Cron') | The cron expression\. Five fields \(minute, hour, day of month, month, day of week\) or six when the first field holds seconds\. |
| [DeadAfter](CatJobOptions.DeadAfter.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.DeadAfter') | The time after which a run that never finished counts as dead, for example because its instance crashed\. A dead run no longer blocks the next one\. The default is one hour\. |
| [Enabled](CatJobOptions.Enabled.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.Enabled') | Switches the job off when `false`\. A job that is off never runs, but [ICatJobRunner](ICatJobRunner.md 'Cat\.Scheduling\.Abstractions\.ICatJobRunner') can still run it at once\. |
| [GrowingRetryDelay](CatJobOptions.GrowingRetryDelay.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.GrowingRetryDelay') | Doubles the wait with every retry when `true`\. The default is `false`\. |
| [MaxRetries](CatJobOptions.MaxRetries.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.MaxRetries') | The number of times a failed run is tried again\. The default is 0: a failed run waits for the next due time\. A retry is a new attempt for the same due time\. It uses the same claim, so two instances never retry the same job together\. |
| [MissedRuns](CatJobOptions.MissedRuns.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.MissedRuns') | What the job does at startup when a due time passed\. The default is [RunOnce](CatMissedRunBehavior.md#Cat.Scheduling.Abstractions.CatMissedRunBehavior.RunOnce 'Cat\.Scheduling\.Abstractions\.CatMissedRunBehavior\.RunOnce')\. The service request of the job must be safe to run more than once\. |
| [RetryDelay](CatJobOptions.RetryDelay.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.RetryDelay') | The wait before a retry\. The default is 30 seconds\. |
| [TimeZoneId](CatJobOptions.TimeZoneId.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions\.TimeZoneId') | The ID of the time zone the cron expression is read in, as [System\.TimeZoneInfo\.FindSystemTimeZoneById\(System\.String\)](https://learn.microsoft.com/en-us/dotnet/api/system.timezoneinfo.findsystemtimezonebyid#system-timezoneinfo-findsystemtimezonebyid(system-string) 'System\.TimeZoneInfo\.FindSystemTimeZoneById\(System\.String\)') knows it\. The default is `UTC`\. When daylight saving makes a local time happen twice the job runs once, and when a local time does not happen the job runs at the first moment after the gap\. |
