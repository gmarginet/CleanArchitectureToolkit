using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Sql.Cdc.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cat.Sql.Cdc;

/// <summary>
/// The hosted service. It runs one loop for every captured table.
/// </summary>
internal sealed class CatCdcService : BackgroundService
{
    private readonly IReadOnlyList<CatCdcTable> _tables;
    private readonly ICatCdcDatabase _database;
    private readonly ICatChangeSink _sink;
    private readonly CatCdcSettings _settings;
    private readonly CatCdcStatus _status;
    private readonly ILogger<CatCdcService> _logger;
    private readonly string _owner = $"{Environment.MachineName}:{Guid.NewGuid():N}";

    public CatCdcService(IReadOnlyList<CatCdcTable> tables, ICatCdcDatabase database, ICatChangeSink sink, CatCdcSettings settings,
        CatCdcStatus status, ILogger<CatCdcService> logger)
    {
        _tables = tables;
        _database = database;
        _sink = sink;
        _settings = settings;
        _status = status;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var loops = _tables
            .Select(table => new CatCdcTableReader(table, _database, _sink, _settings, _owner, _logger))
            .Select(reader => Task.Run(() => RunLoopAsync(reader, stoppingToken), stoppingToken))
            .ToList();

        try
        {
            await Task.WhenAll(loops).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // The service is stopping.
        }
    }

    private async Task RunLoopAsync(CatCdcTableReader reader, CancellationToken cancellationToken)
    {
        var initialized = false;

        while (!cancellationToken.IsCancellationRequested)
        {
            var delay = _settings.PollInterval;

            try
            {
                if (!initialized)
                {
                    await reader.InitializeAsync(cancellationToken).ConfigureAwait(false);
                    initialized = true;
                }

                var count = await reader.PollAsync(cancellationToken).ConfigureAwait(false);
                _status.Succeed(reader.Name);

                // A full batch means more is waiting, so read again at once.
                if (count >= _settings.BatchSize)
                {
                    delay = TimeSpan.Zero;
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            catch (CatCdcGapException exception)
            {
                _logger.LogError(exception, "The reader of {Table} stops.", reader.Name);
                CatSqlCdcTelemetry.RecordError(reader.Name, "gap");
                _status.Stop(reader.Name, exception.Message);
                return;
            }
            catch (Exception exception)
            {
                // The position did not move, so the next round tries the same changes again.
                _logger.LogError(exception, "The reader of {Table} failed. It tries again.", reader.Name);
                CatSqlCdcTelemetry.RecordError(reader.Name, "poll");
                _status.Fail(reader.Name, exception);
            }

            if (delay > TimeSpan.Zero)
            {
                try
                {
                    await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }
    }
}
