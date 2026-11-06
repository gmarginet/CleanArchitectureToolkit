using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses;
using Cat.Responses.Abstractions;

namespace Cat.Api.Client;

/// <summary>
/// Runs a call of a generated client and turns the outcome into an <see cref="ICatResponse"/>.
/// A failed call looks like any other failed use case, so the caller never needs to catch the exceptions of the client.
/// </summary>
public static class CatApiCall
{
    /// <summary>
    /// Runs a call that returns a value.
    /// </summary>
    /// <typeparam name="TResponse">The type of the value of the call.</typeparam>
    /// <param name="call">The call to run, for example a method of a generated client.</param>
    /// <param name="serviceName">The name of the service that is called. It is used in the error of an unexpected answer.</param>
    /// <param name="cancellationToken">The token of the caller. A cancel by the caller is not turned into a response.</param>
    /// <returns>
    /// A succeeded response with the value, or a failed response with the errors of the service.
    /// The status of the answer picks the type: 400, 401, 403, 404 and 409 map to their own type, everything else
    /// to <see cref="CatResponseType.InternalServerError"/>.
    /// </returns>
    public static async Task<ICatResponse<TResponse>> ExecuteAsync<TResponse>(
        Func<Task<TResponse>> call,
        string serviceName,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return CatResponse.Ok(await call().ConfigureAwait(false));
        }
        catch (Exception ex) when (IsApiFailure(ex, cancellationToken))
        {
            return Fail<TResponse>(ex, serviceName);
        }
    }

    /// <summary>
    /// Runs a call that returns nothing.
    /// </summary>
    /// <param name="call">The call to run, for example a method of a generated client.</param>
    /// <param name="serviceName">The name of the service that is called. It is used in the error of an unexpected answer.</param>
    /// <param name="cancellationToken">The token of the caller. A cancel by the caller is not turned into a response.</param>
    /// <returns>A succeeded response, or a failed response with the errors of the service.</returns>
    public static async Task<ICatResponse> ExecuteAsync(
        Func<Task> call,
        string serviceName,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await call().ConfigureAwait(false);
            return CatResponse.Ok();
        }
        catch (Exception ex) when (IsApiFailure(ex, cancellationToken))
        {
            return Fail<object>(ex, serviceName);
        }
    }

    private static bool IsApiFailure(Exception exception, CancellationToken cancellationToken)
        => !cancellationToken.IsCancellationRequested
           && exception is CatApiException or HttpRequestException or JsonException or TaskCanceledException or NotSupportedException;

    private static ICatResponse<TResponse> Fail<TResponse>(Exception exception, string serviceName)
    {
        if (exception is not CatApiException apiException)
        {
            return CatResponse.InternalServerError<TResponse>(Unexpected(serviceName));
        }

        var errors = ReadErrors(apiException.Response);
        if (errors.Length == 0)
        {
            errors = [Unexpected(serviceName)];
        }

        switch (apiException.StatusCode)
        {
            case 400: return CatResponse.BadRequest<TResponse>(errors);
            case 401: return CatResponse.Unauthorized<TResponse>(errors);
            case 403: return CatResponse.Forbidden<TResponse>(errors);
            case 404: return CatResponse.NotFound<TResponse>(errors);
            case 409: return CatResponse.Conflict<TResponse>(errors);
            default: return CatResponse.InternalServerError<TResponse>(errors);
        }
    }

    private static ICatError Unexpected(string serviceName)
        => CatGeneralErrorDefinitions.UnexpectedResponse.CreateCatError(serviceName);

    /// <summary>Reads the errors of a failed answer. A body that is empty or has another shape gives no errors.</summary>
    private static ICatError[] ReadErrors(string? body)
    {
        if (string.IsNullOrWhiteSpace(body))
        {
            return [];
        }

        try
        {
            var problem = JsonSerializer.Deserialize<CatErrorResponse>(body!);
            return (problem?.CatErrors ?? [])
                .Where(error => !string.IsNullOrEmpty(error.Code) || !string.IsNullOrEmpty(error.Message))
                .Select(error => (ICatError)CatError.Create(
                    error.Code ?? string.Empty,
                    error.Message ?? string.Empty,
                    (error.Arguments ?? []).Select(ToPlainValue).ToList()))
                .ToArray();
        }
        catch (JsonException)
        {
            return [];
        }
    }

    /// <summary>The serializer reads an argument into a <see cref="JsonElement"/>. This turns it into a plain value.</summary>
    private static object? ToPlainValue(object? value)
    {
        if (value is not JsonElement element)
        {
            return value;
        }

        switch (element.ValueKind)
        {
            case JsonValueKind.String: return element.GetString();
            case JsonValueKind.True: return true;
            case JsonValueKind.False: return false;
            case JsonValueKind.Null:
            case JsonValueKind.Undefined: return null;
            case JsonValueKind.Number:
                return element.TryGetInt64(out var whole) ? whole : element.GetDouble();
            default: return element.GetRawText();
        }
    }
}
