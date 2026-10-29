<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators\.Extensions](Cat.EventAggregators.Extensions.md 'Cat\.EventAggregators\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.EventAggregators\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatEventAggregatorsModule\(this IServiceCollection\) Method

Registers [ICatEventAggregator](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator') as a singleton, backed by the module's default implementation\.

```csharp
public static void AddCatEventAggregatorsModule(this Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Parameters

<a name='Cat.EventAggregators.Extensions.ServiceCollectionExtensions.AddCatEventAggregatorsModule(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add the registration to\.