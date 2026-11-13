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

## CatJobRunner Class

Default [ICatJobRunner](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobRunner.md 'Cat\.Scheduling\.Abstractions\.ICatJobRunner')\. The scheduler uses it for every run too, so a run from a development endpoint
behaves like a run at a due time\.

```csharp
internal sealed class CatJobRunner : Cat.Scheduling.Abstractions.ICatJobRunner
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatJobRunner

Implements [ICatJobRunner](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobRunner.md 'Cat\.Scheduling\.Abstractions\.ICatJobRunner')

| Constructors | |
| :--- | :--- |
| [CatJobRunner\(IServiceScopeFactory, ICatJobRegistry, CatSchedulerSettings, TimeProvider, ILogger&lt;CatJobRunner&gt;\)](CatJobRunner..ctor.CWP2T6NVTJXR72X28KA91XX36.md 'Cat\.Scheduling\.CatJobRunner\.CatJobRunner\(Microsoft\.Extensions\.DependencyInjection\.IServiceScopeFactory, Cat\.Scheduling\.Abstractions\.ICatJobRegistry, Cat\.Scheduling\.CatSchedulerSettings, System\.TimeProvider, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.Scheduling\.CatJobRunner\>\)') | Creates the runner\. |

| Fields | |
| :--- | :--- |
| [\_logger](CatJobRunner._logger.md 'Cat\.Scheduling\.CatJobRunner\.\_logger') | |
| [\_registry](CatJobRunner._registry.md 'Cat\.Scheduling\.CatJobRunner\.\_registry') | |
| [\_scopeFactory](CatJobRunner._scopeFactory.md 'Cat\.Scheduling\.CatJobRunner\.\_scopeFactory') | |
| [\_settings](CatJobRunner._settings.md 'Cat\.Scheduling\.CatJobRunner\.\_settings') | |
| [\_timeProvider](CatJobRunner._timeProvider.md 'Cat\.Scheduling\.CatJobRunner\.\_timeProvider') | |

| Methods | |
| :--- | :--- |
| [AttemptAsync\(CatJobRegistration, int, CancellationToken\)](CatJobRunner.AttemptAsync.Q6NQRBU2NFY2YNW8YZHG2NA11.md 'Cat\.Scheduling\.CatJobRunner\.AttemptAsync\(Cat\.Scheduling\.Abstractions\.CatJobRegistration, int, System\.Threading\.CancellationToken\)') | |
| [RunAsync\(CatJobRegistration, CancellationToken\)](CatJobRunner.RunAsync.md#Cat.Scheduling.CatJobRunner.RunAsync(Cat.Scheduling.Abstractions.CatJobRegistration,System.Threading.CancellationToken) 'Cat\.Scheduling\.CatJobRunner\.RunAsync\(Cat\.Scheduling\.Abstractions\.CatJobRegistration, System\.Threading\.CancellationToken\)') | Runs a job, with its retries, and traces and counts the run\. |
| [RunAsync\(string, CancellationToken\)](CatJobRunner.RunAsync.md#Cat.Scheduling.CatJobRunner.RunAsync(string,System.Threading.CancellationToken) 'Cat\.Scheduling\.CatJobRunner\.RunAsync\(string, System\.Threading\.CancellationToken\)') | Runs the job and waits for the outcome\. A job that is switched off can be run too\. |
