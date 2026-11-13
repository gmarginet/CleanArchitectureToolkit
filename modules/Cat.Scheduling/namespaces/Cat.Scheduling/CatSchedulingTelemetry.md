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

## CatSchedulingTelemetry Class

The trace source and the metrics of the scheduler\.

```csharp
public static class CatSchedulingTelemetry
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSchedulingTelemetry

| Constructors | |
| :--- | :--- |
| [CatSchedulingTelemetry\(\)](CatSchedulingTelemetry.CatSchedulingTelemetry().md 'Cat\.Scheduling\.CatSchedulingTelemetry\.CatSchedulingTelemetry\(\)') | |

| Fields | |
| :--- | :--- |
| [ActivitySource](CatSchedulingTelemetry.ActivitySource.md 'Cat\.Scheduling\.CatSchedulingTelemetry\.ActivitySource') | |
| [LastRunGauge](CatSchedulingTelemetry.LastRunGauge.md 'Cat\.Scheduling\.CatSchedulingTelemetry\.LastRunGauge') | |
| [LastRuns](CatSchedulingTelemetry.LastRuns.md 'Cat\.Scheduling\.CatSchedulingTelemetry\.LastRuns') | |
| [Meter](CatSchedulingTelemetry.Meter.md 'Cat\.Scheduling\.CatSchedulingTelemetry\.Meter') | |
| [Runs](CatSchedulingTelemetry.Runs.md 'Cat\.Scheduling\.CatSchedulingTelemetry\.Runs') | |
| [SourceName](CatSchedulingTelemetry.SourceName.md 'Cat\.Scheduling\.CatSchedulingTelemetry\.SourceName') | The name of the trace source and the meter\. Add it to your OpenTelemetry setup to see the runs\. |

| Methods | |
| :--- | :--- |
| [ObserveLastRuns\(\)](CatSchedulingTelemetry.ObserveLastRuns().md 'Cat\.Scheduling\.CatSchedulingTelemetry\.ObserveLastRuns\(\)') | |
| [RecordRun\(string, CatJobRunStatus, DateTimeOffset\)](CatSchedulingTelemetry.RecordRun.RVXU10Q8PZWDQTT3ZIEM0F9DC.md 'Cat\.Scheduling\.CatSchedulingTelemetry\.RecordRun\(string, Cat\.Scheduling\.Abstractions\.CatJobRunStatus, System\.DateTimeOffset\)') | |
