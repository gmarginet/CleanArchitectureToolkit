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
  
##### >> [Cat\.IntegrationTesting\.PostgreSQL Assembly](index.md 'index') >> [Cat\.IntegrationTesting\.PostgreSQL Namespace](Cat.IntegrationTesting.PostgreSQL.md 'Cat\.IntegrationTesting\.PostgreSQL')

## PostgreSQLTestContainer Class

A PostgreSQL in a container\. The tests of one run share it, and every test class gets its own empty database\.

```csharp
public sealed class PostgreSQLTestContainer : System.IAsyncDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → PostgreSQLTestContainer

Implements [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable')

| Constructors | |
| :--- | :--- |
| [PostgreSQLTestContainer\(string\)](PostgreSQLTestContainer..ctor.B4TRGLNQ7XCKNAOTTW99QYCQD.md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.PostgreSQLTestContainer\(string\)') | Creates a container that starts on the first use\. |

| Fields | |
| :--- | :--- |
| [DefaultImage](PostgreSQLTestContainer.DefaultImage.md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.DefaultImage') | The image that the container starts\. The base entities of `Cat.EFCore.Extensions.PostgreSQL` were first checked by hand on this version\. |
| [SharedContainer](PostgreSQLTestContainer.SharedContainer.md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.SharedContainer') | |
| [\_gate](PostgreSQLTestContainer._gate.md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.\_gate') | |
| [\_image](PostgreSQLTestContainer._image.md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.\_image') | |
| [\_start](PostgreSQLTestContainer._start.md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.\_start') | |

| Properties | |
| :--- | :--- |
| [Shared](PostgreSQLTestContainer.Shared.md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.Shared') | Gets the container that every test of the run shares\. The first use starts it, and Testcontainers removes it when the run ends\. |

| Methods | |
| :--- | :--- |
| [CreateDatabaseAsync\(CancellationToken\)](PostgreSQLTestContainer.CreateDatabaseAsync.ZTKQAJS522JIKC9VLREXTOJ2C.md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.CreateDatabaseAsync\(System\.Threading\.CancellationToken\)') | Creates an empty database with a unique name\. |
| [DisposeAsync\(\)](PostgreSQLTestContainer.DisposeAsync().md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.DisposeAsync\(\)') | Stops and removes the container\. |
| [StartAsync\(\)](PostgreSQLTestContainer.StartAsync().md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.StartAsync\(\)') | |
| [StartContainerAsync\(\)](PostgreSQLTestContainer.StartContainerAsync().md 'Cat\.IntegrationTesting\.PostgreSQL\.PostgreSQLTestContainer\.StartContainerAsync\(\)') | |
