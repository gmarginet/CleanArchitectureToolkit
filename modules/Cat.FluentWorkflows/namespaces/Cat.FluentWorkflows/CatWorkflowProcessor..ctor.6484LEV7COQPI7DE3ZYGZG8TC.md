<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows](Cat.FluentWorkflows.md 'Cat\.FluentWorkflows') > [CatWorkflowProcessor](CatWorkflowProcessor.md 'Cat\.FluentWorkflows\.CatWorkflowProcessor')

## CatWorkflowProcessor\(IServiceProvider, ICatStepProcessor\) Constructor

Creates the processor\.

```csharp
public CatWorkflowProcessor(System.IServiceProvider serviceProvider, Cat.FluentWorkflows.Abstractions.ICatStepProcessor stepProcessor);
```
#### Parameters

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.CatWorkflowProcessor(System.IServiceProvider,Cat.FluentWorkflows.Abstractions.ICatStepProcessor).serviceProvider'></a>

`serviceProvider` [System\.IServiceProvider](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider 'System\.IServiceProvider')

Gives the workflow\.

<a name='Cat.FluentWorkflows.CatWorkflowProcessor.CatWorkflowProcessor(System.IServiceProvider,Cat.FluentWorkflows.Abstractions.ICatStepProcessor).stepProcessor'></a>

`stepProcessor` [ICatStepProcessor](../../../Cat.FluentWorkflows/namespaces/Cat.FluentWorkflows.Abstractions/ICatStepProcessor.md 'Cat\.FluentWorkflows\.Abstractions\.ICatStepProcessor')

Runs the steps\.