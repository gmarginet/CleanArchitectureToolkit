using Cat.ServiceRequests.Abstractions;

namespace ServiceName.Contracts.ServiceRequests;

/// <summary>
/// The request that the scheduler sends. Replace it with the work of your job.
/// A job can run more than once, so write the handler to survive that.
/// </summary>
public record ExampleJobRequest : ICatServiceRequest;
