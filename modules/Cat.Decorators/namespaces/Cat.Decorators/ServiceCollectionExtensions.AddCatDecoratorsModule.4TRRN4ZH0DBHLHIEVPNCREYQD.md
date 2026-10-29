<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Decorators](index.md 'index') > [Cat\.Decorators\.Extensions](Cat.Decorators.Extensions.md 'Cat\.Decorators\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.Decorators\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatDecoratorsModule\(this IServiceCollection\) Method

Registers the decorator factory and its builder\.
Safe to call more than once\. A service that is already registered is skipped\.

```csharp
public static void AddCatDecoratorsModule(this Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Parameters

<a name='Cat.Decorators.Extensions.ServiceCollectionExtensions.AddCatDecoratorsModule(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.