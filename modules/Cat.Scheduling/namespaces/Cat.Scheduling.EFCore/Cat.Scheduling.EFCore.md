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
  
##### >> [Cat\.Scheduling\.EFCore Assembly](index.md 'index')

## Cat\.Scheduling\.EFCore Namespace

Keeps the claims and the run history of the scheduler in the database of the service, so several instances
of the service never run the same job at the same due time, and a missed run is found after a restart\.

| Classes | |
| :--- | :--- |
| [CatJobRun](CatJobRun.md 'Cat\.Scheduling\.EFCore\.CatJobRun') | One row of the job run table: the claim and the outcome of a run of a job at a due time\. The job name and the due time together are the key, so a second claim for the same due time fails\. All times are UTC\. |
| [EfCoreJobClaimStore&lt;TDbContext&gt;](EfCoreJobClaimStore_TDbContext_.md 'Cat\.Scheduling\.EFCore\.EfCoreJobClaimStore\<TDbContext\>') | [ICatJobClaimStore](../../../Cat.Scheduling/namespaces/Cat.Scheduling.Abstractions/ICatJobClaimStore.md 'Cat\.Scheduling\.Abstractions\.ICatJobClaimStore') on a `DbContext` of the service\.             The unique key on the job name and the due time decides which instance gets the claim:             the instance whose insert succeeds runs the job\. |
| [ModelBuilderExtensions](ModelBuilderExtensions.md 'Cat\.Scheduling\.EFCore\.ModelBuilderExtensions') | Adds the job run table to the model of a `DbContext`\. |
