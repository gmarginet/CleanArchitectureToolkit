using Cat.Responses;

namespace Cat.Demo.CatalogService.CoreService;

public static class CatalogErrorDefinitions
{
    private const string CatalogErrorCodePrefix = "CAT-CTL-";

    public static readonly CatErrorDefinition IsbnAlreadyExists = CatErrorDefinition.Create($"{CatalogErrorCodePrefix}1000", "A book with ISBN {Isbn} already exists.");
}
