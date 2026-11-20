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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[CAT.INTEGRATIONTESTING](../../README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Code Reference  
  
##### >> [Cat\.IntegrationTesting\.SqlServer Assembly](index.md 'index') >> [Cat\.IntegrationTesting\.SqlServer Namespace](Cat.IntegrationTesting.SqlServer.md 'Cat\.IntegrationTesting\.SqlServer') >> [SqlServerTestContainer Class](SqlServerTestContainer.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer')

## SqlServerTestContainer\(string, bool\) Constructor

Creates a container that starts on the first use\.

```csharp
public SqlServerTestContainer(string image="mcr.microsoft.com/mssql/server:2022-latest", bool enableAgent=false);
```
#### Parameters

<a name='Cat.IntegrationTesting.SqlServer.SqlServerTestContainer.SqlServerTestContainer(string,bool).image'></a>

`image` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The SQL Server image to start\.

<a name='Cat.IntegrationTesting.SqlServer.SqlServerTestContainer.SqlServerTestContainer(string,bool).enableAgent'></a>

`enableAgent` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Starts the SQL Server Agent in the container\. Change data capture needs it, and it makes the start a little slower\.