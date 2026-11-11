using Cat.Messaging.AzureServiceBus;

namespace Cat.Messaging.Tests;

[TestFixture]
public class AdministrationConnectionStringTests
{
    [Test]
    public void Resolve_UsesTheAdministrationConnectionStringWhenItIsSet()
    {
        var options = new CatServiceBusOptions { ConnectionString = "messages", AdministrationConnectionString = "administration" };

        Assert.That(options.ResolveAdministrationConnectionString(), Is.EqualTo("administration"));
    }

    [Test]
    public void Resolve_FallsBackToTheConnectionString()
    {
        var options = new CatServiceBusOptions { ConnectionString = "messages" };

        Assert.That(options.ResolveAdministrationConnectionString(), Is.EqualTo("messages"));
    }
}
