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
  
##### >> [Cat\.Dapper\.PostgreSQL Assembly](index.md 'index') >> [Cat\.Dapper\.PostgreSQL Namespace](Cat.Dapper.PostgreSQL.md 'Cat\.Dapper\.PostgreSQL')

## ImporterWriter Class

Writes a value of any type to a binary importer\. The importer picks the PostgreSQL type from the type of the value,
so the type of the value must match the type of the column\.

```csharp
internal static class ImporterWriter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → ImporterWriter

| Constructors | |
| :--- | :--- |
| [ImporterWriter\(\)](ImporterWriter.ImporterWriter().md 'Cat\.Dapper\.PostgreSQL\.ImporterWriter\.ImporterWriter\(\)') | |

| Fields | |
| :--- | :--- |
| [Writers](ImporterWriter.Writers.md 'Cat\.Dapper\.PostgreSQL\.ImporterWriter\.Writers') | |
| [WriteTypedMethod](ImporterWriter.WriteTypedMethod.md 'Cat\.Dapper\.PostgreSQL\.ImporterWriter\.WriteTypedMethod') | |

| Methods | |
| :--- | :--- |
| [WriteAsync\(NpgsqlBinaryImporter, object, CancellationToken\)](ImporterWriter.WriteAsync.SJ4AP8M5442G8DF99YQ1IISAC.md 'Cat\.Dapper\.PostgreSQL\.ImporterWriter\.WriteAsync\(Npgsql\.NpgsqlBinaryImporter, object, System\.Threading\.CancellationToken\)') | |
| [WriteTyped&lt;TValue&gt;\(NpgsqlBinaryImporter, object, CancellationToken\)](ImporterWriter.WriteTyped.53BZHUDAPGUFI8NGJ6UB9OPCB.md 'Cat\.Dapper\.PostgreSQL\.ImporterWriter\.WriteTyped\<TValue\>\(Npgsql\.NpgsqlBinaryImporter, object, System\.Threading\.CancellationToken\)') | |
