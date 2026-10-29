using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Queries.Tests.Helpers;

public record GetUserQuery(string Name) : ICatQuery<string>;

public record GetCountQuery : ICatQuery<int>;

public record UnhandledQuery : ICatQuery<string>;

/// <summary>
/// Remembers what the handler saw. It is a singleton, so it outlives the scope of a call.
/// </summary>
public class QueryRecorder
{
    private readonly object _lock = new();

    public List<(string Name, Guid ScopeId, CancellationToken Token)> Calls { get; } = [];

    public void Add(string name, Guid scopeId, CancellationToken token)
    {
        lock (_lock) Calls.Add((name, scopeId, token));
    }
}

/// <summary>
/// A scoped service. Every scope gets its own id.
/// </summary>
public class ScopedMarker
{
    public Guid Id { get; } = Guid.NewGuid();
}

public class GetUserQueryHandler : ICatQueryHandler<GetUserQuery, string>
{
    private readonly QueryRecorder _recorder;
    private readonly ScopedMarker _marker;

    public GetUserQueryHandler(QueryRecorder recorder, ScopedMarker marker)
    {
        _recorder = recorder;
        _marker = marker;
    }

    public Task<ICatResponse<string>> HandleAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        _recorder.Add(query.Name, _marker.Id, cancellationToken);

        return query.Name switch
        {
            "missing" => Task.FromResult<ICatResponse<string>>(CatResponse.NotFound<string>(
                CatError.Create("USR-404", "User {name} was not found", query.Name))),
            "throw" => throw new InvalidOperationException("boom"),
            _ => Task.FromResult<ICatResponse<string>>(CatResponse.Ok("user:" + query.Name))
        };
    }
}

public class GetCountQueryHandler : ICatQueryHandler<GetCountQuery, int>
{
    public Task<ICatResponse<int>> HandleAsync(GetCountQuery query, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse<int>>(CatResponse.Ok(3));
    }
}

/// <summary>
/// A generic handler. The module skips generic handlers when it scans.
/// </summary>
public class GenericQueryHandler<T> : ICatQueryHandler<GetCountQuery, int>
{
    public Task<ICatResponse<int>> HandleAsync(GetCountQuery query, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ICatResponse<int>>(CatResponse.Ok(0));
    }
}
