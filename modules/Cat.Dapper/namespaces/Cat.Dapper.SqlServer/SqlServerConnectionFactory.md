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
  
##### >> [Cat\.Dapper\.SqlServer Assembly](index.md 'index') >> [Cat\.Dapper\.SqlServer Namespace](Cat.Dapper.SqlServer.md 'Cat\.Dapper\.SqlServer')

## SqlServerConnectionFactory Class

Creates SQL Server connections for one connection string\.

```csharp
public sealed class SqlServerConnectionFactory : Cat.Dapper.Abstractions.ICatDbConnectionFactory
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SqlServerConnectionFactory

Implements [ICatDbConnectionFactory](../../../Cat.Dapper/namespaces/Cat.Dapper.Abstractions/ICatDbConnectionFactory.md 'Cat\.Dapper\.Abstractions\.ICatDbConnectionFactory')

| Constructors | |
| :--- | :--- |
| [SqlServerConnectionFactory\(string\)](SqlServerConnectionFactory..ctor.A1H9RGDQ1S7P9JCORWO32Y4B2.md 'Cat\.Dapper\.SqlServer\.SqlServerConnectionFactory\.SqlServerConnectionFactory\(string\)') | Creates the factory\. |

| Fields | |
| :--- | :--- |
| [\_connectionString](SqlServerConnectionFactory._connectionString.md 'Cat\.Dapper\.SqlServer\.SqlServerConnectionFactory\.\_connectionString') | |

| Methods | |
| :--- | :--- |
| [CreateConnection\(\)](SqlServerConnectionFactory.CreateConnection().md 'Cat\.Dapper\.SqlServer\.SqlServerConnectionFactory\.CreateConnection\(\)') | Creates a new connection\. The connection is closed, and the caller owns it and disposes it\. |
