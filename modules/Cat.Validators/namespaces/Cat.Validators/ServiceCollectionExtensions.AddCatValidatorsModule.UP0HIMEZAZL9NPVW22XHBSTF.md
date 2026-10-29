<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.Validators\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatValidatorsModule\(this IServiceCollection, Type\[\]\) Method

Registers the validator processor and every validator found in the given assemblies\.
Validators get a scoped lifetime\. Open generic validators are skipped\.
The module also needs the compiled member expression cache from Cat\.Expressions\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatValidatorsModule(this Microsoft.Extensions.DependencyInjection.IServiceCollection collection, params System.Type[] types);
```
#### Parameters

<a name='Cat.Validators.Extensions.ServiceCollectionExtensions.AddCatValidatorsModule(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type[]).collection'></a>

`collection` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

<a name='Cat.Validators.Extensions.ServiceCollectionExtensions.AddCatValidatorsModule(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type[]).types'></a>

`types` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

One type from each assembly to scan for validators\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, so calls can be chained\.