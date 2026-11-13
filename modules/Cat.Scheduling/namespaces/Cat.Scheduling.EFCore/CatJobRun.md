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
  
##### >> [Cat\.Scheduling\.EFCore Assembly](index.md 'index') >> [Cat\.Scheduling\.EFCore Namespace](Cat.Scheduling.EFCore.md 'Cat\.Scheduling\.EFCore')

## CatJobRun Class

One row of the job run table: the claim and the outcome of a run of a job at a due time\.
The job name and the due time together are the key, so a second claim for the same due time fails\.
All times are UTC\.

```csharp
public class CatJobRun
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatJobRun

| Properties | |
| :--- | :--- |
| [Attempts](CatJobRun.Attempts.md 'Cat\.Scheduling\.EFCore\.CatJobRun\.Attempts') | The number of times the service request ran, with the retries\. |
| [DueTime](CatJobRun.DueTime.md 'Cat\.Scheduling\.EFCore\.CatJobRun\.DueTime') | The due time the run is for\. |
| [ErrorCode](CatJobRun.ErrorCode.md 'Cat\.Scheduling\.EFCore\.CatJobRun\.ErrorCode') | The code of the first error of a failed run\. `null` when it did not fail\. |
| [FinishedAt](CatJobRun.FinishedAt.md 'Cat\.Scheduling\.EFCore\.CatJobRun\.FinishedAt') | When the run ended\. `null` while it runs\. |
| [JobName](CatJobRun.JobName.md 'Cat\.Scheduling\.EFCore\.CatJobRun\.JobName') | The name of the job\. |
| [StartedAt](CatJobRun.StartedAt.md 'Cat\.Scheduling\.EFCore\.CatJobRun\.StartedAt') | When the run started\. |
| [Status](CatJobRun.Status.md 'Cat\.Scheduling\.EFCore\.CatJobRun\.Status') | Running, succeeded or failed\. |
