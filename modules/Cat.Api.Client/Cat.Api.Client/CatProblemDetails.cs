using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cat.Api.Client;

/// <summary>
/// The body of a failed answer of a CAT service, as a plain class.
/// It has the same name and the same JSON shape as <c>CatProblemDetails</c> of <c>Cat.Minimal.Api</c>, without the ASP.NET Core base type.
/// A generated client finds this class through the <c>Cat.Api.Client</c> namespace.
/// </summary>
public class CatProblemDetails
{
    /// <summary>A link to the description of the problem type.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>A short summary of the problem.</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>The HTTP status code.</summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>An explanation specific to this occurrence of the problem.</summary>
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    /// <summary>The path of the request that failed.</summary>
    [JsonPropertyName("instance")]
    public string? Instance { get; set; }

    /// <summary>The errors of the failed response.</summary>
    [JsonPropertyName("catErrors")]
    public List<CatProblemDetailsItem>? CatErrors { get; set; }

    /// <summary>The id to find the request in the logs of the service.</summary>
    [JsonPropertyName("catTraceId")]
    public string? CatTraceId { get; set; }
}
