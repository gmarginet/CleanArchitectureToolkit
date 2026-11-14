using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows;
using Cat.FluentWorkflows.Abstractions;
using Cat.Messaging.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.Sagas.Steps;

/// <summary>
/// Built-in step behind <c>SendAndWait</c>. It hands the request message to the saga and suspends the workflow.
/// The saga saves the state first and sends the message after that. When the answer comes, the step ends and the workflow goes on.
/// </summary>
/// <typeparam name="TRequest">The request message. It is an event or a command message with a parameterless constructor and a settable <c>CorrelationId</c>.</typeparam>
/// <typeparam name="TAnswer">The answer the step waits for. It can be a base class or an interface when the step accepts more than one answer message.</typeparam>
public class CatSendAndWaitStep<TRequest, TAnswer> : CatResumableStepBody<TAnswer>
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
    /// The answer, after the step resumed. Read it with <c>Output</c>.
    /// </summary>
    public TAnswer? Answer { get; private set; }

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
        _context.Pending.Add(Request);
        _context.WaitingFor = typeof(TAnswer).Name;

        return Task.FromResult(CatWorkflowResponse.Suspended());
    }

    /// <inheritdoc />
    protected override Task<ICatWorkflowResponse> ResumeAsync(TAnswer answer, CancellationToken cancellationToken)
    {
        Answer = answer;
        return Task.FromResult(CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue));
    }
}
