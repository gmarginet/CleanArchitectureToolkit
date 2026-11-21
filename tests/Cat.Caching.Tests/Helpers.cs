using System.ComponentModel;
using Cat.Queries.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Users.Abstractions;

namespace Cat.Caching.Tests;

/// <summary>Counts the calls of the handlers and decides what they answer.</summary>
public sealed class Probe
{
    private int _calls;

    public int Calls => _calls;

    public Func<int, ICatResponse<string>> RespondString { get; set; } = call => CatResponse.Ok($"v{call}");

    public Func<int, ICatResponse<IList<string>>> RespondList { get; set; } = call => CatResponse.Ok<IList<string>>(new List<string> { $"v{call}" });

    public Func<int, ICatResponse<int>> RespondInt { get; set; } = call => CatResponse.Ok(call);

    public Func<int, ICatResponse<ImmutableResult>> RespondImmutable { get; set; } = call => CatResponse.Ok(new ImmutableResult($"v{call}"));

    public int Next() => Interlocked.Increment(ref _calls);
}

public sealed class UserHolder
{
    public ICatUser? User { get; set; }
}

public sealed class TestUser(string id) : ICatUser
{
    public string UserId => id;

    public string Name => id;

    public bool IsAuthenticated => id.Length > 0;

    public bool IsInRole(string role) => false;
}

public sealed record StringQuery(string Name) : ICatQuery<string>;

public sealed record OtherStringQuery(string Name) : ICatQuery<string>;

public sealed record ListQuery(string Name) : ICatQuery<IList<string>>;

public sealed record NumberQuery : ICatQuery<int>;

public sealed record ImmutableQuery : ICatQuery<ImmutableResult>;

/// <summary>A query with a property that cannot be serialized, so it cannot make a key.</summary>
public sealed record BadKeyQuery(Action Callback) : ICatQuery<string>;

[ImmutableObject(true)]
public sealed record ImmutableResult(string Value);

public sealed class StringQueryHandler(Probe probe) : ICatQueryHandler<StringQuery, string>
{
    public Task<ICatResponse<string>> HandleAsync(StringQuery query, CancellationToken cancellationToken = default)
        => Task.FromResult(probe.RespondString(probe.Next()));
}

public sealed class OtherStringQueryHandler(Probe probe) : ICatQueryHandler<OtherStringQuery, string>
{
    public Task<ICatResponse<string>> HandleAsync(OtherStringQuery query, CancellationToken cancellationToken = default)
        => Task.FromResult(probe.RespondString(probe.Next()));
}

public sealed class ListQueryHandler(Probe probe) : ICatQueryHandler<ListQuery, IList<string>>
{
    public Task<ICatResponse<IList<string>>> HandleAsync(ListQuery query, CancellationToken cancellationToken = default)
        => Task.FromResult(probe.RespondList(probe.Next()));
}

public sealed class NumberQueryHandler(Probe probe) : ICatQueryHandler<NumberQuery, int>
{
    public Task<ICatResponse<int>> HandleAsync(NumberQuery query, CancellationToken cancellationToken = default)
        => Task.FromResult(probe.RespondInt(probe.Next()));
}

public sealed class ImmutableQueryHandler(Probe probe) : ICatQueryHandler<ImmutableQuery, ImmutableResult>
{
    public Task<ICatResponse<ImmutableResult>> HandleAsync(ImmutableQuery query, CancellationToken cancellationToken = default)
        => Task.FromResult(probe.RespondImmutable(probe.Next()));
}

public sealed class BadKeyQueryHandler(Probe probe) : ICatQueryHandler<BadKeyQuery, string>
{
    public Task<ICatResponse<string>> HandleAsync(BadKeyQuery query, CancellationToken cancellationToken = default)
        => Task.FromResult(probe.RespondString(probe.Next()));
}
