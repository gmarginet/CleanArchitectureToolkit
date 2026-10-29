<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\> Class

Default [ICatSwitchCaseBuilder&lt;TWorkflowState,TSwitchValue&gt;](..\Cat.FluentWorkflows.Abstractions\ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2')\.
Collects the cases and the default case of a switch step\.

```csharp
public class CatSwitchCaseBuilder<TWorkflowState,TSwitchValue> : Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder<TWorkflowState, TSwitchValue>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TSwitchValue : struct, System.ValueType, System.ValueType
```
#### Type parameters

<a name='Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TSwitchValue'></a>

`TSwitchValue`

The type of the value being switched on\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>

Implements [Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder&lt;](..\Cat.FluentWorkflows.Abstractions\ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2')[TWorkflowState](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TWorkflowState')[,](..\Cat.FluentWorkflows.Abstractions\ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2')[TSwitchValue](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TSwitchValue 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TSwitchValue')[&gt;](..\Cat.FluentWorkflows.Abstractions\ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2')

| Properties | |
| :--- | :--- |
| [BuildCases](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.BuildCases.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.BuildCases') | |
| [BuildDefaultCase](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.BuildDefaultCase.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.BuildDefaultCase') | |
| [UnAssignedSwitchValues](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.UnAssignedSwitchValues.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.UnAssignedSwitchValues') | |

| Methods | |
| :--- | :--- |
| [Case\(TSwitchValue\)](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue) 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue\)') | Adds a case without steps of its own\. It runs the steps of the next case that has some, like a fall through\. |
| [Case\(TSwitchValue, Action&lt;ICatWorkflowBuilder&lt;TWorkflowState&gt;&gt;\)](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__) 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)') | Adds a case with its steps\. |
| [Default\(Action&lt;ICatWorkflowBuilder&lt;TWorkflowState&gt;&gt;\)](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Default.P0L80OJ5N9BP5PQ6LHE6D56X9.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Default\(System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)') | Adds the steps to run when no case matches\. |
