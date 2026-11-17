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
  
##### >> [Cat\.Db\.Errors\.MySql Assembly](index.md 'index')

## Cat\.Db\.Errors\.MySql Namespace

Recognizes MySQL errors by their error number, such as a unique key violation, a foreign key violation,
a deadlock or a timeout\. The checks work on any exception that has a MySQL exception inside, so they also work
on the exception that Entity Framework Core throws around it\.

| Classes | |
| :--- | :--- |
| [CatMySqlErrorExtensions](CatMySqlErrorExtensions.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorExtensions') | Extension methods that recognize MySQL errors by their error number\. Each check looks at the exception itself and at the exceptions inside it, so you can call it on the `DbUpdateException` of Entity Framework Core as well as on the [MySqlConnector\.MySqlException](https://learn.microsoft.com/en-us/dotnet/api/mysqlconnector.mysqlexception 'MySqlConnector\.MySqlException') of Dapper\. |
| [CatMySqlErrorNumbers](CatMySqlErrorNumbers.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorNumbers') | The MySQL error numbers that [CatMySqlErrorExtensions](CatMySqlErrorExtensions.md 'Cat\.Db\.Errors\.MySql\.CatMySqlErrorExtensions') looks for\. Use them when you need the number itself, for example in your own pattern match\. |
