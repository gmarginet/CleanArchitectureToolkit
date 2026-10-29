<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Localizations](index.md 'index')

## Cat\.Localizations Namespace

Provides the default no\-op implementation of [ICatLocalizer](..\Cat.Localizations.Abstractions\ICatLocalizer.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer'),
along with the extension method to register it in a dependency injection container\.

| Classes | |
| :--- | :--- |
| [NoLocalizationCatLocalizer](NoLocalizationCatLocalizer.md 'Cat\.Localizations\.NoLocalizationCatLocalizer') | Default [ICatLocalizer](..\Cat.Localizations.Abstractions\ICatLocalizer.md 'Cat\.Localizations\.Abstractions\.ICatLocalizer') implementation that performs no localization\. It returns the key as\-is, only filling in placeholders for the indexer that takes arguments\. |
