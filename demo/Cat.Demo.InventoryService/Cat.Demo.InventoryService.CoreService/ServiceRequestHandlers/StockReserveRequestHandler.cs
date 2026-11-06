using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.InventoryService.Contracts.ServiceRequests;
using Cat.Demo.InventoryService.CoreService.Commands;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.InventoryService.CoreService.ServiceRequestHandlers;

public class StockReserveRequestHandler : ICatServiceRequestHandler<StockReserveRequest>
{
    private readonly ICatCommandProcessor _commandProcessor;

    public StockReserveRequestHandler(ICatCommandProcessor commandProcessor)
    {
        _commandProcessor = commandProcessor;
    }

    public Task<ICatResponse> HandleAsync(StockReserveRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var reservation = serviceRequest.Reservation;

        // A book can appear on two lines. The stock of one book is taken once, for the sum.
        var lines = reservation.Lines
            .GroupBy(line => line.Isbn)
            .Select(group => new StockLine(group.Key, group.Sum(line => line.Quantity)))
            .ToList();

        return _commandProcessor.ProcessAsync(new StockReserveCommand(reservation.OrderNumber, lines), cancellationToken);
    }
}
