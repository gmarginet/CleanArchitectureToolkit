using System.Reflection;
using Cat.Messaging.Abstractions;
using Cat.Messaging.AzureServiceBus;

namespace Cat.Messaging.Tests;

[TestFixture]
public class AzureServiceBusTests
{
    [Test]
    public void Mapper_CopiesTheIdsTheSubjectTheSessionAndTheScheduledTime()
    {
        var at = DateTimeOffset.UtcNow.AddHours(1);
        var outgoing = new CatOutgoingMessage
        {
            EntityName = "OrderPlaced",
            Body = [1, 2, 3],
            ContentType = "application/json",
            MessageId = Guid.NewGuid(),
            CorrelationId = Guid.NewGuid(),
            Subject = "OrderPlaced",
            SessionId = "order-7",
            ScheduledAt = at,
            Properties = new Dictionary<string, string> { ["tenant"] = "a" }
        };

        var message = CatServiceBusMessageMapper.ToServiceBusMessage(outgoing);

        Assert.That(message.MessageId, Is.EqualTo(outgoing.MessageId.ToString()));
        Assert.That(message.CorrelationId, Is.EqualTo(outgoing.CorrelationId.ToString()));
        Assert.That(message.Subject, Is.EqualTo("OrderPlaced"));
        Assert.That(message.ContentType, Is.EqualTo("application/json"));
        Assert.That(message.SessionId, Is.EqualTo("order-7"));
        Assert.That(message.ScheduledEnqueueTime, Is.EqualTo(at));
        Assert.That(message.Body.ToArray(), Is.EqualTo(new byte[] { 1, 2, 3 }));
        Assert.That(message.ApplicationProperties["tenant"], Is.EqualTo("a"));
    }

    [Test]
    public void Topology_FindsOnlyConcreteMessageTypes()
    {
        var types = ServiceBusTopology.FindMessageTypes([typeof(OrderPlaced).Assembly]).ToList();

        Assert.That(types, Does.Contain(typeof(OrderPlaced)));
        Assert.That(types, Does.Contain(typeof(ReserveStock)));
        Assert.That(types, Does.Contain(typeof(PaymentExpired)));
        Assert.That(types, Does.Not.Contain(typeof(AbstractMessage)));
        Assert.That(types, Does.Not.Contain(typeof(NotAMessage)));
    }
}
