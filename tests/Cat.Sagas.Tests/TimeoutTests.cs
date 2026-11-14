using Cat.FluentWorkflows.Abstractions;
using Cat.Responses.Abstractions;
using Cat.Sagas.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.UnitTesting.Responses.NUnit;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Sagas.Tests;

[TestFixture]
public class TimeoutTests
{
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp() => _provider = SagaTestHost.Create();

    [TearDown]
    public void TearDown() => _provider.Dispose();

    private async Task<CatSagaResult> StartAsync<TWorkflow>(OrderState? state = null) where TWorkflow : ICatWorkflow<OrderState>
    {
        using var scope = _provider.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<ICatSagaRunner>().StartAsync<TWorkflow, OrderState>(state ?? new OrderState());
    }

    private async Task<ICatResponse> HandleAsync<TMessage>(TMessage message) where TMessage : class, ICatServiceRequest
    {
        using var scope = _provider.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<ICatServiceRequestHandler<TMessage>>().HandleAsync(message);
    }

    private IEnumerable<TMessage> SentOf<TMessage>() => _provider.GetRequiredService<CheckingSender>().Sent.Select(s => s.Message).OfType<TMessage>();

    private async Task<(CatSagaInstance Instance, OrderState State, List<CatSagaWait> Waits)> LoadAsync(Guid id)
    {
        var instance = (await _provider.GetRequiredService<ICatSagaStore>().FindAsync(id))!;
        var serializer = _provider.GetRequiredService<ICatSagaSerializer>();
        var state = (OrderState)serializer.Deserialize(instance.State, typeof(OrderState));
        var waits = string.IsNullOrEmpty(instance.Waits)
            ? []
            : (List<CatSagaWait>)serializer.Deserialize(instance.Waits, typeof(List<CatSagaWait>));
        return (instance, state, waits);
    }

    [Test]
    public async Task Start_WithATimeout_SendsAScheduledTimeoutMessageForTheWait()
    {
        var started = await StartAsync<TimeoutFlow>();

        var sent = _provider.GetRequiredService<CheckingSender>().Sent;
        var request = sent.Single(s => s.Message is TakePayment);
        var timeout = sent.Single(s => s.Message is CatSagaTimeout);
        var (_, _, waits) = await LoadAsync(started.InstanceId);
        var wait = waits.Single();
        Assert.That(request.ScheduledAt, Is.Null);
        Assert.That(timeout.ScheduledAt, Is.EqualTo(wait.TimeoutAt));
        Assert.That(timeout.ScheduledAt!.Value, Is.EqualTo(DateTimeOffset.UtcNow.AddHours(24)).Within(TimeSpan.FromMinutes(1)));
        var message = (CatSagaTimeout)timeout.Message;
        Assert.That(message.CorrelationId, Is.EqualTo(started.InstanceId));
        Assert.That(message.WaitId, Is.EqualTo(wait.WaitId));
        Assert.That(message.StepName, Is.EqualTo("payment"));
        Assert.That(timeout.InstanceWasSaved, Is.True);
    }

    [Test]
    public async Task Start_WithoutATimeout_SendsNoTimeoutMessage()
    {
        await StartAsync<PaymentFlow>();

        Assert.That(SentOf<CatSagaTimeout>(), Is.Empty);
    }

    [Test]
    public async Task Timeout_ResumesTheWorkflowWithTimedOutAndNoAnswer()
    {
        var started = await StartAsync<TimeoutFlow>();

        var response = await HandleAsync(SentOf<CatSagaTimeout>().Single());

        Assert.That(response, CatIs.Succeeded);
        var (instance, state, waits) = await LoadAsync(started.InstanceId);
        Assert.That(instance.Status, Is.EqualTo(CatSagaStatus.Completed));
        Assert.That(state.TimedOut, Is.True);
        Assert.That(state.Taken, Is.Null);
        Assert.That(state.Log, Is.EqualTo(new[] { "cancelled" }));
        Assert.That(waits, Is.Empty);
    }

