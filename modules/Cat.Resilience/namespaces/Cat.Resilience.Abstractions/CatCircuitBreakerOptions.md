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
  
##### >> [Cat\.Resilience\.Abstractions Assembly](index.md 'index') >> [Cat\.Resilience\.Abstractions Namespace](Cat.Resilience.Abstractions.md 'Cat\.Resilience\.Abstractions')

## CatCircuitBreakerOptions Class

Settings of the circuit breaker of a profile\.

```csharp
public sealed class CatCircuitBreakerOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCircuitBreakerOptions

| Properties | |
| :--- | :--- |
| [BreakDuration](CatCircuitBreakerOptions.BreakDuration.md 'Cat\.Resilience\.Abstractions\.CatCircuitBreakerOptions\.BreakDuration') | Gets or sets how long the circuit stays open before it lets a test call through\. The default is 5 seconds\. |
| [FailureRatio](CatCircuitBreakerOptions.FailureRatio.md 'Cat\.Resilience\.Abstractions\.CatCircuitBreakerOptions\.FailureRatio') | Gets or sets the share of failed calls, from 0 to 1, that opens the circuit\. The default is 0\.1\. |
| [MinimumThroughput](CatCircuitBreakerOptions.MinimumThroughput.md 'Cat\.Resilience\.Abstractions\.CatCircuitBreakerOptions\.MinimumThroughput') | Gets or sets how many calls must happen in the sampling duration before the circuit may open\. The default is 100\. |
| [SamplingDuration](CatCircuitBreakerOptions.SamplingDuration.md 'Cat\.Resilience\.Abstractions\.CatCircuitBreakerOptions\.SamplingDuration') | Gets or sets the period in which the failures are counted\. The default is 30 seconds\. |
