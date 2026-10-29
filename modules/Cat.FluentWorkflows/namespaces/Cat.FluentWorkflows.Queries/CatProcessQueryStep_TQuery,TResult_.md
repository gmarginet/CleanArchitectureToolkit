<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Queries](index.md 'index') > [Cat\.FluentWorkflows\.Queries\.Steps](Cat.FluentWorkflows.Queries.Steps.md 'Cat\.FluentWorkflows\.Queries\.Steps')

## CatProcessQueryStep\<TQuery,TResult\> Class

Built\-in step behind `ProcessQuery`\. It processes a query with the query processor\.
A succeeded query continues the workflow\. A failed query ends it with BreakCascade and the errors\.

```csharp
public class CatProcessQueryStep<TQuery,TResult> : Cat.FluentWorkflows.CatStepBodyAsync
    where TQuery : class, Cat.Queries.Abstractions.ICatQuery<TResult>
```
#### Type parameters

<a name='Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult_.TQuery'></a>

`TQuery`

The query to process\.

<a name='Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult_.TResult'></a>

`TResult`

The type of the data the query returns\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [CatStepBodyAsync](..\Cat.FluentWorkflows\CatStepBodyAsync.md 'Cat\.FluentWorkflows\.CatStepBodyAsync') &#129106; CatProcessQueryStep\<TQuery,TResult\>

| Constructors | |
| :--- | :--- |
| [CatProcessQueryStep\(ICatQueryProcessor, ILogger&lt;CatProcessQueryStep&lt;TQuery,TResult&gt;&gt;\)](CatProcessQueryStep_TQuery,TResult_..ctor.S1ZP809HZME140VRVUHNT3K17.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.CatProcessQueryStep\(Cat\.Queries\.Abstractions\.ICatQueryProcessor, Microsoft\.Extensions\.Logging\.ILogger\<Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\>\)') | Creates the step and the query, using the parameterless constructor of the query\. |

| Fields | |
| :--- | :--- |
| [\_queryProcessor](CatProcessQueryStep_TQuery,TResult_._queryProcessor.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.\_queryProcessor') | |

| Properties | |
| :--- | :--- |
| [Query](CatProcessQueryStep_TQuery,TResult_.Query.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.Query') | The query to process\. Fill its members with `Input`\. |
| [Response](CatProcessQueryStep_TQuery,TResult_.Response.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.Response') | The response of the query\. Read it with `Output` after the step ran\. |

| Methods | |
| :--- | :--- |
| [RunAsync\(CancellationToken\)](CatProcessQueryStep_TQuery,TResult_.RunAsync.H6NR5NC8VYYIJ2M5DCA4498Q6.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.RunAsync\(System\.Threading\.CancellationToken\)') | Runs the step\. |
