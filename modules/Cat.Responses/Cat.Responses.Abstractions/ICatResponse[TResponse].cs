using System;

namespace Cat.Responses.Abstractions;

/// <summary>
/// An <see cref="ICatResponse"/> that carries a value when it succeeds.
/// </summary>
/// <typeparam name="TResponse">The type of value the response carries.</typeparam>
public interface ICatResponse<TResponse> : ICatResponse
{
    /// <summary>
    /// The value the operation produced. Only meaningful when <see cref="ICatResponse.IsSucceeded"/> is <c>true</c>.
    /// </summary>
    TResponse Value { get; }

    /// <summary>
    /// Converts this response's value to another type, keeping its type and errors.
    /// </summary>
    /// <typeparam name="TTargetResponse">The value type of the resulting response.</typeparam>
    /// <param name="convertValue">Converts <see cref="Value"/> to <typeparamref name="TTargetResponse"/>. Only invoked when the response succeeded.</param>
    /// <returns>A response of the same type, carrying the converted value if it succeeded.</returns>
    ICatResponse<TTargetResponse> Cast<TTargetResponse>(Func<TResponse, TTargetResponse> convertValue);
}