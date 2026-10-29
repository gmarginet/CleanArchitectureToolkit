using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;

namespace Cat.ServiceRequests.Tests.Helpers;

public record CreateOrderRequest(string Name) : ICatServiceRequest;

public record GetOrderRequest(int Id) : ICatServiceRequest<string>;

public record NoValidatorRequest : ICatServiceRequest;

public record NoValidatorTypedRequest : ICatServiceRequest<string>;

public record UnhandledRequest : ICatServiceRequest;

public record UnhandledTypedRequest : ICatServiceRequest<string>;

/// <summary>
/// Remembers what the handlers saw. It is a singleton, so it outlives the scope of a call.
/// </summary>
public class RequestRecorder
{
    private readonly object _lock = new();

    public List<(string Request, Guid ScopeId, CancellationToken Token)> Calls { get; } = [];

    public void Add(string request, Guid scopeId, CancellationToken token)
    {
        lock (_lock) Calls.Add((request, scopeId, token));
    }
}

/// <summary>
/// A scoped service. Every scope gets its own id.
/// </summary>
public class ScopedMarker
{
    public Guid Id { get; } = Guid.NewGuid();
}

public class CreateOrderRequestHandler : ICatServiceRequestHandler<CreateOrderRequest>
{
    private readonly RequestRecorder _recorder;
    private readonly ScopedMarker _marker;

    public CreateOrderRequestHandler(RequestRecorder recorder, ScopedMarker marker)
    {
        _recorder = recorder;
        _marker = marker;
    }

    public Task<ICatResponse> HandleAsync(CreateOrderRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        _recorder.Add(nameof(CreateOrderRequest) + ":" + serviceRequest.Name, _marker.Id, cancellationToken);

        return serviceRequest.Name switch
        {
            "fail" => Task.FromResult<ICatResponse>(CatResponse.BadRequest(CatError.Create("ORD-1", "Order {name} failed", serviceRequest.Name))),
            "throw" => throw new InvalidOperationException("boom"),
            _ => Task.FromResult<ICatResponse>(CatResponse.Ok())
        };
    }
}

public class GetOrderRequestHandler : ICatServiceRequestHandler<GetOrderRequest, string>
{
    private readonly RequestRecorder _recorder;
    private readonly ScopedMarker _marker;

    public GetOrderRequestHandler(RequestRecorder recorder, ScopedMarker marker)
    {
        _recorder = recorder;
        _marker = marker;
    }

    public Task<ICatResponse<string>> HandleAsync(GetOrderRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        _recorder.Add(nameof(GetOrderRequest) + ":" + serviceRequest.Id, _marker.Id, cancellationToken);

        return serviceRequest.Id switch
        {
            404 => Task.FromResult<ICatResponse<string>>(CatResponse.NotFound<string>(CatError.Create("ORD-404", "Order {id} was not found", serviceRequest.Id))),
            500 => throw new InvalidOperationException("boom"),
            _ => Task.FromResult<ICatResponse<string>>(CatResponse.Ok("order:" + serviceRequest.Id))
        };
    }
}

public class NoValidatorRequestHandler : ICatServiceRequestHandler<NoValidatorRequest>
{
    public Task<ICatResponse> HandleAsync(NoValidatorRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse>(CatResponse.Ok());
    }
}

public class NoValidatorTypedRequestHandler : ICatServiceRequestHandler<NoValidatorTypedRequest, string>
{
    public Task<ICatResponse<string>> HandleAsync(NoValidatorTypedRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse<string>>(CatResponse.Ok("no validator"));
    }
}

/// <summary>
/// A generic handler. The module skips generic handlers when it scans.
/// </summary>
public class GenericRequestHandler<T> : ICatServiceRequestHandler<CreateOrderRequest>
{
    public Task<ICatResponse> HandleAsync(CreateOrderRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse>(CatResponse.Ok());
    }
}

public class CreateOrderRequestValidator : ICatValidator<CreateOrderRequest>
{
    public void Build(ICatValidatorBuilder<CreateOrderRequest> validator)
    {
        validator.AddPropertyRules(r => r.Name, b => b.NotEmpty());
    }
}

public class GetOrderRequestValidator : ICatValidator<GetOrderRequest>
{
    public void Build(ICatValidatorBuilder<GetOrderRequest> validator)
    {
        validator.AddPropertyRules(r => r.Id, b => b.GreaterThan(0));
    }
}
