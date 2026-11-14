using Cat.Responses.Abstractions;
using Cat.Sagas.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.UnitTesting.Responses.NUnit;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Sagas.Tests;

[TestFixture]
public class SagaTests
{
    private ServiceProvider _provider = null!;

    [SetUp]
    public void SetUp() => _provider = SagaTestHost.Create();

    [TearDown]
    public void TearDown() => _provider.Dispose();

    private async Task<CatSagaResult> StartAsync<TWorkflow>(OrderState state, Guid? id = null)
        where TWorkflow : Cat.FluentWorkflows.Abstractions.ICatWorkflow<OrderState>
    {
        using var scope = _provider.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<ICatSagaRunner>().StartAsync<TWorkflow, OrderState>(state, id);
    }

    private async Task<ICatResponse> AnswerAsync<TAnswer>(TAnswer answer) where TAnswer : class, Cat.Messaging.Abstractions.ICatMessage, ICatServiceRequest
    {
        using var scope = _provider.CreateScope();
        return await scope.ServiceProvider.GetRequiredService<ICatServiceRequestHandler<TAnswer>>().HandleAsync(answer);
    }

    private async Task<CatSagaInstance> InstanceAsync(Guid id)
    {
        var instance = await _provider.GetRequiredService<ICatSagaStore>().FindAsync(id);
        return instance!;
    }

    private OrderState StateOf(CatSagaInstance instance)
        => (OrderState)_provider.GetRequiredService<ICatSagaSerializer>().Deserialize(instance.State, typeof(OrderState));

