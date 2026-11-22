using Cat.Responses;

namespace ServiceName.CoreService;

/// <summary>The error definitions of ItemName. Every error has a code, a number and a message with named arguments.</summary>
public static class ItemNameErrorDefinitions
{
    private const string ItemNameErrorCodePrefix = "ERROR_PREFIX";

    public static readonly CatErrorDefinition NotFound = CatErrorDefinition.Create(ItemNameErrorCodePrefix, 1000, "ItemName {Id} does not exist.");
}
