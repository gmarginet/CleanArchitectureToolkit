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
  
##### >> [Cat\.IntegrationTesting\.MySql Assembly](index.md 'index') >> [Cat\.IntegrationTesting\.MySql Namespace](Cat.IntegrationTesting.MySql.md 'Cat\.IntegrationTesting\.MySql')

## MySqlTestContainer Class

A MySQL in a container\. The tests of one run share it, and every test class gets its own empty database\.

```csharp
public sealed class MySqlTestContainer : System.IAsyncDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → MySqlTestContainer

Implements [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable')

| Constructors | |
| :--- | :--- |
| [MySqlTestContainer\(string\)](MySqlTestContainer..ctor.JWIHKKAYAV2GU0PZS9TEYH3FD.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.MySqlTestContainer\(string\)') | Creates a container that starts on the first use\. |

| Fields | |
| :--- | :--- |
| [DefaultImage](MySqlTestContainer.DefaultImage.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.DefaultImage') | The image that the container starts\. The paging and the error checks of the MySQL modules are tested on this version\. |
| [SharedContainer](MySqlTestContainer.SharedContainer.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.SharedContainer') | |
| [\_gate](MySqlTestContainer._gate.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.\_gate') | |
| [\_image](MySqlTestContainer._image.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.\_image') | |
| [\_start](MySqlTestContainer._start.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.\_start') | |

| Properties | |
| :--- | :--- |
| [Shared](MySqlTestContainer.Shared.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.Shared') | Gets the container that every test of the run shares\. The first use starts it, and Testcontainers removes it when the run ends\. |

| Methods | |
| :--- | :--- |
| [CreateDatabaseAsync\(CancellationToken\)](MySqlTestContainer.CreateDatabaseAsync.8CZ4JR87XXGQFB3LUZWQKJVBB.md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.CreateDatabaseAsync\(System\.Threading\.CancellationToken\)') | Creates an empty database with a unique name\. |
| [DisposeAsync\(\)](MySqlTestContainer.DisposeAsync().md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.DisposeAsync\(\)') | Stops and removes the container\. |
| [StartAsync\(\)](MySqlTestContainer.StartAsync().md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.StartAsync\(\)') | |
| [StartContainerAsync\(\)](MySqlTestContainer.StartContainerAsync().md 'Cat\.IntegrationTesting\.MySql\.MySqlTestContainer\.StartContainerAsync\(\)') | |
