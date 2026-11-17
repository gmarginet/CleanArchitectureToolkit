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
  
##### >> [Cat\.Dapper\.SqlFiles Assembly](index.md 'index') >> [Cat\.Dapper\.SqlFiles Namespace](Cat.Dapper.SqlFiles.md 'Cat\.Dapper\.SqlFiles') >> [SqlFilesGenerator Class](SqlFilesGenerator.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator')

## SqlFilesGenerator\.Generate\(SourceProductionContext, ImmutableArray\<SqlFile\>, ImmutableArray\<ClassInfo\>\) Method

```csharp
private static void Generate(SourceProductionContext output, System.Collections.Immutable.ImmutableArray<Cat.Dapper.SqlFiles.SqlFilesGenerator.SqlFile> files, System.Collections.Immutable.ImmutableArray<Cat.Dapper.SqlFiles.SqlFilesGenerator.ClassInfo> classes);
```
#### Parameters

<a name='Cat.Dapper.SqlFiles.SqlFilesGenerator.Generate(SourceProductionContext,System.Collections.Immutable.ImmutableArray_Cat.Dapper.SqlFiles.SqlFilesGenerator.SqlFile_,System.Collections.Immutable.ImmutableArray_Cat.Dapper.SqlFiles.SqlFilesGenerator.ClassInfo_).output'></a>

`output` [Microsoft\.CodeAnalysis\.SourceProductionContext](https://learn.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.sourceproductioncontext 'Microsoft\.CodeAnalysis\.SourceProductionContext')

<a name='Cat.Dapper.SqlFiles.SqlFilesGenerator.Generate(SourceProductionContext,System.Collections.Immutable.ImmutableArray_Cat.Dapper.SqlFiles.SqlFilesGenerator.SqlFile_,System.Collections.Immutable.ImmutableArray_Cat.Dapper.SqlFiles.SqlFilesGenerator.ClassInfo_).files'></a>

`files` [System\.Collections\.Immutable\.ImmutableArray&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray-1 'System\.Collections\.Immutable\.ImmutableArray\`1')[SqlFile](SqlFilesGenerator.SqlFile.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.SqlFile')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray-1 'System\.Collections\.Immutable\.ImmutableArray\`1')

<a name='Cat.Dapper.SqlFiles.SqlFilesGenerator.Generate(SourceProductionContext,System.Collections.Immutable.ImmutableArray_Cat.Dapper.SqlFiles.SqlFilesGenerator.SqlFile_,System.Collections.Immutable.ImmutableArray_Cat.Dapper.SqlFiles.SqlFilesGenerator.ClassInfo_).classes'></a>

`classes` [System\.Collections\.Immutable\.ImmutableArray&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray-1 'System\.Collections\.Immutable\.ImmutableArray\`1')[ClassInfo](SqlFilesGenerator.ClassInfo.md 'Cat\.Dapper\.SqlFiles\.SqlFilesGenerator\.ClassInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray-1 'System\.Collections\.Immutable\.ImmutableArray\`1')