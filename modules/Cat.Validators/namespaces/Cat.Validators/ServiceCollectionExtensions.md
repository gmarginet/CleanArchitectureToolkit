<link href="../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.Validators](index.md 'index') > [Cat\.Validators\.Extensions](Cat.Validators.Extensions.md 'Cat\.Validators\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the validators module\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatValidatorsModule\(this IServiceCollection, Type\[\]\)](ServiceCollectionExtensions.AddCatValidatorsModule.UP0HIMEZAZL9NPVW22XHBSTF.md 'Cat\.Validators\.Extensions\.ServiceCollectionExtensions\.AddCatValidatorsModule\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\[\]\)') | Registers the validator processor and every validator found in the given assemblies\. Validators get a scoped lifetime\. Open generic validators are skipped\. The module also needs the compiled member expression cache from Cat\.Expressions\. |
