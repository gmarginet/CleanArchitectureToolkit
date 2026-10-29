namespace Cat.ServiceRequests.Abstractions;

/// <summary>
/// Marks a service request that returns a response with a payload.
/// Handle it with <see cref="ICatServiceRequestHandler{TRequest,TResponse}"/>.
/// </summary>
/// <typeparam name="TResponse">The type of the payload the handler returns.</typeparam>
public interface ICatServiceRequest<out TResponse>
{
}