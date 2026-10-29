<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.FluentWorkflows](index.md 'index') > [Cat\.FluentWorkflows\.Extensions](Cat.FluentWorkflows.Extensions.md 'Cat\.FluentWorkflows\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.FluentWorkflows\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatFluentWorkflowsFlows\(this IServiceCollection, Type\[\]\) Method

Registers every workflow found in the given assemblies, with a transient lifetime\.
Only public classes that are not generic are registered\.

```csharp
public static void AddCatFluentWorkflowsFlows(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, params System.Type[] types);
```
#### Parameters

<a name='Cat.FluentWorkflows.Extensions.ServiceCollectionExtensions.AddCatFluentWorkflowsFlows(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type[]).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.FluentWorkflows.Extensions.ServiceCollectionExtensions.AddCatFluentWorkflowsFlows(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type[]).types'></a>

`types` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

One type from each assembly to scan for workflows\.