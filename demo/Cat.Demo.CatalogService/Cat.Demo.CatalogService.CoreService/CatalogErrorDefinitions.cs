using Cat.Responses;

namespace Cat.Demo.CatalogService.CoreService;

public static class CatalogErrorDefinitions
{
    private const string CatalogErrorCodePrefix = "DEM-CTL";

    public static readonly CatErrorDefinition IsbnAlreadyExists = CatErrorDefinition.Create(CatalogErrorCodePrefix, 1000, "A book with ISBN {Isbn} already exists.");

    public static readonly CatErrorDefinition BookPriceNotFound = CatErrorDefinition.Create(CatalogErrorCodePrefix, 1001, "Book {BookId} does not exist or has no price.");
}
