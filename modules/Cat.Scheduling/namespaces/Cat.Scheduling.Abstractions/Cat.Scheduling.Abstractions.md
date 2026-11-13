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
  
##### >> [Cat\.Scheduling\.Abstractions Assembly](index.md 'index')

## Cat\.Scheduling\.Abstractions Namespace

Describes a scheduled job and its settings, the registry that holds the declared jobs, the runner that runs a job
at once, and the claim store that makes sure only one instance of a service runs a job at a due time\.

| Classes | |
| :--- | :--- |
| [CatJobClaim](CatJobClaim.md 'Cat\.Scheduling\.Abstractions\.CatJobClaim') | The right to run a job for one due time\. The instance that holds it runs the job\. |
| [CatJobClaimResult](CatJobClaimResult.md 'Cat\.Scheduling\.Abstractions\.CatJobClaimResult') | The outcome of asking for the claim of a job\. |
| [CatJobOptions](CatJobOptions.md 'Cat\.Scheduling\.Abstractions\.CatJobOptions') | The settings of one scheduled job\. The code sets them when it declares the job\. The configuration section `CatScheduling:Jobs:<job name>` wins, so whoever runs the service can change a cron expression or switch a job off per environment without a build\. |
| [CatJobRegistration](CatJobRegistration.md 'Cat\.Scheduling\.Abstractions\.CatJobRegistration') | A declared job: a name, the service request to send and the settings\. |
| [CatJobRunResult](CatJobRunResult.md 'Cat\.Scheduling\.Abstractions\.CatJobRunResult') | The outcome of a run of a job, after the last retry\. |

| Interfaces | |
| :--- | :--- |
| [ICatJobClaimStore](ICatJobClaimStore.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore') | Makes sure that only one instance of a service runs a job at a due time, and remembers how every run ended\. The module ships a store in memory, for a service with one instance\. The optional EF Core project keeps the claims in the database of the service\. Write your own store, for example on a blob lease, and register it before the module\. |
| [ICatJobRegistry](ICatJobRegistry.md 'Cat\.Scheduling\.Abstractions\.ICatJobRegistry') | Holds the jobs the service declared\. |
| [ICatJobRunner](ICatJobRunner.md 'Cat\.Scheduling\.Abstractions\.ICatJobRunner') | Runs a declared job at once, the same way the scheduler runs it at a due time\. Use it to test a job without waiting for the schedule, for example from a development endpoint\. It sends the service request as the system user of the scheduler, retries as the job says and traces the run\. It does not use the claim store, so it runs whatever the other instances do\. |

| Enums | |
| :--- | :--- |
| [CatJobClaimStatus](CatJobClaimStatus.md 'Cat\.Scheduling\.Abstractions\.CatJobClaimStatus') | Why a caller did or did not get the claim of a job\. |
| [CatJobRunStatus](CatJobRunStatus.md 'Cat\.Scheduling\.Abstractions\.CatJobRunStatus') | The state of one run of a job\. |
| [CatMissedRunBehavior](CatMissedRunBehavior.md 'Cat\.Scheduling\.Abstractions\.CatMissedRunBehavior') | What a job does at startup when a due time passed while the service was not running\. |
