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
            <img src='../../../../resources/logo/CatLogo-RoundedCorners-320x160.png' alt='' width='200' style='float: right;'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepBody Class

Base class for a step that works synchronously and doesn't need the workflow state directly\.
Get its data through `Input` and hand results back through `Output`\. Implement [Run\(\)](CatStepBody.Run().md 'Cat\.FluentWorkflows\.CatStepBody\.Run\(\)')\.

```csharp
public abstract class CatStepBody : Cat.FluentWorkflows.CatStepBodyAsync
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → CatStepBody

Derived  
↳ [CatBreakStep](CatBreakStep.md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep')

| Constructors | |
| :--- | :--- |
| [CatStepBody\(ILogger\)](CatStepBody..ctor.PRKLCTCDL24JHB32LR876DDKB.md 'Cat\.FluentWorkflows\.CatStepBody\.CatStepBody\(Microsoft\.Extensions\.Logging\.ILogger\)') | Creates the step\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatStepBody.Run().md 'Cat\.FluentWorkflows\.CatStepBody\.Run\(\)') | Does the work of the step\. |
| [RunAsync\(CancellationToken\)](CatStepBody.RunAsync.F0CROBL00G1DJYC6ZWR3F6RU9.md 'Cat\.FluentWorkflows\.CatStepBody\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
