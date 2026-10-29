<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepProcessor Class

Default [ICatStepProcessor](..\Cat.FluentWorkflows.Abstractions\ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')\.
For each step it gets the step body from the service provider, fills the inputs, runs the step and copies the outputs\.
It stops after a step that returns BreakCascade, BreakFromCurrentFlowOnly or BreakFromLoop\.
The result is the one of the last step that ran\. The errors of every step that ran are kept\.

```csharp
public class CatStepProcessor : Cat.FluentWorkflows.Abstractions.ICatStepProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatStepProcessor

Implements [ICatStepProcessor](..\Cat.FluentWorkflows.Abstractions\ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')

| Constructors | |
| :--- | :--- |
| [CatStepProcessor\(IServiceProvider, ILogger&lt;CatStepProcessor&gt;\)](CatStepProcessor..ctor.8E1HBRYL2U3SPN9WU6ATH8RC6.md 'Cat\.FluentWorkflows\.CatStepProcessor\.CatStepProcessor\(System\.IServiceProvider, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.CatStepProcessor\>\)') | Creates the processor\. |

| Fields | |
| :--- | :--- |
| [\_logger](CatStepProcessor._logger.md 'Cat\.FluentWorkflows\.CatStepProcessor\.\_logger') | |
| [\_serviceProvider](CatStepProcessor._serviceProvider.md 'Cat\.FluentWorkflows\.CatStepProcessor\.\_serviceProvider') | |

| Methods | |
| :--- | :--- |
| [RunStepsAsync&lt;TWorkflowState&gt;\(ICatWorkflowBuilder&lt;TWorkflowState&gt;, TWorkflowState, CancellationToken\)](CatStepProcessor.RunStepsAsync.X9T5P5646TC85HDMBJ8KD0KQ2.md 'Cat\.FluentWorkflows\.CatStepProcessor\.RunStepsAsync\<TWorkflowState\>\(Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>, TWorkflowState, System\.Threading\.CancellationToken\)') | Runs the steps of a builder in order\. It stops after a step that returns a break result\. |
