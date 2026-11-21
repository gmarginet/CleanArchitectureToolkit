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
  
##### >> [Cat\.Scheduling\.Resilience Assembly](index.md 'index') >> [Cat\.Scheduling\.Resilience Namespace](Cat.Scheduling.Resilience.md 'Cat\.Scheduling\.Resilience')

## CatSchedulingResilienceOptions Class

Says which resilience profile runs the tries of a job\.

```csharp
public sealed class CatSchedulingResilienceOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSchedulingResilienceOptions

| Properties | |
| :--- | :--- |
| [DefaultProfile](CatSchedulingResilienceOptions.DefaultProfile.md 'Cat\.Scheduling\.Resilience\.CatSchedulingResilienceOptions\.DefaultProfile') | Gets or sets the profile for every job that has no profile of its own\. The default is [Internal](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/CatResilienceProfile.Internal.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfile\.Internal')\. |
| [JobProfiles](CatSchedulingResilienceOptions.JobProfiles.md 'Cat\.Scheduling\.Resilience\.CatSchedulingResilienceOptions\.JobProfiles') | Gets the profile of a job by job name\. The job name is not case sensitive\. |
