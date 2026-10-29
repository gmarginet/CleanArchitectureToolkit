namespace Cat.Responses;

/// <summary>
/// Common error definitions shared across CAT modules.
/// </summary>
public static class CatGeneralErrorDefinitions
{
    private const string GeneralErrorCodePrefix = "CAT-GEN-";

    /// <summary>An error occurred whose cause couldn't be determined.</summary>
    public static readonly CatErrorDefinition Unknown = CatErrorDefinition.Create($"{GeneralErrorCodePrefix}1000", "An unknown error occurred.");

    /// <summary>A dependency returned a response that wasn't expected.</summary>
    public static readonly CatErrorDefinition UnexpectedResponse = CatErrorDefinition.Create($"{GeneralErrorCodePrefix}1001", "An unexpected response was returned. ({Service})");

    /// <summary>The requested resource couldn't be found.</summary>
    public static readonly CatErrorDefinition ResourceNotFound = CatErrorDefinition.Create($"{GeneralErrorCodePrefix}1002", "The requested {ResourceName} with id {ResourceId} was not found.");
}