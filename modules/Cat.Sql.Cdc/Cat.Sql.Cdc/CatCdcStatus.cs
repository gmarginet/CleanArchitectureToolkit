using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Cat.Sql.Cdc;

/// <summary>
/// What the readers report: which table stopped for good, and which one failed on its last poll.
/// The health check reads it.
/// </summary>
internal sealed class CatCdcStatus
{
    private readonly ConcurrentDictionary<string, string> _stopped = new();
    private readonly ConcurrentDictionary<string, string> _failing = new();

    public int Stopped => _stopped.Count;

    public string StoppedDescription => string.Join(" ", _stopped.Select(pair => $"{pair.Key}: {pair.Value}"));

    public int Failing => _failing.Count;

    public string FailingDescription => string.Join(" ", _failing.Select(pair => $"{pair.Key}: {pair.Value}"));

    public void Stop(string table, string reason) => _stopped[table] = reason;

    public void Fail(string table, Exception exception) => _failing[table] = exception.Message;

    public void Succeed(string table) => _failing.TryRemove(table, out _);
}
