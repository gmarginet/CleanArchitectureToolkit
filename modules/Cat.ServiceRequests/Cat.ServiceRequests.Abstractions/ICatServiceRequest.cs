namespace Cat.ServiceRequests.Abstractions;

/// <summary>
/// Marks a service request that returns a response without a payload.
/// Handle it with <see cref="ICatServiceRequestHandler{TRequest}"/>.
/// </summary>
public interface ICatServiceRequest
{
}
