<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Steps](Cat.FluentWorkflows.Steps.md 'Cat\.FluentWorkflows\.Steps') > [CatSetStatePropertyStep&lt;TWorkflowState,TProperty&gt;](CatSetStatePropertyStep_TWorkflowState,TProperty_.md 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>')

## CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.StateProperty Property

Picks the property to write\.

```csharp
public System.Linq.Expressions.Expression<System.Func<TWorkflowState,TProperty>> StateProperty { get; set; }
```

#### Property Value
[System\.Linq\.Expressions\.Expression&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')[System\.Func&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TWorkflowState](CatSetStatePropertyStep_TWorkflowState,TProperty_.md#Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TWorkflowState 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.TWorkflowState')[,](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[TProperty](CatSetStatePropertyStep_TWorkflowState,TProperty_.md#Cat.FluentWorkflows.Steps.CatSetStatePropertyStep_TWorkflowState,TProperty_.TProperty 'Cat\.FluentWorkflows\.Steps\.CatSetStatePropertyStep\<TWorkflowState,TProperty\>\.TProperty')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.func-2 'System\.Func\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.linq.expressions.expression-1 'System\.Linq\.Expressions\.Expression\`1')