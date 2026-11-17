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
  
##### >> [Cat\.Db\.Errors\.MySql Assembly](index.md 'index') >> [Cat\.Db\.Errors\.MySql Namespace](Cat.Db.Errors.MySql.md 'Cat\.Db\.Errors\.MySql')

## CatMySqlErrorExtensions Class

Extension methods that recognize MySQL errors by their error number\.
Each check looks at the exception itself and at the exceptions inside it, so you can call it on
the `DbUpdateException` of Entity Framework Core as well as on the [MySqlConnector\.MySqlException](https://learn.microsoft.com/en-us/dotnet/api/mysqlconnector.mysqlexception 'MySqlConnector\.MySqlException') of Dapper\.

```csharp
public static class CatMySqlErrorExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMySqlErrorExtensions

| Methods | |
| :--- | :--- |
| [FindMySqlException\(this Exception\)](CatMySqlErrorExtensions.FindMySqlException.OF12CN8MVIHSH7K1PRWVQF626.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorExtensions\.FindMySqlException\(this System\.Exception\)') | Finds the first [MySqlConnector\.MySqlException](https://learn.microsoft.com/en-us/dotnet/api/mysqlconnector.mysqlexception 'MySqlConnector\.MySqlException') in the exception chain\. |
| [GetNumber\(this Exception\)](CatMySqlErrorExtensions.GetNumber.NPMTI57MTD2AWF4FCDAMJEIN5.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorExtensions\.GetNumber\(this System\.Exception\)') | |
| [IsDeadlock\(this Exception\)](CatMySqlErrorExtensions.IsDeadlock.SUTQP3KGB0V0IJHKMVBCU8EKD.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorExtensions\.IsDeadlock\(this System\.Exception\)') | The transaction was chosen as the deadlock victim\. Number 1213\. Running the work again usually helps\. |
| [IsForeignKeyViolation\(this Exception\)](CatMySqlErrorExtensions.IsForeignKeyViolation.E4L0C66TJFOZKBSZHH91RUBW6.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorExtensions\.IsForeignKeyViolation\(this System\.Exception\)') | A foreign key constraint was violated\. Numbers 1451 and 1452\. |
| [IsTimeout\(this Exception\)](CatMySqlErrorExtensions.IsTimeout.LNBGBGQ0M8AMM2BVELPOGVVZ3.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorExtensions\.IsTimeout\(this System\.Exception\)') | A command timed out, or the server gave up waiting for a lock\. Numbers \-1 and 1205\. |
| [IsUniqueViolation\(this Exception\)](CatMySqlErrorExtensions.IsUniqueViolation.K9XHFREJD2YB9GKXSIWCVVULD.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorExtensions\.IsUniqueViolation\(this System\.Exception\)') | A unique constraint, primary key or unique index was violated\. Number 1062\. |
