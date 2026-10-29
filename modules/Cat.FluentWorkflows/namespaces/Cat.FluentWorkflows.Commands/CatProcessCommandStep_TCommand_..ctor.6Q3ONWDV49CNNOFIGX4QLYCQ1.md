<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows\.Commands](index.md 'index') > [Cat\.FluentWorkflows\.Commands\.Steps](Cat.FluentWorkflows.Commands.Steps.md 'Cat\.FluentWorkflows\.Commands\.Steps') > [CatProcessCommandStep&lt;TCommand&gt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')

## CatProcessCommandStep\(ICatCommandProcessor, ILogger\<CatProcessCommandStep\<TCommand\>\>\) Constructor

Creates the step and the command, using the parameterless constructor of the command\.

```csharp
public CatProcessCommandStep(Cat.Commands.Abstractions.ICatCommandProcessor commandProcessor, Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep<TCommand>> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand_.CatProcessCommandStep(Cat.Commands.Abstractions.ICatCommandProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand__).commandProcessor'></a>

`commandProcessor` [ICatCommandProcessor](../Cat.Commands.Abstractions/ICatCommandProcessor.md 'Cat\.Commands\.Abstractions\.ICatCommandProcessor')

Processes the command\.

<a name='Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand_.CatProcessCommandStep(Cat.Commands.Abstractions.ICatCommandProcessor,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand__).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep&lt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')[TCommand](CatProcessCommandStep_TCommand_.md#Cat.FluentWorkflows.Commands.Steps.CatProcessCommandStep_TCommand_.TCommand 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>\.TCommand')[&gt;](CatProcessCommandStep_TCommand_.md 'Cat\.FluentWorkflows\.Commands\.Steps\.CatProcessCommandStep\<TCommand\>')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger the step can use\.