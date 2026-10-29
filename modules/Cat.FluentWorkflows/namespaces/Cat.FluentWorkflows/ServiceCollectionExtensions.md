<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Extensions](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the fluent workflows module\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatFluentWorkflowsFlows\(this IServiceCollection, Type\[\]\)](ServiceCollectionExtensions.AddCatFluentWorkflowsFlows.E0KTFKVUMXI85V5BSUOTEJAQ6.md 'Cat\.FluentWorkflows\.Extensions\.ServiceCollectionExtensions\.AddCatFluentWorkflowsFlows\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\[\]\)') | Registers every workflow found in the given assemblies, with a transient lifetime\. Only public classes that are not generic are registered\. |
| [AddCatFluentWorkflowsModule\(this IServiceCollection\)](ServiceCollectionExtensions.AddCatFluentWorkflowsModule.XAL21HCPDBGRTJVEFQRFIRMQE.md 'Cat\.FluentWorkflows\.Extensions\.ServiceCollectionExtensions\.AddCatFluentWorkflowsModule\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Registers the workflow and step processors and every built\-in step\. |
| [AddCatFluentWorkflowsSteps\(this IServiceCollection, Type\[\]\)](ServiceCollectionExtensions.AddCatFluentWorkflowsSteps.MOU9BI7E0SJF8KRDQ0LTX9MR.md 'Cat\.FluentWorkflows\.Extensions\.ServiceCollectionExtensions\.AddCatFluentWorkflowsSteps\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\[\]\)') | Registers every step body found in the given assemblies, with a transient lifetime\. Only public classes that are not generic are registered\. |
