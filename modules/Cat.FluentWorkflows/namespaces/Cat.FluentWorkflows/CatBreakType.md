<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps')

## CatBreakType Enum

The kinds of break a break step can make\.

```csharp
public enum CatBreakType
```
### Fields

<a name='Cat.FluentWorkflows.Steps.CatBreakType.BreakCascade'></a>

`BreakCascade` 0

Ends the workflow and every workflow around it\.

<a name='Cat.FluentWorkflows.Steps.CatBreakType.BreakFromCurrentFlowOnly'></a>

`BreakFromCurrentFlowOnly` 1

Ends the current workflow only\.

<a name='Cat.FluentWorkflows.Steps.CatBreakType.BreakFromLoop'></a>

`BreakFromLoop` 2

Leaves the nearest loop\.