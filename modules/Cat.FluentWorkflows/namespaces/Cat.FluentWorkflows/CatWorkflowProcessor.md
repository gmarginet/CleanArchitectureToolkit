<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatWorkflowProcessor Class

Default [ICatWorkflowProcessor](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor')\.
Gets the workflow from the service provider, builds its steps, and runs them inside a tracing activity\.

```csharp
public class CatWorkflowProcessor : Cat.FluentWorkflows.Abstractions.ICatWorkflowProcessor
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatWorkflowProcessor

Implements [ICatWorkflowProcessor](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowProcessor')

| Constructors | |
| :--- | :--- |
| [CatWorkflowProcessor\(IServiceProvider, ICatStepProcessor\)](CatWorkflowProcessor..ctor.6484LEV7COQPI7DE3ZYGZG8TC.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.CatWorkflowProcessor\(System\.IServiceProvider, Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor\)') | Creates the processor\. |

| Fields | |
| :--- | :--- |
| [\_serviceProvider](CatWorkflowProcessor._serviceProvider.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.\_serviceProvider') | |
| [\_stepProcessor](CatWorkflowProcessor._stepProcessor.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.\_stepProcessor') | |

| Methods | |
| :--- | :--- |
| [RunAsync&lt;TWorkflow,TWorkflowState&gt;\(TWorkflowState, CancellationToken\)](CatWorkflowProcessor.RunAsync.LKKIV0SEAAO6ACSDPU7IZPK9C.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor\.RunAsync\<TWorkflow,TWorkflowState\>\(TWorkflowState, System\.Threading\.CancellationToken\)') | Builds the workflow, runs its steps on the given state and returns the outcome\. A [BreakFromCurrentFlowOnly](..\Cat.FluentWorkflows.Abstractions\CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.BreakFromCurrentFlowOnly 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.BreakFromCurrentFlowOnly') result is reported as [Continue](..\Cat.FluentWorkflows.Abstractions\CatStepExecutionResult.md#Cat.FluentWorkflows.Abstractions.CatStepExecutionResult.Continue 'Cat\.FluentWorkflows\.Abstractions\.CatStepExecutionResult\.Continue')\. |
