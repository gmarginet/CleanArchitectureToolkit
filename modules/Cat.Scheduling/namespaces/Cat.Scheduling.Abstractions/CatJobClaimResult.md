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

## CatJobClaimResult Class

The outcome of asking for the claim of a job\.

```csharp
public class CatJobClaimResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatJobClaimResult

| Constructors | |
| :--- | :--- |
| [CatJobClaimResult\(CatJobClaimStatus, CatJobClaim\)](CatJobClaimResult..ctor.JUF7Z29CT8VIW0HJ4SWHYDCS9.md 'Cat\.Scheduling\.Abstractions\.CatJobClaimResult\.CatJobClaimResult\(Cat\.Scheduling\.Abstractions\.CatJobClaimStatus, Cat\.Scheduling\.Abstractions\.CatJobClaim\)') | |

| Properties | |
| :--- | :--- |
| [Claim](CatJobClaimResult.Claim.md 'Cat\.Scheduling\.Abstractions\.CatJobClaimResult\.Claim') | The claim\. Only set when [Status](CatJobClaimResult.Status.md 'Cat\.Scheduling\.Abstractions\.CatJobClaimResult\.Status') is [Claimed](CatJobClaimStatus.md#Cat.Scheduling.Abstractions.CatJobClaimStatus.Claimed 'Cat\.Scheduling\.Abstractions\.CatJobClaimStatus\.Claimed')\. |
| [Status](CatJobClaimResult.Status.md 'Cat\.Scheduling\.Abstractions\.CatJobClaimResult\.Status') | Whether the caller got the claim, and if not why\. |

| Methods | |
| :--- | :--- |
| [Busy\(\)](CatJobClaimResult.Busy().md 'Cat\.Scheduling\.Abstractions\.CatJobClaimResult\.Busy\(\)') | Creates the result for a job whose previous run is still busy\. |
| [Claimed\(CatJobClaim\)](CatJobClaimResult.Claimed.7IADIFEDYU8FR9CTES3MMN6M1.md 'Cat\.Scheduling\.Abstractions\.CatJobClaimResult\.Claimed\(Cat\.Scheduling\.Abstractions\.CatJobClaim\)') | Creates the result for a claim that was given\. |
| [TakenByOther\(\)](CatJobClaimResult.TakenByOther().md 'Cat\.Scheduling\.Abstractions\.CatJobClaimResult\.TakenByOther\(\)') | Creates the result for a due time that another instance already claimed\. |
