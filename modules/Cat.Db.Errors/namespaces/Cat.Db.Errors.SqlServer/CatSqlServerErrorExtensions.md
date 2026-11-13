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

## CatSqlServerErrorExtensions Class

Extension methods that recognize SQL Server errors by their error number\.
Each check looks at the exception itself and at the exceptions inside it, so you can call it on
the `DbUpdateException` of Entity Framework Core as well as on the [Microsoft\.Data\.SqlClient\.SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception 'Microsoft\.Data\.SqlClient\.SqlException') of Dapper\.

```csharp
public static class CatSqlServerErrorExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatSqlServerErrorExtensions

| Methods | |
| :--- | :--- |
| [FindSqlException\(this Exception\)](CatSqlServerErrorExtensions.FindSqlException.V1YNFT3D1JTT9U8EDJNXILCQE.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorExtensions\.FindSqlException\(this System\.Exception\)') | Finds the first [Microsoft\.Data\.SqlClient\.SqlException](https://learn.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlexception 'Microsoft\.Data\.SqlClient\.SqlException') in the exception chain\. |
| [IsDeadlock\(this Exception\)](CatSqlServerErrorExtensions.IsDeadlock.5UGPJW1SFBZQL76AI11B33IX4.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorExtensions\.IsDeadlock\(this System\.Exception\)') | The transaction was chosen as the deadlock victim\. Number 1205\. Running the work again usually helps\. |
| [IsForeignKeyViolation\(this Exception\)](CatSqlServerErrorExtensions.IsForeignKeyViolation.UDWP5VIC679B0WO73VQEEIH85.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorExtensions\.IsForeignKeyViolation\(this System\.Exception\)') | A foreign key constraint was violated\. Number 547\. |
| [IsTimeout\(this Exception\)](CatSqlServerErrorExtensions.IsTimeout.4OWR5SDU0DLV4541UR4VZ0YI4.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorExtensions\.IsTimeout\(this System\.Exception\)') | A command timed out, or the server gave up waiting for a lock\. Numbers \-2 and 1222\. |
| [IsUniqueViolation\(this Exception\)](CatSqlServerErrorExtensions.IsUniqueViolation.8S9X048VFG96OYFTBOESC9GK5.md 'Cat\.Db\.Errors\.SqlServer\.CatSqlServerErrorExtensions\.IsUniqueViolation\(this System\.Exception\)') | A unique constraint, primary key or unique index was violated\. Numbers 2627 and 2601\. |
