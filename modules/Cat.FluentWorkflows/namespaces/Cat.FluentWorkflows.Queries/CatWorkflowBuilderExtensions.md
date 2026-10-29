<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows\.Queries](index.md 'index') > [Cat\.FluentWorkflows\.Queries](Cat.FluentWorkflows.Queries.md 'Cat\.FluentWorkflows\.Queries')

## CatWorkflowBuilderExtensions Class

The query step for the workflow builder\.

```csharp
public static class CatWorkflowBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; CatWorkflowBuilderExtensions

| Methods | |
| :--- | :--- |
| [ProcessQuery&lt;TWorkflowState,TQuery,TResult&gt;\(this ICatWorkflowBuilder&lt;TWorkflowState&gt;\)](CatWorkflowBuilderExtensions.ProcessQuery.6ZRTRPQSKCKEJKVGSI80Y80L7.md 'Cat\.FluentWorkflows\.Queries\.CatWorkflowBuilderExtensions\.ProcessQuery\<TWorkflowState,TQuery,TResult\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)') | Adds a step that processes a query\. The query is created with its parameterless constructor\. Fill it with `Input`, like `.Input(s => s.Id, step => step.Query.Id)`\. Read the result with `Output`, like `.Output(step => step.Response!.Value, s => s.Todo)`\. A failed query ends the workflow with BreakCascade and the errors of the query\. |
