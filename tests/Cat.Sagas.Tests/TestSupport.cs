using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Messaging.Abstractions;
using Cat.Sagas;
using Cat.Sagas.Abstractions;
using Cat.Sagas.Extensions;
using Cat.ServiceRequests.Abstractions;
using Cat.UnitTesting.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Cat.Sagas.Tests;

public class OrderState : ICatWorkflowState<OrderState>
{
    public Guid OrderId { get; set; }
    public List<string> Log { get; set; } = [];
    public PaymentTaken? Taken { get; set; }
    public bool Declined { get; set; }
    public bool TimedOut { get; set; }
    public bool Shipped { get; set; }
}

public class ShipGoods : CatCommandMessage
{
    public Guid OrderId { get; set; }
}

public class ShipmentConfirmed : CatEventMessage, ICatServiceRequest
{
    public Guid OrderId { get; set; }
}

/// <summary>Waits for the payment, and gives up after a day.</summary>
public class TimeoutFlow : ICatWorkflow<OrderState>
{
    public void Build(ICatWorkflowBuilder<OrderState> builder)
    {
        builder.SendAndWait<OrderState, TakePayment, PaymentTaken>("payment", TimeSpan.FromHours(24))
            .Input(s => s.OrderId, step => step.Request.OrderId)
            .Output(step => step.Answer, s => s.Taken)
            .Output(step => step.TimedOut, s => s.TimedOut);
        builder.If(s => s.TimedOut,
            then => then.Run(s => s.Log.Add("cancelled")),
            otherwise => otherwise.Run(s => s.Log.Add("confirmed")));
    }
}

/// <summary>Two waits one after the other, both with a timeout.</summary>
public class TwoWaitsFlow : ICatWorkflow<OrderState>
{
    public void Build(ICatWorkflowBuilder<OrderState> builder)
    {
        builder.SendAndWait<OrderState, TakePayment, PaymentTaken>("payment", TimeSpan.FromHours(1))
            .Output(step => step.TimedOut, s => s.TimedOut);
        builder.SendAndWait<OrderState, ShipGoods, ShipmentConfirmed>("shipping", TimeSpan.FromHours(2))
            .Output(step => step.Answer != null, s => s.Shipped);
        builder.Run(s => s.Log.Add("done"));
    }
}

/// <summary>Waits for the payment and the shipment at the same time.</summary>
public class ParallelWaitsFlow : ICatWorkflow<OrderState>
{
    public void Build(ICatWorkflowBuilder<OrderState> builder)
    {
        builder.Parallel(branches => branches
                .Branch(b => b.SendAndWait<OrderState, TakePayment, PaymentTaken>("payment")
                    .Output(step => step.Answer, s => s.Taken))
                .Branch(b => b.SendAndWait<OrderState, ShipGoods, ShipmentConfirmed>("shipping")
                    .Output(step => step.Answer != null, s => s.Shipped)),
            CatParallelRule.SuspendUntilAllDone);
        builder.Run(s => s.Log.Add("done"));
    }
}

public class TakePayment : CatCommandMessage
{
    public Guid OrderId { get; set; }
}

public abstract class PaymentAnswer : CatEventMessage, ICatServiceRequest
{
    public Guid OrderId { get; set; }
}

public class PaymentTaken : PaymentAnswer
{
}

public class PaymentDeclined : PaymentAnswer
{
}

/// <summary>Waits for one answer type.</summary>
public class PaymentFlow : ICatWorkflow<OrderState>
{
    public void Build(ICatWorkflowBuilder<OrderState> builder)
    {
        builder.Run(s => s.Log.Add("started"));
        builder.SendAndWait<OrderState, TakePayment, PaymentTaken>("payment")
            .Input(s => s.OrderId, step => step.Request.OrderId)
            .Output(step => step.Answer, s => s.Taken);
        builder.Run(s => s.Log.Add("confirmed"));
    }
}

/// <summary>Waits for a base type, so both outcomes of the payment arrive at the same step.</summary>
public class EitherPaymentFlow : ICatWorkflow<OrderState>
{
    public void Build(ICatWorkflowBuilder<OrderState> builder)
    {
        builder.Run(s => s.Log.Add("started"));
        builder.SendAndWait<OrderState, TakePayment, PaymentAnswer>("payment")
            .Input(s => s.OrderId, step => step.Request.OrderId)
            .Output(step => step.Answer is PaymentDeclined, s => s.Declined);
        builder.If(s => s.Declined,
            then => then.Run(s => s.Log.Add("cancelled")),
            otherwise => otherwise.Run(s => s.Log.Add("confirmed")));
    }
}

/// <summary>Never waits.</summary>
public class QuickFlow : ICatWorkflow<OrderState>
{
    public void Build(ICatWorkflowBuilder<OrderState> builder)
    {
        builder.Run(s => s.Log.Add("done"));
    }
}

/// <summary>Remembers if the instance was already saved at the moment a message went out.</summary>
public class CheckingSender : ICatMessageSender
{
    private readonly ICatSagaStore _store;

    public CheckingSender(ICatSagaStore store)
    {
        _store = store;
    }

    public List<(ICatMessage Message, bool InstanceWasSaved, DateTimeOffset? ScheduledAt)> Sent { get; } = [];

    public async Task PublishAsync(ICatEventMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default)
    {
        Sent.Add((message, await _store.FindAsync(message.CorrelationId, cancellationToken) != null, scheduledAt));
    }

    public async Task SendAsync(ICatCommandMessage message, DateTimeOffset? scheduledAt = null, CancellationToken cancellationToken = default)
    {
        Sent.Add((message, await _store.FindAsync(message.CorrelationId, cancellationToken) != null, scheduledAt));
    }
}

public static class SagaTestHost
{
    public static ServiceProvider Create()
    {
        var services = new ServiceCollection();
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatFluentWorkflowsModule();
        services.AddCatFluentWorkflowsFlows(typeof(PaymentFlow));
        services.AddCatSagasModule();
        services.AddCatSagasInMemoryStore();
        services.AddSingleton<CheckingSender>();
        services.AddSingleton<ICatMessageSender>(p => p.GetRequiredService<CheckingSender>());
        services.AddCatSaga<PaymentFlow, OrderState>();
        services.AddCatSaga<EitherPaymentFlow, OrderState>();
        services.AddCatSaga<QuickFlow, OrderState>();
        services.AddCatSaga<TimeoutFlow, OrderState>();
        services.AddCatSaga<TwoWaitsFlow, OrderState>();
        services.AddCatSaga<ParallelWaitsFlow, OrderState>();
        services.AddCatSagaAnswer<PaymentTaken>();
        services.AddCatSagaAnswer<PaymentDeclined>();
        services.AddCatSagaAnswer<ShipmentConfirmed>();
        return services.BuildServiceProvider();
    }
}
