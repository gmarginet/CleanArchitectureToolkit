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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Steps Namespace](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatBreakStep Class

Built\-in step behind `BreakCascade`, `BreakFromCurrentFlowOnly` and `BreakFromLoop`\.
It always breaks the way [BreakType](CatBreakStep.BreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep\.BreakType') says\.

```csharp
public class CatBreakStep : Cat.FluentWorkflows.CatStepBody
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → [CatStepBody](CatStepBody.md 'Cat\.FluentWorkflows\.CatStepBody') → CatBreakStep

| Constructors | |
| :--- | :--- |
| [CatBreakStep\(ILogger&lt;CatBreakStep&gt;\)](CatBreakStep..ctor.MYV86KUK3UZ7WDO40EZQ6KTZE.md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep\.CatBreakStep\(Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Steps\.CatBreakStep\>\)') | Creates the step\. |

| Properties | |
| :--- | :--- |
| [BreakType](CatBreakStep.BreakType.md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep\.BreakType') | The kind of break to make\. |

| Methods | |
| :--- | :--- |
| [Run\(\)](CatBreakStep.Run().md 'Cat\.FluentWorkflows\.Steps\.CatBreakStep\.Run\(\)') | Does the work of the step\. |
