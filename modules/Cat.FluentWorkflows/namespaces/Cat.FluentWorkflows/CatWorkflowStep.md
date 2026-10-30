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

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatWorkflowStep Class

Base class of a workflow step\.

```csharp
public abstract class CatWorkflowStep : Cat.FluentWorkflows.Abstractions.ICatWorkflowStep
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatWorkflowStep

Derived  
↳ [CatWorkflowStep&lt;TStepBody&gt;](CatWorkflowStep_TStepBody_.md 'Cat\.FluentWorkflows\.CatWorkflowStep\<TStepBody\>')

Implements [ICatWorkflowStep](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowStep.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowStep')

| Properties | |
| :--- | :--- |
| [BodyType](CatWorkflowStep.BodyType.md 'Cat\.FluentWorkflows\.CatWorkflowStep\.BodyType') | The type of the step body\. The step processor gets it from the service provider\. |
| [Inputs](CatWorkflowStep.Inputs.md 'Cat\.FluentWorkflows\.CatWorkflowStep\.Inputs') | The values copied from the state into the step before it runs\. |
| [Outputs](CatWorkflowStep.Outputs.md 'Cat\.FluentWorkflows\.CatWorkflowStep\.Outputs') | The values copied from the step into the state after it ran\. |
