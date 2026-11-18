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

## CatEntityConfigurator Class

Holds the part of the Cat table setup that every database shares\.
The provider projects call it and add the calls that only their database knows\.

```csharp
internal static class CatEntityConfigurator
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatEntityConfigurator

| Methods | |
| :--- | :--- |
| [ConfigureCatEntityBase&lt;TEntity&gt;\(ModelBuilder, string, string, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;, Action&lt;TableBuilder&lt;TEntity&gt;&gt;\)](CatEntityConfigurator.ConfigureCatEntityBase.9J0CA6RC2NRLPIQGZT2S2H062.md 'Cat\.EFCore\.Extensions\.CatEntityConfigurator\.ConfigureCatEntityBase\<TEntity\>\(Microsoft\.EntityFrameworkCore\.ModelBuilder, string, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.TableBuilder\<TEntity\>\>\)') | Configures the table and makes [SequenceId](../../../Cat.EFCore/namespaces/Cat.EFCore.Entities/CatEntityBase.SequenceId.md 'Cat\.EFCore\.Entities\.CatEntityBase\.SequenceId') read\-only after the first save\. Then runs the calls of the database provider and the extra configuration of the developer, in that order\. |
| [ConfigureCatReferenceEntityBase&lt;TEntity&gt;\(ModelBuilder, string, string, Action&lt;EntityTypeBuilder&lt;TEntity&gt;&gt;\)](CatEntityConfigurator.ConfigureCatReferenceEntityBase.DQ1YGIJRZ2BJ4O3U8JJIJBPQ9.md 'Cat\.EFCore\.Extensions\.CatEntityConfigurator\.ConfigureCatReferenceEntityBase\<TEntity\>\(Microsoft\.EntityFrameworkCore\.ModelBuilder, string, string, System\.Action\<Microsoft\.EntityFrameworkCore\.Metadata\.Builders\.EntityTypeBuilder\<TEntity\>\>\)') | Configures a table that someone else owns and excludes it from migrations\. Then runs the configuration of the database provider, which sets the key on [Id](../../../Cat.EFCore/namespaces/Cat.EFCore.Entities/CatReferenceEntityBase.Id.md 'Cat\.EFCore\.Entities\.CatReferenceEntityBase\.Id')\. |
