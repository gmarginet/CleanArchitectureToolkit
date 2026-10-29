<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Commands](index.md 'index') > [Cat\.FluentWorkflows\.Commands\.Steps](Cat.FluentWorkflows.Commands.Steps.md 'Cat\.FluentWorkflows\.Commands\.Steps') > [CatProcessCommandStep&lt;TCommand&gt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')

## CatProcessCommandStep\<TCommand\>\.Response Property

The response of the command\. Read it with `Output` after the step ran\.

```csharp
public Cat.Responses.Abstractions.ICatResponse? Response { get; private set; }
```

#### Property Value
[ICatResponse](../../../Cat.Responses/namespaces/Cat.Responses.Abstractions/ICatResponse.md 'Cat\.Responses\.Abstractions\.ICatResponse')