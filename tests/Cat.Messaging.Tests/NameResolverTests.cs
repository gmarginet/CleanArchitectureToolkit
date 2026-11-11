using Cat.Messaging.Abstractions;

namespace Cat.Messaging.Tests;

[TestFixture]
public class NameResolverTests
{
    private readonly CatMessageNameResolver _resolver = new();

    [Test]
    public void GetName_UsesTheTypeNameByConvention()
    {
        Assert.That(_resolver.GetName(typeof(OrderPlaced)), Is.EqualTo("OrderPlaced"));
    }

    [Test]
    public void GetName_UsesTheAttributeName()
    {
        Assert.That(_resolver.GetName(typeof(PaymentExpired)), Is.EqualTo("payment-expired"));
    }

    [Test]
    public void RequiresSession_IsOffByConventionAndOnFromTheAttribute()
    {
        Assert.That(_resolver.RequiresSession(typeof(ReserveStock)), Is.False);
        Assert.That(_resolver.RequiresSession(typeof(PaymentExpired)), Is.True);
    }

    [Test]
    public void GetKind_TellsEventsFromCommandMessages()
    {
        Assert.That(_resolver.GetKind(typeof(OrderPlaced)), Is.EqualTo(CatMessageKind.Event));
        Assert.That(_resolver.GetKind(typeof(ReserveStock)), Is.EqualTo(CatMessageKind.Command));
    }

    [Test]
    public void GetKind_ThrowsForATypeThatIsNotAMessage()
    {
        Assert.Throws<ArgumentException>(() => _resolver.GetKind(typeof(NotAMessage)));
    }
}
