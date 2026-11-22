namespace Cat.Demo.CatalogService.CoreService;

/// <summary>The tags of the cached catalog queries. The registration and the code that clears them use the same constant.</summary>
public static class CatalogCacheTags
{
    /// <summary>Every cached answer that lists books.</summary>
    public const string Books = "books";

    /// <summary>The cached category list.</summary>
    public const string Categories = "categories";
}
