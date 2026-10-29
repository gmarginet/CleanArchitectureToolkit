<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatSwitchCaseBuilder&lt;TWorkflowState,TSwitchValue&gt;](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>')

## CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case Method

| Overloads | |
| :--- | :--- |
| [Case\(TSwitchValue\)](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue) 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue\)') | Adds a case without steps of its own\. It runs the steps of the next case that has some, like a fall through\. |
| [Case\(TSwitchValue, Action&lt;ICatWorkflowBuilder&lt;TWorkflowState&gt;&gt;\)](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__) 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue, System\.Action\<Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\>\)') | Adds a case with its steps\. |

<a name='Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue)'></a>

## CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue\) Method

Adds a case without steps of its own\. It runs the steps of the next case that has some, like a fall through\.

```csharp
public void Case(TSwitchValue testValue);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue).testValue'></a>

`testValue` [TSwitchValue](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TSwitchValue 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TSwitchValue')

The value to match\.

Implements [Case\(TSwitchValue\)](..\Cat.FluentWorkflows.Abstractions\ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case.md#Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue) 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2\.Case\(\`1\)')

#### Exceptions

[System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')  
The value is already used by another case\.

<a name='Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__)'></a>

## CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.Case\(TSwitchValue, Action\<ICatWorkflowBuilder\<TWorkflowState\>\>\) Method

Adds a case with its steps\.

```csharp
public void Case(TSwitchValue testValue, System.Action<Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState>> caseBuilder);
```
#### Parameters

<a name='Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).testValue'></a>

`testValue` [TSwitchValue](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TSwitchValue 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TSwitchValue')

The value to match\.

<a name='Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__).caseBuilder'></a>

`caseBuilder` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.md#Cat.FluentWorkflows.Steps.CatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSwitchCaseBuilder\<TWorkflowState,TSwitchValue\>\.TWorkflowState')[&gt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Adds the steps\.

Implements [Case\(TSwitchValue, Action&lt;ICatWorkflowBuilder&lt;TWorkflowState&gt;&gt;\)](..\Cat.FluentWorkflows.Abstractions\ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case.md#Cat.FluentWorkflows.Abstractions.ICatSwitchCaseBuilder_TWorkflowState,TSwitchValue_.Case(TSwitchValue,System.Action_Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState__) 'Cat\.FluentWorkflows\.Abstractions\.ICatSwitchCaseBuilder\`2\.Case\(\`1,System\.Action\{Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\{\`0\}\}\)')

#### Exceptions

[System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')  
The value is already used by another case\.