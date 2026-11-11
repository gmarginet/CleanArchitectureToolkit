using System;
using System.Text.Json;

namespace Cat.Messaging;

/// <summary>
/// <see cref="ICatMessageSerializer"/> on System.Text.Json with the web defaults.
/// </summary>
internal sealed class SystemTextJsonMessageSerializer : ICatMessageSerializer
{
    private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web);

    /// <inheritdoc />
    public string ContentType => "application/json";

    /// <inheritdoc />
    public byte[] Serialize(object message, Type messageType)
    {
        return JsonSerializer.SerializeToUtf8Bytes(message, messageType, Options);
    }
}
