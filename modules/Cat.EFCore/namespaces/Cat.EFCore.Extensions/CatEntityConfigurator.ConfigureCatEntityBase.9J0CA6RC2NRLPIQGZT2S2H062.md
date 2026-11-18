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
  
##### >> [Cat\.EFCore\.Extensions Assembly](index.md 'index') >> [Cat\.EFCore\.Extensions Namespace](Cat.EFCore.Extensions.md 'Cat\.EFCore\.Extensions') >> [CatEntityConfigurator Class](CatEntityConfigurator.md 'Cat\.EFCore\.Extensions\.CatEntityConfigurator')

## CatEntityConfigurator\.ConfigureCatEntityBase\<TEntity\>\(ModelBuilder, string, string, Action\<EntityTypeBuilder\<TEntity\>\>, Action\<TableBuilder\<TEntity\>\>\) Method

Configures the table and makes [SequenceId](../../../Cat.EFCore/namespaces/Cat.EFCore.Entities/CatEntityBase.SequenceId.md 'Cat\.EFCore\.Entities\.CatEntityBase\.SequenceId') read\-only after the first save\.
Then runs the calls of the database provider and the extra configuration of the developer, in that order\.

```csharp
internal static void ConfigureCatEntityBase<TEntity>(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder, string tableName, string schemaName, System.Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TEntity>>? entityTypeBuildAction, System.Action<Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder<TEntity>>? tableBuildAction)
    where TEntity : Cat.EFCore.Entities.CatEntityBase;
```
#### Type parameters

<a name='Cat.EFCore.Extensions.CatEntityConfigurator.ConfigureCatEntityBase_TEntity_(Microsoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder_TEntity__).TEntity'></a>

`TEntity`

The entity type\.
#### Parameters

<a name='Cat.EFCore.Extensions.CatEntityConfigurator.ConfigureCatEntityBase_TEntity_(Microsoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder_TEntity__).modelBuilder'></a>

`modelBuilder` [Microsoft\.EntityFrameworkCore\.ModelBuilder](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.modelbuilder 'Microsoft\.EntityFrameworkCore\.ModelBuilder')

The model builder to configure\.

<a name='Cat.EFCore.Extensions.CatEntityConfigurator.ConfigureCatEntityBase_TEntity_(Microsoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder_TEntity__).tableName'></a>

`tableName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the table\.

<a name='Cat.EFCore.Extensions.CatEntityConfigurator.ConfigureCatEntityBase_TEntity_(Microsoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder_TEntity__).schemaName'></a>

`schemaName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the schema\.

<a name='Cat.EFCore.Extensions.CatEntityConfigurator.ConfigureCatEntityBase_TEntity_(Microsoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder_TEntity__).entityTypeBuildAction'></a>

`entityTypeBuildAction` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.metadata.builders.entitytypebuilder-1 'Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\`1')[TEntity](CatEntityConfigurator.ConfigureCatEntityBase.9J0CA6RC2NRLPIQGZT2S2H062.md#Cat.EFCore.Extensions.CatEntityConfigurator.ConfigureCatEntityBase_TEntity_(Microsoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder_TEntity__).TEntity 'Cat\.EFCore\.Extensions\.CatEntityConfigurator\.ConfigureCatEntityBase\<TEntity\>\(Microsoft\.EntityFrameworkCore\.ModelBuilder, string, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.TableBuilder\<TEntity\>\>\)\.TEntity')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.metadata.builders.entitytypebuilder-1 'Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Optional extra configuration for the entity\.

<a name='Cat.EFCore.Extensions.CatEntityConfigurator.ConfigureCatEntityBase_TEntity_(Microsoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder_TEntity__).tableBuildAction'></a>

`tableBuildAction` [System\.Action&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')[Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.TableBuilder&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.metadata.builders.tablebuilder-1 'Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.TableBuilder\`1')[TEntity](CatEntityConfigurator.ConfigureCatEntityBase.9J0CA6RC2NRLPIQGZT2S2H062.md#Cat.EFCore.Extensions.CatEntityConfigurator.ConfigureCatEntityBase_TEntity_(Microsoft.EntityFrameworkCore.ModelBuilder,string,string,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder_TEntity__,System.Action_Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder_TEntity__).TEntity 'Cat\.EFCore\.Extensions\.CatEntityConfigurator\.ConfigureCatEntityBase\<TEntity\>\(Microsoft\.EntityFrameworkCore\.ModelBuilder, string, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.TableBuilder\<TEntity\>\>\)\.TEntity')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.metadata.builders.tablebuilder-1 'Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.TableBuilder\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.action-1 'System\.Action\`1')

Optional extra configuration for the table\.