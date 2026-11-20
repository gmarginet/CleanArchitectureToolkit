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
  
##### >> [Cat\.Db\.Errors\.PostgreSQL Assembly](index.md 'index')

## Cat\.Db\.Errors\.PostgreSQL Namespace

| Classes | |
| :--- | :--- |
| [CatPostgreSQLErrorCodes](CatPostgreSQLErrorCodes.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorCodes') | The PostgreSQL error codes that [CatPostgreSQLErrorExtensions](CatPostgreSQLErrorExtensions.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions') looks for\. PostgreSQL reports a five character SQLSTATE code, so these constants are text and not numbers\. Use them when you need the code itself, for example in your own pattern match\. |
| [CatPostgreSQLErrorExtensions](CatPostgreSQLErrorExtensions.md 'Cat\.Db\.Errors\.PostgreSQL\.CatPostgreSQLErrorExtensions') | Extension methods that recognize PostgreSQL errors by their SQLSTATE code\. Each check looks at the exception itself and at the exceptions inside it, so you can call it on the `DbUpdateException` of Entity Framework Core as well as on the [Npgsql\.PostgresException](https://learn.microsoft.com/en-us/dotnet/api/npgsql.postgresexception 'Npgsql\.PostgresException') of Dapper\. |
