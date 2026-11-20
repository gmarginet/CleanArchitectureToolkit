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
  
##### >> [Cat\.Dapper\.PostgreSQL Assembly](index.md 'index') >> [Cat\.Dapper\.PostgreSQL Namespace](Cat.Dapper.PostgreSQL.md 'Cat\.Dapper\.PostgreSQL') >> [ImporterWriter Class](ImporterWriter.md 'Cat\.Dapper\.PostgreSQL\.ImporterWriter')

## ImporterWriter\.WriteTyped\<TValue\>\(NpgsqlBinaryImporter, object, CancellationToken\) Method

```csharp
private static System.Threading.Tasks.Task WriteTyped<TValue>(Npgsql.NpgsqlBinaryImporter importer, object value, System.Threading.CancellationToken cancellationToken);
```
#### Type parameters

<a name='Cat.Dapper.PostgreSQL.ImporterWriter.WriteTyped_TValue_(Npgsql.NpgsqlBinaryImporter,object,System.Threading.CancellationToken).TValue'></a>

`TValue`
#### Parameters

<a name='Cat.Dapper.PostgreSQL.ImporterWriter.WriteTyped_TValue_(Npgsql.NpgsqlBinaryImporter,object,System.Threading.CancellationToken).importer'></a>

`importer` [Npgsql\.NpgsqlBinaryImporter](https://learn.microsoft.com/en-us/dotnet/api/npgsql.npgsqlbinaryimporter 'Npgsql\.NpgsqlBinaryImporter')

<a name='Cat.Dapper.PostgreSQL.ImporterWriter.WriteTyped_TValue_(Npgsql.NpgsqlBinaryImporter,object,System.Threading.CancellationToken).value'></a>

`value` [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object')

<a name='Cat.Dapper.PostgreSQL.ImporterWriter.WriteTyped_TValue_(Npgsql.NpgsqlBinaryImporter,object,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')