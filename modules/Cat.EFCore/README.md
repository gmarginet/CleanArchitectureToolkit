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

# Cat.EFCore <!-- omit in toc -->  

<!-- region start: Intro-->
Set up Entity Framework Core entities the same way every time.  
Inherit from a base class, call one extension method in `OnModelCreating`, and get a time ordered Guid key, an identity sequence column, and optional temporal tables on SQL Server.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.EFCore.Entities)](#nuget-packages)

| Package | Role | Targets | Install | Downloads |
|---------|------|---------|---------|-----------|
| [Cat.EFCore.Entities](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Entities/) | Entity base classes | netstandard2.0 | `dotnet add package gmarginet.Cat.EFCore.Entities` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Entities)](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Entities/) |
| [Cat.EFCore.Extensions](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Extensions/) | Provider neutral base of the model builder extensions | net10.0, net11.0 | `dotnet add package gmarginet.Cat.EFCore.Extensions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Extensions)](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Extensions/) |
| [Cat.EFCore.Entities.SqlServer](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Entities.SqlServer/) | SQL Server entity base class for temporal tables | netstandard2.0, net11.0 | `dotnet add package gmarginet.Cat.EFCore.Entities.SqlServer` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Entities.SqlServer)](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Entities.SqlServer/) |
| [Cat.EFCore.Extensions.SqlServer](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Extensions.SqlServer/) | SQL Server model builder extensions, with temporal tables | net10.0, net11.0 | `dotnet add package gmarginet.Cat.EFCore.Extensions.SqlServer` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Extensions.SqlServer)](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Extensions.SqlServer/) |
| [Cat.EFCore.Extensions.PostgreSQL](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Extensions.PostgreSQL/) | PostgreSQL model builder extensions | net10.0 | `dotnet add package gmarginet.Cat.EFCore.Extensions.PostgreSQL` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Extensions.PostgreSQL)](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Extensions.PostgreSQL/) |
| [Cat.EFCore.Queries](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Queries/) | Base query handler and paging | net10.0, net11.0 | `dotnet add package gmarginet.Cat.EFCore.Queries` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Queries)](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Queries/) |
| [Cat.EFCore.Commands](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Commands/) | Base command handlers | net10.0, net11.0 | `dotnet add package gmarginet.Cat.EFCore.Commands` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Commands)](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Commands/) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.EFCore.Entities](namespaces/Cat.EFCore.Entities/index.md) | Base classes for regular, temporal and reference data entities. |
| [Cat.EFCore.Extensions](namespaces/Cat.EFCore.Extensions/index.md) | The part of the table setup that every database shares. It references no provider package. |
| [Cat.EFCore.Entities.SqlServer](namespaces/Cat.EFCore.Entities.SqlServer/index.md) | The entity base class for SQL Server temporal tables. |
| [Cat.EFCore.Extensions.SqlServer](namespaces/Cat.EFCore.Extensions.SqlServer/index.md) | Model builder extensions that configure the base classes on SQL Server, including temporal tables. |
| [Cat.EFCore.Extensions.PostgreSQL](namespaces/Cat.EFCore.Extensions.PostgreSQL/index.md) | Model builder extensions that configure the base classes on PostgreSQL. |
| [Cat.EFCore.Queries](namespaces/Cat.EFCore.Queries/index.md) | The base class for query handlers that read with EF Core, and a paging extension. |
| [Cat.EFCore.Commands](namespaces/Cat.EFCore.Commands/index.md) | The base classes for command handlers that change data with EF Core. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.EFCore needs it |
|--------|-------------------------|
| [Cat.Queries](../Cat.Queries/README.md) | `Cat.EFCore.Queries` implements `ICatQueryHandler` in its base class. |
| [Cat.Commands](../Cat.Commands/README.md) | `Cat.EFCore.Commands` implements `ICatCommandHandler` in its base classes. |
| [Cat.Responses](../Cat.Responses/README.md) | `Cat.EFCore.Queries` returns an `ICatPagedList` from the paging extension. |

Every project references only what it needs, so you pick the projects you use. `Cat.EFCore.Entities` targets `netstandard2.0`, and `Cat.EFCore.Entities.SqlServer` targets `netstandard2.0` and `net11.0`. Neither has a reference to EF Core. `Cat.EFCore.Entities` references the [SequentialGuid](https://www.nuget.org/packages/SequentialGuid/) package, which creates the time ordered Guid of `CatEntityBase.Id`. The other projects target `net10.0` and `net11.0`, and use EF Core 10 on `net10.0` and EF Core 11 on `net11.0`. `Cat.EFCore.Extensions.PostgreSQL` targets `net10.0` only for now.  
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
- `CatEntityBase`: a Guid primary key on `Id` and an identity column `SequenceId` with a unique index. On SQL Server the key is non-clustered and the index on `SequenceId` is clustered. `Id` gets a time ordered Guid (UUID version 7) when you create the entity, so its index fills at the end.
- `CatTemporalEntityBase`: the same as above, in a [temporal table](https://learn.microsoft.com/en-us/sql/relational-databases/tables/temporal/overview?view=sql-server-ver17) with a history table in the `History` schema.
- `CatReferenceEntityBase`: the primary key on `Id` (non-clustered on SQL Server), and the table is excluded from migrations.

`ConfigureCatEntity`, `ConfigureCatReferenceEntity` and `ConfigureCatTemporalEntity` live in `Cat.EFCore.Extensions.SqlServer`, because the keys, the identity column and the clustered index are SQL Server calls. Reference that project and add `using Cat.EFCore.Extensions.SqlServer;`. The namespaces have the same names as the projects. `CatTemporalEntityBase` lives in `Cat.EFCore.Entities.SqlServer`, and you need it only for temporal tables.

`Cat.EFCore.Extensions` holds the shared part of the setup and references no provider package. A project of one database never pulls in the package of another.

#### Moving from an earlier version
`ConfigureCatEntity` and `ConfigureCatReferenceEntity` used to live in `Cat.EFCore.Extensions`. They moved, and the old methods are gone.
- Reference `Cat.EFCore.Extensions.SqlServer` instead of `Cat.EFCore.Extensions`.
- Change `using Cat.EFCore.Extensions;` to `using Cat.EFCore.Extensions.SqlServer;`.
- The method names, the parameters and the SQL Server model stay the same, so you get no new migration.

### Use PostgreSQL
`Cat.EFCore.Extensions.PostgreSQL` has the same method names as the SQL Server project, `ConfigureCatEntity` and `ConfigureCatReferenceEntity`, in the namespace `Cat.EFCore.Extensions.PostgreSQL`. Reference that project instead and change the `using`. It uses the Npgsql provider and targets `net10.0` for now. The `net11.0` build follows when the Npgsql provider for EF Core 11 is stable.

The model has the same keys as on SQL Server. The differences:
- **No clustered index.** PostgreSQL stores a table as a heap, so the keys and the index on `SequenceId` have no clustered part. The Guid of `Id` is a time ordered one, so the primary key index still fills at the end.
- **The sequence column.** `SequenceId` is `GENERATED ALWAYS AS IDENTITY`. The database fills it, and an insert that gives a value fails. EF Core never writes it after the first save.
- **The schema.** The default schema is `public` and not `dbo`.
- **Temporal tables.** PostgreSQL has none, so there is no PostgreSQL version of `ConfigureCatTemporalEntity`.
- **The Guid** is stored as the native `uuid` type.

### Find an entity by id or sequence number
`FindByIdAsync` and `FindBySequenceIdAsync` are extension methods on `DbSet<TEntity>` in `Cat.EFCore.Extensions`. They work on every database. They read the primary key from the model. When the column you ask for is the key, they call `Find`. Otherwise they look in the change tracker first, like `Find` does, and then query the database.

```csharp
using Cat.EFCore.Extensions;

