namespace Cat.EventProcessor.AzureServiceBus;

/// <summary>
/// Tracks the state of the listeners, for the health check.
/// </summary>
internal sealed class ListenerStatus
{
    private readonly object _lock = new();
    private readonly List<Func<bool>> _isRunning = new();
    private DateTimeOffset? _lastError;

    /// <summary>
    /// Adds a listener to watch.
    /// </summary>
    /// <param name="isRunning">Tells whether the listener is processing messages.</param>
    public void Add(Func<bool> isRunning)
    {
        lock (_lock)
        {
            _isRunning.Add(isRunning);
        }
    }

    /// <summary>
    /// Records an error that a listener reported.
    /// </summary>
    public void ReportError()
    {
        _lastError = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// The number of listeners.
    /// </summary>
    public int Count
    {
        get
        {
            lock (_lock)
            {
                return _isRunning.Count;
            }
        }
    }

    /// <summary>
    /// The number of listeners that are not processing.
    /// </summary>
    public int StoppedCount
    {
        get
        {
            lock (_lock)
            {
                return _isRunning.Count(isRunning => !isRunning());
            }
        }
    }

    /// <summary>
    /// When the last error was reported, if any.
    /// </summary>
    public DateTimeOffset? LastError => _lastError;
}
