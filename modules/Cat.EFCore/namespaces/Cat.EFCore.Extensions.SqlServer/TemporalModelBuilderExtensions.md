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
  
##### >> [Cat\.EFCore\.Extensions\.SqlServer Assembly](index.md 'index') >> [Cat\.EFCore\.Extensions\.SqlServer Namespace](Cat.EFCore.Extensions.SqlServer.md 'Cat\.EFCore\.Extensions\.SqlServer')

## TemporalModelBuilderExtensions Class

Extension methods on [Microsoft\.EntityFrameworkCore\.ModelBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.modelbuilder 'Microsoft\.EntityFrameworkCore\.ModelBuilder') that set up SQL Server temporal tables\.

```csharp
public static class TemporalModelBuilderExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → TemporalModelBuilderExtensions

| Methods | |
| :--- | :--- |
| [ConfigureCatTemporalEntity&lt;TEntity&gt;\(this ModelBuilder, string, string, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;\)](TemporalModelBuilderExtensions.ConfigureCatTemporalEntity.md#Cat.EFCore.Extensions.SqlServer.TemporalModelBuilderExtensions.ConfigureCatTemporalEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__) 'Cat\.EFCore\.Extensions\.SqlServer\.TemporalModelBuilderExtensions\.ConfigureCatTemporalEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, string, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>\)') | Configures a temporal entity with an explicit table name and schema\. The history table gets the same name in the `History` schema\. |
| [ConfigureCatTemporalEntity&lt;TEntity&gt;\(this ModelBuilder, string, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;\)](TemporalModelBuilderExtensions.ConfigureCatTemporalEntity.md#Cat.EFCore.Extensions.SqlServer.TemporalModelBuilderExtensions.ConfigureCatTemporalEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__) 'Cat\.EFCore\.Extensions\.SqlServer\.TemporalModelBuilderExtensions\.ConfigureCatTemporalEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>\)') | Configures a temporal entity with an explicit table name\. The schema comes from the model and falls back to `dbo`\. |
| [ConfigureCatTemporalEntity&lt;TEntity&gt;\(this ModelBuilder, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;\)](TemporalModelBuilderExtensions.ConfigureCatTemporalEntity.md#Cat.EFCore.Extensions.SqlServer.TemporalModelBuilderExtensions.ConfigureCatTemporalEntity_TEntity_(thisMicrosoft.EntityFrameworkCore.ModelBuilder,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__) 'Cat\.EFCore\.Extensions\.SqlServer\.TemporalModelBuilderExtensions\.ConfigureCatTemporalEntity\<TEntity\>\(this Microsoft\.EntityFrameworkCore\.ModelBuilder, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>\)') | Configures a temporal entity with the table name and schema already known to the model\. The history table gets the same name in the `History` schema\. |
