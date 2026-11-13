using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Cat.Sql.Cdc.Abstractions;

namespace Cat.Sql.Cdc;

/// <summary>
/// One captured table and what its changes become.
/// </summary>
public sealed class CatCdcTable
{
    internal CatCdcTable(string captureInstance, Func<CatChange, object> map)
    {
        CaptureInstance = captureInstance;
        Map = map;
    }

    /// <summary>
    /// The name of the capture instance, such as <c>dbo_BookPrice</c>.
    /// </summary>
    public string CaptureInstance { get; }

    /// <summary>
    /// Makes the message of a change.
    /// </summary>
    public Func<CatChange, object> Map { get; }
}

/// <summary>
/// Sets the mapping of one table to a message type.
/// </summary>
/// <typeparam name="TMessage">The message type.</typeparam>
public sealed class CatCdcTableBuilder<TMessage>
    where TMessage : class
{
    internal Func<CatChange, TMessage>? Mapper { get; private set; }

    /// <summary>
    /// Says how a change becomes a message. Use <see cref="CatChange.MessageId"/> as the id of the message.
    /// </summary>
    /// <param name="map">Makes the message.</param>
    /// <returns>The same builder.</returns>
    public CatCdcTableBuilder<TMessage> Map(Func<CatChange, TMessage> map)
    {
        Mapper = map;
        return this;
    }
}

/// <summary>
/// Collects the tables to capture. You get one in <c>AddCatSqlCdc</c>.
/// </summary>
public sealed class CatCdcBuilder
{
    private static readonly Regex NamePattern = new(@"^[A-Za-z0-9_]+$", RegexOptions.Compiled);

    private readonly List<CatCdcTable> _tables = [];

    internal IReadOnlyList<CatCdcTable> Tables => _tables;

    /// <summary>
    /// Captures a table and sends every change as it is. The sink gets the <see cref="CatChange"/> as the message.
    /// </summary>
    /// <param name="captureInstance">The capture instance, such as <c>dbo_BookPrice</c>. Only letters, digits and underscores.</param>
    /// <returns>The same builder.</returns>
    public CatCdcBuilder AddTable(string captureInstance)
    {
        Add(captureInstance, change => change);
        return this;
    }

    /// <summary>
    /// Captures a table and turns every change into a message of your own type.
    /// </summary>
    /// <typeparam name="TMessage">The message type.</typeparam>
    /// <param name="captureInstance">The capture instance, such as <c>dbo_BookPrice</c>. Only letters, digits and underscores.</param>
    /// <param name="configure">Sets the mapping with <c>t.Map(change =&gt; ...)</c>.</param>
    /// <returns>The same builder.</returns>
    /// <exception cref="InvalidOperationException">The configuration gives no mapping.</exception>
    public CatCdcBuilder AddTable<TMessage>(string captureInstance, Action<CatCdcTableBuilder<TMessage>> configure)
        where TMessage : class
    {
        var tableBuilder = new CatCdcTableBuilder<TMessage>();
        configure(tableBuilder);

        var mapper = tableBuilder.Mapper
                     ?? throw new InvalidOperationException($"The table '{captureInstance}' needs a mapping. Call Map in the configuration.");

        Add(captureInstance, change => mapper(change));
        return this;
    }

    private void Add(string captureInstance, Func<CatChange, object> map)
    {
        if (string.IsNullOrWhiteSpace(captureInstance) || !NamePattern.IsMatch(captureInstance))
        {
            throw new ArgumentException("A capture instance has only letters, digits and underscores.", nameof(captureInstance));
        }

        if (_tables.Exists(t => string.Equals(t.CaptureInstance, captureInstance, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"The table '{captureInstance}' is already added.");
        }

        _tables.Add(new CatCdcTable(captureInstance, map));
    }
}
