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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.OUTBOX](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Outbox\.EFCore Assembly](index.md 'index') >> [Cat\.Outbox\.EFCore\.Extensions Namespace](Cat.Outbox.EFCore.Extensions.md 'Cat\.Outbox\.EFCore\.Extensions') >> [ServiceCollectionExtensions Class](ServiceCollectionExtensions.md 'Cat\.Outbox\.EFCore\.Extensions\.ServiceCollectionExtensions')

## ServiceCollectionExtensions\.AddCatOutboxEfCore\<TDbContext\>\(this IServiceCollection\) Method

Registers the EF Core outbox store on the given context\.
The context must call [AddCatOutbox\(this ModelBuilder\)](ModelBuilderExtensions.AddCatOutbox.4MBVYQYL34QU6L00E6KOBZ401.md 'Cat\.Outbox\.EFCore\.ModelBuilderExtensions\.AddCatOutbox\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)') in `OnModelCreating`\.

```csharp
public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddCatOutboxEfCore<TDbContext>(this Microsoft.Extensions.DependencyInjection.IServiceCollection services)
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext;
```
#### Type parameters

<a name='Cat.Outbox.EFCore.Extensions.ServiceCollectionExtensions.AddCatOutboxEfCore_TDbContext_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).TDbContext'></a>

`TDbContext`

The context of the service that holds the outbox table\.
#### Parameters

<a name='Cat.Outbox.EFCore.Extensions.ServiceCollectionExtensions.AddCatOutboxEfCore_TDbContext_(thisMicrosoft.Extensions.DependencyInjection.IServiceCollection).services'></a>

`services` [Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')

The service collection to add to\.

#### Returns
[Microsoft\.Extensions\.DependencyInjection\.IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection 'Microsoft\.Extensions\.DependencyInjection\.IServiceCollection')  
The same service collection, so calls can be chained\.