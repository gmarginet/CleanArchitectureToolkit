using Cat.Responses;

namespace Cat.Validators;

public static class CatDemoErrorDefinitions
{
    private const string DemoErrorCodePrefix = "CAT-DEM-";

    public static readonly CatErrorDefinition NotFound = CatErrorDefinition.Create($"{DemoErrorCodePrefix}1000", "{ResourceName} with id {id} could not be found.");
}