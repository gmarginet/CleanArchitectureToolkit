using Cat.Sql.Cdc.Abstractions;
using ServiceName.Contracts.Messages;

namespace ServiceName.CoreService.Cdc;

/// <summary>
/// Turns one captured change of the table ItemName into <see cref="ItemNameChanged"/>.
/// Register it where the service calls AddCatSqlCdc:
/// <c>cdc.AddTable&lt;ItemNameChanged&gt;("dbo_ItemName", t => t.Map(ItemNameChangeMapper.Map));</c>
/// The names of the columns below are an example. Use the columns of your table.
/// </summary>
public static class ItemNameChangeMapper
{
    public static ItemNameChanged Map(CatChange change) => new()
    {
        // The id of the change is stable, so a receiver can recognize a message that comes twice.
        MessageId = change.MessageId,
        Id = (Guid)change.Keys["Id"]!,
        Operation = change.Operation.ToString(),
        OldName = (string?)change.Old?["Name"],
        NewName = (string?)change.New?["Name"]
    };
}
