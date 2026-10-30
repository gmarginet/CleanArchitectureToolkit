<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatWorkflowStep\<TStepBody\> Class

A workflow step that runs the step body [TStepBody](CatWorkflowStep_TStepBody_.md#Cat.FluentWorkflows.CatWorkflowStep_TStepBody_.TStepBody 'Cat\.FluentWorkflows\.CatWorkflowStep\<TStepBody\>\.TStepBody')\.

```csharp
public class CatWorkflowStep<TStepBody> : Cat.FluentWorkflows.CatWorkflowStep
    where TStepBody : Cat.FluentWorkflows.Abstractions.ICatStepBodyAsync
```
#### Type parameters

<a name='Cat.FluentWorkflows.CatWorkflowStep_TStepBody_.TStepBody'></a>

`TStepBody`

The step body to run\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [CatWorkflowStep](CatWorkflowStep.md 'Cat\.FluentWorkflows\.CatWorkflowStep') → CatWorkflowStep\<TStepBody\>

| Properties | |
| :--- | :--- |
| [BodyType](CatWorkflowStep_TStepBody_.BodyType.md 'Cat\.FluentWorkflows\.CatWorkflowStep\<TStepBody\>\.BodyType') | The type of the step body\. The step processor gets it from the service provider\. |
