using System;
using System.Collections.Generic;
using Cat.Responses.Abstractions;

namespace Cat.Responses;

/// <summary>
/// An <see cref="ICatResponse{TResponse}"/> implementation. Created through the static factory methods on
/// <see cref="CatResponse"/> rather than its constructors directly.
/// </summary>
/// <typeparam name="TResponse">The type of value the response carries.</typeparam>
public class CatResponse<TResponse> : CatResponse, ICatResponse<TResponse>
{
    /// <summary>
    /// Creates a succeeded response with no value.
    /// </summary>
    /// <param name="type">The specific succeeded outcome.</param>
    internal CatResponse(CatResponseType.Succeeded type) : base(type)
    {
        Value = default!;
    }

    /// <summary>
    /// Creates a succeeded response carrying the given value.
    /// </summary>
    /// <param name="type">The specific succeeded outcome.</param>
    /// <param name="value">The value the response carries.</param>
    internal CatResponse(CatResponseType.Succeeded type, TResponse value) : base(type)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a failed response with the given errors.
    /// </summary>
    /// <param name="type">The specific failed outcome.</param>
    /// <param name="errorList">The errors that caused the operation to fail.</param>
    internal CatResponse(CatResponseType.Failed type, IReadOnlyList<ICatError> errorList) : base(type, errorList)
    {
        Value = default!;
    }

    /// <inheritdoc />
    public TResponse Value { get; }

    /// <inheritdoc />
    public ICatResponse<TTargetResponse> Cast<TTargetResponse>(Func<TResponse, TTargetResponse> convertValue)
    {
        return Type switch
        {
            CatResponseType.Succeeded typeSucceeded => new CatResponse<TTargetResponse>(typeSucceeded, convertValue(Value)),
            CatResponseType.Failed => throw new InvalidOperationException("Cannot cast a failed response to a succeeded response."),
            _ => throw new NotImplementedException()
        };
    }
}