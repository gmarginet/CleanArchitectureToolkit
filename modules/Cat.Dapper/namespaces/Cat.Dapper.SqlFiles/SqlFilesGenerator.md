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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.DAPPER](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Dapper\.SqlFiles Assembly](index.md 'index') >> [Cat\.Dapper\.SqlFiles Namespace](Cat.Dapper.SqlFiles.md 'Cat\.Dapper\.SqlFiles')

## SqlFilesGenerator Class

Creates a `private const string` in a handler class for each `.sql` file next to it\.
`OrderOverviewQueryHandler.sql` gives the constant `Sql`, and
`OrderOverviewQueryHandler.Count.sql` gives `CountSql`\.

```csharp
public sealed class SqlFilesGenerator
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.CodeAnalysis\.IIncrementalGenerator](https://learn.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.iincrementalgenerator 'Microsoft\.CodeAnalysis\.IIncrementalGenerator') → SqlFilesGenerator

| Fields | |
| :--- | :--- |
| [Category](SqlFilesGenerator.Category.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.Category') | |
| [ClassNotPartial](SqlFilesGenerator.ClassNotPartial.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.ClassNotPartial') | |
| [ConstantExists](SqlFilesGenerator.ConstantExists.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.ConstantExists') | |
| [InvalidName](SqlFilesGenerator.InvalidName.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.InvalidName') | |
| [NoMatchingClass](SqlFilesGenerator.NoMatchingClass.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.NoMatchingClass') | |

| Methods | |
| :--- | :--- |
| [Generate\(SourceProductionContext, ImmutableArray&lt;SqlFile&gt;, ImmutableArray&lt;ClassInfo&gt;\)](SqlFilesGenerator.Generate.GSPKSJI4P19GEA1ZTSCY8G395.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.Generate\(SourceProductionContext, System\.Collections\.Immutable\.ImmutableArray\<Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.SqlFile\>, System\.Collections\.Immutable\.ImmutableArray\<Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.ClassInfo\>\)') | |
| [Initialize\(IncrementalGeneratorInitializationContext\)](SqlFilesGenerator.Initialize.5X18BGZIJGGUV3LZ8Q763L554.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.Initialize\(IncrementalGeneratorInitializationContext\)') | |
| [Normalize\(string\)](SqlFilesGenerator.Normalize.HUIC8GB5WYJWOPKXPVGNU2FE2.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.Normalize\(string\)') | |
| [Render\(ClassInfo, string, string\)](SqlFilesGenerator.Render.UVY8DM4JYKL5USKRS2AZH7HF.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.Render\(Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.ClassInfo, string, string\)') | |
