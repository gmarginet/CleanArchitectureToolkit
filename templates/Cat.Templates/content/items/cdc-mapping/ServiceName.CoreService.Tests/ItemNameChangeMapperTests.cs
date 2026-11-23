using Cat.Sql.Cdc.Abstractions;
using ServiceName.CoreService.Cdc;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ItemNameChangeMapperTests
{
    [Test]
    public void Map_WithAnInsert_ShouldFillTheNewValues()
    {
        var id = Guid.NewGuid();
        var change = new CatChange
        {
            Table = "dbo_ItemName",
            Operation = CatChangeOperation.Insert,
            Lsn = new byte[10],
            SequenceValue = new byte[10],
            Keys = new Dictionary<string, object?> { ["Id"] = id },
            New = new Dictionary<string, object?> { ["Name"] = "Example" }
        };

        var message = ItemNameChangeMapper.Map(change);

        Assert.That(message.MessageId, Is.EqualTo(change.MessageId));
        Assert.That(message.Id, Is.EqualTo(id));
        Assert.That(message.Operation, Is.EqualTo("Insert"));
        Assert.That(message.OldName, Is.Null);
        Assert.That(message.NewName, Is.EqualTo("Example"));
    }

    [Test]
    public void Map_WithADelete_ShouldFillTheOldValues()
    {
        var change = new CatChange
        {
            Table = "dbo_ItemName",
            Operation = CatChangeOperation.Delete,
            Lsn = new byte[10],
            SequenceValue = new byte[10],
            Keys = new Dictionary<string, object?> { ["Id"] = Guid.NewGuid() },
            Old = new Dictionary<string, object?> { ["Name"] = "Example" }
        };

        var message = ItemNameChangeMapper.Map(change);

        Assert.That(message.Operation, Is.EqualTo("Delete"));
        Assert.That(message.OldName, Is.EqualTo("Example"));
        Assert.That(message.NewName, Is.Null);
    }
}
