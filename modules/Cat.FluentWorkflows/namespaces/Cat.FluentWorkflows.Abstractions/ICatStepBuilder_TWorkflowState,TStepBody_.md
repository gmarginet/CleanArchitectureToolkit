<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatStepBuilder\<TWorkflowState,TStepBody\> Interface

Connects a step to the workflow state\. Inputs go from the state into the step before it runs\.
Outputs go from the step back into the state after it ran\.

```csharp
public interface ICatStepBuilder<TWorkflowState,TStepBody>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TStepBody : class, Cat.FluentWorkflows.Abstractions.ICatStepBodyAsync
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Abstractions.ICatStepBuilder_TWorkflowState,TStepBody_.TStepBody'></a>

`TStepBody`

The step body being configured\.

| Methods | |
| :--- | :--- |
| [Input&lt;TInput&gt;\(Expression&lt;Func&lt;TWorkflowState,TInput&gt;&gt;, Expression&lt;Func&lt;TStepBody,TInput&gt;&gt;\)](ICatStepBuilder_TWorkflowState,TStepBody_.Input.UIKFPDN2N33G1RLIGKEATQGF5.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>\.Input\<TInput\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TInput\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TStepBody,TInput\>\>\)') | Copies a value from the workflow state into a member of the step, right before the step runs\. |
| [Output&lt;TOutput&gt;\(Expression&lt;Func&lt;TStepBody,TOutput&gt;&gt;, Expression&lt;Func&lt;TWorkflowState,TOutput&gt;&gt;\)](ICatStepBuilder_TWorkflowState,TStepBody_.Output.GL4EJ5MHMHDQM7R47T76EDI69.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\<TWorkflowState,TStepBody\>\.Output\<TOutput\>\(System\.Linq\.Expressions\.Expression\<System\.Func\<TStepBody,TOutput\>\>, System\.Linq\.Expressions\.Expression\<System\.Func\<TWorkflowState,TOutput\>\>\)') | Copies a value from a member of the step into the workflow state, right after the step ran\. |
