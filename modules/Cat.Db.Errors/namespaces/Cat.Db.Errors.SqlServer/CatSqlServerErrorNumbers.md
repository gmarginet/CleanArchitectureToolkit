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
  
##### >> [Cat\.Db\.Errors\.SqlServer Assembly](index.md 'index') >> [Cat\.Db\.Errors\.SqlServer Namespace](Cat.Db.Errors.SqlServer.md 'Cat\.Db\.Errors\.SqlServer')

## CatSqlServerErrorNumbers Class

The SQL Server error numbers that [CatSqlServerErrorExtensions](CatSqlServerErrorExtensions.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorExtensions') looks for\.
Use them when you need the number itself, for example in your own pattern match\.

```csharp
public static class CatSqlServerErrorNumbers
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSqlServerErrorNumbers

| Fields | |
| :--- | :--- |
| [CommandTimeout](CatSqlServerErrorNumbers.CommandTimeout.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorNumbers\.CommandTimeout') | The command ran longer than its command timeout\. The client raises this one, not the server\. |
| [Deadlock](CatSqlServerErrorNumbers.Deadlock.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorNumbers\.Deadlock') | The transaction was chosen as the deadlock victim\. |
| [ForeignKeyViolation](CatSqlServerErrorNumbers.ForeignKeyViolation.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorNumbers\.ForeignKeyViolation') | A foreign key constraint was violated\. |
| [LockRequestTimeout](CatSqlServerErrorNumbers.LockRequestTimeout.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorNumbers\.LockRequestTimeout') | The server gave up waiting for a lock, because a lock timeout was set\. |
| [UniqueIndexViolation](CatSqlServerErrorNumbers.UniqueIndexViolation.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorNumbers\.UniqueIndexViolation') | A unique index was violated\. |
| [UniqueKeyViolation](CatSqlServerErrorNumbers.UniqueKeyViolation.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorNumbers\.UniqueKeyViolation') | A unique constraint or primary key was violated\. |
