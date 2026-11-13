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

## CatParallelRule Enum

Says what a parallel step does when a branch fails or suspends\.
The branches run one after another in the order they were added\. Only the waiting is parallel\.

```csharp
public enum CatParallelRule
```
### Fields

<a name='Cat.FluentWorkflows.Abstractions.CatParallelRule.FailFast'></a>

`FailFast` 0

The first branch that fails or suspends stops the parallel step at once\. Later branches do not start\.
A failure ends the workflow\. A suspend suspends the workflow, and a resume goes on with the later branches\.
This is the default\.

<a name='Cat.FluentWorkflows.Abstractions.CatParallelRule.WaitForAll'></a>

`WaitForAll` 1

Every branch runs, also after a failure\. A suspended branch does not stop the others from running\.
The step ends when no branch waits any more\. It ends the workflow if a branch failed\.

<a name='Cat.FluentWorkflows.Abstractions.CatParallelRule.SuspendUntilAllDone'></a>

`SuspendUntilAllDone` 2

Every branch runs, and a suspended branch does not stop the others from running\.
The first failure stops the parallel step at once and ends the workflow, even when other branches still wait\.
Without a failure the step waits until all branches are done\.