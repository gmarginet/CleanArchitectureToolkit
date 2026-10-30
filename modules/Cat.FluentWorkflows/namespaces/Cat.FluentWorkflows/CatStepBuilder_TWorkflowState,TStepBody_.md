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

## CatStepBuilder\<TWorkflowState,TStepBody\> Class

Default [ICatStepBuilder&lt;TWorkflowState,TStepBody&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')\.
Stores the inputs and outputs on the workflow step\.

```csharp
public class CatStepBuilder<TWorkflowState,TStepBody> : Cat.FluentWorkflows.Abstractions.ICatStepBuilder<TWorkflowState, TStepBody>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TStepBody : class, Cat.FluentWorkflows.Abstractions.ICatStepBodyAsync
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TStepBody'></a>

`TStepBody`

The step body being configured\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatStepBuilder\<TWorkflowState,TStepBody\>

Implements [Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TWorkflowState')[,](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TStepBody](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TStepBody 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TStepBody')[&gt;](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')

| Constructors | |
| :--- | :--- |
| [CatStepBuilder\(CatWorkflowStep&lt;TStepBody&gt;\)](CatStepBuilder_TWorkflowState,TStepBody_..ctor.PYL39T2KIA4RUHRESUD8OPE7A.md 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.CatStepBuilder\(Cat\.FluentWorkflows\.CatWorkflowStep\<TStepBody\>\)') | Creates the builder\. |

| Fields | |
| :--- | :--- |
| [\_workflowStep](CatStepBuilder_TWorkflowState,TStepBody_._workflowStep.md 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.\_workflowStep') | |

| Methods | |
| :--- | :--- |
| [Input&lt;TInput&gt;\(Expression&lt;Func&lt;TWorkflowState,TInput&gt;&gt;, Expression&lt;Func&lt;TStepBody,TInput&gt;&gt;\)](CatStepBuilder_TWorkflowState,TStepBody_.Input.TRRQBNNG9HO7LPEEEGT9IKB46.md 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.Input\<TInput\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TInput\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TStepBody,TInput\>\>\)') | Copies a value from the workflow state into a member of the step, right before the step runs\. |
| [Output&lt;TOutput&gt;\(Expression&lt;Func&lt;TStepBody,TOutput&gt;&gt;, Expression&lt;Func&lt;TWorkflowState,TOutput&gt;&gt;\)](CatStepBuilder_TWorkflowState,TStepBody_.Output.HYH4UZ8ZC1T35S2523Q7M5AEA.md 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.Output\<TOutput\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TStepBody,TOutput\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TOutput\>\>\)') | Copies a value from a member of the step into the workflow state, right after the step ran\. |
