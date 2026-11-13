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

## CatJobClaim Class

The right to run a job for one due time\. The instance that holds it runs the job\.

```csharp
public class CatJobClaim
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatJobClaim

| Constructors | |
| :--- | :--- |
| [CatJobClaim\(string, DateTimeOffset, DateTimeOffset\)](CatJobClaim..ctor.RMPO7H1HDIT3WRXU05M9QOPJA.md 'Cat\.Scheduling\.Abstractions\.CatJobClaim\.CatJobClaim\(string, System\.DateTimeOffset, System\.DateTimeOffset\)') | Creates a claim\. |

| Properties | |
| :--- | :--- |
| [DueTime](CatJobClaim.DueTime.md 'Cat\.Scheduling\.Abstractions\.CatJobClaim\.DueTime') | The due time the claim is for\. |
| [JobName](CatJobClaim.JobName.md 'Cat\.Scheduling\.Abstractions\.CatJobClaim\.JobName') | The name of the job\. |
| [StartedAt](CatJobClaim.StartedAt.md 'Cat\.Scheduling\.Abstractions\.CatJobClaim\.StartedAt') | When the run started\. |
