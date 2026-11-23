using Cat.UnitTesting.Users;
using Cat.Users.Abstractions;

namespace Cat.Users.Tests;

/// <summary>
/// The tests of the chapter "Tests" in the module readme. They show how a handler gets a user in a unit test.
/// </summary>
[TestFixture]
public class FakeUserTests
{
    [Test]
    public void Handle_WithAnAdmin_ShouldSaveTheUserId()
    {
        var user = new FakeUser { UserId = "u-1" }.InRole("admin");
        var handler = new SavePriceHandler(user);

        var saved = handler.Handle();

        Assert.That(saved, Is.True);
        Assert.That(handler.LastUpdatedBy, Is.EqualTo("u-1"));
    }

    [Test]
    public void Handle_WithoutTheRole_ShouldNotSave()
    {
        var handler = new SavePriceHandler(new FakeUser());

        var saved = handler.Handle();

        Assert.That(saved, Is.False);
        Assert.That(handler.LastUpdatedBy, Is.Null);
    }

    [Test]
    public void Worker_WithTheSystemUser_ShouldRunAsTheSystem()
    {
        var accessor = new FakeUserAccessor();
        var worker = new CleanupWorker(accessor);

        worker.Run();

        Assert.That(accessor.User.UserId, Is.EqualTo("orders"));
        Assert.That(accessor.User.IsInRole(CatUser.SystemRole), Is.True);
    }

    private sealed class SavePriceHandler(ICatUser user)
    {
        public string? LastUpdatedBy { get; private set; }

        public bool Handle()
        {
            if (!user.IsInRole("admin"))
            {
                return false;
            }

            LastUpdatedBy = user.UserId;
            return true;
        }
    }

    private sealed class CleanupWorker(ICatUserAccessor accessor)
    {
        public void Run() => accessor.User = CatUser.System("orders");
    }
}
