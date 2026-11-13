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

## CatCheckpointBranches Class

The names a container step writes in [Branch](CatCheckpointFrame.Branch.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.Branch')\. A custom container can use its own names\.

```csharp
public static class CatCheckpointBranches
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatCheckpointBranches

| Fields | |
| :--- | :--- |
| [Body](CatCheckpointBranches.Body.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointBranches\.Body') | The inner steps of a loop\. |
| [Case](CatCheckpointBranches.Case.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointBranches\.Case') | A case of a switch\. The value is in [CaseValue](CatCheckpointFrame.CaseValue.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointFrame\.CaseValue')\. |
| [Default](CatCheckpointBranches.Default.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointBranches\.Default') | The default case of a switch\. |
| [Else](CatCheckpointBranches.Else.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointBranches\.Else') | The else steps of an if\. |
| [Sub](CatCheckpointBranches.Sub.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointBranches\.Sub') | The steps of a sub\-workflow\. |
| [Then](CatCheckpointBranches.Then.md 'Cat\.FluentWorkflows\.Abstractions\.CatCheckpointBranches\.Then') | The then steps of an if\. |
