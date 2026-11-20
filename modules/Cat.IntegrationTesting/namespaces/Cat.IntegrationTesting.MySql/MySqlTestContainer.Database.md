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
  
##### >> [Cat\.IntegrationTesting\.MySql Assembly](index.md 'index') >> [Cat\.IntegrationTesting\.MySql Namespace](Cat.IntegrationTesting.MySql.md 'Cat\.IntegrationTesting\.MySql') >> [MySqlTestContainer Class](MySqlTestContainer.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer')

## MySqlTestContainer\.Database Class

```csharp
private sealed class MySqlTestContainer.Database : Cat.IntegrationTesting.ICatTestDatabase, System.IAsyncDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Database

Implements [ICatTestDatabase](../../../Cat.IntegrationTesting/namespaces/Cat.IntegrationTesting.Abstractions/ICatTestDatabase.md 'Cat\.IntegrationTesting\.ICatTestDatabase'), [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable')

| Constructors | |
| :--- | :--- |
| [Database\(string, string, string\)](MySqlTestContainer.Database..ctor.EKV37EXQ4GPRF9PZ7O6XDQAD2.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.Database\.Database\(string, string, string\)') | |

| Fields | |
| :--- | :--- |
| [\_master](MySqlTestContainer.Database._master.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.Database\.\_master') | |

| Properties | |
| :--- | :--- |
| [ConnectionString](MySqlTestContainer.Database.ConnectionString.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.Database\.ConnectionString') | |
| [Name](MySqlTestContainer.Database.Name.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.Database\.Name') | |

| Methods | |
| :--- | :--- |
| [DisposeAsync\(\)](MySqlTestContainer.Database.DisposeAsync().md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.Database\.DisposeAsync\(\)') | |
