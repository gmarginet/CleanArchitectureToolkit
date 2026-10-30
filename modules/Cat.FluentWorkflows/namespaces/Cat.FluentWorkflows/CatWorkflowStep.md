<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatWorkflowStep Class

Base class of a workflow step\.

```csharp
public abstract class CatWorkflowStep : Cat.FluentWorkflows.Abstractions.ICatWorkflowStep
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatWorkflowStep

Derived  
↳ [CatWorkflowStep&lt;TStepBody&gt;](CatWorkflowStep_TStepBody_.md 'Cat\.FluentWorkflows\.CatWorkflowStep\<TStepBody\>')

Implements [ICatWorkflowStep](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatWorkflowStep.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowStep')

| Properties | |
| :--- | :--- |
| [BodyType](CatWorkflowStep.BodyType.md 'Cat\.FluentWorkflows\.CatWorkflowStep\.BodyType') | The type of the step body\. The step processor gets it from the service provider\. |
| [Inputs](CatWorkflowStep.Inputs.md 'Cat\.FluentWorkflows\.CatWorkflowStep\.Inputs') | The values copied from the state into the step before it runs\. |
| [Outputs](CatWorkflowStep.Outputs.md 'Cat\.FluentWorkflows\.CatWorkflowStep\.Outputs') | The values copied from the step into the state after it ran\. |
