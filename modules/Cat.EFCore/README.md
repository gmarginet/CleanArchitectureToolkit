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

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../README.md#module-overview)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>

# Cat.EFCore <!-- omit in toc -->  

<!-- Intro start-->
Set up Entity Framework Core entities the same way every time.  
Inherit from a base class, call one extension method in `OnModelCreating`, and get a Guid key, an identity sequence column, and optional temporal tables.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)

## NuGet packages
<!-- NuGet start -->
<!-- Badge: use the package named like the module, or the first project if there is none -->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.EFCore.Entities)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.EFCore.Entities](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Entities/) | Entity base classes | `dotnet add package gmarginet.Cat.EFCore.Entities` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Entities)](#nuget-packages) |
| [Cat.EFCore.Extensions](https://www.nuget.org/packages/gmarginet.Cat.EFCore.Extensions/) | Model builder extensions | `dotnet add package gmarginet.Cat.EFCore.Extensions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EFCore.Extensions)](#nuget-packages) |

<!-- NuGet end -->

## Namespaces
<!-- Namespaces start-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.EFCore.Entities](namespaces/Cat.EFCore.Entities/index.md) | Base classes for regular, temporal and reference data entities. |
| [Cat.EFCore.Extensions](namespaces/Cat.EFCore.Extensions/index.md) | Model builder extensions that configure keys, indexes and tables for the base classes. |

<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->
<!-- No dependencies: replace the table with "[[ModuleName]] has no dependencies on other CAT modules." -->
Cat.EFCore has no dependencies on other CAT modules.  
<!-- Dependencies end-->

## Usage
<!-- Usage start-->
Inherit your entities from the Cat base classes.

```csharp
public class Todo : CatEntityBase
{
    public string Title { get; set; } = string.Empty;
}

public class TodoHistoryItem : CatTemporalEntityBase
{
    public string Title { get; set; } = string.Empty;
}

public class TodoStatus : CatReferenceEntityBase
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
    modelBuilder.ConfigureCatReferenceEntity<TodoStatus>("TodoStatus", "todo");
}
```

What you get:
- `CatEntityBase`: a non-clustered Guid primary key on `Id` and a unique clustered index on the identity column `SequenceId`.
- `CatTemporalEntityBase`: the same as above, in a temporal table with a history table in the `History` schema.
- `CatReferenceEntityBase`: a non-clustered primary key, and the table is excluded from migrations.
<!-- Usage end-->
