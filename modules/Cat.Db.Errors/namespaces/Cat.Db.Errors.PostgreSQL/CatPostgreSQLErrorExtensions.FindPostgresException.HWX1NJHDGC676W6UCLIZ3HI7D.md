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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.DB.ERRORS](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.Db\.Errors\.PostgreSQL Assembly](index.md 'index') >> [Cat\.Db\.Errors\.PostgreSQL Namespace](Cat.Db.Errors.PostgreSQL.md 'Cat\.Db\.Errors\.PostgreSQL') >> [CatPostgreSQLErrorExtensions Class](CatPostgreSQLErrorExtensions.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions')

## CatPostgreSQLErrorExtensions\.FindPostgresException\(this Exception\) Method

Finds the first [Npgsql\.PostgresException](https://learn.microsoft.com/en-us/dotnet/api/npgsql.postgresexception 'Npgsql\.PostgresException') in the exception chain\.

```csharp
public static Npgsql.PostgresException? FindPostgresException(this System.Exception? exception);
```
#### Parameters

<a name='Cat.Db.Errors.PostgreSQL.CatPostgreSQLErrorExtensions.FindPostgresException(thisSystem.Exception).exception'></a>

`exception` [System\.Exception](https://learn.microsoft.com/en-us/dotnet/api/system.exception 'System\.Exception')

The exception to look at\.

#### Returns
[Npgsql\.PostgresException](https://learn.microsoft.com/en-us/dotnet/api/npgsql.postgresexception 'Npgsql\.PostgresException')  
The PostgreSQL exception, or `null` when the chain has none\.