    [Test]
    public async Task Answer_BeforeTheTimeout_MakesTheLateTimeoutHarmless()
    {
        var started = await StartAsync<TimeoutFlow>();
        await HandleAsync(new PaymentTaken { CorrelationId = started.InstanceId });

        var late = await HandleAsync(SentOf<CatSagaTimeout>().Single());

        Assert.That(late, CatIs.Succeeded);
        var (instance, state, _) = await LoadAsync(started.InstanceId);
        Assert.That(instance.Status, Is.EqualTo(CatSagaStatus.Completed));
        Assert.That(state.TimedOut, Is.False);
        Assert.That(state.Log, Is.EqualTo(new[] { "confirmed" }));
    }

    [Test]
    public async Task Timeout_ForAnUnknownInstance_IsNotFound()
    {
        var response = await HandleAsync(new CatSagaTimeout { CorrelationId = Guid.NewGuid(), WaitId = Guid.NewGuid() });

        Assert.That(response, CatIs.FailedWith(CatResponseType.NotFound, "CAT-SAG-1001"));
    }

    [Test]
    public async Task Timeout_OfAnEarlierWait_DoesNotFireTheWaitThatFollows()
    {
        var started = await StartAsync<TwoWaitsFlow>();
        var firstTimeout = SentOf<CatSagaTimeout>().Single();
        await HandleAsync(new PaymentTaken { CorrelationId = started.InstanceId });
        var (_, _, waitsAfterPayment) = await LoadAsync(started.InstanceId);
        Assert.That(waitsAfterPayment.Single().StepName, Is.EqualTo("shipping"));

        var response = await HandleAsync(firstTimeout);

        Assert.That(response, CatIs.Succeeded);
        var (instance, state, waits) = await LoadAsync(started.InstanceId);
        Assert.That(instance.Status, Is.EqualTo(CatSagaStatus.Waiting));
        Assert.That(waits.Single().StepName, Is.EqualTo("shipping"));
        Assert.That(state.Log, Is.Empty);
    }

    [Test]
    public async Task Timeout_OfTheSecondWait_ResumesIt()
    {
        var started = await StartAsync<TwoWaitsFlow>();
        await HandleAsync(new PaymentTaken { CorrelationId = started.InstanceId });
        var shippingTimeout = SentOf<CatSagaTimeout>().Single(t => t.StepName == "shipping");

        await HandleAsync(shippingTimeout);

        var (instance, state, _) = await LoadAsync(started.InstanceId);
        Assert.That(instance.Status, Is.EqualTo(CatSagaStatus.Completed));
        Assert.That(state.Shipped, Is.False);
        Assert.That(state.Log, Is.EqualTo(new[] { "done" }));
    }

    [Test]
    public async Task ParallelWaits_AreBothOpenAndAnswersFindTheirStepByType()
    {
        var started = await StartAsync<ParallelWaitsFlow>();
        var (_, _, waits) = await LoadAsync(started.InstanceId);
        Assert.That(waits.Select(w => w.StepName), Is.EquivalentTo(new[] { "payment", "shipping" }));

        await HandleAsync(new ShipmentConfirmed { CorrelationId = started.InstanceId });

        var (afterShipping, stateAfterShipping, waitsAfterShipping) = await LoadAsync(started.InstanceId);
        Assert.That(afterShipping.Status, Is.EqualTo(CatSagaStatus.Waiting));
        Assert.That(waitsAfterShipping.Single().StepName, Is.EqualTo("payment"));
        Assert.That(stateAfterShipping.Shipped, Is.True);

        await HandleAsync(new PaymentTaken { CorrelationId = started.InstanceId });

        var (done, state, _) = await LoadAsync(started.InstanceId);
        Assert.That(done.Status, Is.EqualTo(CatSagaStatus.Completed));
        Assert.That(state.Taken, Is.Not.Null);
        Assert.That(state.Log, Is.EqualTo(new[] { "done" }));
    }

    [Test]
    public async Task ParallelWaits_AnAnswerThatFitsNoWait_IsAConflict()
    {
        var started = await StartAsync<ParallelWaitsFlow>();

        var response = await HandleAsync(new PaymentDeclined { CorrelationId = started.InstanceId });

        Assert.That(response, CatIs.FailedWith(CatResponseType.Conflict, "CAT-SAG-1003"));
        Assert.That((await LoadAsync(started.InstanceId)).Waits, Has.Count.EqualTo(2));
    }
}
