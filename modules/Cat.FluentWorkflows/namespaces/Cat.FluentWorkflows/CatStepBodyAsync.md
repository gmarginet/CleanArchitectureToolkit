<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows')

## CatStepBodyAsync Class

Base class for a step that works asynchronously and doesn't need the workflow state directly\.
Get its data through `Input` and hand results back through `Output`\. Implement [RunAsync\(CancellationToken\)](CatStepBodyAsync.RunAsync.NDIRNNFATTDGG9GCGGAU4GQP1.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.RunAsync\(System\.Threading\.CancellationToken\)')\.

```csharp
public abstract class CatStepBodyAsync : Cat.FluentWorkflows.Abstractions.ICatStepBodyAsync
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatStepBodyAsync

Derived  
&#8627; [CatStepBody](CatStepBody.md 'Cat\.FluentWorkflows\.CatStepBody')  
&#8627; [CatStepBodyAsync&lt;TWorkflowState&gt;](CatStepBodyAsync_TWorkflowState_.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\<TWorkflowState\>')

Implements [ICatStepBodyAsync](..\Cat.FluentWorkflows.Abstractions\ICatStepBodyAsync.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBodyAsync')

| Constructors | |
| :--- | :--- |
| [CatStepBodyAsync\(ILogger\)](CatStepBodyAsync..ctor.Q9L49J6VOF258D2X8RO30MX3D.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.CatStepBodyAsync\(Microsoft\.Extensions\.Logging\.ILogger\)') | Creates the step\. |

| Fields | |
| :--- | :--- |
| [Logger](CatStepBodyAsync.Logger.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.Logger') | The logger of the step\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatStepBodyAsync.RunAsync.NDIRNNFATTDGG9GCGGAU4GQP1.md 'Cat\.FluentWorkflows\.CatStepBodyAsync\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
