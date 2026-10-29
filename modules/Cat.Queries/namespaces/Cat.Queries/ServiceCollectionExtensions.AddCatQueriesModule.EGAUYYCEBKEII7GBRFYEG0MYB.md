<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Queries](index.md 'index') > [Cat\.Queries\.Extensions](Cat.Queries.Extensions.md 'Cat\.Queries\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.Queries\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatQueriesModule\(this IServiceCollection, Type\[\]\) Method

Registers the query processor and every query handler found in the given assemblies\.
Handlers get a scoped lifetime\. Open generic handlers are skipped\.
Registers the decorators module too, unless it is already registered\.

```csharp
public static void AddCatQueriesModule(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, params System.Type[] types);
```
#### Parameters

<a name='Cat.Queries.Extensions.ServiceCollectionExtensions.AddCatQueriesModule(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type[]).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.Queries.Extensions.ServiceCollectionExtensions.AddCatQueriesModule(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type[]).types'></a>

`types` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

One type from each assembly to scan for handlers\.