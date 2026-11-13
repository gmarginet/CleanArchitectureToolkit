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
  
##### >> [Cat\.Scheduling\.EFCore Assembly](index.md 'index') >> [Cat\.Scheduling\.EFCore Namespace](Cat.Scheduling.EFCore.md 'Cat\.Scheduling\.EFCore')

## EfCoreJobClaimStore\<TDbContext\> Class

[ICatJobClaimStore](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobClaimStore.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore') on a `DbContext` of the service\.
            The unique key on the job name and the due time decides which instance gets the claim:
            the instance whose insert succeeds runs the job\.

```csharp
internal sealed class EfCoreJobClaimStore<TDbContext> : Cat.Scheduling.Abstractions.ICatJobClaimStore
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
```
#### Type parameters

<a name='Cat.Scheduling.EFCore.EfCoreJobClaimStore_TDbContext_.TDbContext'></a>

`TDbContext`

The context that holds the job run table, see [AddCatScheduling\(this ModelBuilder\)](ModelBuilderExtensions.AddCatScheduling.AIU68307FR4A2EMPKCIBK347A.md 'Cat\.Scheduling\.EFCore\.ModelBuilderExtensions\.AddCatScheduling\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)')\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → EfCoreJobClaimStore\<TDbContext\>

Implements [ICatJobClaimStore](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobClaimStore.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore')

| Constructors | |
| :--- | :--- |
| [EfCoreJobClaimStore\(IServiceScopeFactory\)](EfCoreJobClaimStore_TDbContext_..ctor.2BK1CYY5G1EJ009QRYNQQB4AE.md 'Cat\.Scheduling\.EFCore\.EfCoreJobClaimStore\<TDbContext\>\.EfCoreJobClaimStore\(Microsoft\.Extensions\.DependencyInjection\.IServiceScopeFactory\)') | Creates the store\. |

| Fields | |
| :--- | :--- |
| [\_scopeFactory](EfCoreJobClaimStore_TDbContext_._scopeFactory.md 'Cat\.Scheduling\.EFCore\.EfCoreJobClaimStore\<TDbContext\>\.\_scopeFactory') | |

| Methods | |
| :--- | :--- |
| [CompleteAsync\(CatJobClaim, CatJobRunResult, DateTimeOffset, CancellationToken\)](EfCoreJobClaimStore_TDbContext_.CompleteAsync.Q6Z7B87Q52KVVTYKSTRA682D7.md 'Cat\.Scheduling\.EFCore\.EfCoreJobClaimStore\<TDbContext\>\.CompleteAsync\(Cat\.Scheduling\.Abstractions\.CatJobClaim, Cat\.Scheduling\.Abstractions\.CatJobRunResult, System\.DateTimeOffset, System\.Threading\.CancellationToken\)') | Records how a claimed run ended\. |
| [ExistsAsync\(string, DateTime, CancellationToken\)](EfCoreJobClaimStore_TDbContext_.ExistsAsync.OS9YAY5KMENO1FADOU2IDHOI6.md 'Cat\.Scheduling\.EFCore\.EfCoreJobClaimStore\<TDbContext\>\.ExistsAsync\(string, System\.DateTime, System\.Threading\.CancellationToken\)') | |
| [GetLastDueTimeAsync\(string, CancellationToken\)](EfCoreJobClaimStore_TDbContext_.GetLastDueTimeAsync.LYOZ2P4TPWUTP1PK6CYO3HECC.md 'Cat\.Scheduling\.EFCore\.EfCoreJobClaimStore\<TDbContext\>\.GetLastDueTimeAsync\(string, System\.Threading\.CancellationToken\)') | Gets the latest due time that was claimed for a job\. The scheduler uses it at startup to find missed runs\. |
| [TryClaimAsync\(string, DateTimeOffset, DateTimeOffset, bool, TimeSpan, CancellationToken\)](EfCoreJobClaimStore_TDbContext_.TryClaimAsync.8XQHWC8KZP7YXN7BKF2WY4XO6.md 'Cat\.Scheduling\.EFCore\.EfCoreJobClaimStore\<TDbContext\>\.TryClaimAsync\(string, System\.DateTimeOffset, System\.DateTimeOffset, bool, System\.TimeSpan, System\.Threading\.CancellationToken\)') | Tries to claim the job for a due time\. Exactly one caller gets [Claimed](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/CatJobClaimStatus.md#Cat.Scheduling.Abstractions.CatJobClaimStatus.Claimed 'Cat\.Scheduling\.Abstractions\.CatJobClaimStatus\.Claimed') for the same job and due time\. |
