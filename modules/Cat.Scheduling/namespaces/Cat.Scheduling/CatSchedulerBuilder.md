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

## CatSchedulerBuilder Class

Declares the jobs of a service\. You get one from `AddCatScheduling`\.

```csharp
public sealed class CatSchedulerBuilder
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSchedulerBuilder

| Fields | |
| :--- | :--- |
| [DefaultSystemUserName](CatSchedulerBuilder.DefaultSystemUserName.md 'Cat\.Scheduling\.CatSchedulerBuilder\.DefaultSystemUserName') | The default name of the system user a job runs as\. |
| [\_registrations](CatSchedulerBuilder._registrations.md 'Cat\.Scheduling\.CatSchedulerBuilder\.\_registrations') | |

| Properties | |
| :--- | :--- |
| [Registrations](CatSchedulerBuilder.Registrations.md 'Cat\.Scheduling\.CatSchedulerBuilder\.Registrations') | |
| [SystemUserName](CatSchedulerBuilder.SystemUserName.md 'Cat\.Scheduling\.CatSchedulerBuilder\.SystemUserName') | |

| Methods | |
| :--- | :--- |
| [Job\(string, string, Func&lt;ICatServiceRequest&gt;, Action&lt;CatJobOptions&gt;\)](CatSchedulerBuilder.Job.md#Cat.Scheduling.CatSchedulerBuilder.Job(string,string,System.Func_Cat.ServiceRequests.Abstractions.ICatServiceRequest_,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_) 'Cat\.Scheduling\.CatSchedulerBuilder\.Job\(string, string, System\.Func\<Cat\.ServiceRequests\.Abstractions\.ICatServiceRequest\>, System\.Action\<Cat\.Scheduling\.Abstractions\.CatJobOptions\>\)') | Declares a job that sends a service request built by a factory, for a request with data\. |
| [Job&lt;TRequest&gt;\(string, string, Action&lt;CatJobOptions&gt;\)](CatSchedulerBuilder.Job.md#Cat.Scheduling.CatSchedulerBuilder.Job_TRequest_(string,string,System.Action_Cat.Scheduling.Abstractions.CatJobOptions_) 'Cat\.Scheduling\.CatSchedulerBuilder\.Job\<TRequest\>\(string, string, System\.Action\<Cat\.Scheduling\.Abstractions\.CatJobOptions\>\)') | Declares a job that sends a service request with a parameterless constructor, such as one without data\. |
| [RunAs\(string\)](CatSchedulerBuilder.RunAs.UCXM2LF3HCK6CO1308R8YWL34.md 'Cat\.Scheduling\.CatSchedulerBuilder\.RunAs\(string\)') | Sets the name of the system user every job runs as, so `ICatUser` always has a value\. Use the name of the service, such as `orders`\. The default is [DefaultSystemUserName](CatSchedulerBuilder.DefaultSystemUserName.md 'Cat\.Scheduling\.CatSchedulerBuilder\.DefaultSystemUserName')\. |
