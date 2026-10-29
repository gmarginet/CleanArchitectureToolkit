<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions') > [ICatSwitchCaseBuilder&lt;TWorkflowState,TSwitchValue&gt;](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>')

## ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case Method

| Overloads | |
| :--- | :--- |
| [Case\(TSwitchValue\)](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case.md#Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue) 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue\)') | Adds a case without steps of its own\. It runs the steps of the next case that has some, like a fall through\. |
| [Case\(TSwitchValue, Action&lt;ICatWorkflowBuilder&lt;TWorkflowState&gt;&gt;\)](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case.md#Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__) 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)') | Adds a case with its steps\. |

<a name='Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue)'></a>

## ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue\) Method

Adds a case without steps of its own\. It runs the steps of the next case that has some, like a fall through\.

```csharp
void Case(TSwitchValue testValue);
```
#### Parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue).testValue'></a>

`testValue` [TSwitchValue](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TSwitchValue 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TSwitchValue')

The value to match\.

#### Exceptions

[System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')  
The value is already used by another case\.

<a name='Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__)'></a>

## ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue, Action\<ICatWorkflowBuilder\<TWorkflowState\>\>\) Method

Adds a case with its steps\.

```csharp
void Case(TSwitchValue testValue, System.Action<Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState>> caseBuilder);
```
#### Parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).testValue'></a>

`testValue` [TSwitchValue](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TSwitchValue 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TSwitchValue')

The value to match\.

<a name='Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).caseBuilder'></a>

`caseBuilder` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>')[TWorkflowState](ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TWorkflowState 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TWorkflowState')[&gt;](ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the steps\.

#### Exceptions

[System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')  
The value is already used by another case\.