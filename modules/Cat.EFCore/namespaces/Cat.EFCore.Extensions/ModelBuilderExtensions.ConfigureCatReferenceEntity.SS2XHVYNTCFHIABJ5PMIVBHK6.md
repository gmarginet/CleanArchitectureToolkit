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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EFCORE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EFCore\.Extensions Assembly](index.md 'index') >> [Cat\.EFCore\.Extensions Namespace](Cat.EFCore.Extensions.md 'Cat\.EFCore\.Extensions') >> [ModelBuilderExtensions Class](ModelBuilderExtensions.md 'Cat\.EFCore\.Extensions\.ModelBuilderExtensions')

## ModelBuilderExtensions\.ConfigureCatReferenceEntity\<TEntity\>\(this ModelBuilder, string, string\) Method

Configures a reference data entity\.
Sets a non\-clustered primary key and excludes the table from migrations\.

```csharp
public static void ConfigureCatReferenceEntity<TEntity>(this Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder, string tableName, string schemaName="dbo")
    where TEntity : Cat.EFCore.Entities.CatReferenceEntityBase;
```
#### Type parameters

<a name='Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatReferenceEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,string).TEntity'></a>

`TEntity`

The entity type\.
#### Parameters

<a name='Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatReferenceEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,string).modelBuilder'></a>

`modelBuilder` [Microsoft\.EntityFrameworkCore\.ModelBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.modelbuilder 'Microsoft\.EntityFrameworkCore\.ModelBuilder')

The model builder to configure\.

<a name='Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatReferenceEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,string).tableName'></a>

`tableName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the table\.

<a name='Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatReferenceEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,string).schemaName'></a>

`schemaName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the schema\. Defaults to `dbo`\.