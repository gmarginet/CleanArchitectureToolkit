using Cat.Sql.Cdc.Abstractions;

namespace Cat.Sql.Cdc.Tests;

[TestFixture]
public class CatCdcRowMapperTests
{
    private static CatCdcRawRow Row(int operation, int lsn, int seq, int id, string name) => new()
    {
        Operation = operation,
        Lsn = Lsn.Of(lsn),
        SequenceValue = Lsn.Of(seq),
        TransactionId = [1, 2],
        Values = new Dictionary<string, object?> { ["Id"] = id, ["Name"] = name }
    };

    [Test]
    public void ToChanges_Insert_HasNewValuesAndKeys()
    {
        var changes = CatCdcRowMapper.ToChanges("dbo_Book", [Row(2, 5, 1, 7, "a")], 10, ["Id"]);

        var change = changes.Single();
        Assert.That(change.Operation, Is.EqualTo(CatChangeOperation.Insert));
        Assert.That(change.Old, Is.Null);
        Assert.That(change.New!["Name"], Is.EqualTo("a"));
        Assert.That(change.Keys["Id"], Is.EqualTo(7));
        Assert.That(change.Table, Is.EqualTo("dbo_Book"));
    }

    [Test]
    public void ToChanges_Delete_HasOldValuesAndKeys()
    {
        var change = CatCdcRowMapper.ToChanges("t", [Row(1, 5, 1, 7, "a")], 10, ["Id"]).Single();

        Assert.That(change.Operation, Is.EqualTo(CatChangeOperation.Delete));
        Assert.That(change.New, Is.Null);
        Assert.That(change.Old!["Name"], Is.EqualTo("a"));
        Assert.That(change.Keys["Id"], Is.EqualTo(7));
    }

    [Test]
    public void ToChanges_UpdateRows_BecomeOneChangeWithOldAndNew()
    {
        var change = CatCdcRowMapper.ToChanges("t", [Row(3, 5, 1, 7, "old"), Row(4, 5, 2, 7, "new")], 10, ["Id"]).Single();

        Assert.That(change.Operation, Is.EqualTo(CatChangeOperation.Update));
        Assert.That(change.Old!["Name"], Is.EqualTo("old"));
        Assert.That(change.New!["Name"], Is.EqualTo("new"));
        Assert.That(change.SequenceValue, Is.EqualTo(Lsn.Of(2)));
    }

    [Test]
    public void ToChanges_UpdateWithoutItsSecondRow_StopsBeforeIt()
    {
        var changes = CatCdcRowMapper.ToChanges("t", [Row(2, 5, 1, 1, "a"), Row(3, 6, 1, 2, "old")], 10, ["Id"]);

        Assert.That(changes, Has.Count.EqualTo(1));
    }

    [Test]
    public void ToChanges_StopsAtTheBatchSize()
    {
        var rows = new[] { Row(2, 5, 1, 1, "a"), Row(2, 5, 2, 2, "b"), Row(2, 5, 3, 3, "c") };

        var changes = CatCdcRowMapper.ToChanges("t", rows, 2, ["Id"]);

        Assert.That(changes, Has.Count.EqualTo(2));
    }

    [Test]
    public void ToChanges_UnknownOperation_Throws()
    {
        Assert.Throws<InvalidOperationException>(() => CatCdcRowMapper.ToChanges("t", [Row(9, 5, 1, 1, "a")], 10, ["Id"]));
    }

    [Test]
    public void MessageId_IsStableAndDiffersPerChangeAndOperation()
    {
        var first = new CatChange { Lsn = Lsn.Of(5), SequenceValue = Lsn.Of(1), Operation = CatChangeOperation.Insert };
        var same = new CatChange { Lsn = Lsn.Of(5), SequenceValue = Lsn.Of(1), Operation = CatChangeOperation.Insert };
        var otherSequence = new CatChange { Lsn = Lsn.Of(5), SequenceValue = Lsn.Of(2), Operation = CatChangeOperation.Insert };
        var otherOperation = new CatChange { Lsn = Lsn.Of(5), SequenceValue = Lsn.Of(1), Operation = CatChangeOperation.Delete };

        Assert.That(first.MessageId, Is.EqualTo(same.MessageId));
        Assert.That(first.MessageId, Is.Not.EqualTo(otherSequence.MessageId));
        Assert.That(first.MessageId, Is.Not.EqualTo(otherOperation.MessageId));
    }

    [Test]
    public void Binary_Compare_FollowsSqlServerOrder()
    {
        Assert.That(CatCdcBinary.Compare(Lsn.Of(1), Lsn.Of(2)), Is.LessThan(0));
        Assert.That(CatCdcBinary.Compare(Lsn.Of(300), Lsn.Of(2)), Is.GreaterThan(0));
        Assert.That(CatCdcBinary.Compare(Lsn.Of(2), Lsn.Of(2)), Is.EqualTo(0));
    }
}
