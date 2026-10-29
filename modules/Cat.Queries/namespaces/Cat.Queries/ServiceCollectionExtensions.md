<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Queries](index.md 'index') > [Cat\.Queries\.Extensions](Cat.Queries.Extensions.md 'Cat\.Queries\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the queries module\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatQueriesModule\(this IServiceCollection, Type\[\]\)](ServiceCollectionExtensions.AddCatQueriesModule.EGAUYYCEBKEII7GBRFYEG0MYB.md 'Cat\.Queries\.Extensions\.ServiceCollectionExtensions\.AddCatQueriesModule\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\[\]\)') | Registers the query processor and every query handler found in the given assemblies\. Handlers get a scoped lifetime\. Open generic handlers are skipped\. Registers the decorators module too, unless it is already registered\. |
