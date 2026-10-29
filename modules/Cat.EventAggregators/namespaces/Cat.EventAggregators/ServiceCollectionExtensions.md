<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.EventAggregators](index.md 'index') > [Cat\.EventAggregators\.Extensions](Cat.EventAggregators.Extensions.md 'Cat\.EventAggregators\.Extensions')

## ServiceCollectionExtensions Class

Registers the Cat EventAggregators module in the dependency injection container\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatEventAggregatorsModule\(this IServiceCollection\)](ServiceCollectionExtensions.AddCatEventAggregatorsModule.59Z792S5B98CTA1K54OTCSOH7.md 'Cat\.EventAggregators\.Extensions\.ServiceCollectionExtensions\.AddCatEventAggregatorsModule\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Registers [ICatEventAggregator](../../../Cat.EventAggregators/namespaces/Cat.EventAggregators.Abstractions/ICatEventAggregator.md 'Cat\.EventAggregators\.Abstractions\.ICatEventAggregator') as a singleton, backed by the module's default implementation\. |
