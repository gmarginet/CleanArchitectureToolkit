<link href="../../../resources/styles/style.css" rel="stylesheet"></link>  
  
# `Clean Architecture Toolkit for .NET`  
  
[CAT](../../../../README.md 'Readme of the CAT project\.')  
[Module](../../README.md 'Readme of the module\.')  
[Module overview](../../../../README.md#module-overview 'List of all the CAT modules\.')  
  
# `Class Reference`  
  
##### > [Cat\.ServiceCollection\.Extensions](index.md 'index') > [Cat\.ServiceCollection\.Extensions](Cat.ServiceCollection.Extensions.md 'Cat\.ServiceCollection\.Extensions') > [ServiceCollectionExtensions](ServiceCollectionExtensions.md 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.HasRegistrationFor Method

| Overloads | |
| :--- | :--- |
| [HasRegistrationFor\(this IServiceCollection, Type\)](ServiceCollectionExtensions.HasRegistrationFor.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type) 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\)') | Checks whether the given service type is already registered in the service collection\. An open generic type \(such as `typeof(IRepository<>)`\) matches any registration for that generic definition\. |
| [HasRegistrationFor&lt;TService&gt;\(this IServiceCollection\)](ServiceCollectionExtensions.HasRegistrationFor.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection) 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Checks whether [TService](ServiceCollectionExtensions.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TService 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)\.TService') is already registered in the service collection\. |

<a name='Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type)'></a>

## ServiceCollectionExtensions\.HasRegistrationFor\(this IServiceCollection, Type\) Method

Checks whether the given service type is already registered in the service collection\. An open generic type
\(such as `typeof(IRepository<>)`\) matches any registration for that generic definition\.

```csharp
public static bool HasRegistrationFor(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Type serviceType);
```
#### Parameters

<a name='Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to check\.

<a name='Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type).serviceType'></a>

`serviceType` [System\.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type 'System\.Type')

The service type to look for\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if a matching registration exists\.

<a name='Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection)'></a>

## ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this IServiceCollection\) Method

Checks whether [TService](ServiceCollectionExtensions.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TService 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)\.TService') is already registered in the service collection\.

```csharp
public static bool HasRegistrationFor<TService>(this Microsoft.Extensions.DependencyInjection.IServiceCollection services);
```
#### Type parameters

<a name='Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TService'></a>

`TService`

The service type to look for\.
#### Parameters

<a name='Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to check\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
`true` if a registration for [TService](ServiceCollectionExtensions.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TService 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)\.TService') exists\.