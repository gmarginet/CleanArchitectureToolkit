<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatStepProcessor](CatStepProcessor.md 'Cat\.FluentWorkflows\.CatStepProcessor')

## CatStepProcessor\(IServiceProvider, ILogger\<CatStepProcessor\>\) Constructor

Creates the processor\.

```csharp
public CatStepProcessor(System.IServiceProvider serviceProvider, Microsoft.Extensions.Logging.ILogger<Cat.FluentWorkflows.CatStepProcessor> logger);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatStepProcessor.CatStepProcessor(System.IServiceProvider,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.CatStepProcessor_).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Gives the step bodies\. Every step body must be registered\.

<a name='Cat.FluentWorkflows.CatStepProcessor.CatStepProcessor(System.IServiceProvider,Microsoft.Extensions.Logging.ILogger_Cat.FluentWorkflows.CatStepProcessor_).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[CatStepProcessor](CatStepProcessor.md 'Cat\.FluentWorkflows\.CatStepProcessor')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

Logs problems with inputs and outputs\.