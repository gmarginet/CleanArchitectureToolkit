<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Localizations](index.md 'index') > [Cat\.Localizations](Cat.Localizations.md 'Cat\.Localizations')

## NoLocalizationCatLocalizer Class

Default [ICatLocalizer](../Cat.Localizations.Abstractions/ICatLocalizer.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer') implementation that performs no localization\. It returns the key as\-is,
only filling in placeholders for the indexer that takes arguments\.

```csharp
internal class NoLocalizationCatLocalizer : Cat.Localizations.Abstractions.ICatLocalizer
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; NoLocalizationCatLocalizer

Implements [ICatLocalizer](../Cat.Localizations.Abstractions/ICatLocalizer.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer')

| Properties | |
| :--- | :--- |
| [this\[string, object\[\]\]](NoLocalizationCatLocalizer.Item.IHK969183C3VM6YLYNFZK3OF9.md 'Cat\.Localizations\.NoLocalizationCatLocalizer\.this\[string, object\[\]\]') | Gets the localized string for the given key, with placeholders filled in from the given arguments\. |
| [this\[string\]](NoLocalizationCatLocalizer.Item.ZCPDRAO0ITIIKJTVX4KRYDR6B.md 'Cat\.Localizations\.NoLocalizationCatLocalizer\.this\[string\]') | Gets the localized string for the given key\. |
