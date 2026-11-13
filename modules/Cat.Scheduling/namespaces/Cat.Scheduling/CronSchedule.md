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

## CronSchedule Class

The due times of a job, worked out from its cron expression and time zone\.

```csharp
internal sealed class CronSchedule
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CronSchedule

| Constructors | |
| :--- | :--- |
| [CronSchedule\(CronExpression, TimeZoneInfo\)](CronSchedule..ctor.Y409YI7YRK80PLC8FE23P4OND.md 'Cat\.Scheduling\.CronSchedule\.CronSchedule\(CronExpression, System\.TimeZoneInfo\)') | |

| Fields | |
| :--- | :--- |
| [\_expression](CronSchedule._expression.md 'Cat\.Scheduling\.CronSchedule\.\_expression') | |
| [\_zone](CronSchedule._zone.md 'Cat\.Scheduling\.CronSchedule\.\_zone') | |

| Methods | |
| :--- | :--- |
| [Create\(string, CatJobOptions\)](CronSchedule.Create.FJUQILFU3YRZZ88SIKLWXNJQ9.md 'Cat\.Scheduling\.CronSchedule\.Create\(string, Cat\.Scheduling\.Abstractions\.CatJobOptions\)') | Reads the cron expression and the time zone of a job\. |
| [GetNext\(DateTimeOffset\)](CronSchedule.GetNext.MHYGPN6AX0PEEFC9CDPBGPUME.md 'Cat\.Scheduling\.CronSchedule\.GetNext\(System\.DateTimeOffset\)') | Gets the first due time after a moment\. |
