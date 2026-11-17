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

## CatMySqlErrorNumbers Class

The MySQL error numbers that [CatMySqlErrorExtensions](CatMySqlErrorExtensions.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorExtensions') looks for\.
Use them when you need the number itself, for example in your own pattern match\.

```csharp
public static class CatMySqlErrorNumbers
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → CatMySqlErrorNumbers

| Fields | |
| :--- | :--- |
| [CommandTimeout](CatMySqlErrorNumbers.CommandTimeout.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorNumbers\.CommandTimeout') | The command ran longer than its command timeout\. The client raises this one, not the server\. |
| [Deadlock](CatMySqlErrorNumbers.Deadlock.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorNumbers\.Deadlock') | The transaction was chosen as the deadlock victim\. |
| [DuplicateEntry](CatMySqlErrorNumbers.DuplicateEntry.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorNumbers\.DuplicateEntry') | A unique constraint, primary key or unique index was violated\. |
| [LockWaitTimeout](CatMySqlErrorNumbers.LockWaitTimeout.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorNumbers\.LockWaitTimeout') | The server gave up waiting for a lock, because the lock wait timeout ran out\. |
| [NoReferencedRow](CatMySqlErrorNumbers.NoReferencedRow.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorNumbers\.NoReferencedRow') | A row that you tried to add or change points to a row that does not exist\. |
| [RowIsReferenced](CatMySqlErrorNumbers.RowIsReferenced.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorNumbers\.RowIsReferenced') | A row that you tried to delete or change is still referenced by a foreign key\. |
