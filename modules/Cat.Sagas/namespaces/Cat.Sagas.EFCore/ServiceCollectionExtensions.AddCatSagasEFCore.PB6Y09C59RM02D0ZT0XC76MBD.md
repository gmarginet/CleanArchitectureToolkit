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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.SAGAS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Sagas\.EFCore Assembly](index.md 'index') >> [Cat\.Sagas\.EFCore\.Extensions Namespace](Cat.Sagas.EFCore.Extensions.md 'Cat\.Sagas\.EFCore\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Sagas\.EFCore\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatSagasEFCore\<TDbContext\>\(this IServiceCollection\) Method

Registers the saga store on the given context\. It replaces the store in memory\.
The context must call [AddCatSagas\(this ModelBuilder\)](ModelBuilderExtensions.AddCatSagas.ONPE2ELDHBFDVCG1E70SN9QN8.md 'Cat\.Sagas\.EFCore\.ModelBuilderExtensions\.AddCatSagas\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)') in `OnModelCreating`\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatSagasEFCore<TDbContext>(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext;
```
#### Type parameters

<a name='Cat.Sagas.EFCore.Extensions.ServiceCollectionExtensions.AddCatSagasEFCore_TDbContext_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TDbContext'></a>

`TDbContext`

The context of the service that holds the saga table\.
#### Parameters

<a name='Cat.Sagas.EFCore.Extensions.ServiceCollectionExtensions.AddCatSagasEFCore_TDbContext_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, so calls can be chained\.