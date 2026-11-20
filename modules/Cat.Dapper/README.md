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

# Cat.Dapper <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Dapper gives query and command handlers plain SQL with Dapper underneath. It is the choice for a fast read-only overview, for views and stored procedures, and for a database that already exists with its own tables.

A handler asks a session for the connection, runs a statement and returns a response, the same way the handlers of the other modules do. The session opens the connection on first use and disposes it with the scope.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Write a query handler](#write-a-query-handler)
  - [Keep the SQL in .sql files](#keep-the-sql-in-sql-files)
  - [Write a command handler with a transaction](#write-a-command-handler-with-a-transaction)
  - [Page a result](#page-a-result)
  - [Handle database errors](#handle-database-errors)
  - [Keep the SQL safe](#keep-the-sql-safe)
  - [Map columns to a result class](#map-columns-to-a-result-class)
  - [Test the handlers](#test-the-handlers)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Dapper)](#nuget-packages)

| Package | Role | Targets | Install | Downloads |
|---------|------|---------|---------|-----------|
| [Cat.Dapper.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Dapper.Abstractions/) | Contracts | netstandard2.0 | `dotnet add package gmarginet.Cat.Dapper.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Dapper.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.Dapper.Abstractions/) |
| [Cat.Dapper](https://www.nuget.org/packages/gmarginet.Cat.Dapper/) | Implementation | netstandard2.0 | `dotnet add package gmarginet.Cat.Dapper` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Dapper)](https://www.nuget.org/packages/gmarginet.Cat.Dapper/) |
| [Cat.Dapper.MySql](https://www.nuget.org/packages/gmarginet.Cat.Dapper.MySql/) | MySQL support | netstandard2.0 | `dotnet add package gmarginet.Cat.Dapper.MySql` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Dapper.MySql)](https://www.nuget.org/packages/gmarginet.Cat.Dapper.MySql/) |
| [Cat.Dapper.SqlFiles](https://www.nuget.org/packages/gmarginet.Cat.Dapper.SqlFiles/) | Optional source generator | netstandard2.0 | `dotnet add package gmarginet.Cat.Dapper.SqlFiles` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Dapper.SqlFiles)](https://www.nuget.org/packages/gmarginet.Cat.Dapper.SqlFiles/) |
| [Cat.Dapper.SqlServer](https://www.nuget.org/packages/gmarginet.Cat.Dapper.SqlServer/) | SQL Server support | netstandard2.0 | `dotnet add package gmarginet.Cat.Dapper.SqlServer` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Dapper.SqlServer)](https://www.nuget.org/packages/gmarginet.Cat.Dapper.SqlServer/) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Dapper.Abstractions](namespaces/Cat.Dapper.Abstractions/index.md) | The factory that creates connections and the session that holds one connection and its transaction. |
| [Cat.Dapper](namespaces/Cat.Dapper/index.md) | The session, the base classes for query and command handlers and the extension methods that run SQL with Dapper. |
| [Cat.Dapper.MySql](namespaces/Cat.Dapper.MySql/index.md) | The MySQL connection factory and a paging helper that returns an `ICatPagedList`. |
| [Cat.Dapper.SqlFiles](namespaces/Cat.Dapper.SqlFiles/index.md) | The source generator that turns the `.sql` files next to a handler into constants of that handler. |
| [Cat.Dapper.SqlServer](namespaces/Cat.Dapper.SqlServer/index.md) | The SQL Server connection factory and a paging helper that returns an `ICatPagedList`. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.Dapper needs it |
|--------|-------------------------|
| [Cat.Queries](../Cat.Queries/README.md) | The query handler base class implements the handler interface of `Cat.Queries.Abstractions`. |
| [Cat.Commands](../Cat.Commands/README.md) | The command handler base classes implement the handler interfaces of `Cat.Commands.Abstractions`. |
| [Cat.Responses](../Cat.Responses/README.md) | Handlers return a response, and the paging helper returns an `ICatPagedList`. |
| [Cat.Db.Errors](../Cat.Db.Errors/README.md) | `Cat.Dapper.SqlServer` and `Cat.Dapper.MySql` use the error checks of their database, so the handler can tell a unique key violation from a deadlock. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Register the module
Register the SQL Server factory with the connection string. This also registers the session, with a scoped lifetime, so every scope gets one connection.

```csharp
using Cat.Dapper.SqlServer.Extensions;

services.AddCatDapperSqlServer(connectionString);
```

Register the handlers the same way as for the other modules, with `AddCatQueriesModule` and `AddCatCommandsModule`. The Dapper module does not scan for handlers.

The core of a service only references the `Abstractions` project and the query and command abstractions. The infrastructure project holds the handlers and references `Cat.Dapper`. The session and the factory live in `Cat.Dapper.Abstractions`, so another module or a service can use them without Dapper.

On MySQL, use `Cat.Dapper.MySql` instead. It has the same helper with the name `AddCatDapperMySql`, and it uses the MySqlConnector driver. It has no bulk operations, so a MySQL developer writes the bulk code themselves.

```csharp
using Cat.Dapper.MySql.Extensions;

services.AddCatDapperMySql(connectionString);
```

Another database adds its own project next to these two. It registers an `ICatDbConnectionFactory` and the neutral `Cat.Dapper` project stays the same. When a service already registers a factory, `AddCatDapperModule` keeps it.

### Write a query handler
Inherit `CatDapperQueryHandlerBase`. The `Session` property is the session of the scope. Keep the SQL in a constant of the handler class, with a raw string literal.

```csharp
using Cat.Dapper;

public class OrderOverviewQueryHandler : CatDapperQueryHandlerBase<OrderOverviewQuery, IReadOnlyList<OrderOverviewRow>>
{
    private const string Sql = """
        SELECT o.Id, o.Number, o.Total
        FROM Orders o
        WHERE o.UserId = @UserId
        ORDER BY o.Number DESC
        """;

    public OrderOverviewQueryHandler(ICatDbSession session) : base(session)
    {
    }

    public override async Task<ICatResponse<IReadOnlyList<OrderOverviewRow>>> HandleAsync(
        OrderOverviewQuery query, CancellationToken cancellationToken = default)
    {
        var rows = await Session.QueryAsync<OrderOverviewRow>(Sql, new { query.UserId }, cancellationToken);
        return CatResponse.Ok(rows);
    }
}
```

The handler never opens the connection. The extension methods of `CatDbSessionExtensions` do it when they need it.

| Method | Use it for |
|--------|------------|
| `QueryAsync<T>` | Every row of a query. |
| `QueryFirstOrDefaultAsync<T>` | The first row, or nothing. |
| `QuerySingleOrDefaultAsync<T>` | Zero or one row. It throws when there are more. |
| `ExecuteAsync` | An insert, update, delete or stored procedure. It returns the number of changed rows. |
| `ExecuteScalarAsync<T>` | One value, such as a count or a new id. |
| `PrepareAsync` | The open connection and the Dapper command, to call Dapper yourself, for example `QueryMultipleAsync`. |

The query handler returns the result class straight from Dapper. There is no extra mapping step.

### Keep the SQL in .sql files
A constant in the handler class is one place for the SQL. A `.sql` file next to the handler is the other. It gets syntax highlighting and a database tool can open it. A source generator turns each file into a `const string`, so the handler uses it like the constant above. A missing or misspelled file is a compile error.

This is optional. A developer who wants no generated code keeps the SQL in constants and adds nothing.

1. Add the package `gmarginet.Cat.Dapper.SqlFiles` to the project of the handlers. It has no reference to `Cat.Dapper` and no cost at run time.
2. Add one line to the project file, so the generator sees the files:

```xml
<ItemGroup>
    <AdditionalFiles Include="**/*.sql" />
</ItemGroup>
```

3. Make the handler class `partial` and name the file after it, in the same folder:

```csharp
// OrderOverviewQueryHandler.sql sits next to this file
public partial class OrderOverviewQueryHandler : CatDapperQueryHandlerBase<OrderOverviewQuery, IReadOnlyList<OrderOverviewRow>>
{
    public OrderOverviewQueryHandler(ICatDbSession session) : base(session)
    {
    }

    public override async Task<ICatResponse<IReadOnlyList<OrderOverviewRow>>> HandleAsync(
        OrderOverviewQuery query, CancellationToken cancellationToken = default)
    {
        var rows = await Session.QueryAsync<OrderOverviewRow>(Sql, new { query.UserId }, cancellationToken);
        return CatResponse.Ok(rows);
    }
}
```

The rules:
- **Names.** `OrderOverviewQueryHandler.sql` gives the constant `Sql`. A suffix picks another statement: `OrderOverviewQueryHandler.Count.sql` gives `CountSql`.
- **Finding the class.** The generator looks for a class with the name of the file, declared in a source file in the same folder as the `.sql` file. The namespace does not matter. Two files with the same name in different folders each belong to the class of their own folder.
- **Visibility.** The constant is `private`, so only the handler sees its SQL.
- **Opt in.** The package does not pick up `.sql` files by itself, because a global rule would also catch files nobody meant, such as the database scripts of a service. That is why you add the `AdditionalFiles` line. Without it there are no constants, and the handler does not compile where it uses one.

A compile error names the file for each of these failures:

| Id | Failure |
|----|---------|
| `CATSQL001` | No class with the name of the file in the folder of the file. |
| `CATSQL002` | The class is not `partial`. |
| `CATSQL003` | The name of the file is not valid. Use `<Class>.sql` or `<Class>.<Name>.sql`, with valid C# names. |
| `CATSQL004` | The class already has a member with the name of the constant. |

### Write a command handler with a transaction
Inherit `CatDapperCommandHandlerBase`. A command that runs one statement needs no transaction. For more than one statement, start one on the session and commit it yourself. A transaction that is not committed rolls back when the scope ends.

```csharp
public class StockMoveCommandHandler : CatDapperCommandHandlerBase<StockMoveCommand>
{
    public StockMoveCommandHandler(ICatDbSession session) : base(session)
    {
    }

    public override async Task<ICatResponse> HandleAsync(StockMoveCommand command, CancellationToken cancellationToken = default)
    {
        var transaction = await Session.BeginTransactionAsync(cancellationToken: cancellationToken);

        var changed = await Session.ExecuteAsync(ReserveSql, new { command.Isbn, command.Quantity }, cancellationToken);
        if (changed == 0)
        {
            return CatResponse.Conflict(/* your error */);
        }

        await Session.ExecuteAsync(LogSql, new { command.Isbn, command.Quantity }, cancellationToken);
        transaction.Commit();
        return CatResponse.Ok();
    }
}
```

- `Session.Transaction` is the running transaction, or `null`. The extension methods use it for you.
- A second `BeginTransactionAsync` while one runs throws an `InvalidOperationException`.
- After `Commit` or `Rollback` the transaction is gone and a new one can start.
- A service that also uses Entity Framework Core can build its `DbContext` on the connection of the session, so both share one transaction.

The session is not thread safe. Do not share it between tasks that run at the same time.

### Page a result
`QueryPagedAsync` is in `Cat.Dapper.SqlServer` and in `Cat.Dapper.MySql`, with the same arguments. MySQL pages with `LIMIT` and `OFFSET`, SQL Server with `OFFSET` and `FETCH`. A developer who changes the database changes a `using`. A project that uses both namespaces needs the namespace of one of them in the call. It returns an `ICatPagedList`, the same shape as the paging helper of `Cat.EFCore.Queries`, and it counts and reads the page in one round trip.

```csharp
using Cat.Dapper.SqlServer;

var page = await Session.QueryPagedAsync<OrderOverviewRow>(
    "SELECT o.Id, o.Number, o.Total FROM Orders o WHERE o.UserId = @UserId",
    "o.Number DESC",
    query.PageNumber,
    query.PageSize,
    new { query.UserId },
    cancellationToken);
```

- Give the statement without an `ORDER BY`. The helper adds it from the second argument.
- Make the order unique, for example end it with the id. Otherwise the pages have no stable order.
- Every column needs its own name, and the statement may not start with `WITH`, because the helper counts the rows with a derived table.
- A page number past the end gives an empty page with the right total.
- A page number or size below 1 throws an `ArgumentOutOfRangeException`.

### Handle database errors
`Cat.Dapper.SqlServer` references `Cat.Db.Errors.SqlServer`, and `Cat.Dapper.MySql` references `Cat.Db.Errors.MySql`, with the same check names. Ask the exception what happened, and do not write error numbers in the handler. See the [module readme of Cat.Db.Errors](../Cat.Db.Errors/README.md) for every check.

```csharp
using Cat.Db.Errors.SqlServer;

try
{
    await Session.ExecuteAsync(InsertSql, new { command.Isbn, command.Title }, cancellationToken);
}
catch (Exception exception) when (exception.IsUniqueViolation())
{
    return CatResponse.Conflict(/* your error */);
}
```

### Keep the SQL safe
- Pass every value through the parameters object, and never build the SQL text from user input. Dapper sends the values as parameters.
- The methods take the SQL as a plain `string` and the parameters as an object. The module does not check for string concatenation, so review it yourself.
- The `sql` and `orderBy` arguments of `QueryPagedAsync` go into the SQL text as they are. Use constants for both.
- A list of values works with `WHERE Id IN @Ids` and an array or list in the parameters object.

### Map columns to a result class
The developer handles the mapping. The module has no helpers for it, because Dapper settings are global.

- **Column names.** Use an alias in the SQL when the name differs from the property, such as `o.Number AS OrderNumber`.
- **Result class names.** The module does not enforce a name. The demo uses the suffix `Row`.
- **UTC dates.** Dapper hands out a `DateTime` with the kind `Unspecified`. Write a type handler that sets the kind to `Utc`, or convert in the handler.
- **Static type handlers.** `SqlMapper.AddTypeHandler` changes Dapper for the whole process. Register it once at startup, and know that it affects every service in the same process, such as the tests.

### Test the handlers
The module has no tests of the SQL itself. It needs no container and no in memory database. Run the SQL against a real database, as the demo does.

A handler can still be unit tested in the service that owns it. The core of the service only knows the query and command abstractions, so test the code that sends them with the fakes of `Cat.UnitTesting`.
<!-- region end: Usage-->
