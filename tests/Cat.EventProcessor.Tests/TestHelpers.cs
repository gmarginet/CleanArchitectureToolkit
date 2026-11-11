using System.Text.Json;
using Cat.EventProcessor.Abstractions;
using Cat.Messaging.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.EventProcessor.Tests;

public class OrderPlaced : CatEventMessage, ICatServiceRequest
{
    public string OrderNumber { get; set; } = string.Empty;
}

public class ReserveStock : CatCommandMessage, ICatServiceRequest
{
    public int Quantity { get; set; }
}

public class FakeError(string code, string message) : ICatError
{
    public string Code { get; } = code;
    public string Message { get; } = message;
    public IList<object?> Arguments { get; } = new List<object?>();
}

/// <summary>
/// A service request processor that returns what the test says, and remembers the message that was current.
/// </summary>
public class FakeServiceRequestProcessor : ICatServiceRequestProcessor
{
    public Func<ICatServiceRequest, ICatResponse> Respond { get; set; } = _ => CatResponse.Ok();
    public CatMessageContextData? SeenContext { get; private set; }
    public ICatServiceRequest? SeenRequest { get; private set; }

    public Task<ICatResponse> ProcessAsync(ICatServiceRequest catServiceRequest, CancellationToken cancellationToken = default)
    {
        SeenContext = CatMessageContext.Current;
        SeenRequest = catServiceRequest;
        return Task.FromResult(Respond(catServiceRequest));
    }

    public Task<ICatResponse<TResponse>> ProcessAsync<TResponse>(ICatServiceRequest<TResponse> catServiceRequest, CancellationToken cancellationToken = default)
        => throw new NotSupportedException();

    public ICatResponse Process(ICatServiceRequest catServiceRequest) => throw new NotSupportedException();

    public ICatResponse<TResponse> Process<TResponse>(ICatServiceRequest<TResponse> catServiceRequest) => throw new NotSupportedException();
}

public static class Json
{
    public static byte[] Of(object value) =>
        JsonSerializer.SerializeToUtf8Bytes(value, new JsonSerializerOptions(JsonSerializerDefaults.Web));
}
