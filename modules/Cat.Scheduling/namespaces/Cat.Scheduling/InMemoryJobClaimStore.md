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

## InMemoryJobClaimStore Class

[ICatJobClaimStore](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobClaimStore.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore') in memory\. It is right for a service with one instance\.
            The claims are gone after a restart, so a missed run cannot be found at startup\.

```csharp
internal sealed class InMemoryJobClaimStore : Cat.Scheduling.Abstractions.ICatJobClaimStore
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → InMemoryJobClaimStore

Implements [ICatJobClaimStore](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobClaimStore.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore')

| Fields | |
| :--- | :--- |
| [\_lock](InMemoryJobClaimStore._lock.md 'Cat\.Scheduling\.InMemoryJobClaimStore\.\_lock') | |
| [\_runs](InMemoryJobClaimStore._runs.md 'Cat\.Scheduling\.InMemoryJobClaimStore\.\_runs') | |

| Methods | |
| :--- | :--- |
| [CompleteAsync\(CatJobClaim, CatJobRunResult, DateTimeOffset, CancellationToken\)](InMemoryJobClaimStore.CompleteAsync.1C9DPZJITHXLSUS8OF3F5LP18.md 'Cat\.Scheduling\.InMemoryJobClaimStore\.CompleteAsync\(Cat\.Scheduling\.Abstractions\.CatJobClaim, Cat\.Scheduling\.Abstractions\.CatJobRunResult, System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | Records how a claimed run ended\. |
| [GetLastDueTimeAsync\(string, CancellationToken\)](InMemoryJobClaimStore.GetLastDueTimeAsync.B0D95IA5Z6MCWMAWZ158M02TA.md 'Cat\.Scheduling\.InMemoryJobClaimStore\.GetLastDueTimeAsync\(string, System\.Threading\.CancellationToken\)') | Gets the latest due time that was claimed for a job\. The scheduler uses it at startup to find missed runs\. |
| [Key\(string, DateTimeOffset\)](InMemoryJobClaimStore.Key.0GTE2FB6JQFMNYT4YKQW0H6T5.md 'Cat\.Scheduling\.InMemoryJobClaimStore\.Key\(string, System\.DateTimeOffset\)') | |
| [TryClaimAsync\(string, DateTimeOffset, DateTimeOffset, bool, TimeSpan, CancellationToken\)](InMemoryJobClaimStore.TryClaimAsync.SE1UXJOEB11N8HDMX3FZEAN15.md 'Cat\.Scheduling\.InMemoryJobClaimStore\.TryClaimAsync\(string, System\.DateTimeOffset, System\.DateTimeOffset, bool, System\.TimeSpan, System\.Threading\.CancellationToken\)') | Tries to claim the job for a due time\. Exactly one caller gets [Claimed](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobClaimStatus.md#Cat.Scheduling.Abstractions.CatJobClaimStatus.Claimed 'Cat\.Scheduling\.Abstractions\.CatJobClaimStatus\.Claimed') for the same job and due time\. |
