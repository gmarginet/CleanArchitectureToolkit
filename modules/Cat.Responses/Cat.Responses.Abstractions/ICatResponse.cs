using System.Collections.Generic;

namespace Cat.Responses.Abstractions;

/// <summary>
/// Represents the outcome of an operation: whether it succeeded or failed, its specific <see cref="CatResponseType"/>,
/// and any errors that caused it to fail.
/// </summary>
public interface ICatResponse
{
    /// <summary>
    /// The specific outcome of the operation, such as <see cref="CatResponseType.Ok"/> or <see cref="CatResponseType.NotFound"/>.
    /// </summary>
    CatResponseType Type { get; }

    /// <summary>
    /// The errors that caused the operation to fail. Empty when <see cref="IsSucceeded"/> is <c>true</c>.
    /// </summary>
    IReadOnlyList<ICatError> ErrorList { get; }

    /// <summary>
    /// <c>true</c> if the operation succeeded.
    /// </summary>
    bool IsSucceeded { get; }

    /// <summary>
    /// <c>true</c> if the operation failed.
    /// </summary>
    bool IsFailed { get; }

    /// <summary>
    /// Converts this response into an <see cref="ICatResponse{TResponse}"/>, carrying over its type and errors.
    /// Only valid when <see cref="IsFailed"/> is <c>true</c>, since no value is supplied for the succeeded case.
    /// </summary>
    /// <typeparam name="TResponse">The value type of the resulting response.</typeparam>
    /// <returns>A failed response with the same type and errors.</returns>
    ICatResponse<TResponse> Cast<TResponse>();

    /// <summary>
    /// Converts this response into an <see cref="ICatResponse{TResponse}"/> carrying the given value, keeping this response's type.
    /// </summary>
    /// <typeparam name="TResponse">The value type of the resulting response.</typeparam>
    /// <param name="value">The value to carry on the resulting response. Only used when <see cref="IsSucceeded"/> is <c>true</c>.</param>
    /// <returns>A response with the same type, carrying <paramref name="value"/> if it succeeded.</returns>
    ICatResponse<TResponse> Cast<TResponse>(TResponse value);
}
