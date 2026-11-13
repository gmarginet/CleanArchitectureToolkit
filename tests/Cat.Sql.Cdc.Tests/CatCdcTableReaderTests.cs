using Cat.Sql.Cdc.Abstractions;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Sql.Cdc.Tests;

[TestFixture]
public class CatCdcTableReaderTests
{
    private FakeCdcDatabase _database = null!;
    private RecordingSink _sink = null!;
    private CatCdcSettings _settings = null!;

    [SetUp]
    public void SetUp()
    {
        _database = new FakeCdcDatabase();
        _sink = new RecordingSink();
        _settings = new CatCdcSettings { BatchSize = 10 };
    }

    private CatCdcTableReader CreateReader(Func<CatChange, object>? map = null)
    {
        var builder = new CatCdcBuilder();
        builder.AddTable("dbo_BookPrice");
        var table = map == null ? builder.Tables[0] : CreateTable(map);
        return new CatCdcTableReader(table, _database, _sink, _settings, "owner", NullLogger.Instance);
    }

    private static CatCdcTable CreateTable(Func<CatChange, object> map)
    {
        var builder = new CatCdcBuilder();
        builder.AddTable<string>("dbo_BookPrice", t => t.Map(c => (string)map(c)));
        return builder.Tables[0];
    }

    private static CatChange Change(int lsn, int seq, CatChangeOperation operation = CatChangeOperation.Insert) => new()
    {
        Table = "dbo_BookPrice",
        Operation = operation,
        Lsn = Lsn.Of(lsn),
        SequenceValue = Lsn.Of(seq)
    };

    [Test]
    public async Task Poll_FirstStart_ReadsFromTheOldestChangeAndSavesThePosition()
    {
        _database.Changes.AddRange([Change(2, 1), Change(2, 2), Change(5, 1)]);

        var count = await CreateReader().PollAsync(CancellationToken.None);

        Assert.That(count, Is.EqualTo(3));
        Assert.That(_sink.Received, Has.Count.EqualTo(3));
        Assert.That(_database.Saved, Has.Count.EqualTo(1));
        Assert.That(_database.Saved[0].Lsn, Is.EqualTo(Lsn.Of(5)));
        Assert.That(_database.Saved[0].SequenceValue, Is.EqualTo(Lsn.Of(1)));
    }

