using Cat.Responses;

namespace Cat.Demo.InventoryService.CoreService;

public static class InventoryErrorDefinitions
{
    private const string InventoryErrorCodePrefix = "DEM-INV";

    public static readonly CatErrorDefinition OutOfStock = CatErrorDefinition.Create(InventoryErrorCodePrefix, 1000, "Book {Isbn} is out of stock. Order {OrderNumber} got no stock.");

    public static readonly CatErrorDefinition UnknownBook = CatErrorDefinition.Create(InventoryErrorCodePrefix, 1001, "Book {Isbn} is not in the warehouse. Order {OrderNumber} got no stock.");
}
