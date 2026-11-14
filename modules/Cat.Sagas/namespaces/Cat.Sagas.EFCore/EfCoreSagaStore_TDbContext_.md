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
  
##### >> [Cat\.Sagas\.EFCore Assembly](index.md 'index') >> [Cat\.Sagas\.EFCore Namespace](Cat.Sagas.EFCore.md 'Cat\.Sagas\.EFCore')

## EfCoreSagaStore\<TDbContext\> Class

[ICatSagaStore](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaStore.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore') on a `DbContext` of the service\. Every call saves at once with `SaveChangesAsync`,
            so other pending changes of the context are saved with it\.

```csharp
internal sealed class EfCoreSagaStore<TDbContext> : Cat.Sagas.Abstractions.ICatSagaStore
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
```
#### Type parameters

<a name='Cat.Sagas.EFCore.EfCoreSagaStore_TDbContext_.TDbContext'></a>

`TDbContext`

The context that holds the saga table, see [AddCatSagas\(this ModelBuilder\)](ModelBuilderExtensions.AddCatSagas.ONPE2ELDHBFDVCG1E70SN9QN8.md 'Cat\.Sagas\.EFCore\.ModelBuilderExtensions\.AddCatSagas\(this Microsoft\.EntityFrameworkCore\.ModelBuilder\)')\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → EfCoreSagaStore\<TDbContext\>

Implements [ICatSagaStore](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/ICatSagaStore.md 'Cat\.Sagas\.Abstractions\.ICatSagaStore')

| Constructors | |
| :--- | :--- |
| [EfCoreSagaStore\(TDbContext\)](EfCoreSagaStore_TDbContext_..ctor.UJLT52TPJ7ZDQ4IWMLR8AWCMD.md 'Cat\.Sagas\.EFCore\.EfCoreSagaStore\<TDbContext\>\.EfCoreSagaStore\(TDbContext\)') | Creates the store\. |

| Fields | |
| :--- | :--- |
| [\_dbContext](EfCoreSagaStore_TDbContext_._dbContext.md 'Cat\.Sagas\.EFCore\.EfCoreSagaStore\<TDbContext\>\.\_dbContext') | |

| Methods | |
| :--- | :--- |
| [AddAsync\(CatSagaInstance, CancellationToken\)](EfCoreSagaStore_TDbContext_.AddAsync.PJPLUY5R86E5DSRGSEVF0YBS1.md 'Cat\.Sagas\.EFCore\.EfCoreSagaStore\<TDbContext\>\.AddAsync\(Cat\.Sagas\.Abstractions\.CatSagaInstance, System\.Threading\.CancellationToken\)') | Saves a new instance with [Version](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaInstance.Version.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Version') 1\. |
| [FindAsync\(Guid, CancellationToken\)](EfCoreSagaStore_TDbContext_.FindAsync.CSZERNL2D2R8Q6SKJPVWKI90D.md 'Cat\.Sagas\.EFCore\.EfCoreSagaStore\<TDbContext\>\.FindAsync\(System\.Guid, System\.Threading\.CancellationToken\)') | Finds an instance\. |
| [UpdateAsync\(CatSagaInstance, CancellationToken\)](EfCoreSagaStore_TDbContext_.UpdateAsync.P7UFYPIDOYSD10NSOMPIP0VFC.md 'Cat\.Sagas\.EFCore\.EfCoreSagaStore\<TDbContext\>\.UpdateAsync\(Cat\.Sagas\.Abstractions\.CatSagaInstance, System\.Threading\.CancellationToken\)') | Saves the changes of an instance and raises [Version](../../../Cat.Sagas/namespaces/Cat.Sagas.Abstractions/CatSagaInstance.Version.md 'Cat\.Sagas\.Abstractions\.CatSagaInstance\.Version') by one\. |
