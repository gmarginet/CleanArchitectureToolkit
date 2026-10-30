<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatWorkflowState\<TWorkflowState\> Interface

Marks the class that holds the data of a workflow\. Steps read from it and write to it\.
Implement it with the class itself as the type argument, like `class OrderState : ICatWorkflowState<OrderState>`\.

```csharp
public interface ICatWorkflowState<out TWorkflowState>
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Abstractions.ICatWorkflowState_TWorkflowState_.TWorkflowState'></a>

`TWorkflowState`

The state class itself\.

Derived  
↳ [ICatForeachState&lt;TCollection,TWorkflowState&gt;](ICatForeachState_TCollection,TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatForeachState\<TCollection,TWorkflowState\>')