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
  
##### >> [Cat\.FluentWorkflows Assembly](index.md 'index') >> [Cat\.FluentWorkflows Namespace](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatResumableStepBody\<TAnswer\> Class

Base class for a step that waits for an answer\. Implement [RunAsync\(CancellationToken\)](CatStepBodyAsync.RunAsync.NDIRNNFATTDGG9GCGGAU4GQP1.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.RunAsync\(System\.Threading\.CancellationToken\)') to start the work and return
[Suspended\(\)](CatWorkflowResponse.Suspended.md#Cat.FluentWorkflows.CatWorkflowResponse.Suspended() 'Cat\.FluentWorkflows\.CatWorkflowResponse\.Suspended\(\)')\. Implement [ResumeAsync\(TAnswer, CancellationToken\)](CatResumableStepBody_TAnswer_.ResumeAsync.7ELFJGJWCBA2LQ5ARR41WH7LE.md 'Cat\.FluentWorkflows\.CatResumableStepBody\<TAnswer\>\.ResumeAsync\(TAnswer, System\.Threading\.CancellationToken\)') to finish the step with the answer\.
Give the step a name with `Named` when you add it, so a checkpoint and a resume can point at it\.

```csharp
public abstract class CatResumableStepBody<TAnswer> : Cat.FluentWorkflows.CatStepBodyAsync, Cat.FluentWorkflows.Abstractions.ICatResumableStepBody, Cat.FluentWorkflows.Abstractions.ICatStepBodyAsync
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatResumableStepBody_TAnswer_.TAnswer'></a>

`TAnswer`

The type of the answer\. A resume with an answer of another type fails\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatStepBodyAsync](CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') → CatResumableStepBody\<TAnswer\>

Implements [ICatResumableStepBody](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatResumableStepBody.md 'Cat\.FluentWorkflows\.Abstractions\.ICatResumableStepBody'), [ICatStepBodyAsync](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBodyAsync.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyAsync')

| Constructors | |
| :--- | :--- |
| [CatResumableStepBody\(ILogger\)](CatResumableStepBody_TAnswer_..ctor.INL3RAAUAS0EEF7WXT5IWVSH6.md 'Cat\.FluentWorkflows\.CatResumableStepBody\<TAnswer\>\.CatResumableStepBody\(Microsoft\.Extensions\.Logging\.ILogger\)') | Creates the step\. |

| Methods | |
| :--- | :--- |
| [ResumeAsync\(TAnswer, CancellationToken\)](CatResumableStepBody_TAnswer_.ResumeAsync.7ELFJGJWCBA2LQ5ARR41WH7LE.md 'Cat\.FluentWorkflows\.CatResumableStepBody\<TAnswer\>\.ResumeAsync\(TAnswer, System\.Threading\.CancellationToken\)') | Finishes the step with the answer\. The outputs of the step are copied into the state after it returns\. |

| Explicit Interface Implementations | |
| :--- | :--- |
| [Cat\.FluentWorkflows\.Abstractions\.ICatResumableStepBody\.ResumeAsync\(object, CancellationToken\)](CatResumableStepBody_TAnswer_.Cat.FluentWorkflows.Abstractions.ICatResumableStepBody.ResumeAsync.AGYNL7S63STXVI80KNNT7OCU8.md 'Cat\.FluentWorkflows\.CatResumableStepBody\<TAnswer\>\.Cat\.FluentWorkflows\.Abstractions\.ICatResumableStepBody\.ResumeAsync\(object, System\.Threading\.CancellationToken\)') | Finishes the step with the answer\. The inputs of the step are filled again before this runs, and the outputs are copied after it\. |
