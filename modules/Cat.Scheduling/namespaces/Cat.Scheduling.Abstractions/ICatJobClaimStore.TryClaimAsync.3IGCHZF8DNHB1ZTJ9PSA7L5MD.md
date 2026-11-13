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

## ICatJobClaimStore\.TryClaimAsync\(string, DateTimeOffset, DateTimeOffset, bool, TimeSpan, CancellationToken\) Method

Tries to claim the job for a due time\. Exactly one caller gets [Claimed](CatJobClaimStatus.md#Cat.Scheduling.Abstractions.CatJobClaimStatus.Claimed 'Cat\.Scheduling\.Abstractions\.CatJobClaimStatus\.Claimed') for the same job and due time\.

```csharp
System.Threading.Tasks.Task<Cat.Scheduling.Abstractions.CatJobClaimResult> TryClaimAsync(string jobName, System.DateTimeOffset dueTime, System.DateTimeOffset now, bool allowOverlap, System.TimeSpan deadAfter, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Cat.Scheduling.Abstractions.ICatJobClaimStore.TryClaimAsync(string,System.DateTimeOffset,System.DateTimeOffset,bool,System.TimeSpan,System.Threading.CancellationToken).jobName'></a>

`jobName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the job\.

<a name='Cat.Scheduling.Abstractions.ICatJobClaimStore.TryClaimAsync(string,System.DateTimeOffset,System.DateTimeOffset,bool,System.TimeSpan,System.Threading.CancellationToken).dueTime'></a>

`dueTime` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The due time to claim\.

<a name='Cat.Scheduling.Abstractions.ICatJobClaimStore.TryClaimAsync(string,System.DateTimeOffset,System.DateTimeOffset,bool,System.TimeSpan,System.Threading.CancellationToken).now'></a>

`now` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The current time\.

<a name='Cat.Scheduling.Abstractions.ICatJobClaimStore.TryClaimAsync(string,System.DateTimeOffset,System.DateTimeOffset,bool,System.TimeSpan,System.Threading.CancellationToken).allowOverlap'></a>

`allowOverlap` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

When `false` and a run that started less than [deadAfter](ICatJobClaimStore.TryClaimAsync.3IGCHZF8DNHB1ZTJ9PSA7L5MD.md#Cat.Scheduling.Abstractions.ICatJobClaimStore.TryClaimAsync(string,System.DateTimeOffset,System.DateTimeOffset,bool,System.TimeSpan,System.Threading.CancellationToken).deadAfter 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore\.TryClaimAsync\(string, System\.DateTimeOffset, System\.DateTimeOffset, bool, System\.TimeSpan, System\.Threading\.CancellationToken\)\.deadAfter') ago has not finished, the result is [Busy](CatJobClaimStatus.md#Cat.Scheduling.Abstractions.CatJobClaimStatus.Busy 'Cat\.Scheduling\.Abstractions\.CatJobClaimStatus\.Busy')\.

<a name='Cat.Scheduling.Abstractions.ICatJobClaimStore.TryClaimAsync(string,System.DateTimeOffset,System.DateTimeOffset,bool,System.TimeSpan,System.Threading.CancellationToken).deadAfter'></a>

`deadAfter` [System\.TimeSpan](https://learn.microsoft.com/en-us/dotnet/api/system.timespan 'System\.TimeSpan')

The time after which a run that never finished counts as dead\.

<a name='Cat.Scheduling.Abstractions.ICatJobClaimStore.TryClaimAsync(string,System.DateTimeOffset,System.DateTimeOffset,bool,System.TimeSpan,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CatJobClaimResult](CatJobClaimResult.md 'Cat\.Scheduling\.Abstractions\.CatJobClaimResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The outcome of the request for the claim\.