using System;

namespace Cat.Demo.CatalogService.Contracts.Models;

/// <summary>A category as the admin edits it, with its default name and the Dutch translation.</summary>
public class CategoryEditModel
{
    public Guid Id { get; set; }

    /// <summary>The default name, in English.</summary>
    public required string Name { get; set; }

    /// <summary>The Dutch name. Empty means the category shows its default name to a Dutch user.</summary>
    public string? NameNl { get; set; }
}
