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

## CatWorkflowCheckpoint Class

The saved position of a suspended workflow\. It is a plain class, so you can serialize it with the serializer you like\.
The engine never serializes it\. Save it next to the workflow state, and give both to `ResumeAsync` later\.

```csharp
public class CatWorkflowCheckpoint
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatWorkflowCheckpoint

| Properties | |
| :--- | :--- |
| [Frame](CatWorkflowCheckpoint.Frame.md 'Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint\.Frame') | The position in the first list of steps\. A container step holds the position inside itself in [Child](CatCheckpointFrame.Child.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Child')\. |
| [Version](CatWorkflowCheckpoint.Version.md 'Cat\.FluentWorkflows\.Abstractions\.CatWorkflowCheckpoint\.Version') | The version of the workflow when it suspended, see [ICatVersionedWorkflow](ICatVersionedWorkflow.md 'Cat\.FluentWorkflows\.Abstractions\.ICatVersionedWorkflow')\. A resume with a workflow of another version fails\. |
