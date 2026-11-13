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
  
##### >> [Cat\.Scheduling\.Abstractions Assembly](index.md 'index') >> [Cat\.Scheduling\.Abstractions Namespace](Cat.Scheduling.Abstractions.md 'Cat\.Scheduling\.Abstractions')

## ICatJobClaimStore Interface

Makes sure that only one instance of a service runs a job at a due time, and remembers how every run ended\.
The module ships a store in memory, for a service with one instance\. The optional EF Core project keeps the claims
in the database of the service\. Write your own store, for example on a blob lease, and register it before the module\.

```csharp
public interface ICatJobClaimStore
```

| Methods | |
| :--- | :--- |
| [CompleteAsync\(CatJobClaim, CatJobRunResult, DateTimeOffset, CancellationToken\)](ICatJobClaimStore.CompleteAsync.CQM3U3SVUJ1ATMS0RBFYADC32.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore\.CompleteAsync\(Cat\.Scheduling\.Abstractions\.CatJobClaim, Cat\.Scheduling\.Abstractions\.CatJobRunResult, System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | Records how a claimed run ended\. |
| [GetLastDueTimeAsync\(string, CancellationToken\)](ICatJobClaimStore.GetLastDueTimeAsync.U4K9715BAMBGZN57UGXLKIHE.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore\.GetLastDueTimeAsync\(string, System\.Threading\.CancellationToken\)') | Gets the latest due time that was claimed for a job\. The scheduler uses it at startup to find missed runs\. |
| [TryClaimAsync\(string, DateTimeOffset, DateTimeOffset, bool, TimeSpan, CancellationToken\)](ICatJobClaimStore.TryClaimAsync.3IGCHZF8DNHB1ZTJ9PSA7L5MD.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore\.TryClaimAsync\(string, System\.DateTimeOffset, System\.DateTimeOffset, bool, System\.TimeSpan, System\.Threading\.CancellationToken\)') | Tries to claim the job for a due time\. Exactly one caller gets [Claimed](CatJobClaimStatus.md#Cat.Scheduling.Abstractions.CatJobClaimStatus.Claimed 'Cat\.Scheduling\.Abstractions\.CatJobClaimStatus\.Claimed') for the same job and due time\. |
