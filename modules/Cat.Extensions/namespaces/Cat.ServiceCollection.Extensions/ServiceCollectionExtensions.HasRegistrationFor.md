<link href="../../../../resources/styles/style.css" rel="stylesheet"/>
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

|&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[CAT.EXTENSIONS](../../README.md)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.ServiceCollection\.Extensions Assembly](index.md 'index') >> [Cat\.ServiceCollection\.Extensions Namespace](Cat.ServiceCollection.Extensions.md 'Cat\.ServiceCollection\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.HasRegistrationFor Method

| Overloads | |
| :--- | :--- |
| [HasRegistrationFor\(this IServiceCollection, Type\)](ServiceCollectionExtensions.HasRegistrationFor.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection,System.Type) 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection, System\.Type\)') | Checks whether the given service type is already registered in the service collection\. An open generic type \(such as `typeof(IRepository<>)`\) matches any registration for that generic definition\. |
| [HasRegistrationFor&lt;TService&gt;\(this IServiceCollection\)](ServiceCollectionExtensions.HasRegistrationFor.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection) 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)') | Checks whether [TService](ServiceCollectionExtensions.HasRegistrationFor.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TService 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)\.TService') is already registered in the service collection\. |

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

Checks whether [TService](ServiceCollectionExtensions.HasRegistrationFor.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TService 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)\.TService') is already registered in the service collection\.

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
`true` if a registration for [TService](ServiceCollectionExtensions.HasRegistrationFor.md#Cat.ServiceCollection.Extensions.ServiceCollectionExtensions.HasRegistrationFor_TService_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TService 'Cat\.ServiceCollection\.Extensions\.ServiceCollectionExtensions\.HasRegistrationFor\<TService\>\(this Microsoft\.Extensions\.DependencyInjection\.IServiceCollection\)\.TService') exists\.