var todo = await context.Todos.FindByIdAsync(id, cancellationToken);
var other = await context.Todos.FindBySequenceIdAsync(42, cancellationToken);
```

Use them instead of the built-in `Find`. An extension method cannot be called `Find`, because the built-in instance method wins, and `Find(guid)` is wrong on a model where the Guid is not the key.

### What are temporal tables
A temporal table is a SQL Server feature. It keeps the full history of your data, not only the current rows.

- SQL Server stores the current rows in the table itself.
- Every update or delete moves the old row to a history table.
- Two period columns, `ValidFrom` and `ValidUntil`, say when a row version was valid. On `net11.0`, `CatTemporalEntityBase` has them as properties, so you can read them in a query. EF Core 10 only accepts a period column as a shadow property, so on `net10.0` the class has no such properties, and you read them with `EF.Property<DateTime>(entity, "ValidFrom")`. EF Core and SQL Server set the values, so never set them yourself.
- You can query the data as it was at any point in time.
- Only SQL Server supports them. Read the [overview of temporal tables](https://learn.microsoft.com/en-us/sql/relational-databases/tables/temporal/overview?view=sql-server-ver17) for the details.

### When to use `CatReferenceEntityBase`
Use it for a table that someone else owns, so you can point a foreign key at it.

- Several services share one database. Each service owns some of the tables.
- Your service needs a foreign key or navigation to a table of another service.
- You map that table in your own `DbContext` with `CatReferenceEntityBase`. Migrations never touch it, so the owner keeps control of the schema.
- Treat the entity as read-only. Only the owner changes the data.

Do not use it for your own tables. Use `CatEntityBase` for those, even when the data is a short list of fixed values.

### Query handlers
Inherit from `CatEfQueryHandlerBase` and write only what is special about the query.

```csharp
public class BookGetQueryHandler(CatalogDbContext dbContext)
    : CatEfQueryHandlerBase<CatalogDbContext, BookGetQuery, Book>(dbContext)
{
    public override async Task<ICatResponse<Book>> HandleAsync(BookGetQuery query, CancellationToken cancellationToken = default)
    {
        var book = await Set<Book>()
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == query.BookId, cancellationToken);

        return book is null ? CatResponse.NotFound<Book>(/* your error */) : CatResponse.Ok(book);
    }
}
```

- The context type is any `DbContext`, so a scaffolded context of a database first service works.
- `Set<TEntity>()` does not track the entities. Override `TrackChanges` in a handler that needs tracking.
- `ToPagedListAsync(pageNumber, pageSize)` on an `IQueryable` returns an `ICatPagedList`. Sort the query first. Sorting and filtering stay in your handler.

### Command handlers
Inherit from `CatEfCommandHandlerBase`. Use the version with a third type parameter when the command returns a result.

```csharp
public class BookSaveCommandHandler(CatalogDbContext dbContext)
    : CatEfCommandHandlerBase<CatalogDbContext, BookSaveCommand>(dbContext)
{
    public override async Task<ICatResponse> HandleAsync(BookSaveCommand command, CancellationToken cancellationToken = default)
    {
        DbContext.Books.Add(command.Book);
        await DbContext.SaveChangesAsync(cancellationToken);
        return CatResponse.Ok();
    }
}
```

- The base class only gives you `DbContext`. You decide when to start a transaction and when to call `SaveChanges`.
- `SaveChanges` is one transaction by itself. You only need your own transaction when you mix it with raw SQL or call it more than once.
- You map database errors to responses yourself. `Cat.Db.Errors.SqlServer` has helpers such as `IsUniqueViolation`.
- Every command runs in its own scope with its own `DbContext`, so two commands never share a transaction.
<!-- region end: Usage-->
