<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatBreakIfStep&lt;TWorkflowState&gt;](CatBreakIfStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>')

## CatBreakIfStep\<TWorkflowState\>\.Check Property

The check\. It gets the logger and the workflow state\.

```csharp
public System.Func<Microsoft.Extensions.Logging.ILogger,TWorkflowState,bool> Check { get; set; }
```

#### Property Value
[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[TWorkflowState](CatBreakIfStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatBreakIfStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatBreakIfStep\<TWorkflowState\>\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-3 'System\.Func\`3')