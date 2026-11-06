using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cat.Api.Client;

/// <summary>
/// One error in a <see cref="CatErrorResponse"/>.
/// </summary>
public class CatErrorResponseItem
{
    /// <summary>The stable code of the error.</summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>The message template. It can hold placeholders that the arguments fill in.</summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>The values for the placeholders of the message, in order.</summary>
    [JsonPropertyName("arguments")]
    public List<object?>? Arguments { get; set; }
}
