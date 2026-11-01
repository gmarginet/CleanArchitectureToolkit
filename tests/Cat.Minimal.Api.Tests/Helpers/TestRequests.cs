using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.ServiceRequests.Minimal.Api;
using Microsoft.AspNetCore.JsonPatch.SystemTextJson;

namespace Cat.Minimal.Api.Tests.Helpers;

public record ItemModel(int Id, string Name);

/// <summary>
/// The model a JSON Patch document is applied to. The properties need setters, so the patch can change them.
/// </summary>
public class ItemPatchModel
{
    public string? Name { get; set; }
}

/// <summary>
/// Requests. The Outcome value comes from the query string and tells the handler which response to return.
/// </summary>
public record ItemGetRequest(int Id, string? Outcome) : ICatServiceRequest<ItemModel>;

public record ItemListRequest(string? Outcome, int? Page) : ICatServiceRequest<IList<ItemModel>>;

public record ItemPagedRequest(string? Outcome) : ICatServiceRequest<ICatPagedList<ItemModel>>;

public record ItemCreateRequest(ItemModel? Item, string? Outcome) : ICatServiceRequest<ItemModel>;

public record PingRequest(string? Outcome) : ICatServiceRequest;

public record ItemUpdateRequest(int Id, ItemModel? Item, string? Outcome) : ICatServiceRequest;

public record ItemDeleteRequest(int Id, string? Outcome) : ICatServiceRequest;

public record ItemRouteParameters(int Id, string? Outcome);

/// <summary>
/// Remembers what the patch document handler received, so a test can look at it.
/// </summary>
public class PatchRecorder
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public int? OperationCount { get; set; }
}

/// <summary>
/// Builds the response a handler returns for an outcome name.
/// </summary>
public static class Outcomes
{
    public static readonly ICatError Error = CatError.Create("ITM-1", "Item {what} failed", "x");

    public static ICatResponse<T> Respond<T>(string? outcome, string defaultOutcome, T value)
        => (outcome ?? defaultOutcome) switch
        {
            "ok" => CatResponse.Ok(value),
            "created" => CatResponse.Created(value),
            "nocontent" => CatResponse.NoContent<T>(),
            "badrequest" => CatResponse.BadRequest<T>(Error),
            "notfound" => CatResponse.NotFound<T>(Error),
            "conflict" => CatResponse.Conflict<T>(Error),
            "unauthorized" => CatResponse.Unauthorized<T>(Error),
            "forbidden" => CatResponse.Forbidden<T>(Error),
            "server" => CatResponse.InternalServerError<T>(Error),
            "throw" => throw new InvalidOperationException("secret detail"),
            var other => throw new ArgumentOutOfRangeException(nameof(outcome), other, "Unknown outcome.")
        };

    public static ICatResponse Respond(string? outcome, string defaultOutcome)
        => (outcome ?? defaultOutcome) switch
        {
            "ok" => CatResponse.Ok(),
            "created" => CatResponse.Created(),
            "nocontent" => CatResponse.NoContent(),
            "badrequest" => CatResponse.BadRequest(Error),
            "notfound" => CatResponse.NotFound(Error),
            "conflict" => CatResponse.Conflict(Error),
            "unauthorized" => CatResponse.Unauthorized(Error),
            "forbidden" => CatResponse.Forbidden(Error),
            "server" => CatResponse.InternalServerError(Error),
            "throw" => throw new InvalidOperationException("secret detail"),
            var other => throw new ArgumentOutOfRangeException(nameof(outcome), other, "Unknown outcome.")
        };
}

public class ItemGetRequestHandler : ICatServiceRequestHandler<ItemGetRequest, ItemModel>
{
    public Task<ICatResponse<ItemModel>> HandleAsync(ItemGetRequest serviceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(Outcomes.Respond(serviceRequest.Outcome, "ok", new ItemModel(serviceRequest.Id, "item " + serviceRequest.Id)));
}

public class ItemListRequestHandler : ICatServiceRequestHandler<ItemListRequest, IList<ItemModel>>
{
    public Task<ICatResponse<IList<ItemModel>>> HandleAsync(ItemListRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        IList<ItemModel> items = [new ItemModel(1, "first"), new ItemModel(2, "second")];
        return Task.FromResult(Outcomes.Respond(serviceRequest.Outcome, "ok", items));
    }
}

public class ItemPagedRequestHandler : ICatServiceRequestHandler<ItemPagedRequest, ICatPagedList<ItemModel>>
{
    public Task<ICatResponse<ICatPagedList<ItemModel>>> HandleAsync(ItemPagedRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        ICatPagedList<ItemModel> page = new CatPagedList<ItemModel>([new ItemModel(1, "first"), new ItemModel(2, "second")], 1, 10, 2);
        return Task.FromResult(Outcomes.Respond(serviceRequest.Outcome, "ok", page));
    }
}

public class ItemCreateRequestHandler : ICatServiceRequestHandler<ItemCreateRequest, ItemModel>
{
    public Task<ICatResponse<ItemModel>> HandleAsync(ItemCreateRequest serviceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(Outcomes.Respond(serviceRequest.Outcome, "created", serviceRequest.Item ?? new ItemModel(0, "none")));
}

public class PingRequestHandler : ICatServiceRequestHandler<PingRequest>
{
    public Task<ICatResponse> HandleAsync(PingRequest serviceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(Outcomes.Respond(serviceRequest.Outcome, "created"));
}

public class ItemUpdateRequestHandler : ICatServiceRequestHandler<ItemUpdateRequest>
{
    public Task<ICatResponse> HandleAsync(ItemUpdateRequest serviceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(Outcomes.Respond(serviceRequest.Outcome, "nocontent"));
}

public class ItemDeleteRequestHandler : ICatServiceRequestHandler<ItemDeleteRequest>
{
    public Task<ICatResponse> HandleAsync(ItemDeleteRequest serviceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(Outcomes.Respond(serviceRequest.Outcome, "nocontent"));
}

public class ItemPatchDocumentRequestHandler : ICatServiceRequestHandler<PatchDocumentRequest<ItemRouteParameters, ItemPatchModel>>
{
    private readonly PatchRecorder _recorder;

    public ItemPatchDocumentRequestHandler(PatchRecorder recorder)
    {
        _recorder = recorder;
    }

    public Task<ICatResponse> HandleAsync(PatchDocumentRequest<ItemRouteParameters, ItemPatchModel> serviceRequest, CancellationToken cancellationToken = default)
    {
        var model = new ItemPatchModel { Name = "original" };
        serviceRequest.PatchDocument.ApplyTo(model);

        _recorder.Id = serviceRequest.RouteParameters.Id;
        _recorder.Name = model.Name;
        _recorder.OperationCount = serviceRequest.PatchDocument.Operations.Count;

        return Task.FromResult(Outcomes.Respond(serviceRequest.RouteParameters.Outcome, "nocontent"));
    }
}
