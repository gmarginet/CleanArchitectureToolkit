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
  
##### >> [Cat\.Scheduling\.Abstractions Assembly](index.md 'index') >> [Cat\.Scheduling\.Abstractions Namespace](Cat.Scheduling.Abstractions.md 'Cat\.Scheduling\.Abstractions') >> [ICatJobClaimStore Interface](ICatJobClaimStore.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore')

## ICatJobClaimStore\.CompleteAsync\(CatJobClaim, CatJobRunResult, DateTimeOffset, CancellationToken\) Method

Records how a claimed run ended\.

```csharp
System.Threading.Tasks.Task CompleteAsync(Cat.Scheduling.Abstractions.CatJobClaim claim, Cat.Scheduling.Abstractions.CatJobRunResult result, System.DateTimeOffset finishedAt, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Scheduling.Abstractions.ICatJobClaimStore.CompleteAsync(Cat.Scheduling.Abstractions.CatJobClaim,Cat.Scheduling.Abstractions.CatJobRunResult,System.DateTimeOffset,System.Threading.CancellationToken).claim'></a>

`claim` [CatJobClaim](CatJobClaim.md 'Cat\.Scheduling\.Abstractions\.CatJobClaim')

The claim of the run\.

<a name='Cat.Scheduling.Abstractions.ICatJobClaimStore.CompleteAsync(Cat.Scheduling.Abstractions.CatJobClaim,Cat.Scheduling.Abstractions.CatJobRunResult,System.DateTimeOffset,System.Threading.CancellationToken).result'></a>

`result` [CatJobRunResult](CatJobRunResult.md 'Cat\.Scheduling\.Abstractions\.CatJobRunResult')

The outcome of the run\.

<a name='Cat.Scheduling.Abstractions.ICatJobClaimStore.CompleteAsync(Cat.Scheduling.Abstractions.CatJobClaim,Cat.Scheduling.Abstractions.CatJobRunResult,System.DateTimeOffset,System.Threading.CancellationToken).finishedAt'></a>

`finishedAt` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

When the run ended\.

<a name='Cat.Scheduling.Abstractions.ICatJobClaimStore.CompleteAsync(Cat.Scheduling.Abstractions.CatJobClaim,Cat.Scheduling.Abstractions.CatJobRunResult,System.DateTimeOffset,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that completes when the outcome is recorded\.