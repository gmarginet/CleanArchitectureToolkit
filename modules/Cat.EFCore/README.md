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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-module-readme skill to update this readme.-->
<!-- region end: TemplateSkill-->

# Cat.EFCore <!-- omit in toc -->  

<!-- region start: Intro-->
Set up Entity Framework Core entities the same way every time.  
Inherit from a base class, call one extension method in `OnModelCreating`, and get a Guid key, an identity sequence column, and optional temporal tables.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.EFCore.Entities)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.EFCore.Entities](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Entities/) | Entity base classes | `dotnet add package gmarginet.Cat.EFCore.Entities` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Entities)](#nuget-packages) |
| [Cat.EFCore.Extensions](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Extensions/) | Model builder extensions | `dotnet add package gmarginet.Cat.EFCore.Extensions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Extensions)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.EFCore.Entities](namespaces/Cat.EFCore.Entities/index.md) | Base classes for regular, temporal and reference data entities. |
| [Cat.EFCore.Extensions](namespaces/Cat.EFCore.Extensions/index.md) | Model builder extensions that configure keys, indexes and tables for the base classes. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->
Cat.EFCore has no dependencies on other CAT modules.  
<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
Inherit your entities from the Cat base classes.

```csharp
public class Todo : CatEntityBase
{
    public string Title { get; set; } = string.Empty;
    public Guid TodoOwnerId { get; set; }
    public TodoOwner? TodoOwner { get; set; }
}

public class TodoHistoryItem : CatTemporalEntityBase
{
    public string Title { get; set; } = string.Empty;
}

// The table belongs to another service that shares the database.
public class TodoOwner : CatReferenceEntityBase
{
    public string Name { get; set; } = string.Empty;
}
```

Configure them in `OnModelCreating`.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ConfigureCatEntity<Todo>("Todo", "todo");
    modelBuilder.ConfigureCatTemporalEntity<TodoHistoryItem>("TodoHistoryItem", "todo");
    modelBuilder.ConfigureCatReferenceEntity<TodoOwner>("TodoOwner", "identity");

    modelBuilder.Entity<Todo>()
        .HasOne(t => t.TodoOwner)
        .WithMany()
        .HasForeignKey(t => t.TodoOwnerId);
}
```

What you get:
- `CatEntityBase`: a non-clustered Guid primary key on `Id` and a unique clustered index on the identity column `SequenceId`.
- `CatTemporalEntityBase`: the same as above, in a [temporal table](https://learn.microsoft.com/en-us/sql/relational-databases/tables/temporal/overview?view=sql-server-ver17) with a history table in the `History` schema.
- `CatReferenceEntityBase`: a non-clustered primary key, and the table is excluded from migrations.

### What are temporal tables
A temporal table is a SQL Server feature. It keeps the full history of your data, not only the current rows.

- SQL Server stores the current rows in the table itself.
- Every update or delete moves the old row to a history table.
- Two period columns, `ValidFrom` and `ValidUntil`, say when a row version was valid.
- You can query the data as it was at any point in time.
- Only SQL Server supports them. Read the [overview of temporal tables](https://learn.microsoft.com/en-us/sql/relational-databases/tables/temporal/overview?view=sql-server-ver17) for the details.

### When to use `CatReferenceEntityBase`
Use it for a table that someone else owns, so you can point a foreign key at it.

- Several services share one database. Each service owns some of the tables.
- Your service needs a foreign key or navigation to a table of another service.
- You map that table in your own `DbContext` with `CatReferenceEntityBase`. Migrations never touch it, so the owner keeps control of the schema.
- Treat the entity as read-only. Only the owner changes the data.

Do not use it for your own tables. Use `CatEntityBase` for those, even when the data is a short list of fixed values.
<!-- region end: Usage-->
