<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Queries](index.md 'index') > [Cat\.FluentWorkflows\.Queries\.Steps](Cat.FluentWorkflows.Queries.Steps.md 'Cat\.FluentWorkflows\.Queries\.Steps') > [CatProcessQueryStep&lt;TQuery,TResult&gt;](CatProcessQueryStep_TQuery,TResult_.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>')

## CatProcessQueryStep\(ICatQueryProcessor, ILogger\<CatProcessQueryStep\<TQuery,TResult\>\>\) Constructor

Creates the step and the query, using the parameterless constructor of the query\.

```csharp
public CatProcessQueryStep(Cat.Queries.Abstractions.ICatQueryProcessor queryProcessor, Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep<TQuery,TResult>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult_.CatProcessQueryStep(Cat.Queries.Abstractions.ICatQueryProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult__).queryProcessor'></a>

`queryProcessor` [ICatQueryProcessor](../Cat.Queries.Abstractions/ICatQueryProcessor.md 'Cat\.Queries\.Abstractions\.ICatQueryProcessor')

Processes the query\.

<a name='Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult_.CatProcessQueryStep(Cat.Queries.Abstractions.ICatQueryProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep&lt;](CatProcessQueryStep_TQuery,TResult_.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>')[TQuery](CatProcessQueryStep_TQuery,TResult_.md#Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult_.TQuery 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.TQuery')[,](CatProcessQueryStep_TQuery,TResult_.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>')[TResult](CatProcessQueryStep_TQuery,TResult_.md#Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult_.TResult 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.TResult')[&gt;](CatProcessQueryStep_TQuery,TResult_.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\.