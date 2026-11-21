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
  
##### >> [Cat\.Resilience\.Abstractions Assembly](index.md 'index')

## Cat\.Resilience\.Abstractions Namespace

Holds the names and the settings of the resilience profiles, and the contract to run one call through a profile\.

| Classes | |
| :--- | :--- |
| [CatCircuitBreakerOptions](CatCircuitBreakerOptions.md 'Cat\.Resilience\.Abstractions\.CatCircuitBreakerOptions') | Settings of the circuit breaker of a profile\. |
| [CatRateLimiterOptions](CatRateLimiterOptions.md 'Cat\.Resilience\.Abstractions\.CatRateLimiterOptions') | Settings of the rate limiter of a profile\. It limits the calls that run at the same time\. |
| [CatResilienceOptions](CatResilienceOptions.md 'Cat\.Resilience\.Abstractions\.CatResilienceOptions') | All resilience profiles by name\. It always holds [Internal](CatResilienceProfile.Internal.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfile\.Internal') and [External](CatResilienceProfile.External.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfile\.External') with their code defaults\. Configuration under `Cat:Resilience:Profiles:{name}` wins over code\. |
| [CatResilienceProfile](CatResilienceProfile.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfile') | The names of the two profiles that every service has\. A developer adds more profiles by name, in configuration or in code\. |
| [CatResilienceProfileOptions](CatResilienceProfileOptions.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfileOptions') | The settings of one resilience profile: a rate limiter, a total timeout, a retry, a circuit breaker and a timeout per try\. The defaults are those of the [Internal](CatResilienceProfile.Internal.md 'Cat\.Resilience\.Abstractions\.CatResilienceProfile\.Internal') profile\. |
| [CatRetryOptions](CatRetryOptions.md 'Cat\.Resilience\.Abstractions\.CatRetryOptions') | Settings of the retry of a profile\. |
| [CatTimeoutOptions](CatTimeoutOptions.md 'Cat\.Resilience\.Abstractions\.CatTimeoutOptions') | A timeout setting, used for the total timeout and for the timeout per try\. |

| Interfaces | |
| :--- | :--- |
| [ICatResiliencePipeline](ICatResiliencePipeline.md 'Cat\.Resilience\.Abstractions\.ICatResiliencePipeline') | Runs one call through a resilience profile\. Use it for a call that is not HTTP, such as an upload to blob storage\. The call inside must be safe to repeat, because the pipeline can run it more than once\. Never put a database write of the handler inside it\. |
| [ICatResiliencePipelines](ICatResiliencePipelines.md 'Cat\.Resilience\.Abstractions\.ICatResiliencePipelines') | Gives the pipeline of a named resilience profile, for a call that is not HTTP\. |

| Enums | |
| :--- | :--- |
| [CatBackoffType](CatBackoffType.md 'Cat\.Resilience\.Abstractions\.CatBackoffType') | How the delay between two tries grows\. |
