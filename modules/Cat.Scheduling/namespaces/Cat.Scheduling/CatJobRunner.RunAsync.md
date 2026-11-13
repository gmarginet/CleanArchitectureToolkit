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
  
##### >> [Cat\.Scheduling Assembly](index.md 'index') >> [Cat\.Scheduling Namespace](Cat.Scheduling.md 'Cat\.Scheduling') >> [CatJobRunner Class](CatJobRunner.md 'Cat\.Scheduling\.CatJobRunner')

## CatJobRunner\.RunAsync Method

| Overloads | |
| :--- | :--- |
| [RunAsync\(CatJobRegistration, CancellationToken\)](CatJobRunner.RunAsync.md#Cat.Scheduling.CatJobRunner.RunAsync(Cat.Scheduling.Abstractions.CatJobRegistration,System.Threading.CancellationToken) 'Cat\.Scheduling\.CatJobRunner\.RunAsync\(Cat\.Scheduling\.Abstractions\.CatJobRegistration, System\.Threading\.CancellationToken\)') | Runs a job, with its retries, and traces and counts the run\. |
| [RunAsync\(string, CancellationToken\)](CatJobRunner.RunAsync.md#Cat.Scheduling.CatJobRunner.RunAsync(string,System.Threading.CancellationToken) 'Cat\.Scheduling\.CatJobRunner\.RunAsync\(string, System\.Threading\.CancellationToken\)') | Runs the job and waits for the outcome\. A job that is switched off can be run too\. |

<a name='Cat.Scheduling.CatJobRunner.RunAsync(Cat.Scheduling.Abstractions.CatJobRegistration,System.Threading.CancellationToken)'></a>

## CatJobRunner\.RunAsync\(CatJobRegistration, CancellationToken\) Method

Runs a job, with its retries, and traces and counts the run\.

```csharp
public System.Threading.Tasks.Task<Cat.Scheduling.Abstractions.CatJobRunResult> RunAsync(Cat.Scheduling.Abstractions.CatJobRegistration job, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Cat.Scheduling.CatJobRunner.RunAsync(Cat.Scheduling.Abstractions.CatJobRegistration,System.Threading.CancellationToken).job'></a>

`job` [CatJobRegistration](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobRegistration.md 'Cat\.Scheduling\.Abstractions\.CatJobRegistration')

The job to run\.

<a name='Cat.Scheduling.CatJobRunner.RunAsync(Cat.Scheduling.Abstractions.CatJobRegistration,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CatJobRunResult](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobRunResult.md 'Cat\.Scheduling\.Abstractions\.CatJobRunResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The outcome after the last retry\.

<a name='Cat.Scheduling.CatJobRunner.RunAsync(string,System.Threading.CancellationToken)'></a>

## CatJobRunner\.RunAsync\(string, CancellationToken\) Method

Runs the job and waits for the outcome\. A job that is switched off can be run too\.

```csharp
public System.Threading.Tasks.Task<Cat.Scheduling.Abstractions.CatJobRunResult> RunAsync(string jobName, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Scheduling.CatJobRunner.RunAsync(string,System.Threading.CancellationToken).jobName'></a>

`jobName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the job\.

<a name='Cat.Scheduling.CatJobRunner.RunAsync(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

Implements [RunAsync\(string, CancellationToken\)](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobRunner.RunAsync.0EKJBOM11MQCEYU81GJIFI5I8.md 'Cat\.Scheduling\.Abstractions\.ICatJobRunner\.RunAsync\(System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CatJobRunResult](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobRunResult.md 'Cat\.Scheduling\.Abstractions\.CatJobRunResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The outcome after the last retry\.

#### Exceptions

[System\.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception 'System\.ArgumentException')  
There is no job with that name\.