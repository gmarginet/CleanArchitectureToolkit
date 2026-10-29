<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.Minimal\.Api](index.md 'index') > [Cat\.Minimal\.Api\.Extensions](Cat.Minimal.Api.Extensions.md 'Cat\.Minimal\.Api\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.Minimal\.Api\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatMinimalApiModule\(this IServiceCollection\) Method

Registers the exception handler and the problem details services\.
Call `app.UseExceptionHandler()` as well, so the handler catches unexpected exceptions\.

```csharp
public static void AddCatMinimalApiModule(this Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Parameters

<a name='Cat.Minimal.Api.Extensions.ServiceCollectionExtensions.AddCatMinimalApiModule(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.