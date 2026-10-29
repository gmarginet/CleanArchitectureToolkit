<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatInlineActionStep&lt;TWorkflowState&gt;](CatInlineActionStep_TWorkflowState_.md 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>')

## CatInlineActionStep\<TWorkflowState\>\.Body Property

Your code\. It gets the logger and the workflow state\.

```csharp
public System.Action<Microsoft.Extensions.Logging.ILogger,TWorkflowState> Body { get; set; }
```

#### Property Value
[System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')[,](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')[TWorkflowState](CatInlineActionStep_TWorkflowState_.md#Cat.FluentWorkflows.Steps.CatInlineActionStep_TWorkflowState_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatInlineActionStep\<TWorkflowState\>\.TWorkflowState')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-2 'System\.Action\`2')