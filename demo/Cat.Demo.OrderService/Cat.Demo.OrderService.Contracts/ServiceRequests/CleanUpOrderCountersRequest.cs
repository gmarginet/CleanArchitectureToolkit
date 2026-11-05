using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.Contracts.ServiceRequests;

/// <summary>
/// Deletes the order counters of earlier days and creates the counter of today (UTC).
/// The scheduler runs it every night. You can run it at any time, and more than once.
/// </summary>
public record CleanUpOrderCountersRequest : ICatServiceRequest;
