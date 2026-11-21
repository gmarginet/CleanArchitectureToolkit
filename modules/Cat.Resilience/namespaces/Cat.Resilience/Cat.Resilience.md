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
  
##### >> [Cat\.Resilience Assembly](index.md 'index')

## Cat\.Resilience Namespace

Puts the resilience profiles on an [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient') and runs one call that is not HTTP through a profile\.

| Classes | |
| :--- | :--- |
| [CatResilienceConfigurationSetup](CatResilienceConfigurationSetup.md 'Cat\.Resilience\.CatResilienceConfigurationSetup') | Reads the profiles from configuration after the code has set them, so configuration wins over code\. |
| [CatResiliencePipelines](CatResiliencePipelines.md 'Cat\.Resilience\.CatResiliencePipelines') | Builds one pipeline per profile for a call that is not HTTP, and keeps it, so the circuit breaker state is shared\. |
| [CatResiliencePipelines\.CatResiliencePipeline](CatResiliencePipelines.CatResiliencePipeline.md 'Cat\.Resilience\.CatResiliencePipelines\.CatResiliencePipeline') | |
| [CatResilienceProfiles](CatResilienceProfiles.md 'Cat\.Resilience\.CatResilienceProfiles') | Looks up the settings of a profile by name\. |
| [CatResilienceStartupValidator](CatResilienceStartupValidator.md 'Cat\.Resilience\.CatResilienceStartupValidator') | Fails the startup of the host when a registration refers to a profile that does not exist\. |
| [CatResilienceUse](CatResilienceUse.md 'Cat\.Resilience\.CatResilienceUse') | Notes that a client refers to a profile, so the startup check can fail on a name that does not exist\. |
