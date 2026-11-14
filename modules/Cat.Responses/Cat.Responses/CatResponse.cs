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

    #region No Data Responses
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Ok"/> outcome and no value.</summary>
    public static ICatResponse Ok()
        => new CatResponse(CatResponseType.Ok);
    
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Created"/> outcome and no value.</summary>
    public static ICatResponse Created()
        => new CatResponse(CatResponseType.Created);
    
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.NoContent"/> outcome.</summary>
    public static ICatResponse NoContent()
        => new CatResponse(CatResponseType.NoContent);
    
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Accepted"/> outcome and no value.</summary>
    public static ICatResponse Accepted()
        => new CatResponse(CatResponseType.Accepted);

    /// <summary>Creates a failed response with the <see cref="CatResponseType.BadRequest"/> outcome.</summary>
    /// <param name="errors">The errors that caused the request to be rejected.</param>
    public static ICatResponse BadRequest(
        params ICatError[] errors)
        => new CatResponse(CatResponseType.BadRequest, errors);
    
    /// <summary>Creates a failed response with the <see cref="CatResponseType.NotFound"/> outcome.</summary>
    /// <param name="errors">The errors describing what couldn't be found.</param>
    public static ICatResponse NotFound(
        params ICatError[] errors)
        => new CatResponse(CatResponseType.NotFound, errors);
    
    /// <summary>Creates a failed response with the <see cref="CatResponseType.Conflict"/> outcome.</summary>
    /// <param name="errors">The errors describing the conflict.</param>
    public static ICatResponse Conflict(
        params ICatError[] errors)
        => new CatResponse(CatResponseType.Conflict, errors);
    
    /// <summary>Creates a failed response with the <see cref="CatResponseType.Unauthorized"/> outcome.</summary>
    /// <param name="errors">The errors describing why the caller isn't authenticated.</param>
    public static ICatResponse Unauthorized(
        params ICatError[] errors)
        => new CatResponse(CatResponseType.Unauthorized, errors);

    /// <summary>Creates a failed response with the <see cref="CatResponseType.Forbidden"/> outcome.</summary>
    /// <param name="errors">The errors describing why the caller isn't allowed.</param>
    public static ICatResponse Forbidden(
        params ICatError[] errors)
        => new CatResponse(CatResponseType.Forbidden, errors);
    
    /// <summary>Creates a failed response with the <see cref="CatResponseType.InternalServerError"/> outcome.</summary>
    /// <param name="errors">The errors describing what went wrong.</param>
    public static ICatResponse InternalServerError(
        params ICatError[] errors)
        => new CatResponse(CatResponseType.InternalServerError, errors);
    #endregion No Data Responses

    #region Data Responses
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Ok"/> outcome, carrying the given value.</summary>
    /// <typeparam name="TResponse">The type of value the response carries.</typeparam>
    /// <param name="value">The value the response carries.</param>
    public static ICatResponse<TResponse> Ok<TResponse>(
        TResponse value)
        => new CatResponse<TResponse>(CatResponseType.Ok, value);
    
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Created"/> outcome, carrying the given value.</summary>
    /// <typeparam name="TResponse">The type of value the response carries.</typeparam>
    /// <param name="value">The value the response carries.</param>
    public static ICatResponse<TResponse> Created<TResponse>(
        TResponse value)
        => new CatResponse<TResponse>(CatResponseType.Created,value);
    
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.NoContent"/> outcome and no value.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    public static ICatResponse<TResponse> NoContent<TResponse>()
        => new CatResponse<TResponse>(CatResponseType.NoContent);
    
    /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Accepted"/> outcome, carrying the given value.</summary>
    /// <typeparam name="TResponse">The type of value the response carries.</typeparam>
    /// <param name="value">The value the response carries.</param>
    public static ICatResponse<TResponse> Accepted<TResponse>(
        TResponse value)
        => new CatResponse<TResponse>(CatResponseType.Accepted, value);

    /// <summary>Creates a failed response with the <see cref="CatResponseType.BadRequest"/> outcome.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    /// <param name="errors">The errors that caused the request to be rejected.</param>
    public static ICatResponse<TResponse> BadRequest<TResponse>(
        params ICatError[] errors)
        => new CatResponse<TResponse>(CatResponseType.BadRequest, errors);
    
    /// <summary>Creates a failed response with the <see cref="CatResponseType.NotFound"/> outcome.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    /// <param name="errors">The errors describing what couldn't be found.</param>
    public static ICatResponse<TResponse> NotFound<TResponse>(
        params ICatError[] errors)
        => new CatResponse<TResponse>(CatResponseType.NotFound, errors);
    
    /// <summary>Creates a failed response with the <see cref="CatResponseType.Conflict"/> outcome.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    /// <param name="errors">The errors describing the conflict.</param>
    public static ICatResponse<TResponse> Conflict<TResponse>(
        params ICatError[] errors)
        => new CatResponse<TResponse>(CatResponseType.Conflict, errors);
    
    /// <summary>Creates a failed response with the <see cref="CatResponseType.Unauthorized"/> outcome.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    /// <param name="errors">The errors describing why the caller isn't authenticated.</param>
    public static ICatResponse<TResponse> Unauthorized<TResponse>(
        params ICatError[] errors)
        => new CatResponse<TResponse>(CatResponseType.Unauthorized, errors);

    /// <summary>Creates a failed response with the <see cref="CatResponseType.Forbidden"/> outcome.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    /// <param name="errors">The errors describing why the caller isn't allowed.</param>
    public static ICatResponse<TResponse> Forbidden<TResponse>(
        params ICatError[] errors)
        => new CatResponse<TResponse>(CatResponseType.Forbidden, errors);
    
    /// <summary>Creates a failed response with the <see cref="CatResponseType.InternalServerError"/> outcome.</summary>
    /// <typeparam name="TResponse">The value type the response is typed to.</typeparam>
    /// <param name="errors">The errors describing what went wrong.</param>
    public static ICatResponse<TResponse> InternalServerError<TResponse>(
        params ICatError[] errors)
        => new CatResponse<TResponse>(CatResponseType.InternalServerError, errors);
    #endregion Data Responses

    #region List Responses
    /// <summary>
    /// Factory methods for responses that carry a list of items.
    /// </summary>
    public static class List
    {
        /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Ok"/> outcome, carrying the given list.</summary>
        /// <typeparam name="TResponse">The type of the items in the list.</typeparam>
        /// <param name="list">The items the response carries.</param>
        public static ICatResponse<IReadOnlyList<TResponse>> Ok<TResponse>(
            IReadOnlyList<TResponse> list)
            => new CatResponse<IReadOnlyList<TResponse>>(CatResponseType.Ok, list);

        /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Created"/> outcome, carrying the given list.</summary>
        /// <typeparam name="TResponse">The type of the items in the list.</typeparam>
        /// <param name="list">The items the response carries.</param>
        public static ICatResponse<IReadOnlyList<TResponse>> Created<TResponse>(
            IReadOnlyList<TResponse> list)
            => new CatResponse<IReadOnlyList<TResponse>>(CatResponseType.Created, list);

        /// <summary>Creates a succeeded response with the <see cref="CatResponseType.NoContent"/> outcome and no list.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        public static ICatResponse<IReadOnlyList<TResponse>> NoContent<TResponse>()
            => new CatResponse<IReadOnlyList<TResponse>>(CatResponseType.NoContent);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.BadRequest"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors that caused the request to be rejected.</param>
        public static ICatResponse<IReadOnlyList<TResponse>> BadRequest<TResponse>(
            params ICatError[] errors)
            => new CatResponse<IReadOnlyList<TResponse>>(CatResponseType.BadRequest, errors);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.NotFound"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors describing what couldn't be found.</param>
        public static ICatResponse<IReadOnlyList<TResponse>> NotFound<TResponse>(
            params ICatError[] errors)
            => new CatResponse<IReadOnlyList<TResponse>>(CatResponseType.NotFound, errors);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.Conflict"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors describing the conflict.</param>
        public static ICatResponse<IReadOnlyList<TResponse>> Conflict<TResponse>(
            params ICatError[] errors)
            => new CatResponse<IReadOnlyList<TResponse>>(CatResponseType.Conflict, errors);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.Unauthorized"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors describing why the caller isn't authenticated.</param>
        public static ICatResponse<IReadOnlyList<TResponse>> Unauthorized<TResponse>(
            params ICatError[] errors)
            => new CatResponse<IReadOnlyList<TResponse>>(CatResponseType.Unauthorized, errors);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.Forbidden"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors describing why the caller isn't allowed.</param>
        public static ICatResponse<IReadOnlyList<TResponse>> Forbidden<TResponse>(
            params ICatError[] errors)
            => new CatResponse<IReadOnlyList<TResponse>>(CatResponseType.Forbidden, errors);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.InternalServerError"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors describing what went wrong.</param>
        public static ICatResponse<IReadOnlyList<TResponse>> InternalServerError<TResponse>(
            params ICatError[] errors)
            => new CatResponse<IReadOnlyList<TResponse>>(CatResponseType.InternalServerError, errors);
    }
    #endregion List Responses

    #region Paged List Responses
    /// <summary>
    /// Factory methods for responses that carry one page of a larger list.
    /// </summary>
    public static class PagedList
    {
        /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Ok"/> outcome, carrying the given page.</summary>
        /// <typeparam name="TResponse">The type of the items in the page.</typeparam>
        /// <param name="pagedList">The page the response carries.</param>
        public static ICatResponse<ICatPagedList<TResponse>> Ok<TResponse>(
            ICatPagedList<TResponse> pagedList)
            => new CatResponse<ICatPagedList<TResponse>>(CatResponseType.Ok, pagedList);

        /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Ok"/> outcome, carrying a page built from the given values.</summary>
        /// <typeparam name="TResponse">The type of the items in the page.</typeparam>
        /// <param name="list">The items on this page.</param>
        /// <param name="pageNumber">The number of this page. The first page is 1.</param>
        /// <param name="pageSize">The maximum number of items on a page.</param>
        /// <param name="totalItemCount">The number of items across all pages.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="list"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pageNumber"/> or <paramref name="pageSize"/> is less than 1, or <paramref name="totalItemCount"/> is negative.</exception>
        public static ICatResponse<ICatPagedList<TResponse>> Ok<TResponse>(
            IReadOnlyList<TResponse> list,
            int pageNumber,
            int pageSize,
            int totalItemCount)
            => new CatResponse<ICatPagedList<TResponse>>(
                CatResponseType.Ok,
                new CatPagedList<TResponse>(list, pageNumber, pageSize, totalItemCount));

        /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Created"/> outcome, carrying the given page.</summary>
        /// <typeparam name="TResponse">The type of the items in the page.</typeparam>
        /// <param name="pagedList">The page the response carries.</param>
        public static ICatResponse<ICatPagedList<TResponse>> Created<TResponse>(
            ICatPagedList<TResponse> pagedList)
            => new CatResponse<ICatPagedList<TResponse>>(CatResponseType.Created, pagedList);

        /// <summary>Creates a succeeded response with the <see cref="CatResponseType.Created"/> outcome, carrying a page built from the given values.</summary>
        /// <typeparam name="TResponse">The type of the items in the page.</typeparam>
        /// <param name="list">The items on this page.</param>
        /// <param name="pageNumber">The number of this page. The first page is 1.</param>
        /// <param name="pageSize">The maximum number of items on a page.</param>
        /// <param name="totalItemCount">The number of items across all pages.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="list"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="pageNumber"/> or <paramref name="pageSize"/> is less than 1, or <paramref name="totalItemCount"/> is negative.</exception>
        public static ICatResponse<ICatPagedList<TResponse>> Created<TResponse>(
            IReadOnlyList<TResponse> list,
            int pageNumber,
            int pageSize,
            int totalItemCount)
            => new CatResponse<ICatPagedList<TResponse>>(
                CatResponseType.Created,
                new CatPagedList<TResponse>(list, pageNumber, pageSize, totalItemCount));

        /// <summary>Creates a succeeded response with the <see cref="CatResponseType.NoContent"/> outcome and no page.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        public static ICatResponse<ICatPagedList<TResponse>> NoContent<TResponse>()
            => new CatResponse<ICatPagedList<TResponse>>(CatResponseType.NoContent);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.BadRequest"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors that caused the request to be rejected.</param>
        public static ICatResponse<ICatPagedList<TResponse>> BadRequest<TResponse>(
            params ICatError[] errors)
            => new CatResponse<ICatPagedList<TResponse>>(CatResponseType.BadRequest, errors);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.NotFound"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors describing what couldn't be found.</param>
        public static ICatResponse<ICatPagedList<TResponse>> NotFound<TResponse>(
            params ICatError[] errors)
            => new CatResponse<ICatPagedList<TResponse>>(CatResponseType.NotFound, errors);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.Conflict"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors describing the conflict.</param>
        public static ICatResponse<ICatPagedList<TResponse>> Conflict<TResponse>(
            params ICatError[] errors)
            => new CatResponse<ICatPagedList<TResponse>>(CatResponseType.Conflict, errors);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.Unauthorized"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors describing why the caller isn't authenticated.</param>
        public static ICatResponse<ICatPagedList<TResponse>> Unauthorized<TResponse>(
            params ICatError[] errors)
            => new CatResponse<ICatPagedList<TResponse>>(CatResponseType.Unauthorized, errors);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.Forbidden"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors describing why the caller isn't allowed.</param>
        public static ICatResponse<ICatPagedList<TResponse>> Forbidden<TResponse>(
            params ICatError[] errors)
            => new CatResponse<ICatPagedList<TResponse>>(CatResponseType.Forbidden, errors);

        /// <summary>Creates a failed response with the <see cref="CatResponseType.InternalServerError"/> outcome.</summary>
        /// <typeparam name="TResponse">The type of the items the response is typed to.</typeparam>
        /// <param name="errors">The errors describing what went wrong.</param>
        public static ICatResponse<ICatPagedList<TResponse>> InternalServerError<TResponse>(
            params ICatError[] errors)
            => new CatResponse<ICatPagedList<TResponse>>(CatResponseType.InternalServerError, errors);
    }
    #endregion Paged List Responses
}
