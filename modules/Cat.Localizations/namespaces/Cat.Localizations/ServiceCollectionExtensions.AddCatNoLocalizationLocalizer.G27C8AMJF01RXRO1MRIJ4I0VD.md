<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Localizations](index.md 'index') > [Cat\.Localizations\.Extensions](Cat.Localizations.Extensions.md 'Cat\.Localizations\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.Localizations\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatNoLocalizationLocalizer\(this IServiceCollection\) Method

Registers [ICatLocalizer](../Cat.Localizations.Abstractions/ICatLocalizer.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer') as a singleton, backed by the no\-op implementation that returns keys as\-is\.

```csharp
public static void AddCatNoLocalizationLocalizer(this Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Parameters

<a name='Cat.Localizations.Extensions.ServiceCollectionExtensions.AddCatNoLocalizationLocalizer(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add the registration to\.