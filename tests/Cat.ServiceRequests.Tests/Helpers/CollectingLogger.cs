using Microsoft.Extensions.Logging;

namespace Cat.ServiceRequests.Tests.Helpers;

/// <summary>
/// Keeps every log entry of every logger, so a test can look at what was logged.
/// </summary>
public class LogCollector
{
    private readonly object _lock = new();
    private readonly List<(LogLevel Level, string Message)> _entries = [];

    public IReadOnlyList<(LogLevel Level, string Message)> Entries
    {
        get
        {
            lock (_lock) return _entries.ToList();
        }
    }

    public void Add(LogLevel level, string message)
    {
        lock (_lock) _entries.Add((level, message));
    }

    public void Clear()
    {
        lock (_lock) _entries.Clear();
    }
}

public class CollectingLogger<T> : ILogger<T>
{
    private readonly LogCollector _collector;

    public CollectingLogger(LogCollector collector)
    {
        _collector = collector;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        _collector.Add(logLevel, formatter(state, exception));
    }
}
