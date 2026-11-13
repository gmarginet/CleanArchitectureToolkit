using Cat.Scheduling.Abstractions;

namespace Cat.Scheduling.Tests;

[TestFixture]
public class InMemoryClaimStoreTests
{
    private static readonly DateTimeOffset Due = new DateTimeOffset(2026, 11, 13, 0, 5, 0, TimeSpan.Zero);
    private static readonly DateTimeOffset Now = Due.AddSeconds(1);

    private InMemoryJobClaimStore _store = null!;

    [SetUp]
    public void SetUp()
    {
        _store = new InMemoryJobClaimStore();
    }

    [Test]
    public async Task TryClaim_FirstCaller_Claims()
    {
        var result = await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        Assert.That(result.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
        Assert.That(result.Claim!.JobName, Is.EqualTo("job"));
        Assert.That(result.Claim.DueTime, Is.EqualTo(Due));
    }

    [Test]
    public async Task TryClaim_SameDueTime_IsTakenByTheFirst()
    {
        await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        var second = await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        Assert.That(second.Status, Is.EqualTo(CatJobClaimStatus.TakenByOther));
        Assert.That(second.Claim, Is.Null);
    }

    [Test]
    public async Task TryClaim_AnotherJob_IsIndependent()
    {
        await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        var other = await _store.TryClaimAsync("other", Due, Now, false, TimeSpan.FromHours(1));

        Assert.That(other.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
    }

    [Test]
    public async Task TryClaim_PreviousRunStillBusy_IsBusy()
    {
        await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        var next = await _store.TryClaimAsync("job", Due.AddDays(1), Now.AddMinutes(30), false, TimeSpan.FromHours(1));

        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Busy));
    }

    [Test]
    public async Task TryClaim_PreviousRunStillBusyAndOverlapAllowed_Claims()
    {
        await _store.TryClaimAsync("job", Due, Now, true, TimeSpan.FromHours(1));

        var next = await _store.TryClaimAsync("job", Due.AddMinutes(1), Now.AddMinutes(1), true, TimeSpan.FromHours(1));

        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
    }

    [Test]
    public async Task TryClaim_PreviousRunIsDead_Claims()
    {
        await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));

        var next = await _store.TryClaimAsync("job", Due.AddDays(1), Now.AddDays(1), false, TimeSpan.FromHours(1));

        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
    }

    [Test]
    public async Task TryClaim_PreviousRunFinished_Claims()
    {
        var first = await _store.TryClaimAsync("job", Due, Now, false, TimeSpan.FromHours(1));
        await _store.CompleteAsync(first.Claim!, new CatJobRunResult(CatJobRunStatus.Succeeded, null, 1), Now.AddSeconds(5));

        var next = await _store.TryClaimAsync("job", Due.AddMinutes(1), Now.AddMinutes(1), false, TimeSpan.FromHours(1));

        Assert.That(next.Status, Is.EqualTo(CatJobClaimStatus.Claimed));
    }

    [Test]
    public async Task GetLastDueTime_NeverRan_IsNull()
    {
        Assert.That(await _store.GetLastDueTimeAsync("job"), Is.Null);
    }

    [Test]
    public async Task GetLastDueTime_ReturnsTheLatestDueTimeOfThatJob()
    {
        await _store.TryClaimAsync("job", Due, Now, true, TimeSpan.FromHours(1));
        await _store.TryClaimAsync("job", Due.AddDays(2), Now, true, TimeSpan.FromHours(1));
        await _store.TryClaimAsync("job", Due.AddDays(1), Now, true, TimeSpan.FromHours(1));
        await _store.TryClaimAsync("other", Due.AddDays(9), Now, true, TimeSpan.FromHours(1));

        Assert.That(await _store.GetLastDueTimeAsync("job"), Is.EqualTo(Due.AddDays(2)));
    }
}
