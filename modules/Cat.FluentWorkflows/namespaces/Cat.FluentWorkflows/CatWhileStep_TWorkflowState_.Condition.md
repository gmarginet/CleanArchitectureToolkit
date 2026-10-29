<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatWhileStep&lt;TWorkflowState&gt;](CatWhileStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>')

## CatWhileStep\<TWorkflowState\>\.Condition Property

The condition\. It gets the workflow state and is checked before every pass\.

```csharp
public System.Func<TWorkflowState,bool> Condition { get; set; }
```

#### Property Value
[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatWhileStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatWhileStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatWhileStep\<TWorkflowState\>\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')