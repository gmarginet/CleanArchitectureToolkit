<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Queries](index.md 'index') > [Cat\.FluentWorkflows\.Queries](Cat.FluentWorkflows.Queries.md 'Cat\.FluentWorkflows\.Queries') > [CatWorkflowBuilderExtensions](CatWorkflowBuilderExtensions.md 'Cat\.FluentWorkflows\.Queries\.CatWorkflowBuilderExtensions')

## CatWorkflowBuilderExtensions\.ProcessQuery\<TWorkflowState,TQuery,TResult\>\(this ICatWorkflowBuilder\<TWorkflowState\>\) Method

Adds a step that processes a query\.
The query is created with its parameterless constructor\. Fill it with `Input`, like `.Input(s => s.Id, step => step.Query.Id)`\.
Read the result with `Output`, like `.Output(step => step.Response!.Value, s => s.Todo)`\.
A failed query ends the workflow with BreakCascade and the errors of the query\.

```csharp
public static Cat.FluentWorkflows.Abstractions.ICatStepBuilder<TWorkflowState,Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep<TQuery,TResult>> ProcessQuery<TWorkflowState,TQuery,TResult>(this Cat.FluentWorkflows.Abstractions.ICatWorkflowBuilder<TWorkflowState> builder)
    where TWorkflowState : class, Cat.FluentWorkflows.Abstractions.ICatWorkflowState<TWorkflowState>
    where TQuery : class, Cat.Queries.Abstractions.ICatQuery<TResult>;
```
#### Type parameters

<a name='Cat.FluentWorkflows.Queries.CatWorkflowBuilderExtensions.ProcessQuery_TWorkflowState,TQuery,TResult_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState'></a>

`TWorkflowState`

The state of the workflow\.

<a name='Cat.FluentWorkflows.Queries.CatWorkflowBuilderExtensions.ProcessQuery_TWorkflowState,TQuery,TResult_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TQuery'></a>

`TQuery`

The query to process\.

<a name='Cat.FluentWorkflows.Queries.CatWorkflowBuilderExtensions.ProcessQuery_TWorkflowState,TQuery,TResult_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TResult'></a>

`TResult`

The type of the data the query returns\.
#### Parameters

<a name='Cat.FluentWorkflows.Queries.CatWorkflowBuilderExtensions.ProcessQuery_TWorkflowState,TQuery,TResult_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).builder'></a>

`builder` [Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder&lt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')[TWorkflowState](CatWorkflowBuilderExtensions.ProcessQuery.6ZRTRPQSKCKEJKVGSI80Y80L7.md#Cat.FluentWorkflows.Queries.CatWorkflowBuilderExtensions.ProcessQuery_TWorkflowState,TQuery,TResult_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Queries\.CatWorkflowBuilderExtensions\.ProcessQuery\<TWorkflowState,TQuery,TResult\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[&gt;](..\Cat.FluentWorkflows.Abstractions\ICatWorkflowBuilder_TWorkflowState_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\`1')

The builder to add the step to\.

#### Returns
[Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder&lt;](..\Cat.FluentWorkflows.Abstractions\ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[TWorkflowState](CatWorkflowBuilderExtensions.ProcessQuery.6ZRTRPQSKCKEJKVGSI80Y80L7.md#Cat.FluentWorkflows.Queries.CatWorkflowBuilderExtensions.ProcessQuery_TWorkflowState,TQuery,TResult_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TWorkflowState 'Cat\.FluentWorkflows\.Queries\.CatWorkflowBuilderExtensions\.ProcessQuery\<TWorkflowState,TQuery,TResult\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TWorkflowState')[,](..\Cat.FluentWorkflows.Abstractions\ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')[Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep&lt;](CatProcessQueryStep_TQuery,TResult_.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>')[TQuery](CatWorkflowBuilderExtensions.ProcessQuery.6ZRTRPQSKCKEJKVGSI80Y80L7.md#Cat.FluentWorkflows.Queries.CatWorkflowBuilderExtensions.ProcessQuery_TWorkflowState,TQuery,TResult_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TQuery 'Cat\.FluentWorkflows\.Queries\.CatWorkflowBuilderExtensions\.ProcessQuery\<TWorkflowState,TQuery,TResult\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TQuery')[,](CatProcessQueryStep_TQuery,TResult_.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>')[TResult](CatWorkflowBuilderExtensions.ProcessQuery.6ZRTRPQSKCKEJKVGSI80Y80L7.md#Cat.FluentWorkflows.Queries.CatWorkflowBuilderExtensions.ProcessQuery_TWorkflowState,TQuery,TResult_(thisCat.FluentWorkflows.Abstractions.ICatWorkflowBuilder_TWorkflowState_).TResult 'Cat\.FluentWorkflows\.Queries\.CatWorkflowBuilderExtensions\.ProcessQuery\<TWorkflowState,TQuery,TResult\>\(this Cat\.FluentWorkflows\.Abstractions\.ICatWorkflowBuilder\<TWorkflowState\>\)\.TResult')[&gt;](CatProcessQueryStep_TQuery,TResult_.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>')[&gt;](..\Cat.FluentWorkflows.Abstractions\ICatStepBuilder_TWorkflowState,TStepBody_.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepBuilder\`2')  
A builder to connect the step to the state with `Input` and `Output`\.