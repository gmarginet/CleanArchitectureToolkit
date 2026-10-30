<link href="../../../../resources/styles/style.css" rel="stylesheet"/>  
  
# Clean Architecture Toolkit for .NET  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# Class Reference  
  
##### > [Cat\.ServiceRequests](index.md 'index') > [Cat\.ServiceRequests\.Extensions](Cat.ServiceRequests.Extensions.md 'Cat\.ServiceRequests\.Extensions')

## ServiceCollectionExtensions Class

Registration helpers for the service requests module\.

```csharp
public static class ServiceCollectionExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ServiceCollectionExtensions

| Methods | |
| :--- | :--- |
| [AddCatServiceRequestsModule\(this IServiceCollection, Type\[\]\)](ServiceCollectionExtensions.AddCatServiceRequestsModule.LPPM554JG953S41TCU6NNOHHC.md 'Cat\.ServiceRequests\.Extensions\.ServiceCollectionExtensions\.AddCatServiceRequestsModule\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\[\]\)') | Registers the service request processor and every service request handler found in the given assemblies\. Handlers get a scoped lifetime\. Open generic handlers are skipped\. Registers the decorators module too, unless it is already registered\. |
