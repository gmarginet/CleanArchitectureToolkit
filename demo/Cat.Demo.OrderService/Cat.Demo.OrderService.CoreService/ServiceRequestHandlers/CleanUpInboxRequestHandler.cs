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

public class CleanUpInboxRequestHandler : ICatServiceRequestHandler<CleanUpInboxRequest>
{
    /// <summary>
    /// How long an inbox row stays. The demo uses 30 days.
    /// </summary>
    public static readonly TimeSpan Retention = TimeSpan.FromDays(30);

    private readonly ICatCommandProcessor _commandProcessor;
    private readonly TimeProvider _timeProvider;

    public CleanUpInboxRequestHandler(ICatCommandProcessor commandProcessor, TimeProvider timeProvider)
    {
        _commandProcessor = commandProcessor;
        _timeProvider = timeProvider;
    }

    public async Task<ICatResponse> HandleAsync(CleanUpInboxRequest serviceRequest, CancellationToken cancellationToken = default)
    {
        var response = await _commandProcessor.ProcessAsync(new InboxCleanUpCommand(_timeProvider.GetUtcNow() - Retention), cancellationToken);
        return response.IsSucceeded ? CatResponse.NoContent() : response;
    }
}
