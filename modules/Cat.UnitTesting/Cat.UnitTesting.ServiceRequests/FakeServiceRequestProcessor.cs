using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.UnitTesting.ServiceRequests;

/// <summary>
/// A service request processor for unit tests. It records every service request and returns what the test says.
/// It works like the fake command processor: a request without a result gets <see cref="DefaultResponse"/>,
/// and a request with a result needs a set up response.
/// </summary>
public class FakeServiceRequestProcessor : ICatServiceRequestProcessor
{
    private readonly Dictionary<Type, Func<object, object>> _responses = new Dictionary<Type, Func<object, object>>();

    /// <summary>
    /// The response of a service request without a result when the test set up nothing for its type.
    /// It starts as <see cref="CatResponse.Ok()"/>.
    /// </summary>
    public ICatResponse DefaultResponse { get; set; } = CatResponse.Ok();

    /// <summary>
    /// Every service request that was processed, in order. It holds requests with and without a result.
    /// </summary>
    public List<object> Requests { get; } = new List<object>();

    /// <summary>
    /// Sets the response for a service request without a result.
    /// </summary>
    /// <typeparam name="TRequest">The service request type.</typeparam>
    /// <param name="response">The response every request of this type gets.</param>
    /// <returns>The fake, so calls can be chained.</returns>
    public FakeServiceRequestProcessor Respond<TRequest>(ICatResponse response)
        where TRequest : ICatServiceRequest
    {
        return Respond<TRequest>(_ => response);
    }

    /// <summary>
    /// Sets the response for a service request without a result, built from the request.
    /// </summary>
    /// <typeparam name="TRequest">The service request type.</typeparam>
    /// <param name="respond">Builds the response from the request.</param>
    /// <returns>The fake, so calls can be chained.</returns>
    public FakeServiceRequestProcessor Respond<TRequest>(Func<TRequest, ICatResponse> respond)
        where TRequest : ICatServiceRequest
    {
        _responses[typeof(TRequest)] = request => respond((TRequest)request);
        return this;
    }

    /// <summary>
    /// Sets the response for a service request with a result.
    /// </summary>
    /// <typeparam name="TRequest">The service request type.</typeparam>
    /// <typeparam name="TResponse">The type of the result.</typeparam>
    /// <param name="response">The response every request of this type gets.</param>
    /// <returns>The fake, so calls can be chained.</returns>
    public FakeServiceRequestProcessor Respond<TRequest, TResponse>(ICatResponse<TResponse> response)
        where TRequest : ICatServiceRequest<TResponse>
    {
        return Respond<TRequest, TResponse>(_ => response);
    }

    /// <summary>
    /// Sets the response for a service request with a result, built from the request.
    /// </summary>
    /// <typeparam name="TRequest">The service request type.</typeparam>
    /// <typeparam name="TResponse">The type of the result.</typeparam>
    /// <param name="respond">Builds the response from the request.</param>
    /// <returns>The fake, so calls can be chained.</returns>
    public FakeServiceRequestProcessor Respond<TRequest, TResponse>(Func<TRequest, ICatResponse<TResponse>> respond)
        where TRequest : ICatServiceRequest<TResponse>
    {
        _responses[typeof(TRequest)] = request => respond((TRequest)request);
        return this;
    }

    /// <summary>
    /// Gives the processed service requests of one type, in order.
    /// </summary>
    /// <typeparam name="T">The service request type.</typeparam>
    /// <returns>The requests of this type.</returns>
    public IEnumerable<T> Of<T>() => Requests.OfType<T>();

    /// <summary>
    /// Clears the recorded requests, the set up responses and the default response.
    /// </summary>
    public void Reset()
    {
        Requests.Clear();
        _responses.Clear();
        DefaultResponse = CatResponse.Ok();
    }

    /// <inheritdoc />
    public Task<ICatResponse> ProcessAsync(ICatServiceRequest catServiceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(Process(catServiceRequest));

    /// <inheritdoc />
    public Task<ICatResponse<TResponse>> ProcessAsync<TResponse>(ICatServiceRequest<TResponse> catServiceRequest, CancellationToken cancellationToken = default)
        => Task.FromResult(Process(catServiceRequest));

    /// <inheritdoc />
    public ICatResponse Process(ICatServiceRequest catServiceRequest)
    {
        Requests.Add(catServiceRequest);

        return _responses.TryGetValue(catServiceRequest.GetType(), out var respond)
            ? (ICatResponse)respond(catServiceRequest)
            : DefaultResponse;
    }

    /// <inheritdoc />
    public ICatResponse<TResponse> Process<TResponse>(ICatServiceRequest<TResponse> catServiceRequest)
    {
        Requests.Add(catServiceRequest);

        return _responses.TryGetValue(catServiceRequest.GetType(), out var respond)
            ? (ICatResponse<TResponse>)respond(catServiceRequest)
            : throw new NotSupportedException($"No response is set up for {catServiceRequest.GetType().Name}. Call Respond first.");
    }
}
