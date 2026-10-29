<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepBuilder\<TWorkflowState,TStepBody\> Class

Default [ICatStepBuilder&lt;TWorkflowState,TStepBody&gt;](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')\.
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

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatStepBuilder\<TWorkflowState,TStepBody\>

Implements [Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TWorkflowState')[,](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TStepBody](CatStepBuilder_TWorkflowState,TStepBody_.md#Cat.FluentWorkflows.CatStepBuilder_TWorkflowState,TStepBody_.TStepBody 'Cat\.FluentWorkflows\.CatStepBuilder\<TWorkflowState,TStepBody\>\.TStepBody')[&gt;](../Cat.FluentWorkflows.Abstractions/ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')

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
