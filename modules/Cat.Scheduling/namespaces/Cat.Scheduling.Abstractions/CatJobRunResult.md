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

## CatJobRunResult Class

The outcome of a run of a job, after the last retry\.

```csharp
public class CatJobRunResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatJobRunResult

| Constructors | |
| :--- | :--- |
| [CatJobRunResult\(CatJobRunStatus, string, int\)](CatJobRunResult..ctor.I0Z1D6CKK297NQZ2KAU05Y3X4.md 'Cat\.Scheduling\.Abstractions\.CatJobRunResult\.CatJobRunResult\(Cat\.Scheduling\.Abstractions\.CatJobRunStatus, string, int\)') | Creates a result\. |

| Properties | |
| :--- | :--- |
| [Attempts](CatJobRunResult.Attempts.md 'Cat\.Scheduling\.Abstractions\.CatJobRunResult\.Attempts') | The number of times the service request ran, at least 1\. |
| [ErrorCode](CatJobRunResult.ErrorCode.md 'Cat\.Scheduling\.Abstractions\.CatJobRunResult\.ErrorCode') | The code of the first error of a failed response, or the exception type name\. `null` when it succeeded\. |
| [Status](CatJobRunResult.Status.md 'Cat\.Scheduling\.Abstractions\.CatJobRunResult\.Status') | Succeeded or failed\. |
