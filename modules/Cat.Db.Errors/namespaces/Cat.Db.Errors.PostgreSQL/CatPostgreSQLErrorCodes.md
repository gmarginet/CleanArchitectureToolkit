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

## CatPostgreSQLErrorCodes Class

The PostgreSQL error codes that [CatPostgreSQLErrorExtensions](CatPostgreSQLErrorExtensions.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions') looks for\.
PostgreSQL reports a five character SQLSTATE code, so these constants are text and not numbers\.
Use them when you need the code itself, for example in your own pattern match\.

```csharp
public static class CatPostgreSQLErrorCodes
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatPostgreSQLErrorCodes

| Fields | |
| :--- | :--- |
| [DeadlockDetected](CatPostgreSQLErrorCodes.DeadlockDetected.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorCodes\.DeadlockDetected') | The transaction was chosen as the deadlock victim\. |
| [ForeignKeyViolation](CatPostgreSQLErrorCodes.ForeignKeyViolation.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorCodes\.ForeignKeyViolation') | A row that you tried to add, change or delete breaks a foreign key\. |
| [LockNotAvailable](CatPostgreSQLErrorCodes.LockNotAvailable.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorCodes\.LockNotAvailable') | A lock that the statement asked for with no waiting is not available\. |
| [QueryCanceled](CatPostgreSQLErrorCodes.QueryCanceled.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorCodes\.QueryCanceled') | The server cancelled the statement, for example because the statement timeout ran out\. |
| [UniqueViolation](CatPostgreSQLErrorCodes.UniqueViolation.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorCodes\.UniqueViolation') | A unique constraint, primary key or unique index was violated\. |
