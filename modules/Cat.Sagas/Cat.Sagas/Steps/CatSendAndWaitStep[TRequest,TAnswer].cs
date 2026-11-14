using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Cat.Messaging.Abstractions;
using Cat.Sagas.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Sagas.Steps;

/// <summary>
/// Built-in step behind <c>SendAndWait</c>. It hands the request message to the saga and suspends the workflow.
/// The saga saves the state first and sends the message after that. When the answer comes, the step ends and the workflow goes on.
/// When the wait has a timeout and it passes first, the step ends with <see cref="TimedOut"/> set and no <see cref="Answer"/>.
/// </summary>
/// <typeparam name="TRequest">The request message. It is an event or a command message with a parameterless constructor and a settable <c>CorrelationId</c>.</typeparam>
/// <typeparam name="TAnswer">The answer the step waits for. It can be a base class or an interface when the step accepts more than one answer message.</typeparam>
public class CatSendAndWaitStep<TRequest, TAnswer> : CatStepBodyAsync, ICatResumableStepBody
    where TRequest : class, ICatMessage
    where TAnswer : class
{
    private readonly CatSagaContext _context;

    /// <summary>
    /// Creates the step and the request, using the parameterless constructor of the request.
    /// </summary>
    /// <param name="context">The running saga.</param>
    /// <param name="logger">The logger the step can use.</param>
    public CatSendAndWaitStep(CatSagaContext context, ILogger<CatSendAndWaitStep<TRequest, TAnswer>> logger)
        : base(logger)
    {
        _context = context;
        Request = (TRequest)Activator.CreateInstance(typeof(TRequest));
    }

    /// <summary>
    /// The request message. Fill its members with <c>Input</c>.
    /// </summary>
    public TRequest Request { get; }

    /// <summary>
    /// The name of the step. <c>SendAndWait</c> fills it. A timeout and an answer find the step by it.
    /// </summary>
    public string StepName { get; set; } = string.Empty;

    /// <summary>
    /// How long the wait lasts. <c>SendAndWait</c> fills it. Null means the wait has no timeout.
    /// </summary>
    public TimeSpan? Timeout { get; set; }

    /// <summary>
    /// The answer, after the step resumed with one. It is null when <see cref="TimedOut"/> is true. Read it with <c>Output</c>.
    /// </summary>
    public TAnswer? Answer { get; private set; }

    /// <summary>
    /// True when the wait timed out before an answer came. Read it with <c>Output</c> and branch on it.
    /// </summary>
    public bool TimedOut { get; private set; }

    /// <inheritdoc />
    /// <exception cref="InvalidOperationException">The request has no settable <c>CorrelationId</c>.</exception>
    public override Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        var property = typeof(TRequest).GetProperty(nameof(ICatMessage.CorrelationId), BindingFlags.Public | BindingFlags.Instance);
        if (property?.SetMethod == null || !property.SetMethod.IsPublic)
        {
            throw new InvalidOperationException(
                $"The request {typeof(TRequest).Name} needs a public setter for CorrelationId, so the saga can put its id in it. Inherit CatEventMessage or CatCommandMessage.");
        }

        property.SetValue(Request, _context.InstanceId);
        _context.Pending.Add(new CatPendingMessage(Request, null));

        var wait = new CatSagaWait
        {
            StepName = StepName,
            WaitId = Guid.NewGuid(),
            AnswerType = typeof(TAnswer).AssemblyQualifiedName ?? typeof(TAnswer).FullName ?? typeof(TAnswer).Name
        };

        if (Timeout.HasValue)
        {
            wait.TimeoutAt = DateTimeOffset.UtcNow.Add(Timeout.Value);
            _context.Pending.Add(new CatPendingMessage(
                new CatSagaTimeout { CorrelationId = _context.InstanceId, WaitId = wait.WaitId, StepName = StepName },
                wait.TimeoutAt));
        }

        _context.Waits.Add(wait);
        return Task.FromResult(CatWorkflowResponse.Suspended());
    }

    /// <inheritdoc />
    /// <exception cref="CatWorkflowResumeException">The answer is not a <typeparamref name="TAnswer"/>.</exception>
    public Task<ICatWorkflowResponse> ResumeAsync(object? answer, CancellationToken cancellationToken = default)
    {
        if (answer is CatSagaTimedOut)
        {
            TimedOut = true;
        }
        else if (answer is TAnswer typed)
        {
            Answer = typed;
        }
        else
        {
            throw new CatWorkflowResumeException(
                $"The step {GetType().Name} expects an answer of type {typeof(TAnswer).Name}, but got {answer?.GetType().Name ?? "null"}.");
        }

        return Task.FromResult(CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue));
    }
}
