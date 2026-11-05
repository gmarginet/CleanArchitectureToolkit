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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.EFCORE](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.EFCore\.Extensions Assembly](index.md 'index') >> [Cat\.EFCore\.Extensions Namespace](Cat.EFCore.Extensions.md 'Cat\.EFCore\.Extensions')

## ModelBuilderExtensions Class

Extension methods on [Microsoft\.EntityFrameworkCore\.ModelBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.modelbuilder 'Microsoft\.EntityFrameworkCore\.ModelBuilder') that apply the standard Cat table setup\.

```csharp
public static class ModelBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ModelBuilderExtensions

| Methods | |
| :--- | :--- |
| [ConfigureCatEntity&lt;TEntity&gt;\(this ModelBuilder, string, string, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;\)](ModelBuilderExtensions.ConfigureCatEntity.md#Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__) 'Cat\.EFCore\.Extensions\.ModelBuilderExtensions\.ConfigureCatEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, string, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>\)') | Configures an entity with an explicit table name and schema\. |
| [ConfigureCatEntity&lt;TEntity&gt;\(this ModelBuilder, string, string, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;, Action&lt;TableBuilder&lt;TEntity&gt;&gt;\)](ModelBuilderExtensions.ConfigureCatEntity.md#Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder_TEntity__) 'Cat\.EFCore\.Extensions\.ModelBuilderExtensions\.ConfigureCatEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, string, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.TableBuilder\<TEntity\>\>\)') | |
| [ConfigureCatEntity&lt;TEntity&gt;\(this ModelBuilder, string, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;\)](ModelBuilderExtensions.ConfigureCatEntity.md#Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__) 'Cat\.EFCore\.Extensions\.ModelBuilderExtensions\.ConfigureCatEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>\)') | Configures an entity with an explicit table name\. The schema comes from the model and falls back to `dbo`\. |
| [ConfigureCatEntity&lt;TEntity&gt;\(this ModelBuilder, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;\)](ModelBuilderExtensions.ConfigureCatEntity.md#Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__) 'Cat\.EFCore\.Extensions\.ModelBuilderExtensions\.ConfigureCatEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>\)') | Configures an entity with the table name and schema already known to the model\. The schema falls back to `dbo`\. Sets the non\-clustered primary key on [Id](../../../Cat.EFCore/namespaces/Cat.EFCore.Entities/CatEntityBase.Id.md 'Cat\.EFCore\.Entities\.CatEntityBase\.Id') and a unique clustered index on the identity column [SequenceId](../../../Cat.EFCore/namespaces/Cat.EFCore.Entities/CatEntityBase.SequenceId.md 'Cat\.EFCore\.Entities\.CatEntityBase\.SequenceId')\. |
| [ConfigureCatReferenceEntity&lt;TEntity&gt;\(this ModelBuilder, string, string\)](ModelBuilderExtensions.ConfigureCatReferenceEntity.SS2XHVYNTCFHIABJ5PMIVBHK6.md 'Cat\.EFCore\.Extensions\.ModelBuilderExtensions\.ConfigureCatReferenceEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, string, string\)') | Configures an entity that maps a table owned by someone else\. Sets a non\-clustered primary key and excludes the table from migrations\. Use it to define foreign keys to a table of another service in a shared database\. |
| [ConfigureCatTemporalEntity&lt;TEntity&gt;\(this ModelBuilder, string, string, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;\)](ModelBuilderExtensions.ConfigureCatTemporalEntity.md#Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatTemporalEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__) 'Cat\.EFCore\.Extensions\.ModelBuilderExtensions\.ConfigureCatTemporalEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, string, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>\)') | Configures a temporal entity with an explicit table name and schema\. The history table gets the same name in the `History` schema\. |
| [ConfigureCatTemporalEntity&lt;TEntity&gt;\(this ModelBuilder, string, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;\)](ModelBuilderExtensions.ConfigureCatTemporalEntity.md#Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatTemporalEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__) 'Cat\.EFCore\.Extensions\.ModelBuilderExtensions\.ConfigureCatTemporalEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>\)') | Configures a temporal entity with an explicit table name\. The schema comes from the model and falls back to `dbo`\. |
| [ConfigureCatTemporalEntity&lt;TEntity&gt;\(this ModelBuilder, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;\)](ModelBuilderExtensions.ConfigureCatTemporalEntity.md#Cat.EFCore.Extensions.ModelBuilderExtensions.ConfigureCatTemporalEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__) 'Cat\.EFCore\.Extensions\.ModelBuilderExtensions\.ConfigureCatTemporalEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>\)') | Configures a temporal entity with the table name and schema already known to the model\. The history table gets the same name in the `History` schema\. |
