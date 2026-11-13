using Cat.Commands.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.Commands;

/// <summary>Publishes a low stock report with the stock items below the limit. It publishes nothing when none is below.</summary>
public record LowStockReportPublishCommand(int Limit) : ICatCommand;
