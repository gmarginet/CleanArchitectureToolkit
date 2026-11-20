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
  
##### >> [Cat\.IntegrationTesting\.MySql\.NUnit Assembly](index.md 'index') >> [Cat\.IntegrationTesting\.MySql\.NUnit Namespace](Cat.IntegrationTesting.MySql.NUnit.md 'Cat\.IntegrationTesting\.MySql\.NUnit')

## MySqlDatabaseTests Class

Base class for the tests of one class that need an empty MySQL database\. The class gets its own database in the shared container, and the database is dropped when the class is done\.

```csharp
public abstract class MySqlDatabaseTests
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → MySqlDatabaseTests

### Remarks
When Docker is not available, the tests fail if the `CI` environment variable is set, and are ignored with a message otherwise\.

| Fields | |
| :--- | :--- |
| [\_database](MySqlDatabaseTests._database.md 'Cat\.IntegrationTesting\.MySql\.NUnit\.MySqlDatabaseTests\.\_database') | |

| Properties | |
| :--- | :--- |
| [ConnectionString](MySqlDatabaseTests.ConnectionString.md 'Cat\.IntegrationTesting\.MySql\.NUnit\.MySqlDatabaseTests\.ConnectionString') | Gets the connection string of the database of this test class\. |

| Methods | |
| :--- | :--- |
| [CreateDatabase\(\)](MySqlDatabaseTests.CreateDatabase().md 'Cat\.IntegrationTesting\.MySql\.NUnit\.MySqlDatabaseTests\.CreateDatabase\(\)') | Creates the database of the test class\. |
| [DropDatabase\(\)](MySqlDatabaseTests.DropDatabase().md 'Cat\.IntegrationTesting\.MySql\.NUnit\.MySqlDatabaseTests\.DropDatabase\(\)') | Drops the database of the test class\. |
