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

# Cat.Localizations <!-- omit in toc -->

<!-- region start: Intro-->
Cat.Localizations translates the reference data an admin creates, such as category names. The entity keeps its default text. The translations live in one table, next to it.

A developer reads the text in the language of the request, and an admin saves a translation per language. A language that has no translation gives the default text. A new language needs no schema change.

The module is for texts the admin owns. Fixed texts, such as a mail, use `IStringLocalizer` and resx files from .NET, and the module adds nothing for them. The screens of a client are out of scope too, because a client uses its own translation library. The module is plain .NET. It never references Aspire.
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Mark the entity](#mark-the-entity)
  - [Map the table](#map-the-table)
  - [Register the translator](#register-the-translator)
  - [Read a text](#read-a-text)
  - [Save a translation](#save-a-translation)
  - [Which culture is used](#which-culture-is-used)
  - [A missing translation](#a-missing-translation)
  - [The default culture of background work](#the-default-culture-of-background-work)
  - [Databases](#databases)
  - [What the module does not do](#what-the-module-does-not-do)

## NuGet packages
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Localizations.EFCore)](#nuget-packages)

| Package | Role | Targets | Install | Downloads |
|---------|------|---------|---------|-----------|
| [Cat.Localizations.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Localizations.Abstractions/) | Contracts | netstandard2.0 | `dotnet add package gmarginet.Cat.Localizations.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Localizations.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.Localizations.Abstractions/) |
| [Cat.Localizations.EFCore](https://www.nuget.org/packages/gmarginet.Cat.Localizations.EFCore/) | Implementation | net10.0, net11.0 | `dotnet add package gmarginet.Cat.Localizations.EFCore` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Localizations.EFCore)](https://www.nuget.org/packages/gmarginet.Cat.Localizations.EFCore/) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Localizations.Abstractions](namespaces/Cat.Localizations.Abstractions/index.md) | The marker of a translatable entity, the translation entity and the translator contract. |
| [Cat.Localizations.EFCore](namespaces/Cat.Localizations.EFCore/index.md) | The table mapping and the translator on EF Core. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

Cat.Localizations has no dependencies on other CAT modules.

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Mark the entity
Put the marker on the entity. The entity keeps the default text in its own field, and that text is the fallback. The core of a service, such as a `DataModels` project, only needs `Cat.Localizations.Abstractions`.

```csharp
public class Category : CatEntityBase, ICatTranslatable
{
    public string Name { get; set; } = "";
}
```

### Map the table
Call `AddCatTranslations` in `OnModelCreating`. It maps one table for every translatable entity, with a unique index on entity type, entity, field and culture. There is no foreign key, so one table serves them all. Add a migration as usual.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.AddCatTranslations();
}
```

The table is called `Translation` in the default schema. Pass another table or schema name when you need to.

### Register the translator
```csharp
services.AddCatLocalizations<CatalogDbContext>();
```

`ICatTranslator` is scoped, like the `DbContext`. It writes debug lines through `ILogger`, so the service needs logging, as a web host has.

### Read a text
Ask for one text, or for many with one database call. The default text is what you pass in.

```csharp
var name = await translator.GetTextAsync<Category>(category.Id, nameof(Category.Name), category.Name, ct);

var names = await translator.GetTextsAsync<Category>(
    categories.ToDictionary(c => c.Id, c => c.Name), nameof(Category.Name), ct);
```

An admin screen reads every language of one field with `GetTranslationsAsync`.

### Save a translation
`SetTextAsync` adds, changes or removes the translation of one field in one culture. It saves nothing. The change goes into the same `SaveChanges` as the change of the entity, so both are saved or neither. An empty text removes the translation.

```csharp
await translator.SetTextAsync<Category>(category.Id, nameof(Category.Name), "nl", "Boeken", ct);
await dbContext.SaveChangesAsync(ct);
```

### Which culture is used
Reads use `CultureInfo.CurrentUICulture`, the culture that `IStringLocalizer` reads too. ASP.NET Core request localization sets it for a request. A message handler gets it from the message when the service turns it on, see the [module readme of Cat.EventProcessor](../Cat.EventProcessor/README.md#culture-of-the-sender).

A specific culture falls back to its parent. `nl-BE` finds a translation saved as `nl-BE`, and when there is none, the one saved as `nl`. The more specific one wins.

### A missing translation
When an entity has no translation in the language of the user, the translator returns the default text of the entity and writes a line on the `Debug` level with the entity, the field and the language. A missing translation is a normal state while an admin works, so it is no warning.

### The default culture of background work
Work without a request or a message, such as a scheduled job, has no culture of its own. It uses the default culture of .NET. Set it once in `Program.cs`:

```csharp
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en");
```

### Databases
The mapping and the translator are plain EF Core, so they run on SQL Server and on PostgreSQL. The integration tests run on both, with the containers of `Cat.IntegrationTesting`.

### What the module does not do
- It does not translate fixed texts. Use `IStringLocalizer`.
- It does not translate the screens of a client.
- It does not localize error codes. The server returns the code with its English message, and the client translates the code.
- It has no Dapper project. One can follow when a developer needs it.
### Tests
The translator is plain EF Core, so a test runs it on SQLite in memory with the real registration. A handler that reads a translated text gets its answer from a real table, and a missing translation shows the default text.

```csharp
var connection = new SqliteConnection("DataSource=:memory:");
await connection.OpenAsync();

var services = new ServiceCollection();
services.AddLogging();
services.AddDbContext<ShopDbContext>(options => options.UseSqlite(connection));
services.AddCatLocalizations<ShopDbContext>();
var provider = services.BuildServiceProvider();

var scope = provider.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
await db.Database.EnsureCreatedAsync();
var translator = scope.ServiceProvider.GetRequiredService<ICatTranslator>();
```

`ShopDbContext` calls `AddCatTranslations` in `OnModelCreating`. Save a text, set the culture, and read it back:

```csharp
await translator.SetTextAsync<Category>(id, "Name", "nl", "Boeken");
await db.SaveChangesAsync();
CultureInfo.CurrentUICulture = new CultureInfo("nl");

var name = await translator.GetTextAsync<Category>(id, "Name", "Books");  // "Boeken"
```

Test a missing text the same way. With a culture that has no translation, the call returns the default text you pass in, `Books` here.

What to know:
- **Put the culture back.** `CultureInfo.CurrentUICulture` is a setting of the thread, so a test restores it in its `TearDown`, or a later test reads the wrong language.
- **Keep the connection open.** SQLite in memory drops the database when the last connection closes.
- **The example.** `ReadmeExampleTests` of this module holds it.
- **More cases.** `TranslatorTests` of this module also cover the parent culture, `nl-BE` falling back to `nl`, the invariant culture and reading many texts with one call.
<!-- region end: Usage-->
