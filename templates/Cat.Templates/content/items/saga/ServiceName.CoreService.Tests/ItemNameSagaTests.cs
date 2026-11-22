using Cat.FluentWorkflows.Extensions;
using Cat.Messaging.Abstractions;
using Cat.Sagas;
using Cat.Sagas.Abstractions;
using Cat.Sagas.Extensions;
using Cat.UnitTesting.Messaging;
using Cat.UnitTesting.NUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ServiceName.CoreService.Messages;
using ServiceName.CoreService.Workflows;

namespace ServiceName.CoreService.Tests;

/// <summary>
/// The saga from the start to the answer. It runs in memory with a fake sender,
/// and the test plays the part of the other service by giving the dispatcher the answer.
/// </summary>
[TestFixture]
public class ItemNameSagaTests : UnitTestBase
{
    private readonly FakeMessageSender _sender = new();

    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatFluentWorkflowsModule();
        services.AddCatFluentWorkflowsFlows(typeof(ItemNameSaga));
        services.AddCatSagasModule();
        services.AddCatSagasInMemoryStore();
        services.AddCatSaga<ItemNameSaga, ItemNameSagaState>();
        services.AddSingleton<ICatMessageSender>(_sender);
    }

    [SetUp]
    public void SetUp() => _sender.Reset();

    [Test]
    public async Task Start_ShouldSendTheRequestAndWait()
    {
        using var scope = ServiceProvider.CreateScope();
        var id = Guid.NewGuid();

        var result = await scope.ServiceProvider.GetRequiredService<ICatSagaRunner>()
            .StartAsync<ItemNameSaga, ItemNameSagaState>(new ItemNameSagaState { Id = id });

        var request = _sender.Of<ItemNameRequested>().Single();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Waiting));
            Assert.That(request.Id, Is.EqualTo(id));
            Assert.That(request.CorrelationId, Is.EqualTo(result.InstanceId));
        }
    }

    [Test]
    public async Task Answer_ShouldCompleteTheSaga()
    {
        using var scope = ServiceProvider.CreateScope();
        var id = Guid.NewGuid();
        var started = await scope.ServiceProvider.GetRequiredService<ICatSagaRunner>()
            .StartAsync<ItemNameSaga, ItemNameSagaState>(new ItemNameSagaState { Id = id });

        await scope.ServiceProvider.GetRequiredService<ICatSagaDispatcher>()
            .ResumeAsync(started.InstanceId, new ItemNameAnswered { CorrelationId = started.InstanceId, Id = id });

        var instance = await scope.ServiceProvider.GetRequiredService<ICatSagaStore>().FindAsync(started.InstanceId);
        Assert.That(instance!.Status, Is.EqualTo(CatSagaStatus.Completed));
    }
}
