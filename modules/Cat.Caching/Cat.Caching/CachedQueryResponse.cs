using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Caching;

/// <summary>
/// What the cache stores for a query. A <c>CatResponse</c> cannot be read back from JSON, so the cache stores the outcome,
/// the value and, for a <c>NotFound</c>, the errors as code and message. A hit rebuilds the response with the factories of <c>CatResponse</c>.
/// The two derived classes only differ in how <c>HybridCache</c> sees them, see <see cref="CatImmutableTypes"/>.
/// </summary>
/// <typeparam name="T">The type of the value of the response.</typeparam>
internal abstract class CachedQueryResponse<T>
{
    private const string Ok = "Ok";
    private const string Created = "Created";
    private const string NoContent = "NoContent";
    private const string Accepted = "Accepted";
    private const string NotFound = "NotFound";

    public string Outcome { get; set; } = Ok;

    public T? Value { get; set; }

    public List<CachedError>? Errors { get; set; }

    public static bool IsNotFound(ICatResponse<T> response) => response.Type is CatResponseType.Failed.NotFound;

    public static TCached From<TCached>(ICatResponse<T> response)
        where TCached : CachedQueryResponse<T>, new()
    {
        var cached = new TCached { Value = response.Value };
        switch (response.Type)
        {
            case CatResponseType.Succeeded.Ok:
                cached.Outcome = Ok;
                break;
            case CatResponseType.Succeeded.Created:
                cached.Outcome = Created;
                break;
            case CatResponseType.Succeeded.NoContent:
                cached.Outcome = NoContent;
                break;
            case CatResponseType.Succeeded.Accepted:
                cached.Outcome = Accepted;
                break;
            case CatResponseType.Failed.NotFound:
                cached.Outcome = NotFound;
                cached.Value = default;
                cached.Errors = response.ErrorList
                    .Select(error => new CachedError
                    {
                        Code = error.Code,
                        Message = error.Message,
                        Arguments = error.Arguments.Select(argument => argument?.ToString()).ToList()
                    })
                    .ToList();
                break;
            default:
                throw new InvalidOperationException($"A response with the outcome {response.Type.GetType().Name} cannot be cached.");
        }

        return cached;
    }

    public ICatResponse<T> ToResponse()
    {
        switch (Outcome)
        {
            case Ok:
                return CatResponse.Ok(Value!);
            case Created:
                return CatResponse.Created(Value!);
            case NoContent:
                return CatResponse.NoContent<T>();
            case Accepted:
                return CatResponse.Accepted(Value!);
            case NotFound:
                var errors = (Errors ?? new List<CachedError>())
                    .Select(error => (ICatError)CatError.Create(error.Code, error.Message,
                        error.Arguments.Select(argument => (object?)argument).ToArray()))
                    .ToArray();
                return CatResponse.NotFound<T>(errors);
            default:
                throw new InvalidOperationException($"The cache holds an unknown outcome: {Outcome}.");
        }
    }
}

/// <summary>
/// An error of a cached <c>NotFound</c>. The arguments are kept as text, so a reader of an argument gets text and not the original object.
/// </summary>
internal sealed class CachedError
{
    public string Code { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public List<string?> Arguments { get; set; } = new List<string?>();
}

/// <summary>
/// The stored form for a value that <c>HybridCache</c> must treat as mutable. Every hit gets a copy.
/// </summary>
internal sealed class MutableCachedQueryResponse<T> : CachedQueryResponse<T>
{
}

/// <summary>
/// The stored form for a value that is immutable. <c>HybridCache</c> hands out the same instance on a hit.
/// </summary>
[ImmutableObject(true)]
internal sealed class ImmutableCachedQueryResponse<T> : CachedQueryResponse<T>
{
}
