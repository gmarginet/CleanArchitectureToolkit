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
  
##### >> [Cat\.Scheduling Assembly](index.md 'index') >> [Cat\.Scheduling\.Extensions Namespace](Cat.Scheduling.Extensions.md 'Cat\.Scheduling\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the scheduler\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Fields | |
| :--- | :--- |
| [ConfigurationSectionName](ServiceCollectionExtensions.ConfigurationSectionName.md 'Cat\.Scheduling\.Extensions\.ServiceCollectionExtensions\.ConfigurationSectionName') | The configuration section that holds the settings per job, in the form `CatScheduling:Jobs:clean-up-order-counters:Cron`\. |

| Methods | |
| :--- | :--- |
| [AddCatScheduling\(this IServiceCollection, IConfiguration, Action&lt;CatSchedulerBuilder&gt;\)](ServiceCollectionExtensions.AddCatScheduling.MNVW197CZUUNU0H4L6NWFQM2B.md 'Cat\.Scheduling\.Extensions\.ServiceCollectionExtensions\.AddCatScheduling\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, Microsoft\.Extensions\.Configuration\.IConfiguration, System\.Action\<Cat\.Scheduling\.CatSchedulerBuilder\>\)') | Registers the scheduler, the jobs the service declares and the runner\. The scheduler starts with the host\. The settings per job come from the code\. The configuration wins, so whoever runs the service can change a cron expression or switch a job off without a build\. A cron expression or a time zone that is not valid throws here, so the service fails at startup\. Register the service request module too\. The claim store is in memory unless you register another one, such as the EF Core store of `Cat.Scheduling.EFCore`\. |
