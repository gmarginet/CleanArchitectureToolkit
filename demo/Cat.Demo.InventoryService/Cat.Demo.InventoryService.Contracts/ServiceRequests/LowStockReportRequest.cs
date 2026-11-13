using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.InventoryService.Contracts.ServiceRequests;

/// <summary>
/// Publishes a low stock report when stock items are below the limit. Nothing is published when all stock is fine.
/// The scheduler runs it every night. You can run it at any time, and more than once.
/// </summary>
public record LowStockReportRequest : ICatServiceRequest;
