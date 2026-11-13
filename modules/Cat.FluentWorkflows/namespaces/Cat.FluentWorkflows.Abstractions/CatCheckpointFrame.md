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
  
##### >> [Cat\.FluentWorkflows\.Abstractions Assembly](index.md 'index') >> [Cat\.FluentWorkflows\.Abstractions Namespace](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## CatCheckpointFrame Class

The position in one list of steps: which step suspended, and what that step looked like inside\.
A step that waits for an answer is the end of the chain and has no [Child](CatCheckpointFrame.Child.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Child') and no [Branches](CatCheckpointFrame.Branches.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Branches')\.
A container step such as an if, a loop or a sub\-workflow points to the frame of the step inside it with [Child](CatCheckpointFrame.Child.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Child')\.
A parallel step holds one entry per branch in [Branches](CatCheckpointFrame.Branches.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Branches')\.

```csharp
public class CatCheckpointFrame
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCheckpointFrame

| Properties | |
| :--- | :--- |
| [BodyType](CatCheckpointFrame.BodyType.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.BodyType') | The full name of the step body type\. A resume checks it against the rebuilt step\. |
| [Branch](CatCheckpointFrame.Branch.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Branch') | The branch a container step was in, see [CatCheckpointBranches](CatCheckpointBranches.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointBranches')\. |
| [Branches](CatCheckpointFrame.Branches.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Branches') | The branches of a parallel step\. It is empty for every other step\. |
| [CaseValue](CatCheckpointFrame.CaseValue.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.CaseValue') | The value of the case a switch step ran\. |
| [Child](CatCheckpointFrame.Child.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Child') | The frame of the step inside this container step, or `null` for a step that waits itself\. |
| [IsLeaf](CatCheckpointFrame.IsLeaf.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.IsLeaf') | `true` for a step that waits for an answer itself\. |
| [ItemCount](CatCheckpointFrame.ItemCount.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.ItemCount') | The number of items a foreach had\. A resume fails when the collection has another count\. |
| [Iteration](CatCheckpointFrame.Iteration.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Iteration') | The pass of a while, or the index of the item of a foreach, that was running\. |
| [LoopState](CatCheckpointFrame.LoopState.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.LoopState') | The state of a foreach, shared by all its items\. The engine sets its parent state to `null`, so a serializer does not drag the whole workflow state along\. The resume sets it again\. |
| [LoopStateType](CatCheckpointFrame.LoopStateType.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.LoopStateType') | The assembly qualified name of the type of [LoopState](CatCheckpointFrame.LoopState.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.LoopState'), so the serializer knows what to create\. |
| [StepIndex](CatCheckpointFrame.StepIndex.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.StepIndex') | The position of the step in its list\. |
| [StepName](CatCheckpointFrame.StepName.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.StepName') | The name of the step, when the developer gave it one\. A name wins over the position when the workflow is rebuilt\. |
| [WorkflowVersion](CatCheckpointFrame.WorkflowVersion.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.WorkflowVersion') | The version of a sub\-workflow that suspended inside this step\. |

| Methods | |
| :--- | :--- |
| [Leaves\(\)](CatCheckpointFrame.Leaves().md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Leaves\(\)') | Finds the steps that wait for an answer, at any depth\. |
