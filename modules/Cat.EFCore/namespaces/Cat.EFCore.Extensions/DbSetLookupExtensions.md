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
  
##### >> [Cat\.EFCore\.Extensions Assembly](index.md 'index') >> [Cat\.EFCore\.Extensions Namespace](Cat.EFCore.Extensions.md 'Cat\.EFCore\.Extensions')

## DbSetLookupExtensions Class

Lookup methods for entities that derive from [CatEntityBase](../../../Cat.EFCore/namespaces/Cat.EFCore.Entities/CatEntityBase.md 'Cat\.EFCore\.Entities\.CatEntityBase')\.
They give the same result on every database and read the primary key from the EF Core model,
so the code does not depend on which column is the key\.

```csharp
public static class DbSetLookupExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → DbSetLookupExtensions

### Remarks
Use these methods instead of the built\-in `Find`\. An instance method wins over an extension method,
so the extension methods cannot be called `Find`, and `set.Find(guid)` always binds to the built\-in one\.

| Methods | |
| :--- | :--- |
| [FindAsync&lt;TEntity&gt;\(DbSet&lt;TEntity&gt;, string, object, Expression&lt;Func&lt;TEntity,bool&gt;&gt;, CancellationToken\)](DbSetLookupExtensions.FindAsync.XMFUO9HUMJC7H1PY2L3TZ20E.md 'Cat\.EFCore\.Extensions\.DbSetLookupExtensions\.FindAsync\<TEntity\>\(Microsoft\.EntityFrameworkCore\.DbSet\<TEntity\>, string, object, System\.Linq\.Expressions\.Expression\<System\.Func\<TEntity,bool\>\>, System\.Threading\.CancellationToken\)') | |
| [FindByIdAsync&lt;TEntity&gt;\(this DbSet&lt;TEntity&gt;, Guid, CancellationToken\)](DbSetLookupExtensions.FindByIdAsync.K2J387MWRU9SCAJZWL123JZ5A.md 'Cat\.EFCore\.Extensions\.DbSetLookupExtensions\.FindByIdAsync\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.DbSet\<TEntity\>, System\.Guid, System\.Threading\.CancellationToken\)') | Finds an entity by its [Id](../../../Cat.EFCore/namespaces/Cat.EFCore.Entities/CatEntityBase.Id.md 'Cat\.EFCore\.Entities\.CatEntityBase\.Id')\. It looks in the change tracker first, like `Find`, and then queries the database\. |
| [FindBySequenceIdAsync&lt;TEntity&gt;\(this DbSet&lt;TEntity&gt;, int, CancellationToken\)](DbSetLookupExtensions.FindBySequenceIdAsync.ZHRZES0Z02AETXM9LJ0HJAUKD.md 'Cat\.EFCore\.Extensions\.DbSetLookupExtensions\.FindBySequenceIdAsync\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.DbSet\<TEntity\>, int, System\.Threading\.CancellationToken\)') | Finds an entity by its [SequenceId](../../../Cat.EFCore/namespaces/Cat.EFCore.Entities/CatEntityBase.SequenceId.md 'Cat\.EFCore\.Entities\.CatEntityBase\.SequenceId')\. It looks in the change tracker first, and then queries the database\. |
