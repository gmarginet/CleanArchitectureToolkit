using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Commands.Abstractions;
using Cat.Demo.OrderService.Contracts.ServiceRequests;
using Cat.Demo.OrderService.CoreService.Commands;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Demo.OrderService.CoreService.ServiceRequestHandlers;

public class CleanUpOutboxRequestHandler : ICatServiceRequestHandler<CleanUpOutboxRequest>
{
    /// <summary>
    /// How long a sent outbox row stays. The demo uses 30 days.
    /// </summary>
    public static readonly TimeSpan Retention = TimeSpan.FromDays(30);

    private readonly ICatCommandProcessor _commandProcessor;
    private readonly TimeProvider _timeProvider;

    public CleanUpOutboxRequestHandler(ICatCommandProcessor commandProcessor, TimeProvider timeProvider)
    {
        _commandProcessor = commandProcessor;
        _timeProvider = timeProvider;
    }

    public async Task<ICatResponse> HandleAsync(CleanUpOutboxRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var response = await _commandProcessor.ProcessAsync(new OutboxCleanUpCommand(_timeProvider.GetUtcNow() - Retention), cancellationToken);
        return response.IsSucceeded ? CatResponse.NoContent() : response;
    }
}