    [Test]
    public async Task Poll_SecondRound_DoesNotSendTheSameChangesAgain()
    {
        _database.Changes.AddRange([Change(2, 1), Change(5, 1)]);
        var reader = CreateReader();

        await reader.PollAsync(CancellationToken.None);
        var second = await reader.PollAsync(CancellationToken.None);

        Assert.That(second, Is.EqualTo(0));
        Assert.That(_sink.Received, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task Poll_NothingNew_MovesThePositionToTheNewestLsn()
    {
        var count = await CreateReader().PollAsync(CancellationToken.None);

        Assert.That(count, Is.EqualTo(0));
        Assert.That(_database.Position!.Lsn, Is.EqualTo(Lsn.Of(100)));
    }

    [Test]
    public async Task Poll_SinkFails_DoesNotMoveThePosition_AndTheNextRoundRepeats()
    {
        _database.Changes.Add(Change(2, 1));
        _sink.FailWith = new InvalidOperationException("bus down");
        var reader = CreateReader();

        await Assert.ThrowsAsync<InvalidOperationException>(() => reader.PollAsync(CancellationToken.None));
        Assert.That(_database.Saved, Is.Empty);

        _sink.FailWith = null;
        var count = await reader.PollAsync(CancellationToken.None);

        Assert.That(count, Is.EqualTo(1));
        Assert.That(_sink.Received, Has.Count.EqualTo(1));
    }

    [Test]
    public async Task Poll_OtherInstanceHoldsTheClaim_ReadsNothing()
    {
        _database.ClaimAvailable = false;
        _database.Changes.Add(Change(2, 1));

        var count = await CreateReader().PollAsync(CancellationToken.None);

        Assert.That(count, Is.EqualTo(-1));
        Assert.That(_sink.Received, Is.Empty);
    }

    [Test]
    public async Task Poll_ClaimLostBeforeSave_Throws()
    {
        _database.Changes.Add(Change(2, 1));
        _database.SaveSucceeds = false;

        await Assert.ThrowsAsync<InvalidOperationException>(() => CreateReader().PollAsync(CancellationToken.None));
    }

    [Test]
    public async Task Poll_PositionOlderThanTheOldestChange_FailsByDefault()
    {
        _database.Min = Lsn.Of(50);
        _database.Position = new CatCdcPosition(Lsn.Of(10), Lsn.Of(1));

        await Assert.ThrowsAsync<CatCdcGapException>(() => CreateReader().PollAsync(CancellationToken.None));
    }

    [Test]
    public async Task Poll_PositionOlderThanTheOldestChange_CanSkipToTheOldest()
    {
        _settings.OnRetentionGap = CatCdcGapBehavior.SkipToOldest;
        _database.Min = Lsn.Of(50);
        _database.Position = new CatCdcPosition(Lsn.Of(10), Lsn.Of(1));
        _database.Changes.AddRange([Change(20, 1), Change(60, 1)]);

        var count = await CreateReader().PollAsync(CancellationToken.None);

        Assert.That(count, Is.EqualTo(1));
        Assert.That(_sink.Received[0].Change.Lsn, Is.EqualTo(Lsn.Of(60)));
    }

    [Test]
    public async Task Poll_CaptureInstanceMissing_Throws()
    {
        _database.Min = null;

        await Assert.ThrowsAsync<InvalidOperationException>(() => CreateReader().PollAsync(CancellationToken.None));
    }

    [Test]
    public async Task Poll_UsesTheMappingOfTheTable()
    {
        _database.Changes.Add(Change(2, 1));

        await CreateReader(change => "changed:" + change.Table).PollAsync(CancellationToken.None);

        Assert.That(_sink.Received[0].Message, Is.EqualTo("changed:dbo_BookPrice"));
    }

    [Test]
    public async Task Poll_WithoutMapping_SendsTheChangeAsTheMessage()
    {
        _database.Changes.Add(Change(2, 1));

        await CreateReader().PollAsync(CancellationToken.None);

        Assert.That(_sink.Received[0].Message, Is.SameAs(_sink.Received[0].Change));
    }

    [Test]
    public async Task Service_DeliversChanges_AndStopsAReaderThatHitsAGap()
    {
        _settings.PollInterval = TimeSpan.FromMilliseconds(10);
        _database.Changes.Add(Change(2, 1));
        var builder = new CatCdcBuilder();
        builder.AddTable("dbo_BookPrice");
        var status = new CatCdcStatus();
        var service = new CatCdcService(builder.Tables, _database, _sink, _settings, status, NullLogger<CatCdcService>.Instance);

        await service.StartAsync(CancellationToken.None);
        await WaitUntilAsync(() => _sink.Received.Count == 1);

        Assert.That(_database.Initialized, Is.EqualTo(1));
        Assert.That(status.Stopped, Is.EqualTo(0));

        _database.Min = Lsn.Of(500);
        _database.Max = Lsn.Of(600);
        await WaitUntilAsync(() => status.Stopped == 1);
        await service.StopAsync(CancellationToken.None);

        Assert.That(status.Stopped, Is.EqualTo(1));
    }

    [Test]
    public async Task Service_SinkFails_ReportsFailingAndRecovers()
    {
        _settings.PollInterval = TimeSpan.FromMilliseconds(10);
        _database.Changes.Add(Change(2, 1));
        _sink.FailWith = new InvalidOperationException("bus down");
        var builder = new CatCdcBuilder();
        builder.AddTable("dbo_BookPrice");
        var status = new CatCdcStatus();
        var service = new CatCdcService(builder.Tables, _database, _sink, _settings, status, NullLogger<CatCdcService>.Instance);

        await service.StartAsync(CancellationToken.None);
        await WaitUntilAsync(() => status.Failing == 1);

        _sink.FailWith = null;
        await WaitUntilAsync(() => _sink.Received.Count == 1 && status.Failing == 0);
        await service.StopAsync(CancellationToken.None);

        Assert.That(_sink.Received, Has.Count.EqualTo(1));
    }

    private static async Task WaitUntilAsync(Func<bool> condition)
    {
        var until = DateTime.UtcNow.AddSeconds(5);
        while (!condition() && DateTime.UtcNow < until)
        {
            await Task.Delay(10);
        }

        Assert.That(condition(), Is.True, "The condition was not met in time.");
    }
}
