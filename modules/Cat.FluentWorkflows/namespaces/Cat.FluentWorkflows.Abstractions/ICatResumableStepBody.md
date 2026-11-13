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

## ICatResumableStepBody Interface

A step that can wait for an answer\. Its `RunAsync` starts the work and returns [Suspend](CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Suspend 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Suspend')\.
When the answer comes, the resume calls [ResumeAsync\(object, CancellationToken\)](ICatResumableStepBody.ResumeAsync.HP5PHZV9SR380TQFY6XTWDFQB.md 'Cat\.FluentWorkflows\.Abstractions\.ICatResumableStepBody\.ResumeAsync\(object, System\.Threading\.CancellationToken\)') on a new instance of the step\.
Derive from `CatResumableStepBody` to get the answer typed\.

```csharp
public interface ICatResumableStepBody : Cat.FluentWorkflows.Abstractions.ICatStepBodyAsync
```

Implements [ICatStepBodyAsync](ICatStepBodyAsync.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyAsync')

| Methods | |
| :--- | :--- |
| [ResumeAsync\(object, CancellationToken\)](ICatResumableStepBody.ResumeAsync.HP5PHZV9SR380TQFY6XTWDFQB.md 'Cat\.FluentWorkflows\.Abstractions\.ICatResumableStepBody\.ResumeAsync\(object, System\.Threading\.CancellationToken\)') | Finishes the step with the answer\. The inputs of the step are filled again before this runs, and the outputs are copied after it\. |
