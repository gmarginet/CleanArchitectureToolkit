<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Commands](index.md 'index') > [Cat\.Commands\.Extensions](Cat.Commands.Extensions.md 'Cat\.Commands\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the commands module\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatCommandsModule\(this IServiceCollection, Type\[\]\)](ServiceCollectionExtensions.AddCatCommandsModule.8NML136E5SKGWLMYG3VLYKK47.md 'Cat\.Commands\.Extensions\.ServiceCollectionExtensions\.AddCatCommandsModule\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\[\]\)') | Registers the command processor and every command handler found in the given assemblies\. Handlers get a scoped lifetime\. Open generic handlers are skipped\. Registers the decorators module too, unless it is already registered\. |
