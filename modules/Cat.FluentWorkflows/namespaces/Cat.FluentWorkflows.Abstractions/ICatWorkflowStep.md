<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Abstractions](index.md 'index') > [Cat\.FluentWorkflows\.Abstractions](Cat.FluentWorkflows.Abstractions.md 'Cat\.FluentWorkflows\.Abstractions')

## ICatWorkflowStep Interface

One step in a workflow: the step body to run and how it connects to the state\.

```csharp
public interface ICatWorkflowStep
```

| Properties | |
| :--- | :--- |
| [BodyType](ICatWorkflowStep.BodyType.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowStep\.BodyType') | The type of the step body\. The step processor gets it from the service provider\. |
| [Inputs](ICatWorkflowStep.Inputs.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowStep\.Inputs') | The values copied from the state into the step before it runs\. |
| [Outputs](ICatWorkflowStep.Outputs.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowStep\.Outputs') | The values copied from the step into the state after it ran\. |
