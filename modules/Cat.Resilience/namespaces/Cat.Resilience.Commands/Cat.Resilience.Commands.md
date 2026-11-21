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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.RESILIENCE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Resilience\.Commands Assembly](index.md 'index')

## Cat\.Resilience\.Commands Namespace

Retries a whole command through a resilience profile of Cat\.Resilience, for the command types a developer lists\.

| Classes | |
| :--- | :--- |
| [CatCommandRetryOptions](CatCommandRetryOptions.md 'Cat\.Resilience\.Commands\.CatCommandRetryOptions') | Lists the command types that are retried\. Nothing is retried by default\. |
| [CatRetryCommandProcessor](CatRetryCommandProcessor.md 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor') | Wraps the command processor\. A listed command type runs inside the pipeline of its profile, and every try calls the inner processor again, which opens a new scope\. Every other type passes straight through\. A failed response that the rule counts becomes an exception inside the pipeline, so the profile retries it and counts it for its circuit breaker\. After the last retry the response of the last try comes back\. When the pipeline itself says no, for example because its circuit is open or a try timed out, its exception comes through\. |
| [CatRetryCommandProcessor\.RetryableResponseException&lt;TResponse&gt;](CatRetryCommandProcessor.RetryableResponseException_TResponse_.md 'Cat\.Resilience\.Commands\.CatRetryCommandProcessor\.RetryableResponseException\<TResponse\>') | |
| [CatRetryRule](CatRetryRule.md 'Cat\.Resilience\.Commands\.CatRetryRule') | Says how one command type is retried: through which profile, and which failed responses count as a reason to try again\. |
