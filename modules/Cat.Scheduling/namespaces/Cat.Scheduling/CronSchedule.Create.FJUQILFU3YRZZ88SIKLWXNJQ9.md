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
  
##### >> [Cat\.Scheduling Assembly](index.md 'index') >> [Cat\.Scheduling Namespace](Cat.Scheduling.md 'Cat\.Scheduling') >> [CronSchedule Class](CronSchedule.md 'Cat\.Scheduling\.CronSchedule')

## CronSchedule\.Create\(string, CatJobOptions\) Method

Reads the cron expression and the time zone of a job\.

```csharp
public static Cat.Scheduling.CronSchedule Create(string jobName, Cat.Scheduling.Abstractions.CatJobOptions options);
```
#### Parameters

<a name='Cat.Scheduling.CronSchedule.Create(string,Cat.Scheduling.Abstractions.CatJobOptions).jobName'></a>

`jobName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the job, for the message of the exception\.

<a name='Cat.Scheduling.CronSchedule.Create(string,Cat.Scheduling.Abstractions.CatJobOptions).options'></a>

`options` [CatJobOptions](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobOptions.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions')

The settings of the job\.

#### Returns
[CronSchedule](CronSchedule.md 'Cat\.Scheduling\.CronSchedule')  
The schedule\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
The cron expression or the time zone is not valid\.