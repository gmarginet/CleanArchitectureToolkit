<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceCollection\.Extensions](index.md 'index') > [Cat\.ServiceCollection\.Extensions](Cat.ServiceCollection.Extensions.md 'Cat\.ServiceCollection\.Extensions')

## ServiceCollectionExtensions Class

Extension methods for inspecting an [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')'s existing registrations\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [HasRegistrationFor\(this IServiceCollection, Type\)](ServiceCollectionExtensions.HasRegistrationFor.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type) 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\)') | Checks whether the given service type is already registered in the service collection\. An open generic type \(such as `typeof(IRepository<>)`\) matches any registration for that generic definition\. |
| [HasRegistrationFor&lt;TService&gt;\(this IServiceCollection\)](ServiceCollectionExtensions.HasRegistrationFor.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection) 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Checks whether [TService](ServiceCollectionExtensions.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TService 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)\.TService') is already registered in the service collection\. |
