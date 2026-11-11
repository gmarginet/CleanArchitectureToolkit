using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Messaging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cat.Messaging.Outbox;

/// <summary>
/// Background service that sends the pending messages of the outbox to the transport.
/// A message is marked as sent after the transport accepted it, so a crash in between sends it twice, never zero times.
/// A receiver must handle a message more than once, and duplicate detection of the bus helps with the same message ID.
/// </summary>
internal sealed class OutboxSender : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IOptions<CatOutboxOptions> _options;
    private readonly ILogger<OutboxSender> _logger;

    /// <summary>
    /// Creates the sender.
    /// </summary>
    /// <param name="scopeFactory">Opens a scope for each round, because the store is scoped.</param>
    /// <param name="options">The settings of the outbox.</param>
    /// <param name="logger">The logger.</param>
    public OutboxSender(IServiceScopeFactory scopeFactory, IOptions<CatOutboxOptions> options, ILogger<OutboxSender> logger)
    {
        _scopeFactory = scopeFactory;
        _options = options;
        _logger = logger;
    }

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await SendPendingAsync(stoppingToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "The outbox sender failed. It tries again after the poll interval.");
            }

            try
            {
                await Task.Delay(_options.Value.PollInterval, stoppingToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }
    }

    /// <summary>
    /// Sends one batch. It stops at the first message that fails, so the order of the rest is kept.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The number of messages that were sent.</returns>
    internal async Task<int> SendPendingAsync(CancellationToken cancellationToken)
    {
        var sent = 0;

        using var scope = _scopeFactory.CreateScope();
        var store = scope.ServiceProvider.GetRequiredService<ICatOutboxStore>();
        var transport = scope.ServiceProvider.GetRequiredService<ICatMessageTransport>();

        var pending = await store.GetPendingAsync(_options.Value.BatchSize, cancellationToken).ConfigureAwait(false);

        foreach (var item in pending)
        {
            await transport.SendAsync(item.Message, cancellationToken).ConfigureAwait(false);
            await store.MarkSentAsync(item.Id, cancellationToken).ConfigureAwait(false);
            sent++;
        }

        return sent;
    }
}
