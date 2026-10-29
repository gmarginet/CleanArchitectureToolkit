<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Queries](index.md 'index') > [Cat\.FluentWorkflows\.Queries\.Steps](Cat.FluentWorkflows.Queries.Steps.md 'Cat\.FluentWorkflows\.Queries\.Steps') > [CatProcessQueryStep&lt;TQuery,TResult&gt;](CatProcessQueryStep_TQuery,TResult_.md 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>')

## CatProcessQueryStep\<TQuery,TResult\>\.Response Property

The response of the query\. Read it with `Output` after the step ran\.

```csharp
public Cat.Responses.Abstractions.ICatResponse<TResult>? Response { get; private set; }
```

#### Property Value
[Cat\.Responses\.Abstractions\.ICatResponse&lt;](../Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')[TResult](CatProcessQueryStep_TQuery,TResult_.md#Cat.FluentWorkflows.Queries.Steps.CatProcessQueryStep_TQuery,TResult_.TResult 'Cat\.FluentWorkflows\.Queries\.Steps\.CatProcessQueryStep\<TQuery,TResult\>\.TResult')[&gt;](../Cat.Responses.Abstractions/ICatResponse_TResponse_.md 'Cat\.Responses\.Abstractions\.ICatResponse\`1')