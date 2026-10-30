<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\> Interface

Describes the cases of a switch step\.

```csharp
public interface ICatSwitchCaseBuilder<TWorkflowState,TSwitchValue>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TSwitchValue : struct
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TSwitchValue'></a>

`TSwitchValue`

The type of the value being switched on\.

| Methods | |
| :--- | :--- |
| [Case\(TSwitchValue\)](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case.md#Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue) 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue\)') | Adds a case without steps of its own\. It runs the steps of the next case that has some, like a fall through\. |
| [Case\(TSwitchValue, Action&lt;ICatWorkflowBuilder&lt;TWorkflowState&gt;&gt;\)](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case.md#Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__) 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)') | Adds a case with its steps\. |
| [Default\(Action&lt;ICatWorkflowBuilder&lt;TWorkflowState&gt;&gt;\)](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Default.RQTMMYBVC4TIU3P75LQHNIYZ3.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Default\(System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)') | Adds the steps to run when no case matches\. |