    [Test]
    public async Task Start_StopsAtTheWaitStepAndSavesTheInstance()
    {
        var orderId = Guid.NewGuid();

        var result = await StartAsync<PaymentFlow>(new OrderState { OrderId = orderId });

        Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Waiting));
        var instance = await InstanceAsync(result.InstanceId);
        Assert.That(instance.Status, Is.EqualTo(CatSagaStatus.Waiting));
        var wait = ((List<CatSagaWait>)_provider.GetRequiredService<ICatSagaSerializer>().Deserialize(instance.Waits!, typeof(List<CatSagaWait>))).Single();
        Assert.That(wait.StepName, Is.EqualTo("payment"));
        Assert.That(wait.AnswerType, Does.StartWith(typeof(PaymentTaken).FullName!));
        Assert.That(wait.TimeoutAt, Is.Null);
        Assert.That(instance.WorkflowType, Is.EqualTo(typeof(PaymentFlow).FullName));
        Assert.That(StateOf(instance).Log, Is.EqualTo(new[] { "started" }));
    }

    [Test]
    public async Task Start_SendsTheRequestWithTheInstanceIdAfterTheInstanceIsSaved()
    {
        var orderId = Guid.NewGuid();

        var result = await StartAsync<PaymentFlow>(new OrderState { OrderId = orderId });

        var sent = _provider.GetRequiredService<CheckingSender>().Sent.Single();
        var request = (TakePayment)sent.Message;
        Assert.That(request.CorrelationId, Is.EqualTo(result.InstanceId));
        Assert.That(request.OrderId, Is.EqualTo(orderId));
        Assert.That(sent.InstanceWasSaved, Is.True);
    }

    [Test]
    public async Task Start_WithAGivenCorrelationId_UsesItForTheInstance()
    {
        var id = Guid.NewGuid();

        var result = await StartAsync<PaymentFlow>(new OrderState(), id);

        Assert.That(result.InstanceId, Is.EqualTo(id));
    }

    [Test]
    public async Task Answer_ResumesTheWorkflowAndCompletesTheInstance()
    {
        var orderId = Guid.NewGuid();
        var started = await StartAsync<PaymentFlow>(new OrderState { OrderId = orderId });

        var response = await AnswerAsync(new PaymentTaken { CorrelationId = started.InstanceId, OrderId = orderId });

        Assert.That(response, CatIs.Succeeded);
        var instance = await InstanceAsync(started.InstanceId);
        Assert.That(instance.Status, Is.EqualTo(CatSagaStatus.Completed));
        Assert.That(instance.Checkpoint, Is.Null);
        var state = StateOf(instance);
        Assert.That(state.Log, Is.EqualTo(new[] { "started", "confirmed" }));
        Assert.That(state.Taken!.OrderId, Is.EqualTo(orderId));
    }

    [Test]
    public async Task Answer_ForTheSameInstanceTwice_IsIgnoredTheSecondTime()
    {
        var started = await StartAsync<PaymentFlow>(new OrderState());
        var answer = new PaymentTaken { CorrelationId = started.InstanceId };
        await AnswerAsync(answer);

        var second = await AnswerAsync(answer);

        Assert.That(second, CatIs.Succeeded);
        Assert.That(StateOf(await InstanceAsync(started.InstanceId)).Log, Is.EqualTo(new[] { "started", "confirmed" }));
    }

    [Test]
    public async Task Answer_ForAnUnknownInstance_IsNotFound()
    {
        var response = await AnswerAsync(new PaymentTaken { CorrelationId = Guid.NewGuid() });

        Assert.That(response, CatIs.FailedWith(CatResponseType.NotFound, "CAT-SAG-1001"));
    }

    [Test]
    public async Task Answer_OfAnotherTypeThanTheStepWaitsFor_IsAConflictAndTheInstanceKeepsWaiting()
    {
        var started = await StartAsync<PaymentFlow>(new OrderState());

        var response = await AnswerAsync(new PaymentDeclined { CorrelationId = started.InstanceId });

        Assert.That(response, CatIs.FailedWith(CatResponseType.Conflict, "CAT-SAG-1003"));
        Assert.That((await InstanceAsync(started.InstanceId)).Status, Is.EqualTo(CatSagaStatus.Waiting));
    }

    [Test]
    public async Task Answer_OfADerivedType_ReachesAStepThatWaitsForTheBaseType()
    {
        var started = await StartAsync<EitherPaymentFlow>(new OrderState());

        await AnswerAsync(new PaymentDeclined { CorrelationId = started.InstanceId });

        var state = StateOf(await InstanceAsync(started.InstanceId));
        Assert.That(state.Declined, Is.True);
        Assert.That(state.Log, Is.EqualTo(new[] { "started", "cancelled" }));
    }

    [Test]
    public async Task Answer_TakenOnTheBaseTypeStep_TakesTheOtherBranch()
    {
        var started = await StartAsync<EitherPaymentFlow>(new OrderState());

        await AnswerAsync(new PaymentTaken { CorrelationId = started.InstanceId });

        Assert.That(StateOf(await InstanceAsync(started.InstanceId)).Log, Is.EqualTo(new[] { "started", "confirmed" }));
    }

    [Test]
    public async Task Start_OfAWorkflowThatNeverWaits_CompletesAndSavesNothing()
    {
        var result = await StartAsync<QuickFlow>(new OrderState());

        Assert.That(result.Status, Is.EqualTo(CatSagaStatus.Completed));
        Assert.That(await _provider.GetRequiredService<ICatSagaStore>().FindAsync(result.InstanceId), Is.Null);
        Assert.That(_provider.GetRequiredService<CheckingSender>().Sent, Is.Empty);
    }

    [Test]
    public async Task Start_OfAWorkflowThatIsNotRegistered_Throws()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddSingleton(typeof(Microsoft.Extensions.Logging.ILogger<>), typeof(Microsoft.Extensions.Logging.Abstractions.NullLogger<>));
        Cat.FluentWorkflows.Extensions.ServiceCollectionExtensions.AddCatFluentWorkflowsModule(services);
        Cat.FluentWorkflows.Extensions.ServiceCollectionExtensions.AddCatFluentWorkflowsFlows(services, typeof(PaymentFlow));
        Cat.Sagas.Extensions.ServiceCollectionExtensions.AddCatSagasModule(services);
        Cat.Sagas.Extensions.ServiceCollectionExtensions.AddCatSagasInMemoryStore(services);
        services.AddSingleton<Cat.Messaging.Abstractions.ICatMessageSender, Cat.UnitTesting.Messaging.FakeMessageSender>();
        using var provider = services.BuildServiceProvider();
        using var scope = provider.CreateScope();

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            scope.ServiceProvider.GetRequiredService<ICatSagaRunner>().StartAsync<PaymentFlow, OrderState>(new OrderState()));
    }

    [Test]
    public async Task Store_UpdateWithAnOldVersion_ThrowsAConcurrencyException()
    {
        var started = await StartAsync<PaymentFlow>(new OrderState());
        var store = _provider.GetRequiredService<ICatSagaStore>();
        var first = (await store.FindAsync(started.InstanceId))!;
        var second = (await store.FindAsync(started.InstanceId))!;

        await store.UpdateAsync(first);

        await Assert.ThrowsAsync<CatSagaConcurrencyException>(() => store.UpdateAsync(second));
        Assert.That(first.Version, Is.EqualTo(2));
    }

    [Test]
    public async Task Store_AddOfAnExistingId_ThrowsAConcurrencyException()
    {
        var started = await StartAsync<PaymentFlow>(new OrderState());
        var store = _provider.GetRequiredService<ICatSagaStore>();

        await Assert.ThrowsAsync<CatSagaConcurrencyException>(() => store.AddAsync(new CatSagaInstance { Id = started.InstanceId }));
    }
}
