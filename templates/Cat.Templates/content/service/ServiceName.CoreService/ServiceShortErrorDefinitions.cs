using Cat.Responses;

namespace ServiceName.CoreService;

/// <summary>The error definitions of the service. Pick a prefix of three letters that no other service uses.</summary>
public static class ServiceShortErrorDefinitions
{
    private const string ServiceShortErrorCodePrefix = "SVC-EXA";

    public static readonly CatErrorDefinition ExampleNotFound = CatErrorDefinition.Create(ServiceShortErrorCodePrefix, 1000, "Example {ExampleId} does not exist.");
}
