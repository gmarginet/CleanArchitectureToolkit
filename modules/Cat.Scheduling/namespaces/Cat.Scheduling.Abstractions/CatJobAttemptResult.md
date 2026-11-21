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

## CatJobAttemptResult Class

The outcome of one try of a job, and whether a failed try is worth trying again\.

```csharp
public sealed class CatJobAttemptResult
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatJobAttemptResult

| Constructors | |
| :--- | :--- |
| [CatJobAttemptResult\(string, bool\)](CatJobAttemptResult..ctor.H0ZR0SMFCK0FRJZS9NNJT99X5.md 'Cat\.Scheduling\.Abstractions\.CatJobAttemptResult\.CatJobAttemptResult\(string, bool\)') | |

| Properties | |
| :--- | :--- |
| [CanRetry](CatJobAttemptResult.CanRetry.md 'Cat\.Scheduling\.Abstractions\.CatJobAttemptResult\.CanRetry') | Gets whether a new try can help\. It is `true` for an `InternalServerError` response and for an exception, and `false` for every other failed response, such as `BadRequest` or `NotFound`\. |
| [ErrorCode](CatJobAttemptResult.ErrorCode.md 'Cat\.Scheduling\.Abstractions\.CatJobAttemptResult\.ErrorCode') | Gets the code of the first error of a failed response, or the exception type name\. `null` when the try succeeded\. |
| [Succeeded](CatJobAttemptResult.Succeeded.md 'Cat\.Scheduling\.Abstractions\.CatJobAttemptResult\.Succeeded') | Gets the result of a try that succeeded\. |

| Methods | |
| :--- | :--- |
| [Failed\(string, bool\)](CatJobAttemptResult.Failed.IYWC6JV9BU4AKDPQB13V9P221.md 'Cat\.Scheduling\.Abstractions\.CatJobAttemptResult\.Failed\(string, bool\)') | Creates the result of a try that failed\. |
