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
  
##### >> [Cat\.Db\.Errors\.PostgreSQL Assembly](index.md 'index') >> [Cat\.Db\.Errors\.PostgreSQL Namespace](Cat.Db.Errors.PostgreSQL.md 'Cat\.Db\.Errors\.PostgreSQL')

## CatPostgreSQLErrorExtensions Class

Extension methods that recognize PostgreSQL errors by their SQLSTATE code\.
Each check looks at the exception itself and at the exceptions inside it, so you can call it on
the `DbUpdateException` of Entity Framework Core as well as on the [Npgsql\.PostgresException](https://learn.microsoft.com/en-us/dotnet/api/npgsql.postgresexception 'Npgsql\.PostgresException') of Dapper\.

```csharp
public static class CatPostgreSQLErrorExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatPostgreSQLErrorExtensions

| Methods | |
| :--- | :--- |
| [FindPostgresException\(this Exception\)](CatPostgreSQLErrorExtensions.FindPostgresException.HWX1NJHDGC676W6UCLIZ3HI7D.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions\.FindPostgresException\(this System\.Exception\)') | Finds the first [Npgsql\.PostgresException](https://learn.microsoft.com/en-us/dotnet/api/npgsql.postgresexception 'Npgsql\.PostgresException') in the exception chain\. |
| [GetSqlState\(this Exception\)](CatPostgreSQLErrorExtensions.GetSqlState.NSH037JBFDL8JV7PJ8ZAC7WN.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions\.GetSqlState\(this System\.Exception\)') | |
| [HasTimeoutException\(this Exception\)](CatPostgreSQLErrorExtensions.HasTimeoutException.CQNSJYW49217SFBPLFK05SBC2.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions\.HasTimeoutException\(this System\.Exception\)') | |
| [IsDeadlock\(this Exception\)](CatPostgreSQLErrorExtensions.IsDeadlock.IUEBL665HXKCFGWMT315D4TZE.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions\.IsDeadlock\(this System\.Exception\)') | The transaction was chosen as the deadlock victim\. Code 40P01\. Running the work again usually helps\. |
| [IsForeignKeyViolation\(this Exception\)](CatPostgreSQLErrorExtensions.IsForeignKeyViolation.AJCQLMEE1FVZFFHD23YYW1QO8.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions\.IsForeignKeyViolation\(this System\.Exception\)') | A foreign key constraint was violated\. Code 23503\. |
| [IsTimeout\(this Exception\)](CatPostgreSQLErrorExtensions.IsTimeout.EKDQY945XKWM0D3ILPLRLVBP.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions\.IsTimeout\(this System\.Exception\)') | A command timed out, the server cancelled the statement, or a lock was not available\. A [System\.TimeoutException](https://learn.microsoft.com/en-us/dotnet/api/system.timeoutexception 'System\.TimeoutException') in the exception chain, and the codes 57014 and 55P03\. |
| [IsUniqueViolation\(this Exception\)](CatPostgreSQLErrorExtensions.IsUniqueViolation.6ATS5P80X97KUQKZUZ1F97EA3.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions\.IsUniqueViolation\(this System\.Exception\)') | A unique constraint, primary key or unique index was violated\. Code 23505\. |
