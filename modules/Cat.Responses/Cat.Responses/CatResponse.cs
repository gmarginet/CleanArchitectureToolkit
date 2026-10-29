using System;
using System.Collections.Generic;
using Cat.Responses.Abstractions;

namespace Cat.Responses;

/// <summary>
/// The default <see cref="ICatResponse"/> implementation. Create instances through its static factory methods,
/// such as <see cref="Ok()"/> and <see cref="NotFound"/>, rather than its constructors directly.
/// </summary>
public class CatResponse : ICatResponse
{
    /// <summary>
    /// Creates a succeeded response with no errors.
    /// </summary>
    /// <param name="type">The specific succeeded outcome.</param>
    internal CatResponse(CatResponseType.Succeeded type)
    {
        Type = type;
        ErrorList = [];
    }

    /// <summary>
    /// Creates a failed response with the given errors.
    /// </summary>
    /// <param name="type">The specific failed outcome.</param>
    /// <param name="errorList">The errors that caused the operation to fail.</param>
    internal CatResponse(CatResponseType.Failed type, IReadOnlyList<ICatError> errorList)
    {
        Type = type;
        ErrorList = errorList;
    }

    /// <inheritdoc />
    public CatResponseType Type { get; private set; }

    /// <inheritdoc />
    public IReadOnlyList<ICatError> ErrorList { get; private set; }

    /// <inheritdoc />
    public bool IsSucceeded => Type is CatResponseType.Succeeded;

    /// <inheritdoc />
    public bool IsFailed => Type is CatResponseType.Failed;

    /// <inheritdoc />
    public ICatResponse<TResponse> Cast<TResponse>()
    {
        return Type switch
        {
            CatResponseType.Succeeded => throw new InvalidOperationException("Cannot cast a succeeded response to a failed response."),
            CatResponseType.Failed typeFailed => new CatResponse<TResponse>(typeFailed, ErrorList),
            _ => throw new NotImplementedException()
        };
    }

    /// <inheritdoc />
    public ICatResponse<TResponse> Cast<TResponse>(TResponse value)
    {
        return Type switch
        {
            CatResponseType.Succeeded typeSucceeded => new CatResponse<TResponse>(typeSucceeded, value),
            CatResponseType.Failed => throw new InvalidOperationException("Cannot cast a failed response to a succeeded response."),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Ok"/> outcome and no value.</summary>
    public static ICatResponse Ok() => new CatResponse(CatResponseType.Ok);
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Created"/> outcome and no value.</summary>
    public static ICatResponse Created() => new CatResponse(CatResponseType.Created);
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.NoContent"/> outcome.</summary>
    public static ICatResponse NoContent() => new CatResponse(CatResponseType.NoContent);
    /// <summary>Creates a failed response with the <see cref="CatResponseType.BadRequest"/> outcome.</summary>
    /// <param name="errors">The errors that caused the request to be rejected.</param>
    public static ICatResponse BadRequest(params ICatError[] errors) => new CatResponse(CatResponseType.BadRequest, errors);
    /// <summary>Creates a failed response with the <see cref="CatResponseType.NotFound"/> outcome.</summary>
    /// <param name="errors">The errors describing what couldn't be found.</param>
    public static ICatResponse NotFound(params ICatError[] errors) => new CatResponse(CatResponseType.NotFound, errors);
    /// <summary>Creates a failed response with the <see cref="CatResponseType.Unauthorized"/> outcome.</summary>
    /// <param name="errors">The errors describing why the caller isn't authorized.</param>
    public static ICatResponse Unauthorized(params ICatError[] errors) => new CatResponse(CatResponseType.Unauthorized, errors);
    /// <summary>Creates a failed response with the <see cref="CatResponseType.InternalServerError"/> outcome.</summary>
    /// <param name="errors">The errors describing what went wrong.</param>
    public static ICatResponse InternalServerError(params ICatError[] errors) => new CatResponse(CatResponseType.InternalServerError, errors);

    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Ok"/> outcome, carrying the given value.</summary>
    /// <typeparam name="TResponse">The type of value the response carries.</typeparam>
    /// <param name="value">The value the response carries.</param>
    public static ICatResponse<TResponse> Ok<TResponse>(TResponse value) => new CatResponse<TResponse>(CatResponseType.Ok, value);
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Created"/> outcome, carrying the given value.</summary>
    /// <typeparam name="TResponse">The type of value the response carries.</typeparam>
    /// <param name="value">The value the response carries.</param>
    public static ICatResponse<TResponse> Created<TResponse>(TResponse value) => new CatResponse<TResponse>(CatResponseType.Created,value);
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.NoContent"/> outcome and no value.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    public static ICatResponse<TResponse> NoContent<TResponse>() => new CatResponse<TResponse>(CatResponseType.NoContent);
    /// <summary>Creates a failed response with the <see cref="CatResponseType.BadRequest"/> outcome.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    /// <param name="errors">The errors that caused the request to be rejected.</param>
    public static ICatResponse<TResponse> BadRequest<TResponse>(params ICatError[] errors) => new CatResponse<TResponse>(CatResponseType.BadRequest, errors);
    /// <summary>Creates a failed response with the <see cref="CatResponseType.NotFound"/> outcome.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    /// <param name="errors">The errors describing what couldn't be found.</param>
    public static ICatResponse<TResponse> NotFound<TResponse>(params ICatError[] errors) => new CatResponse<TResponse>(CatResponseType.NotFound, errors);
    /// <summary>Creates a failed response with the <see cref="CatResponseType.Unauthorized"/> outcome.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    /// <param name="errors">The errors describing why the caller isn't authorized.</param>
    public static ICatResponse<TResponse> Unauthorized<TResponse>(params ICatError[] errors) => new CatResponse<TResponse>(CatResponseType.Unauthorized, errors);
    /// <summary>Creates a failed response with the <see cref="CatResponseType.InternalServerError"/> outcome.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    /// <param name="errors">The errors describing what went wrong.</param>
    public static ICatResponse<TResponse> InternalServerError<TResponse>(params ICatError[] errors) => new CatResponse<TResponse>(CatResponseType.InternalServerError, errors);
}
