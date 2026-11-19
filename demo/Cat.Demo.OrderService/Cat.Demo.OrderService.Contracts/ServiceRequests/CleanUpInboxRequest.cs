using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.Contracts.ServiceRequests;

/// <summary>
/// Deletes the inbox rows that are older than 30 days, so the inbox table does not grow forever.
/// The scheduler runs it every night. You can run it at any time, and more than once.
/// </summary>
public record CleanUpInboxRequest : ICatServiceRequest;
