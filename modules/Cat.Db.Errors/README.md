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

# Cat.Db.Errors <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Db.Errors recognizes database errors by their error number. Ask an exception if it is a unique key violation, a foreign key violation, a deadlock or a timeout, instead of writing the number in your handler.

There is one project per database. Entity Framework Core and Dapper code share the same checks, because the module references neither of them.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Map a unique key violation to a failed response](#map-a-unique-key-violation-to-a-failed-response)
  - [Retry on a deadlock](#retry-on-a-deadlock)
  - [The checks](#the-checks)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Db.Errors.SqlServer)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.Db.Errors.SqlServer](https://www.nuget.org/packages/gmarginet.Cat.Db.Errors.SqlServer/) | SQL Server error checks | `dotnet add package gmarginet.Cat.Db.Errors.SqlServer` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Db.Errors.SqlServer)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Db.Errors.SqlServer](namespaces/Cat.Db.Errors.SqlServer/index.md) | The error numbers and the extension methods that recognize SQL Server errors. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

Cat.Db.Errors has no dependencies on other CAT modules.  

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Map a unique key violation to a failed response
Call the check on the exception you caught. It works on the `DbUpdateException` of Entity Framework Core, because the check looks at the exceptions inside it too. It works on the `SqlException` of Dapper as well.

```csharp
using Cat.Db.Errors.SqlServer;

try
{
    await context.SaveChangesAsync(cancellationToken);
}
catch (DbUpdateException ex) when (ex.IsUniqueViolation())
{
    return CatResponse.BadRequest(CatalogErrorDefinitions.IsbnAlreadyExists.CreateCatError(book.Isbn));
}
```

### Retry on a deadlock
A deadlock victim can run the same work again.

```csharp
catch (Exception ex) when (ex.IsDeadlock())
{
    // run the work again
}
```

### The checks
All checks are extension methods on `Exception`. A `null` exception, or one without a SQL Server exception inside, gives `false`.

| Method | Error numbers | Meaning |
|--------|---------------|---------|
| `IsUniqueViolation` | 2627, 2601 | A unique constraint, primary key or unique index was violated. |
| `IsForeignKeyViolation` | 547 | A foreign key constraint was violated. |
| `IsDeadlock` | 1205 | The transaction was chosen as the deadlock victim. |
| `IsTimeout` | -2, 1222 | The command timed out, or the server gave up waiting for a lock. |

`FindSqlException` returns the first `SqlException` in the chain of the exception, or `null`. The numbers are public constants in `CatSqlServerErrorNumbers`, for your own pattern match.

The module references `Microsoft.Data.SqlClient` and reads `SqlException.Number`. It makes no call to the database.
<!-- region end: Usage-->
