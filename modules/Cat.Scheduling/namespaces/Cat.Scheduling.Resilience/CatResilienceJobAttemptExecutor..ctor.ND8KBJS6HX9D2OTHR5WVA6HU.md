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
  
##### >> [Cat\.Scheduling\.Resilience Assembly](index.md 'index') >> [Cat\.Scheduling\.Resilience Namespace](Cat.Scheduling.Resilience.md 'Cat\.Scheduling\.Resilience') >> [CatResilienceJobAttemptExecutor Class](CatResilienceJobAttemptExecutor.md 'Cat\.Scheduling\.Resilience\.CatResilienceJobAttemptExecutor')

## CatResilienceJobAttemptExecutor\(ICatResiliencePipelines, CatSchedulingResilienceOptions\) Constructor

Runs every try of a job inside the pipeline of its resilience profile\.
A try that says it can be retried becomes an exception inside the pipeline, so the profile retries it
and counts it for its circuit breaker\. After the last retry the result of the last try comes back\.

```csharp
public CatResilienceJobAttemptExecutor(Cat.Resilience.Abstractions.ICatResiliencePipelines pipelines, Cat.Scheduling.Resilience.CatSchedulingResilienceOptions options);
```
#### Parameters

<a name='Cat.Scheduling.Resilience.CatResilienceJobAttemptExecutor.CatResilienceJobAttemptExecutor(Cat.Resilience.Abstractions.ICatResiliencePipelines,Cat.Scheduling.Resilience.CatSchedulingResilienceOptions).pipelines'></a>

`pipelines` [ICatResiliencePipelines](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/ICatResiliencePipelines.md 'Cat\.Resilience\.Abstractions\.ICatResiliencePipelines')

<a name='Cat.Scheduling.Resilience.CatResilienceJobAttemptExecutor.CatResilienceJobAttemptExecutor(Cat.Resilience.Abstractions.ICatResiliencePipelines,Cat.Scheduling.Resilience.CatSchedulingResilienceOptions).options'></a>

`options` [CatSchedulingResilienceOptions](CatSchedulingResilienceOptions.md 'Cat\.Scheduling\.Resilience\.CatSchedulingResilienceOptions')