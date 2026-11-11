using Azure.Messaging.ServiceBus;
using Cat.EventProcessor.AzureServiceBus;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class AzureServiceBusTests
{
    [Test]
    public void Mapper_CopiesTheBodyTheIdsAndTheProperties()
    {
        var received = ServiceBusModelFactory.ServiceBusReceivedMessage(
            body: BinaryData.FromString("{\"orderNumber\":\"ORD-1\"}"),
            messageId: "id-1",
            contentType: "application/json",
            deliveryCount: 3,
            properties: new Dictionary<string, object> { ["tenant"] = "a" });

        var incoming = ServiceBusIncomingMessageMapper.ToIncomingMessage(received);

        Assert.That(incoming.MessageId, Is.EqualTo("id-1"));
        Assert.That(incoming.ContentType, Is.EqualTo("application/json"));
        Assert.That(incoming.DeliveryCount, Is.EqualTo(3));
        Assert.That(incoming.Properties["tenant"], Is.EqualTo("a"));
        Assert.That(System.Text.Encoding.UTF8.GetString(incoming.Body), Does.Contain("ORD-1"));
    }

    [Test]
    public async Task HealthCheck_IsHealthyWhenAllListenersRun()
    {
        var status = new ListenerStatus();
        status.Add(() => true);

        var result = await new EventProcessorHealthCheck(status).CheckHealthAsync(new HealthCheckContext());

        Assert.That(result.Status, Is.EqualTo(HealthStatus.Healthy));
    }

    [Test]
    public async Task HealthCheck_IsUnhealthyWhenAListenerStopped()
    {
        var status = new ListenerStatus();
        status.Add(() => true);
        status.Add(() => false);

        var result = await new EventProcessorHealthCheck(status).CheckHealthAsync(new HealthCheckContext());

        Assert.That(result.Status, Is.EqualTo(HealthStatus.Unhealthy));
    }

    [Test]
    public async Task HealthCheck_IsDegradedRightAfterAnError()
    {
        var status = new ListenerStatus();
        status.Add(() => true);
        status.ReportError();

        var result = await new EventProcessorHealthCheck(status).CheckHealthAsync(new HealthCheckContext());

        Assert.That(result.Status, Is.EqualTo(HealthStatus.Degraded));
    }
}
