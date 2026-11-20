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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EFCORE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EFCore\.Extensions Assembly](index.md 'index') >> [Cat\.EFCore\.Extensions Namespace](Cat.EFCore.Extensions.md 'Cat\.EFCore\.Extensions') >> [DbSetLookupExtensions Class](DbSetLookupExtensions.md 'Cat\.EFCore\.Extensions\.DbSetLookupExtensions')

## DbSetLookupExtensions\.FindBySequenceIdAsync\<TEntity\>\(this DbSet\<TEntity\>, int, CancellationToken\) Method

Finds an entity by its [SequenceId](../../../Cat.EFCore/namespaces/Cat.EFCore.Entities/CatEntityBase.SequenceId.md 'Cat\.EFCore\.Entities\.CatEntityBase\.SequenceId')\. It looks in the change tracker first, and then queries the database\.

```csharp
public static System.Threading.Tasks.ValueTask<TEntity?> FindBySequenceIdAsync<TEntity>(this Microsoft.EntityFrameworkCore.DbSet<TEntity> set, int sequenceId, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken))
    where TEntity : Cat.EFCore.Entities.CatEntityBase;
```
#### Type parameters

<a name='Cat.EFCore.Extensions.DbSetLookupExtensions.FindBySequenceIdAsync_TEntity_(thisMicrosoft.EntityFrameworkCore.DbSet_TEntity_,int,System.Threading.CancellationToken).TEntity'></a>

`TEntity`

The entity type\.
#### Parameters

<a name='Cat.EFCore.Extensions.DbSetLookupExtensions.FindBySequenceIdAsync_TEntity_(thisMicrosoft.EntityFrameworkCore.DbSet_TEntity_,int,System.Threading.CancellationToken).set'></a>

`set` [Microsoft\.EntityFrameworkCore\.DbSet&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1 'Microsoft\.EntityFrameworkCore\.DbSet\`1')[TEntity](DbSetLookupExtensions.FindBySequenceIdAsync.ZHRZES0Z02AETXM9LJ0HJAUKD.md#Cat.EFCore.Extensions.DbSetLookupExtensions.FindBySequenceIdAsync_TEntity_(thisMicrosoft.EntityFrameworkCore.DbSet_TEntity_,int,System.Threading.CancellationToken).TEntity 'Cat\.EFCore\.Extensions\.DbSetLookupExtensions\.FindBySequenceIdAsync\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.DbSet\<TEntity\>, int, System\.Threading\.CancellationToken\)\.TEntity')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1 'Microsoft\.EntityFrameworkCore\.DbSet\`1')

The set to look in\.

<a name='Cat.EFCore.Extensions.DbSetLookupExtensions.FindBySequenceIdAsync_TEntity_(thisMicrosoft.EntityFrameworkCore.DbSet_TEntity_,int,System.Threading.CancellationToken).sequenceId'></a>

`sequenceId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The sequence number to look for\.

<a name='Cat.EFCore.Extensions.DbSetLookupExtensions.FindBySequenceIdAsync_TEntity_(thisMicrosoft.EntityFrameworkCore.DbSet_TEntity_,int,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Token to cancel the work\.

#### Returns
[System\.Threading\.Tasks\.ValueTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')[TEntity](DbSetLookupExtensions.FindBySequenceIdAsync.ZHRZES0Z02AETXM9LJ0HJAUKD.md#Cat.EFCore.Extensions.DbSetLookupExtensions.FindBySequenceIdAsync_TEntity_(thisMicrosoft.EntityFrameworkCore.DbSet_TEntity_,int,System.Threading.CancellationToken).TEntity 'Cat\.EFCore\.Extensions\.DbSetLookupExtensions\.FindBySequenceIdAsync\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.DbSet\<TEntity\>, int, System\.Threading\.CancellationToken\)\.TEntity')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.valuetask-1 'System\.Threading\.Tasks\.ValueTask\`1')  
The tracked entity, or `null` when none has this sequence number\.