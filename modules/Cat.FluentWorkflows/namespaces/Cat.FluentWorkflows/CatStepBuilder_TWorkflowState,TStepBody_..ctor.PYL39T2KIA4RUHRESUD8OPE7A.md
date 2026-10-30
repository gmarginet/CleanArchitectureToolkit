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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatStepBuilder&lt;TWorkflowState,TStepBody&gt; Class](CatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>')

## CatStepBuilder\(CatWorkflowStep\<TStepBody\>\) Constructor

Creates the builder\.

```csharp
public CatStepBuilder(Cat.FluentWorkflows.CatWorkflowStep<TStepBody> workflowStep);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.CatStepBuilder(Cat.FluentWorkflows.CatWorkflowStep_TStepBody_).workflowStep'></a>

`workflowStep` [Cat\.FluentWorkflows\.CatWorkflowStep&lt;](CatWorkflowStep_TStepBody_.md 'Cat\.FluentWorkflows\.CatWorkflowStep\<TStepBody\>')[TStepBody](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TStepBody 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TStepBody')[&gt;](CatWorkflowStep_TStepBody_.md 'Cat\.FluentWorkflows\.CatWorkflowStep\<TStepBody\>')

The step to add the inputs and outputs to\.