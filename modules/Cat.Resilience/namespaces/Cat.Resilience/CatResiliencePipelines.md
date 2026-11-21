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
  
##### >> [Cat\.Resilience Assembly](index.md 'index') >> [Cat\.Resilience Namespace](Cat.Resilience.md 'Cat\.Resilience')

## CatResiliencePipelines Class

Builds one pipeline per profile for a call that is not HTTP, and keeps it, so the circuit breaker state is shared\.

```csharp
internal sealed class CatResiliencePipelines : Cat.Resilience.Abstractions.ICatResiliencePipelines
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatResiliencePipelines

Implements [ICatResiliencePipelines](../../../Cat.Resilience/namespaces/Cat.Resilience.Abstractions/ICatResiliencePipelines.md 'Cat\.Resilience\.Abstractions\.ICatResiliencePipelines')

| Constructors | |
| :--- | :--- |
| [CatResiliencePipelines\(CatResilienceProfiles, ILoggerFactory, TimeProvider\)](CatResiliencePipelines..ctor.5XM1R4FL260Y56W9V83GD8ZP8.md 'Cat\.Resilience\.CatResiliencePipelines\.CatResiliencePipelines\(Cat\.Resilience\.CatResilienceProfiles, Microsoft\.Extensions\.Logging\.ILoggerFactory, System\.TimeProvider\)') | Builds one pipeline per profile for a call that is not HTTP, and keeps it, so the circuit breaker state is shared\. |

| Fields | |
| :--- | :--- |
| [\_pipelines](CatResiliencePipelines._pipelines.md 'Cat\.Resilience\.CatResiliencePipelines\.\_pipelines') | |

| Methods | |
| :--- | :--- |
| [Build\(string, CatResilienceProfileOptions\)](CatResiliencePipelines.Build.NV7BL97HB8GY20XLY2DUNZ096.md 'Cat\.Resilience\.CatResiliencePipelines\.Build\(string, Cat\.Resilience\.Abstractions\.CatResilienceProfileOptions\)') | |
| [Get\(string\)](CatResiliencePipelines.Get.GP5ASI83KIZI5KBE2XJZ2C6I.md 'Cat\.Resilience\.CatResiliencePipelines\.Get\(string\)') | Gets the pipeline of a profile\. Every call with the same name returns the same pipeline, with the same circuit breaker state\. |
| [ToPolly\(CatBackoffType\)](CatResiliencePipelines.ToPolly.LD9LKJSSLFW24F16T73B4A1K7.md 'Cat\.Resilience\.CatResiliencePipelines\.ToPolly\(Cat\.Resilience\.Abstractions\.CatBackoffType\)') | |
