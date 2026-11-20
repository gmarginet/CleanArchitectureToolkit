<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: ../.. -->
<link href="../../resources/styles/style.css" rel="stylesheet" />
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
            <img src='../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-module-readme skill to update this readme.-->
<!-- region end: TemplateSkill-->

# Cat.IntegrationTesting <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.IntegrationTesting runs your integration tests on a real SQL Server, PostgreSQL or MySQL in a container. It starts the container with Testcontainers, and it gives every test class its own empty database.

The module is a toolbox of small projects. A core project for each database starts the container and has no test framework. A small NUnit project for each database adds a base class. You pick the database and the framework you use.

The integration tests are not unit tests. Name the projects `*.IntegrationTests.csproj` so the unit test run does not pick them up, and run them in a separate step.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Write a test class](#write-a-test-class)
  - [Change data capture on SQL Server](#change-data-capture-on-sql-server)
  - [Use the container without NUnit](#use-the-container-without-nunit)
  - [When Docker is not running](#when-docker-is-not-running)
  - [Run the tests](#run-the-tests)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.IntegrationTesting.SqlServer)](#nuget-packages)

| Package | Role | Targets | Install | Downloads |
|---------|------|---------|---------|-----------|
| [Cat.IntegrationTesting.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.Abstractions/) | Shared contract, error and environment check | netstandard2.0 | `dotnet add package gmarginet.Cat.IntegrationTesting.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.IntegrationTesting.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.Abstractions/) |
| [Cat.IntegrationTesting.MySql](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.MySql/) | MySQL container, no test framework | netstandard2.0 | `dotnet add package gmarginet.Cat.IntegrationTesting.MySql` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.IntegrationTesting.MySql)](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.MySql/) |
| [Cat.IntegrationTesting.MySql.NUnit](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.MySql.NUnit/) | NUnit base class for MySQL | net10.0, net11.0 | `dotnet add package gmarginet.Cat.IntegrationTesting.MySql.NUnit` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.IntegrationTesting.MySql.NUnit)](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.MySql.NUnit/) |
| [Cat.IntegrationTesting.PostgreSQL](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.PostgreSQL/) | PostgreSQL container, no test framework | net10.0, net11.0 | `dotnet add package gmarginet.Cat.IntegrationTesting.PostgreSQL` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.IntegrationTesting.PostgreSQL)](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.PostgreSQL/) |
| [Cat.IntegrationTesting.PostgreSQL.NUnit](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.PostgreSQL.NUnit/) | NUnit base class for PostgreSQL | net10.0, net11.0 | `dotnet add package gmarginet.Cat.IntegrationTesting.PostgreSQL.NUnit` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.IntegrationTesting.PostgreSQL.NUnit)](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.PostgreSQL.NUnit/) |
| [Cat.IntegrationTesting.SqlServer](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.SqlServer/) | SQL Server container, no test framework | netstandard2.0 | `dotnet add package gmarginet.Cat.IntegrationTesting.SqlServer` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.IntegrationTesting.SqlServer)](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.SqlServer/) |
| [Cat.IntegrationTesting.SqlServer.NUnit](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.SqlServer.NUnit/) | NUnit base class for SQL Server | net10.0, net11.0 | `dotnet add package gmarginet.Cat.IntegrationTesting.SqlServer.NUnit` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.IntegrationTesting.SqlServer.NUnit)](https://www.nuget.org/packages/gmarginet.Cat.IntegrationTesting.SqlServer.NUnit/) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.IntegrationTesting.Abstractions](namespaces/Cat.IntegrationTesting.Abstractions/index.md) | The test database contract, the error for a missing Docker and the check for a build server. |
| [Cat.IntegrationTesting.MySql](namespaces/Cat.IntegrationTesting.MySql/index.md) | Starts a MySQL container and creates an empty database for a test class. |
| [Cat.IntegrationTesting.MySql.NUnit](namespaces/Cat.IntegrationTesting.MySql.NUnit/index.md) | The NUnit base class that gives a test class its own MySQL database. |
| [Cat.IntegrationTesting.PostgreSQL](namespaces/Cat.IntegrationTesting.PostgreSQL/index.md) | Starts a PostgreSQL container and creates an empty database for a test class. |
| [Cat.IntegrationTesting.PostgreSQL.NUnit](namespaces/Cat.IntegrationTesting.PostgreSQL.NUnit/index.md) | The NUnit base class that gives a test class its own PostgreSQL database. |
| [Cat.IntegrationTesting.SqlServer](namespaces/Cat.IntegrationTesting.SqlServer/index.md) | Starts a SQL Server container and creates an empty database for a test class. |
| [Cat.IntegrationTesting.SqlServer.NUnit](namespaces/Cat.IntegrationTesting.SqlServer.NUnit/index.md) | The NUnit base class that gives a test class its own SQL Server database. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->
Cat.IntegrationTesting has no dependencies on other CAT modules.  
<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Write a test class
Inherit from the base class of your database. The class gets one empty database in a container that the whole test run shares. The database is created before the first test of the class and dropped after the last one.

```csharp
using Cat.IntegrationTesting.SqlServer.NUnit;

[TestFixture]
public class OrderTests : SqlServerDatabaseTests
{
    [OneTimeSetUp]
    public async Task CreateSchema()
    {
        // ConnectionString points at the empty database of this class.
        await using var context = new OrderDbContext(new DbContextOptionsBuilder<OrderDbContext>().UseSqlServer(ConnectionString).Options);
        await context.Database.MigrateAsync();
    }
}
```

For PostgreSQL, inherit from `PostgreSQLDatabaseTests` in `Cat.IntegrationTesting.PostgreSQL.NUnit`. For MySQL, inherit from `MySqlDatabaseTests` in `Cat.IntegrationTesting.MySql.NUnit`. The tests of a class share its database, so clean the tables in a `[SetUp]` method.

The containers start from `mcr.microsoft.com/mssql/server:2022-latest`, `postgres:17` and `mysql:8.4`.

### Change data capture on SQL Server
Change data capture needs the SQL Server Agent. Inherit from `SqlServerAgentDatabaseTests` instead. It uses a second shared container with the Agent on, `SqlServerTestContainer.SharedWithAgent`. The other tests stay on the faster container without the Agent.

### Use the container without NUnit
The core projects have no test framework. Use the shared container and create the database yourself.

```csharp
await using var database = await SqlServerTestContainer.Shared.CreateDatabaseAsync();
var connectionString = database.ConnectionString;
```

`PostgreSQLTestContainer` works the same way. Disposing the database drops it. The container of a run is removed by Testcontainers when the run ends.

### When Docker is not running
- On a build server, the tests fail with a clear message. The build server is recognized by the `CI` environment variable, which GitHub Actions sets. A missing Docker is never hidden there.
- On a developer machine, the tests are ignored with a message, so a run without Docker stays green.

### Run the tests
- Name the test projects `*.IntegrationTests.csproj`. The `Test` target of the build only runs `*.Tests.csproj`.
- Run them in a separate step, such as the `IntegrationTest` Cake target of this repository. In GitHub Actions use a separate job, and let the publish job wait for it.
- The tests for `net10.0` and `net11.0` run in two processes, so each process starts its own container.
<!-- region end: Usage-->