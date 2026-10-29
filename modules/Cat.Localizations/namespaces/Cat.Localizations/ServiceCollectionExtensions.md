<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Localizations](index.md 'index') > [Cat\.Localizations\.Extensions](Cat.Localizations.Extensions.md 'Cat\.Localizations\.Extensions')

## ServiceCollectionExtensions Class

Registers the Cat Localizations module in the dependency injection container\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatNoLocalizationLocalizer\(this IServiceCollection\)](ServiceCollectionExtensions.AddCatNoLocalizationLocalizer.G27C8AMJF01RXRO1MRIJ4I0VD.md 'Cat\.Localizations\.Extensions\.ServiceCollectionExtensions\.AddCatNoLocalizationLocalizer\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Registers [ICatLocalizer](../../../Cat.Localizations/namespaces/Cat.Localizations.Abstractions/ICatLocalizer.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer') as a singleton, backed by the no\-op implementation that returns keys as\-is\. |
