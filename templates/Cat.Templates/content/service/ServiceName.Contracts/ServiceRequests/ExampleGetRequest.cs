using Cat.ServiceRequests.Abstractions;
using ServiceName.Contracts.Models;

namespace ServiceName.Contracts.ServiceRequests;

/// <summary>Gets one example item. It proves that the service builds, starts and reaches its database.</summary>
public record ExampleGetRequest(Guid ExampleId) : ICatServiceRequest<ExampleModel>;
