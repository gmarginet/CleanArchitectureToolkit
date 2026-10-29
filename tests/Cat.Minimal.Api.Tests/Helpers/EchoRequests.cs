using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Minimal.Api.Tests.Helpers;

/// <summary>
/// A request with a payload. It has a parameterless constructor, so an empty body is fine.
/// </summary>
public class EchoRequest : ICatServiceRequest<string>
{
    public string? Text { get; set; }
}

/// <summary>
/// A request with a payload and no parameterless constructor.
/// </summary>
public record PositionalRequest(string Name) : ICatServiceRequest<string>;

/// <summary>
/// A request without a payload.
/// </summary>
public class PingRequest : ICatServiceRequest
{
    public string? Text { get; set; }
}

public class EchoRequestHandler : ICatServiceRequestHandler<EchoRequest, string>
{
    public Task<ICatResponse<string>> HandleAsync(EchoRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var error = CatError.Create("ECH-1", "Echo {text} failed", serviceRequest.Text);

        return serviceRequest.Text switch
        {
            "bad" => Task.FromResult<ICatResponse<string>>(CatResponse.BadRequest<string>(error)),
            "notfound" => Task.FromResult<ICatResponse<string>>(CatResponse.NotFound<string>(error)),
            "unauthorized" => Task.FromResult<ICatResponse<string>>(CatResponse.Unauthorized<string>(error)),
            "server" => Task.FromResult<ICatResponse<string>>(CatResponse.InternalServerError<string>(error)),
            "throw" => throw new InvalidOperationException("secret detail"),
            _ => Task.FromResult<ICatResponse<string>>(CatResponse.Ok("echo:" + serviceRequest.Text))
        };
    }
}

public class PositionalRequestHandler : ICatServiceRequestHandler<PositionalRequest, string>
{
    public Task<ICatResponse<string>> HandleAsync(PositionalRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse<string>>(CatResponse.Ok("hello " + serviceRequest.Name));
    }
}

public class PingRequestHandler : ICatServiceRequestHandler<PingRequest>
{
    public Task<ICatResponse> HandleAsync(PingRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse>(serviceRequest.Text == "bad"
            ? CatResponse.BadRequest(CatError.Create("PNG-1", "Ping failed"))
            : CatResponse.Ok());
    }
}
