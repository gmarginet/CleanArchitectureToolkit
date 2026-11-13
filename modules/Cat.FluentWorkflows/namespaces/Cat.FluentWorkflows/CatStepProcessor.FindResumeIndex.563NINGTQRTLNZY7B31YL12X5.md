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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.FLUENTWORKFLOWS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') >> [CatStepProcessor Class](CatStepProcessor.md 'Cat\.FluentWorkflows\.CatStepProcessor')

## CatStepProcessor\.FindResumeIndex\(List\<ICatWorkflowStep\>, CatCheckpointFrame\) Method

```csharp
private static int FindResumeIndex(System.Collections.Generic.List<Cat.FluentWorkflows.Abstractions.ICatWorkflowStep> steps, Cat.FluentWorkflows.Abstractions.CatCheckpointFrame frame);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatStepProcessor.FindResumeIndex(System.Collections.Generic.List_Cat.FluentWorkflows.Abstractions.ICatWorkflowStep_,Cat.FluentWorkflows.Abstractions.CatCheckpointFrame).steps'></a>

`steps` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ICatWorkflowStep](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowStep.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowStep')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='Cat.FluentWorkflows.CatStepProcessor.FindResumeIndex(System.Collections.Generic.List_Cat.FluentWorkflows.Abstractions.ICatWorkflowStep_,Cat.FluentWorkflows.Abstractions.CatCheckpointFrame).frame'></a>

`frame` [CatCheckpointFrame](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/CatCheckpointFrame.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame')

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')