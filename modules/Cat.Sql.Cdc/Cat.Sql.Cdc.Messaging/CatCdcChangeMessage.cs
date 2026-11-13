using System;
using System.Collections.Generic;
using Cat.Messaging.Abstractions;
using Cat.Sql.Cdc.Abstractions;

namespace Cat.Sql.Cdc.Messaging;

/// <summary>
/// The message a table gets when it is added without a mapping. It carries the change as column dictionaries.
/// Map the table to a message of your own to get a typed message instead.
/// </summary>
[CatMessage(Name = "cat-sql-cdc-change")]
public class CatCdcChangeMessage : CatEventMessage
{
    /// <summary>
    /// The capture instance the change comes from.
    /// </summary>
    public string Table { get; set; } = string.Empty;

    /// <summary>
    /// What happened to the row.
    /// </summary>
    public CatChangeOperation Operation { get; set; }

    /// <summary>
    /// The id of the transaction. All changes of one transaction share it.
    /// </summary>
    public string TransactionId { get; set; } = string.Empty;

    /// <summary>
    /// When the transaction committed.
    /// </summary>
    public DateTimeOffset TransactionTime { get; set; }

    /// <summary>
    /// The key columns and their values.
    /// </summary>
    public IReadOnlyDictionary<string, object?> Keys { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// The values before the change, or <c>null</c> for an insert.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? Old { get; set; }

    /// <summary>
    /// The values after the change, or <c>null</c> for a delete.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? New { get; set; }
}
