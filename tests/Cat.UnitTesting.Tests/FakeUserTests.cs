using Cat.UnitTesting.Users;
using Cat.Users.Abstractions;

namespace Cat.UnitTesting.Tests;

[TestFixture]
public class FakeUserTests
{
    [Test]
    public void ANewUser_ShouldBeLoggedInWithoutRoles()
    {
        var user = new FakeUser();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(user.IsAuthenticated, Is.True);
            Assert.That(user.UserId, Is.EqualTo("test-user"));
            Assert.That(user.Name, Is.EqualTo("Test User"));
            Assert.That(user.Roles, Is.Empty);
            Assert.That(user.IsInRole("admin"), Is.False);
        }
    }

    [Test]
    public void TheTest_ShouldBeAbleToChangeEveryProperty()
    {
        var user = new FakeUser { UserId = "alice", Name = "Alice", IsAuthenticated = false };

        using (Assert.EnterMultipleScope())
        {
            Assert.That(user.UserId, Is.EqualTo("alice"));
            Assert.That(user.Name, Is.EqualTo("Alice"));
            Assert.That(user.IsAuthenticated, Is.False);
        }
    }

    [Test]
    public void InRole_ShouldGiveTheRolesAndBeChainable()
    {
        var user = new FakeUser().InRole("admin", "editor").InRole("auditor");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(user.IsInRole("admin"), Is.True);
            Assert.That(user.IsInRole("editor"), Is.True);
            Assert.That(user.IsInRole("auditor"), Is.True);
            Assert.That(user.IsInRole("other"), Is.False);
        }
    }

    [Test]
    public void Roles_ShouldBeChangeableDuringTheTest()
    {
        var user = new FakeUser().InRole("admin");

        user.Roles.Remove("admin");

        Assert.That(user.IsInRole("admin"), Is.False);
    }

    [Test]
    public void IsInRole_ShouldCompareTheCaseOfTheRole()
    {
        var user = new FakeUser().InRole("admin");

        Assert.That(user.IsInRole("Admin"), Is.False);
    }

    [Test]
    public void AUserAccessor_ShouldStartAnonymousAndHoldTheUserOfTheTest()
    {
        var accessor = new FakeUserAccessor();
        Assert.That(accessor.User, Is.SameAs(CatUser.Anonymous));

        var user = new FakeUser();
        accessor.User = user;

        Assert.That(accessor.User, Is.SameAs(user));
    }
}
