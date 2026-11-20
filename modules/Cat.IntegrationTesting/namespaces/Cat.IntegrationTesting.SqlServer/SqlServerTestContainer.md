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
  
##### >> [Cat\.IntegrationTesting\.SqlServer Assembly](index.md 'index') >> [Cat\.IntegrationTesting\.SqlServer Namespace](Cat.IntegrationTesting.SqlServer.md 'Cat\.IntegrationTesting\.SqlServer')

## SqlServerTestContainer Class

A SQL Server in a container\. The tests of one run share it, and every test class gets its own empty database\.

```csharp
public sealed class SqlServerTestContainer : System.IAsyncDisposable
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → SqlServerTestContainer

Implements [System\.IAsyncDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.iasyncdisposable 'System\.IAsyncDisposable')

| Constructors | |
| :--- | :--- |
| [SqlServerTestContainer\(string, bool\)](SqlServerTestContainer..ctor.RMFKKIRGXRBEY7PUJFVL5E93.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.SqlServerTestContainer\(string, bool\)') | Creates a container that starts on the first use\. |

| Fields | |
| :--- | :--- |
| [DefaultImage](SqlServerTestContainer.DefaultImage.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.DefaultImage') | The image that the container starts\. The bulk operations of `Cat.Dapper.SqlServer` were first checked by hand on this version\. |
| [SharedAgentContainer](SqlServerTestContainer.SharedAgentContainer.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.SharedAgentContainer') | |
| [SharedContainer](SqlServerTestContainer.SharedContainer.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.SharedContainer') | |
| [\_enableAgent](SqlServerTestContainer._enableAgent.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.\_enableAgent') | |
| [\_gate](SqlServerTestContainer._gate.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.\_gate') | |
| [\_image](SqlServerTestContainer._image.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.\_image') | |
| [\_start](SqlServerTestContainer._start.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.\_start') | |

| Properties | |
| :--- | :--- |
| [Shared](SqlServerTestContainer.Shared.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.Shared') | Gets the container that every test of the run shares\. The first use starts it, and Testcontainers removes it when the run ends\. |
| [SharedWithAgent](SqlServerTestContainer.SharedWithAgent.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.SharedWithAgent') | Gets the container with the SQL Server Agent on, which every test that needs it shares\. Use it for change data capture only, because the other tests start faster on [Shared](SqlServerTestContainer.Shared.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.Shared')\. |

| Methods | |
| :--- | :--- |
| [CreateDatabaseAsync\(CancellationToken\)](SqlServerTestContainer.CreateDatabaseAsync.Z4RMFALQO6Y9N29HOKA7E9CZ.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.CreateDatabaseAsync\(System\.Threading\.CancellationToken\)') | Creates an empty database with a unique name\. |
| [DisposeAsync\(\)](SqlServerTestContainer.DisposeAsync().md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.DisposeAsync\(\)') | Stops and removes the container\. |
| [StartAsync\(\)](SqlServerTestContainer.StartAsync().md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.StartAsync\(\)') | |
| [StartContainerAsync\(\)](SqlServerTestContainer.StartContainerAsync().md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.StartContainerAsync\(\)') | |
| [WaitForAgentAsync\(string\)](SqlServerTestContainer.WaitForAgentAsync.PAI8B04IJ3872NJUDCFR7SUM6.md 'Cat\.IntegrationTesting\.SqlServer\.SqlServerTestContainer\.WaitForAgentAsync\(string\)') | |
