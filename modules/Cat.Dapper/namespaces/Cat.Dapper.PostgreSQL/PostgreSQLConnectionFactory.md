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
  
##### >> [Cat\.Dapper\.PostgreSQL Assembly](index.md 'index') >> [Cat\.Dapper\.PostgreSQL Namespace](Cat.Dapper.PostgreSQL.md 'Cat\.Dapper\.PostgreSQL')

## PostgreSQLConnectionFactory Class

Creates PostgreSQL connections for one connection string\.

```csharp
public sealed class PostgreSQLConnectionFactory : Cat.Dapper.Abstractions.ICatDbConnectionFactory
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → PostgreSQLConnectionFactory

Implements [ICatDbConnectionFactory](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbConnectionFactory.md 'Cat\.Dapper\.Abstractions\.ICatDbConnectionFactory')

| Constructors | |
| :--- | :--- |
| [PostgreSQLConnectionFactory\(string\)](PostgreSQLConnectionFactory..ctor.YLLNZVGTSKJ98SU02A8DPRHZ8.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLConnectionFactory\.PostgreSQLConnectionFactory\(string\)') | Creates the factory\. |

| Fields | |
| :--- | :--- |
| [\_connectionString](PostgreSQLConnectionFactory._connectionString.md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLConnectionFactory\.\_connectionString') | |

| Methods | |
| :--- | :--- |
| [CreateConnection\(\)](PostgreSQLConnectionFactory.CreateConnection().md 'Cat\.Dapper\.PostgreSQL\.PostgreSQLConnectionFactory\.CreateConnection\(\)') | Creates a new connection\. The connection is closed, and the caller owns it and disposes it\. |
